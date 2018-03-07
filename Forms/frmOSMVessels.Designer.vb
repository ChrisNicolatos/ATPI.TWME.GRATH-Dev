<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOSMVessels

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
        Me.txtOSMEditVessel = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New Telerik.WinControls.UI.RadLabel()
        Me.Label3 = New Telerik.WinControls.UI.RadLabel()
        Me.lstOSMEditCCEmail = New System.Windows.Forms.ListBox()
        Me.lstOSMEditToEmail = New System.Windows.Forms.ListBox()
        Me.cmdOSMEditUpdateVessel = New Telerik.WinControls.UI.RadButton()
        Me.cmdOSMAddToEmail = New Telerik.WinControls.UI.RadButton()
        Me.cmdOSMAddCCEmail = New Telerik.WinControls.UI.RadButton()
        Me.cmdOSMAddVessel = New Telerik.WinControls.UI.RadButton()
        Me.chkOSMVesselInUse = New Telerik.WinControls.UI.RadCheckBox()
        Me.lstVesselGroup1 = New System.Windows.Forms.ListBox()
        Me.cmdAddVesselGroup = New Telerik.WinControls.UI.RadButton()
        Me.Label8 = New Telerik.WinControls.UI.RadLabel()
        Me.lstOSMEditVessels = New System.Windows.Forms.ListBox()
        Me.Label6 = New Telerik.WinControls.UI.RadLabel()
        Me.cmdOSMEditUpdateEmail = New Telerik.WinControls.UI.RadButton()
        Me.txtOSMEditEmailname = New Telerik.WinControls.UI.RadTextBox()
        Me.cmdOSMEditDeleteEmail = New Telerik.WinControls.UI.RadButton()
        Me.Label5 = New Telerik.WinControls.UI.RadLabel()
        Me.lblEmailType = New Telerik.WinControls.UI.RadLabel()
        Me.cmdOSMEditExit = New Telerik.WinControls.UI.RadButton()
        Me.Label7 = New Telerik.WinControls.UI.RadLabel()
        Me.txtOSMEditEmail = New Telerik.WinControls.UI.RadTextBox()
        Me.lstVesselGroup = New Telerik.WinControls.UI.RadCheckedListBox()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOSMEditVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMEditUpdateVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMAddToEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMAddCCEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMAddVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOSMVesselInUse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdAddVesselGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMEditUpdateEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOSMEditEmailname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMEditDeleteEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEmailType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMEditExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOSMEditEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstVesselGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(300, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Vessel name"
        '
        'txtOSMEditVessel
        '
        Me.txtOSMEditVessel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOSMEditVessel.Location = New System.Drawing.Point(380, 57)
        Me.txtOSMEditVessel.Name = "txtOSMEditVessel"
        Me.txtOSMEditVessel.Size = New System.Drawing.Size(488, 20)
        Me.txtOSMEditVessel.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(299, 357)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 18)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "emails CC"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(299, 220)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 18)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "emails TO"
        '
        'lstOSMEditCCEmail
        '
        Me.lstOSMEditCCEmail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstOSMEditCCEmail.FormattingEnabled = True
        Me.lstOSMEditCCEmail.Location = New System.Drawing.Point(380, 357)
        Me.lstOSMEditCCEmail.Name = "lstOSMEditCCEmail"
        Me.lstOSMEditCCEmail.Size = New System.Drawing.Size(488, 82)
        Me.lstOSMEditCCEmail.TabIndex = 9
        '
        'lstOSMEditToEmail
        '
        Me.lstOSMEditToEmail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstOSMEditToEmail.FormattingEnabled = True
        Me.lstOSMEditToEmail.Location = New System.Drawing.Point(380, 220)
        Me.lstOSMEditToEmail.Name = "lstOSMEditToEmail"
        Me.lstOSMEditToEmail.Size = New System.Drawing.Size(488, 82)
        Me.lstOSMEditToEmail.TabIndex = 6
        '
        'cmdOSMEditUpdateVessel
        '
        Me.cmdOSMEditUpdateVessel.Location = New System.Drawing.Point(662, 28)
        Me.cmdOSMEditUpdateVessel.Name = "cmdOSMEditUpdateVessel"
        Me.cmdOSMEditUpdateVessel.Size = New System.Drawing.Size(106, 23)
        Me.cmdOSMEditUpdateVessel.TabIndex = 4
        Me.cmdOSMEditUpdateVessel.Text = "Update Vessel"
        '
        'cmdOSMAddToEmail
        '
        Me.cmdOSMAddToEmail.Location = New System.Drawing.Point(380, 191)
        Me.cmdOSMAddToEmail.Name = "cmdOSMAddToEmail"
        Me.cmdOSMAddToEmail.Size = New System.Drawing.Size(141, 23)
        Me.cmdOSMAddToEmail.TabIndex = 7
        Me.cmdOSMAddToEmail.Text = "Add TO email"
        '
        'cmdOSMAddCCEmail
        '
        Me.cmdOSMAddCCEmail.Location = New System.Drawing.Point(380, 328)
        Me.cmdOSMAddCCEmail.Name = "cmdOSMAddCCEmail"
        Me.cmdOSMAddCCEmail.Size = New System.Drawing.Size(141, 23)
        Me.cmdOSMAddCCEmail.TabIndex = 10
        Me.cmdOSMAddCCEmail.Text = "Add CC email"
        '
        'cmdOSMAddVessel
        '
        Me.cmdOSMAddVessel.Location = New System.Drawing.Point(380, 28)
        Me.cmdOSMAddVessel.Name = "cmdOSMAddVessel"
        Me.cmdOSMAddVessel.Size = New System.Drawing.Size(118, 23)
        Me.cmdOSMAddVessel.TabIndex = 20
        Me.cmdOSMAddVessel.Text = "Add Vessel"
        '
        'chkOSMVesselInUse
        '
        Me.chkOSMVesselInUse.Location = New System.Drawing.Point(380, 77)
        Me.chkOSMVesselInUse.Name = "chkOSMVesselInUse"
        Me.chkOSMVesselInUse.Size = New System.Drawing.Size(48, 18)
        Me.chkOSMVesselInUse.TabIndex = 21
        Me.chkOSMVesselInUse.Text = "InUse"
        '
        'lstVesselGroup1
        '
        Me.lstVesselGroup1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstVesselGroup1.Location = New System.Drawing.Point(278, 12)
        Me.lstVesselGroup1.Name = "lstVesselGroup1"
        Me.lstVesselGroup1.Size = New System.Drawing.Size(88, 17)
        Me.lstVesselGroup1.TabIndex = 25
        '
        'cmdAddVesselGroup
        '
        Me.cmdAddVesselGroup.Location = New System.Drawing.Point(521, 28)
        Me.cmdAddVesselGroup.Name = "cmdAddVesselGroup"
        Me.cmdAddVesselGroup.Size = New System.Drawing.Size(118, 23)
        Me.cmdAddVesselGroup.TabIndex = 24
        Me.cmdAddVesselGroup.Text = "Add Vessel Group"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(300, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 18)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Vessel Group"
        '
        'lstOSMEditVessels
        '
        Me.lstOSMEditVessels.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstOSMEditVessels.FormattingEnabled = True
        Me.lstOSMEditVessels.Location = New System.Drawing.Point(8, 8)
        Me.lstOSMEditVessels.Name = "lstOSMEditVessels"
        Me.lstOSMEditVessels.Size = New System.Drawing.Size(256, 641)
        Me.lstOSMEditVessels.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(300, 513)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 18)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "eMail"
        '
        'cmdOSMEditUpdateEmail
        '
        Me.cmdOSMEditUpdateEmail.Location = New System.Drawing.Point(380, 557)
        Me.cmdOSMEditUpdateEmail.Name = "cmdOSMEditUpdateEmail"
        Me.cmdOSMEditUpdateEmail.Size = New System.Drawing.Size(141, 23)
        Me.cmdOSMEditUpdateEmail.TabIndex = 16
        Me.cmdOSMEditUpdateEmail.Text = "Update email"
        '
        'txtOSMEditEmailname
        '
        Me.txtOSMEditEmailname.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOSMEditEmailname.Location = New System.Drawing.Point(380, 488)
        Me.txtOSMEditEmailname.Name = "txtOSMEditEmailname"
        Me.txtOSMEditEmailname.Size = New System.Drawing.Size(488, 20)
        Me.txtOSMEditEmailname.TabIndex = 13
        '
        'cmdOSMEditDeleteEmail
        '
        Me.cmdOSMEditDeleteEmail.Location = New System.Drawing.Point(551, 557)
        Me.cmdOSMEditDeleteEmail.Name = "cmdOSMEditDeleteEmail"
        Me.cmdOSMEditDeleteEmail.Size = New System.Drawing.Size(141, 23)
        Me.cmdOSMEditDeleteEmail.TabIndex = 17
        Me.cmdOSMEditDeleteEmail.Text = "Delete email"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(300, 491)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 18)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "eMail Name"
        '
        'lblEmailType
        '
        Me.lblEmailType.Location = New System.Drawing.Point(377, 472)
        Me.lblEmailType.Name = "lblEmailType"
        Me.lblEmailType.Size = New System.Drawing.Size(9, 18)
        Me.lblEmailType.TabIndex = 11
        Me.lblEmailType.Text = "."
        '
        'cmdOSMEditExit
        '
        Me.cmdOSMEditExit.Location = New System.Drawing.Point(725, 557)
        Me.cmdOSMEditExit.Name = "cmdOSMEditExit"
        Me.cmdOSMEditExit.Size = New System.Drawing.Size(141, 23)
        Me.cmdOSMEditExit.TabIndex = 18
        Me.cmdOSMEditExit.Text = "Exit"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(380, 533)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(248, 18)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Multiple email addresses can be separated with ;"
        '
        'txtOSMEditEmail
        '
        Me.txtOSMEditEmail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOSMEditEmail.Location = New System.Drawing.Point(380, 510)
        Me.txtOSMEditEmail.Name = "txtOSMEditEmail"
        Me.txtOSMEditEmail.Size = New System.Drawing.Size(488, 20)
        Me.txtOSMEditEmail.TabIndex = 15
        '
        'lstVesselGroup
        '
        Me.lstVesselGroup.Location = New System.Drawing.Point(380, 104)
        Me.lstVesselGroup.Name = "lstVesselGroup"
        Me.lstVesselGroup.Size = New System.Drawing.Size(488, 82)
        Me.lstVesselGroup.TabIndex = 26
        '
        'frmOSMVessels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(901, 675)
        Me.Controls.Add(Me.lstVesselGroup)
        Me.Controls.Add(Me.lstVesselGroup1)
        Me.Controls.Add(Me.lstOSMEditToEmail)
        Me.Controls.Add(Me.cmdAddVesselGroup)
        Me.Controls.Add(Me.lstOSMEditCCEmail)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdOSMAddVessel)
        Me.Controls.Add(Me.chkOSMVesselInUse)
        Me.Controls.Add(Me.txtOSMEditEmail)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdOSMAddToEmail)
        Me.Controls.Add(Me.txtOSMEditVessel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdOSMEditUpdateVessel)
        Me.Controls.Add(Me.cmdOSMAddCCEmail)
        Me.Controls.Add(Me.lstOSMEditVessels)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmdOSMEditExit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblEmailType)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdOSMEditUpdateEmail)
        Me.Controls.Add(Me.cmdOSMEditDeleteEmail)
        Me.Controls.Add(Me.txtOSMEditEmailname)
        Me.Name = "frmOSMVessels"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OSM Vessels"
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOSMEditVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMEditUpdateVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMAddToEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMAddCCEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMAddVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOSMVesselInUse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdAddVesselGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMEditUpdateEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOSMEditEmailname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMEditDeleteEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEmailType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMEditExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOSMEditEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstVesselGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtOSMEditVessel As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Label3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lstOSMEditCCEmail As ListBox
    Friend WithEvents lstOSMEditToEmail As ListBox
    Friend WithEvents cmdOSMEditUpdateVessel As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdOSMAddToEmail As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdOSMAddCCEmail As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdOSMAddVessel As Telerik.WinControls.UI.RadButton
    Friend WithEvents chkOSMVesselInUse As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents cmdAddVesselGroup As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lstOSMEditVessels As ListBox
    Friend WithEvents Label6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdOSMEditUpdateEmail As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtOSMEditEmailname As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmdOSMEditDeleteEmail As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblEmailType As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdOSMEditExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtOSMEditEmail As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lstVesselGroup1 As ListBox
    Friend WithEvents lstVesselGroup As Telerik.WinControls.UI.RadCheckedListBox
End Class
