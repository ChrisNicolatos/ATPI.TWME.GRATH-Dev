Public Class frmAdmin
    Private Sub frmAdmin_Load(sender As Object, e As EventArgs) Handles Me.Load

        PrepareGrids()
        DisplayGrids()

    End Sub

    Private Sub PrepareGrids()
        With dgvGDS
            .Columns.Clear()
            .Columns.Add("GDSId", "Id")
            .Columns.Add("GDSName", "Name")
            '.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        End With
        With dgvBackOffice
            .Columns.Clear()
            .Columns.Add("BOId", "Id")
            .Columns.Add("BOName", "Name")
            '.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        End With
    End Sub
    Private Sub DisplayGrids()

        Dim pGDSColl As New GDS.GDSCollection
        Dim pBackOfficeColl As New BackOffice.BackOfficeCollection

        pGDSColl.Load()
        pBackOfficeColl.Load()

        For Each pItem As GDS.GDSItem In pGDSColl.Values
            Dim pRow As New DataGridViewRow
            Dim pIdCell As New DataGridViewTextBoxCell With {
                .Value = pItem.Id
            }
            Dim pNameCell As New DataGridViewTextBoxCell With {
                .Value = pItem.GDSName
            }
            pRow.Cells.Add(pIdCell)
            pRow.Cells.Add(pNameCell)
            dgvGDS.Rows.Add(pRow)
        Next

        'dgvGDS.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        For Each pItem As BackOffice.BackOfficeItem In pBackOfficeColl.Values
            Dim pRow As New DataGridViewRow
            Dim pIdCell As New DataGridViewTextBoxCell With {
                .Value = pItem.Id
            }
            Dim pNameCell As New DataGridViewTextBoxCell With {
                .Value = pItem.BackOfficeName
            }
            pRow.Cells.Add(pIdCell)
            pRow.Cells.Add(pNameCell)
            dgvBackOffice.Rows.Add(pRow)
        Next
        'dgvBackOffice.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

    End Sub
End Class