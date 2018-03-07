Option Strict Off
Option Explicit On
Namespace GDSNew
    Public Class Item
        Private Structure NewItemClass
            Dim GDSCommand As String
            Dim TextRequested As String
            Friend Sub Clear()
                GDSCommand = ""
                TextRequested = ""
            End Sub

        End Structure
        Private mudtProps As NewItemClass
        Public ReadOnly Property GDSCommand As String
            Get
                GDSCommand = mudtProps.GDSCommand
            End Get
        End Property
        Public ReadOnly Property TextRequested As String
            Get
                TextRequested = mudtProps.TextRequested
            End Get
        End Property

        Friend Sub SetText(ByVal Value As String)
            mudtProps.TextRequested = Value
        End Sub

        Friend Sub SetText(ByVal Value As String, ByVal pAmadeusCommand As String)
            mudtProps.TextRequested = Value
            mudtProps.GDSCommand = pAmadeusCommand
        End Sub

        Friend Sub Clear()
            mudtProps.Clear()
        End Sub

    End Class
    Public Class Collection
        Private mobjOpenSegment As New Item
        Private mobjPhoneElement As New Item
        Private mobjEmailElement As New Item
        Private mobjTicketElement As New Item

        Private mobjOptionQueueElement As New Item
        Private mobjAOH As New Item
        Private mobjAgentID As New Item
        Private mobjSavingsElement As New Item
        Private mobjLossElement As New Item

        Private mobjCustomerCode As New Item
        Private mobjCustomerName As New Item
        Private mobjSubDepartmentCode As New Item
        Private mobjSubDepartmentName As New Item
        Private mobjCRMCode As New Item
        Private mobjCRMName As New Item
        Private mobjVesselName As New Item
        Private mobjVesselFlag As New Item
        Private mobjVesselOSI As New Item
        Private mobjReference As New Item
        Private mobjBookedBy As New Item
        Private mobjDepartment As New Item
        Private mobjReasonForTravel As New Item
        Private mobjCostCentre As New Item

        Private mobjVesselNameForPNR As New Item
        Private mobjVesselFlagForPNR As New Item

        Private mobjGreekToLatin As New GreekToLatin

        Private mstrOfficeOfResponsibility As String
        Private mdteCreationDate As Date
        Private mdteDepartureDate As Date
        Private mintNumberOfPax As Integer

        Public Sub New(ByVal pOfficeOfResponsibility As String, ByVal pCreationDate As Date, ByVal pDepartureDate As Date, ByVal pNumberOfPax As Integer)
            mstrOfficeOfResponsibility = pOfficeOfResponsibility
            mdteCreationDate = pCreationDate
            mdteDepartureDate = pDepartureDate
            mintNumberOfPax = pNumberOfPax
            PrepareCommands()
        End Sub

        Public ReadOnly Property OpenSegment As Item
            Get
                OpenSegment = mobjOpenSegment
            End Get
        End Property
        Public ReadOnly Property PhoneElement As Item
            Get
                PhoneElement = mobjPhoneElement
            End Get
        End Property
        Public ReadOnly Property EmailElement As Item
            Get
                EmailElement = mobjEmailElement
            End Get
        End Property
        Public ReadOnly Property TicketElement As Item
            Get
                TicketElement = mobjTicketElement
            End Get
        End Property
        Public ReadOnly Property OptionQueueElement As Item
            Get
                OptionQueueElement = mobjOptionQueueElement
            End Get
        End Property
        Public ReadOnly Property AOH As Item
            Get
                AOH = mobjAOH
            End Get
        End Property
        Public ReadOnly Property AgentID As Item
            Get
                AgentID = mobjAgentID
            End Get
        End Property
        Public ReadOnly Property CustomerCode As Item
            Get
                CustomerCode = mobjCustomerCode
            End Get
        End Property
        Public ReadOnly Property SavingsElement As Item
            Get
                SavingsElement = mobjSavingsElement
            End Get
        End Property
        Public ReadOnly Property LossElement As Item
            Get
                LossElement = mobjLossElement
            End Get
        End Property
        Public ReadOnly Property CustomerName As Item
            Get
                CustomerName = mobjCustomerName
            End Get
        End Property
        Public ReadOnly Property SubDepartmentCode As Item
            Get
                SubDepartmentCode = mobjSubDepartmentCode
            End Get
        End Property
        Public ReadOnly Property SubDepartmentName As Item
            Get
                SubDepartmentName = mobjSubDepartmentName
            End Get
        End Property
        Public ReadOnly Property CRMCode As Item
            Get
                CRMCode = mobjCRMCode
            End Get
        End Property
        Public ReadOnly Property CRMName As Item
            Get
                CRMName = mobjCRMName
            End Get
        End Property
        Public ReadOnly Property VesselName As Item
            Get
                VesselName = mobjVesselName
            End Get
        End Property
        Public ReadOnly Property VesselFlag As Item
            Get
                VesselFlag = mobjVesselFlag
            End Get
        End Property
        Public ReadOnly Property VesselOSI As Item
            Get
                VesselOSI = mobjVesselOSI
            End Get
        End Property
        Public ReadOnly Property VesselNameForPNR As Item
            Get
                VesselNameForPNR = mobjVesselNameForPNR
            End Get
        End Property
        Public ReadOnly Property VesselFlagForPNR As Item
            Get
                VesselFlagForPNR = mobjVesselFlagForPNR
            End Get
        End Property
        Public ReadOnly Property Reference As Item
            Get
                Reference = mobjReference
            End Get
        End Property
        Public ReadOnly Property BookedBy As Item
            Get
                BookedBy = mobjBookedBy
            End Get
        End Property
        Public ReadOnly Property Department As Item
            Get
                Department = mobjDepartment
            End Get
        End Property
        Public ReadOnly Property ReasonForTravel As Item
            Get
                ReasonForTravel = mobjReasonForTravel
            End Get
        End Property
        Public ReadOnly Property CostCentre As Item
            Get
                CostCentre = mobjCostCentre
            End Get
        End Property

        Public Sub SetItem(ByVal Item As Customers.CustomerItem)

            mobjCustomerCode.Clear()
            mobjCustomerName.Clear()
            If Not Item Is Nothing Then
                If Item.Code <> "" Then
                    mobjCustomerCode.SetText(Item.Code, MySettings.GDSValue("TextCLN") & Item.Code)
                End If
                If Item.Name <> "" Then
                    mobjCustomerName.SetText(Item.Name, MySettings.GDSValue("TextCLA") & mobjGreekToLatin.Convert(Item.Name))
                End If
                'PrepareAirlinePoints()
            End If

        End Sub
        Public Sub SetItem(ByVal Item As SubDepartments.Item)

            mobjSubDepartmentCode.Clear()
            mobjSubDepartmentName.Clear()
            If Not Item Is Nothing Then
                If Item.ID > 0 Then
                    mobjSubDepartmentCode.SetText(Item.Code, MySettings.GDSValue("TextSBN") & Item.ID)
                End If
                If Item.Name <> "" Then
                    mobjSubDepartmentName.SetText(Item.Name, MySettings.GDSValue("TextSBA") & mobjGreekToLatin.Convert(Item.Name))
                End If
            End If

        End Sub
        Public Sub SetItem(ByVal Item As CRM.Item)

            mobjCRMCode.Clear()
            mobjCRMName.Clear()
            If Not Item Is Nothing Then
                If Item.ID > 0 Then
                    mobjCRMCode.SetText(Item.Code, MySettings.GDSValue("TextCRN") & Item.Code)
                End If
                If Item.Name <> "" Then
                    mobjCRMName.SetText(Item.Name, MySettings.GDSValue("TextCRA") & mobjGreekToLatin.Convert(Item.Name))
                End If
            End If

        End Sub
        Public Sub SetItem(ByVal Item As Vessels.Item)

            mobjVesselName.Clear()
            mobjVesselFlag.Clear()
            If Not Item Is Nothing Then
                mobjVesselName.SetText(Item.Name, MySettings.GDSValue("TextVSL") & Item.Name)
                If Item.Flag <> "" Then
                    mobjVesselFlag.SetText(Item.Flag, MySettings.GDSValue("TextVSR") & Item.Flag)
                End If
                mobjVesselOSI.SetText("", MySettings.GDSValue("TextVOS") & Item.Name)
                mobjVesselNameForPNR.Clear()
                mobjVesselFlagForPNR.Clear()
            End If

        End Sub
        Public Sub SetVesselForPNR(ByVal pVesselName As String, ByVal pVesselFlag As String)

            mobjVesselName.Clear()
            mobjVesselFlag.Clear()
            If pVesselName <> "" Then
                mobjVesselName.SetText("", MySettings.GDSValue("TextVSL") & mobjVesselNameForPNR.TextRequested)
                mobjVesselOSI.SetText("", MySettings.GDSValue("TextVOS") & mobjVesselNameForPNR.TextRequested)
                If pVesselFlag <> "" Then
                    mobjVesselFlag.SetText("", MySettings.GDSValue("TextVSR") & mobjVesselFlagForPNR.TextRequested)
                    If mobjVesselOSI.GDSCommand <> "" Then
                        mobjVesselOSI.SetText("", MySettings.GDSValue("TextVOS") & mobjVesselFlagForPNR.TextRequested)
                    End If
                End If
            End If

            mobjVesselNameForPNR.SetText(pVesselName)
            mobjVesselFlagForPNR.SetText(pVesselFlag)

        End Sub
        Public Sub SetReference(ByVal Text As String)
            Text = Text.Trim
            If Text <> "" Then
                mobjReference.SetText(Text, MySettings.GDSValue("TextREF") & Text)
            Else
                mobjReference.Clear()
            End If
        End Sub
        Public Sub SetBookedBy(ByVal Text As String)
            Text = Text.Trim
            If Text <> "" Then
                mobjBookedBy.SetText(Text, MySettings.GDSValue("TextBBY") & Text)
            Else
                mobjBookedBy.Clear()
            End If
        End Sub
        Public Sub SetDepartment(ByVal Text As String)
            Text = Text.Trim
            If Text <> "" Then
                mobjDepartment.SetText(Text, MySettings.GDSValue("TextDPT") & Text)
            Else
                mobjDepartment.Clear()
            End If
        End Sub
        Public Sub SetReasonForTravel(ByVal Text As String)
            Text = Text.Trim
            If Text <> "" Then
                mobjReasonForTravel.SetText(Text, MySettings.GDSValue("TextRFT") & Text)
            Else
                mobjReasonForTravel.Clear()
            End If
        End Sub
        Public Sub SetCostCentre(ByVal Text As String)
            Text = Text.Trim
            If Text <> "" Then
                mobjCostCentre.SetText(Text, MySettings.GDSValue("TextCC") & Text)
            Else
                mobjCostCentre.Clear()
            End If
        End Sub
        Private Sub PrepareCommands()

            Dim pDate As New s1aAirlineDate.clsAirlineDate

            Try
                pDate.VBDate = DateAdd(DateInterval.Month, 11, mdteCreationDate)
            Catch ex As OverflowException
                pDate.VBDate = DateAdd(DateInterval.Month, 11, Today)
            Catch ex As Exception
                Throw New Exception("PreparePNRCommands()" & vbCrLf & ex.Message)
            End Try
            mobjOpenSegment.SetText("",
                                    MySettings.GDSValue("TextMISSegmentCommand") &
                                    IIf(mintNumberOfPax = 0, 1, mintNumberOfPax) & " " &
                                    MySettings.OfficeCityCode & " " &
                                    pDate.IATA & "-" & MySettings.GDSValue("TextMISSegmentText"))
            mobjPhoneElement.SetText("", (MySettings.GDSValue("TextAP").Replace("  ", " ")))
            mobjEmailElement.SetText("", MySettings.GDSValue("TextAPE"))
            mobjAgentID.SetText("", MySettings.GDSValue("TextAGT"))

            If mdteDepartureDate > DateAdd(DateInterval.Day, 3, Today) Then ' Date.MinValue Then
                pDate.VBDate = DateAdd(DateInterval.Day, -3, mdteDepartureDate)
            Else
                pDate.VBDate = Today
            End If
            Dim pTTLAmadeus As String
            If mstrOfficeOfResponsibility <> MySettings.GDSPCC Then
                pTTLAmadeus = MySettings.GDSValue("TextTTL") & pDate.IATA & "/" & MySettings.GDSPCC
            Else
                pTTLAmadeus = MySettings.GDSValue("TextTTL") & pDate.IATA
            End If
            mobjTicketElement.SetText("", pTTLAmadeus)

            If mdteDepartureDate > Today Then
                pDate.VBDate = DateAdd(DateInterval.Day, 1, mdteDepartureDate)
            Else
                pDate.VBDate = Today
            End If
            mobjOptionQueueElement.SetText("", MySettings.GDSValue("TextOPC") & MySettings.GDSPCC & "/" & pDate.IATA & "/" & MySettings.AgentOPQueue)

            mobjAOH.SetText("", MySettings.GDSValue("TextAOH"))

        End Sub
        Public Sub Clear()

            mobjOpenSegment.Clear()
            mobjPhoneElement.Clear()
            mobjEmailElement.Clear()
            mobjTicketElement.Clear()

            mobjOptionQueueElement.Clear()
            mobjAOH.Clear()
            mobjAgentID.Clear()
            mobjSavingsElement.Clear()
            mobjLossElement.Clear()

            ClearCustomerElements()

        End Sub
        Public Sub ClearCustomerElements()
            mobjCustomerCode.Clear()
            mobjCustomerName.Clear()
            mobjSubDepartmentCode.Clear()
            mobjSubDepartmentName.Clear()
            mobjCRMCode.Clear()
            mobjCRMName.Clear()
            mobjVesselName.Clear()
            mobjVesselFlag.Clear()
            mobjVesselOSI.Clear()
            mobjReference.Clear()
            mobjBookedBy.Clear()
            mobjDepartment.Clear()
            mobjReasonForTravel.Clear()
            mobjCostCentre.Clear()
            mobjVesselNameForPNR.Clear()
            mobjVesselFlagForPNR.Clear()
        End Sub
    End Class

End Namespace
