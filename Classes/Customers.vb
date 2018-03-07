Option Strict Off
Option Explicit On
Namespace Customers
    Public Class CustomerItem
        Private Structure ClassProps
            Dim ID As Long
            Dim Code As String
            Dim Name As String
            Dim EntityKindLT As Long
            Dim HasVessels As Boolean
            Dim HasDepartments As Boolean
            Dim Alert As String
        End Structure
        Private mudtProps As ClassProps
        Private mobjCustomProperties As New CustomProperties.Collection
        Private mflgCustomProperties As Boolean
        Private mobjAlerts As New Alerts.Collection

        Public Overrides Function ToString() As string
            With mudtProps
                Return .Code & " " & .Name
            End With
        End Function

        Public ReadOnly Property ID() As Long
            Get
                ID = mudtProps.ID
            End Get
        End Property

        Public ReadOnly Property Code() As string
            Get
                Code = mudtProps.Code
            End Get
        End Property

        Public ReadOnly Property Name() As string
            Get
                Name = mudtProps.Name
            End Get
        End Property

        Public ReadOnly Property EntityKindLT() As Long
            Get
                EntityKindLT = mudtProps.EntityKindLT
            End Get
        End Property

        Public ReadOnly Property HasVessels() As Boolean
            Get
                HasVessels = mudtProps.HasVessels
            End Get
        End Property

        Public ReadOnly Property HasDepartments() As Boolean
            Get
                HasDepartments = mudtProps.HasDepartments
            End Get
        End Property
        Public ReadOnly Property Alert As string
            Get
                Alert = mudtProps.Alert
            End Get
        End Property
        Public ReadOnly Property CustomerProperties As CustomProperties.Collection
            Get
                If Not mflgCustomProperties Then
                    mobjCustomProperties.Load(mudtProps.ID)
                    mflgCustomProperties = True
                End If
                CustomerProperties = mobjCustomProperties
            End Get
        End Property

        Friend Sub SetValues(ByVal pID As Long, ByVal pCode As string, ByVal pName As string, ByVal pEntityKindLT As Long, ByVal pAlert As string)
            With mudtProps
                .ID = pID
                .Code = pCode
                .Name = pName
                .EntityKindLT = pEntityKindLT
                .Alert = pAlert.Trim
                ' TFEntityKind (from DB table [TravelForceCosmos].[dbo].[LookupTable])
                ' 404 = Other
                ' 405 = Individual
                ' 406 = Corporate
                ' 526 = Shipping Co
                ' 527 = Travel Agency
                Select Case pEntityKindLT
                    Case 526, 527
                        .HasDepartments = True
                        .HasVessels = True
                    Case Else
                        .HasDepartments = False
                        .HasVessels = False
                End Select

                mflgCustomProperties = False
            End With
        End Sub
        Public Sub Load(ByVal pCode As string)

            mobjAlerts.Load()

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringACC) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = PrepareClientSelectCommand(pCode)
                pobjReader = .ExecuteReader
            End With
            With pobjReader
                If pobjReader.Read Then
                    SetValues(.Item("Id"), .Item("Code"), .Item("Name"), .Item("TFEntityKindLT"), mobjAlerts.Alert(MySettings.PCCBackOffice, .Item("Code")))
                    .Close()
                End If
            End With
            pobjConn.Close()

        End Sub

        Private Function PrepareClientSelectCommand(ByVal pCode As String) As string

            Select Case MySettings.PCCBackOffice
                Case 1 ' Travel Force
                    PrepareClientSelectCommand = " SELECT TFEntities.Id " &
                               " ,TFEntities.Code" &
                               " ,TFEntities.Name " &
                               " ,TFEntityCategories.TFEntityKindLT " &
                               " FROM [TravelForceCosmos].[dbo].[TFEntities] " &
                               " LEFT JOIN [TravelForceCosmos].[dbo].[TFEntityCategories] " &
                               " ON TFEntities.CategoryID = TFEntityCategories.Id " &
                               " WHERE TFEntities.IsClient = 1  " &
                               " AND TFEntities.CanHaveCT = 1 " &
                               " AND TFEntities.IsActive = 1 " &
                               " AND TFEntities.Code = '" & pCode & "' "
                Case 2 ' Discovery
                    PrepareClientSelectCommand = " Select [Account_Id] As Id " &
                                                " ,[Account_Abbriviation] AS Code " &
                                                " ,[Account_Name] AS Name " &
                                                " ,526 AS TFEntityKindLT" &
                                                " From [Disco_Instone_EU].[dbo].[Company] " &
                                                " Where Account_Abbriviation = '" & pCode & "' "
                Case Else
                    PrepareClientSelectCommand = ""
            End Select
        End Function
    End Class

    Public Class CustomerCollection
        Inherits Collections.Generic.Dictionary(Of String, CustomerItem)
        Private mAllCustomer As New AllCustomer
        Public Sub Load(ByVal SearchString As string)

            Try
                If mAllCustomer.Count = 0 Or mAllCustomer.PCCBackOffice <> MySettings.PCCBackOffice Then
                    Cursor.Current = Cursors.WaitCursor
                    mAllCustomer.Load()
                End If

                MyBase.Clear()

                Dim pItem As CustomerItem

                For Each pItem In mAllCustomer.Values
                    If pItem.Code.ToUpper.IndexOf(SearchString.ToUpper) >= 0 Or pItem.Name.ToUpper.IndexOf(SearchString.ToUpper) >= 0 Then
                        MyBase.Add(pItem.ID, pItem)
                    End If
                Next

            Catch ex As Exception
                Throw New Exception("Customers.Load()" & vbCrLf & ex.Message)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub


    End Class
    Public Class AllCustomer

        Inherits Collections.Generic.Dictionary(Of String, CustomerItem)

        Dim mobjAlerts As New Alerts.Collection
        Dim mintPCCBackoffice As Integer
        Public ReadOnly Property PCCBackOffice As Integer
            Get
                PCCBackOffice = mintPCCBackoffice
            End Get
        End Property

        Public Sub Load()

            Dim pCommandText As String

            Try
                mobjAlerts.Load()

                pCommandText = PrepareClientSelectCommand()
                ReadCustomers(pCommandText)
            Catch ex As Exception
                Throw New Exception("Customers.Load()" & vbCrLf & ex.Message)
            End Try

        End Sub
        Private Function PrepareClientSelectCommand() As string

            mintPCCBackoffice = MySettings.PCCBackOffice

            Select Case MySettings.PCCBackOffice
                Case 1 ' Travel Force
                    PrepareClientSelectCommand = " SELECT TFEntities.Id " &
                               " ,TFEntities.Code" &
                               " ,TFEntities.Name " &
                               " ,TFEntityCategories.TFEntityKindLT " &
                               " FROM [TravelForceCosmos].[dbo].[TFEntities] " &
                               " LEFT JOIN [TravelForceCosmos].[dbo].[TFEntityCategories] " &
                               " ON TFEntities.CategoryID = TFEntityCategories.Id " &
                               " WHERE TFEntities.IsClient = 1  " &
                               " AND TFEntities.CanHaveCT = 1 " &
                               " AND TFEntities.IsActive = 1 " &
                               " ORDER BY TFEntities.Code "
                Case 2 ' Discovery
                    PrepareClientSelectCommand = "SELECT Company.[Account_Id] AS Id " &
                                                 " ,[Account_Abbriviation] AS Code " &
                                                 " ,[Account_Name] AS Name " &
                                                 " ,526 AS TFEntityKindLT" &
                                                 " From [Disco_Instone_EU].[dbo].[Company] " &
                                                 " Left Join Disco_Instone_EU.dbo.CompProfile " &
                                                 " On Company.Account_Id = CompProfile.Account_Id " &
                                                 " Where CompProfile.Branch = 19 " &
                                                 " ORDER BY Account_Abbriviation "
                Case Else
                    PrepareClientSelectCommand = ""
            End Select
        End Function
        Private Sub ReadCustomers(ByVal CommandText As string)

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringACC) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As CustomerItem

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = CommandText
                pobjReader = .ExecuteReader
            End With

            MyBase.Clear()

            With pobjReader
                Do While .Read
                    pobjClass = New CustomerItem
                    pobjClass.SetValues(.Item("Id"), .Item("Code"), .Item("Name"), .Item("TFEntityKindLT"), mobjAlerts.Alert(MySettings.PCCBackOffice, .Item("Code")))
                    MyBase.Add(pobjClass.ID, pobjClass)
                Loop
                .Close()
            End With
            pobjConn.Close()

        End Sub

    End Class

    Public Class CustomerGroupItem
        Private Structure ClassProps
            Dim ID As Long
            Dim Name As String
        End Structure
        Private mudtProps As ClassProps
        Public Overrides Function ToString() As string
            With mudtProps
                Return .Name
            End With
        End Function
        Public ReadOnly Property ID() As Long
            Get
                ID = mudtProps.ID
            End Get
        End Property
        Public ReadOnly Property Name() As string
            Get
                Name = mudtProps.Name
            End Get
        End Property
        Friend Sub SetValues(ByVal pID As Long, ByVal pName As string)
            With mudtProps
                .ID = pID
                .Name = pName
            End With
        End Sub
    End Class
    Public Class AllCustomerGroups
        Inherits Collections.Generic.Dictionary(Of String, CustomerGroupItem)
        Public Sub Load()

            Dim pCommandText As String

            Try
                pCommandText = " USE TravelForceCosmos " &
                               " SELECT Id " &
                               " ,Description " &
                               " FROM Tags " &
                               " WHERE TagGroupId = 146 " &
                               " ORDER BY Description "
                ReadCustomerGroups(pCommandText)
            Catch ex As Exception
                Throw New Exception("AllCustomerGroups.Load()" & vbCrLf & ex.Message)
            End Try

        End Sub
        Private Sub ReadCustomerGroups(ByVal CommandText As string)

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringACC) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As CustomerGroupItem

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = CommandText
                pobjReader = .ExecuteReader
            End With

            With pobjReader
                Do While .Read
                    pobjClass = New CustomerGroupItem
                    pobjClass.SetValues(.Item("Id"), .Item("Description"))
                    MyBase.Add(pobjClass.ID, pobjClass)
                Loop
                .Close()
            End With
            pobjConn.Close()

        End Sub
    End Class
    Public Class CustomerGroupCollection
        Inherits Collections.Generic.Dictionary(Of String, CustomerGroupItem)
        Private mAllCustomer As New AllCustomerGroups

        Public Sub Load(ByVal SearchString As string)

            Try
                If mAllCustomer.Count = 0 Then
                    Cursor.Current = Cursors.WaitCursor
                    mAllCustomer.Load()
                End If

                MyBase.Clear()

                Dim pItem As CustomerGroupItem

                For Each pItem In mAllCustomer.Values
                    If pItem.Name.ToUpper.IndexOf(SearchString.ToUpper) >= 0 Then
                        MyBase.Add(pItem.ID, pItem)
                    End If
                Next


            Catch ex As Exception
                Throw New Exception("CustomerGroupCollection.Load()" & vbCrLf & ex.Message)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub

    End Class

End Namespace
