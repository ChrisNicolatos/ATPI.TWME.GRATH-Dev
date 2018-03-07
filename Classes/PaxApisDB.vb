Option Strict Off
Option Explicit On
Namespace PaxApisDB
    Public Class Item
        Private Structure ClassProps
            Friend Id As Integer
            Friend Surname As String
            Friend FirstName As String
            Friend Birthdate As Date
            Friend Gender As String

            Friend IssuingCountry As String
            Friend PassportNumber As String
            Friend ExpiryDate As Date
            Friend Nationality As String
        End Structure
        Private mudtProps As ClassProps
        Public Sub New()
            With mudtProps
                .Id = 0
                .Surname = ""
                .FirstName = ""
                .Birthdate = Date.MinValue
                .Gender = "M"
                .IssuingCountry = ""
                .PassportNumber = ""
                .ExpiryDate = Date.MinValue
                .Nationality = ""
            End With
        End Sub
        Public Sub New(ByVal pId As Integer, ByVal pSurname As String, ByVal pFirstName As String, ByVal pBirthDate As Date,
                       ByVal pGender As String, ByVal pIssuingCountry As String, ByVal pPassportNumber As String,
                       ByVal pExpiryDate As Date, ByVal pNationality As String)
            With mudtProps
                .Id = pId
                .Surname = pSurname
                .FirstName = pFirstName
                .Birthdate = pBirthDate
                .Gender = pGender

                .IssuingCountry = pIssuingCountry
                .PassportNumber = pPassportNumber
                .ExpiryDate = pExpiryDate
                .Nationality = pNationality
            End With
        End Sub
        Public ReadOnly Property Id() As Integer
            Get
                Id = mudtProps.Id
            End Get
        End Property
        Public Property Surname() As String
            Get
                Surname = mudtProps.Surname
            End Get
            Set(ByVal value As String)
                mudtProps.Surname = value
            End Set
        End Property
        Public Property FirstName() As String
            Get
                FirstName = mudtProps.FirstName
            End Get
            Set(ByVal value As String)
                mudtProps.FirstName = value
            End Set
        End Property
        Public Property BirthDate() As Date
            Get
                BirthDate = mudtProps.Birthdate
            End Get
            Set(ByVal value As Date)
                mudtProps.Birthdate = value
            End Set
        End Property
        Public Property Gender() As String
            Get
                Gender = mudtProps.Gender
            End Get
            Set(ByVal value As String)
                mudtProps.Gender = value
            End Set
        End Property
        Public Property IssuingCountry() As String
            Get
                IssuingCountry = mudtProps.IssuingCountry
            End Get
            Set(ByVal value As String)
                mudtProps.IssuingCountry = value
            End Set
        End Property
        Public Property PassportNumber() As String
            Get
                PassportNumber = mudtProps.PassportNumber
            End Get
            Set(ByVal value As String)
                mudtProps.PassportNumber = value
            End Set
        End Property
        Public Property ExpiryDate() As Date
            Get
                ExpiryDate = mudtProps.ExpiryDate
            End Get
            Set(ByVal value As Date)
                mudtProps.ExpiryDate = value
            End Set
        End Property
        Public Property Nationality() As String
            Get
                Nationality = mudtProps.Nationality
            End Get
            Set(ByVal value As String)
                mudtProps.Nationality = value
            End Set
        End Property

        Public Sub Update(ByVal ExpiryDateOK As Boolean)
            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR)
            Dim pobjComm As New SqlClient.SqlCommand

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.StoredProcedure
                .CommandText = "PaxApisAllInformationInsert"
                .Parameters.Add("@ppSurname", SqlDbType.NVarChar, 30).Value = mudtProps.Surname
                .Parameters.Add("@ppFirstName", SqlDbType.NVarChar, 30).Value = mudtProps.FirstName
                .Parameters.Add("@ppBirthDate", SqlDbType.DateTime).Value = mudtProps.Birthdate
                .Parameters.Add("@ppGender", SqlDbType.NVarChar, 10).Value = mudtProps.Gender
                .Parameters.Add("@ppDocIssuingCountry", SqlDbType.NVarChar, 3).Value = mudtProps.IssuingCountry
                .Parameters.Add("@ppDocnumber", SqlDbType.NVarChar, 15).Value = mudtProps.PassportNumber
                .Parameters.Add("@ppNationality", SqlDbType.NVarChar, 3).Value = mudtProps.Nationality
                If ExpiryDateOK And mudtProps.ExpiryDate > Date.MinValue Then
                    .Parameters.Add("@ppDocExpiryDate", SqlDbType.DateTime).Value = mudtProps.ExpiryDate
                Else
                    .Parameters.Add("@ppDocExpiryDate", SqlDbType.DateTime).Value = DateSerial(1902, 12, 31)
                End If
                .Parameters.Add("@ppQRFreqFlyer", SqlDbType.NChar, 30).Value = False
                .ExecuteNonQuery()
            End With

        End Sub
    End Class

    Public Class Collection
        Inherits Collections.Generic.Dictionary(Of Integer, Item)

        Public Function Read(ByVal Surname As String, ByVal FirstName As String) As Item
            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjItem As Item

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand
            Read = New Item

            With pobjComm
                .CommandType = CommandType.StoredProcedure
                .CommandText = "PaxApisInformationAllSelect"
                .Parameters.Add("@ppSurname", SqlDbType.NVarChar, 30).Value = Surname
                .Parameters.Add("@ppFirstName", SqlDbType.NVarChar, 30).Value = FirstName
                pobjReader = .ExecuteReader
            End With

            Clear()

            With pobjReader
                Do While .Read
                    pobjItem = New Item(.Item("ppId"), Surname, FirstName, If(IsDBNull(.Item("ppBirthdate")), Date.MinValue, .Item("ppBirthdate")), .Item("ppGender"),
                                        .Item("ppDocIssuingCountry"), .Item("ppDocnumber"), If(IsDBNull(.Item("ppDocExpiryDate")), Date.MinValue, .Item("ppDocExpiryDate")),
                                        .Item("ppNationality"))
                    MyBase.Add(pobjItem.Id, pobjItem)
                    Read = pobjItem
                Loop
                .Close()
            End With
            pobjConn.Close()

        End Function

    End Class
End Namespace

