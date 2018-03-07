Public Class frmVesselForPNR

    Dim mstrVesselName As String
    Dim mstrRegistration As String

    Public ReadOnly Property VesselName() As string
        Get
            VesselName = mstrVesselName
        End Get
    End Property

    Public ReadOnly Property Registration() As string
        Get
            Registration = mstrRegistration
        End Get
    End Property

    Private Sub frmVesselForPNR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblNotice.Text = My.Resources.VesselsForPNRNotice
        mstrVesselName = ""
        mstrRegistration = ""
        ShowEnabled()

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub txtVesselName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVesselName.TextChanged

        mstrVesselName = Trim(txtVesselName.Text)
        ShowEnabled()

    End Sub

    Private Sub txtRegistration_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRegistration.TextChanged

        mstrRegistration = Trim(txtRegistration.Text)
        ShowEnabled()

    End Sub

    Private Sub ShowEnabled()

        cmdOK.Enabled = (mstrVesselName <> "")

    End Sub

End Class