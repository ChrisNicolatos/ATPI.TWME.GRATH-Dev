<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmin

    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TabControl1 = New Telerik.WinControls.UI.RadPageView()
        Me.GDSBackOffice = New Telerik.WinControls.UI.RadPageViewPage()
        Me.lblBackOffice = New Telerik.WinControls.UI.RadLabel()
        Me.lblGDS = New Telerik.WinControls.UI.RadLabel()
        Me.dgvBackOffice = New Telerik.WinControls.UI.RadGridView()
        Me.dgvGDS = New Telerik.WinControls.UI.RadGridView()
        Me.PCC = New Telerik.WinControls.UI.RadPageViewPage()
        Me.Users = New Telerik.WinControls.UI.RadPageViewPage()
        Me.AmadeusReferences = New Telerik.WinControls.UI.RadPageViewPage()
        Me.PNRCloseOffEntries = New Telerik.WinControls.UI.RadPageViewPage()
        Me.ClientCorporateDeals = New Telerik.WinControls.UI.RadPageViewPage()
        Me.ClientAlerts = New Telerik.WinControls.UI.RadPageViewPage()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.GDSBackOffice.SuspendLayout()
        CType(Me.lblBackOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGDS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBackOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBackOffice.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGDS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvGDS.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.GDSBackOffice)
        Me.TabControl1.Controls.Add(Me.PCC)
        Me.TabControl1.Controls.Add(Me.Users)
        Me.TabControl1.Controls.Add(Me.AmadeusReferences)
        Me.TabControl1.Controls.Add(Me.PNRCloseOffEntries)
        Me.TabControl1.Controls.Add(Me.ClientCorporateDeals)
        Me.TabControl1.Controls.Add(Me.ClientAlerts)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedPage = Me.ClientAlerts
        Me.TabControl1.Size = New System.Drawing.Size(1040, 513)
        Me.TabControl1.TabIndex = 0
        '
        'GDSBackOffice
        '
        Me.GDSBackOffice.Controls.Add(Me.lblBackOffice)
        Me.GDSBackOffice.Controls.Add(Me.lblGDS)
        Me.GDSBackOffice.Controls.Add(Me.dgvBackOffice)
        Me.GDSBackOffice.Controls.Add(Me.dgvGDS)
        Me.GDSBackOffice.ItemSize = New System.Drawing.SizeF(98.0!, 28.0!)
        Me.GDSBackOffice.Location = New System.Drawing.Point(10, 37)
        Me.GDSBackOffice.Name = "GDSBackOffice"
        Me.GDSBackOffice.Padding = New System.Windows.Forms.Padding(3)
        Me.GDSBackOffice.Size = New System.Drawing.Size(1019, 465)
        Me.GDSBackOffice.Text = "GDS/Back Office"
        '
        'lblBackOffice
        '
        Me.lblBackOffice.Location = New System.Drawing.Point(58, 212)
        Me.lblBackOffice.Name = "lblBackOffice"
        Me.lblBackOffice.Size = New System.Drawing.Size(62, 18)
        Me.lblBackOffice.TabIndex = 3
        Me.lblBackOffice.Text = "Back Office"
        Me.lblBackOffice.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'lblGDS
        '
        Me.lblGDS.Location = New System.Drawing.Point(58, 18)
        Me.lblGDS.Name = "lblGDS"
        Me.lblGDS.Size = New System.Drawing.Size(28, 18)
        Me.lblGDS.TabIndex = 2
        Me.lblGDS.Text = "GDS"
        Me.lblGDS.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'dgvBackOffice
        '
        Me.dgvBackOffice.BeginEditMode = Telerik.WinControls.RadGridViewBeginEditMode.BeginEditProgrammatically
        Me.dgvBackOffice.Location = New System.Drawing.Point(58, 228)
        '
        '
        '
        Me.dgvBackOffice.MasterTemplate.AllowAddNewRow = False
        Me.dgvBackOffice.MasterTemplate.AllowDeleteRow = False
        Me.dgvBackOffice.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvBackOffice.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvBackOffice.Name = "dgvBackOffice"
        Me.dgvBackOffice.Size = New System.Drawing.Size(514, 119)
        Me.dgvBackOffice.TabIndex = 1
        '
        'dgvGDS
        '
        Me.dgvGDS.Location = New System.Drawing.Point(58, 34)
        '
        '
        '
        Me.dgvGDS.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvGDS.Name = "dgvGDS"
        Me.dgvGDS.Size = New System.Drawing.Size(514, 119)
        Me.dgvGDS.TabIndex = 0
        '
        'PCC
        '
        Me.PCC.ItemSize = New System.Drawing.SizeF(37.0!, 28.0!)
        Me.PCC.Location = New System.Drawing.Point(10, 37)
        Me.PCC.Name = "PCC"
        Me.PCC.Padding = New System.Windows.Forms.Padding(3)
        Me.PCC.Size = New System.Drawing.Size(1019, 465)
        Me.PCC.Text = "PCC"
        '
        'Users
        '
        Me.Users.ItemSize = New System.Drawing.SizeF(43.0!, 28.0!)
        Me.Users.Location = New System.Drawing.Point(10, 37)
        Me.Users.Name = "Users"
        Me.Users.Padding = New System.Windows.Forms.Padding(3)
        Me.Users.Size = New System.Drawing.Size(1019, 465)
        Me.Users.Text = "Users"
        '
        'AmadeusReferences
        '
        Me.AmadeusReferences.ItemSize = New System.Drawing.SizeF(120.0!, 28.0!)
        Me.AmadeusReferences.Location = New System.Drawing.Point(10, 37)
        Me.AmadeusReferences.Name = "AmadeusReferences"
        Me.AmadeusReferences.Size = New System.Drawing.Size(1019, 465)
        Me.AmadeusReferences.Text = "Amadeus References"
        '
        'PNRCloseOffEntries
        '
        Me.PNRCloseOffEntries.ItemSize = New System.Drawing.SizeF(123.0!, 28.0!)
        Me.PNRCloseOffEntries.Location = New System.Drawing.Point(10, 37)
        Me.PNRCloseOffEntries.Name = "PNRCloseOffEntries"
        Me.PNRCloseOffEntries.Size = New System.Drawing.Size(1019, 465)
        Me.PNRCloseOffEntries.Text = "PNR Close Off Entries"
        '
        'ClientCorporateDeals
        '
        Me.ClientCorporateDeals.ItemSize = New System.Drawing.SizeF(129.0!, 28.0!)
        Me.ClientCorporateDeals.Location = New System.Drawing.Point(10, 37)
        Me.ClientCorporateDeals.Name = "ClientCorporateDeals"
        Me.ClientCorporateDeals.Size = New System.Drawing.Size(1019, 465)
        Me.ClientCorporateDeals.Text = "Client Corporate Deals"
        '
        'ClientAlerts
        '
        Me.ClientAlerts.ItemSize = New System.Drawing.SizeF(77.0!, 28.0!)
        Me.ClientAlerts.Location = New System.Drawing.Point(10, 37)
        Me.ClientAlerts.Name = "ClientAlerts"
        Me.ClientAlerts.Size = New System.Drawing.Size(1019, 465)
        Me.ClientAlerts.Text = "Client Alerts"
        '
        'frmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1040, 513)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmAdmin"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "PNR Finisher Administration"
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.GDSBackOffice.ResumeLayout(False)
        Me.GDSBackOffice.PerformLayout()
        CType(Me.lblBackOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGDS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBackOffice.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBackOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGDS.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvGDS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents GDSBackOffice As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents PCC As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents Users As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents AmadeusReferences As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents PNRCloseOffEntries As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents ClientCorporateDeals As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents ClientAlerts As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents dgvGDS As Telerik.WinControls.UI.RadGridView
    Friend WithEvents dgvBackOffice As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblBackOffice As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblGDS As Telerik.WinControls.UI.RadLabel
End Class
