Public Class frmItnMSReportDates

    Private Sub frmItnMSReportDates_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtpFromDate.Value = Today
        dtpToDate.Value = DateAdd(DateInterval.Day, 7, Today)

    End Sub
    Public ReadOnly Property FromDate As Date
        Get
            FromDate = dtpFromDate.Value
        End Get
    End Property
    Public ReadOnly Property ToDate As Date
        Get
            ToDate = dtpToDate.Value
        End Get
    End Property
    Private Sub cmdRun_Click(sender As Object, e As EventArgs) Handles cmdRun.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
End Class