<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVesselForPNR

    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New Telerik.WinControls.UI.RadLabel()
        Me.Label2 = New Telerik.WinControls.UI.RadLabel()
        Me.txtVesselName = New Telerik.WinControls.UI.RadTextBox()
        Me.txtRegistration = New Telerik.WinControls.UI.RadTextBox()
        Me.cmdOK = New Telerik.WinControls.UI.RadButton()
        Me.cmdCancel = New Telerik.WinControls.UI.RadButton()
        Me.lblNotice = New Telerik.WinControls.UI.RadLabel()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Vessel name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Registration"
        '
        'txtVesselName
        '
        Me.txtVesselName.Location = New System.Drawing.Point(78, 125)
        Me.txtVesselName.Name = "txtVesselName"
        Me.txtVesselName.Size = New System.Drawing.Size(277, 20)
        Me.txtVesselName.TabIndex = 2
        '
        'txtRegistration
        '
        Me.txtRegistration.Location = New System.Drawing.Point(78, 151)
        Me.txtRegistration.Name = "txtRegistration"
        Me.txtRegistration.Size = New System.Drawing.Size(277, 20)
        Me.txtRegistration.TabIndex = 4
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(78, 191)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(280, 191)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "Cancel"
        '
        'lblNotice
        '
        Me.lblNotice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblNotice.ForeColor = System.Drawing.Color.Red
        Me.lblNotice.Location = New System.Drawing.Point(5, 9)
        Me.lblNotice.Name = "lblNotice"
        Me.lblNotice.Size = New System.Drawing.Size(350, 103)
        Me.lblNotice.TabIndex = 0
        Me.lblNotice.Text = "NOTE: This vessel will not be added to the customer's vessels and is used only in" & _
    " this PNR"
        '
        'frmVesselForPNR
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(367, 226)
        Me.Controls.Add(Me.lblNotice)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtRegistration)
        Me.Controls.Add(Me.txtVesselName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVesselForPNR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Vessel for PNR"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Label2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtVesselName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtRegistration As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmdOK As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblNotice As Telerik.WinControls.UI.RadLabel
End Class
