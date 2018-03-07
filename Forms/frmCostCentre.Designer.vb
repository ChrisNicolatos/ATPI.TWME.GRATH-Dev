<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCostCentre

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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lstCustomers = New listbox
        Me.lstCustomerGroup = New ListBox
        Me.dgvCostCentres = New Telerik.WinControls.UI.RadGridView()
        Me.mnuCostCentre = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuCostCentreExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdAccept = New Telerik.WinControls.UI.RadButton()
        Me.cmdCancel = New Telerik.WinControls.UI.RadButton()
        Me.txtCustomer = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New Telerik.WinControls.UI.RadLabel()
        Me.txtCustomerGroup = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New Telerik.WinControls.UI.RadLabel()
        Me.Label3 = New Telerik.WinControls.UI.RadLabel()
        Me.txtSearch = New Telerik.WinControls.UI.RadTextBox()
        CType(Me.dgvCostCentres, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuCostCentre.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstCustomers
        '
        Me.lstCustomers.FormattingEnabled = True
        Me.lstCustomers.Location = New System.Drawing.Point(16, 42)
        Me.lstCustomers.Name = "lstCustomers"
        Me.lstCustomers.Size = New System.Drawing.Size(337, 134)
        Me.lstCustomers.TabIndex = 2
        '
        'lstCustomerGroup
        '
        Me.lstCustomerGroup.FormattingEnabled = True
        Me.lstCustomerGroup.Location = New System.Drawing.Point(391, 42)
        Me.lstCustomerGroup.Name = "lstCustomerGroup"
        Me.lstCustomerGroup.Size = New System.Drawing.Size(337, 134)
        Me.lstCustomerGroup.TabIndex = 5
        '
        'dgvCostCentres
        '
        Me.dgvCostCentres.AllowAddNewRow = False
        Me.dgvCostCentres.AllowDeleteRow = False
        Me.dgvCostCentres.AllowRowResize = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        'Me.dgvCostCentres.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCostCentres.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        'Me.dgvCostCentres.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.AllCells
        Me.dgvCostCentres.ContextMenuStrip = Me.mnuCostCentre
        Me.dgvCostCentres.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        Me.dgvCostCentres.Location = New System.Drawing.Point(16, 208)
        Me.dgvCostCentres.MultiSelect = False
        Me.dgvCostCentres.Name = "dgvCostCentres"
        Me.dgvCostCentres.Size = New System.Drawing.Size(709, 244)
        Me.dgvCostCentres.TabIndex = 8
        '
        'mnuCostCentre
        '
        Me.mnuCostCentre.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCostCentreExport})
        Me.mnuCostCentre.Name = "mnuCostCentre"
        Me.mnuCostCentre.Size = New System.Drawing.Size(153, 48)
        '
        'mnuCostCentreExport
        '
        Me.mnuCostCentreExport.Name = "mnuCostCentreExport"
        Me.mnuCostCentreExport.Size = New System.Drawing.Size(152, 22)
        Me.mnuCostCentreExport.Text = "Export"
        '
        'cmdAccept
        '
        Me.cmdAccept.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAccept.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdAccept.Location = New System.Drawing.Point(544, 458)
        Me.cmdAccept.Name = "cmdAccept"
        Me.cmdAccept.Size = New System.Drawing.Size(75, 23)
        Me.cmdAccept.TabIndex = 9
        Me.cmdAccept.Text = "Accept"
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(653, 458)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Text = "Cancel"
        '
        'txtCustomer
        '
        Me.txtCustomer.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(16, 22)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(337, 20)
        Me.txtCustomer.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Yellow
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(337, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer"
        Me.Label1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCustomerGroup
        '
        Me.txtCustomerGroup.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtCustomerGroup.Location = New System.Drawing.Point(391, 22)
        Me.txtCustomerGroup.Name = "txtCustomerGroup"
        Me.txtCustomerGroup.Size = New System.Drawing.Size(337, 20)
        Me.txtCustomerGroup.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.Location = New System.Drawing.Point(391, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(337, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Customer Group"
        Me.Label2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(63, 185)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(662, 20)
        Me.txtSearch.TabIndex = 7
        '
        'frmCostCentre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 493)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCustomerGroup)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCustomer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAccept)
        Me.Controls.Add(Me.dgvCostCentres)
        Me.Controls.Add(Me.lstCustomerGroup)
        Me.Controls.Add(Me.lstCustomers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimumSize = New System.Drawing.Size(764, 377)
        Me.Name = "frmCostCentre"
        Me.Text = "Cost Centre Lookup"
        CType(Me.dgvCostCentres, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuCostCentre.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstCustomers As Listbox
    Friend WithEvents lstCustomerGroup As Listbox
    Friend WithEvents dgvCostCentres As Telerik.WinControls.UI.RadGridView
    Friend WithEvents cmdAccept As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtCustomer As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtCustomerGroup As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtSearch As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents mnuCostCentre As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCostCentreExport As System.Windows.Forms.ToolStripMenuItem
End Class
