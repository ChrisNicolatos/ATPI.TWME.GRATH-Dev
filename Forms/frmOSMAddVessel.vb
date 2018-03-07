Public Class frmOSMAddVessel

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        Try
            Dim pVessel As New osmVessels.VesselItem With {
                .VesselName = txtVesselname.Text.Trim
            }
            pVessel.Update()

            Me.DialogResult = Windows.Forms.DialogResult.OK

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub
End Class