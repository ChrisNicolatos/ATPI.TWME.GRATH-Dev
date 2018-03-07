Public Class frmPNRItinerary

    Private Structure PaxNamesPos
        Dim StartPos As Integer
        Dim EndPos As Integer
    End Structure
    Private WithEvents mobjAmadeus As New gtmAmadeusPNR
    Private WithEvents mobjHostSession As k1aHostToolKit.HostSession
    Private mMaxString As Integer = 80
    Private mstrResponse As String = ""
    Private pPaxNames() As PaxNamesPos

    Private Sub cmdExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdExit.Click

        Me.Close()

    End Sub

    Private Sub cmdReadPNR_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdItnReadPNR.Click

        Try
            Cursor = System.Windows.Forms.Cursors.WaitCursor

            ProcessRequestedPNRs(txtPNR)

            rtbDoc.SelectAll()
            Clipboard.SetText(rtbDoc.Rtf, TextDataFormat.Rtf)


            Cursor = Cursors.Default
            MessageBox.Show("Ready", "Read PNR", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(Err.Description)
        End Try


    End Sub

    Private Sub ProcessRequestedPNRs(ByVal txtPNR As TextBox)

        Dim pPNR() As String = txtPNR.Text.Split(vbCrLf)

        rtbDoc.Clear()
        ReDim pPaxNames(0)

        For i As Integer = pPNR.GetLowerBound(0) To pPNR.GetUpperBound(0)
            If pPNR(i).Trim <> "" Then
                readAmadeus(pPNR(i).Trim)
                makeRTBDoc()
            End If
        Next
        PaxNamesToBold()

    End Sub

    Private Sub ProcessRequestedPNRs()

        rtbDoc.Clear()
        ReDim pPaxNames(0)

        readAmadeus("")
        makeRTBDoc()
        PaxNamesToBold()

    End Sub

    Private Sub readAmadeus(ByVal RecordLocator As String)

        Try
            If RecordLocator = "" Then
                mobjAmadeus.CancelError = True
            Else
                mobjAmadeus.CancelError = False
            End If
            mobjAmadeus.ReadPNR(RecordLocator)
        Catch ex As Exception
            Throw New Exception("readAmadeus()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub makeRTBDoc()

        Dim pString As New System.Text.StringBuilder

        pString.Clear()
        mMaxString = 80

        Try
            pString.Append(MakeRTBDocPart1)
            pString.Append(MakeRTBDocRemarks)
            pString.Append(MakeRTBDocTickets)
            If mMaxString > 0 Then
                pString.AppendLine(StrDup(mMaxString, "-"))
            End If
            pString.AppendLine()
            pString.Append(MakeRTBDocCloseOff)

            rtbDoc.Text &= pString.ToString

        Catch ex As Exception
            Throw New Exception("makeRTBDoc()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub makeRTBDoc(ByVal RemIndex As Integer, ByVal Checked As Boolean)

        Dim pString As New System.Text.StringBuilder

        pString.Clear()
        mMaxString = 80

        Try
            pString.Append(MakeRTBDocPart1)
            pString.Append(MakeRTBDocRemarks(RemIndex, Checked))
            pString.Append(MakeRTBDocTickets)
            If mMaxString > 0 Then
                pString.AppendLine(StrDup(mMaxString, "-"))
            End If
            pString.AppendLine()
            pString.Append(MakeRTBDocCloseOff)

            rtbDoc.Text &= pString.ToString

        Catch ex As Exception
            Throw New Exception("makeRTBDoc()" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub PaxNamesToBold()

        Dim pFont As Font = rtbDoc.SelectionFont

        For i As Integer = 1 To pPaxNames.GetUpperBound(0)
            rtbDoc.Select(pPaxNames(i).StartPos - 1, pPaxNames(i).EndPos - pPaxNames(i).StartPos + 1)
            rtbDoc.SelectionFont = New Font(pFont, FontStyle.Bold)
        Next

    End Sub

    Private Function MakeRTBDocPart1() As String

        Dim pString As New System.Text.StringBuilder

        Dim i As Short
        Dim pobjSeg As gtmAmadeusSeg
        Dim pobjPax As gtmAmadeusPax

        pString.Clear()

        If MySettings.Value("TextOceanRig") Then
            pString.AppendLine("DATE / REF : " & Format(Today, "dd-MM-yyyy") & " / ID ")
            pString.AppendLine(" ")
            pString.AppendLine("SUBJECT : ")
            pString.AppendLine(" ")
            pString.AppendLine("PLS NOTE:  ALL RESERVATIONS ARE MADE ACCORDING TO THE CUSTOMER'S POLICY AND WITHIN MINIMUM CONNECTING TIME/TRANSFER.")
            pString.AppendLine(" ")
        End If
        With mobjAmadeus

            i = 0
            For Each pobjPax In .Passengers.Values
                i = i + 1
                pString.AppendLine(pobjPax.ElementNo & " " & pobjPax.PaxName & " " & pobjPax.PaxID)
            Next pobjPax
            If i = 0 Then
                pString.AppendLine("PASSENGER INFORMATION NOT AVAILABLE")
            End If

            ReDim Preserve pPaxNames(pPaxNames.GetUpperBound(0) + 1)
            pPaxNames(pPaxNames.GetUpperBound(0)).StartPos = rtbDoc.Text.Length + 1
            rtbDoc.Text &= pString.ToString
            pPaxNames(pPaxNames.GetUpperBound(0)).EndPos = rtbDoc.Text.Length

            pString.Clear()

            If MySettings.Value("Vessel") And .VesselName <> "" Then
                pString.AppendLine("VESSEL: " & .VesselName)
            End If

            i = 0
            For Each pobjSeg In .Segments.Values
                i = i + 1
                If i = 1 Then
                    pString.AppendLine("FLIGHT ROUTING:")
                End If
                Dim pSeg As New System.Text.StringBuilder
                pSeg.Append(pobjSeg.Airline & pobjSeg.FlightNo.PadLeft(4) & " ")
                If MySettings.Value("ClassOfService") Then
                    pSeg.Append(pobjSeg.ClassOfService & " ")
                End If
                pSeg.Append(pobjSeg.DepartureDateIATA & " ")
                If MySettings.Value("AirportName") <> 1 Then
                    pSeg.Append(pobjSeg.BoardPoint & " ")
                End If
                If MySettings.Value("AirportName") <> 0 Then
                    pSeg.Append(pobjSeg.BoardCityName.PadRight(.MaxCityNameLength + 1, ".").Substring(0, .MaxCityNameLength + 1) & " ")
                End If
                If MySettings.Value("AirportName") <> 1 Then
                    pSeg.Append(pobjSeg.OffPoint & " ")
                End If
                If MySettings.Value("AirportName") <> 0 Then
                    pSeg.Append(pobjSeg.OffPointCityName.PadRight(.MaxCityNameLength + 1, ".").Substring(0, .MaxCityNameLength + 1) & " ")
                End If
                pSeg.Append(Format(pobjSeg.DepartTime, "HHmm") & "  ")
                pSeg.Append(Format(pobjSeg.ArriveTime, "HHmm") & "  ")
                pSeg.Append(pobjSeg.ArrivalDateIATA & " ")
                pSeg.Append(If(MySettings.Value("AirlineLocator"), pobjSeg.AirlineLocator, ""))
                pString.AppendLine(pSeg.ToString)
                If pSeg.ToString.Length > mMaxString Then
                    mMaxString = pSeg.ToString.Length
                End If
            Next pobjSeg

            If i = 0 Then
                pString.AppendLine("ROUTING INFORMATION NOT AVAILABLE")
            End If

            If .RequestedPNR <> "" Then
                pString.AppendLine("Booking Reference: " & .RequestedPNR)
            End If

            If MySettings.Value("PricingOceanRig") Then
                For iPricing As Integer = 1 To .PricingTextUpperBound
                    pString.AppendLine(.PricingText(iPricing))
                Next
                'pString.AppendLine("Fare...........: " & Format(.Fare, "#,##0.00") & " EUR")
                'pString.AppendLine("Taxes..........: " & Format(.Taxes, "#,##0.00") & " EUR")
                'pString.AppendLine("Service Fee....: " & Format(.SFee, "#,##0.00") & " EUR")
                'pString.AppendLine("Quote..........: " & Format(.Quote, "#,##0.00") & " EUR")
                'pString.AppendLine("Fare: " & Format(.Fare, "#,##0.00") & " | Taxes: " & Format(.Taxes, "#,##0.00") & " | Service Fee: " & Format(.SFee, "#,##0.00") & " | Quote: " & Format(.Quote, "#,##0.00") & " EUR")
            End If

        End With

        Return pString.ToString

    End Function

    Private Function MakeRTBDocRemarks() As String

        Dim pString As New System.Text.StringBuilder
        pString.Clear()

        For iRem As Integer = 0 To lstRemarks.CheckedItems.Count - 1
            pString.AppendLine(lstRemarks.CheckedItems(iRem).ToString)
        Next

        Return pString.ToString

    End Function

    Private Function MakeRTBDocRemarks(ByVal RemIndex As Integer, ByVal Checked As Boolean) As String

        Dim pString As New System.Text.StringBuilder
        pString.Clear()

        If lstRemarks.CheckedIndices.Count > 0 Then
            If RemIndex = 0 And Checked Then
                pString.AppendLine(lstRemarks.Items(RemIndex).ToString)
                RemIndex = Integer.MaxValue
            End If
            For Each IndexChecked As Integer In lstRemarks.CheckedIndices
                If RemIndex < IndexChecked And Checked Then
                    pString.AppendLine(lstRemarks.Items(RemIndex).ToString)
                    RemIndex = Integer.MaxValue
                End If
                If IndexChecked <> RemIndex Then
                    pString.AppendLine(lstRemarks.Items(IndexChecked).ToString)
                End If
            Next
            If RemIndex <> Integer.MaxValue And Checked Then
                pString.AppendLine(lstRemarks.Items(RemIndex).ToString)
                RemIndex = Integer.MaxValue
            End If
        Else
            pString.AppendLine(lstRemarks.Items(RemIndex).ToString)
        End If

        Return pString.ToString

    End Function

    Private Function MakeRTBDocTickets() As String

        Dim pString As New System.Text.StringBuilder
        pString.Clear()

        With mobjAmadeus
            If MySettings.Value("Tickets") And .Tickets.Count >= 1 Then
                pString.AppendLine()
                pString.AppendLine("Tickets")
                For Each tkt As gtmTicket In .Tickets.Values
                    pString.AppendLine(tkt.IssuingAirline & "-" & tkt.Document)
                Next
            End If

        End With

        Return pString.ToString

    End Function

    Private Function MakeRTBDocCloseOff() As String

        Dim pString As New System.Text.StringBuilder

        pString.Clear()
        If MySettings.Value("TextOceanRig") Then
            pString.AppendLine("IF ANY QUERIES OR CHANGES NEEDED, PLEASE DO NOT HESITATE TO CONTACT US. THANK YOU FOR YOUR COOPERATION.")
            pString.AppendLine(" ")
        End If

        Return pString.ToString

    End Function
    Private Sub frmEuronav_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Me.Text = "Prepare itinerary document 06.05.2015 10:42"

        LoadRemarks()
        If MySettings.Value("AirportName") = 0 Then
            optAirportCode.Checked = True
        ElseIf MySettings.Value("AirportName") = 1 Then
            optAirportname.Checked = True
        Else
            optAirportBoth.Checked = True
        End If
        chkVessel.Checked = MySettings.Value("Vessel")
        chkClass.Checked = MySettings.Value("ClassOfService")
        chkAirlineLocator.Checked = MySettings.Value("AirlineLocator")
        chkOceanRig.Checked = MySettings.Value("TextOceanRig")
        chkOceanRigPricing.Checked = MySettings.Value("PricingOceanRig")

        cmdItnReadPNR.Enabled = False

    End Sub

    Private Sub LoadRemarks()

        With lstRemarks.Items()
            .Clear()
            .Add("SEAMAN FARE DOES NOT PERMIT UPGRADING")
            .Add("SEAMAN FARE DOES NOT PERMIT PRESEATING BUT WITH UPGRADING")
            .Add("SEAMAN FARE WITH UPGRADING")
            .Add("SEAMAN FARE WITH UPGRADING AND PRESEATING")
            .Add("PLEASE CHECK BELOW AND ADVISE IF OK TO ISSUE")
            .Add("ALL BOOKINGS ON TIME LIMIT")
            .Add("ALL FARES ON TODAY'S RATE/ADVANCE PURCHASE")
        End With

    End Sub
    Private Sub txtPNR_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPNR.TextChanged

        Try
            cmdItnReadPNR.Enabled = (txtPNR.Text.Trim.Length >= 6)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdEncode_Click(sender As Object, e As EventArgs) Handles cmdEncode.Click

        Dim pobjHostSessions As k1aHostToolKit.HostSessions
        Dim pAlphabet As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

        Dim fs As System.IO.TextWriter = System.IO.File.CreateText("C:\Users\cnicolatos\Desktop\z.txt")
        Try

            pobjHostSessions = New k1aHostToolKit.HostSessions

            If pobjHostSessions.Count > 0 Then
                mobjHostSession = pobjHostSessions.UIActiveSession
                For i1 As Integer = 26 To 26 '17 To 20 '13 To 16 '9 To 12 '6 To 8 '3 To 5 ' 1 To 2
                    For i2 As Integer = 1 To 26
                        For i3 As Integer = 1 To 26
                            Dim pComm As String = "DAC" & pAlphabet.Substring(i1 - 1, 1) & pAlphabet.Substring(i2 - 1, 1) & pAlphabet.Substring(i3 - 1, 1)
                            mobjHostSession.Send(pComm)
                            fs.WriteLine("###" & pComm & vbCrLf & mstrResponse)
                            'If MessageBox.Show(mstrResponse, "Test", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                            '    Throw New Exception("End of test")
                            'End If
                        Next
                    Next
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            fs.Close()
        End Try


    End Sub

    Private Sub mobjHostSession_ReceivedResponse(ByRef newResponse As k1aHostToolKit.CHostResponse) Handles mobjHostSession.ReceivedResponse

        mstrResponse = newResponse.Text

    End Sub

    Private Sub cmdGetAirlines_Click(sender As Object, e As EventArgs) Handles cmdGetAirlines.Click

        Dim pobjHostSessions As k1aHostToolKit.HostSessions
        Dim pAlphabet As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"

        Dim fs As System.IO.TextWriter = System.IO.File.CreateText("C:\Users\cnicolatos\Desktop\Airlines.txt")
        Try

            pobjHostSessions = New k1aHostToolKit.HostSessions

            If pobjHostSessions.Count > 0 Then
                mobjHostSession = pobjHostSessions.UIActiveSession
                For i1 As Integer = 1 To 36
                    For i2 As Integer = 1 To 36
                        Dim pComm As String = "DNA" & pAlphabet.Substring(i1 - 1, 1) & pAlphabet.Substring(i2 - 1, 1)
                        mobjHostSession.Send(pComm)
                        fs.WriteLine("###" & pComm & vbCrLf & mstrResponse)
                    Next
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            fs.Close()
        End Try

    End Sub

    Private Sub optAirportCode_CheckedChanged(sender As Object, e As EventArgs) Handles optAirportCode.CheckedChanged

        MySettings.AddReference("AirportName", 0, 0)
        MySettings.Save()

    End Sub

    Private Sub optAirportname_CheckedChanged(sender As Object, e As EventArgs) Handles optAirportname.CheckedChanged

        MySettings.AddReference("AirportName", 1, 1)
        MySettings.Save()

    End Sub

    Private Sub optAirportBoth_CheckedChanged(sender As Object, e As EventArgs) Handles optAirportBoth.CheckedChanged

        MySettings.AddReference("AirportName", 2, 2)
        MySettings.Save()

    End Sub

    Private Sub chkVessel_CheckedChanged(sender As Object, e As EventArgs) Handles chkVessel.CheckedChanged

        MySettings.AddReference("Vessel", chkVessel.Checked, chkVessel.Checked)
        MySettings.Save()

    End Sub

    Private Sub chkClass_CheckedChanged(sender As Object, e As EventArgs) Handles chkClass.CheckedChanged

        MySettings.AddReference("ClassOfService", chkClass.Checked, chkClass.Checked)
        MySettings.Save()

    End Sub

    Private Sub chkAirlineLocator_CheckedChanged(sender As Object, e As EventArgs) Handles chkAirlineLocator.CheckedChanged

        MySettings.AddReference("AirlineLocator", chkAirlineLocator.Checked, chkAirlineLocator.Checked)
        MySettings.Save()

    End Sub
    Private Sub chkTickets_CheckedChanged(sender As Object, e As EventArgs) Handles chkTickets.CheckedChanged

        MySettings.AddReference("Tickets", chkTickets.Checked, chkTickets.Checked)
        MySettings.Save()

    End Sub
    Private Sub cmdReadCurrent_Click(sender As Object, e As EventArgs) Handles cmdReadCurrent.Click

        Try
            Cursor = System.Windows.Forms.Cursors.WaitCursor

            ProcessRequestedPNRs()

            rtbDoc.SelectAll()
            Clipboard.SetText(rtbDoc.Rtf, TextDataFormat.Rtf)


            Cursor = Cursors.Default
            MessageBox.Show("Ready", "Read PNR", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub chkOceanRig_CheckedChanged(sender As Object, e As EventArgs) Handles chkOceanRig.CheckedChanged

        MySettings.AddReference("TextOceanRig", chkOceanRig.Checked, chkOceanRig.Checked)
        MySettings.Save()

    End Sub

    Private Sub chkOceanRigPricing_CheckedChanged(sender As Object, e As EventArgs) Handles chkOceanRigPricing.CheckedChanged

        MySettings.AddReference("PricingOceanRig", chkOceanRigPricing.Checked, chkOceanRigPricing.Checked)
        MySettings.Save()

    End Sub

    Private Sub lstRemarks_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lstRemarks.ItemCheck

        If rtbDoc.TextLength > 0 Then
            rtbDoc.Clear()

            If e.NewValue = CheckState.Checked Then
                makeRTBDoc(e.Index, True)
            Else
                makeRTBDoc(e.Index, False)
            End If
            PaxNamesToBold()
            rtbDoc.SelectAll()

            Clipboard.Clear()
            Clipboard.SetText(rtbDoc.Rtf, TextDataFormat.Rtf)
        End If

    End Sub

End Class