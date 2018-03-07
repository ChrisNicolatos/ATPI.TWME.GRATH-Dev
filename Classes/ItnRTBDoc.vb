Imports Telerik.WinControls.UI
Friend Class ItnRTBDoc
    Private mobjPNR As GDSPnr
    Private mintMaxString As Integer
    Private mstrRemarks As String
    Private mintHeaderLength As Integer = 0
    Public Sub New(ByRef pPNR As GDSPnr, ByVal pMaxString As Integer, ByRef pItnRemarks As RadCheckedListBox)
        mobjPNR = pPNR
        mintMaxString = pMaxString
        mstrRemarks = ""
        For iRem As Integer = 0 To pItnRemarks.CheckedItems.Count - 1
            mstrRemarks &= pItnRemarks.CheckedItems(iRem).ToString & vbCrLf
        Next

    End Sub
    Public ReadOnly Property RTBDocPassengers As String
        Get
            Dim pString As New System.Text.StringBuilder
            With mobjPNR
                If .Passengers.Count > 0 Then
                    If MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatSeaChefs Or MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode Then
                        pString.AppendLine("FOR PASSENGER" & If(.Passengers.Count > 1, "(S)", ""))
                    End If
                    For Each pobjPax In .Passengers.Values
                        If MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatSeaChefs Or MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode Then
                            pString.AppendLine(pobjPax.PaxName)
                        Else
                            pString.AppendLine(pobjPax.ElementNo & " " & pobjPax.PaxName & " " & pobjPax.PaxID)
                        End If
                    Next pobjPax
                ElseIf .IsGroup Then
                    pString.AppendLine("GROUP: " & .GroupName & " " & .GroupNamesCount)
                Else
                    pString.AppendLine("PASSENGER INFORMATION NOT AVAILABLE")
                End If
                RTBDocPassengers = pString.ToString
            End With
        End Get
    End Property
    Public ReadOnly Property makeRTBDoc() As String
        Get
            Dim pString As New System.Text.StringBuilder

            pString.Clear()
            mintMaxString = 80

            Try
                'TODO - Fix length of output line total 78 characters including spaces
                pString.Append(MakeRTBDocPart1)
                pString.Append(MakeRTBDocTickets)
                If Not (MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatSeaChefs Or MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode) And mintMaxString > 0 Then
                    pString.AppendLine(StrDup(mintHeaderLength, "-"))
                End If
                pString.AppendLine()
                pString.Append(mstrRemarks)
                pString.Append(MakeRTBDocCloseOff)
            Catch ex As Exception
                Throw New Exception("makeRTBDoc()" & vbCrLf & ex.Message)
            End Try
            makeRTBDoc = pString.ToString
        End Get
    End Property
    Public ReadOnly Property MakeRTBMSReport() As String
        Get
            Try
                Dim pString As New System.Text.StringBuilder
                With mobjPNR
                    If .HasSegments Then
                        Dim pDepTime As String = ""
                        Dim pArrTime As String = ""
                        For Each pobjPax In .Passengers.Values
                            If .LastSegment.Text.Substring(35, 4) = "FLWN" Then
                                pDepTime = "FLOWN"
                                pArrTime = "FLOWN"
                            Else
                                pDepTime = Format(.LastSegment.DepartTime, "HH:mm")
                                pArrTime = Format(.LastSegment.ArriveTime, "HH:mm")
                            End If
                            pString.AppendLine(pobjPax.LastName & vbTab & pobjPax.Initial & vbTab & pobjPax.IdNo & vbTab & pobjPax.Department & vbTab & .VesselName &
                                               vbTab & .LastSegment.DepartureDateIATA & vbTab & .LastSegment.Airline & vbTab & .LastSegment.FlightNo & vbTab & pDepTime &
                                               vbTab & .LastSegment.BoardPoint & vbTab & pArrTime & vbTab & .LastSegment.OffPoint & vbTab & .RequestedPNR & vbTab & pobjPax.ElementNo)
                        Next pobjPax
                        Return pString.ToString
                    Else
                        Return ""
                    End If
                End With
                MakeRTBMSReport = pString.ToString
            Catch ex As Exception
                Throw New Exception("MakeRTBMSReport()" & vbCrLf & ex.Message)
            End Try
        End Get
    End Property
    Private ReadOnly Property MakeRTBDocPart1 As String
        Get
            Try
                Dim pString As New System.Text.StringBuilder
                Dim pAirlineLocator As String = ""
                Dim pobjSeg As GDSSeg.GDSSegItem
                pString.Clear()
                With mobjPNR

                    pString.Clear()
                    Dim pTemp As String = ""
                    If Not (MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatSeaChefs Or MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode) And MySettings.Vessel And .VesselName <> "" Then
                        pTemp &= "VESSEL     : " & .VesselName
                    End If
                    If Not (MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatSeaChefs Or MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode) And MySettings.CostCentre And .CostCentre <> "" Then
                        If pTemp <> "" Then
                            pTemp &= vbCrLf
                        End If
                        pTemp &= "COST CENTRE: " & .CostCentre
                    End If
                    If pTemp <> "" Then
                        pString.AppendLine(" ")
                        pString.AppendLine(pTemp)
                        pString.AppendLine(" ")
                    End If
                    Dim pHeader As New System.Text.StringBuilder

                    If MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatDefault Then
                        pHeader.Append("Flight ")
                        If MySettings.ClassOfService Then
                            pHeader.Append("C ")
                        End If
                        pHeader.Append("Date  ")
                        Select Case MySettings.AirportName
                            Case 0
                                pHeader.Append("Org Dest")
                            Case 1
                                pHeader.Append("Origin " & StrDup(.MaxAirportNameLength - 5, " ") & "Destination" & StrDup(.MaxAirportNameLength - 9, " "))
                            Case 2
                                pHeader.Append("Origin " & StrDup(.MaxAirportNameLength - 1, " ") & "Destination" & StrDup(.MaxAirportNameLength - 5, " "))
                            Case 3
                                pHeader.Append("Origin " & StrDup(.MaxCityNameLength - 5, " ") & "Destination" & StrDup(.MaxCityNameLength - 9, " "))
                            Case 4
                                pHeader.Append("Origin " & StrDup(.MaxCityNameLength - 1, " ") & "Destination" & StrDup(.MaxCityNameLength - 5, " "))
                        End Select
                        pHeader.Append("Dep   ")
                        pHeader.Append("Arr   ")
                        If MySettings.FlyingTime Then
                            pHeader.Append(" EFT  ")
                        End If
                        pHeader.Append("ArrDte ")
                        pHeader.Append(If(MySettings.AirlineLocator, "AL Locator", ""))
                        pHeader.Append(" - BagAl")

                        mintHeaderLength = pHeader.Length

                        pString.AppendLine(StrDup(mintHeaderLength, "-"))
                        pString.AppendLine(pHeader.ToString)
                        pString.AppendLine(StrDup(mintHeaderLength, "-"))
                    ElseIf MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatSeaChefs Or MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode Then
                        pHeader.Append("Flight ")
                        pHeader.Append("Date  ")
                        If MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode Then
                            pHeader.Append("Org    " & StrDup(.MaxAirportShortNameLength - 1, " ") & "Dest       " & StrDup(.MaxAirportShortNameLength - 5, " "))
                        Else
                            pHeader.Append("Org    " & StrDup(.MaxAirportShortNameLength - 5, " ") & "Dest       " & StrDup(.MaxAirportShortNameLength - 9, " "))
                        End If
                        pHeader.Append("Dep   ")
                        pHeader.Append("Arr   ")
                        pHeader.Append("Term   ")
                        pHeader.Append("Status")
                        pHeader.Append("   BagAl")
                        mintHeaderLength = pHeader.Length

                        pString.AppendLine(StrDup(mintHeaderLength, "-"))
                        pString.AppendLine(pHeader.ToString)
                        pString.AppendLine(StrDup(mintHeaderLength, "-"))
                    End If

                    Dim iSegCount As Integer = 0
                    For Each pobjSeg In .Segments.Values
                        iSegCount = iSegCount + 1
                        Dim pSeg As New System.Text.StringBuilder

                        If MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatSeaChefs Or MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode Then
                            pSeg.Append(pobjSeg.Airline & pobjSeg.FlightNo.PadLeft(4) & " ")
                            pSeg.Append(pobjSeg.DepartureDateIATA & " ")
                            If MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode Then
                                pSeg.Append(pobjSeg.BoardPoint & " " & pobjSeg.BoardAirportShortName.PadRight(.MaxAirportShortNameLength + 1, " ").Substring(0, .MaxAirportShortNameLength + 1) & " ")
                                pSeg.Append(pobjSeg.OffPoint & " " & pobjSeg.OffPointAirportShortName.PadRight(.MaxAirportShortNameLength + 1, " ").Substring(0, .MaxAirportShortNameLength + 1) & " ")
                            Else
                                pSeg.Append(pobjSeg.BoardAirportShortName.PadRight(.MaxAirportShortNameLength + 1, " ").Substring(0, .MaxAirportShortNameLength + 1) & " ")
                                pSeg.Append(pobjSeg.OffPointAirportShortName.PadRight(.MaxAirportShortNameLength + 1, " ").Substring(0, .MaxAirportShortNameLength + 1) & " ")
                            End If
                            If pobjSeg.Text.Length > 35 AndAlso pobjSeg.Text.Substring(35, 4) = "FLWN" Then
                                pSeg.Append("FLWN")
                            Else
                                pSeg.Append(Format(pobjSeg.DepartTime, "HHmm") & "  ")
                                pSeg.Append(Format(pobjSeg.ArriveTime, "HHmm"))
                                If DateDiff(DateInterval.Day, pobjSeg.DepartureDate, pobjSeg.ArrivalDate) > 0 Then
                                    pSeg.Append("+1 ")
                                ElseIf DateDiff(DateInterval.Day, pobjSeg.DepartureDate, pobjSeg.ArrivalDate) < 0 Then
                                    pSeg.Append("-1 ")
                                Else
                                    pSeg.Append("   ")
                                End If
                                If pobjSeg.DepartTerminal <> "" Then
                                    If pobjSeg.DepartTerminal.LastIndexOf(" ") > -1 Then
                                        pSeg.Append(pobjSeg.DepartTerminal.Substring(pobjSeg.DepartTerminal.LastIndexOf(" ")).PadLeft(3))
                                    Else
                                        pSeg.Append("   ")
                                    End If
                                Else
                                    pSeg.Append("   ")
                                End If

                                If pobjSeg.Status = "HL" Then
                                    pSeg.Append("      HL")
                                Else
                                    pSeg.Append("      OK")
                                End If
                                pSeg.Append("    " & mobjPNR.AllowanceForSegment(pobjSeg.BoardPoint, pobjSeg.OffPoint, pobjSeg.Airline)) ', ""))
                                If pAirlineLocator.IndexOf(pobjSeg.AirlineLocator.Trim) = -1 Then
                                    If pAirlineLocator <> "" Then
                                        pAirlineLocator &= " - "
                                    End If
                                    pAirlineLocator &= pobjSeg.AirlineLocator.Trim
                                End If
                            End If
                        Else
                            pSeg.Append(pobjSeg.Airline & pobjSeg.FlightNo.PadLeft(4) & " ")
                            If MySettings.ClassOfService Then
                                pSeg.Append(pobjSeg.ClassOfService & " ")
                            End If
                            pSeg.Append(pobjSeg.DepartureDateIATA & " ")
                            Select Case MySettings.AirportName
                                Case 0 'code
                                    pSeg.Append(pobjSeg.BoardPoint & " " & pobjSeg.OffPoint & " ")
                                Case 1 'airport name
                                    pSeg.Append(pobjSeg.BoardAirportName.PadRight(.MaxAirportNameLength + 1, " ").Substring(0, .MaxAirportNameLength + 1) & " " &
                                                pobjSeg.OffPointAirportName.PadRight(.MaxAirportNameLength + 1, " ").Substring(0, .MaxAirportNameLength + 1) & " ")
                                Case 2 'code and airport
                                    pSeg.Append(pobjSeg.BoardPoint & " " & pobjSeg.BoardAirportName.PadRight(.MaxAirportNameLength + 1, " ").Substring(0, .MaxAirportNameLength + 1) & " " &
                                                pobjSeg.OffPoint & " " & pobjSeg.OffPointAirportName.PadRight(.MaxAirportNameLength + 1, " ").Substring(0, .MaxAirportNameLength + 1) & " ")
                                Case 3 'city name
                                    pSeg.Append(pobjSeg.BoardCityName.PadRight(.MaxCityNameLength + 1, " ").Substring(0, .MaxCityNameLength + 1) & " " &
                                                pobjSeg.OffPointCityName.PadRight(.MaxCityNameLength + 1, " ").Substring(0, .MaxCityNameLength + 1) & " ")
                                Case 4 'code and city
                                    pSeg.Append(pobjSeg.BoardPoint & " " & pobjSeg.BoardCityName.PadRight(.MaxCityNameLength + 1, " ").Substring(0, .MaxCityNameLength + 1) & " " &
                                                pobjSeg.OffPoint & " " & pobjSeg.OffPointCityName.PadRight(.MaxCityNameLength + 1, " ").Substring(0, .MaxCityNameLength + 1) & " ")
                            End Select
                            If pobjSeg.Text.Length > 35 AndAlso pobjSeg.Text.Substring(35, 4) = "FLWN" Then
                                pSeg.Append("FLWN")
                            Else
                                'pSeg.Append(pobjSeg.Status.PadRight(3))
                                pSeg.Append(Format(pobjSeg.DepartTime, "HHmm") & "  ")
                                pSeg.Append(Format(pobjSeg.ArriveTime, "HHmm") & "  ")
                                If MySettings.FlyingTime Then
                                    pSeg.Append(pobjSeg.EstimatedFlyingTime & " ")
                                End If
                                pSeg.Append(pobjSeg.ArrivalDateIATA & "   ")
                                pSeg.Append(If(MySettings.AirlineLocator, pobjSeg.AirlineLocator.PadRight(9, " "), ""))
                                pSeg.Append(" - " & mobjPNR.AllowanceForSegment(pobjSeg.BoardPoint, pobjSeg.OffPoint, pobjSeg.Airline)) ', ""))
                                If pobjSeg.Status = "HL" Then
                                    pSeg.Append("   WAITLISTED")
                                End If
                                If MySettings.ShowTerminal And pobjSeg.DepartTerminal <> "" Then
                                    pSeg.Append("   " & pobjSeg.DepartTerminal)
                                End If
                            End If
                        End If

                        pString.AppendLine(pSeg.ToString)

                        If Not MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatPlain Then
                            If pobjSeg.OperatedBy <> "" Then
                                pString.AppendLine(StrDup(13, " ") & pobjSeg.OperatedBy)
                            End If
                            If (MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatSeaChefs Or MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode Or MySettings.ShowStopovers) And pobjSeg.Stopovers <> "" Then
                                pString.AppendLine("             *INTERMEDIATE STOP*  " & pobjSeg.Stopovers)
                            End If
                        End If

                        If pSeg.ToString.Length > mintMaxString Then
                            mintMaxString = pSeg.ToString.Length
                        End If
                    Next pobjSeg

                    If iSegCount = 0 Then
                        pString.AppendLine("ROUTING INFORMATION NOT AVAILABLE")
                    End If

                    If .RequestedPNR <> "" Then
                        pString.AppendLine(" ")
                        If MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatSeaChefs Or MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode Then
                            pString.AppendLine("ATPI REF: " & .RequestedPNR)
                            If pAirlineLocator <> "" Then
                                pString.AppendLine("AIRLINE REF: " & pAirlineLocator)
                            End If
                        Else
                            pString.AppendLine("ATPI Booking Reference: " & .RequestedPNR)
                        End If
                    End If

                End With

                Return pString.ToString
            Catch ex As Exception
                Throw New Exception("MakeRTBDocPart1()" & vbCrLf & ex.Message)
            End Try
        End Get
    End Property
    Private ReadOnly Property MakeRTBDocTickets As String
        Get
            Try
                Dim pString As New System.Text.StringBuilder
                pString.Clear()
                With mobjPNR
                    If (MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatSeaChefs Or MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode Or MySettings.Tickets) And .Tickets.Count >= 1 Then
                        If MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatDefault Then
                            pString.AppendLine(StrDup(mintHeaderLength, "-"))
                        ElseIf MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatPlain Then
                            pString.AppendLine()
                        End If
                        If Not (MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatSeaChefs Or MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode) Then
                            Dim pHeader As String = "Ticket Number   "
                            If MySettings.PaxSegPerTkt Then
                                pHeader &= "Routing      Passenger"
                            End If
                            pString.AppendLine(pHeader)
                            If Not MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatPlain Then
                                pString.AppendLine(StrDup(mintHeaderLength, "-"))
                            End If
                        End If

                        If MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatSeaChefs Or MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode Then
                            For Each pobjPax In .Passengers.Values
                                pString.AppendLine()
                                pString.AppendLine(pobjPax.PaxName)
                                For Each tkt As Ticket.TicketItem In .Tickets.Values
                                    If tkt.Pax.Trim = pobjPax.PaxName.Trim Then
                                        Dim pFF As String = mobjPNR.FrequentFlyerNumber(tkt.AirlineCode, tkt.Pax.Substring(0, tkt.Pax.Length - 2).Trim)
                                        If pFF <> "" Then
                                            pFF = "Frequent Flyer Number: " & pFF
                                        End If
                                        pString.AppendLine(If(tkt.TicketType <> "PAX", tkt.TicketType & " ", "ETICKET NUMBER: ") & tkt.IssuingAirline & "-" & tkt.Document & " " & tkt.AirlineCode & " " & pFF)
                                    End If
                                Next
                            Next
                        Else
                            For Each tkt As Ticket.TicketItem In .Tickets.Values
                                If tkt.eTicket Then
                                    If MySettings.PaxSegPerTkt Then

                                        'todo - Issuing airline is code, we need airline 2 letter code for frequent flyer or maybe ff element has airline number code?
                                        Dim pFF As String = mobjPNR.FrequentFlyerNumber(tkt.AirlineCode, tkt.Pax.Substring(0, tkt.Pax.Length - 2).Trim)
                                        If pFF <> "" Then
                                            pFF = "Frequent Flyer Number: " & pFF
                                        End If
                                        pString.AppendLine(If(tkt.TicketType <> "PAX", tkt.TicketType & " ", "") & tkt.IssuingAirline & "-" & tkt.Document & "  " & tkt.Segs.Substring(0, 10) & "   " & tkt.Pax.Substring(0, tkt.Pax.Length - 2) & "  " & pFF)
                                        For i As Integer = 12 To tkt.Segs.Length - 10 Step 12
                                            pString.AppendLine(If(tkt.TicketType <> "PAX", "    ", "") & StrDup(16, " ") & tkt.Segs.Substring(i, 10))
                                        Next
                                    Else
                                        pString.AppendLine(If(tkt.TicketType <> "PAX", tkt.TicketType & " ", "") & tkt.IssuingAirline & "-" & tkt.Document)
                                    End If
                                End If
                            Next
                        End If

                    End If

                    If MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatSeaChefs Or MySettings.FormatStyle = Config.OPTItinFormat.ItnSeaChefsWithCode Or MySettings.Seating Then
                        If .Seats <> "" Then
                            If Not MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatPlain Then
                                pString.AppendLine(StrDup(mintHeaderLength, "-"))
                            End If
                            pString.AppendLine("Seat Assignment")
                            If Not MySettings.FormatStyle = Config.OPTItinFormat.ItnFormatPlain Then
                                pString.AppendLine(StrDup(mintHeaderLength, "-"))
                            End If
                            pString.AppendLine(.Seats & vbCrLf)
                        End If
                    End If

                End With

                Return pString.ToString
            Catch ex As Exception
                Throw New Exception("MakeRTBDocTickets()" & vbCrLf & ex.Message)
            End Try
        End Get
    End Property
    Private Function MakeRTBDocCloseOff() As String

        Try
            Dim pString As New System.Text.StringBuilder

            pString.Clear()
            If MySettings.BrazilText Then
                pString.AppendLine(" ")
                pString.AppendLine("***Please be advised that all Seamen entering Brazil are required to have their joining letters, or letter of guarantee written in Portuguese.  These must be provided by their respective shipping companies.  Letters in English are no longer accepted.***")
                pString.AppendLine(" ")
            End If

            If MySettings.USAText Then
                pString.AppendLine(" ")
                pString.AppendLine("***Please note, all electronic equipment must be fully charged when travelling to/from the US.***")
                pString.AppendLine("**TSA SECURE FLIGHT PROGRAMME**")
                pString.AppendLine("**All passengers who intend to travel to the United States without a U.S. Visa under the terms of the Visa Waiver Program (VWP) must obtain an electronic preauthorisation or ESTA prior to boarding a flight to the U.S.**")
                pString.AppendLine("Passengers who do not obtain ESTA prior to travel are subject to denied boarding.")
                pString.AppendLine("A third party, such as a relative, friend or travel agent may submit an ESTA application on behalf of a VWP traveller.")
                pString.AppendLine("For more details on the Visa Waiver Program, a list of VWP eligible countries and the new ESTA process, please visit the ESTA website at http://www.cbp.gov/ESTA")
                pString.AppendLine(" ")
            End If

            If MySettings.BanElectricalEquipment Then
                pString.AppendLine("Important Security information")
                pString.AppendLine(" ")
                pString.AppendLine("UK and US authorities have imposed a ban on electrical items larger than mobile phones being carried in the cabin of inbound flights from specific countries.")
                pString.AppendLine("These items, including laptops, e-readers and tablets, must now be placed in your hold baggage.")
                pString.AppendLine("For more information please contact your ATPI consultant or refer to the airline web site.")
                pString.AppendLine(" ")
            End If

            Return pString.ToString
        Catch ex As Exception
            Throw New Exception("MakeRTBDocCloseOff()" & vbCrLf & ex.Message)
        End Try

    End Function
    Public ReadOnly Property RTBMSReportHeader(ByVal FromDate As String, ByVal ToDate As String) As String
        Get
            RTBMSReportHeader = "FROM " & FromDate & " : To " & ToDate & vbCrLf
            RTBMSReportHeader &= "Last Name" & vbTab & "First Name" & vbTab & "ID No." & vbTab & "Department" & vbTab & "Vessel Name" & vbTab & "Date Of Travel" & vbTab & "Airline" & vbTab & "Flight No." & vbTab & "Dep.Time" & vbTab & "Dep.City" & vbTab & "Arr.Time" & vbTab & "Arr.City" & vbTab & "PNR" & vbTab & "PaxNo" & vbCrLf
        End Get
    End Property
    Public ReadOnly Property MakeRTBMSReportOutsiderange() As String
        Get
            Try
                Dim pString As New System.Text.StringBuilder

                With mobjPNR
                    If .HasSegments Then
                        Dim pDepTime As String = ""
                        Dim pArrTime As String = ""
                        For Each pobjPax As GDSPax.GDSPaxitem In .Passengers.Values
                            For Each pSeg As GDSSeg.GDSSegItem In .Segments.Values
                                If pSeg.Text.Substring(35, 4) = "FLWN" Then
                                    pDepTime = "FLOWN"
                                    pArrTime = "FLOWN"
                                Else
                                    pDepTime = Format(pSeg.DepartTime, "HH:mm")
                                    pArrTime = Format(pSeg.ArriveTime, "HH:mm")
                                End If
                                pString.AppendLine(pobjPax.LastName & vbTab & pobjPax.Initial & vbTab & pobjPax.IdNo & vbTab & pobjPax.Department & vbTab & .VesselName &
                                                   vbTab & pSeg.DepartureDateIATA & vbTab & pSeg.Airline & vbTab & pSeg.FlightNo & vbTab & pDepTime &
                                                   vbTab & pSeg.BoardPoint & vbTab & pArrTime & vbTab & pSeg.OffPoint & vbTab & .RequestedPNR & vbTab & pobjPax.ElementNo)
                            Next pSeg
                        Next pobjPax
                        pString.AppendLine(" ")
                        Return pString.ToString
                    Else
                        Return ""
                    End If
                End With
            Catch ex As Exception
                Throw New Exception("MakeRTBMSReportOutsiderange()" & vbCrLf & ex.Message)
            End Try
        End Get
    End Property
End Class
