<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTables
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvAirlinePoints = New System.Windows.Forms.DataGridView()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdAirlineNotes = New System.Windows.Forms.Button()
        Me.cmdAirlinePoints = New System.Windows.Forms.Button()
        Me.mnuTables = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuTablesExport = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgvAirlinePoints, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuTables.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvAirlinePoints
        '
        Me.dgvAirlinePoints.AllowUserToAddRows = False
        Me.dgvAirlinePoints.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        Me.dgvAirlinePoints.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAirlinePoints.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAirlinePoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAirlinePoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAirlinePoints.ContextMenuStrip = Me.mnuTables
        Me.dgvAirlinePoints.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvAirlinePoints.Location = New System.Drawing.Point(12, 62)
        Me.dgvAirlinePoints.Name = "dgvAirlinePoints"
        Me.dgvAirlinePoints.Size = New System.Drawing.Size(605, 325)
        Me.dgvAirlinePoints.TabIndex = 3
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(544, 12)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(73, 27)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdAirlineNotes
        '
        Me.cmdAirlineNotes.Location = New System.Drawing.Point(12, 12)
        Me.cmdAirlineNotes.Name = "cmdAirlineNotes"
        Me.cmdAirlineNotes.Size = New System.Drawing.Size(114, 27)
        Me.cmdAirlineNotes.TabIndex = 0
        Me.cmdAirlineNotes.Text = "Airline Notes"
        Me.cmdAirlineNotes.UseVisualStyleBackColor = True
        '
        'cmdAirlinePoints
        '
        Me.cmdAirlinePoints.Location = New System.Drawing.Point(132, 12)
        Me.cmdAirlinePoints.Name = "cmdAirlinePoints"
        Me.cmdAirlinePoints.Size = New System.Drawing.Size(114, 27)
        Me.cmdAirlinePoints.TabIndex = 1
        Me.cmdAirlinePoints.Text = "Airline Points"
        Me.cmdAirlinePoints.UseVisualStyleBackColor = True
        '
        'mnuTables
        '
        Me.mnuTables.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTablesExport})
        Me.mnuTables.Name = "mnuTables"
        Me.mnuTables.Size = New System.Drawing.Size(153, 48)
        '
        'mnuTablesExport
        '
        Me.mnuTablesExport.Name = "mnuTablesExport"
        Me.mnuTablesExport.Size = New System.Drawing.Size(152, 22)
        Me.mnuTablesExport.Text = "Export"
        '
        'frmTables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 399)
        Me.Controls.Add(Me.cmdAirlinePoints)
        Me.Controls.Add(Me.cmdAirlineNotes)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.dgvAirlinePoints)
        Me.Name = "frmTables"
        Me.Text = "Tables"
        CType(Me.dgvAirlinePoints, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuTables.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvAirlinePoints As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdAirlineNotes As System.Windows.Forms.Button
    Friend WithEvents cmdAirlinePoints As System.Windows.Forms.Button
    Friend WithEvents mnuTables As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuTablesExport As System.Windows.Forms.ToolStripMenuItem

End Class
