Option Strict Off
Option Explicit On
Namespace CloseOffEntries

    Public Class Item

        Dim mEntry As String

        Public ReadOnly Property CloseOffEntry As string
            Get
                CloseOffEntry = MySettings.ConvertGDSValue(mEntry)
            End Get
        End Property
        Friend Sub SetValues(ByVal CloseOffEntry As string)
            mEntry = CloseOffEntry
        End Sub
    End Class
    Public Class Collection
        Inherits Collections.Generic.Dictionary(Of String, Item)

        Public Sub Load(ByVal GDSPcc As String, ByVal OwnPCC As Boolean)

            Dim pobjConn As New SqlClient.SqlConnection(ConnectionStringPNR) ' ActiveConnection)
            Dim pobjComm As New SqlClient.SqlCommand
            Dim pobjReader As SqlClient.SqlDataReader

            pobjConn.Open()
            pobjComm = pobjConn.CreateCommand

            With pobjComm
                .CommandType = CommandType.Text
                .Parameters.Add("@PCC", SqlDbType.NChar, 9).Value = GDSPcc
                .Parameters.Add("@OwnPCC", SqlDbType.Bit).Value = IIf(OwnPCC, 1, 0)
                .CommandText = "SELECT pfcEntry " &
                "  FROM AmadeusReports.dbo.PNRFinisherCloseOff " &
                "  WHERE pfcPCC = @PCC AND pfcOwnPCC = @OwnPCC " &
                "  ORDER BY pfcSeqNo "
                pobjReader = .ExecuteReader
            End With

            MyBase.Clear()

            Dim pIndex As Integer = 0
            With pobjReader
                While pobjReader.Read
                    Dim pItem As New Item
                    pIndex += 1
                    pItem.SetValues(.Item("pfcEntry"))
                    MyBase.Add(pIndex, pItem)
                End While
                .Close()
            End With
            pobjConn.Close()

        End Sub
    End Class
End Namespace
