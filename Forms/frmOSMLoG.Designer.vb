<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOSMLoG
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
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.optPerPNR = New Telerik.WinControls.UI.RadRadioButton()
        Me.optPerPax = New Telerik.WinControls.UI.RadRadioButton()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.optOffSigners = New Telerik.WinControls.UI.RadRadioButton()
        Me.optOnSigners = New Telerik.WinControls.UI.RadRadioButton()
        Me.RadGroupBox3 = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkNoPortAgent = New Telerik.WinControls.UI.RadCheckBox()
        Me.lstPortAgent = New Telerik.WinControls.UI.RadListView()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.txtSignedBy = New Telerik.WinControls.UI.RadTextBoxControl()
        Me.lblPax = New Telerik.WinControls.UI.RadLabel()
        Me.lblSegs = New Telerik.WinControls.UI.RadLabel()
        Me.cmdCreatePDF = New Telerik.WinControls.UI.RadButton()
        Me.cmdExit = New Telerik.WinControls.UI.RadButton()
        Me.brwFileDestination = New Telerik.WinControls.UI.RadBrowseEditor()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.optPerPNR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optPerPax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.optOffSigners, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optOnSigners, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox3.SuspendLayout()
        CType(Me.chkNoPortAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstPortAgent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSignedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSegs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdCreatePDF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.brwFileDestination, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.optPerPNR)
        Me.RadGroupBox1.Controls.Add(Me.optPerPax)
        Me.RadGroupBox1.HeaderText = "LoG layout"
        Me.RadGroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(216, 86)
        Me.RadGroupBox1.TabIndex = 0
        Me.RadGroupBox1.Text = "LoG layout"
        '
        'optPerPNR
        '
        Me.optPerPNR.Location = New System.Drawing.Point(5, 45)
        Me.optPerPNR.Name = "optPerPNR"
        Me.optPerPNR.Size = New System.Drawing.Size(168, 18)
        Me.optPerPNR.TabIndex = 4
        Me.optPerPNR.Text = "1 Letter for all the passengers"
        '
        'optPerPax
        '
        Me.optPerPax.Location = New System.Drawing.Point(5, 21)
        Me.optPerPax.Name = "optPerPax"
        Me.optPerPax.Size = New System.Drawing.Size(132, 18)
        Me.optPerPax.TabIndex = 3
        Me.optPerPax.Text = "1 Letter per passenger"
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox2.Controls.Add(Me.optOffSigners)
        Me.RadGroupBox2.Controls.Add(Me.optOnSigners)
        Me.RadGroupBox2.HeaderText = "Reason for travel"
        Me.RadGroupBox2.Location = New System.Drawing.Point(12, 104)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Size = New System.Drawing.Size(216, 86)
        Me.RadGroupBox2.TabIndex = 1
        Me.RadGroupBox2.Text = "Reason for travel"
        '
        'optOffSigners
        '
        Me.optOffSigners.Location = New System.Drawing.Point(5, 45)
        Me.optOffSigners.Name = "optOffSigners"
        Me.optOffSigners.Size = New System.Drawing.Size(74, 18)
        Me.optOffSigners.TabIndex = 6
        Me.optOffSigners.Text = "Off signers"
        '
        'optOnSigners
        '
        Me.optOnSigners.Location = New System.Drawing.Point(5, 21)
        Me.optOnSigners.Name = "optOnSigners"
        Me.optOnSigners.Size = New System.Drawing.Size(74, 18)
        Me.optOnSigners.TabIndex = 5
        Me.optOnSigners.Text = "On signers"
        '
        'RadGroupBox3
        '
        Me.RadGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox3.Controls.Add(Me.RadLabel3)
        Me.RadGroupBox3.Controls.Add(Me.chkNoPortAgent)
        Me.RadGroupBox3.Controls.Add(Me.lstPortAgent)
        Me.RadGroupBox3.HeaderText = "Port Agent"
        Me.RadGroupBox3.Location = New System.Drawing.Point(248, 19)
        Me.RadGroupBox3.Name = "RadGroupBox3"
        Me.RadGroupBox3.Size = New System.Drawing.Size(418, 170)
        Me.RadGroupBox3.TabIndex = 2
        Me.RadGroupBox3.Text = "Port Agent"
        '
        'chkNoPortAgent
        '
        Me.chkNoPortAgent.Location = New System.Drawing.Point(15, 142)
        Me.chkNoPortAgent.Name = "chkNoPortAgent"
        Me.chkNoPortAgent.Size = New System.Drawing.Size(92, 18)
        Me.chkNoPortAgent.TabIndex = 1
        Me.chkNoPortAgent.Text = "No Port Agent"
        '
        'lstPortAgent
        '
        Me.lstPortAgent.KeyboardSearchEnabled = True
        Me.lstPortAgent.Location = New System.Drawing.Point(15, 25)
        Me.lstPortAgent.Name = "lstPortAgent"
        Me.lstPortAgent.Size = New System.Drawing.Size(391, 111)
        Me.lstPortAgent.TabIndex = 0
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(12, 212)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(56, 18)
        Me.RadLabel1.TabIndex = 3
        Me.RadLabel1.Text = "Signed by"
        '
        'RadLabel2
        '
        Me.RadLabel2.Location = New System.Drawing.Point(12, 256)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(83, 18)
        Me.RadLabel2.TabIndex = 4
        Me.RadLabel2.Text = "File Destination"
        '
        'txtSignedBy
        '
        Me.txtSignedBy.Location = New System.Drawing.Point(97, 208)
        Me.txtSignedBy.Name = "txtSignedBy"
        Me.txtSignedBy.Size = New System.Drawing.Size(518, 20)
        Me.txtSignedBy.TabIndex = 5
        '
        'lblPax
        '
        Me.lblPax.AutoSize = False
        Me.lblPax.BackColor = System.Drawing.Color.Aqua
        Me.lblPax.ForeColor = System.Drawing.Color.Blue
        Me.lblPax.Location = New System.Drawing.Point(20, 291)
        Me.lblPax.Name = "lblPax"
        Me.lblPax.Size = New System.Drawing.Size(288, 89)
        Me.lblPax.TabIndex = 8
        '
        'lblSegs
        '
        Me.lblSegs.AutoSize = False
        Me.lblSegs.BackColor = System.Drawing.Color.Aqua
        Me.lblSegs.ForeColor = System.Drawing.Color.Blue
        Me.lblSegs.Location = New System.Drawing.Point(366, 291)
        Me.lblSegs.Name = "lblSegs"
        Me.lblSegs.Size = New System.Drawing.Size(288, 89)
        Me.lblSegs.TabIndex = 9
        '
        'cmdCreatePDF
        '
        Me.cmdCreatePDF.Location = New System.Drawing.Point(252, 395)
        Me.cmdCreatePDF.Name = "cmdCreatePDF"
        Me.cmdCreatePDF.Size = New System.Drawing.Size(103, 23)
        Me.cmdCreatePDF.TabIndex = 10
        Me.cmdCreatePDF.Text = "Create PDF(s)"
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(377, 395)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(103, 23)
        Me.cmdExit.TabIndex = 11
        Me.cmdExit.Text = "Create PDF(s)"
        '
        'brwFileDestination
        '
        Me.brwFileDestination.DialogType = Telerik.WinControls.UI.BrowseEditorDialogType.FolderBrowseDialog
        Me.brwFileDestination.Location = New System.Drawing.Point(97, 254)
        Me.brwFileDestination.Name = "brwFileDestination"
        Me.brwFileDestination.Size = New System.Drawing.Size(557, 20)
        Me.brwFileDestination.TabIndex = 12
        '
        'RadLabel3
        '
        Me.RadLabel3.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Italic)
        Me.RadLabel3.Location = New System.Drawing.Point(263, 136)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(143, 16)
        Me.RadLabel3.TabIndex = 4
        Me.RadLabel3.Text = "Filter Port Agent by typing Name"
        '
        'FrmOSMLoG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 471)
        Me.Controls.Add(Me.brwFileDestination)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdCreatePDF)
        Me.Controls.Add(Me.lblSegs)
        Me.Controls.Add(Me.lblPax)
        Me.Controls.Add(Me.txtSignedBy)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.RadGroupBox3)
        Me.Controls.Add(Me.RadGroupBox2)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmOSMLoG"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OSM Letter of Guarantee"
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.optPerPNR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optPerPax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        Me.RadGroupBox2.PerformLayout()
        CType(Me.optOffSigners, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optOnSigners, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox3.ResumeLayout(False)
        Me.RadGroupBox3.PerformLayout()
        CType(Me.chkNoPortAgent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstPortAgent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSignedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSegs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdCreatePDF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.brwFileDestination, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents optPerPNR As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optPerPax As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents optOffSigners As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optOnSigners As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents RadGroupBox3 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkNoPortAgent As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents lstPortAgent As Telerik.WinControls.UI.RadListView
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtSignedBy As Telerik.WinControls.UI.RadTextBoxControl
    Friend WithEvents lblPax As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblSegs As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdCreatePDF As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents brwFileDestination As Telerik.WinControls.UI.RadBrowseEditor
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
End Class

