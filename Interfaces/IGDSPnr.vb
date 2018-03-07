Friend Interface IGDSPnr
    ReadOnly Property AllowanceForSegment(ByVal Origin As String, ByVal Destination As String, ByVal Airline As String) As String
    ReadOnly Property FrequentFlyerNumber(ByVal Airline As String, ByVal PaxName As String) As String
    ReadOnly Property VesselName() As String
    ReadOnly Property ClientName As String
    ReadOnly Property ClientCode As String
    Function ReadPNR(ByVal pGDSCode As Config.GDSCode, ByVal PNR As String, ByVal ForReportOnly As Boolean) As Boolean
    Function RetrievePNRsFromQueue(ByVal Queue As String) As String
    Property CancelError() As Boolean
    ReadOnly Property BookedBy As String
    ReadOnly Property CostCentre As String
    ReadOnly Property FirstSegment As GDSSeg.GDSSegItem
    ReadOnly Property GroupName As String
    ReadOnly Property GroupNamesCount As Integer
    ReadOnly Property HasSegments As Boolean
    ReadOnly Property IsGroup As Boolean
    ReadOnly Property LastSegment As GDSSeg.GDSSegItem
    ReadOnly Property MaxAirportNameLength As Integer
    ReadOnly Property MaxAirportShortNameLength As Integer
    ReadOnly Property MaxCityNameLength As Integer
    ReadOnly Property Passengers() As GDSPax.GDSPaxColl
    ReadOnly Property RequestedPNR() As String
    ReadOnly Property Seats As String
    ReadOnly Property Segments() As GDSSeg.GDSSegColl
    ReadOnly Property Tickets() As Ticket.TicketColl

End Interface
