Option Strict Off
Option Explicit On
Namespace osmVessels
    Public Class VesselItem
        Private Structure ClassProps
            Dim Id As Integer
            Dim VesselName As String
            Dim VesselGroup() As Integer
            Dim VesselgroupCount As Integer
            Dim InUse As Boolean
            Dim isNew As Boolean
            Dim isValid As Boolean
        End Structure
        Dim mudtProps As ClassProps
        Dim mobjVessel_VesselGroup As New Vessel_VesselGroupCollection

        Public Sub New()
            With mudtProps
                .Id = 0
                .VesselName = ""
                .VesselgroupCount = 0
                ReDim .VesselGroup(0)
                .InUse = True
                .isNew = True
                CheckValid()
            End With
        End Sub
        Public Overrides Function ToString() As String

            ToString = mudtProps.VesselName

        End Function
        Public ReadOnly Property Id As Integer
            Get
                Id = mudtProps.Id
            End Get
        End Property
        Public Property VesselName As String
            Get
                VesselName = mudtProps.VesselName
            End Get
            Set(value As String)
                mudtProps.VesselName = value
                CheckValid()
            End Set
        End Property
        Public ReadOnly Property VesselGroupCount As Integer
            Get
                VesselGroupCount = mudtProps.VesselgroupCount
            End Get
        End Property
        Public ReadOnly Property VesselGroup(ByVal Index As Integer) As Integer
            Get
                If Index >= 0 And Index < mudtProps.VesselgroupCount Then
                    VesselGroup = mudtProps.VesselGroup(Index)
                Else
                    VesselGroup = 0
                End If
            End Get
        End Property
        Public ReadOnly Property Vessel_VesselGroup As Vessel_VesselGroupCollection
            Get
                Vessel_VesselGroup = mobjVessel_VesselGroup
            End Get
        End Property
        Public Property InUse As Boolean
            Get
                InUse = mudtProps.InUse
            End Get
            Set(value As Boolean)
                mudtProps.InUse = value
            End Set
        End Property
        Public ReadOnly Property isValid As Boolean
            Get
                isValid = mudtProps.isValid
            End Get
        End Property
        Public Sub SetValues(ByVal pId As Integer, ByVal pVesselName As String, ByVal pInUse As Boolean)
            With mudtProps
                .Id = pId
                .VesselName = pVesselName
                .InUse = pInUse
                .isNew = False
                mobjVessel_VesselGroup.Load(Id)
            End With
            CheckValid()
        End Sub
        Private Sub CheckValid()

            With mudtProps
                .isValid = (.VesselName.Trim <> "")
            End With

        End Sub
        Public Sub Update()

            Try
                If mudtProps.isValid Then

                    Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
                    Dim pobjComm As New SqlClient.SqlCommand

                    pobjConn.Open()
                    pobjComm = pobjConn.CreateCommand

                    With pobjComm
                        .CommandType = CommandType.Text
                        If mudtProps.isNew Then
                            .CommandText = "IF (SELECT COUNT(*) FROM [AmadeusReports].[dbo].[osmVessels] WHERE osmvVesselName = '" & mudtProps.VesselName & "') = 0 " &
                                           " INSERT INTO AmadeusReports.dbo.osmVessels " &
                                           " (osmvVesselName, osmvVesselGroup, osmvInUse) " &
                                           " VALUES " &
                                           " ( '" & mudtProps.VesselName & "', '', " & If(mudtProps.InUse, 1, 0) & ") " &
                                           " select scope_identity() as Id"
                            Dim pTemp As Object = .ExecuteScalar
                            If IsDBNull(pTemp) Then
                                Throw New Exception("Vessel Already exists")
                            Else
                                mudtProps.Id = pTemp
                                mudtProps.isNew = False
                            End If
                        Else
                            .CommandText = "UPDATE AmadeusReports.dbo.osmVessels " &
                                           " SET osmvVesselName = '" & mudtProps.VesselName & "', " &
                                           "     osmvVesselGroup = '', " &
                                           "     osmvInUse = " & If(mudtProps.InUse, 1, 0) & " " &
                                           " WHERE osmvId = " & mudtProps.Id
                            .ExecuteNonQuery()
                        End If
                    End With
                    mobjVessel_VesselGroup.Update()
                Else
                    Throw New Exception("Vessel name invalid")
                End If
            Catch ex As Exception
                Throw New Exception("Update Vessel Error" & vbCrLf & ex.Message)
            End Try


        End Sub

    End Class

    Public Class VesselCollection
        Inherits Collections.Generic.Dictionary(Of String, VesselItem)

        Public Sub Load()

            Dim pText As String

            pText = "SELECT osmvID " &
                    " ,osmvVesselName " &
                    " , ISNULL(osmvInUse, 0) AS osmvInUse " &
                    " FROM AmadeusReports.dbo.osmVessels " &
                    " ORDER BY osmvVesselName"
            ExecuteLoad(pText)

        End Sub
        Public Sub Load(ByVal pVesselGroup As Integer)

            Dim pText As String

            pText = "SELECT osmvID " &
                    " ,osmvVesselName " &
                    " , ISNULL(osmvInUse, 0) AS osmvInUse " &
                    " FROM AmadeusReports.dbo.osmVessels " &
                    " WHERE osmvID IN (SELECT osmVesselGroup_Vessels.osmvId_fkey FROM osmVesselGroup_Vessels WHERE osmVesselGroup_Vessels.osmvrId_fkey=" & pVesselGroup & ")" &
                    " ORDER BY osmvVesselName"
            ExecuteLoad(pText)

        End Sub
        Private Sub ExecuteLoad(ByVal pText As String)

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As VesselItem

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = pText
                pobjReader = .ExecuteReader
            End With

            With pobjReader
                Do While .Read
                    pobjClass = New VesselItem
                    pobjClass.SetValues(.Item("osmvId"), .Item("osmvVesselName"), .Item("osmvInUse"))
                    MyBase.Add(pobjClass.Id, pobjClass)
                Loop
                .Close()
            End With
            pobjConn.Close()
        End Sub
    End Class
    Public Class Vessel_VesselGroupItem
        Private Structure ClassProps
            Dim Id As Integer
            Dim VesselId As Integer
            Dim VesselGroupId As Integer
            Dim VesselName As String
            Dim VesselGroupName As String
            Dim Exists As Boolean
        End Structure
        Dim mudtProps As ClassProps
        Public Sub New()
            With mudtProps
                .Id = 0
                .VesselId = 0
                .VesselGroupId = 0
                .VesselName = ""
                .VesselGroupName = ""
                .Exists = False
            End With
        End Sub
        Public Overrides Function ToString() As String
            ToString = mudtProps.VesselName & "-" & mudtProps.VesselGroupName
        End Function
        Public ReadOnly Property Id As Integer
            Get
                Id = mudtProps.Id
            End Get
        End Property
        Public ReadOnly Property VesselName As String
            Get
                VesselName = mudtProps.VesselName
            End Get
        End Property
        Public ReadOnly Property VesselGroupName As String
            Get
                VesselGroupName = mudtProps.VesselGroupName
            End Get
        End Property
        Public Property VesselId As Integer
            Get
                VesselId = mudtProps.VesselId
            End Get
            Set(value As Integer)
                mudtProps.VesselId = value
            End Set
        End Property
        Public Property VesselGroupId As Integer
            Get
                VesselGroupId = mudtProps.VesselGroupId
            End Get
            Set(value As Integer)
                mudtProps.VesselGroupId = value
            End Set
        End Property
        Public Property Exists As Boolean
            Get
                Exists = mudtProps.Exists
            End Get
            Set(value As Boolean)
                mudtProps.Exists = value
            End Set
        End Property
        Friend Sub SetValues(ByVal pId As Integer, ByVal pVesselId As Integer, ByVal pVesselGroupId As Integer, ByVal pVesselName As String, ByVal pVesselGroupName As String, ByVal pVesselId_fkey As Integer)
            With mudtProps
                .Id = pId
                .VesselId = pVesselId
                .VesselGroupId = pVesselGroupId
                .VesselName = pVesselName
                .VesselGroupName = pVesselGroupName
                .Exists = (pVesselId_fkey <> 0)
            End With
        End Sub
    End Class
    Public Class Vessel_VesselGroupCollection
        Inherits Collections.Generic.Dictionary(Of String, Vessel_VesselGroupItem)

        Public Sub Load(ByVal pVesselId As Integer)

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As Vessel_VesselGroupItem

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = " SELECT [osmvrId] " &
                               "       ,[osmvrGroupName] " &
                               " 	  ,ISNULL(osmvVesselName, '') AS osmvVesselName " &
                               " 	  ," & pVesselId & " AS osmvId " &
                               " 	  ,ISNULL((SELECT osmvId_fkey FROM osmVesselGroup_Vessels WHERE osmvrId = osmvrId_fkey AND osmvId_fkey=" & pVesselId & "),0) AS osmvId_fkey " &
                               "   FROM [AmadeusReports].[dbo].[osmVesselGroup] " &
                               "   LEFT JOIN osmVessels " &
                               "   ON osmvID = " & pVesselId

                pobjReader = .ExecuteReader
            End With

            MyBase.Clear()
            Dim pId As Integer = 0
            With pobjReader
                Do While .Read
                    pobjClass = New Vessel_VesselGroupItem
                    pId += 1
                    pobjClass.SetValues(pId, .Item("osmvId"), .Item("osmvrId"), .Item("osmvVesselName"), .Item("osmvrGroupName"), .Item("osmvId_fkey"))
                    MyBase.Add(pobjClass.Id, pobjClass)
                Loop
                .Close()
            End With
            pobjConn.Close()

        End Sub
        Public Sub Update()

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjClass As Vessel_VesselGroupItem

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            For Each pobjClass In MyBase.Values
                pobjComm.CommandType = CommandType.Text
                If pobjClass.Exists Then
                    pobjComm.CommandText = "IF (SELECT COUNT(*) FROM AmadeusReports.dbo.osmVesselGroup_Vessels WHERE osmvrId_fkey = " & pobjClass.VesselGroupId & " AND osmvId_fkey = " & pobjClass.VesselId & ")=0" &
                        "INSERT INTO AmadeusReports.dbo.osmVesselGroup_Vessels (osmvrId_fkey ,osmvId_fkey) VALUES (" & pobjClass.VesselGroupId & "," & pobjClass.VesselId & ")"
                Else
                    pobjComm.CommandText = "DELETE FROM AmadeusReports.dbo.osmVesselGroup_Vessels WHERE osmvrId_fkey = " & pobjClass.VesselGroupId & " AND osmvId_fkey = " & pobjClass.VesselId
                End If
                pobjComm.ExecuteNonQuery()
            Next
        End Sub
    End Class
    Public Class VesselGroupItem
        Private Structure ClassProps
            Dim Id As Integer
            Dim GroupName As String
            Dim isNew As Boolean
            Dim isValid As Boolean
        End Structure
        Dim mudtProps As ClassProps
        Public Sub New()
            With mudtProps
                .Id = 0
                .GroupName = ""
                .isNew = True
                CheckValid()
            End With
        End Sub
        Public Sub New(pId As Integer, pGroupName As String)
            With mudtProps
                .Id = pId
                .GroupName = pGroupName
                .isNew = True
                CheckValid()
            End With
        End Sub
        Private Sub CheckValid()
            mudtProps.isValid = (GroupName <> "")
        End Sub
        Public Overrides Function ToString() As String
            ToString = mudtProps.GroupName
        End Function
        Public ReadOnly Property Id As Integer
            Get
                Id = mudtProps.Id
            End Get
        End Property
        Public Property GroupName As String
            Get
                GroupName = mudtProps.GroupName
            End Get
            Set(value As String)
                mudtProps.GroupName = value
                CheckValid()
            End Set
        End Property
        Public ReadOnly Property isValid As Boolean
            Get
                isValid = mudtProps.isValid
            End Get
        End Property
        Public ReadOnly Property isNew As Boolean
            Get
                isNew = mudtProps.isNew
            End Get
        End Property
        Public Sub SetValues(ByVal pId As Integer, ByVal pGroupName As String)
            With mudtProps
                .Id = pId
                .GroupName = pGroupName
                .isNew = False
                CheckValid()
            End With
        End Sub
        Public Sub Update()

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = "INSERT INTO [AmadeusReports].[dbo].[osmVesselGroup] " &
                               " (osmvrGroupName) " &
                               " VALUES " &
                               " ( '" & GroupName & ", ') " &
                               " select scope_identity() as Id"
                mudtProps.Id = .ExecuteScalar
                mudtProps.isNew = False
            End With
        End Sub
        Public Sub Delete()
            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                If Not mudtProps.isNew Then
                    .CommandText = "DELETE FROM AmadeusReports.dbo.osmVesselGroup " &
                                   " WHERE osmvrId = " & mudtProps.Id
                    .ExecuteNonQuery()
                End If
            End With
        End Sub
    End Class
    Public Class VesselGroupCollection
        Inherits Collections.Generic.Dictionary(Of String, VesselGroupItem)

        Public Sub Load(ByVal pVesselGroupID As Integer)

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As VesselGroupItem

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@VesselgroupId", SqlDbType.BigInt).Value = pVesselGroupID
                .CommandText = "SELECT osmvrId " &
                               "      ,osmvrGroupName " &
                               "  FROM AmadeusReports.dbo.osmVesselGroup " &
                               "  WHERE osmvrId = @VesselgroupId " &
                               "  ORDER BY osmvrGroupName"
                pobjReader = .ExecuteReader
            End With

            MyBase.Clear()
            With pobjReader
                Do While .Read
                    pobjClass = New VesselGroupItem
                    pobjClass.SetValues(.Item("osmvrId"), .Item("osmvrGroupName"))
                    MyBase.Add(pobjClass.Id, pobjClass)
                Loop
                .Close()
            End With
            pobjConn.Close()

        End Sub
        Public Sub Load()

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As VesselGroupItem

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = "SELECT osmvrId " &
                               "      ,osmvrGroupName " &
                               "  FROM AmadeusReports.dbo.osmVesselGroup " &
                               "  ORDER BY osmvrGroupName"
                pobjReader = .ExecuteReader
            End With

            MyBase.Clear()
            With pobjReader
                Do While .Read
                    pobjClass = New VesselGroupItem
                    pobjClass.SetValues(.Item("osmvrId"), .Item("osmvrGroupName"))
                    MyBase.Add(pobjClass.Id, pobjClass)
                Loop
                .Close()
            End With
            pobjConn.Close()

        End Sub
    End Class
    Public Class emailItem

        Private Structure Classprops
            Dim Id As Integer
            Dim Vessel_FK As Integer
            Dim Name As String
            Dim Details As String
            Dim EmailType As String
            Dim Email As String
            Dim VesselName As String
            Dim isNew As Boolean
            Dim isValid As Boolean
        End Structure
        Dim mudtprops As Classprops
        Dim mNameOnly As Boolean
        Public Sub New()

            With mudtprops
                .Id = 0
                .Vessel_FK = 0
                .Name = ""
                .Details = ""
                .EmailType = ""
                .Email = ""
                .VesselName = ""
                .isNew = True
            End With
            mNameOnly = False

        End Sub
        Public Sub New(ByVal pType As String, Optional ByVal pVessel_FK As Integer = 0)

            With mudtprops
                .Id = 0
                .Vessel_FK = pVessel_FK
                .Name = ""
                .Details = ""
                .EmailType = pType
                .Email = ""
                .VesselName = ""
                .isNew = True
                CheckValid()
            End With
            mNameOnly = False

        End Sub
        Private Sub CheckValid()

            With mudtprops
                .isValid = False
                If (.Vessel_FK <> 0 Or (.EmailType = "AGENT" And .Vessel_FK = 0)) And .Name <> "" And .EmailType <> "" And .Email <> "" Then
                    .isValid = True
                End If
            End With
        End Sub
        Public Sub SetNameOnly()
            mNameOnly = True
        End Sub
        Public Overrides Function ToString() As String

            If mNameOnly Then
                ToString = mudtprops.Name
            Else

                ToString = Chr(34) & mudtprops.Name & Chr(34) & " <" & mudtprops.Email & ">"
                Dim pEmail() As String = mudtprops.Email.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                If IsArray(pEmail) Then
                    Dim pString As String = ""
                    For i As Integer = 0 To pEmail.GetUpperBound(0)

                        If pString <> "" Then
                            pString &= ";"
                        End If
                        pString &= Chr(34) & mudtprops.Name & Chr(34) & " <" & pEmail(i) & ">"
                    Next
                    ToString = pString
                End If
            End If

        End Function

        Public ReadOnly Property Id As Integer
            Get
                Id = mudtprops.Id
            End Get
        End Property
        Public ReadOnly Property Vessel_FK As Integer
            Get
                Vessel_FK = mudtprops.Vessel_FK
            End Get
        End Property
        Public Property Name As String
            Get
                Name = mudtprops.Name
            End Get
            Set(value As String)
                mudtprops.Name = value
                CheckValid()
            End Set
        End Property
        Public Property Details As String
            Get
                Details = mudtprops.Details
            End Get
            Set(value As String)
                mudtprops.Details = value
                CheckValid()
            End Set
        End Property
        Public ReadOnly Property EmailType As String
            Get
                EmailType = mudtprops.EmailType
            End Get
        End Property
        Public Property Email As String
            Get
                Email = mudtprops.Email
            End Get
            Set(value As String)
                mudtprops.Email = value
                CheckValid()
            End Set
        End Property
        Public ReadOnly Property VesselName As String
            Get
                VesselName = mudtprops.VesselName
            End Get
        End Property
        Public ReadOnly Property isValid As Boolean
            Get
                isValid = mudtprops.isValid
            End Get
        End Property
        Public ReadOnly Property isNew As Boolean
            Get
                isNew = mudtprops.isNew
            End Get
        End Property
        Public Sub SetValues(ByVal pId As Integer, ByVal pVessel_FK As Integer, ByVal pName As String, ByVal pDetails As String, ByVal pEmailType As String, ByVal pEmail As String, ByVal pVesselName As String)

            With mudtprops
                .Id = pId
                .Vessel_FK = pVessel_FK
                .Name = pName
                .Details = pDetails
                .EmailType = pEmailType
                .Email = pEmail
                .VesselName = pVesselName
                .isNew = False
                CheckValid()
            End With
        End Sub
        Public Sub Update()

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                If mudtprops.isNew Then
                    If mudtprops.EmailType = "AGENT" Then
                        .CommandText = "INSERT INTO [AmadeusReports].[dbo].[osmEmailDetails] " &
                                       " (osmeName, osmeDetails, osmeType, osmeEmail) " &
                                       " VALUES " &
                                       " ( '" & mudtprops.Name & "', '" & mudtprops.Details & "', '" & mudtprops.EmailType & "', '" & mudtprops.Email & "') " &
                                       " select scope_identity() as Id"
                    Else
                        .CommandText = "INSERT INTO [AmadeusReports].[dbo].[osmEmailDetails] " &
                                       " (osmeVessel_FK, osmeName, osmeDetails, osmeType, osmeEmail) " &
                                       " VALUES " &
                                       " ( " & mudtprops.Vessel_FK & ", '" & mudtprops.Name & "', '" & mudtprops.Details & "', '" & mudtprops.EmailType & "', '" & mudtprops.Email & "') " &
                                       " select scope_identity() as Id"

                    End If
                    mudtprops.Id = .ExecuteScalar
                    mudtprops.isNew = False
                Else
                    .CommandText = "UPDATE AmadeusReports.dbo.osmEmailDetails " &
                                   " SET osmeName = '" & mudtprops.Name & "', " &
                                   "     osmeDetails = '" & mudtprops.Details & "', " &
                                   "     osmeType    = '" & mudtprops.EmailType & "' ," &
                                   "     osmeEmail   = '" & mudtprops.Email & "' " &
                                   " WHERE osmeId = " & mudtprops.Id
                    .ExecuteNonQuery()
                End If
            End With
        End Sub
        Public Sub Delete()
            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                If Not mudtprops.isNew Then
                    .CommandText = "DELETE FROM AmadeusReports.dbo.osmEmailDetails " &
                                   " WHERE osmeId = " & mudtprops.Id
                    .ExecuteNonQuery()
                End If
            End With
        End Sub
    End Class
    Public Class EmailCollection
        Inherits Collections.Generic.Dictionary(Of String, emailItem)

        Public Sub Load(ByVal pVesselID As Integer)

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As emailItem

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = "SELECT osmeId " &
                               "      ,ISNULL(osmeVessel_FK,0) AS osmeVessel_FK " &
                               "      ,ISNULL(osmeName, '') AS osmeName " &
                               "      ,ISNULL(osmeDetails, '') AS osmeDetails " &
                               "      ,ISNULL(osmeType, '') AS osmeType " &
                               "      ,ISNULL(osmeEmail, '') AS osmeEmail " &
                               "      ,ISNULL(osmvVesselName, '') AS osmvVesselName " &
                               "  FROM AmadeusReports.dbo.osmEmailDetails " &
                               " LEFT JOIN AmadeusReports.dbo.osmVessels " &
                               "   ON osmeVessel_FK = osmVessels.osmvID " &
                               "  WHERE ISNULL(osmeVessel_FK, " & pVesselID & ") = " & pVesselID & " " &
                               "  ORDER BY osmeType, osmeName"
                pobjReader = .ExecuteReader
            End With

            MyBase.Clear()
            With pobjReader
                Do While .Read
                    pobjClass = New emailItem
                    pobjClass.SetValues(.Item("osmeId"), .Item("osmeVessel_FK"), .Item("osmeName"), .Item("osmeDetails"), .Item("osmeType"), .Item("osmeEmail"), .Item("osmvVesselName"))
                    MyBase.Add(pobjClass.Id, pobjClass)
                Loop
                .Close()
            End With
            pobjConn.Close()

        End Sub
        Public Sub Load()

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As emailItem

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = "SELECT osmeId " &
                               "      ,ISNULL(osmeVessel_FK,0) AS osmeVessel_FK " &
                               "      ,ISNULL(osmeName, '') AS osmeName " &
                               "      ,ISNULL(osmeDetails, '') AS osmeDetails " &
                               "      ,ISNULL(osmeType, '') AS osmeType " &
                               "      ,ISNULL(osmeEmail, '') AS osmeEmail " &
                               "      ,ISNULL(osmvVesselName, '') AS osmvVesselName " &
                               "  FROM AmadeusReports.dbo.osmEmailDetails " &
                               " LEFT JOIN AmadeusReports.dbo.osmVessels " &
                               "   ON osmeVessel_FK = osmVessels.osmvID " &
                               "  WHERE osmeType = 'AGENT' " &
                               "  ORDER BY  osmeName"
                pobjReader = .ExecuteReader
            End With

            MyBase.Clear()
            With pobjReader
                Do While .Read
                    pobjClass = New emailItem
                    pobjClass.SetValues(.Item("osmeId"), .Item("osmeVessel_FK"), .Item("osmeName"), .Item("osmeDetails"), .Item("osmeType"), .Item("osmeEmail"), .Item("osmvVesselName"))
                    MyBase.Add(pobjClass.Id, pobjClass)
                Loop
                .Close()
            End With
            pobjConn.Close()

        End Sub
    End Class

End Namespace
