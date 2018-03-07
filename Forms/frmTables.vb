Public Class frmTables

    Private mobjAirlinePoints As New AirlinePoints.Collection
    Private mobjAirlineNotes As New AirlineNotes.Collection

    Private Sub frmTables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub cmdAirlineNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAirlineNotes.Click

        PrepareNotesTable()

    End Sub

    Private Sub PrepareNotesTable()

        mobjAirlineNotes.Load()

        With dgvAirlinePoints
            .Rows.Clear()
            .Columns.Clear()

            .Columns.Add("AirlineCode", "Airline Code")
            .Columns.Add("SeqNo", "Seq No")
            .Columns.Add("FlightType", "Flight Type")
            .Columns.Add("Seaman", "Seaman")
            .Columns.Add("AmadeusElement", "Amadeus Element")
            .Columns.Add("AmadeusText", "Amadeus Text")
            Dim pAirlineCode As String = ""
            Dim pBackColor As Color = Color.FromKnownColor(KnownColor.Window)
            For Each Item As AirlineNotes.Item In mobjAirlineNotes.Values
                Dim pCellAirlineCode As New DataGridViewTextBoxCell With {
                    .Value = Item.AirlineCode
                }
                Dim pCellSeqNo As New DataGridViewTextBoxCell With {
                    .Value = Item.SeqNo
                }
                Dim pCellFlightType As New DataGridViewTextBoxCell With {
                    .Value = Item.FlightType
                }
                Dim pCellSeaman As New DataGridViewTextBoxCell With {
                    .Value = Item.Seaman
                }
                Dim pCellAmadeusElement As New DataGridViewTextBoxCell With {
                    .Value = Item.AmadeusElement
                }
                Dim pCellAmadeusText As New DataGridViewTextBoxCell With {
                    .Value = Item.AmadeusText
                }

                Dim pRow As New DataGridViewRow
                pRow.Cells.Add(pCellAirlineCode)
                pRow.Cells.Add(pCellSeqNo)
                pRow.Cells.Add(pCellFlightType)
                pRow.Cells.Add(pCellSeaman)
                pRow.Cells.Add(pCellAmadeusElement)
                pRow.Cells.Add(pCellAmadeusText)
                If pAirlineCode <> Item.AirlineCode Then
                    If pBackColor = Color.Aquamarine Then
                        pBackColor = Color.FromKnownColor(KnownColor.Window)
                    Else
                        pBackColor = Color.Aquamarine
                    End If
                End If
                pAirlineCode = Item.AirlineCode
                pRow.DefaultCellStyle.BackColor = pBackColor
                .Rows.Add(pRow)
            Next
        End With

    End Sub

    Private Sub cmdAirlinePoints_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAirlinePoints.Click

        PreparePointsTable()

    End Sub

    Private Sub PreparePointsTable()

        mobjAirlinePoints.Load()

        With dgvAirlinePoints
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("CustCode", "Customer Code")
            .Columns.Add("CustName", "Customer Name")
            .Columns.Add("AirlineCode", "Airline Code")
            .Columns.Add("AirlineName", "Airline Name")
            .Columns.Add("PointsCommand", "Command")
            For Each Item As AirlinePoints.Item In mobjAirlinePoints.Values
                Dim pCellCustCode As New DataGridViewTextBoxCell With {
                    .Value = Item.CustomerCode
                }
                Dim pCellCustName As New DataGridViewTextBoxCell With {
                    .Value = Item.CustomerName
                }
                Dim pCellAirlineCode As New DataGridViewTextBoxCell With {
                    .Value = Item.AirlineCode
                }
                Dim pCellAirlineName As New DataGridViewTextBoxCell With {
                    .Value = Item.AirlineName
                }
                Dim pCellPointsCommand As New DataGridViewTextBoxCell With {
                    .Value = Item.PointsCommand
                }
                Dim pRow As New DataGridViewRow
                pRow.Cells.Add(pCellCustCode)
                pRow.Cells.Add(pCellCustName)
                pRow.Cells.Add(pCellAirlineCode)
                pRow.Cells.Add(pCellAirlineName)
                pRow.Cells.Add(pCellPointsCommand)
                .Rows.Add(pRow)
            Next
        End With

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Me.Close()

    End Sub

    Private Sub mnuTablesExport_Click(sender As Object, e As EventArgs) Handles mnuTablesExport.Click

        Dim mExport As New ExportDataGrid

        mExport.Export(dgvAirlinePoints)

    End Sub
End Class
