Option Strict Off
Option Explicit On
Friend Class GDSPnr
    Implements IGDSPnr
    Public Event ReadStatus(ByRef Status As Short, ByRef StatusDescription As String)
    Private Structure ClassProps
        Dim RequestedPNR As String
        Dim UserSignIn As String
        Dim PNRCreationdate As Date
        Dim Seats As String

        Dim isDirty As Boolean
        Dim isValid As Boolean
        Dim isNew As Boolean
    End Structure

    Private Structure TQTProps
        Dim TQTElement As Integer
        Dim Segment As Integer
        Dim Itin As String
        Dim Allowance As String
        Dim Pax As String
        Dim Status As String
    End Structure

    Private mudtProps As ClassProps
    Private mudtTQT() As TQTProps
    Private mudtAllowance() As TQTProps

    Private WithEvents mobjHostSession As k1aHostToolKit.HostSession
    Private mobjPNR1A As s1aPNR.PNR
    Private mobjPNR1G As Travelport.TravelData.BookingFile
    Private mobjPax As GDSPax.GDSPaxColl
    Private mobjSegs As GDSSeg.GDSSegColl
    Private mSegsFirstElement As Integer
    Private mSegsLastElement As Integer
    Private mobjNumberParser As GDSNumberParser
    Private mstrVesselName As String
    Private mobjTickets As Ticket.TicketColl
    Private mobjFrequentFlyer As FrequentFlyer.FrequentFlyerColl
    Private mstrBookedBy As String
    Private mstrCC As String
    Private mstrCLN As String
    Private mstrCLA As String
    Private mstrGroupName As String
    Private mintGroupNamesCount As Integer
    Private mflgCancelError As Boolean

    Private mintStatus As Short
    Private mstrStatus As String
    Private Sub Class_Initialize_Renamed()
        mobjPax = New GDSPax.GDSPaxColl
        mobjSegs = New GDSSeg.GDSSegColl
        mobjNumberParser = New GDSNumberParser
        mobjFrequentFlyer = New FrequentFlyer.FrequentFlyerColl
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Public ReadOnly Property AllowanceForSegment(ByVal Origin As String, ByVal Destination As String, ByVal Airline As String) As String Implements IGDSPnr.AllowanceForSegment ', ByVal Pax As String) As String
        Get
            AllowanceForSegment = ""
            If Not IsNothing(mudtAllowance) Then
                For i As Integer = 1 To mudtAllowance.GetUpperBound(0)
                    If mudtAllowance(i).Itin = Origin & " " & Airline & " " & Destination Then
                        AllowanceForSegment = mudtAllowance(i).Allowance
                    End If
                Next
            End If
        End Get
    End Property
    Public ReadOnly Property FrequentFlyerNumber(ByVal Airline As String, ByVal PaxName As String) As String Implements IGDSPnr.FrequentFlyerNumber
        Get
            FrequentFlyerNumber = ""
            For Each pItem As FrequentFlyer.FrequentFlyerItem In mobjFrequentFlyer.Values
                If pItem.Airline = Airline And pItem.PaxName = PaxName Then
                    FrequentFlyerNumber = pItem.Airline & " " & pItem.FrequentTravelerNo
                    Exit For
                End If
            Next
        End Get
    End Property
    Public ReadOnly Property VesselName() As String Implements IGDSPnr.VesselName
        Get
            VesselName = mstrVesselName
        End Get
    End Property
    Public ReadOnly Property ClientName As String Implements IGDSPnr.ClientName
        Get
            ClientName = mstrCLA
        End Get
    End Property
    Public ReadOnly Property ClientCode As String Implements IGDSPnr.ClientCode
        Get
            ClientCode = mstrCLN
        End Get
    End Property
    Public ReadOnly Property BookedBy As String Implements IGDSPnr.BookedBy
        Get
            BookedBy = mstrBookedBy
        End Get
    End Property
    Public ReadOnly Property CostCentre As String Implements IGDSPnr.CostCentre
        Get
            CostCentre = mstrCC
        End Get
    End Property
    Public ReadOnly Property RequestedPNR() As String Implements IGDSPnr.RequestedPNR
        Get
            RequestedPNR = mudtProps.RequestedPNR
        End Get
    End Property
    Public ReadOnly Property Seats As String Implements IGDSPnr.Seats
        Get
            Seats = mudtProps.Seats
        End Get
    End Property
    Public Property CancelError() As Boolean Implements IGDSPnr.CancelError
        Get
            CancelError = mflgCancelError
        End Get
        Set(ByVal Value As Boolean)
            mflgCancelError = Value
        End Set
    End Property

    Public ReadOnly Property Tickets() As Ticket.TicketColl Implements IGDSPnr.Tickets
        Get
            Tickets = mobjTickets
        End Get
    End Property

    Public ReadOnly Property Segments() As GDSSeg.GDSSegColl Implements IGDSPnr.Segments
        Get
            Segments = mobjSegs
        End Get
    End Property
    Public ReadOnly Property HasSegments As Boolean Implements IGDSPnr.HasSegments
        Get
            HasSegments = (mSegsLastElement > -1)
        End Get
    End Property
    Public ReadOnly Property FirstSegment As GDSSeg.GDSSegItem Implements IGDSPnr.FirstSegment
        Get
            If mSegsFirstElement = -1 Then
                FirstSegment = New GDSSeg.GDSSegItem
            Else
                FirstSegment = mobjSegs(Format(mSegsFirstElement))
            End If
        End Get
    End Property
    Public ReadOnly Property LastSegment As GDSSeg.GDSSegItem Implements IGDSPnr.LastSegment
        Get
            If mSegsLastElement = -1 Then
                LastSegment = New GDSSeg.GDSSegItem
            Else
                LastSegment = mobjSegs(Format(mSegsLastElement))
            End If
        End Get
    End Property
    Public ReadOnly Property MaxAirportNameLength As Integer Implements IGDSPnr.MaxAirportNameLength
        Get
            MaxAirportNameLength = mobjSegs.MaxAirportNameLength
        End Get
    End Property
    Public ReadOnly Property MaxCityNameLength As Integer Implements IGDSPnr.MaxCityNameLength
        Get
            MaxCityNameLength = mobjSegs.MaxCityNameLength
        End Get
    End Property
    Public ReadOnly Property MaxAirportShortNameLength As Integer Implements IGDSPnr.MaxAirportShortNameLength
        Get
            MaxAirportShortNameLength = mobjSegs.MaxAirportShortNameLength
        End Get
    End Property
    Public ReadOnly Property Passengers() As GDSPax.GDSPaxColl Implements IGDSPnr.Passengers
        Get
            Passengers = mobjPax
        End Get
    End Property
    Public ReadOnly Property GroupName As String Implements IGDSPnr.GroupName
        Get
            GroupName = mstrGroupName
        End Get
    End Property
    Public ReadOnly Property GroupNamesCount As Integer Implements IGDSPnr.GroupNamesCount
        Get
            GroupNamesCount = mintGroupNamesCount
        End Get
    End Property
    Public ReadOnly Property IsGroup As Boolean Implements IGDSPnr.IsGroup
        Get
            IsGroup = (mstrGroupName <> "")
        End Get
    End Property
    Public Function RetrievePNRsFromQueue(ByVal Queue As String) As String Implements IGDSPnr.RetrievePNRsFromQueue

        Dim pobjHostSessions As k1aHostToolKit.HostSessions
        Dim pQV As String = ""

        RetrievePNRsFromQueue = ""

        Try
            mstrStatus = ""
            pobjHostSessions = New k1aHostToolKit.HostSessions

            If pobjHostSessions.Count > 0 Then
                mobjHostSession = pobjHostSessions.UIActiveSession

                If Queue <> "" Then
                    mobjHostSession.Send("QI")
                    mobjHostSession.Send("IG")
                End If
                pQV &= mobjHostSession.Send("QV/" & Queue).Text
                Do While pQV.IndexOf(")>") = pQV.Length - 4
                    pQV &= mobjHostSession.Send("MDR").Text
                Loop
                Dim pLines() As String = pQV.Split({vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
                Dim pPNRs As String = ""
                For i As Integer = 4 To pLines.GetUpperBound(0)
                    If pLines(i).Length >= 19 Then
                        pPNRs &= pLines(i).Substring(14, 6) & vbCrLf
                    End If
                Next
                RetrievePNRsFromQueue = pPNRs
            Else
                Throw New Exception("Amadeus not signed in")
            End If


        Catch ex As Exception
            mintStatus = 999
            mstrStatus = Err.Description
            RaiseEvent ReadStatus(mintStatus, mstrStatus)

            If CancelError Then
                Throw New Exception("RetrivePNRsFromQueue()" & vbCrLf & mstrStatus)
            End If
        End Try

    End Function
    Public Function ReadPNR(ByVal pGDSCode As Config.GDSCode, ByVal PNR As String, ByVal ForReportOnly As Boolean) As Boolean Implements IGDSPnr.ReadPNR

        ReadPNR = False
        If pGDSCode = Config.GDSCode.GDSisAmadeus Then
            ReadPNR = ReadPNR1A(PNR, ForReportOnly)
        ElseIf pGDSCode = Config.GDSCode.GDSisGalileo Then
            ReadPNR = ReadPNR1G(PNR, ForReportOnly)
        Else
            Throw New Exception("Incorrect GDS")
        End If

    End Function
    Private Function ReadPNR1A(ByVal PNR As String, ByVal ForReportOnly As Boolean) As Boolean

        Dim pobjHostSessions As k1aHostToolKit.HostSessions
        ReadPNR1A = False
        Try
            mstrStatus = ""
            pobjHostSessions = New k1aHostToolKit.HostSessions

            If pobjHostSessions.Count > 0 Then
                mobjHostSession = pobjHostSessions.UIActiveSession

                If PNR <> "" Then
                    mobjHostSession.Send("QI")
                    mobjHostSession.Send("IG")
                End If
                mudtProps.RequestedPNR = PNR
                ReadPNR1A = RetrievePNR1A(ForReportOnly)
            Else
                Throw New Exception("Amadeus not signed in")
            End If

            If ReadPNR1A Then
                mintStatus = 0
                mstrStatus = "Amadeus read " & PNR & " OK"
            Else
                mintStatus = 1
                mstrStatus = "Amadeus " & PNR & " not found"
            End If
            mobjHostSession.SendSpecialKey(512 + 282) '(k1aHostConstantsLib.AmaKeyValues.keySHIFT + k1aHostConstantsLib.AmaKeyValues.keyPause)
            mobjHostSession.Send("RT")
            RaiseEvent ReadStatus(mintStatus, mstrStatus)
        Catch ex As Exception
            mintStatus = 999
            mstrStatus = Err.Description
            RaiseEvent ReadStatus(mintStatus, mstrStatus)

            If CancelError Then
                Throw New Exception("ReadPNR()" & vbCrLf & mstrStatus)
            End If
        End Try

    End Function
    Private Function ReadPNR1G(ByVal PNR As String, ByVal ForReportOnly As Boolean) As Boolean
        Try
            Dim Session As New Travelport.TravelData.Factory.GalileoDesktopFactory("SPG720", "MYCONNECTION", False, True, "SMRT")

            If PNR <> "" Then
                Session.SendTerminalCommand("QXI+I")
            End If
            mudtProps.RequestedPNR = PNR
            ReadPNR1G = RetrievePNR1G(ForReportOnly)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Private Function RetrievePNR1A(ByVal ForReportOnly As Boolean) As Boolean

        Dim pintPNRStatus As Integer

        mobjPNR1A = New s1aPNR.PNR
        mobjTickets = New Ticket.TicketColl
        mstrVesselName = ""
        mstrBookedBy = ""
        mstrCC = ""
        mstrCLA = ""
        mstrCLN = ""

        With mudtProps

            If .RequestedPNR = "" Then
                pintPNRStatus = mobjPNR1A.RetrieveCurrent(mobjHostSession)
            Else
                pintPNRStatus = mobjPNR1A.RetrievePNR(mobjHostSession, "RT" & .RequestedPNR)
            End If
            .PNRCreationdate = Today

            If pintPNRStatus = 0 Or pintPNRStatus = 1005 Then
                .RequestedPNR = setRecordLocator1A()
                If ForReportOnly Then
                    GetGroup1A()
                    GetPax1A()
                    GetSegs1A(ForReportOnly)
                    GetOtherServiceElements1A()
                    GetRMElements1A()
                Else
                    GetTQT1A()
                    GetGroup1A()
                    GetPax1A()
                    GetSegs1A(ForReportOnly)
                    GetAutoTickets1A()
                    GetOtherServiceElements1A()
                    GetSSRElements1A()
                    GetRMElements1A()
                End If
                RetrievePNR1A = True
            Else
                RetrievePNR1A = False
            End If
        End With

    End Function
    Private Function RetrievePNR1G(ByVal ForReportOnly As Boolean) As Boolean

        Dim Session As New Travelport.TravelData.Factory.GalileoDesktopFactory("SPG720", "MYCONNECTION", False, True, "SMRT")
        mobjTickets = New Ticket.TicketColl
        mstrVesselName = ""
        mstrBookedBy = ""
        mstrCC = ""
        mstrCLA = ""
        mstrCLN = ""

        With mudtProps

            If .RequestedPNR = "" Then
                Dim pErr As Integer = 1

                Do While pErr < 10
                    Try
                        mobjPNR1G = Session.RetrieveCurrentBookingFile
                        pErr = 99
                    Catch ex As Exception
                        System.Threading.Thread.Sleep(2000)
                        pErr += 1
                    End Try
                Loop
                If pErr < 99 Then
                    Throw New Exception("Galileo communication problem. Please try again or contact your system adminbistrator")
                End If
            Else
                mobjPNR1G = Session.RetrieveBookingFile(.RequestedPNR)
            End If
            If mobjPNR1G.IsEmpty Then
                Throw New Exception("No B.F. to display")
            End If
            .PNRCreationdate = Today

            .RequestedPNR = setRecordLocator1G()
            If ForReportOnly Then
                'GetGroup1G()
                GetPax1G()
                GetSegs1G(ForReportOnly)
                GetOtherServiceElements1G()
                GetRMElements1G()
            Else
                'GetTQT1G()
                'GetGroup1G()
                GetPax1G()
                GetSegs1G(ForReportOnly)
                'GetAutoTickets1G()
                GetOtherServiceElements1G()
                'GetSSRElements1G()
                GetRMElements1G()
            End If
            RetrievePNR1G = True
        End With

    End Function
    Private Function setRecordLocator1A() As String
        Try
            setRecordLocator1A = mobjPNR1A.Header.RecordLocator
        Catch ex As Exception
            setRecordLocator1A = UCase(mudtProps.RequestedPNR)
        End Try
    End Function
    Private Sub GetAutoTickets1A()

        Dim pobjFareAutoTktElement As s1aPNR.FareAutoTktElement
        Dim pobjFareOriginalIssueElement As s1aPNR.FareOriginalIssueElement

        For Each pobjFareOriginalIssueElement In mobjPNR1A.FareOriginalIssueElements
            parseFareOriginal(pobjFareOriginalIssueElement)
        Next pobjFareOriginalIssueElement

        For Each pobjFareAutoTktElement In mobjPNR1A.FareAutoTktElements
            parseFareAutoTktElement(pobjFareAutoTktElement)
        Next pobjFareAutoTktElement

    End Sub

    Private Sub parseFareOriginal(ByVal Element As s1aPNR.FareOriginalIssueElement)

        Dim i As Short
        Dim pflgIATAFound As Boolean
        Dim pstrText As String
        Dim pstrSplit1() As String
        Dim pstrSplit2() As String

        Try

            Dim SegAssociations As String = ""
            Dim PaxAssociations As String = ""

            Dim objSeg As Object
            Dim objPax As Object

            If Element.Associations.Segments.Count > 0 Then
                For Each objSeg In Element.Associations.segments
                    SegAssociations &= mobjSegs(objSeg.ElementNo).BoardPoint & " " & mobjSegs(objSeg.ElementNo).Airline & " " & mobjSegs(objSeg.ElementNo).OffPoint & vbCrLf
                Next
            Else
                For Each pSeg As GDSSeg.GDSSegItem In mobjSegs.Values
                    SegAssociations &= pSeg.BoardPoint & " " & pSeg.Airline & " " & pSeg.OffPoint & vbCrLf
                Next
            End If

            If Element.Associations.Passengers.Count > 0 Then
                For Each objPax In Element.Associations.Passengers
                    PaxAssociations &= mobjPax(objPax.ElementNo).PaxName & vbCrLf
                Next
            Else
                For Each pPax As GDSPax.GDSPaxitem In mobjPax.Values
                    PaxAssociations &= pPax.PaxName & vbCrLf
                Next
            End If

            pstrText = ConcatenateText(Element.Text)

            pstrSplit1 = Split(pstrText, " ")
            pstrSplit2 = Split(pstrText, "/")

            pflgIATAFound = False
            If IsArray(pstrSplit2) Then
                For i = LBound(pstrSplit2) To UBound(pstrSplit2)
                    If InStr(pstrSplit2(i), MySettings.IATANumber) > 0 Then
                        pflgIATAFound = True
                        Exit For
                    End If
                    If pflgIATAFound Then
                        Exit For
                    End If
                Next i
            End If

            If pflgIATAFound Then
                If IsArray(pstrSplit1) Then
                    For i = LBound(pstrSplit1) To UBound(pstrSplit1)
                        If Len(pstrSplit1(i)) >= 13 Then
                            With mobjNumberParser
                                If .TicketNumberText(pstrSplit1(i)) Then
                                    mobjTickets.addTicket("FO", .StockType, .DocumentNumber, .Books, .AirlineNumber, .AirlineNumber, False, SegAssociations, PaxAssociations, pstrSplit2(2))
                                End If
                            End With
                        End If
                    Next i
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    ''' <summary>
    ''' This is the new version which does not check the issuing office of the ticket
    ''' </summary>
    Private Sub parseFareAutoTktElement(ByVal Element As s1aPNR.FareAutoTktElement)

        Dim pstrSplit2() As String
        Dim pflgETicket As Boolean

        Try

            Dim SegAssociations As String = ""
            Dim PaxAssociations As String = ""

            Dim objSeg As Object
            Dim objPax As Object

            If Element.Associations.Segments.Count > 0 Then
                For Each objSeg In Element.Associations.segments
                    SegAssociations &= mobjSegs(objSeg.ElementNo).BoardPoint & " " & mobjSegs(objSeg.ElementNo).Airline & " " & mobjSegs(objSeg.ElementNo).OffPoint & vbCrLf
                Next
            Else
                For Each pSeg As GDSSeg.GDSSegItem In mobjSegs.Values
                    SegAssociations &= pSeg.BoardPoint & " " & pSeg.Airline & " " & pSeg.OffPoint & vbCrLf
                Next
            End If

            If Element.Associations.Passengers.Count > 0 Then
                For Each objPax In Element.Associations.Passengers
                    PaxAssociations &= mobjPax(objPax.ElementNo).PaxName & vbCrLf
                Next
            Else
                For Each pPax As GDSPax.GDSPaxitem In mobjPax.Values
                    PaxAssociations &= pPax.PaxName & vbCrLf
                Next
            End If


            Dim pstrText As String = Element.Text

            Dim pstrSplit1() As String = Split(pstrText, "/")
            pflgETicket = False

            If IsArray(pstrSplit1) Then

                pstrSplit2 = Split(pstrSplit1(0), " ")
                If UBound(pstrSplit1) > 0 Then
                    If Len(pstrSplit1(1)) = 4 And Left(pstrSplit1(1), 2) = "ET" Then
                        pflgETicket = True
                    End If
                End If
                If IsArray(pstrSplit2) Then
                    If UBound(pstrSplit2) >= 3 Then
                        With mobjNumberParser
                            If .TicketNumberText(pstrSplit2(3)) Then
                                mobjTickets.addTicket("FA", .StockType, .DocumentNumber, .Books, .AirlineNumber, pstrSplit1(1).Substring(2, 2), pflgETicket, SegAssociations, PaxAssociations, pstrSplit2(2))
                            End If
                        End With
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub GetGroup1A()

        mstrGroupName = ""
        mintGroupNamesCount = 0

        For Each pGroup As s1aPNR.GroupNameElement In mobjPNR1A.GroupNameElements
            mstrGroupName = pGroup.GroupName
            mintGroupNamesCount = pGroup.NbrOfAssignedNames + pGroup.NbrNamesMissing
            Exit For
        Next
        If mobjPNR1A.GroupNameElements.Count > 1 Then
            mstrGroupName &= "x" & mobjPNR1A.GroupNameElements.Count
        End If

    End Sub
    Private Sub GetPax1A()

        Dim i As Short
        Dim j As Short
        Dim pstrID As String
        Dim pobjPax As s1aPNR.NameElement

        mobjPax.Clear()

        For Each pobjPax In mobjPNR1A.NameElements
            With pobjPax
                '                i = InStr(.Text, "(ID")
                i = InStr(.Text, "(")
                If i > 0 Then
                    j = InStrRev(.Text, ")")
                    If j = 0 Then
                        j = Len(.Text) + 1
                    End If
                    pstrID = .Text.Substring(i - 1, j - i + 1) ' Mid(.Text, i + 3, j - (i + 3))
                Else
                    pstrID = ""
                End If
                mobjPax.AddItem(.ElementNo, .Initial, .LastName, pstrID)
            End With
        Next pobjPax

    End Sub

    Private Sub GetSegs1A(ByVal ForReportOnly As Boolean)

        Dim pobjSeg As Object

        mobjSegs.Clear()
        mSegsLastElement = -1
        mSegsFirstElement = -1

        For Each pobjSeg In mobjPNR1A.AllAirSegments
            Dim pElementNo As Short = airElementNo1A(pobjSeg)
            If ForReportOnly Then
                mobjSegs.AddItem(airAirline1A(pobjSeg), airBoardPoint1A(pobjSeg), airClass1A(pobjSeg), airDepartureDate1A(pobjSeg), airArrivalDate1A(pobjSeg), pElementNo, airFlightNo1A(pobjSeg), airOffPoint1A(pobjSeg), airStatus1A(pobjSeg), airDepartTime1A(pobjSeg), airArriveTime1A(pobjSeg), airText1A(pobjSeg), "")
            Else
                Dim pSegDo As k1aHostToolKit.CHostResponse = mobjHostSession.Send("DO" & pobjSeg.ElementNo)
                mobjSegs.AddItem(airAirline1A(pobjSeg), airBoardPoint1A(pobjSeg), airClass1A(pobjSeg), airDepartureDate1A(pobjSeg), airArrivalDate1A(pobjSeg), pElementNo, airFlightNo1A(pobjSeg), airOffPoint1A(pobjSeg), airStatus1A(pobjSeg), airDepartTime1A(pobjSeg), airArriveTime1A(pobjSeg), airText1A(pobjSeg), pSegDo.Text)
            End If
            If mSegsFirstElement = -1 Then
                mSegsFirstElement = pElementNo
            End If
            If pElementNo > mSegsLastElement Then
                mSegsLastElement = pElementNo
            End If
        Next pobjSeg

    End Sub
    Private Function airStatus1A(ByRef pSegment As Object) As String

        Try
            airStatus1A = pSegment.text.substring(27, 2)
        Catch ex As Exception
            airStatus1A = ""
        End Try

    End Function

    Private Function airAirline1A(ByRef pSegment As Object) As String

        Try
            airAirline1A = pSegment.Airline
        Catch ex As Exception
            airAirline1A = ""
        End Try

    End Function

    Private Function airBoardPoint1A(ByRef pSegment As Object) As String

        Try
            airBoardPoint1A = pSegment.BoardPoint
        Catch ex As Exception
            airBoardPoint1A = ""
        End Try

    End Function

    Private Function airClass1A(ByRef pSegment As Object) As String

        Try
            airClass1A = pSegment.Class
        Catch ex As Exception
            airClass1A = ""
        End Try

    End Function

    Private Function airDepartureDate1A(ByRef pSegment As Object) As Date

        Dim pdteDate As Date

        Try
            pdteDate = pSegment.DepartureDate
            Do While pdteDate > DateAdd(Microsoft.VisualBasic.DateInterval.Year, 1, mudtProps.PNRCreationdate) Or pdteDate < System.DateTime.FromOADate(2)
                pdteDate = DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, pdteDate)
            Loop
            If pdteDate < System.DateTime.FromOADate(2) Then
                pdteDate = System.DateTime.FromOADate(0)
            End If

            airDepartureDate1A = pdteDate
        Catch ex As Exception
            airDepartureDate1A = System.DateTime.FromOADate(0)
        End Try

    End Function

    Private Function airArrivalDate1A(ByRef pSegment As Object) As Date

        Dim pdteDate As Date

        Try
            pdteDate = pSegment.ArrivalDate
            Do While pdteDate > DateAdd(Microsoft.VisualBasic.DateInterval.Year, 1, mudtProps.PNRCreationdate) Or pdteDate < System.DateTime.FromOADate(2)
                pdteDate = DateAdd(Microsoft.VisualBasic.DateInterval.Year, -1, pdteDate)
            Loop
            If pdteDate < System.DateTime.FromOADate(2) Then
                pdteDate = System.DateTime.FromOADate(0)
            End If

            airArrivalDate1A = pdteDate
        Catch ex As Exception
            airArrivalDate1A = System.DateTime.FromOADate(0)
        End Try

    End Function
    Private Function airElementNo1A(ByRef pSegment As Object) As Short

        Try
            airElementNo1A = pSegment.ElementNo
        Catch ex As Exception
            airElementNo1A = CShort("")
        End Try

    End Function

    Private Function airFlightNo1A(ByRef pSegment As Object) As String

        Try
            airFlightNo1A = pSegment.FlightNo
        Catch ex As Exception
            airFlightNo1A = ""
        End Try

    End Function

    Private Function airOffPoint1A(ByRef pSegment As Object) As String

        Try
            airOffPoint1A = pSegment.OffPoint
        Catch ex As Exception
            airOffPoint1A = ""
        End Try

    End Function
    Private Function airDepartTime1A(ByRef pSegment As Object) As Date

        Try
            airDepartTime1A = pSegment.DepartureTime
        Catch ex As Exception
            airDepartTime1A = System.DateTime.FromOADate(0)
        End Try

    End Function

    Private Function airArriveTime1A(ByRef pSegment As Object) As Date

        Try
            airArriveTime1A = pSegment.ArrivalTime
        Catch ex As Exception
            airArriveTime1A = System.DateTime.FromOADate(0)
        End Try

    End Function

    Private Function airText1A(ByRef pSegment As Object) As String

        Try
            airText1A = pSegment.Text
        Catch ex As Exception
            airText1A = ""
        End Try

    End Function

    Private Sub GetOtherServiceElements1A()

        Dim pobjOtherServiceElement As s1aPNR.OtherServiceElement

        For Each pobjOtherServiceElement In mobjPNR1A.OtherServiceElements
            parseOtherServiceElements1A(pobjOtherServiceElement)
        Next pobjOtherServiceElement

    End Sub

    Private Sub parseOtherServiceElements1A(ByVal Element As s1aPNR.OtherServiceElement)

        Dim i As Short
        Dim j As Short

        Dim pintLen As Short
        Dim pstrText As String
        Dim pstrSplit() As String

        pstrText = ConcatenateText(Element.Text)
        pintLen = Len(pstrText)

        i = InStr(pstrText, "/SG")
        j = InStr(pstrText, "/P")
        If i > 0 And i - 1 < pintLen Then
            pintLen = i - 1
        End If
        If j > 0 And j - 1 < pintLen Then
            pintLen = j - 1
        End If

        pstrSplit = Split(Left(pstrText, pintLen), " ")

        If IsArray(pstrSplit) Then
            For i = LBound(pstrSplit) To UBound(pstrSplit)
                If pstrSplit(i) = "MV" Then
                    mstrVesselName = ""
                    For j = i + 1 To UBound(pstrSplit)
                        mstrVesselName = mstrVesselName & " " & Trim(pstrSplit(j))
                    Next j
                    Exit For
                ElseIf Left(pstrSplit(i), 11) = "SEMN/VESSEL" Then
                    mstrVesselName = Mid(pstrSplit(i), 13)
                    For j = i + 1 To UBound(pstrSplit)
                        If pstrSplit(j) <> "-" Then
                            mstrVesselName = mstrVesselName & " " & Trim(pstrSplit(j))
                        End If
                    Next j
                    Exit For
                End If
            Next i
        End If

    End Sub

    Private Sub GetSSRElements1A()

        Dim pobjSSR As s1aPNR.SSRfqtvElement

        For Each pobjSSR In mobjPNR1A.SSRfqtvElements

            If pobjSSR.Associations.Passengers.Count > 0 Then
                For Each objPax In pobjSSR.Associations.Passengers
                    mobjFrequentFlyer.AddItem(mobjPax(objPax.ElementNo).PaxName, pobjSSR.Airline, pobjSSR.FrequentTravelerNo)
                Next
            Else
                For Each pPax As GDSPax.GDSPaxitem In mobjPax.Values
                    mobjFrequentFlyer.AddItem(pPax.PaxName, pobjSSR.Airline, pobjSSR.FrequentTravelerNo)
                Next
            End If

        Next

        Dim pTQTtext As k1aHostToolKit.CHostResponse = mobjHostSession.Send("RTSTR")
        If pTQTtext.Text.IndexOf("NO SEATS") = 0 Then
            mudtProps.Seats = ""
        Else
            Dim pTemp() As String = pTQTtext.Text.Split({vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
            Dim pTemp2 As String = ""
            If IsArray(pTemp) Then

                pTemp2 = pTemp(0)
                For i As Integer = 1 To pTemp.GetUpperBound(0)
                    If pTemp(i).Length > 10 Then
                        If pTemp2.Length > 0 Then
                            pTemp2 &= vbCrLf
                        End If
                        If pTemp(i).StartsWith(" ") Then
                            pTemp2 &= pTemp(i).Substring(0, 10) & " " & pTemp(i).Substring(13)
                        Else
                            pTemp2 &= pTemp(i)
                        End If

                    End If
                Next
            End If
            mudtProps.Seats = pTemp2
        End If

    End Sub

    Private Sub GetRMElements1A()

        Dim pobjRMElement As s1aPNR.RemarkElement

        For Each pobjRMElement In mobjPNR1A.RemarkElements
            parseRMElements1A(pobjRMElement)
        Next pobjRMElement

    End Sub
    Private Sub parseRMElements1A(ByVal Element As s1aPNR.RemarkElement)

        Dim pintLen As Short
        Dim pstrText As String
        Dim pstrSplit() As String

        pstrText = ConcatenateText(Element.Text)
        pintLen = Len(pstrText)
        pstrSplit = Split(Left(pstrText, pintLen), "/")
        ' TODO - make necessary changes for Cyprus Discovery remarks
        If IsArray(pstrSplit) AndAlso pstrSplit.Length >= 2 Then
            If pstrSplit(1) = "CC" Then
                mstrCC = pstrSplit(2)
            ElseIf pstrSplit(1) = "CLN" Then
                mstrCLN = pstrSplit(2)
            ElseIf pstrSplit(1) = "CLA" Then
                mstrCLA = pstrSplit(2)
            ElseIf pstrSplit(1) = "BBY" Then
                mstrBookedBy = pstrSplit(2)
            End If
        End If
        pstrSplit = Split(Left(pstrText, pintLen), "-")
        If IsArray(pstrSplit) AndAlso pstrSplit.Length >= 2 Then
            If pstrSplit(0).IndexOf("D,BOOKED") > 0 Then
                mstrBookedBy = pstrSplit(1)
            ElseIf pstrSplit(0).IndexOf("D,AC") > 0 Then
                mstrCLN = pstrSplit(1)
            End If
        End If


    End Sub
    Private Sub GetTQT1A()

        Dim pTQTtext As k1aHostToolKit.CHostResponse = mobjHostSession.Send("TQT")
        Dim pTQT() As String = pTQTtext.Text.Split(vbCrLf)

        ReDim mudtAllowance(0)
        ReDim mudtTQT(0)

        If pTQT(0).StartsWith("T     P/S  NAME") Then
            For i As Integer = 1 To pTQT.GetUpperBound(0)
                If pTQT(i).Length > 62 AndAlso pTQT(i).Substring(1) <> " " Then
                    ReDim Preserve mudtTQT(mudtTQT.GetUpperBound(0) + 1)
                    If pTQT(i).Substring(1, pTQT(i).IndexOf(" ")) <> pTQT(i - 1).Substring(1, pTQT(i).IndexOf(" ")) AndAlso IsNumeric(pTQT(i).Substring(1, pTQT(i).IndexOf(" "))) Then
                        mudtTQT(mudtTQT.GetUpperBound(0)).TQTElement = pTQT(i).Substring(1, pTQT(i).IndexOf(" "))
                        Dim pSeg() As String
                        If i < pTQT.GetUpperBound(0) AndAlso pTQT(i + 1).Length > 2 AndAlso pTQT(i + 1).Substring(1, 1) = " " Then
                            pTQT(i) &= pTQT(i + 1).Trim
                            pSeg = pTQT(i).Substring(pTQT(i).LastIndexOf(" ")).Trim.Split(",")
                        Else
                            pSeg = pTQT(i).Substring(pTQT(i).LastIndexOf(" ")).Trim.Split(",")
                        End If
                        For i1 As Integer = 0 To pSeg.GetUpperBound(0)
                            Dim pSeg1() As String = pSeg(i1).Split("-")
                            If IsNumeric(pSeg1(0)) Then
                                mudtTQT(mudtTQT.GetUpperBound(0)).Segment = CInt(pSeg1(0))
                                If pSeg1.GetUpperBound(0) = 1 Then
                                    For i2 As Integer = CInt(pSeg1(0)) + 1 To CInt(pSeg1(1))
                                        ReDim Preserve mudtTQT(mudtTQT.GetUpperBound(0) + 1)
                                        mudtTQT(mudtTQT.GetUpperBound(0)).TQTElement = mudtTQT(mudtTQT.GetUpperBound(0) - 1).TQTElement
                                        mudtTQT(mudtTQT.GetUpperBound(0)).Segment = i2
                                    Next
                                Else

                                End If
                            End If

                        Next
                    End If

                    Dim pTSTText As k1aHostToolKit.CHostResponse = mobjHostSession.Send("TQT/T" & pTQT(i).Substring(1, pTQT(i).IndexOf(" ")))
                    Dim pTST() As String = pTSTText.Text.Split(vbCrLf)

                    SplitTQT1A(pTST)

                End If
            Next
        ElseIf pTQT(0).StartsWith("TST") Then
            SplitTQT1A(pTQT)
        End If

    End Sub

    Private Sub SplitTQT1A(ByVal pTQT() As String)

        Dim iSeg As Integer = 0
        For i As Integer = 0 To pTQT.GetUpperBound(0)
            If pTQT(i).Length > 4 AndAlso pTQT(i).Substring(5, 1) = "." Then
                iSeg = i + 1
            ElseIf iSeg > 0 Then
                Exit For
            End If
        Next
        If iSeg > 0 Then
            For i As Integer = iSeg To pTQT.GetUpperBound(0)
                If IsNumeric(pTQT(i).Substring(2, 1)) Then
                    If pTQT(i).Length > 60 Then
                        ReDim Preserve mudtAllowance(mudtAllowance.GetUpperBound(0) + 1)
                        mudtAllowance(mudtAllowance.GetUpperBound(0)).Itin = pTQT(i).Substring(6, 6) & " " & pTQT(i + 1).Substring(6, 3)
                        mudtAllowance(mudtAllowance.GetUpperBound(0)).Allowance = pTQT(i).Substring(61)
                        mudtAllowance(mudtAllowance.GetUpperBound(0)).Status = pTQT(i).Substring(31, 3)
                    End If
                Else
                    Exit For
                End If
            Next
        End If

    End Sub
    Private Function ConcatenateText(ByVal Text As String) As String

        Dim i As Short
        Dim j As Short
        Dim pintLen As Short
        Dim pstrTemp As String

        Try
            j = -1
            pintLen = Len(Text)
            For i = 1 To Len(Text)
                pstrTemp = Mid(Text, i, 1)
                If pstrTemp <> " " And (pstrTemp < "0" Or pstrTemp > "9") Then
                    j = i
                    Exit For
                End If
            Next i

            If j = -1 Then
                ConcatenateText = Text
            Else
                pstrTemp = Mid(Text, j, 60)
                j = j + 60
                Do While j <= pintLen
                    If Mid(Text, j, Math.Min(23, pintLen - j + 1)) & " " = " " & Mid(Text, j, Math.Min(23, pintLen - j + 1)) Then
                        j = j + 23
                        If j <= pintLen Then
                            pstrTemp = pstrTemp & Mid(Text, j, 57)
                            j = j + 57
                        End If
                    End If
                Loop
                ConcatenateText = pstrTemp
            End If
        Catch ex As Exception
            ConcatenateText = Text
        End Try

    End Function
    Private Sub GetPax1G()

        Dim pobjPax As Travelport.TravelData.Person

        mobjPax.Clear()

        For Each pobjPax In mobjPNR1G.Passengers
            With pobjPax
                mobjPax.AddItem(.PassengerNumber, .FirstName, .LastName, If(IsNothing(.NameRemark), "", .NameRemark))
            End With
        Next pobjPax

    End Sub
    Private Sub GetSegs1G(ByVal ForReportOnly As Boolean)

        Dim pobjSeg As Travelport.TravelData.AirSegment

        mobjSegs.Clear()
        mSegsLastElement = -1
        mSegsFirstElement = -1

        For Each pobjSeg In mobjPNR1G.AirSegments
            With pobjSeg
                Dim pElementNo As Short = .SegmentNumber
                If ForReportOnly Then
                    mobjSegs.AddItem(.Carrier.Code, .Origin.Code, .ClassOfService, .StartDateTime, .EndDateTime, .SegmentNumber, .FlightNumber, .Destination.Code, .FlightStatus, .StartDateTime, .EndDateTime, .ToString, "")
                Else
                    '                    Dim pSegDo As k1aHostToolKit.CHostResponse = mobjHostSession.Send("DO" & pobjSeg.ElementNo)
                    mobjSegs.AddItem(.Carrier.Code, .Origin.Code, If(IsNothing(.ClassOfService), "", .ClassOfService), .StartDateTime, .EndDateTime, .SegmentNumber, .FlightNumber, .Destination.Code, .RequestStatus, .StartDateTime, .EndDateTime, .ToString, "")
                End If
                If mSegsFirstElement = -1 Then
                    mSegsFirstElement = pElementNo
                End If
                If pElementNo > mSegsLastElement Then
                    mSegsLastElement = pElementNo
                End If
            End With
        Next pobjSeg

    End Sub
    Private Sub GetOtherServiceElements1G()
        Dim pobjOtherServiceElement As Travelport.TravelData.BookingFileOtherSupplementaryInformation

        For Each pobjOtherServiceElement In mobjPNR1G.OtherSupplementaryInformationRemarks
            With pobjOtherServiceElement
                '"SEMN/VESSEL-CHRISTOS"
                If (.Message.StartsWith("SEMN/VESSEL-")) Then
                    mstrVesselName = .Message.Substring(12).Trim
                End If
            End With
        Next pobjOtherServiceElement
    End Sub
    Private Sub GetRMElements1G()

        Dim pobjRMElement As Travelport.TravelData.BookingFileRemark
        For Each pobjRMElement In mobjPNR1G.InvoiceRemarks
            With pobjRMElement
                ' TODO - make necessary changes for Cyprus Discovery remarks
                If .Text.StartsWith("GRACE/CC/") Then
                    mstrCC = .Text.Substring(9)
                ElseIf .Text.StartsWith("GRACE/CLN/") Then
                    mstrCLN = .Text.Substring(10)
                ElseIf .Text.StartsWith("GRACE/CLA/") Then
                    mstrCLA = .Text.Substring(10)
                ElseIf .Text.StartsWith("GRACE/BBY/") Then
                    mstrBookedBy = .Text.Substring(10)
                End If
                If .Text.StartsWith("D,BOOKED") > 0 Then
                    mstrBookedBy = .Text.Substring(8)
                ElseIf .Text.StartsWith("D,AC") > 0 Then
                    mstrCLN = .Text.Substring(4)
                End If
            End With
        Next pobjRMElement

    End Sub
    Private Function setRecordLocator1G() As String
        Try
            setRecordLocator1G = mobjPNR1G.RecordLocator
        Catch ex As Exception
            setRecordLocator1G = UCase(mudtProps.RequestedPNR)
        End Try
    End Function
End Class