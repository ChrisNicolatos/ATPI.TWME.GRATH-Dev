Public Class frmOSMAgents

    Private mOSMSelectedEmail As osmVessels.emailItem

    Private Sub frmOSMVessels_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        OSMDisplayEmails(lstOSMEditAgents)
        CheckValid()

    End Sub

    Private Sub CheckValid()
        If mOSMSelectedEmail Is Nothing Then
            cmdOSMEditUpdateAgent.Enabled = False
            cmdOSMEditDeleteAgent.Enabled = False
            txtOSMEditAgentEmail.Enabled = False
            txtOSMEditAgentDetails.Enabled = False
            txtOSMEditAgentName.Enabled = False
        Else
            cmdOSMEditUpdateAgent.Enabled = mOSMSelectedEmail.isValid
            cmdOSMEditDeleteAgent.Enabled = Not mOSMSelectedEmail.isNew
            txtOSMEditAgentEmail.Enabled = True
            txtOSMEditAgentDetails.Enabled = True
            txtOSMEditAgentName.Enabled = True
        End If
    End Sub

    Private Sub lstOSMEditAgents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOSMEditAgents.SelectedIndexChanged

        If Not lstOSMEditAgents.SelectedItem Is Nothing Then
            mOSMSelectedEmail = lstOSMEditAgents.SelectedItem
            DisplaySelectedEmail()
            CheckValid()
        End If
    End Sub

    Private Sub cmdOSMEditUpdateEmail_Click(sender As Object, e As EventArgs) Handles cmdOSMEditUpdateAgent.Click

        mOSMSelectedEmail.Update()
        OSMDisplayEmails(lstOSMEditAgents)
        mOSMSelectedEmail = Nothing
        DisplaySelectedEmail()
        CheckValid()

    End Sub

    Private Sub cmdOSMEditDeleteEmail_Click(sender As Object, e As EventArgs) Handles cmdOSMEditDeleteAgent.Click

        mOSMSelectedEmail.Delete()
        OSMDisplayEmails(lstOSMEditAgents)
        mOSMSelectedEmail = Nothing
        DisplaySelectedEmail()
        CheckValid()

    End Sub
    Private Sub txtOSMEditEmailname_TextChanged(sender As Object, e As EventArgs) Handles txtOSMEditAgentName.TextChanged

        If Not mOSMSelectedEmail Is Nothing Then
            mOSMSelectedEmail.Name = txtOSMEditAgentName.Text.Trim
            CheckValid()
        End If

    End Sub

    Private Sub txtOSMEditAgentDetails_TextChanged(sender As Object, e As EventArgs) Handles txtOSMEditAgentDetails.TextChanged
        If Not mOSMSelectedEmail Is Nothing Then
            mOSMSelectedEmail.Details = txtOSMEditAgentDetails.Text.Trim
            CheckValid()
        End If
    End Sub
    Private Sub txtOSMEditEmail_TextChanged(sender As Object, e As EventArgs) Handles txtOSMEditAgentEmail.TextChanged

        If Not mOSMSelectedEmail Is Nothing Then
            mOSMSelectedEmail.Email = txtOSMEditAgentEmail.Text.Trim
            CheckValid()
        End If

    End Sub

    Private Sub cmdOSMEditExit_Click(sender As Object, e As EventArgs) Handles cmdOSMEditAgentExit.Click

        Me.Close()

    End Sub

    Private Sub cmdOSMAddAgent_Click(sender As Object, e As EventArgs) Handles cmdOSMAddAgent.Click

        mOSMSelectedEmail = New osmVessels.emailItem("AGENT")
        DisplaySelectedEmail()
        CheckValid()

    End Sub

    Private Sub DisplaySelectedEmail()

        If mOSMSelectedEmail Is Nothing Then
            txtOSMEditAgentName.Text = ""
            txtOSMEditAgentDetails.Text = ""
            txtOSMEditAgentEmail.Text = ""
        Else
            txtOSMEditAgentName.Text = mOSMSelectedEmail.Name
            txtOSMEditAgentDetails.Text = mOSMSelectedEmail.Details
            txtOSMEditAgentEmail.Text = mOSMSelectedEmail.Email
        End If

    End Sub


End Class