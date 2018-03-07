Option Strict Off
Option Explicit On
Friend Class Airports

    Private mCode As String = ""
    Private mCityName As String
    Private mCityAirportName As String
    Private mAirportShortname As String
    Private mCountryName As String

    Public ReadOnly Property CityAirportName(ByVal CityCode As String) As string
        Get
            ReadCityName(CityCode)
            CityAirportName = mCityAirportName
        End Get
    End Property
    Public ReadOnly Property CityName(ByVal CityCode As String) As string
        Get
            ReadCityName(CityCode)
            CityName = mCityName
        End Get
    End Property
    Public ReadOnly Property AirportShortname(ByVal CityCode As String) As string
        Get
            ReadCityName(CityCode)
            AirportShortname = mAirportShortname
        End Get
    End Property
    Public ReadOnly Property CountryName(ByVal CityCode As String) As String
        Get
            CountryName = mCountryName
        End Get
    End Property
    Private Sub ReadCityName(ByVal airportCode As String)

        If airportCode <> mCode Then
            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@AirportCode", SqlDbType.NVarChar, 3).Value = airportCode
                .CommandText = " SELECT cityName, airportName, ISNULL(airportShortName, '') AS airportShortName , ISNULL(countryName, '') AS countryName " &
                               " FROM [AmadeusReports].[dbo].[zzAirports] " &
                               " LEFT JOIN AmadeusReports.dbo.zzCities " &
                               " ON cityCode = airportCityCode_FK " &
                               " LEFT JOIN AmadeusReports.dbo.zzCountries " &
                               " ON zzCities.cityCountryCode_FK = zzCountries.countryCode " &
                               " WHERE airportCode = @AirportCode"
                pobjReader = .ExecuteReader
            End With

            With pobjReader
                If .Read Then
                    If .Item("cityName") = .Item("airportName") Then
                        mCityAirportName = .Item("cityName")
                    ElseIf .Item("airportName").ToString.StartsWith(.Item("cityName")) Then
                        mCityAirportName = .Item("airportName")
                    Else
                        mCityAirportName = .Item("cityName") & " " & .Item("airportName")
                    End If
                    mCityName = .Item("cityName")
                    mAirportShortname = .Item("airportShortName")
                    mCountryName = .Item("countryName")
                Else
                    mCityAirportName = airportCode
                    mCityName = airportCode
                    mCountryName = ""
                End If
                .Close()
            End With
            pobjConn.Close()
        End If
        mCode = airportCode

    End Sub

End Class