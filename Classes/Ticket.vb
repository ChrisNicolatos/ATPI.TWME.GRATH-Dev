Option Strict Off
Option Explicit On
Namespace Ticket

    Friend Class TicketItem

        Private Structure ClassProps
            Dim GDSLine As String
            Dim StockType As Short
            Dim Document As Decimal
            Dim Books As Short
            Dim IssuingAirline As String
            Dim AirlineCode As String
            Dim eTicket As Boolean
            Dim Segs As String
            Dim Pax As String
            Dim TicketType As String
        End Structure
        Private mudtProps As ClassProps
        Public ReadOnly Property Document() As Decimal
            Get

                Document = mudtProps.Document

            End Get
        End Property
        Public ReadOnly Property IssuingAirline() As String
            Get

                IssuingAirline = Trim(mudtProps.IssuingAirline)

            End Get
        End Property
        Public ReadOnly Property AirlineCode As String
            Get
                AirlineCode = Trim(mudtProps.AirlineCode)
            End Get
        End Property
        Public ReadOnly Property eTicket() As Boolean
            Get

                eTicket = mudtProps.eTicket

            End Get
        End Property
        Public ReadOnly Property Segs As String
            Get
                Segs = mudtProps.Segs
            End Get
        End Property
        Public ReadOnly Property Pax As String
            Get
                Pax = mudtProps.Pax
            End Get
        End Property
        Public ReadOnly Property TicketType As String
            Get
                TicketType = mudtProps.TicketType
            End Get
        End Property
        Friend Sub SetValues(ByRef pGDSLine As String, ByRef pStockType As Short, ByRef pDocument As Decimal, ByRef pBooks As Short, ByRef pIssuingAirline As String, ByVal AirlineCode As String, ByRef peTicket As Boolean, pSegs As String, pPax As String, pTicketType As String)

            With mudtProps
                .GDSLine = pGDSLine
                .StockType = pStockType
                .Document = pDocument
                .Books = pBooks
                .IssuingAirline = pIssuingAirline
                .AirlineCode = AirlineCode
                .eTicket = peTicket
                .Segs = pSegs
                .Pax = pPax
                .TicketType = pTicketType
            End With

        End Sub
    End Class
    Friend Class TicketColl
        Inherits Collections.Generic.Dictionary(Of String, TicketItem)

        Private mintCount As Short

        Public Sub addTicket(ByVal pGDSLine As String, ByVal pTicketType As Short, ByVal pTicketNumber As Decimal, ByVal pTicketCount As Short, ByVal IssuingAirline As String, ByVal AirlineCode As String, ByVal eTicket As Boolean, ByVal Segs As String, ByVal Pax As String, ByVal TicketType As String)

            Dim pobjTicket As TicketItem

            Try
                pobjTicket = New TicketItem

                mintCount = mintCount + 1
                pobjTicket.SetValues(pGDSLine, pTicketType, pTicketNumber, pTicketCount, IssuingAirline, AirlineCode, eTicket, Segs, Pax, TicketType)
                MyBase.Add(Format(mintCount), pobjTicket)
            Catch ex As Exception
                Throw New Exception("addTicket()" & vbCrLf & Err.Description)
            End Try

        End Sub
    End Class
End Namespace
