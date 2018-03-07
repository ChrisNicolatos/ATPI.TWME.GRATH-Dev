Option Strict Off
Option Explicit On
Namespace GDSTickets
    Public Class Item
        Public Enum TicketDocType
            NONE = 0
            ETKT = 1
            VCHR = 2
            INTR = 3
        End Enum
        Private Structure ClassProps
            Dim DocType As TicketDocType ' 1=ETKT 2= VCHR 3=Interoffice ticket
            Dim ID As String
            Dim PaxType As String
            Dim TicketNumber As String
            Dim IssuingAirline As String
            Dim Price As String
            Dim IssueDate As String
            Dim PCC As String
            Dim IATA As String
            Dim PaxID As String
            Dim SegsElementNo As String
            Dim SegsDescription As String
            Dim ClassAir As String
            Dim ClassCust As String
            Dim RawText As String
            Dim SellingPrice As Decimal
        End Structure
        Private mudtProps As ClassProps

        Public ReadOnly Property DocType As TicketDocType
            Get
                DocType = mudtProps.DocType
            End Get
        End Property

        Public ReadOnly Property TicketNumber As String
            Get
                TicketNumber = mudtProps.TicketNumber
            End Get
        End Property

        Public ReadOnly Property ID As String
            Get
                ID = mudtProps.ID
            End Get
        End Property
        Public ReadOnly Property PaxType As String
            Get
                PaxType = mudtProps.PaxType
            End Get
        End Property
        Public ReadOnly Property IssuingAirline As String
            Get
                IssuingAirline = mudtProps.IssuingAirline
            End Get
        End Property
        Public ReadOnly Property Price As String
            Get
                Price = mudtProps.Price
            End Get
        End Property
        Public ReadOnly Property IssueDate As String
            Get
                IssueDate = mudtProps.IssueDate
            End Get
        End Property
        Public ReadOnly Property PCC As String
            Get
                PCC = mudtProps.PCC
            End Get
        End Property
        Public ReadOnly Property IATA As String
            Get
                IATA = mudtProps.IATA
            End Get
        End Property
        Public ReadOnly Property RawText As String
            Get
                RawText = mudtProps.RawText
            End Get
        End Property
        Public ReadOnly Property PaxID() As String
            Get
                PaxID = mudtProps.PaxID
            End Get
        End Property
        Public Property SegsElementNo As String
            Get
                SegsElementNo = mudtProps.SegsElementNo
            End Get
            Set(value As String)
                mudtProps.SegsElementNo = value
            End Set
        End Property
        Public Property SegsDescription As String
            Get
                SegsDescription = mudtProps.SegsDescription
            End Get
            Set(value As String)
                mudtProps.SegsDescription = value
            End Set
        End Property
        Public Property ClassAir As String
            Get
                ClassAir = mudtProps.ClassAir
            End Get
            Set(value As String)
                mudtProps.ClassAir = value
            End Set
        End Property
        Public Property ClassCust As String
            Get
                ClassCust = mudtProps.ClassCust
            End Get
            Set(value As String)
                mudtProps.ClassCust = value
            End Set
        End Property
        Public Property SellingPrice As Decimal
            Get
                SellingPrice = mudtProps.SellingPrice
            End Get
            Set(value As Decimal)
                mudtProps.SellingPrice = value
            End Set
        End Property
        Public Sub SetElement(ByVal RawText As String, ByVal DocType As TicketDocType, ByVal PaxID As String, ByVal SegsElementNo As String) ', ByVal SegsDescription As String) ', ByVal ClassAir As String)

            With mudtProps
                ' 2 examples of RawText
                ' 30 FA PAX 724-4175946315/ETLX/EUR369.39/13SEP13/ATHG42100/27280                
                '       573/S5-8/P4
                '28 FA PAX 157-4175946329/ETQR/13SEP13/ATHG42100/27280573                       
                '       /S6-7/P1 
                ' after the split we can have:
                '(0) - 30FAPAX724-4175946315
                '(1) - ETLX
                '(2) - EUR369.39
                '(3) - 13SEP13
                '(4) - ATHG42100'
                '(5) - 27280573
                '(6) - S5-8
                '(7) - P4
                '
                ' or
                '
                '(0) - 28FAPAX157-4175946329
                '(1) - ETQR
                '(2) - 13SEP13
                '(3) - ATHG42100
                '(4) - 27280573
                '(5) - S6-7
                '(6) - P1 
                '
                ' or for a voucher
                '
                ' 21 OSI YY ATH VCHR 9783035 AL.O/SG4   
                '


                .RawText = RawText
                .DocType = DocType
                .PaxID = PaxID
                .ClassCust = ""
                Dim pSegs() As String = Split(SegsElementNo, ":")
                If pSegs.GetUpperBound(0) = 2 Then
                    .SegsElementNo = pSegs(0).Trim
                    .SegsDescription = pSegs(1).Trim
                    .ClassAir = pSegs(2).Trim
                Else
                    .SegsElementNo = ""
                    .SegsDescription = ""
                    .ClassAir = ""
                End If

                If DocType = TicketDocType.VCHR Then
                    Dim iVchrFrom As Integer = -1
                    Dim iALFrom As Integer = -1
                    Dim iSGFrom As Integer = -1
                    .PaxType = "Voucher"
                    iVchrFrom = .RawText.IndexOf("VCHR")
                    If iVchrFrom > 0 And iVchrFrom < .RawText.Length + 5 Then
                        iALFrom = .RawText.IndexOf("AL", iVchrFrom + 4)
                        If iALFrom > 0 And iALFrom < .RawText.Length + 5 Then
                            iSGFrom = .RawText.IndexOf("/SG", iALFrom + 4)
                        Else
                            iSGFrom = .RawText.IndexOf("/SG", iVchrFrom + 4)
                        End If
                        If iALFrom = -1 Then
                            iALFrom = .RawText.Length
                        End If
                        If iSGFrom = -1 Then
                            iSGFrom = .RawText.Length
                        End If
                        If iALFrom <= iSGFrom Then
                            .TicketNumber = .RawText.Substring(iVchrFrom + 4, iALFrom - iVchrFrom - 5)
                        Else
                            .TicketNumber = .RawText.Substring(iVchrFrom + 4, iSGFrom - iVchrFrom - 5)
                        End If
                        If iALFrom < .RawText.Length - 4 Then
                            .IssuingAirline = .RawText.Substring(iALFrom + 2, iSGFrom - iALFrom - 2)
                        End If
                        If iSGFrom < .RawText.Length - 3 Then
                            .SegsElementNo = "S" & .RawText.Substring(iSGFrom + 3, .RawText.Length - iSGFrom - 3)
                        End If
                    Else
                        .TicketNumber = .RawText
                    End If

                Else
                    Dim pItems() As String = Split(RawText.Replace(" ", ""), "/")
                    If pItems.GetUpperBound(0) >= 4 Then
                        .TicketNumber = pItems(0)
                        Dim i1 As Integer = pItems(0).IndexOf("FA")
                        If i1 > 0 Then
                            .ID = pItems(0).Substring(0, i1)
                            .PaxType = pItems(0).Substring(i1 + 2, 3)
                            .TicketNumber = pItems(0).Substring(i1 + 5)
                        End If
                        .IssuingAirline = pItems(1).Substring(2)
                        Dim pPriceIndex As Integer = 2
                        If IsNumeric(("0" & pItems(2)).Substring(0, 1)) Then
                            pPriceIndex = 1
                            .Price = ""
                        Else
                            .Price = pItems(pPriceIndex)
                        End If
                        .IssueDate = pItems(pPriceIndex + 1)
                        .PCC = pItems(pPriceIndex + 2)
                        .IATA = pItems(pPriceIndex + 3)
                    Else
                        .TicketNumber = RawText
                        .ID = PaxID
                        .PaxType = ""
                        .IssuingAirline = ""
                        .Price = ""
                        .IssueDate = ""
                        .PCC = ""
                        .IATA = ""
                    End If
                End If
            End With

        End Sub
    End Class

    Public Class Collection

        Private mobjTickets() As Item
        Private mobjPNR As s1aPNR.PNR

        'Private MySettings As New References

        Public Sub New(ByVal pPnr As s1aPNR.PNR)
            mobjPNR = pPnr
            ReadTickets()
        End Sub

        Private Sub ReadTickets()

            Dim FAOwnTkt As String = ""
            Dim FAInterofficeTkt As String = ""
            ' example : 12 OSI YY ATH VCHR 97893469 AL.M/SG2-3   

            ReDim mobjTickets(0)

            For Each objOSI As s1aPNR.OtherServiceElement In mobjPNR.OtherServiceElements
                If objOSI.Text.IndexOf("ATH VCHR") > 0 Then
                    FAOwnTkt &= objOSI.Text & vbCrLf
                    ReDim Preserve mobjTickets(mobjTickets.GetUpperBound(0) + 1)
                    mobjTickets(mobjTickets.GetUpperBound(0)) = New Item
                    mobjTickets(mobjTickets.GetUpperBound(0)).SetElement(objOSI.Text, Item.TicketDocType.VCHR, "", "") ', "") ', "")
                End If
            Next
            For Each objFA As s1aPNR.FareAutoTktElement In mobjPNR.FareAutoTktElements
                If objFA.Text.Replace(" ", "").Contains(MySettings.GDSPcc) Then
                    FAOwnTkt &= objFA.Text & vbCrLf
                    ReDim Preserve mobjTickets(mobjTickets.GetUpperBound(0) + 1)
                    mobjTickets(mobjTickets.GetUpperBound(0)) = New Item
                    mobjTickets(mobjTickets.GetUpperBound(0)).SetElement(objFA.Text, Item.TicketDocType.ETKT, BuildPaxname(objFA.Associations.Passengers), BuildSegments(objFA.Associations.Segments)) ', "") ', "")
                    FAOwnTkt &= "-----------------------------------------" & vbCrLf
                Else
                    FAInterofficeTkt &= objFA.Text & vbCrLf
                    ReDim Preserve mobjTickets(mobjTickets.GetUpperBound(0) + 1)
                    mobjTickets(mobjTickets.GetUpperBound(0)) = New Item
                    mobjTickets(mobjTickets.GetUpperBound(0)).SetElement(objFA.Text, Item.TicketDocType.INTR, BuildPaxname(objFA.Associations.Passengers), BuildSegments(objFA.Associations.Segments)) ', "") ', "")
                    FAInterofficeTkt &= "-----------------------------------------" & vbCrLf
                End If
            Next

            For i As Integer = 1 To mobjTickets.GetUpperBound(0)
                If mobjTickets(i).DocType = Item.TicketDocType.VCHR Then
                    For j = i + 1 To mobjTickets.GetUpperBound(0)
                        If mobjTickets(j).SegsElementNo.StartsWith(mobjTickets(i).SegsElementNo) Then
                            mobjTickets(i).SegsElementNo = mobjTickets(j).SegsElementNo
                            Exit For
                        End If
                    Next
                End If
            Next

        End Sub

        Public ReadOnly Property GetUpperBound As Integer
            Get
                GetUpperBound = mobjTickets.GetUpperBound(0)
            End Get
        End Property

        Public ReadOnly Property Tickets(ByVal Index As Integer) As Item
            Get
                If Index >= 1 And Index <= mobjTickets.GetUpperBound(0) Then
                    Tickets = mobjTickets(Index)
                Else
                    Throw New Exception("Invalid Index")
                End If
            End Get
        End Property

        Private Function BuildPaxname(ByVal PaxElements As Object) As String

            Dim PaxCount As Integer = 0
            BuildPaxname = ""

            For Each Pax As s1aPNR.NameElement In PaxElements
                BuildPaxname &= MakePaxNameString(Pax)
                PaxCount += 1
            Next
            If PaxCount = 0 Then
                For Each Pax As s1aPNR.NameElement In mobjPNR.NameElements
                    BuildPaxname &= MakePaxNameString(Pax)
                Next
            End If

        End Function

        Private Function MakePaxNameString(ByVal Pax As s1aPNR.NameElement) As String

            MakePaxNameString = Pax.ElementNo & ". " & Pax.LastName & "/" & Pax.Initial
            If Pax.PassengerType <> "" Then
                MakePaxNameString &= " (" & Pax.PassengerType & ")"
            End If
            If Pax.ID <> "" Then
                MakePaxNameString &= " (" & Pax.ID & ")"
            End If
            MakePaxNameString &= vbCrLf

        End Function

        Private Function BuildSegments(ByVal SegElements As Object) As String

            Dim SegCount As Integer = 0
            Dim SegNo As String = ""
            Dim SegItn As String = ""
            Dim SegClass As String = ""
            Dim PrevSeg As String = ""
            Dim ElementNo As Integer = 0

            BuildSegments = ""

            Try

                For Each Seg As Object In SegElements
                    ElementNo = Seg.ElementNo
                    ' the first segment no goes automatically into the list as the start
                    If SegNo = "" Then
                        SegNo &= ElementNo
                    Else
                        ' compare the segment no with the last one in the list
                        Dim a2 As Integer = SegNo.Substring(SegNo.Length - 1, 1)
                        ' if it is in sequence
                        If ElementNo = a2 + 1 Then
                            ' and it is the second one, put it in the list preceded by a hyphen
                            If SegNo.Length = 1 Then
                                SegNo &= "-" & ElementNo
                            Else
                                ' otherwise replace the last no with this one
                                SegNo = SegNo.Substring(0, SegNo.Length - 1) & ElementNo
                            End If
                        Else
                            ' if it is not in sequence, precede it with a comma
                            SegNo &= "," & ElementNo
                        End If
                    End If
                    If PrevSeg = Seg.BoardPoint Then
                        SegItn &= "-" & Seg.OffPoint
                        SegClass &= "-" & Seg.Class
                    Else
                        If SegItn <> "" Then
                            SegItn &= "-***-"
                            SegClass &= "-"
                        End If
                        SegItn &= Seg.BoardPoint & "-" & Seg.OffPoint
                        SegClass &= Seg.Class
                    End If
                    PrevSeg = Seg.OffPoint
                    SegCount += 1
                Next
                If SegCount = 0 Then
                    For Each Seg As Object In mobjPNR.AirSegments
                        SegNo &= Seg.ElementNo
                        If PrevSeg = Seg.BoardPoint Then
                            SegItn &= "-" & Seg.OffPoint
                            SegClass &= "-" & Seg.Class
                        Else
                            If SegItn <> "" Then
                                SegItn &= "-***-"
                                SegClass &= "-*-"
                            End If
                            SegItn &= Seg.BoardPoint & "-" & Seg.OffPoint
                            SegClass &= Seg.Class
                        End If
                        PrevSeg = Seg.OffPoint
                    Next
                End If

                BuildSegments = "S" & SegNo & ": " & SegItn & ": " & SegClass
            Catch ex As MissingMemberException
                If ElementNo <> 0 Then
                    BuildSegments = mobjPNR.AllElements.Item(ElementNo).text
                Else
                    BuildSegments = ""
                End If
            Catch ex As Exception
                BuildSegments = ""
            End Try

        End Function

        'Private Function MakeSegString(ByVal Seg As Object) As String

        '    Try
        '        MakeSegString = Seg.ElementNo & " " & Seg.BoardPoint & "-" & Seg.OffPoint & vbCrLf
        '    Catch ex As Exception
        '        MakeSegString = "??"
        '    End Try


        'End Function

        'Public Sub UpdatePrices()

        'End Sub

    End Class

End Namespace
