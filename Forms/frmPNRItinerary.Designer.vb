<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPNRItinerary
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
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId:="System.Windows.Forms.Label.set_Text(System.String)")> <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId:="System.Windows.Forms.GroupBox.set_Text(System.String)")> <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId:="System.Windows.Forms.ButtonBase.set_Text(System.String)")> <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdEncode = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdItnReadPNR = New System.Windows.Forms.Button()
        Me.txtPNR = New System.Windows.Forms.TextBox()
        Me.lblPNR = New System.Windows.Forms.Label()
        Me.rtbDoc = New System.Windows.Forms.RichTextBox()
        Me.cmdGetAirlines = New System.Windows.Forms.Button()
        Me.fraOptions = New System.Windows.Forms.GroupBox()
        Me.chkTickets = New System.Windows.Forms.CheckBox()
        Me.chkClass = New System.Windows.Forms.CheckBox()
        Me.chkVessel = New System.Windows.Forms.CheckBox()
        Me.chkAirlineLocator = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optAirportBoth = New System.Windows.Forms.RadioButton()
        Me.optAirportname = New System.Windows.Forms.RadioButton()
        Me.optAirportCode = New System.Windows.Forms.RadioButton()
        Me.cmdReadCurrent = New System.Windows.Forms.Button()
        Me.chkOceanRig = New System.Windows.Forms.CheckBox()
        Me.chkOceanRigPricing = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstRemarks = New System.Windows.Forms.CheckedListBox()
        Me.fraOptions.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdEncode
        '
        Me.cmdEncode.Location = New System.Drawing.Point(485, 0)
        Me.cmdEncode.Name = "cmdEncode"
        Me.cmdEncode.Size = New System.Drawing.Size(69, 35)
        Me.cmdEncode.TabIndex = 33
        Me.cmdEncode.Text = "Get Codes"
        Me.cmdEncode.UseVisualStyleBackColor = True
        Me.cmdEncode.Visible = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(485, 42)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(69, 35)
        Me.cmdExit.TabIndex = 21
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'cmdItnReadPNR
        '
        Me.cmdItnReadPNR.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItnReadPNR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItnReadPNR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItnReadPNR.Location = New System.Drawing.Point(155, 42)
        Me.cmdItnReadPNR.Name = "cmdItnReadPNR"
        Me.cmdItnReadPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItnReadPNR.Size = New System.Drawing.Size(143, 35)
        Me.cmdItnReadPNR.TabIndex = 19
        Me.cmdItnReadPNR.Text = "Read PNR"
        Me.cmdItnReadPNR.UseVisualStyleBackColor = False
        '
        'txtPNR
        '
        Me.txtPNR.AcceptsReturn = True
        Me.txtPNR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPNR.BackColor = System.Drawing.SystemColors.Window
        Me.txtPNR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPNR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPNR.Location = New System.Drawing.Point(12, 42)
        Me.txtPNR.MaxLength = 0
        Me.txtPNR.Multiline = True
        Me.txtPNR.Name = "txtPNR"
        Me.txtPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPNR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPNR.Size = New System.Drawing.Size(134, 332)
        Me.txtPNR.TabIndex = 18
        '
        'lblPNR
        '
        Me.lblPNR.BackColor = System.Drawing.SystemColors.Control
        Me.lblPNR.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPNR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPNR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPNR.Location = New System.Drawing.Point(9, 22)
        Me.lblPNR.Name = "lblPNR"
        Me.lblPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPNR.Size = New System.Drawing.Size(137, 13)
        Me.lblPNR.TabIndex = 17
        Me.lblPNR.Text = "PNR"
        Me.lblPNR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rtbDoc
        '
        Me.rtbDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbDoc.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.rtbDoc.Location = New System.Drawing.Point(304, 168)
        Me.rtbDoc.Name = "rtbDoc"
        Me.rtbDoc.Size = New System.Drawing.Size(708, 206)
        Me.rtbDoc.TabIndex = 35
        Me.rtbDoc.Text = ""
        '
        'cmdGetAirlines
        '
        Me.cmdGetAirlines.Location = New System.Drawing.Point(410, 0)
        Me.cmdGetAirlines.Name = "cmdGetAirlines"
        Me.cmdGetAirlines.Size = New System.Drawing.Size(69, 35)
        Me.cmdGetAirlines.TabIndex = 39
        Me.cmdGetAirlines.Text = "Get Airlines"
        Me.cmdGetAirlines.UseVisualStyleBackColor = True
        Me.cmdGetAirlines.Visible = False
        '
        'fraOptions
        '
        Me.fraOptions.Controls.Add(Me.chkTickets)
        Me.fraOptions.Controls.Add(Me.chkClass)
        Me.fraOptions.Controls.Add(Me.chkVessel)
        Me.fraOptions.Controls.Add(Me.chkAirlineLocator)
        Me.fraOptions.Location = New System.Drawing.Point(161, 200)
        Me.fraOptions.Name = "fraOptions"
        Me.fraOptions.Size = New System.Drawing.Size(137, 173)
        Me.fraOptions.TabIndex = 40
        Me.fraOptions.TabStop = False
        Me.fraOptions.Text = "Options"
        '
        'chkTickets
        '
        Me.chkTickets.AutoSize = True
        Me.chkTickets.Location = New System.Drawing.Point(6, 97)
        Me.chkTickets.Name = "chkTickets"
        Me.chkTickets.Size = New System.Drawing.Size(61, 17)
        Me.chkTickets.TabIndex = 3
        Me.chkTickets.Text = "Tickets"
        Me.chkTickets.UseVisualStyleBackColor = True
        '
        'chkClass
        '
        Me.chkClass.AutoSize = True
        Me.chkClass.Location = New System.Drawing.Point(6, 51)
        Me.chkClass.Name = "chkClass"
        Me.chkClass.Size = New System.Drawing.Size(102, 17)
        Me.chkClass.TabIndex = 2
        Me.chkClass.Text = "Class of Service"
        Me.chkClass.UseVisualStyleBackColor = True
        '
        'chkVessel
        '
        Me.chkVessel.AutoSize = True
        Me.chkVessel.Location = New System.Drawing.Point(6, 28)
        Me.chkVessel.Name = "chkVessel"
        Me.chkVessel.Size = New System.Drawing.Size(57, 17)
        Me.chkVessel.TabIndex = 1
        Me.chkVessel.Text = "Vessel"
        Me.chkVessel.UseVisualStyleBackColor = True
        '
        'chkAirlineLocator
        '
        Me.chkAirlineLocator.AutoSize = True
        Me.chkAirlineLocator.Location = New System.Drawing.Point(6, 74)
        Me.chkAirlineLocator.Name = "chkAirlineLocator"
        Me.chkAirlineLocator.Size = New System.Drawing.Size(93, 17)
        Me.chkAirlineLocator.TabIndex = 0
        Me.chkAirlineLocator.Text = "Airline Locator"
        Me.chkAirlineLocator.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optAirportBoth)
        Me.GroupBox1.Controls.Add(Me.optAirportname)
        Me.GroupBox1.Controls.Add(Me.optAirportCode)
        Me.GroupBox1.Location = New System.Drawing.Point(161, 94)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(137, 100)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Airport Name"
        '
        'optAirportBoth
        '
        Me.optAirportBoth.AutoSize = True
        Me.optAirportBoth.Location = New System.Drawing.Point(6, 65)
        Me.optAirportBoth.Name = "optAirportBoth"
        Me.optAirportBoth.Size = New System.Drawing.Size(47, 17)
        Me.optAirportBoth.TabIndex = 2
        Me.optAirportBoth.TabStop = True
        Me.optAirportBoth.Text = "Both"
        Me.optAirportBoth.UseVisualStyleBackColor = True
        '
        'optAirportname
        '
        Me.optAirportname.AutoSize = True
        Me.optAirportname.Location = New System.Drawing.Point(6, 42)
        Me.optAirportname.Name = "optAirportname"
        Me.optAirportname.Size = New System.Drawing.Size(72, 17)
        Me.optAirportname.TabIndex = 1
        Me.optAirportname.TabStop = True
        Me.optAirportname.Text = "Full Name"
        Me.optAirportname.UseVisualStyleBackColor = True
        '
        'optAirportCode
        '
        Me.optAirportCode.AutoSize = True
        Me.optAirportCode.Location = New System.Drawing.Point(6, 19)
        Me.optAirportCode.Name = "optAirportCode"
        Me.optAirportCode.Size = New System.Drawing.Size(89, 17)
        Me.optAirportCode.TabIndex = 0
        Me.optAirportCode.TabStop = True
        Me.optAirportCode.Text = "3 Letter Code"
        Me.optAirportCode.UseVisualStyleBackColor = True
        '
        'cmdReadCurrent
        '
        Me.cmdReadCurrent.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReadCurrent.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReadCurrent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReadCurrent.Location = New System.Drawing.Point(323, 42)
        Me.cmdReadCurrent.Name = "cmdReadCurrent"
        Me.cmdReadCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReadCurrent.Size = New System.Drawing.Size(143, 35)
        Me.cmdReadCurrent.TabIndex = 42
        Me.cmdReadCurrent.Text = "Read Current"
        Me.cmdReadCurrent.UseVisualStyleBackColor = False
        '
        'chkOceanRig
        '
        Me.chkOceanRig.AutoSize = True
        Me.chkOceanRig.Location = New System.Drawing.Point(323, 94)
        Me.chkOceanRig.Name = "chkOceanRig"
        Me.chkOceanRig.Size = New System.Drawing.Size(134, 17)
        Me.chkOceanRig.TabIndex = 43
        Me.chkOceanRig.Text = "Add text for Ocean Rig"
        Me.chkOceanRig.UseVisualStyleBackColor = True
        '
        'chkOceanRigPricing
        '
        Me.chkOceanRigPricing.AutoSize = True
        Me.chkOceanRigPricing.Location = New System.Drawing.Point(323, 113)
        Me.chkOceanRigPricing.Name = "chkOceanRigPricing"
        Me.chkOceanRigPricing.Size = New System.Drawing.Size(148, 17)
        Me.chkOceanRigPricing.TabIndex = 44
        Me.chkOceanRigPricing.Text = "Add pricing for Ocean Rig"
        Me.chkOceanRigPricing.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(560, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(451, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Remarks"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstRemarks
        '
        Me.lstRemarks.CheckOnClick = True
        Me.lstRemarks.FormattingEnabled = True
        Me.lstRemarks.Location = New System.Drawing.Point(563, 38)
        Me.lstRemarks.Name = "lstRemarks"
        Me.lstRemarks.Size = New System.Drawing.Size(448, 124)
        Me.lstRemarks.TabIndex = 47
        '
        'frmPNRItinerary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 386)
        Me.Controls.Add(Me.lstRemarks)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkOceanRigPricing)
        Me.Controls.Add(Me.chkOceanRig)
        Me.Controls.Add(Me.cmdReadCurrent)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.fraOptions)
        Me.Controls.Add(Me.cmdGetAirlines)
        Me.Controls.Add(Me.rtbDoc)
        Me.Controls.Add(Me.cmdEncode)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdItnReadPNR)
        Me.Controls.Add(Me.txtPNR)
        Me.Controls.Add(Me.lblPNR)
        Me.MinimumSize = New System.Drawing.Size(1036, 363)
        Me.Name = "frmPNRItinerary"
        Me.Text = "Prepare itinerary document"
        Me.fraOptions.ResumeLayout(False)
        Me.fraOptions.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdEncode As System.Windows.Forms.Button
    Public WithEvents cmdExit As System.Windows.Forms.Button
    Public WithEvents cmdItnReadPNR As System.Windows.Forms.Button
    Public WithEvents txtPNR As System.Windows.Forms.TextBox
    Public WithEvents lblPNR As System.Windows.Forms.Label
    Friend WithEvents rtbDoc As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdGetAirlines As System.Windows.Forms.Button
    Friend WithEvents fraOptions As System.Windows.Forms.GroupBox
    Friend WithEvents chkAirlineLocator As System.Windows.Forms.CheckBox
    Friend WithEvents chkVessel As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optAirportBoth As System.Windows.Forms.RadioButton
    Friend WithEvents optAirportname As System.Windows.Forms.RadioButton
    Friend WithEvents optAirportCode As System.Windows.Forms.RadioButton
    Friend WithEvents chkClass As System.Windows.Forms.CheckBox
    Public WithEvents cmdReadCurrent As System.Windows.Forms.Button
    Friend WithEvents chkTickets As System.Windows.Forms.CheckBox
    Friend WithEvents chkOceanRig As System.Windows.Forms.CheckBox
    Friend WithEvents chkOceanRigPricing As System.Windows.Forms.CheckBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstRemarks As System.Windows.Forms.CheckedListBox
End Class
