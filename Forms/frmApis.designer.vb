<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmApis
   Inherits System.Windows.Forms.Form

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
        Me.cmdReadPnr = New System.Windows.Forms.Button()
        Me.cmdAPISUpdate = New System.Windows.Forms.Button()
        Me.dgvApis = New System.Windows.Forms.DataGridView()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.lblPNR = New System.Windows.Forms.Label()
        CType(Me.dgvApis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdReadPnr
        '
        Me.cmdReadPnr.Location = New System.Drawing.Point(12, 12)
        Me.cmdReadPnr.Name = "cmdReadPnr"
        Me.cmdReadPnr.Size = New System.Drawing.Size(123, 28)
        Me.cmdReadPnr.TabIndex = 0
        Me.cmdReadPnr.Text = "Read PNR"
        Me.cmdReadPnr.UseVisualStyleBackColor = True
        '
        'cmdAPISUpdate
        '
        Me.cmdAPISUpdate.Location = New System.Drawing.Point(188, 12)
        Me.cmdAPISUpdate.Name = "cmdAPISUpdate"
        Me.cmdAPISUpdate.Size = New System.Drawing.Size(123, 28)
        Me.cmdAPISUpdate.TabIndex = 1
        Me.cmdAPISUpdate.Text = "Update PNR"
        Me.cmdAPISUpdate.UseVisualStyleBackColor = True
        '
        'dgvApis
        '
        Me.dgvApis.AllowUserToAddRows = False
        Me.dgvApis.AllowUserToDeleteRows = False
        Me.dgvApis.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvApis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvApis.Location = New System.Drawing.Point(12, 85)
        Me.dgvApis.Name = "dgvApis"
        Me.dgvApis.Size = New System.Drawing.Size(534, 284)
        Me.dgvApis.TabIndex = 2
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(424, 12)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(123, 28)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'lblPNR
        '
        Me.lblPNR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPNR.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblPNR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPNR.Location = New System.Drawing.Point(12, 58)
        Me.lblPNR.Name = "lblPNR"
        Me.lblPNR.Size = New System.Drawing.Size(534, 18)
        Me.lblPNR.TabIndex = 4
        Me.lblPNR.Text = " "
        '
        'frmApis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 381)
        Me.Controls.Add(Me.lblPNR)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvApis)
        Me.Controls.Add(Me.cmdAPISUpdate)
        Me.Controls.Add(Me.cmdReadPnr)
        Me.Name = "frmApis"
        Me.Text = "APIS"
        CType(Me.dgvApis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdReadPnr As System.Windows.Forms.Button
    Friend WithEvents cmdAPISUpdate As System.Windows.Forms.Button
    Friend WithEvents dgvApis As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents lblPNR As System.Windows.Forms.Label

End Class
