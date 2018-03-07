Option Strict Off
Option Explicit On
Friend Class Airlines

    Public ReadOnly Property AirlineName(ByVal AirlineCode As String) As string
        Get
            AirlineName = ReadAirline(AirlineCode)
        End Get
    End Property

    Private Function ReadAirline(ByVal airlineCode As String) As string

        Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
        Dim pobjComm As New SqlClient.SqlCommand
        Dim pobjReader As SqlClient.SqlDataReader

        pobjConn.Open()
        pobjComm = pobjConn.CreateCommand

        With pobjComm
            .CommandType = CommandType.Text
            .Parameters.Add("@AirlineCode", SqlDbType.NVarChar, 2).Value = airlineCode
            .CommandText = " SELECT airlineName " &
                           " FROM [AmadeusReports].[dbo].[zzAirlines] " &
                           " WHERE airlineCode2 = @AirlineCode"
            pobjReader = .ExecuteReader
        End With

        With pobjReader
            If .Read Then
                ReadAirline = .Item("airlineName")
            Else
                ReadAirline = airlineCode
            End If
            .Close()
        End With
        pobjConn.Close()

    End Function
End Class