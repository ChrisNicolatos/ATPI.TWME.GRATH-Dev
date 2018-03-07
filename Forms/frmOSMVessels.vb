Imports Telerik.WinControls.UI

Public Class frmOSMVessels

    Private mOSMSelectedVessel As osmVessels.VesselItem
    Private mOSMSelectedEmail As osmVessels.emailItem

    Private Sub frmOSMVessels_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        OSMRefreshVessels(lstOSMEditVessels)
        CheckValid()

    End Sub

    Private Sub CheckValid()
        If mOSMSelectedVessel Is Nothing Then
            cmdOSMEditUpdateVessel.Enabled = False
            cmdOSMAddCCEmail.Enabled = False
            cmdOSMAddToEmail.Enabled = False
        Else
            cmdOSMEditUpdateVessel.Enabled = mOSMSelectedVessel.isValid
            cmdOSMAddCCEmail.Enabled = True
            cmdOSMAddToEmail.Enabled = True
        End If
        If mOSMSelectedEmail Is Nothing Then
            cmdOSMEditUpdateEmail.Enabled = False
            cmdOSMEditDeleteEmail.Enabled = False
            txtOSMEditEmail.Enabled = False
            txtOSMEditEmailname.Enabled = False
        Else
            cmdOSMEditUpdateEmail.Enabled = mOSMSelectedEmail.isValid
            cmdOSMEditDeleteEmail.Enabled = Not mOSMSelectedEmail.isNew
            txtOSMEditEmail.Enabled = True
            txtOSMEditEmailname.Enabled = True
        End If
    End Sub

    Private Sub lstOSMEditVessels_DrawItem(sender As Object, e As DrawItemEventArgs) Handles lstOSMEditVessels.DrawItem

        ListBox_DrawItem(sender, e)

    End Sub

    Private Sub lstOSMEditVessels_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOSMEditVessels.SelectedIndexChanged

        If Not lstOSMEditVessels.SelectedItem Is Nothing Then
            mOSMSelectedVessel = lstOSMEditVessels.SelectedItem
            txtOSMEditVessel.Text = mOSMSelectedVessel.ToString
            chkOSMVesselInUse.Checked = mOSMSelectedVessel.InUse
            OSMDisplayVesselGroups(lstVesselGroup, mOSMSelectedVessel.Vessel_VesselGroup)
            OSMDisplayEmails(mOSMSelectedVessel.Id, lstOSMEditToEmail, lstOSMEditCCEmail)
        End If

    End Sub

    Private Sub lstOSMEditToEmail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOSMEditToEmail.SelectedIndexChanged

        If Not lstOSMEditToEmail.SelectedItem Is Nothing Then
            mOSMSelectedEmail = lstOSMEditToEmail.SelectedItem
            DisplaySelectedEmail()
            CheckValid()
        End If
    End Sub

    Private Sub cmdOSMEditUpdateEmail_Click(sender As Object, e As EventArgs) Handles cmdOSMEditUpdateEmail.Click

        mOSMSelectedEmail.Update()
        OSMDisplayEmails(mOSMSelectedVessel.Id, lstOSMEditToEmail, lstOSMEditCCEmail)
        mOSMSelectedEmail = Nothing
        DisplaySelectedEmail()
        CheckValid()

    End Sub

    Private Sub cmdOSMEditDeleteEmail_Click(sender As Object, e As EventArgs) Handles cmdOSMEditDeleteEmail.Click

        mOSMSelectedEmail.Delete()
        OSMDisplayEmails(mOSMSelectedVessel.Id, lstOSMEditToEmail, lstOSMEditCCEmail)
        mOSMSelectedEmail = Nothing
        DisplaySelectedEmail()
        CheckValid()

    End Sub
    Private Sub txtOSMEditEmailname_TextChanged(sender As Object, e As EventArgs) Handles txtOSMEditEmailname.TextChanged

        If Not mOSMSelectedEmail Is Nothing Then
            mOSMSelectedEmail.Name = txtOSMEditEmailname.Text.Trim
            CheckValid()
        End If

    End Sub

    Private Sub txtOSMEditEmail_TextChanged(sender As Object, e As EventArgs) Handles txtOSMEditEmail.TextChanged

        If Not mOSMSelectedEmail Is Nothing Then
            mOSMSelectedEmail.Email = txtOSMEditEmail.Text.Trim
            CheckValid()
        End If

    End Sub

    Private Sub cmdOSMEditExit_Click(sender As Object, e As EventArgs) Handles cmdOSMEditExit.Click

        Me.Close()

    End Sub

    Private Sub cmdOSMAddToEmail_Click(sender As Object, e As EventArgs) Handles cmdOSMAddToEmail.Click

        mOSMSelectedEmail = New osmVessels.emailItem("TO", mOSMSelectedVessel.Id)
        DisplaySelectedEmail()
        CheckValid()

    End Sub

    Private Sub cmdOSMAddCCEmail_Click(sender As Object, e As EventArgs) Handles cmdOSMAddCCEmail.Click

        mOSMSelectedEmail = New osmVessels.emailItem("CC", mOSMSelectedVessel.Id)
        DisplaySelectedEmail()
        CheckValid()

    End Sub

    Private Sub lstOSMEditCCEmail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOSMEditCCEmail.SelectedIndexChanged

        If Not lstOSMEditCCEmail.SelectedItem Is Nothing Then
            mOSMSelectedEmail = lstOSMEditCCEmail.SelectedItem
            DisplaySelectedEmail()
            CheckValid()
        End If

    End Sub
    Private Sub DisplaySelectedEmail()

        If mOSMSelectedEmail Is Nothing Then
            lblEmailType.Text = ""
            txtOSMEditEmailname.Text = ""
            txtOSMEditEmail.Text = ""
        Else
            lblEmailType.Text = mOSMSelectedEmail.EmailType
            txtOSMEditEmailname.Text = mOSMSelectedEmail.Name
            txtOSMEditEmail.Text = mOSMSelectedEmail.Email
        End If

    End Sub
    Private Sub cmdOSMEditUpdateVessel_Click(sender As Object, e As EventArgs) Handles cmdOSMEditUpdateVessel.Click

        Try
            mOSMSelectedVessel.Update()

            OSMRefreshVessels(lstOSMEditVessels)
            CheckValid()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtOSMEditVessel_TextChanged(sender As Object, e As EventArgs) Handles txtOSMEditVessel.TextChanged

        mOSMSelectedVessel.VesselName = txtOSMEditVessel.Text.Trim
        CheckValid()

    End Sub

    Private Sub cmdOSMAddVessel_Click(sender As Object, e As EventArgs) Handles cmdOSMAddVessel.Click

        Dim pFrm As New frmOSMAddVessel

        If pFrm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            OSMRefreshVessels(lstOSMEditVessels)
            CheckValid()
        End If

        pFrm.Close()

    End Sub

    Private Sub chkOSMVesselInUse_CheckedChanged(sender As Object, e As EventArgs) Handles chkOSMVesselInUse.CheckStateChanged
        mOSMSelectedVessel.InUse = chkOSMVesselInUse.Checked
        CheckValid()

    End Sub
    'Private Sub lstVesselGroup_ItemCheckedChanged(sender As Object, e As ListViewItemEventArgs) Handles lstVesselGroup.ItemCheckedChanged
    '    Dim pItem As osmVessels.Vessel_VesselGroupItem = e.Item
    '    pItem.Exists = e.NewValue
    'End Sub
End Class