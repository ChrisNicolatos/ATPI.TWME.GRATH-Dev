Option Strict Off
Option Explicit On
Namespace Alerts
    Public Class AlertItem
        Private Structure ClassProps
            Dim BackOfficeId As Integer
            Dim ClientCode As String
            Dim Alert As String
        End Structure
        Dim mudtprops As ClassProps
        Public ReadOnly Property BackOfficeID As Integer
            Get
                BackOfficeID = mudtprops.BackOfficeId
            End Get
        End Property
        Public ReadOnly Property ClientCode As string
            Get
                ClientCode = mudtprops.ClientCode
            End Get
        End Property
        Public ReadOnly Property Alert() As string
            Get
                Alert = mudtprops.Alert
            End Get
        End Property
        Friend Sub SetValues(ByVal pBackOfficeID As Integer, ByVal pClientCode As String, ByVal pAlert As String)
            With mudtprops
                .BackOfficeId = pBackOfficeID
                .ClientCode = pClientCode
                .Alert = pAlert
            End With
        End Sub
    End Class

    Public Class Collection
        Inherits Collections.Generic.Dictionary(Of String, AlertItem)
        Public Sub Load()
            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader
            Dim pobjClass As AlertItem

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            MyBase.Clear()

            With pobjComm
                .CommandType = CommandType.Text
                .CommandText = "SELECT pnaID,pnaBOId_fkey, pnaClientCode, pnaAlert FROM [AmadeusReports].[dbo].[PNRFinisherAlerts]"
                pobjReader = .ExecuteReader
            End With

            With pobjReader
                Do While .Read
                    pobjClass = New AlertItem
                    pobjClass.SetValues(.Item("pnaBOId_fkey"), .Item("pnaClientCode"), .Item("pnaAlert"))
                    MyBase.Add(.Item("pnaID").ToString, pobjClass)
                Loop
            End With
        End Sub
        Public ReadOnly Property Alert(ByVal pBackOfficeId As Integer, ByVal pClientCode As String) As string
            Get
                Alert = ""
                For Each pItem As AlertItem In MyBase.Values
                    If pItem.BackOfficeID = pBackOfficeId And pClientCode = pItem.ClientCode Then
                        Alert = pItem.Alert
                        Exit For
                    End If
                Next
            End Get
        End Property
    End Class
End Namespace