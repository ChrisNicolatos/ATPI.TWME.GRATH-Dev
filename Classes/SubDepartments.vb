Option Strict Off
Option Explicit On
Namespace SubDepartments
    Public Class Item
        Private Structure ClassProps
            Dim ID As Long
            Dim Code As String
            Dim Name As String
        End Structure
        Private mudtProps As ClassProps
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
        Friend Sub SetValues(ByVal pID As Long, ByVal pCode As string, ByVal pName As string)
            With mudtProps
                .ID = pID
                .Code = pCode
                .Name = pName
            End With
        End Sub

        Public Sub Load(ByVal pSubID As Long)
            If MySettings.PCCBackOffice = 1 Then

                Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringACC) ' ActiveConnection)
                Dim pobjComm As New SqlClient.SqlCommand
                Dim pobjReader As SqlClient.SqlDataReader

                pobjConn.Open()
                pobjComm = pobjConn.CreateCommand

                With pobjComm
                    .CommandType = CommandType.Text
                    .CommandText = " SELECT [Id] " &
                               " ,[Code] " &
                               " ,[Name] " &
                               " FROM [TravelForceCosmos].[dbo].[TFEntitySubdepartments] " &
                               " WHERE ID = " & pSubID & "  " &
                               " ORDER BY Name "


                    pobjReader = .ExecuteReader
                End With

                With pobjReader
                    Do While .Read
                        SetValues(.Item("Id"), .Item("Code"), .Item("Name"))
                    Loop
                    .Close()
                End With
                pobjConn.Close()
            End If
        End Sub
    End Class
    Public Class Collection

        Inherits Collections.Generic.Dictionary(Of String, Item)
        Private mlngEntityID As Long

        Public Sub Load(ByVal pEntityID As Long)
            If MySettings.PCCBackOffice = 1 Then

                Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringACC) ' ActiveConnection)
                Dim pobjComm As New SqlClient.SqlCommand
                Dim pobjReader As SqlClient.SqlDataReader
                Dim pobjClass As Item

                mlngEntityID = pEntityID

                pobjConn.Open()
                pobjComm = pobjConn.CreateCommand

                With pobjComm
                    .CommandType = CommandType.Text
                    .CommandText = " SELECT [Id] " &
                               " ,[Code] " &
                               " ,[Name] " &
                               " FROM [TravelForceCosmos].[dbo].[TFEntitySubdepartments] " &
                               " WHERE EntityID = " & mlngEntityID & "  AND InUse = 1 " &
                               " ORDER BY Name "


                    pobjReader = .ExecuteReader
                End With

                With pobjReader
                    Do While .Read
                        pobjClass = New Item
                        pobjClass.SetValues(.Item("Id"), .Item("Code"), .Item("Name"))
                        MyBase.Add(pobjClass.ID, pobjClass)
                    Loop
                    .Close()
                End With
                pobjConn.Close()
            End If
        End Sub

    End Class
End Namespace
