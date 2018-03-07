Option Strict Off
Option Explicit On
Public Class ExportDataGrid
    Public Sub Export(ByVal dGrid As Telerik.WinControls.UI.RadGridView)

        Try
            Dim pFileName As String = "C:\Users\cnicolatos\desktop\xxx.csv"

            Dim pstrText As String = ""
            For j = 0 To dGrid.ColumnCount - 1
                If j > 0 Then
                    pstrText &= vbTab
                End If
                pstrText &= Chr(34) & dGrid.Columns(j).HeaderText & Chr(34)
            Next
            For i As Integer = 0 To dGrid.Rows.Count - 1
                pstrText &= vbCrLf
                For j As Integer = 0 To dGrid.Rows(i).Cells.Count - 1
                    If j > 0 Then
                        pstrText &= vbTab
                    End If
                    pstrText &= Chr(34) & dGrid.Rows(i).Cells(j).Value & Chr(34)
                Next
            Next
            My.Computer.FileSystem.WriteAllText(pFileName, pstrText, False, System.Text.Encoding.GetEncoding(28597))

        Catch ex As Exception
            Throw New Exception("ExportDataGrid.Export()" & vbCrLf & ex.Message)
        End Try

    End Sub
End Class
