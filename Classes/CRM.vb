Option Strict Off
Option Explicit On
Namespace CRM
    Public Class Item
        Private Structure ClassProps
            Dim ID As Long
            Dim Code As String
            Dim Name As String
            Dim Alert As String
        End Structure
        Private mudtProps As ClassProps
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
        Public ReadOnly Property Alert As string
            Get
                Alert = mudtProps.Alert
            End Get
        End Property
        Friend Sub SetValues(ByVal pID As Long, ByVal pCode As string, ByVal pName As string, ByVal pAlert As string)
            With mudtProps
                .ID = pID
                .Code = pCode
                .Name = pName
                .Alert = pAlert
            End With
        End Sub

        Public Sub Load(ByVal pSubCode As string)

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringACC) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader

            mobjAlerts.Load()

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = " SELECT [Id] " &
                               " ,[Code] " &
                               " ,[Name] " &
                               " FROM [TravelForceCosmos].[dbo].[TFEntities] " &
                               " WHERE Code = '" & pSubCode & "'  " &
                               " ORDER BY Name "


                pobjReader = .ExecuteReader
            End With

            With pobjReader
                Do While .Read
                    SetValues(.Item("Id"), .Item("Code"), .Item("Name"), mobjAlerts.Alert(MySettings.PCCBackOffice, .Item("Code")))
                Loop
                .Close()
            End With
            pobjConn.Close()
        End Sub
    End Class
    Public Class Collection
        Inherits Collections.Generic.Dictionary(Of String, Item)
        Private mlngEntityID As Long
        Private mobjAlerts As New Alerts.Collection
        Public Sub Load(ByVal pEntityID As Long)

            mobjAlerts.Load()

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
                               " FROM [TravelForceCosmos].[dbo].[TFEntities] " &
                               " WHERE  IsMLEntity = 1 AND IsActive = 1 AND RelatedEntityID = " & mlngEntityID & "  " &
                               " ORDER BY Name "

                    pobjReader = .ExecuteReader
                End With

                With pobjReader
                    Do While .Read
                        pobjClass = New Item
                        pobjClass.SetValues(.Item("Id"), .Item("Code"), .Item("Name"), mobjAlerts.Alert(MySettings.PCCBackOffice, .Item("Code")))
                        MyBase.Add(pobjClass.ID, pobjClass)
                    Loop
                    .Close()
                End With
                pobjConn.Close()
            End If
        End Sub

    End Class
End Namespace
