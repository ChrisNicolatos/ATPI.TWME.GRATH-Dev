Option Strict Off
Option Explicit On
Friend Class GDSNumberParser

    Private Structure ParserProps

        Dim ParseType As Short ' 1 = Ticket number text 2 = Segment number association

        ' Ticket number text properties
        Dim TicketNumberText As String ' Input
        Dim StockType As Short
        Dim DocumentNumber As Decimal
        Dim Books As Short
        Dim Airline As String
        Dim AirlineNumber As String

        ' Segment number association text properties
        Dim SegmentAssociationText As String
        Dim SegmentCount As Short
        Dim SegmentElements() As Short
        Dim isValid As Boolean
    End Structure

    Private mudtProps As ParserProps

    Public Function TicketNumberText(ByVal Value As String) As Boolean

        With mudtProps
            .ParseType = 1
            .TicketNumberText = Trim(Value)
            .isValid = False
        End With

        TicketNumberText = parseTicketNumber()

    End Function

    Public ReadOnly Property StockType() As Short
        Get

            StockType = mudtProps.StockType

        End Get
    End Property
    Public ReadOnly Property DocumentNumber() As Decimal
        Get

            DocumentNumber = mudtProps.DocumentNumber

        End Get
    End Property
    Public ReadOnly Property Books() As Short
        Get

            Books = mudtProps.Books

        End Get
    End Property
    Public ReadOnly Property AirlineNumber() As string
        Get

            AirlineNumber = mudtProps.AirlineNumber

        End Get
    End Property
    Private Function parseTicketNumber() As Boolean
        ' acceptable strings are:
        ' TTTTTTTTTT 10 digit ticket number
        ' AAATTTTTTTTTT 3 digit airline + 10 digit ticket number
        ' AAA-TTTTTTTTTT 3 digit airline + 10 digit ticket number separated by hyphen
        ' all the above can have conjunction tickets with last digits of last ticket separated by hyphen
        ' the number of last digits is variable
        ' TTTTTTTTTT-XX 10 digit ticket number
        ' AAATTTTTTTTTT-XX 3 digit airline + 10 digit ticket number
        ' AAA-TTTTTTTTTT-XX 3 digit airline + 10 digit ticket number separated by hyphen

        Dim i As Short
        Dim pstrTicket As String = ""
        Dim pintAirlineFrom As Short
        Dim pintAirlineTo As Short
        Dim pintTicketFrom As Short
        Dim pintTicketTo As Short
        Dim pintConjFrom As Short
        Dim pintConjTo As Short
        Dim pintEndOfString As Short

        Dim pstrTemp As String
        Dim pstrTemp2 As String
        Dim pcurrDoc2 As Decimal
        Dim pflgOK As Boolean

        Try
            With mudtProps
                .Airline = ""
                .AirlineNumber = ""
                .Books = 0
                .DocumentNumber = 0
                .StockType = 1

                pintEndOfString = Len(.TicketNumberText)
                For i = 1 To Len(.TicketNumberText)
                    pflgOK = False
                    pstrTemp = Mid(.TicketNumberText, i, 1)
                    If pstrTemp >= "0" And pstrTemp <= "9" Then
                        pflgOK = True
                    ElseIf pstrTemp = "-" Then
                        Select Case i
                            Case 4
                                pintAirlineFrom = 1
                                pintAirlineTo = 3
                                pintTicketFrom = 5
                                pintTicketTo = 14
                                pflgOK = True
                            Case 11
                                If pintTicketFrom <> 0 Then
                                    pintEndOfString = 0
                                    Exit For
                                End If
                                pintAirlineFrom = 0
                                pintAirlineTo = 0
                                pintTicketFrom = 1
                                pintTicketTo = 10
                                pintConjFrom = 12
                                pflgOK = True
                            Case 14
                                If pintConjFrom <> 0 Then
                                    pintEndOfString = 0
                                    Exit For
                                End If
                                pintAirlineFrom = 1
                                pintAirlineTo = 3
                                pintTicketFrom = 4
                                pintTicketTo = 13
                                pintConjFrom = 15
                                pflgOK = True
                            Case 15
                                If pintConjFrom <> 0 Then
                                    pintEndOfString = 0
                                    Exit For
                                End If
                                pintAirlineFrom = 1
                                pintAirlineTo = 3
                                pintTicketFrom = 5
                                pintTicketTo = 14
                                pintConjFrom = 16
                                pflgOK = True
                        End Select
                    End If
                    If Not pflgOK Then
                        pintEndOfString = i - 1
                        Exit For
                    End If
                Next i
                If pintConjFrom > 0 Then
                    pintConjTo = pintEndOfString
                End If

                If pintEndOfString < 10 Or (pintConjFrom > 0 And pintConjTo <= pintConjFrom) Then
                    .isValid = False
                ElseIf pintEndOfString = 10 And pintTicketFrom = 0 Then
                    pintAirlineFrom = 0
                    pintAirlineTo = 0
                    pintTicketFrom = 1
                    pintTicketTo = 10
                ElseIf pintEndOfString = 13 And pintTicketFrom = 0 Then
                    pintAirlineFrom = 1
                    pintAirlineTo = 3
                    pintTicketFrom = 4
                    pintTicketTo = 13
                End If

                If pintAirlineFrom > 0 And pintAirlineTo > pintAirlineFrom Then
                    .AirlineNumber = Format(myCurr(Mid(.TicketNumberText, pintAirlineFrom, pintAirlineTo - pintAirlineFrom + 1)), "000")
                End If

                If pintTicketFrom > 0 And pintTicketTo > pintTicketFrom Then
                    pstrTicket = Mid(.TicketNumberText, pintTicketFrom, pintTicketTo - pintTicketFrom + 1)
                    .DocumentNumber = myCurr(pstrTicket)
                    .Books = 1
                End If

                If pintConjFrom > 0 And pintConjTo >= pintConjFrom Then
                    pstrTemp = Mid(.TicketNumberText, pintConjFrom, pintConjTo - pintConjFrom + 1)
                    pstrTemp2 = pstrTicket
                    If Len(pstrTemp) <= Len(pstrTemp2) Then
                        Mid(pstrTemp2, Len(pstrTemp2) - Len(pstrTemp) + 1, Len(pstrTemp)) = pstrTemp
                        pcurrDoc2 = myCurr(pstrTemp2)
                        If pcurrDoc2 > .DocumentNumber Then
                            .Books = pcurrDoc2 - .DocumentNumber + 1
                        End If
                    End If
                End If

                If .DocumentNumber > 0 Then
                    .isValid = True
                Else
                    .isValid = False
                End If

                parseTicketNumber = .isValid
            End With
        Catch ex As Exception
            With mudtProps
                .Airline = ""
                .AirlineNumber = ""
                .Books = 0
                .DocumentNumber = 0
                .StockType = 0
                .isValid = False
            End With

            parseTicketNumber = False
        End Try

    End Function
End Class