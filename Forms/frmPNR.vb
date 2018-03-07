Imports ATPI.TWME.SP.Lib
Imports Telerik.WinControls.UI
Imports Travelport.TravelData

Public Class frmPNR

    Const CtrlMask = 8

    Private mstrGenderIndicator() As String = {"M", "F", "MI", "FI", "U"}
    Private mstrSalutations() As String = {"MR", "MRS", "MS", "MISS", "MISTER"}

    Private Structure PaxNamesPos
        Dim StartPos As Integer
        Dim EndPos As Integer
    End Structure

    Private WithEvents mobjPNR As New GDSPnr
    Private mobjReadPNR As New ReadPNR
    Private mSelectedPNRGDSCode As Config.GDSCode
    Private mSelectedItnGDSCode As Config.GDSCode

    Private mflgReadPNR As Boolean
    Private mintMaxString As Integer = 80

    Private mobjAirlinePoints As New AirlinePoints.Collection
    Private mobjAirlineNotes As New AirlineNotes.Collection

    Private mobjCustomerSelected As Customers.CustomerItem
    Private mobjCustomers As New Customers.CustomerCollection

    Private mobjSubDepartmentSelected As SubDepartments.Item
    Private mobjCRMSelected As CRM.Item
    Private mobjVesselSelected As Vessels.Item
    Private mobjAveragePrice As New PriceLookup.Collection

    Private mudtPaxNames() As PaxNamesPos

    Private mOSMPax As New osmPax.PaxCollection
    Private mOSMAgents As New osmVessels.EmailCollection
    Private mOSMAgentIndex As Integer = -1

    Private mItnFromDate As Date
    Private mItnToDate As Date

    Private mflgExpiryDateOK As Boolean
    Private mflgAPISUpdate As Boolean

    Private mflgLoading As Boolean
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click, cmdItnExit.Click
        Me.Close()
    End Sub
    Private Sub cmdPNRReadAmadeusPNR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPNRReadAmadeusPNR.Click
        Try
            ClearForm()
            ReadPNR(Config.GDSCode.GDSisAmadeus)
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ClearForm()

        Try

            mobjCustomerSelected = New Customers.CustomerItem
            mobjSubDepartmentSelected = New SubDepartments.Item
            mobjCRMSelected = New CRM.Item
            mobjVesselSelected = New Vessels.Item

            lblPNR.Text = ""
            lblPax.Text = ""
            lblSegs.Text = ""

            txtCustomer.Clear()
            txtSubdepartment.Clear()
            txtCRM.Clear()
            txtVessel.Clear()
            txtAirlineEntries.Clear()

            lstVessels.Items.Clear()

            lstSubDepartments.Items.Clear()
            txtSubdepartment.Enabled = (lstSubDepartments.Items.Count > 0)

            lstCRM.Items.Clear()
            txtCRM.Enabled = (lstCRM.Items.Count > 0)

            txtReference.Clear()
            cmbDepartment.Items.Clear()
            cmbDepartment.Text = ""
            cmbBookedby.Items.Clear()
            cmbBookedby.Text = ""
            cmbReasonForTravel.Items.Clear()
            cmbReasonForTravel.Text = ""
            cmbCostCentre.Items.Clear()
            cmbCostCentre.Text = ""

            cmdPNRWrite.Enabled = False
            cmdPNRWriteWithDocs.Enabled = False
            cmdPNROnlyDocs.Enabled = False

            mobjReadPNR.ExistingElements.Clear()

            mflgAPISUpdate = False
            mflgExpiryDateOK = False

            APISPrepareGrid()

        Catch ex As Exception
            Throw New Exception("ClearForm()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub SetEnabled()

        Try
            ' read PNR and Exit are always enabled
            cmdPNRReadAmadeusPNR.Enabled = True
            cmdExit.Enabled = True

            cmdAdmin.Enabled = MySettings.Administrator
            cmdAdmin.Visible = cmdAdmin.Enabled

            ' customer based entries are enabled if a PNR has been read and there is data available
            txtCustomer.Enabled = mflgReadPNR And (lstCustomers.Items.Count > 0)
            lstCustomers.Enabled = mflgReadPNR And (lstCustomers.Items.Count > 0)
            cmdCostCentre.Enabled = mflgReadPNR And (lstCustomers.Items.Count > 0)

            txtSubdepartment.Enabled = mflgReadPNR And (lstSubDepartments.Items.Count > 0)
            lstSubDepartments.Enabled = mflgReadPNR And (lstSubDepartments.Items.Count > 0)

            txtCRM.Enabled = mflgReadPNR And (lstCRM.Items.Count > 0)
            lstCRM.Enabled = mflgReadPNR And (lstCRM.Items.Count > 0)

            txtVessel.Enabled = mflgReadPNR And (lstVessels.Items.Count > 0)
            lstVessels.Enabled = mflgReadPNR And (lstVessels.Items.Count > 0)

            ' the exception is the one time vessel which is always enabled for any PNR
            cmdOneTimeVessel.Enabled = mflgReadPNR

            ' Update is enabled if a PNR has been read and if mandatory fields have been entered
            cmdPNRWrite.Enabled = mflgReadPNR

            ' Customer is always needed

            txtCustomer.BackColor = lstCustomers.BackColor
            txtSubdepartment.BackColor = lstCustomers.BackColor
            txtCRM.BackColor = lstCustomers.BackColor
            If Not mobjReadPNR.NewElements Is Nothing Then
                If mobjReadPNR.NewElements.CustomerCode.GDSCommand = "" Then
                    cmdPNRWrite.Enabled = False
                    txtCustomer.BackColor = Color.Red
                End If

                ' if subdepartments exist they are by default madatory
                If mobjReadPNR.NewElements.CustomerCode.GDSCommand <> "" And lstSubDepartments.Items.Count > 0 And mobjReadPNR.NewElements.SubDepartmentCode.GDSCommand = "" Then
                    cmdPNRWrite.Enabled = False
                    txtSubdepartment.BackColor = Color.Red
                End If

                ' the code above is complete validation but allow entry without CRM in any case
                If mobjReadPNR.NewElements.CustomerCode.GDSCommand <> "" And lstCRM.Items.Count > 0 And mobjReadPNR.NewElements.CRMCode.GDSCommand = "" Then
                    txtCRM.BackColor = Color.Pink
                End If

                If mobjReadPNR.NewElements.BookedBy.GDSCommand = "" And cmbBookedby.Enabled Then
                    cmdPNRWrite.Enabled = False
                End If
                If mobjReadPNR.NewElements.CostCentre.GDSCommand = "" And cmbCostCentre.Enabled Then
                    cmdPNRWrite.Enabled = False
                End If
                If mobjReadPNR.NewElements.ReasonForTravel.GDSCommand = "" And cmbReasonForTravel.Enabled Then
                    cmdPNRWrite.Enabled = False
                End If
            End If

            cmdPNRWriteWithDocs.Enabled = cmdPNRWrite.Enabled And mflgAPISUpdate
            cmdPNROnlyDocs.Enabled = mflgAPISUpdate And Not mobjReadPNR.NewPNR
            dgvApis.Enabled = True

            txtReference.Enabled = True

            lblBookedByHighlight.Enabled = (cmbBookedby.Enabled)
            lblDepartmentHighlight.Enabled = (cmbDepartment.Enabled)
            lblReasonForTravelHighLight.Enabled = (cmbReasonForTravel.Enabled)
            lblCostCentreHighlight.Enabled = (cmbCostCentre.Enabled)

            SetLabelColor(lblBookedByHighlight)
            SetLabelColor(lblDepartmentHighlight)
            SetLabelColor(lblReasonForTravelHighLight)
            SetLabelColor(lblCostCentreHighlight)
        Catch ex As Exception
            Throw New Exception("SetEnabled()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub SetLabelColor(ByRef TextLabel As RadLabel)
        Try
            If TextLabel.Enabled Then
                TextLabel.BackColor = Color.FromArgb(255, 128, 128)
            Else
                TextLabel.BackColor = Color.Silver
            End If
        Catch ex As Exception
            Throw New Exception("SetLabelColor()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ReadPNR(ByVal GDSCode As Config.GDSCode)
        Dim pDMI As String
        Try
            With mobjReadPNR
                mflgReadPNR = False
                Dim mGDSUser As New GDSUser(GDSCode)
                InitSettings(mGDSUser)
                SetupPCCOptions()
                pDMI = .Read
                If .NumberOfPax = 0 And Not .IsGroup Then
                    Throw New Exception("Need passenger names")
                End If
                If pDMI <> "" Then
                    If MessageBox.Show("There is a problem with your itinerary. Do you want to cancel the PNR Finisher?" & vbCrLf & vbCrLf & pDMI, "Itinerary Check", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        Throw New Exception("PNR Finisher cancelled because of itinerary check")
                    End If
                End If
                'End If
                mflgReadPNR = True
                .PrepareNewGDSElements()
                lblPNR.Text = .PnrNumber
                If .IsGroup Then
                    lblPax.Text = "Group:" & .GroupName & " " & .GroupNamesCount
                Else
                    lblPax.Text = .PaxName
                End If

                lblSegs.Text = .Itinerary

                Dim pFromDate As Date = DateAdd(DateInterval.Month, -3, Today)

                pFromDate = DateSerial(Year(pFromDate), Month(pFromDate), 1)

                mobjAveragePrice.SetValues(pFromDate, .Itinerary)
                PrepareAirlinePoints()
            End With
            DisplayCustomer()
            APISDisplayPax()

        Catch ex As Exception
            Throw New Exception("ReadPNR()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DisplayCustomer()

        Dim pstrCustomerCode As String
        Dim pintSubDepartment As Integer
        Dim pstrCRM As String
        Dim pstrVesselName As String
        Dim pstrVesselRegistration As String

        Try
            With mobjReadPNR.ExistingElements
                pstrCustomerCode = .CustomerCode.Key
                pintSubDepartment = If(IsNumeric(.SubDepartmentCode.Key), CInt(.SubDepartmentCode.Key), 0)
                pstrCRM = .CRMCode.Key
                pstrVesselName = .VesselName.Key
                pstrVesselRegistration = .VesselFlag.Key

                mobjReadPNR.NewElements.ClearCustomerElements()

                txtCustomer.Clear()
                txtSubdepartment.Clear()
                txtCRM.Clear()
                txtVessel.Clear()

                txtReference.Text = .Reference.Key
                txtSubdepartment.Text = .SubDepartmentCode.Key
                txtCRM.Text = .CRMCode.Key
            End With

            If pstrCustomerCode <> "" Then
                Dim pCustomer As New Customers.CustomerItem
                pCustomer.Load(pstrCustomerCode)
                txtCustomer.Text = pCustomer.Code
                If pintSubDepartment <> 0 Then
                    Dim pSub As New SubDepartments.Item
                    pSub.Load(pintSubDepartment)
                    txtSubdepartment.Text = pSub.Code & " " & pSub.Name
                End If
                If pstrCRM.Length > 0 Then
                    Dim pSub As New CRM.Item
                    pSub.Load(pstrCRM)
                    txtCRM.Text = pSub.Code & " " & pSub.Name
                End If

                If pstrVesselName <> "" Then
                    Dim pVessel As New Vessels.Item
                    If pVessel.Load(pstrCustomerCode, pstrVesselName) Then
                        mobjReadPNR.NewElements.VesselNameForPNR.Clear()
                        mobjReadPNR.NewElements.VesselFlagForPNR.Clear()
                        txtVessel.Text = pVessel.Name
                    Else
                        mobjReadPNR.NewElements.SetVesselForPNR(pstrVesselName, pstrVesselRegistration)
                        txtVessel.Text = mobjReadPNR.NewElements.VesselNameForPNR.TextRequested & " REG " & mobjReadPNR.NewElements.VesselFlagForPNR.TextRequested
                    End If
                End If

                DisplayOldCustomProperty(cmbBookedby, mobjReadPNR.ExistingElements.BookedBy)
                DisplayOldCustomProperty(cmbDepartment, mobjReadPNR.ExistingElements.Department)
                DisplayOldCustomProperty(cmbReasonForTravel, mobjReadPNR.ExistingElements.ReasonForTravel)
                DisplayOldCustomProperty(cmbCostCentre, mobjReadPNR.ExistingElements.CostCentre)

                txtReference.Text = mobjReadPNR.ExistingElements.Reference.Key
                PrepareAirlinePoints()
            End If
        Catch ex As Exception
            Throw New Exception("DisplayCustomer()" & vbCrLf & ex.Message)
        End Try

    End Sub

    'Private Sub DisplayOldCustomProperty(ByRef cmbList As Telerik.WinControls.UI.RadDropDownList, ByVal Item As String)

    '    Try
    '        If Item <> "" Then

    '            If cmbList.DropDownStyle = ComboBoxStyle.DropDown Then
    '                cmbList.Text = Item
    '            Else
    '                For i As Short = 0 To cmbList.Items.Count - 1
    '                    If cmbList.Items(i).ToString.ToUpper.StartsWith(Item.ToUpper) Then
    '                        cmbList.SelectedIndex = i
    '                        Exit For
    '                    End If
    '                Next
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw New Exception("DisplayOldCustomProperty(ByRef cmbList As ComboBox, ByVal Item As String)" & vbCrLf & ex.Message)
    '    End Try

    'End Sub
    Private Sub DisplayOldCustomProperty(ByRef cmbList As Telerik.WinControls.UI.RadDropDownList, ByVal Item As GDSExisting.Item)

        Try
            If Item.Key <> "" Then
                If cmbList.DropDownStyle = ComboBoxStyle.DropDown Then
                    If Item.Key <> "" Then
                        cmbList.Text = Item.Key
                    End If
                Else
                    For i As Short = 0 To cmbList.Items.Count - 1
                        If Item.Key.ToUpper = cmbList.Items(i).ToString.ToUpper Then
                            cmbList.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Throw New Exception("DisplayOldCustomProperty(ByRef cmbList As ComboBox, ByVal Item As PNR_Finisher.AmadeusExisting.Item)" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub DisplayOldCustomProperty(ByRef cmbList As Telerik.WinControls.UI.RadDropDownList, ByVal Item As String)

        Try
            If Item <> "" Then
                If cmbList.DropDownStyle = ComboBoxStyle.DropDown Then
                    cmbList.Text = Item
                Else
                    For i As Short = 0 To cmbList.Items.Count - 1
                        If cmbList.Items(i).ToString.ToUpper.StartsWith(Item.ToUpper) Then
                            cmbList.SelectedIndex = i
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Throw New Exception("DisplayOldCustomProperty(ByRef cmbList As ComboBox, ByVal Item As String)" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub PrepareAirlinePoints()
        Try
            txtAirlineEntries.Clear()
            For Each pSeg As s1aPNR.AirSegment In mobjReadPNR.AirSegments
                mobjAirlinePoints.Load(mobjCustomerSelected.ID, pSeg.Airline)
                For Each pItem As AirlinePoints.Item In mobjAirlinePoints.Values
                    If txtAirlineEntries.Text.IndexOf(pItem.PointsCommand) < 0 Then
                        txtAirlineEntries.AppendText("> " & pItem.PointsCommand & vbCrLf)
                    End If
                Next
            Next
            If mflgReadPNR Then
                For Each pSeg As s1aPNR.AirSegment In mobjReadPNR.AirSegments
                    mobjAirlineNotes.Load(pSeg.Airline)
                    For Each pItem As AirlineNotes.Item In mobjAirlineNotes.Values
                        With pItem
                            If Not .Seaman Or Not mobjVesselSelected Is Nothing Then
                                Dim pGDSText As String = .GDSText

                                If pGDSText.Contains("<?VESSEL NAME>") Then
                                    If Not mobjVesselSelected Is Nothing Then
                                        If mobjVesselSelected.Name Is Nothing Then
                                            pGDSText = pGDSText.Replace("<?VESSEL NAME>", mobjVesselSelected.Name)
                                        Else
                                            pGDSText = pGDSText.Replace("<?VESSEL NAME>", mobjVesselSelected.Name.Replace("(", "-").Replace(")", "-").Replace("&", "-"))
                                        End If
                                    End If
                                End If

                                If pGDSText.Contains("<?VESSEL REGISTRATION>") Then
                                    If Not mobjVesselSelected Is Nothing Then
                                        If mobjVesselSelected.Flag Is Nothing Then
                                            pGDSText = pGDSText.Replace("<?VESSEL REGISTRATION>", mobjVesselSelected.Flag)
                                        Else
                                            pGDSText = pGDSText.Replace("<?VESSEL REGISTRATION>", mobjVesselSelected.Flag.Replace("(", "-").Replace(")", "-").Replace("&", "-"))
                                        End If
                                    End If
                                End If

                                If pGDSText.Contains("<?NBR OF PSGRS>") Then
                                    pGDSText = pGDSText.Replace("<?NBR OF PSGRS>", mobjReadPNR.NumberOfPax)
                                End If

                                If pGDSText.Contains("<?Segment selection>") Then
                                    pGDSText = pGDSText.Replace("<?Segment selection>", pSeg.ElementNo)
                                End If

                                Dim pGDSCommand As String
                                If .GDSElement.StartsWith("R") Then
                                    pGDSCommand = .GDSElement & " " & .AirlineCode & " " & pGDSText
                                ElseIf .GDSElement.StartsWith("S") Then
                                    pGDSCommand = .GDSElement & "-" & pGDSText
                                Else
                                    pGDSCommand = .GDSElement & " " & pGDSText
                                End If
                                If txtAirlineEntries.Text.IndexOf(pGDSCommand) < 0 Then
                                    txtAirlineEntries.AppendText("> " & pGDSCommand & vbCrLf)
                                End If

                            End If
                        End With
                    Next
                Next
            End If

        Catch ex As Exception
            Throw New Exception("PrepareAirlinePoints()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub frmPNR_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mflgLoading = True
        dgvApis.VirtualMode = False
        Try
            Dim mGDSUser As New GDSUser(Config.GDSCode.GDSisAmadeus)
            InitSettings(mGDSUser)
            SetupPCCOptions()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub
    Private Sub SetupPCCOptions()

        Try

            mflgLoading = True
            Dim pText As String = "Athens PNR Finisher (01/03/2018 12:30) "

            If MySettings.GDSPcc <> "" And MySettings.GDSUser <> "" Then
                pText &= MySettings.GDSPcc & " " & MySettings.GDSUser
                If MySettings.GDSPcc <> RequestedPCC Or MySettings.GDSUser <> RequestedUser Then
                    pText &= " (Jump in to " & RequestedPCC & " as user " & RequestedUser & ")"
                End If
                If MySettings.GDSPcc <> MyHomeSettings.GDSPcc Or MySettings.GDSUser <> MyHomeSettings.GDSUser Then
                    pText &= " (Jump in from " & MyHomeSettings.GDSPcc & " user " & MyHomeSettings.GDSUser & ")"
                End If
                Text = pText
            Else
                Throw New Exception("Please start Amadeus and restart the program")
            End If
            If CheckOptions() Then
                ' finisher tab
                mflgReadPNR = False
                ClearForm()
                SetEnabled()
                PrepareForm()
                APISPrepareGrid()

                ' itinerary tab
                LoadRemarks()
                If MySettings.AirportName = 0 Then
                    optItnAirportCode.IsChecked = True
                ElseIf MySettings.AirportName = 1 Then
                    optItnAirportname.IsChecked = True
                ElseIf MySettings.AirportName = 2 Then
                    optItnAirportBoth.IsChecked = True
                ElseIf MySettings.AirportName = 3 Then
                    optItnAirportCityName.IsChecked = True
                ElseIf MySettings.AirportName = 4 Then
                    optItnAirportCityBoth.IsChecked = True
                End If

                Select Case MySettings.FormatStyle
                    Case 0
                        optItnFormatDefault.IsChecked = True
                    Case 1
                        optItnFormatPlain.IsChecked = True
                    Case 2
                        optItnFormatSeaChefs.IsChecked = True
                    Case 3
                        optItnFormatSeaChefsWith3LetterCode.IsChecked = True
                    Case 4
                        optItnFormatEuronav.IsChecked = True
                End Select
                SetITNEnabled(True)

                chkItnVessel.Checked = MySettings.Vessel
                chkItnClass.Checked = MySettings.ClassOfService
                chkItnAirlineLocator.Checked = MySettings.AirlineLocator
                chkItnTickets.Checked = MySettings.Tickets
                chkItnPaxSegPerTicket.Checked = MySettings.PaxSegPerTkt
                chkItnSeating.Checked = MySettings.Seating
                chkItnStopovers.Checked = MySettings.ShowStopovers
                chkItnTerminal.Checked = MySettings.ShowTerminal
                chkItnFlyingTime.Checked = MySettings.FlyingTime
                chkItnCostCentre.Checked = MySettings.CostCentre

                chkItnElecItemsBan.Checked = MySettings.BanElectricalEquipment
                chkItnBrazilText.Checked = MySettings.BrazilText
                chkItnUSAText.Checked = MySettings.USAText

                cmdItn1AReadPNR.Enabled = False
                cmdItn1AReadQueue.Enabled = False
                cmdItn1GReadPNR.Enabled = False
                cmdItn1GReadQueue.Enabled = False
                optItnFormatMSReport.Enabled = cmdItn1AReadQueue.Enabled
            Else
                Throw New Exception("User not authorized for this PCC")
            End If
        Catch ex As Exception
        Finally
            mflgLoading = False
        End Try

    End Sub
    Private Sub LoadRemarks()

        Try
            With lstItnRemarks.Items()
                .Clear()
                .Add("SEAMAN FARE DOES NOT PERMIT UPGRADING")
                .Add("SEAMAN FARE DOES NOT PERMIT PRESEATING BUT WITH UPGRADING")
                .Add("SEAMAN FARE WITH UPGRADING")
                .Add("SEAMAN FARE WITH UPGRADING AND PRESEATING")
                .Add("PLEASE CHECK BELOW AND ADVISE IF OK TO ISSUE")
                .Add("ALL BOOKINGS ON TIME LIMIT")
                .Add("ALL FARES ON TODAY'S RATE/ADVANCE PURCHASE")
            End With

        Catch ex As Exception
            Throw New Exception("LoadRemarks()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Function CheckOptions() As Boolean
        Try
            With MySettings
                While Not .isValid
                    If MessageBox.Show("Please enter your details", "Options Missing", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                        Return False
                    End If
                    ShowOptionsForm()
                End While
                Return True
            End With
        Catch ex As Exception
            Throw New Exception("CheckOptions()" & vbCrLf & ex.Message)
        End Try

    End Function

    Private Sub PrepareForm()

        Try
            PrepareLists()
            PopulateCustomerList("")
        Catch ex As Exception
            Throw New Exception("PrepareForms()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub PrepareLists()

        Try
            lstCustomers.Items.Clear()

            lstSubDepartments.Items.Clear()
            mobjSubDepartmentSelected = Nothing

            lstCRM.Items.Clear()
            mobjCRMSelected = Nothing

            lstVessels.Items.Clear()
            mobjVesselSelected = Nothing

            cmdPNRWrite.Enabled = False
            cmdPNRWriteWithDocs.Enabled = False
            cmdPNROnlyDocs.Enabled = False

        Catch ex As Exception
            Throw New Exception("PrepareLists()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub PopulateCustomerList(ByVal SearchString As String)

        Try
            mobjCustomers.Load(SearchString)

            lstCustomers.Items.Clear()
            For Each pCustomer As Customers.CustomerItem In mobjCustomers.Values
                If SearchString = "" Or pCustomer.ToString.ToUpper.Contains(SearchString.ToUpper) Then
                    lstCustomers.Items.Add(pCustomer)
                End If
            Next

            If lstCustomers.Items.Count = 1 Then
                Try
                    mflgLoading = True

                    SelectCustomer(lstCustomers.Items(0))
                    txtCustomer.Text = lstCustomers.Items(0).ToString
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally
                    mflgLoading = False
                End Try
            End If
        Catch ex As Exception
            Throw New Exception("PopulateCustomerList()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub PopulateSubdepartmentsList(ByVal SearchString As String)

        Try
            Dim pobjSubDepartments As New SubDepartments.Collection

            If SearchString = "" Then
                mobjSubDepartmentSelected = Nothing
                mobjReadPNR.NewElements.SetItem(mobjSubDepartmentSelected)
            End If
            lstSubDepartments.Items.Clear()

            If Not mobjCustomerSelected Is Nothing Then
                pobjSubDepartments.Load(mobjCustomerSelected.ID)

                For Each pSubDepartment As SubDepartments.Item In pobjSubDepartments.Values
                    If SearchString = "" Or pSubDepartment.ToString.ToUpper.Contains(SearchString.ToUpper) Then
                        lstSubDepartments.Items.Add(pSubDepartment)
                    End If
                Next

                If lstSubDepartments.Items.Count = 1 Then
                    Try
                        mflgLoading = True
                        SelectSubDepartment(lstSubDepartments.Items(0))
                        txtSubdepartment.Text = lstSubDepartments.Items(0).ToString
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    Finally
                        mflgLoading = False
                    End Try
                End If
            End If
        Catch ex As Exception
            Throw New Exception("PopulateSubdepartmentsList()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub PopulateCRMList(ByVal SearchString As String)

        Try
            Dim pobjCRM As New CRM.Collection

            If SearchString = "" Then
                mobjCRMSelected = Nothing
                mobjReadPNR.NewElements.SetItem(mobjCRMSelected)
            End If
            lstCRM.Items.Clear()

            If Not mobjCustomerSelected Is Nothing Then
                pobjCRM.Load(mobjCustomerSelected.ID)

                For Each pCRM As CRM.Item In pobjCRM.Values
                    If SearchString = "" Or pCRM.ToString.ToUpper.Contains(SearchString.ToUpper) Then
                        lstCRM.Items.Add(pCRM)
                    End If
                Next
                If mobjReadPNR.NewElements.CRMCode.TextRequested <> "" And lstCRM.Items.Count = 1 Then
                    Try
                        mflgLoading = True
                        SelectCRM(lstCRM.Items(0))
                        txtCRM.Text = lstCRM.Items(0).ToString
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    Finally
                        mflgLoading = False
                    End Try
                End If
            End If
        Catch ex As Exception
            Throw New Exception("PopulateCRMList()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub PopulateVesselsList()

        Try
            Dim pobjVessels As New Vessels.Collection

            lstVessels.Items.Clear()

            If Not mobjCustomerSelected Is Nothing Then

                pobjVessels.Load(mobjCustomerSelected.ID)

                For Each pVessel As Vessels.Item In pobjVessels.Values
                    If mobjReadPNR.NewElements.VesselName.TextRequested = "" Or pVessel.ToString.ToUpper.Contains(mobjReadPNR.NewElements.VesselName.TextRequested.ToUpper) Then
                        lstVessels.Items.Add(pVessel)
                    End If
                Next
                If lstVessels.Items.Count = 1 Then
                    Try
                        mflgLoading = True
                        SelectVessel(lstVessels.Items(0))
                        txtVessel.Text = lstVessels.Items(0).ToString
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    Finally
                        mflgLoading = False
                    End Try
                End If
            End If
        Catch ex As Exception
            Throw New Exception("PopulateVesselsList()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub PopulateCustomProperties()

        Try
            cmbBookedby.Items.Clear()
            cmbDepartment.Items.Clear()
            cmbReasonForTravel.Items.Clear()
            cmbCostCentre.Items.Clear()
            cmbBookedby.Enabled = False
            cmbDepartment.Enabled = False
            cmbReasonForTravel.Enabled = False
            cmbCostCentre.Enabled = False

            If Not mobjCustomerSelected Is Nothing Then
                For Each pProp As CustomProperties.Item In mobjCustomerSelected.CustomerProperties.Values
                    If pProp.CustomPropertyID = CustomProperties.CustomPropertyIDValue.BookedBy Then
                        PrepareCustomProperty(cmbBookedby, pProp)
                    ElseIf pProp.CustomPropertyID = CustomProperties.CustomPropertyIDValue.Department Then
                        PrepareCustomProperty(cmbDepartment, pProp)
                    ElseIf pProp.CustomPropertyID = CustomProperties.CustomPropertyIDValue.ReasonFortravel Then
                        PrepareCustomProperty(cmbReasonForTravel, pProp)
                    ElseIf pProp.CustomPropertyID = CustomProperties.CustomPropertyIDValue.CostCentre Then
                        PrepareCustomProperty(cmbCostCentre, pProp)
                    End If
                Next
            End If
        Catch ex As Exception
            Throw New Exception("PopulateCustomproperties()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub PrepareCustomProperty(ByRef cmbCombo As Telerik.WinControls.UI.RadDropDownList, ByRef pProp As CustomProperties.Item)

        Try
            cmbCombo.Enabled = True
            If pProp.LimitToLookup Then
                cmbCombo.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                cmbCombo.DropDownStyle = ComboBoxStyle.DropDown
            End If
            cmbCombo.AutoCompleteDataSource = AutoCompleteSource.ListItems
            cmbCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            For i As Integer = 0 To pProp.ValuesCount - 1
                cmbCombo.Items.Add(pProp.Value(i))
            Next
        Catch ex As Exception
            Throw New Exception("PrepareCustomProperty()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub txtCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged

        Try
            If Not mflgLoading Then
                PopulateCustomerList(txtCustomer.Text)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub SelectCustomer(ByVal pCustomer As Customers.CustomerItem)

        Try
            'TODO
            mobjReadPNR.NewElements.ClearCustomerElements()
            mobjAirlinePoints.Clear()
            mobjAirlineNotes.Clear()
            mobjCustomerSelected = pCustomer
            txtCustomer.Text = pCustomer.ToString
            mobjReadPNR.NewElements.SetItem(mobjCustomerSelected)

            txtSubdepartment.Clear()
            lstSubDepartments.Items.Clear()
            mobjSubDepartmentSelected = Nothing

            txtCRM.Clear()
            lstCRM.Items.Clear()
            mobjCRMSelected = Nothing

            txtVessel.Clear()
            lstVessels.Items.Clear()
            mobjVesselSelected = Nothing

            txtReference.Clear()

            cmbBookedby.Text = ""
            cmbDepartment.Text = ""

            If mobjCustomerSelected.HasVessels Then
                PopulateVesselsList()
            End If

            If mobjCustomerSelected.HasDepartments Then
                PopulateSubdepartmentsList("")
            End If

            PopulateCRMList("")
            PopulateCustomProperties()
            PrepareAirlinePoints()

            SetEnabled()

            If pCustomer.Alert <> "" Then

                MessageBox.Show(pCustomer.Alert, pCustomer.Code & " " & pCustomer.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        Catch ex As Exception
            Throw New Exception("SelectCustomer()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub txtSubdepartment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubdepartment.TextChanged

        Try
            If Not mflgLoading Then
                PopulateSubdepartmentsList(txtSubdepartment.Text)
            End If

            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtCRM_TextChanged(sender As Object, e As EventArgs) Handles txtCRM.TextChanged

        Try
            If Not mflgLoading Then
                PopulateCRMList(txtCRM.Text)
            End If

            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub SelectSubDepartment(ByVal pSubDepartment As SubDepartments.Item)

        Try
            mobjSubDepartmentSelected = pSubDepartment
            txtSubdepartment.Text = pSubDepartment.ToString
            mobjReadPNR.NewElements.SetItem(mobjSubDepartmentSelected)

            SetEnabled()
        Catch ex As Exception
            Throw New Exception("SelectSubDepartment()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub SelectCRM(ByVal pCRM As CRM.Item)

        Try
            mobjCRMSelected = pCRM
            txtCRM.Text = pCRM.ToString
            mobjReadPNR.NewElements.SetItem(mobjCRMSelected)

            SetEnabled()
            If pCRM.Alert <> "" Then
                MessageBox.Show(pCRM.Alert, pCRM.Code & " " & pCRM.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Throw New Exception("SelectCRM()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub SelectVessel(ByVal pVessel As Vessels.Item)

        Try
            mobjVesselSelected = pVessel
            txtVessel.Text = pVessel.ToString
            mobjReadPNR.NewElements.SetItem(mobjVesselSelected)
            PrepareAirlinePoints()
            SetEnabled()
        Catch ex As Exception
            Throw New Exception("SelectVessel()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub lstCustomers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCustomers.SelectedIndexChanged

        Try
            If lstCustomers.SelectedIndex >= 0 Then
                mflgLoading = True
                SelectCustomer(lstCustomers.SelectedItem)
                txtCustomer.Text = lstCustomers.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub

    Private Sub lstSubDepartments_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSubDepartments.SelectedIndexChanged

        Try
            If Not lstSubDepartments.SelectedItem Is Nothing Then
                mflgLoading = True
                SelectSubDepartment(lstSubDepartments.SelectedItem)
                txtSubdepartment.Text = lstSubDepartments.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub

    Private Sub lstCRM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCRM.SelectedIndexChanged

        Try
            If Not lstCRM.SelectedItem Is Nothing Then
                mflgLoading = True
                SelectCRM(lstCRM.SelectedItem)
                txtCRM.Text = lstCRM.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub

    Private Sub txtVessel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVessel.TextChanged

        Try
            If Not mflgLoading Then
                mobjReadPNR.NewElements.SetVesselForPNR("", "")
                mobjReadPNR.NewElements.VesselName.SetText(txtVessel.Text)
                PopulateVesselsList()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub lstVessels_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstVessels.SelectedIndexChanged
        Try
            If lstVessels.SelectedIndex >= 0 Then
                mflgLoading = True
                SelectVessel(lstVessels.SelectedItem)
                txtVessel.Text = lstVessels.SelectedItem.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub

    Private Sub cmdPNRWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPNRWrite.Click

        Try
            PNRWrite(True, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdPNRWriteWithDocs_Click(sender As Object, e As EventArgs) Handles cmdPNRWriteWithDocs.Click
        Try
            PNRWrite(True, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdPNROnlyDocs_Click(sender As Object, e As EventArgs) Handles cmdPNROnlyDocs.Click
        Try
            PNRWrite(False, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub PNRWrite(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean)

        Try
            UpdatePNR(WritePNR, WriteDocs)
            mflgReadPNR = False
            ClearForm()
            SetEnabled()
        Catch ex As Exception
            Throw New Exception("PNRWrite(" & WritePNR & ", " & WriteDocs & ")" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub UpdatePNR(ByVal WritePNR As Boolean, ByVal WriteDocs As Boolean)

        Try
            Dim pPNR As New ReadPNR

            pPNR.Read()

            If pPNR.PnrNumber = mobjReadPNR.PnrNumber And
                                pPNR.Itinerary = mobjReadPNR.Itinerary And
                                ((pPNR.IsGroup And mobjReadPNR.IsGroup) Or (pPNR.PaxName = mobjReadPNR.PaxName)) Then
                mobjReadPNR.SendNewGDSEntries(WritePNR, WriteDocs, mflgExpiryDateOK, dgvApis, txtAirlineEntries)
            Else
                Throw New Exception("PNR has been changed since read" & vbCrLf & "Please read again and re-enter data", New Exception("DifferentPNR"))
            End If
        Catch ex As Exception
            Throw New Exception("UpdatePNR()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub ShowOptionsForm()
        Try
            Dim pFrm As New frmShowOptions
            pFrm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub llbOptions_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbOptions.LinkClicked

        Try
            ShowOptionsForm()

            If Not CheckOptions() Then
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdOneTimeVessel_Click(sender As Object, e As EventArgs) Handles cmdOneTimeVessel.Click

        Try
            Dim pFrm As New frmVesselForPNR

            If pFrm.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                With mobjReadPNR.NewElements
                    .SetVesselForPNR(pFrm.VesselName, pFrm.Registration)
                    mflgLoading = True
                    txtVessel.Text = .VesselNameForPNR.TextRequested & If(.VesselFlagForPNR.TextRequested <> "", " REG " & .VesselFlagForPNR.TextRequested, "")
                End With
            End If
            pFrm.Dispose()
            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try
    End Sub

    Private Sub cmbBookedby_TextChanged(sender As Object, e As EventArgs) Handles cmbBookedby.TextChanged

        Try
            If Not mflgLoading Then
                mobjReadPNR.NewElements.SetBookedBy(cmbBookedby.Text)
            End If

            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmbReasonForTravel_TextChanged(sender As Object, e As EventArgs) Handles cmbReasonForTravel.TextChanged

        Try
            If Not mflgLoading Then
                mobjReadPNR.NewElements.SetReasonForTravel(cmbReasonForTravel.Text)
            End If

            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmbCostCentre_TextChanged(sender As Object, e As EventArgs) Handles cmbCostCentre.TextChanged

        Try
            If Not mflgLoading Then
                mobjReadPNR.NewElements.SetCostCentre(cmbCostCentre.Text)
            End If

            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtReference_TextChanged(sender As Object, e As EventArgs) Handles txtReference.TextChanged

        Try
            If Not mflgLoading Then
                mobjReadPNR.NewElements.SetReference(txtReference.Text)
            End If

            SetEnabled()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmbDepartment_TextChanged(sender As Object, e As EventArgs) Handles cmbDepartment.TextChanged

        Try
            If Not mflgLoading Then
                mobjReadPNR.NewElements.SetDepartment(cmbDepartment.Text)
            End If

            SetEnabled()
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdItn1AReadPNR_Click(sender As Object, e As EventArgs) Handles cmdItn1AReadPNR.Click

        Try
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            Dim mGDSUser As New GDSUser(Config.GDSCode.GDSisAmadeus)
            InitSettings(mGDSUser)
            SetupPCCOptions()
            lblItnPNRCounter.Text = ""
            ProcessRequestedPNRs(txtItnPNR)
            CopyItinToClipboard()
            cmdItnRefresh.Enabled = False
            cmdItnFormatOSMLoG.Enabled = True
            Cursor = Cursors.Default
            MessageBox.Show("Ready", "Read PNR", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdItnReadQueue_Click(sender As Object, e As EventArgs) Handles cmdItn1AReadQueue.Click

        Try
            lblItnPNRCounter.Text = ""
            If optItnFormatMSReport.IsChecked Then
                If ItnReadFromToDates() = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            txtItnPNR.Text = mobjPNR.RetrievePNRsFromQueue(txtItnPNR.Text)

            ProcessRequestedPNRs(txtItnPNR)
            CopyItinToClipboard()
            cmdItnRefresh.Enabled = False
            cmdItnFormatOSMLoG.Enabled = False
            Cursor = Cursors.Default
            MessageBox.Show("Ready", "Read PNR", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function ItnReadFromToDates() As DialogResult

        Try
            Dim pFrm As New frmItnMSReportDates

            ItnReadFromToDates = pFrm.ShowDialog()
            mItnFromDate = pFrm.FromDate
            mItnToDate = pFrm.ToDate
            pFrm.Close()
        Catch ex As Exception
            Throw New Exception(message:=$"ItnReadFromToDates(){vbCrLf}{ex.Message}")
        End Try

    End Function
    Private Sub ProcessRequestedPNRs(ByVal RefreshOnly As Boolean)

        Try

            If Not RefreshOnly Then
                ReDim mudtPaxNames(0)
                readGDS("")
            End If
            If optItnFormatEuronav.IsChecked Then
                webItnDoc.Width = rtbItnDoc.Width
                webItnDoc.Height = rtbItnDoc.Height
                webItnDoc.Left = rtbItnDoc.Left
                webItnDoc.Top = rtbItnDoc.Top
                webItnDoc.Visible = True
                webItnDoc.BringToFront()
                rtbItnDoc.Visible = False
                webItnDoc.DocumentText = makeWebHead() & makeWebDoc() & makeWebClose()
            Else
                webItnDoc.Visible = False
                rtbItnDoc.Visible = True
                rtbItnDoc.Clear()
                makeRTBDoc()
            End If
        Catch ex As Exception
            Throw New Exception("ProcessRequestedPNRs(RefreshOnly)" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub ProcessRequestedPNRs(ByVal txtPNR As Telerik.WinControls.UI.RadTextBox)

        Try
            Dim pPNR() As String = txtPNR.Text.Split(vbCrLf)
            Dim pPNRsOutsideRange As New System.Text.StringBuilder
            Dim pWebItn As String = ""

            pPNRsOutsideRange.Clear()

            ReDim mudtPaxNames(0)
            If optItnFormatEuronav.IsChecked Then
                webItnDoc.Width = rtbItnDoc.Width
                webItnDoc.Height = rtbItnDoc.Height
                webItnDoc.Left = rtbItnDoc.Left
                webItnDoc.Top = rtbItnDoc.Top
                webItnDoc.Visible = True
                rtbItnDoc.Visible = False
                pWebItn = makeWebHead()
            Else
                webItnDoc.Visible = False
                rtbItnDoc.Visible = True
                rtbItnDoc.Clear()
            End If
            For i As Integer = pPNR.GetLowerBound(0) To pPNR.GetUpperBound(0)
                lblItnPNRCounter.Text = i + 1 & " of " & pPNR.GetUpperBound(0) + 1
                If pPNR(i).Trim <> "" Then
                    readGDS(pPNR(i).Trim)
                    If Not optItnFormatMSReport.IsChecked Or (mobjPNR.LastSegment.DepartureDate >= mItnFromDate And mobjPNR.LastSegment.DepartureDate <= mItnToDate) Then
                        If optItnFormatEuronav.IsChecked Then
                            pWebItn &= makeWebDoc()
                        Else
                            makeRTBDoc()
                        End If
                    Else
                        Dim pItnRTBDoc As New ItnRTBDoc(mobjPNR, mintMaxString, lstItnRemarks)
                        pPNRsOutsideRange.Append(pItnRTBDoc.MakeRTBMSReportOutsiderange)
                    End If
                End If
            Next
            If optItnFormatEuronav.IsChecked Then
                pWebItn &= makeWebClose()
                webItnDoc.DocumentText = pWebItn
            Else
                If pPNRsOutsideRange.Length > 0 Then
                    rtbItnDoc.Text &= vbCrLf & "OUTSIDE DATE RANGE" & vbCrLf
                    rtbItnDoc.Text &= pPNRsOutsideRange.ToString
                End If
            End If
        Catch ex As Exception
            Throw New Exception("ProcessRequestedPNRs(txtPNR)" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub makeRTBDoc()

        Dim pItnRTBDoc As New ItnRTBDoc(mobjPNR, mintMaxString, lstItnRemarks)

        If optItnFormatMSReport.IsChecked Then
            If optItnFormatMSReport.IsChecked AndAlso rtbItnDoc.TextLength = 0 Then
                rtbItnDoc.Text &= pItnRTBDoc.RTBMSReportHeader(mItnFromDate.ToShortDateString, mItnToDate.ToShortDateString)
            End If
            rtbItnDoc.Text &= pItnRTBDoc.MakeRTBMSReport.ToString
        Else
            Dim pFont As Font = rtbItnDoc.SelectionFont
            Dim pStart As Integer = rtbItnDoc.Text.Length + 1
            rtbItnDoc.Text &= pItnRTBDoc.RTBDocPassengers
            Dim pEnd As Integer = rtbItnDoc.Text.Length
            rtbItnDoc.Select(pStart, pEnd)
            rtbItnDoc.SelectionFont = New Font(pFont, FontStyle.Bold)
            rtbItnDoc.Text &= pItnRTBDoc.makeRTBDoc
        End If

    End Sub
    Private Sub PaxNamesToBold()

        Try
            Dim pFont As Font = rtbItnDoc.SelectionFont

            For i As Integer = 1 To mudtPaxNames.GetUpperBound(0)
                rtbItnDoc.Select(mudtPaxNames(i).StartPos - 1, mudtPaxNames(i).EndPos - mudtPaxNames(i).StartPos + 1)
                rtbItnDoc.SelectionFont = New Font(pFont, FontStyle.Bold)
            Next
        Catch ex As Exception
            Throw New Exception("PaxNamesToBold()" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Function makeWebDoc() As String

        makeWebDoc = ""
        Try
            Return makeWebDocBody()
        Catch ex As Exception

        End Try

    End Function
    Private Function makeWebHead() As String

        makeWebHead = "<head>
                        <style>
                        td {
                            font-size:10.0pt;
                            font-family:arial;
                        }
                        </style>
                        </head><body>"

    End Function
    Private Function makeWebDocBody() As String

        Dim pString As New System.Text.StringBuilder

        Try

            With mobjPNR
                pString.Clear()
                pString.AppendLine("")
                pString.AppendLine("<div>")
                pString.AppendLine("<span style='font-size:12.0pt;font-family:arial'>")
                pString.AppendLine("Flight Routing Information<br />")
                pString.AppendLine("</span>")
                pString.AppendLine("<span style='font-size:10.0pt;font-family:arial'>")
                pString.AppendLine(MySettings.FormalOfficeName & "<br />")
                pString.AppendLine("Flight routing information<br />")
                If .ClientName.Trim <> "" Then
                    pString.AppendLine("For: " & .ClientName)
                End If
                pString.AppendLine("<br /><br />")
                pString.AppendLine("Date: " & Format(Now, "dd/MM/yyyy") & "<br /><br />")
                If mobjPNR.VesselName <> "" Then
                    pString.AppendLine("<b><u>VESSEL:</u></b><br />" & mobjPNR.VesselName & "<br /><br />")
                End If

                If mobjPNR.Passengers.Count > 0 Then
                    pString.AppendLine("<b><u>")
                    If mobjPNR.Passengers.Count = 1 Then
                        pString.AppendLine("PASSENGER<br />")
                    Else
                        pString.AppendLine("PASSENGERS<br />")
                    End If
                    pString.AppendLine("</u></b>")
                    Dim iPaxCount As Integer = 0
                    For Each pobjPax In mobjPNR.Passengers.Values
                        iPaxCount = iPaxCount + 1
                        pString.AppendLine(pobjPax.ElementNo & " " & pobjPax.PaxName & " " & pobjPax.PaxID & "<br />")
                    Next pobjPax
                ElseIf mobjPNR.IsGroup Then
                    pString.AppendLine("<b><u>")
                    pString.AppendLine("GROUP<br />")
                    pString.AppendLine("</u></b>")
                    pString.AppendLine(mobjPNR.GroupName & " " & mobjPNR.GroupNamesCount & "<br />")
                Else
                    pString.AppendLine("PASSENGER INFORMATION NOT AVAILABLE")
                End If
                pString.AppendLine("<span style='font-size:12.0pt;font-family:arial'>")
                pString.AppendLine("<br />FLIGHT ROUTING<br />")
                pString.AppendLine("</span>")
                'pString.AppendLine("<div align=left>")
                pString.AppendLine("<span style='font-size:10.0pt;font-family:arial'>")
                pString.AppendLine("<table cellspacing=" & Chr(34) & "1" & Chr(34) & " cellpadding=" & Chr(34) & "2" & Chr(34) & " border=" & Chr(34) & "1" & Chr(34) & " >")
                pString.AppendLine("<tr bgcolor=" & Chr(34) & "#0Fffff" & Chr(34) & ">")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Airline</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Flight</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Date</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Itinerary</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Depart</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Arrive</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Airline Locator</td>")
                pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>Baggage Allowance</td>")
                pString.AppendLine("</tr>")

                Dim iSegCount As Integer = 0
                Dim pPrevOff As String = ""
                For Each pobjSeg In .Segments.Values
                    iSegCount = iSegCount + 1
                    If iSegCount > 1 And pPrevOff <> pobjSeg.BoardPoint Then
                        pString.AppendLine("<tr>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")

                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>** CHANGE OF AIRPORT **</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("</tr>")
                    End If
                    pPrevOff = pobjSeg.OffPoint
                    pString.AppendLine("<tr>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & iSegCount & "</td>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.Airline & "-" & pobjSeg.AirlineName)
                    If pobjSeg.OperatedBy <> "" Then
                        pString.AppendLine("<br /><span style='font-size:6.0pt;font-family:arial'>" & pobjSeg.OperatedBy & "</span>")
                    End If
                    pString.AppendLine("</td>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.FlightNo & "</td>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & Format(pobjSeg.DepartureDate, "dd/MM/yyyy") & "<br><span style='font-size:6.0pt;font-family:arial'>" & pobjSeg.DepartureDay & "</span></td>")
                    pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & pobjSeg.BoardPoint & " " & pobjSeg.BoardCityName.PadRight(.MaxCityNameLength + 1, " ").Substring(0, .MaxCityNameLength + 1) & " - " &
                                            pobjSeg.OffPoint & " " & pobjSeg.OffPointCityName.PadRight(.MaxCityNameLength + 1, " ").Substring(0, .MaxCityNameLength + 1) & "</td>")
                    If pobjSeg.Text.Length > 35 AndAlso pobjSeg.Text.Substring(35, 4) = "FLWN" Then
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>FLOWN</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                    Else
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & Format(pobjSeg.DepartTime, "HH:mm") & "</td>")
                        Dim pDateDiff As Integer = DateDiff(DateInterval.Day, pobjSeg.DepartureDate, pobjSeg.ArrivalDate)
                        If pDateDiff = 0 Then
                            pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & Format(pobjSeg.ArriveTime, "HH:mm") & "</td>")
                        Else
                            pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>" & Format(pobjSeg.ArriveTime, "HH:mm") & " " & Format(pDateDiff, "+0;-0") & "</td>")
                        End If
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;" & pobjSeg.AirlineLocator & "</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;" & .AllowanceForSegment(pobjSeg.BoardPoint, pobjSeg.OffPoint, pobjSeg.Airline) & "</td>")

                    End If
                    pString.AppendLine("</tr>")
                    If pobjSeg.Stopovers <> "" Then
                        pString.AppendLine("<tr>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        If pobjSeg.Stopovers <> "" Then
                            pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>*INTERMEDIATE STOP*  " & pobjSeg.Stopovers.Trim & "</td>")
                        Else
                            pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        End If
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("<td style='font-size:10.0pt;font-family:arial'>&nbsp;</td>")
                        pString.AppendLine("</tr>")
                    End If

                Next pobjSeg

                pString.AppendLine("</table>")
                pString.AppendLine("</span>")
                'pString.AppendLine("</div>")
                pString.AppendLine("<br />")
                pString.AppendLine("<br />")
                pString.AppendLine("<div>")
                pString.AppendLine("<span style='font-size:10.0pt;font-family:arial'><b><u>Booking Reference</u></b><br />")
                pString.AppendLine(mSelectedItnGDSCode & "/" & .RequestedPNR & "<br /><br />")
                pString.AppendLine("<b><u>Tickets</u></b><br />")

                For Each pobjPax In .Passengers.Values
                    If .Passengers.Values.Count > 1 Then
                        pString.AppendLine("<u>" & pobjPax.PaxName & "</u><br />")
                    End If

                    For Each tkt As Ticket.TicketItem In .Tickets.Values
                        If tkt.Pax.Trim = pobjPax.PaxName.Trim Then
                            If tkt.TicketType = "PAX" Then
                                Dim pFF As String = mobjPNR.FrequentFlyerNumber(tkt.AirlineCode, tkt.Pax.Substring(0, tkt.Pax.Length - 2).Trim)
                                If pFF <> "" Then
                                    pFF = "Frequent Flyer Number: " & pFF
                                End If
                                pString.AppendLine(tkt.IssuingAirline & "-" & tkt.Document & " " & tkt.AirlineCode & " " & pFF & "<br />")
                            End If
                        End If
                    Next
                Next
                pString.AppendLine("<br />")

                pString.AppendLine("Kind Regards<br />")
                pString.AppendLine("</span>")
                pString.AppendLine("</div>")
                pString.AppendLine("</div>")

            End With
        Catch ex As Exception

        End Try

        Return pString.ToString

    End Function
    Private Function makeWebClose() As String

        makeWebClose = "</body></html>"

    End Function
    Private Sub cmdItnRead1ACurrent_Click(sender As Object, e As EventArgs) Handles cmdItn1AReadCurrent.Click
        Try
            mSelectedItnGDSCode = Config.GDSCode.GDSisAmadeus
            ItnReadCurrentPNR()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub cmdItnRead1GCurrent_Click(sender As Object, e As EventArgs) Handles cmdItn1GReadCurrent.Click
        Try
            mSelectedItnGDSCode = Config.GDSCode.GDSisGalileo
            ItnReadCurrentPNR()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub ItnReadCurrentPNR()
        Dim mGDSUser As New GDSUser(mSelectedItnGDSCode)
        InitSettings(mGDSUser)
        SetupPCCOptions()
        lblItnPNRCounter.Text = ""
        ReadPNRandCreateItn(False)
        cmdItnRefresh.Enabled = True
        cmdItnFormatOSMLoG.Enabled = True
    End Sub
    Private Sub cmdItnRefresh_Click(sender As Object, e As EventArgs) Handles cmdItnRefresh.Click

        Try
            ReadPNRandCreateItn(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub ReadPNRandCreateItn(ByVal RefreshOnly As Boolean)

        Try
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            ProcessRequestedPNRs(RefreshOnly)
            CopyItinToClipboard()
            If Not RefreshOnly Then
                MessageBox.Show("Ready", "Read PNR", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Throw New Exception("ReadPNRandCreateItn" & vbCrLf & ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub CopyItinToClipboard()

        Try
            If Not optItnFormatEuronav.IsChecked Then
                rtbItnDoc.SelectAll()
                Clipboard.Clear()
                Clipboard.SetText(rtbItnDoc.Rtf, TextDataFormat.Rtf)
                Clipboard.SetText(rtbItnDoc.SelectedText, TextDataFormat.Text)
            End If
        Catch ex As Exception
            ' ignore any error that occurs when copying to clipboard
        End Try

    End Sub
    Private Sub optAirportCode_CheckedChanged(sender As Object, e As EventArgs) Handles optItnAirportCode.CheckStateChanged

        Try
            MySettings.AirportName = 0
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub optAirportname_CheckStateChanged(sender As Object, e As EventArgs) Handles optItnAirportname.CheckStateChanged

        Try
            MySettings.AirportName = 1
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub optAirportBoth_CheckStateChanged(sender As Object, e As EventArgs) Handles optItnAirportBoth.CheckStateChanged

        Try
            MySettings.AirportName = 2
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub optAirportCityName_CheckStateChanged(sender As Object, e As EventArgs) Handles optItnAirportCityName.CheckStateChanged

        Try
            MySettings.AirportName = 3
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub optAirportCityBoth_CheckStateChanged(sender As Object, e As EventArgs) Handles optItnAirportCityBoth.CheckStateChanged

        Try
            MySettings.AirportName = 4
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkVessel_CheckStateChanged(sender As Object, e As EventArgs) Handles chkItnVessel.CheckStateChanged

        Try
            MySettings.Vessel = chkItnVessel.Checked
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkClass_CheckStateChanged(sender As Object, e As EventArgs) Handles chkItnClass.CheckStateChanged

        Try
            MySettings.ClassOfService = chkItnClass.Checked
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkAirlineLocator_CheckStateChanged(sender As Object, e As EventArgs) Handles chkItnAirlineLocator.CheckStateChanged

        Try
            MySettings.AirlineLocator = chkItnAirlineLocator.Checked
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkTickets_CheckStateChanged(sender As Object, e As EventArgs) Handles chkItnTickets.CheckStateChanged

        Try
            MySettings.Tickets = chkItnTickets.Checked
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkPaxSegPerTicket_CheckStateChanged(sender As Object, e As EventArgs) Handles chkItnPaxSegPerTicket.CheckStateChanged

        Try
            MySettings.PaxSegPerTkt = chkItnPaxSegPerTicket.Checked
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkSeating_CheckStateChanged(sender As Object, e As EventArgs) Handles chkItnSeating.CheckStateChanged

        Try
            MySettings.Seating = chkItnSeating.Checked
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkTerminal_CheckStateChanged(sender As Object, e As EventArgs) Handles chkItnTerminal.CheckStateChanged
        Try
            MySettings.ShowTerminal = chkItnTerminal.Checked
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkStopovers_CheckStateChanged(sender As Object, e As EventArgs) Handles chkItnStopovers.CheckStateChanged

        Try
            MySettings.ShowStopovers = chkItnStopovers.Checked
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkItnFlyingTime_CheckStateChanged(sender As Object, e As EventArgs) Handles chkItnFlyingTime.CheckStateChanged

        Try
            MySettings.FlyingTime = chkItnFlyingTime.Checked
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkItnCostCentre_CheckStateChanged(sender As Object, e As EventArgs) Handles chkItnCostCentre.CheckStateChanged

        Try
            MySettings.CostCentre = chkItnCostCentre.Checked
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub chkItnElecItemsBan_CheckStateChanged(sender As Object, e As EventArgs) Handles chkItnElecItemsBan.CheckStateChanged

        Try
            MySettings.BanElectricalEquipment = chkItnElecItemsBan.Checked
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkBrazilText_CheckStateChanged(sender As Object, e As EventArgs) Handles chkItnBrazilText.CheckStateChanged

        Try
            MySettings.BrazilText = chkItnBrazilText.Checked
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkUSAText_CheckStateChanged(sender As Object, e As EventArgs) Handles chkItnUSAText.CheckStateChanged

        Try
            MySettings.USAText = chkItnUSAText.Checked
            MySettings.Save()
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub txtPNR_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtItnPNR.TextChanged

        Try
            cmdItn1AReadPNR.Enabled = (txtItnPNR.Text.Trim.Length >= 6)
            cmdItn1AReadQueue.Enabled = (txtItnPNR.Text.Trim.Length >= 2)
            cmdItn1GReadPNR.Enabled = cmdItn1AReadPNR.Enabled
            cmdItn1GReadQueue.Enabled = cmdItn1AReadQueue.Enabled

            optItnFormatMSReport.Enabled = cmdItn1AReadQueue.Enabled
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub readGDS(ByVal RecordLocator As String)

        Try
            If RecordLocator = "" Then
                mobjPNR.CancelError = True
            Else
                mobjPNR.CancelError = False
            End If
            mobjPNR.ReadPNR(mSelectedItnGDSCode, RecordLocator, (optItnFormatMSReport.IsChecked))
        Catch ex As Exception
            Throw New Exception("readGDS()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub cmdCostCentre_Click(sender As Object, e As EventArgs) Handles cmdCostCentre.Click

        Try
            Dim pfrmcostCentre As New frmCostCentre
            Dim pResult As System.Windows.Forms.DialogResult
            mflgLoading = False
            pResult = pfrmcostCentre.ShowDialog()

            If pResult = Windows.Forms.DialogResult.OK Then
                txtCustomer.Text = pfrmcostCentre.CodeSelected
                txtVessel.Text = pfrmcostCentre.VesselSelected
                DisplayOldCustomProperty(cmbCostCentre, pfrmcostCentre.CostCentreSelected)
            End If
            pfrmcostCentre.Close()
        Catch ex As Exception
            MessageBox.Show("cmdCostCentre_Click()" & vbCrLf & ex.Message)
        End Try


    End Sub

    Private Sub cmdAveragePrice_Click(sender As Object, e As EventArgs) Handles cmdAveragePrice.Click

        Try
            With mobjAveragePrice
                If .Load() Then
                    lblAvPriceDetails.Text = "From: " & .FromDate & "  " & .Itinerary
                    lblAveragePrice.Text = .TicketCount & " tkts - Avge Price: " & Format(.AveragePrice, "#,##0 EUR")
                Else
                    lblAvPriceDetails.Text = "Cannot calculate round trip"
                    lblAveragePrice.Text = ""
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


#Region "OSM"

    Private Sub cmdOSMRefresh_Click(sender As Object, e As EventArgs) Handles cmdOSMRefresh.Click

        Try
            OSMRefreshVesselGroup(cmbOSMVesselGroup)
            OSMRefreshVessels(lstOSMVessels, chkOSMVesselInUse.Checked)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub cmbOSMVesselGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOSMVesselGroup.SelectedIndexChanged
        Try
            If Not mflgLoading Then
                Dim pSelectedItem As osmVessels.VesselGroupItem
                pSelectedItem = cmbOSMVesselGroup.SelectedItem
                MySettings.OSMVesselGroup = pSelectedItem.Id
                MySettings.Save()
                OSMRefreshVessels(lstOSMVessels, chkOSMVesselInUse.Checked)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdOSMCopyTo_Click(sender As Object, e As EventArgs) Handles cmdOSMCopyTo.Click

        Try
            Dim pstrEmail As String = ""

            For Each pSelectedAgent As osmVessels.emailItem In lstOSMAgents.SelectedItems
                If pstrEmail <> "" Then
                    pstrEmail &= "; "
                End If
                pstrEmail &= pSelectedAgent.ToString
            Next

            For Each pEmailTO As osmVessels.emailItem In lstOSMToEmail.Items
                If pstrEmail <> "" Then
                    pstrEmail &= "; "
                End If
                pstrEmail &= pEmailTO.ToString
            Next
            Clipboard.Clear()
            Clipboard.SetText(pstrEmail)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdOSMCopyCC_Click(sender As Object, e As EventArgs) Handles cmdOSMCopyCC.Click

        Try
            Dim pstrEmail As String = ""

            For Each pEmailTO As osmVessels.emailItem In lstOSMCCEmail.Items
                If pstrEmail <> "" Then
                    pstrEmail &= "; "
                End If
                pstrEmail &= pEmailTO.ToString
            Next
            Clipboard.Clear()
            Clipboard.SetText(pstrEmail)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdOSMCopyDocument_Click(sender As Object, e As EventArgs) Handles cmdOSMCopyDocument.Click

        Try
            Dim dobj As New DataObject
            dobj.SetData(DataFormats.Html, webOSMDoc.DocumentStream)
            Clipboard.Clear()
            Clipboard.SetDataObject(dobj)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdOSMCopyTextOnly_Click(sender As Object, e As EventArgs)

        Try
            Clipboard.Clear()
            Clipboard.SetText(webOSMDoc.DocumentText)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub lstOSMVessels_DrawItem(sender As Object, e As DrawItemEventArgs) ' Handles lstOSMVessels.DrawItem

        Try
            ListBox_DrawItem(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub lstOSMVessels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOSMVessels.SelectedIndexChanged

        Try
            If Not mflgLoading Then
                OSMShowSelectedVesselEmails()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub OSMShowSelectedVesselEmails()

        Try

            OSMDisplayEmails(lstOSMVessels, lstOSMToEmail, lstOSMCCEmail, lstOSMAgents)
            mOSMAgents.Load()
            mOSMAgentIndex = -1

            cmdOSMCopyTo.Enabled = (lstOSMToEmail.Items.Count > 0 Or lstOSMAgents.SelectedItems.Count > 0)
            cmdOSMCopyCC.Enabled = (lstOSMCCEmail.Items.Count > 0)

            lblOSMVessel.Text = ""
            txtOSMAgentsFilter.Clear()

            For Each pVessel As osmVessels.VesselItem In lstOSMVessels.SelectedItems
                If lblOSMVessel.Text <> "" Then
                    lblOSMVessel.Text &= " / "
                End If
                lblOSMVessel.Text &= pVessel.ToString
            Next
        Catch ex As Exception
            Throw New Exception("OSMShowSelectedVesselEmails()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub OSMWebCreate()

        Try
            webOSMDoc.DocumentText = OSMWebHeader()
            cmdOSMCopyDocument.Enabled = True
        Catch ex As Exception
            Throw New Exception("OSMWebCreate()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Function OSMWebHeader() As String

        Try
            Dim xDoctext As String = "<html><head></head><body>"

            xDoctext &= "MESSAGE FROM :<br>"

            xDoctext &= "<b>ATPI GRIFFINSTONE GREECE</b><br><br>"

            For Each pSelectedAgent As osmVessels.emailItem In lstOSMAgents.SelectedItems
                xDoctext &= "TO         : " & pSelectedAgent.Name & " / " & pSelectedAgent.Details & "<br>"
            Next

            For Each pEmail As osmVessels.emailItem In lstOSMToEmail.Items
                If lstOSMVessels.SelectedItems.Count > 1 Then
                    xDoctext &= "TO         : " & pEmail.Name & If(pEmail.Details <> "", " / " & pEmail.Details, "") & If(pEmail.VesselName <> "", "(" & pEmail.VesselName & ")", "") & "<br>"
                Else
                    xDoctext &= "TO         : " & pEmail.Name & If(pEmail.Details <> "", " / " & pEmail.Details, "") & "<br>"
                End If
            Next

            xDoctext &= "<br>"
            xDoctext &= "CC         : OSM CYPRUS<br>"
            For Each pEmail As osmVessels.emailItem In lstOSMCCEmail.Items
                xDoctext &= "CC         : " & pEmail.Name & If(pEmail.Details <> "", " / " & pEmail.Details, "") & "<br>"
            Next
            xDoctext &= "CC         : 3rd party applicable<br>"
            xDoctext &= "<br>"
            xDoctext &= "DATE/REF   : " & Format(Now, "dd/MM/yyyy") & "<br><br><br>"
            Dim pTempSubject As String = ""

            For Each pVessel As osmVessels.VesselItem In lstOSMVessels.SelectedItems
                If pTempSubject <> "" Then
                    pTempSubject &= " / "
                End If
                pTempSubject &= pVessel.VesselName
            Next
            xDoctext &= "SUBJECT     : VSL " & pTempSubject & " CREW CHANGE AT PORT  <br>"

            xDoctext &= "<br><br>"
            xDoctext &= "PLEASE BE ADVISED OF THE FOLLOWING ARRANGEMENTS FOR EMBARKING / DISEMBARKING CREW.<br><br><br>"
            xDoctext &= "<font color=" & Chr(34) & "red" & Chr(34) & ">PLEASE CONFIRM RECEIPT OF BELOW :</font><br><br><br>"


            'Dim pJoinerText As String = ""

            Dim pOnSigners As String = ""
            Dim pOnSignerNoVisa As String = ""
            Dim pOnSignerVisa As String = ""
            Dim pOnSignerOKTB As String = ""

            Dim pOffSigners As String = ""

            Dim pOther As String = ""

            For i As Integer = 0 To dgvOSMPax.Rows.Count - 1
                Dim pId = dgvOSMPax.Rows(i).Cells(0).Value
                Dim pPax As osmPax.Pax = mOSMPax(pId)
                Select Case dgvOSMPax.Rows(i).Cells("JoinerLeaver").Value
                    Case "ONSIGNER"
                        pOnSigners &= "<pre>" & pPax.Text & "</pre><br><br>"
                    Case "OFFSIGNER"
                        pOffSigners &= "<pre>" & pPax.Text & "</pre><br><br>"
                    Case Else
                        pOther &= "<pre>" & pPax.Text & "</pre><br><br>"
                End Select
                'pJoinerText = dgvOSMPax.Rows(i).Cells("JoinerLeaver").Value
                Select Case dgvOSMPax.Rows(i).Cells("VisaType").Value
                    Case "OKTB"
                        pOnSignerOKTB &= dgvOSMPax.Rows(i).Cells("Lastname").Value & "/" & dgvOSMPax.Rows(i).Cells("Firstname").Value & "<br>"
                    Case "NO VISA"
                        pOnSignerNoVisa &= dgvOSMPax.Rows(i).Cells("Lastname").Value & "/" & dgvOSMPax.Rows(i).Cells("Firstname").Value & "<br>"
                    Case "VISA"
                        pOnSignerVisa &= dgvOSMPax.Rows(i).Cells("Lastname").Value & "/" & dgvOSMPax.Rows(i).Cells("Firstname").Value & "<br>"
                End Select
            Next

            If pOther <> "" Then
                xDoctext &= "PARTICULARS OF TRAVELLER AS FOLLOWS:</b><br><br>"
                xDoctext &= "<pre>" & pOther
                xDoctext &= "<font color=" & Chr(34) & "red" & Chr(34) & ">FLIGHT DETAILS: </font></pre><br><br>"
            End If
            If pOnSigners <> "" Then
                xDoctext &= "PARTICULARS OF JOINERS AS FOLLOWS:</b><br><br>"
                xDoctext &= "SIGNING ON<br><br>"
                xDoctext &= "<pre>" & pOnSigners
                xDoctext &= "<font color=" & Chr(34) & "red" & Chr(34) & "><b>FLIGHT DETAILS: </b></font><br><br>"
                If pOnSignerNoVisa <> "" Then
                    xDoctext &= "<hr width=30% align=left>" & pOnSignerNoVisa & "<br><br>"
                    xDoctext &= "<pre><b>NO VISA REQUIRED</b></pre><br><br>"
                End If
                If pOnSignerVisa <> "" Then
                    xDoctext &= "<hr width=30% align=left>" & pOnSignerVisa & "<br><br>"
                    xDoctext &= "<pre><b>VISA REQUIRED</b></pre><br><br>"
                    xDoctext &= "<b>CREW WILL TRAVEL WITH VALID VISA. <br><br>"
                    xDoctext &= "AGENT PLEASE ENSURE THAT ONSIGNER'S PASSPORT HAVE AN EXIT STAMP <br>"
                    xDoctext &= "FROM THE IMMIGRATION BEFORE THEY GO ON BOARD. </b><br><br>"
                End If
                If pOnSignerOKTB <> "" Then
                    xDoctext &= "<hr width=30% align=left>" & pOnSignerOKTB & "<br>"
                    xDoctext &= "<pre><b>OKTB</b></pre><br><br>"
                    xDoctext &= "<b>*****IMPORTANT******<br><br>"
                    xDoctext &= "PLS SEND -OK TO BOARD- TO ____ THROUGH NEAREST TOWNOFFICE/AIRPORT<br>"
                    xDoctext &= "OFFICE YOUR SIDE .<br><br>"
                    xDoctext &= "THE LETTER SHOULD CONTAIN THE FOLLOWING WORDINGS OK TO BOARD THAT<br>"
                    xDoctext &= "AIRLINE COUNTER IS REQUIRING FROM THE AGENT.<br><br>"
                    xDoctext &= "WE NEED YOUR FORMAL ACKNOWLEDGEMENT THAT YOU HAVE GIVEN THE -OK TO BOARD<br>"
                    xDoctext &= "PLS ALSO SEND COPY OF OK TO BOARD TO :<br><br>"
                    xDoctext &= "ATPI ATHENS  = E-MAIL : osmsmart.greece@ atpi.com<br>"
                    xDoctext &= "OSM ________ = E-MAIL : _________@_______<br><br>"
                    xDoctext &= "AGENT PLEASE ENSURE THAT ONSIGNER'S PASSPORT HAVE AN EXIT STAMP <br>"
                    xDoctext &= "FROM THE IMMIGRATION BEFORE THEY GO ON BOARD. </b><br><br>"
                End If
                xDoctext &= " "
                xDoctext &= "<br>AGENT PLS CHECK IF THIS ARRANGEMENT IS ACCEPTABLE WITH ETA/ETD<br><br>"
                xDoctext &= "PLS LIASE WITH MASTER, MEET CREW, ARRANGE ENTRY FORMALITIES AND SECURE <br>"
                xDoctext &= "SAFE JOINSHIP.</pre><br>"
            End If
            If pOffSigners <> "" Then
                xDoctext &= "<hr SIZE=2 COLOR=gray>"
                xDoctext &= "<b>TO MASTER/PORT AGENT</b><br><br>"
                xDoctext &= "FOLLOWING ROUTE ARE CONFIRMED FOR HOMEGOING CREW AS FLWS :<br><br>"
                xDoctext &= "OFFSIGNER:<br><br>"
                xDoctext &= "<pre>" & pOffSigners & "</pre><br>"
                xDoctext &= "<pre><font color=" & Chr(34) & "red" & Chr(34) & "><b>FLIGHT DETAILS: </b></font></pre><br><br>"
                xDoctext &= "<pre><b>AGENT – CREW TRAVELING ON E-TICKETS, AND MUST GO DIRECTLY TO CHECK-IN<br>"
                xDoctext &= "COUNTER AT AIRPORT WITH PASSPORT READY.</b></pre><br><br>"
                xDoctext &= "<br><pre>PLS LIASE WITH MASTER AND CONVEY CREW TO AIRPORT.</pre><br>"

            End If
            xDoctext &= "<br><pre>IF ANY PROBLEM REGARDING FLIGHT DETAILS, PLS CONTACT OUR OFFICE.</pre><br><br>"

            xDoctext &= "</body></html>"

            Return xDoctext
        Catch ex As Exception
            Throw New Exception("OSMWebHeader()" & vbCrLf & ex.Message)
        End Try
    End Function
    Private Sub txtOSMPax_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOSMPax.KeyDown

        Try
            If e.Control And e.KeyCode = Keys.A Then
                txtOSMPax.SelectAll()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub txtOSMText_TextChanged(sender As Object, e As EventArgs) Handles txtOSMPax.TextChanged
        Try
            OSMAnalyzePax()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub OSMAnalyzePax()
        Try
            mOSMPax.Load(txtOSMPax.Text)
            dgvOSMPax.Rows.Clear()
            For Each iPax As osmPax.Pax In mOSMPax.Values
                Dim pId As New DataGridViewTextBoxCell
                Dim pLastName As New DataGridViewTextBoxCell
                Dim pFirstName As New DataGridViewTextBoxCell
                Dim pNationality As New DataGridViewTextBoxCell
                Dim pJoiner As New DataGridViewComboBoxCell
                Dim pVisaType As New DataGridViewComboBoxCell
                pId.Value = iPax.Id
                pLastName.Value = iPax.LastName
                pFirstName.Value = iPax.FirstName
                pNationality.Value = iPax.Nationality
                pJoiner.Items.AddRange({"ONSIGNER", "OFFSIGNER"})
                pVisaType.Items.AddRange({"OKTB", "VISA", "NO VISA"})
                If iPax.JoinerLeaver <> "" Then
                    pJoiner.Value = iPax.JoinerLeaver
                End If
                Dim pRow As New DataGridViewRow
                pRow.Cells.Add(pId)
                pRow.Cells.Add(pLastName)
                pRow.Cells.Add(pFirstName)
                pRow.Cells.Add(pNationality)
                pRow.Cells.Add(pJoiner)
                pRow.Cells.Add(pVisaType)
                dgvOSMPax.Rows.Add(pRow)
            Next
            dgvOSMPax.Columns(1).ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdOSMPrepareDoc_Click(sender As Object, e As EventArgs) Handles cmdOSMPrepareDoc.Click
        Try
            OSMWebCreate()
            cmdOSMCopyDocument.Enabled = True

        Catch ex As Exception
            MessageBox.Show("cmdOSMPrepareDoc_Click()" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub cmdOSMVesselsEdit_Click(sender As Object, e As EventArgs) Handles cmdOSMVesselsEdit.Click
        Try
            Dim pFrm As New frmOSMVessels
            pFrm.ShowDialog(Me)
            OSMRefreshVessels(lstOSMVessels, chkOSMVesselInUse.Checked)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdOSMAgentEdit_Click(sender As Object, e As EventArgs) Handles cmdOSMAgentEdit.Click
        Try
            Dim pFrm As New frmOSMAgents
            If pFrm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                OSMRefreshVessels(lstOSMVessels, chkOSMVesselInUse.Checked)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub dgvOSMPax_CellValueChanged(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvOSMPax.CellValueChanged
        Dim pflgLoading As Boolean = mflgLoading
        Try
            If Not mflgLoading Then
                mflgLoading = True
                If e.ColumnIndex = 5 Then
                    For i As Integer = 0 To dgvOSMPax.Rows.Count - 1
                        If i <> e.RowIndex AndAlso dgvOSMPax.Rows(i).Cells("JoinerLeaver").Value = "ONSIGNER" AndAlso dgvOSMPax.Rows(i).Cells("VisaType").Value Is Nothing Then
                            dgvOSMPax.Rows(i).Cells("VisaType").Value = dgvOSMPax.Rows(e.RowIndex).Cells("VisaType").Value
                        End If
                    Next
                End If
            End If
        Catch ex As Exception

        Finally
            mflgLoading = pflgLoading
        End Try
    End Sub

    Private Sub cmdOSMEmailClear_Click(sender As Object, e As EventArgs) Handles cmdOSMEmailClear.Click

        Try
            txtOSMPax.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub tabPNR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabPNR.SelectedPageChanged
        Try
            mflgLoading = True
            If tabPNR.SelectedPage.TabIndex = 1 Then
                cmdItnFormatOSMLoG.Enabled = False
            ElseIf tabPNR.SelectedPage.TabIndex = 2 Then
                OSMRefreshVesselGroup(cmbOSMVesselGroup)
                OSMRefreshVessels(lstOSMVessels, chkOSMVesselInUse.Checked)
                cmdOSMCopyDocument.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mflgLoading = False
        End Try

    End Sub
    Private Sub SetITNEnabled(ByVal AllowOptions As Boolean)

        fraItnAirportName.Enabled = AllowOptions
        fraItnOptions.Enabled = AllowOptions
        lstItnRemarks.Enabled = AllowOptions

    End Sub
    Private Sub optItnFormatDefault_CheckedChanged(sender As Object, e As EventArgs) Handles optItnFormatDefault.CheckStateChanged, optItnFormatPlain.CheckStateChanged, optItnFormatSeaChefs.CheckStateChanged, optItnFormatSeaChefsWith3LetterCode.CheckStateChanged, optItnFormatMSReport.CheckStateChanged, optItnFormatEuronav.CheckStateChanged
        Try
            If Not mflgLoading Then
                If Not MySettings Is Nothing Then
                    ' optItnFormatDefault = 0
                    ' optItnFormatPlain = 1
                    ' optItnFormatSeaChefs = 2
                    ' chkItnSeaChefsWithCode = 3
                    ' optItnFormatEuronav = 4
                    If optItnFormatDefault.IsChecked Then
                        MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatDefault
                    ElseIf optItnFormatPlain.IsChecked Then
                        MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatPlain
                    ElseIf optItnFormatSeaChefs.IsChecked Then
                        MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatSeaChefs
                    ElseIf optItnFormatSeaChefsWith3LetterCode.IsChecked Then
                        MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode
                    ElseIf optItnFormatEuronav.IsChecked Then
                        MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatEuronav
                    End If
                    MySettings.Save()

                    If cmdItnRefresh.Enabled Then
                        ReadPNRandCreateItn(True)
                    End If
                    If sender.Name = "optItnFormatDefault" Or sender.name = "optItnFormatPlain" Then
                        SetITNEnabled(True)
                    Else
                        SetITNEnabled(False)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmdItnFormatOSMLoG_Click(sender As Object, e As EventArgs) Handles cmdItnFormatOSMLoG.Click
        Try
            Dim pOSMLoG = New OsmLOG
            pOSMLoG.CreatePDF(mobjPNR)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub lstItnRemarks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstItnRemarks.SelectedIndexChanged
        Try
            If cmdItnRefresh.Enabled Then
                ReadPNRandCreateItn(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdOSMClearSelected_Click(sender As Object, e As EventArgs) Handles cmdOSMClearSelected.Click

        Try
            mflgLoading = True
            For i As Integer = 0 To lstOSMVessels.Items.Count - 1
                lstOSMVessels.SetSelected(i, False)
            Next
            For i As Integer = 0 To lstOSMAgents.Items.Count - 1
                lstOSMAgents.SetSelected(i, False)
            Next
            mflgLoading = False
            OSMShowSelectedVesselEmails()
        Catch ex As Exception
            mflgLoading = False
            MessageBox.Show("cmdOSMClearSelected_Click()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub lstOSMAgents_MouseMove(sender As Object, e As MouseEventArgs) Handles lstOSMAgents.MouseMove

        Try
            Dim pIndex As Integer = lstOSMAgents.IndexFromPoint(e.Location)

            If pIndex >= 0 And pIndex < lstOSMAgents.Items.Count And mOSMAgentIndex <> pIndex Then
                ttpToolTip.SetToolTip(lstOSMAgents, lstOSMAgents.Items(pIndex).ToString)
                mOSMAgentIndex = pIndex
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub lstOSMAgents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOSMAgents.SelectedIndexChanged

        Try
            cmdOSMCopyTo.Enabled = (lstOSMToEmail.Items.Count > 0 Or lstOSMAgents.SelectedItems.Count > 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtOSMAgentsFilter_TextChanged(sender As Object, e As EventArgs) Handles txtOSMAgentsFilter.TextChanged

        Try
            lstOSMAgents.Items.Clear()
            mOSMAgentIndex = -1

            If txtOSMAgentsFilter.Text.Trim = "" Then
                For Each pAgent As osmVessels.emailItem In mOSMAgents.Values
                    lstOSMAgents.Items.Add(pAgent)
                Next
            Else
                Dim pFilter() As String = txtOSMAgentsFilter.Text.ToUpper.Trim.Split({"|"}, StringSplitOptions.RemoveEmptyEntries)

                For Each pAgent As osmVessels.emailItem In mOSMAgents.Values
                    For i As Integer = 0 To pFilter.GetUpperBound(0)
                        If pAgent.ToString.ToUpper.IndexOf(pFilter(i).Trim) >= 0 Then
                            lstOSMAgents.Items.Add(pAgent)
                            Exit For
                        End If
                    Next
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub chkOSMVesselInUse_CheckedChanged(sender As Object, e As EventArgs) Handles chkOSMVesselInUse.CheckStateChanged
        Try
            If Not mflgLoading And chkOSMVesselInUse.Visible Then
                OSMRefreshVessels(lstOSMVessels, chkOSMVesselInUse.Checked)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
    'DataGridViewRow
    Public Sub APISValidateDataRow(ByVal Row As Telerik.WinControls.UI.GridViewRowInfo)
        Dim pdteDate As DateTime
        Dim pflgGenderFound As Boolean = False
        Dim pflgBirthDateOK As Boolean = False
        Dim pflgPassportNumberOK As Boolean = False
        Dim pstrErrorText As String = ""
        pflgPassportNumberOK = (Trim(Row.Cells("PassportNumber").Value).Length > 0)
        If Not Date.TryParse(Row.Cells("Birthdate").Value, pdteDate) Then
            pdteDate = APISDateFromIATA(Row.Cells("Birthdate").Value)
            If pdteDate > Date.MinValue Then
                pflgBirthDateOK = True
            Else
                pflgBirthDateOK = False
            End If
        Else
            pflgBirthDateOK = True
        End If
        If Not Date.TryParse(Row.Cells("ExpiryDate").Value, pdteDate) Then
            pdteDate = APISDateFromIATA(Row.Cells("ExpiryDate").Value)
        End If
        If pdteDate > Now Then
            mflgExpiryDateOK = True
        Else
            mflgExpiryDateOK = False
        End If
        pflgGenderFound = False
        For i As Integer = 0 To mstrGenderIndicator.GetUpperBound(0)
            If Row.Cells("Gender").Value = mstrGenderIndicator(i) Then
                pflgGenderFound = True
                Exit For
            End If
        Next
        mflgAPISUpdate = mflgAPISUpdate Or (Not mobjReadPNR.SSRDocsExists And mobjReadPNR.SegmentsExist And pflgBirthDateOK) ' And pflgGenderFound And pflgPassportNumberOK)
        If Not pflgBirthDateOK Then
            pstrErrorText &= "Invalid birth date" & vbCrLf
        End If
        If Not pflgGenderFound Then
            pstrErrorText &= "Invalid gender" & vbCrLf
        End If
        If Not pflgPassportNumberOK Then
            pstrErrorText &= "Passport number missing" & vbCrLf
        End If
        If Not mflgExpiryDateOK Then
            pstrErrorText &= "Invalid expiry date" & vbCrLf
        End If
        If mobjReadPNR.SSRDocsExists Then
            lblSSRDocs.Text = "SSR DOCS already exist in the PNR"
            lblSSRDocs.BackColor = Color.Red
        Else
            If mobjReadPNR.SegmentsExist Then
                lblSSRDocs.Text = "SSR DOCS"
                lblSSRDocs.BackColor = Color.Yellow
            Else
                lblSSRDocs.Text = "SSR DOCS cannot be updated - No segments in PNR"
                lblSSRDocs.BackColor = Color.Red
            End If
        End If
        Row.ErrorText = pstrErrorText
        SetEnabled()

    End Sub

    Private Sub dgvApis_CellValueChanged(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvApis.CellValueChanged

        Try
            dgvApis.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = dgvApis.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString.ToUpper
            APISValidateDataRow(dgvApis.Rows(e.RowIndex))
        Catch ex As Exception

        End Try


    End Sub

    Private Sub dgvApis_RowValidating(sender As Object, e As Telerik.WinControls.UI.RowValidatingEventArgs) Handles dgvApis.RowValidating

        APISValidateDataRow(dgvApis.Rows(e.RowIndex))

    End Sub

    Public Sub APISDisplayPax()
        Dim pobjPax As s1aPNR.NameElement
        Dim pobjPaxApis As New PaxApisDB.Collection
        Dim pobjPaxItem As PaxApisDB.Item
        dgvApis.Rows.Clear()
        For Each pobjPax In mobjReadPNR.PNR.NameElements
            pobjPaxItem = pobjPaxApis.Read(pobjPax.LastName, APISModifyFirstName(pobjPax.Initial))
            If pobjPaxApis.Count = 0 Then
                dgvApis.Rows.Add(pobjPax.ElementNo, pobjPax.LastName, APISModifyFirstName(pobjPax.Initial), "", "", "", 0, "M", 0)
            Else
                dgvApis.Rows.Add(pobjPax.ElementNo, pobjPax.LastName, APISModifyFirstName(pobjPax.Initial), pobjPaxItem.IssuingCountry, pobjPaxItem.PassportNumber, pobjPaxItem.Nationality, APISDateToIATA(pobjPaxItem.BirthDate), pobjPaxItem.Gender, If(pobjPaxItem.ExpiryDate > Date.MinValue, APISDateToIATA(pobjPaxItem.ExpiryDate), 0))
            End If
            APISValidateDataRow(dgvApis.Rows(dgvApis.RowCount - 1))
        Next
    End Sub
    Private Function APISModifyFirstName(ByVal FirstName As String) As String
        Dim pintFindPos As Integer
        FirstName = Trim(FirstName)
        For i As Short = 0 To mstrSalutations.GetUpperBound(0)
            pintFindPos = FirstName.IndexOf(mstrSalutations(i))
            If pintFindPos > 0 And pintFindPos = FirstName.Length - mstrSalutations(i).Length Then
                FirstName = FirstName.Substring(0, pintFindPos).Trim
            End If
        Next
        Return FirstName
    End Function

    Private Sub APISPrepareGrid()

        dgvApis.AutoGenerateColumns = False

        dgvApis.MasterTemplate.Columns.Clear()
        Dim pColId As New GridViewTextBoxColumn With {
            .Name = "Id",
            .HeaderText = "Id",
            .FieldName = "Id"
        }
        dgvApis.MasterTemplate.Columns.Add(pColId)
        Dim pColSurname As New GridViewTextBoxColumn With {
            .Name = "Surname",
            .HeaderText = "Surname",
            .FieldName = "Surname"
        }
        dgvApis.MasterTemplate.Columns.Add(pColSurname)
        Dim pColFirst As New GridViewTextBoxColumn With {
            .Name = "FirstName",
            .HeaderText = "First Name",
            .FieldName = "FirstName"
        }
        dgvApis.MasterTemplate.Columns.Add(pColFirst)
        Dim pColIssCountry As New GridViewTextBoxColumn With {
            .Name = "IssuingCountry",
            .HeaderText = "Issuing Country",
            .FieldName = "IssuingCountry"
        }
        dgvApis.MasterTemplate.Columns.Add(pColIssCountry)
        Dim pColPassportNum As New GridViewTextBoxColumn With {
            .Name = "Passportnumber",
            .HeaderText = "Passport number",
            .FieldName = "Passportnumber"
        }
        dgvApis.MasterTemplate.Columns.Add(pColPassportNum)
        Dim pColnationality As New GridViewTextBoxColumn With {
            .Name = "Nationality",
            .HeaderText = "Nationality",
            .FieldName = "Nationality"
        }
        dgvApis.MasterTemplate.Columns.Add(pColnationality)
        Dim pColBirthdate As New GridViewDateTimeColumn With {
            .Name = "BirthDate",
            .HeaderText = "BirthDate",
            .FieldName = "BirthDate",
            .Format = DateTimePickerFormat.Custom,
            .CustomFormat = "dd/MM/yyyy"
        }
        dgvApis.MasterTemplate.Columns.Add(pColBirthdate)
        Dim pColGender As New GridViewTextBoxColumn With {
            .Name = "Gender",
            .HeaderText = "Gender",
            .FieldName = "Gender"
        }
        dgvApis.MasterTemplate.Columns.Add(pColGender)
        Dim pColExpiry As New GridViewDateTimeColumn With {
            .Name = "ExpiryDate",
            .HeaderText = "Expiry Date",
            .FieldName = "ExpiryDate",
           .Format = DateTimePickerFormat.Custom,
            .CustomFormat = "dd/MM/yyyy"
        }
        dgvApis.MasterTemplate.Columns.Add(pColExpiry)

    End Sub
    Private Sub MenuCopyItn_Click(sender As Object, e As EventArgs) Handles MenuCopyItn.Click
        Try
            rtbItnDoc.SelectAll()
            Clipboard.Clear()
            Clipboard.SetText(rtbItnDoc.Rtf, TextDataFormat.Rtf)
            Clipboard.SetText(rtbItnDoc.SelectedText, TextDataFormat.Text)
        Catch ex As Exception
            ' ignore any error that occurs when copying to clipboard
        End Try
    End Sub

    Private Sub cmdAdmin_Click(sender As Object, e As EventArgs) Handles cmdAdmin.Click
        Try
            Dim pfrmAdmin As New frmAdmin
            pfrmAdmin.ShowDialog(Me)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub webItnDoc_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles webItnDoc.DocumentCompleted
        Try
            If optItnFormatEuronav.IsChecked Then
                Dim dobj As New DataObject
                dobj.SetData(DataFormats.Text, webItnDoc.Document.Body.InnerText)
                dobj.SetData(DataFormats.Html, webItnDoc.DocumentStream)
                Clipboard.Clear()
                Clipboard.SetDataObject(dobj, True)
            End If
        Catch ex As Exception
            ' ignore any error that occurs when copying to clipboard
        End Try
    End Sub
    Private Sub tabPNR_PageRemoving(sender As Object, e As RadPageViewCancelEventArgs) Handles tabPNR.PageRemoving
        e.Cancel = True
    End Sub
End Class