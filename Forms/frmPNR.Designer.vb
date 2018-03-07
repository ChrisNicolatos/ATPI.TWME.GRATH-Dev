Imports Telerik.WinControls.UI

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPNR

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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPNR))
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewComboBoxColumn1 As Telerik.WinControls.UI.GridViewComboBoxColumn = New Telerik.WinControls.UI.GridViewComboBoxColumn()
        Dim GridViewComboBoxColumn2 As Telerik.WinControls.UI.GridViewComboBoxColumn = New Telerik.WinControls.UI.GridViewComboBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.cmdExit = New Telerik.WinControls.UI.RadButton()
        Me.cmdPNRReadAmadeusPNR = New Telerik.WinControls.UI.RadButton()
        Me.llbOptions = New System.Windows.Forms.LinkLabel()
        Me.lblPNR = New Telerik.WinControls.UI.RadLabel()
        Me.lblPax = New Telerik.WinControls.UI.RadLabel()
        Me.lblSegs = New Telerik.WinControls.UI.RadLabel()
        Me.lstVessels = New System.Windows.Forms.ListBox()
        Me.lblCRM = New Telerik.WinControls.UI.RadLabel()
        Me.lstSubDepartments = New System.Windows.Forms.ListBox()
        Me.txtCRM = New Telerik.WinControls.UI.RadTextBox()
        Me.txtVessel = New Telerik.WinControls.UI.RadTextBox()
        Me.lstCRM = New System.Windows.Forms.ListBox()
        Me.txtSubdepartment = New Telerik.WinControls.UI.RadTextBox()
        Me.cmdOneTimeVessel = New Telerik.WinControls.UI.RadButton()
        Me.txtCustomer = New Telerik.WinControls.UI.RadTextBox()
        Me.lblReference = New Telerik.WinControls.UI.RadLabel()
        Me.lblAirlinePoints = New Telerik.WinControls.UI.RadLabel()
        Me.lblSubDepartment = New Telerik.WinControls.UI.RadLabel()
        Me.txtReference = New Telerik.WinControls.UI.RadTextBox()
        Me.lblVessel = New Telerik.WinControls.UI.RadLabel()
        Me.cmbBookedby = New Telerik.WinControls.UI.RadDropDownList()
        Me.lblCustomer = New Telerik.WinControls.UI.RadLabel()
        Me.cmbDepartment = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmdPNRWrite = New Telerik.WinControls.UI.RadButton()
        Me.lblBookedByHighlight = New Telerik.WinControls.UI.RadLabel()
        Me.lblDepartmentHighlight = New Telerik.WinControls.UI.RadLabel()
        Me.lstCustomers = New System.Windows.Forms.ListBox()
        Me.cmbReasonForTravel = New Telerik.WinControls.UI.RadDropDownList()
        Me.lblReasonForTravelHighLight = New Telerik.WinControls.UI.RadLabel()
        Me.cmbCostCentre = New Telerik.WinControls.UI.RadDropDownList()
        Me.lblCostCentreHighlight = New Telerik.WinControls.UI.RadLabel()
        Me.tabPNR = New Telerik.WinControls.UI.RadPageView()
        Me.tabPageFinisher = New Telerik.WinControls.UI.RadPageViewPage()
        Me.cmdAdmin = New Telerik.WinControls.UI.RadButton()
        Me.cmdPNROnlyDocs = New Telerik.WinControls.UI.RadButton()
        Me.cmdPNRWriteWithDocs = New Telerik.WinControls.UI.RadButton()
        Me.txtAirlineEntries = New Telerik.WinControls.UI.RadTextBox()
        Me.lblSSRDocs = New Telerik.WinControls.UI.RadLabel()
        Me.dgvApis = New Telerik.WinControls.UI.RadGridView()
        Me.cmdAveragePrice = New Telerik.WinControls.UI.RadButton()
        Me.lblAveragePrice = New Telerik.WinControls.UI.RadLabel()
        Me.lblAvPriceDetails = New Telerik.WinControls.UI.RadLabel()
        Me.cmdCostCentre = New Telerik.WinControls.UI.RadButton()
        Me.tabPageItinerary = New Telerik.WinControls.UI.RadPageViewPage()
        Me.cmdItnFormatOSMLoG = New Telerik.WinControls.UI.RadButton()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.cmdItn1GReadCurrent = New Telerik.WinControls.UI.RadButton()
        Me.cmdItn1GReadPNR = New Telerik.WinControls.UI.RadButton()
        Me.cmdItn1GReadQueue = New Telerik.WinControls.UI.RadButton()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.cmdItn1AReadCurrent = New Telerik.WinControls.UI.RadButton()
        Me.cmdItn1AReadPNR = New Telerik.WinControls.UI.RadButton()
        Me.cmdItn1AReadQueue = New Telerik.WinControls.UI.RadButton()
        Me.webItnDoc = New System.Windows.Forms.WebBrowser()
        Me.lblItnPNRCounter = New Telerik.WinControls.UI.RadLabel()
        Me.cmdItnRefresh = New Telerik.WinControls.UI.RadButton()
        Me.fraItnFormat = New Telerik.WinControls.UI.RadGroupBox()
        Me.optItnFormatSeaChefsWith3LetterCode = New Telerik.WinControls.UI.RadRadioButton()
        Me.optItnFormatEuronav = New Telerik.WinControls.UI.RadRadioButton()
        Me.optItnFormatMSReport = New Telerik.WinControls.UI.RadRadioButton()
        Me.optItnFormatSeaChefs = New Telerik.WinControls.UI.RadRadioButton()
        Me.optItnFormatPlain = New Telerik.WinControls.UI.RadRadioButton()
        Me.optItnFormatDefault = New Telerik.WinControls.UI.RadRadioButton()
        Me.cmdItnExit = New Telerik.WinControls.UI.RadButton()
        Me.lstItnRemarks = New Telerik.WinControls.UI.RadCheckedListBox()
        Me.lblItnRemarks = New Telerik.WinControls.UI.RadLabel()
        Me.fraItnAirportName = New Telerik.WinControls.UI.RadGroupBox()
        Me.optItnAirportCityBoth = New Telerik.WinControls.UI.RadRadioButton()
        Me.optItnAirportCityName = New Telerik.WinControls.UI.RadRadioButton()
        Me.optItnAirportBoth = New Telerik.WinControls.UI.RadRadioButton()
        Me.optItnAirportname = New Telerik.WinControls.UI.RadRadioButton()
        Me.optItnAirportCode = New Telerik.WinControls.UI.RadRadioButton()
        Me.fraItnOptions = New Telerik.WinControls.UI.RadGroupBox()
        Me.chkItnCostCentre = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkItnFlyingTime = New Telerik.WinControls.UI.RadCheckBox()
        Me.lblItnTextToBeAdded = New Telerik.WinControls.UI.RadLabel()
        Me.chkItnSeating = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkItnUSAText = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkItnStopovers = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkItnBrazilText = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkItnTerminal = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkItnElecItemsBan = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkItnPaxSegPerTicket = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkItnTickets = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkItnClass = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkItnVessel = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkItnAirlineLocator = New Telerik.WinControls.UI.RadCheckBox()
        Me.rtbItnDoc = New System.Windows.Forms.RichTextBox()
        Me.menuITNSelectCopy = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuCopyItn = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtItnPNR = New Telerik.WinControls.UI.RadTextBox()
        Me.lblItnPNR = New Telerik.WinControls.UI.RadLabel()
        Me.tabOSM = New Telerik.WinControls.UI.RadPageViewPage()
        Me.Label2 = New Telerik.WinControls.UI.RadLabel()
        Me.cmbOSMVesselGroup = New System.Windows.Forms.ComboBox()
        Me.chkOSMVesselInUse = New Telerik.WinControls.UI.RadCheckBox()
        Me.lblOSMMultipleSearchSeparator = New Telerik.WinControls.UI.RadLabel()
        Me.txtOSMAgentsFilter = New Telerik.WinControls.UI.RadTextBox()
        Me.cmdOSMClearSelected = New Telerik.WinControls.UI.RadButton()
        Me.cmdOSMEmailClear = New Telerik.WinControls.UI.RadButton()
        Me.webOSMDoc = New System.Windows.Forms.WebBrowser()
        Me.lstOSMVessels = New System.Windows.Forms.ListBox()
        Me.cmdOSMCopyDocument = New Telerik.WinControls.UI.RadButton()
        Me.cmdOSMPrepareDoc = New Telerik.WinControls.UI.RadButton()
        Me.dgvOSMPax = New Telerik.WinControls.UI.RadGridView()
        Me.lblOSMPasteEmailsHere = New Telerik.WinControls.UI.RadLabel()
        Me.txtOSMPax = New Telerik.WinControls.UI.RadTextBox()
        Me.lblOSMVessel = New Telerik.WinControls.UI.RadLabel()
        Me.cmdOSMVesselsEdit = New Telerik.WinControls.UI.RadButton()
        Me.lblOSMVessels = New Telerik.WinControls.UI.RadLabel()
        Me.cmdOSMAgentEdit = New Telerik.WinControls.UI.RadButton()
        Me.lblOSMAgents = New Telerik.WinControls.UI.RadLabel()
        Me.lstOSMAgents = New System.Windows.Forms.ListBox()
        Me.cmdOSMCopyCC = New Telerik.WinControls.UI.RadButton()
        Me.cmdOSMCopyTo = New Telerik.WinControls.UI.RadButton()
        Me.lblOSMEmailsCC = New Telerik.WinControls.UI.RadLabel()
        Me.lblOSMEmailsTo = New Telerik.WinControls.UI.RadLabel()
        Me.lstOSMCCEmail = New System.Windows.Forms.ListBox()
        Me.lstOSMToEmail = New System.Windows.Forms.ListBox()
        Me.cmdOSMRefresh = New Telerik.WinControls.UI.RadButton()
        Me.ttpToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.cmdExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdPNRReadAmadeusPNR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPNR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSegs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCRM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCRM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubdepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOneTimeVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReference, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAirlinePoints, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSubDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReference, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbBookedby, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdPNRWrite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBookedByHighlight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDepartmentHighlight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbReasonForTravel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReasonForTravelHighLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCostCentre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCostCentreHighlight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabPNR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPNR.SuspendLayout()
        Me.tabPageFinisher.SuspendLayout()
        CType(Me.cmdAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdPNROnlyDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdPNRWriteWithDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAirlineEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSSRDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvApis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvApis.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdAveragePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAveragePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAvPriceDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdCostCentre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPageItinerary.SuspendLayout()
        CType(Me.cmdItnFormatOSMLoG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.cmdItn1GReadCurrent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdItn1GReadPNR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdItn1GReadQueue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.cmdItn1AReadCurrent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdItn1AReadPNR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdItn1AReadQueue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItnPNRCounter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdItnRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fraItnFormat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraItnFormat.SuspendLayout()
        CType(Me.optItnFormatSeaChefsWith3LetterCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optItnFormatEuronav, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optItnFormatMSReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optItnFormatSeaChefs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optItnFormatPlain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optItnFormatDefault, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdItnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstItnRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItnRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fraItnAirportName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraItnAirportName.SuspendLayout()
        CType(Me.optItnAirportCityBoth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optItnAirportCityName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optItnAirportBoth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optItnAirportname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optItnAirportCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fraItnOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraItnOptions.SuspendLayout()
        CType(Me.chkItnCostCentre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkItnFlyingTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItnTextToBeAdded, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkItnSeating, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkItnUSAText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkItnStopovers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkItnBrazilText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkItnTerminal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkItnElecItemsBan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkItnPaxSegPerTicket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkItnTickets, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkItnClass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkItnVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkItnAirlineLocator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuITNSelectCopy.SuspendLayout()
        CType(Me.txtItnPNR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItnPNR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabOSM.SuspendLayout()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOSMVesselInUse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOSMMultipleSearchSeparator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOSMAgentsFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMClearSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMEmailClear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMCopyDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMPrepareDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOSMPax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOSMPax.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOSMPasteEmailsHere, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOSMPax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOSMVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMVesselsEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOSMVessels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMAgentEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOSMAgents, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMCopyCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMCopyTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOSMEmailsCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOSMEmailsTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOSMRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(996, 6)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(154, 35)
        Me.cmdExit.TabIndex = 37
        Me.cmdExit.Text = "Exit"
        '
        'cmdPNRReadAmadeusPNR
        '
        Me.cmdPNRReadAmadeusPNR.Location = New System.Drawing.Point(16, 6)
        Me.cmdPNRReadAmadeusPNR.Name = "cmdPNRReadAmadeusPNR"
        Me.cmdPNRReadAmadeusPNR.Size = New System.Drawing.Size(133, 35)
        Me.cmdPNRReadAmadeusPNR.TabIndex = 0
        Me.cmdPNRReadAmadeusPNR.Text = "Read Amadeus PNR"
        '
        'llbOptions
        '
        Me.llbOptions.AutoSize = True
        Me.llbOptions.Location = New System.Drawing.Point(1217, 11)
        Me.llbOptions.Name = "llbOptions"
        Me.llbOptions.Size = New System.Drawing.Size(43, 13)
        Me.llbOptions.TabIndex = 38
        Me.llbOptions.TabStop = True
        Me.llbOptions.Text = "Options"
        '
        'lblPNR
        '
        Me.lblPNR.BackColor = System.Drawing.Color.Coral
        Me.lblPNR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPNR.Location = New System.Drawing.Point(643, 55)
        Me.lblPNR.Name = "lblPNR"
        Me.lblPNR.Size = New System.Drawing.Size(10, 16)
        Me.lblPNR.TabIndex = 29
        Me.lblPNR.Text = "."
        Me.lblPNR.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'lblPax
        '
        Me.lblPax.BackColor = System.Drawing.Color.Coral
        Me.lblPax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblPax.Location = New System.Drawing.Point(643, 68)
        Me.lblPax.Name = "lblPax"
        Me.lblPax.Size = New System.Drawing.Size(10, 16)
        Me.lblPax.TabIndex = 30
        Me.lblPax.Text = "."
        Me.lblPax.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'lblSegs
        '
        Me.lblSegs.BackColor = System.Drawing.Color.Coral
        Me.lblSegs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSegs.Location = New System.Drawing.Point(643, 81)
        Me.lblSegs.Name = "lblSegs"
        Me.lblSegs.Size = New System.Drawing.Size(10, 16)
        Me.lblSegs.TabIndex = 31
        Me.lblSegs.Text = "."
        Me.lblSegs.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'lstVessels
        '
        Me.lstVessels.FormattingEnabled = True
        Me.lstVessels.Location = New System.Drawing.Point(363, 91)
        Me.lstVessels.Name = "lstVessels"
        Me.lstVessels.Size = New System.Drawing.Size(265, 277)
        Me.lstVessels.TabIndex = 13
        '
        'lblCRM
        '
        Me.lblCRM.BackColor = System.Drawing.Color.Yellow
        Me.lblCRM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCRM.Location = New System.Drawing.Point(13, 264)
        Me.lblCRM.Name = "lblCRM"
        Me.lblCRM.Size = New System.Drawing.Size(148, 16)
        Me.lblCRM.TabIndex = 8
        Me.lblCRM.Text = "CRM - Invoicing Addresses"
        Me.lblCRM.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'lstSubDepartments
        '
        Me.lstSubDepartments.FormattingEnabled = True
        Me.lstSubDepartments.Location = New System.Drawing.Point(13, 193)
        Me.lstSubDepartments.Name = "lstSubDepartments"
        Me.lstSubDepartments.Size = New System.Drawing.Size(337, 69)
        Me.lstSubDepartments.TabIndex = 7
        '
        'txtCRM
        '
        Me.txtCRM.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtCRM.Location = New System.Drawing.Point(13, 277)
        Me.txtCRM.Name = "txtCRM"
        Me.txtCRM.Size = New System.Drawing.Size(337, 18)
        Me.txtCRM.TabIndex = 9
        '
        'txtVessel
        '
        Me.txtVessel.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtVessel.Location = New System.Drawing.Point(363, 71)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Size = New System.Drawing.Size(265, 18)
        Me.txtVessel.TabIndex = 12
        '
        'lstCRM
        '
        Me.lstCRM.FormattingEnabled = True
        Me.lstCRM.Location = New System.Drawing.Point(13, 299)
        Me.lstCRM.Name = "lstCRM"
        Me.lstCRM.Size = New System.Drawing.Size(337, 69)
        Me.lstCRM.TabIndex = 10
        '
        'txtSubdepartment
        '
        Me.txtSubdepartment.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtSubdepartment.Location = New System.Drawing.Point(13, 173)
        Me.txtSubdepartment.Name = "txtSubdepartment"
        Me.txtSubdepartment.Size = New System.Drawing.Size(337, 18)
        Me.txtSubdepartment.TabIndex = 6
        '
        'cmdOneTimeVessel
        '
        Me.cmdOneTimeVessel.Location = New System.Drawing.Point(345, 6)
        Me.cmdOneTimeVessel.Name = "cmdOneTimeVessel"
        Me.cmdOneTimeVessel.Size = New System.Drawing.Size(138, 35)
        Me.cmdOneTimeVessel.TabIndex = 14
        Me.cmdOneTimeVessel.Text = "One time Vessel for PNR"
        '
        'txtCustomer
        '
        Me.txtCustomer.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(13, 71)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(337, 18)
        Me.txtCustomer.TabIndex = 3
        '
        'lblReference
        '
        Me.lblReference.BackColor = System.Drawing.Color.Cyan
        Me.lblReference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblReference.Location = New System.Drawing.Point(640, 117)
        Me.lblReference.Name = "lblReference"
        Me.lblReference.Size = New System.Drawing.Size(60, 16)
        Me.lblReference.TabIndex = 15
        Me.lblReference.Text = "Reference"
        Me.lblReference.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'lblAirlinePoints
        '
        Me.lblAirlinePoints.BackColor = System.Drawing.Color.Silver
        Me.lblAirlinePoints.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblAirlinePoints.Location = New System.Drawing.Point(990, 117)
        Me.lblAirlinePoints.Name = "lblAirlinePoints"
        Me.lblAirlinePoints.Size = New System.Drawing.Size(79, 16)
        Me.lblAirlinePoints.TabIndex = 25
        Me.lblAirlinePoints.Text = "Airline Entries"
        Me.lblAirlinePoints.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'lblSubDepartment
        '
        Me.lblSubDepartment.BackColor = System.Drawing.Color.Yellow
        Me.lblSubDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSubDepartment.Location = New System.Drawing.Point(13, 160)
        Me.lblSubDepartment.Name = "lblSubDepartment"
        Me.lblSubDepartment.Size = New System.Drawing.Size(88, 16)
        Me.lblSubDepartment.TabIndex = 5
        Me.lblSubDepartment.Text = "SubDepartment"
        Me.lblSubDepartment.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'txtReference
        '
        Me.txtReference.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtReference.Location = New System.Drawing.Point(773, 120)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(207, 18)
        Me.txtReference.TabIndex = 16
        '
        'lblVessel
        '
        Me.lblVessel.BackColor = System.Drawing.Color.Yellow
        Me.lblVessel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblVessel.Location = New System.Drawing.Point(363, 55)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(42, 16)
        Me.lblVessel.TabIndex = 11
        Me.lblVessel.Text = "Vessel"
        Me.lblVessel.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'cmbBookedby
        '
        Me.cmbBookedby.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbBookedby.Location = New System.Drawing.Point(773, 190)
        Me.cmbBookedby.Name = "cmbBookedby"
        Me.cmbBookedby.Size = New System.Drawing.Size(207, 20)
        Me.cmbBookedby.TabIndex = 20
        '
        'lblCustomer
        '
        Me.lblCustomer.BackColor = System.Drawing.Color.Yellow
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCustomer.Location = New System.Drawing.Point(13, 55)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(57, 16)
        Me.lblCustomer.TabIndex = 2
        Me.lblCustomer.Text = "Customer"
        Me.lblCustomer.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'cmbDepartment
        '
        Me.cmbDepartment.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbDepartment.Location = New System.Drawing.Point(773, 155)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(207, 20)
        Me.cmbDepartment.TabIndex = 18
        '
        'cmdPNRWrite
        '
        Me.cmdPNRWrite.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNRWrite.Location = New System.Drawing.Point(491, 6)
        Me.cmdPNRWrite.Name = "cmdPNRWrite"
        Me.cmdPNRWrite.Size = New System.Drawing.Size(141, 35)
        Me.cmdPNRWrite.TabIndex = 35
        Me.cmdPNRWrite.Text = "Write to PNR"
        '
        'lblBookedByHighlight
        '
        Me.lblBookedByHighlight.BackColor = System.Drawing.Color.Pink
        Me.lblBookedByHighlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblBookedByHighlight.Location = New System.Drawing.Point(640, 187)
        Me.lblBookedByHighlight.Name = "lblBookedByHighlight"
        Me.lblBookedByHighlight.Size = New System.Drawing.Size(61, 16)
        Me.lblBookedByHighlight.TabIndex = 19
        Me.lblBookedByHighlight.Text = "Booked by"
        Me.lblBookedByHighlight.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'lblDepartmentHighlight
        '
        Me.lblDepartmentHighlight.BackColor = System.Drawing.Color.Pink
        Me.lblDepartmentHighlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblDepartmentHighlight.Location = New System.Drawing.Point(640, 152)
        Me.lblDepartmentHighlight.Name = "lblDepartmentHighlight"
        Me.lblDepartmentHighlight.Size = New System.Drawing.Size(68, 16)
        Me.lblDepartmentHighlight.TabIndex = 17
        Me.lblDepartmentHighlight.Text = "Department"
        Me.lblDepartmentHighlight.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'lstCustomers
        '
        Me.lstCustomers.FormattingEnabled = True
        Me.lstCustomers.Location = New System.Drawing.Point(13, 91)
        Me.lstCustomers.Name = "lstCustomers"
        Me.lstCustomers.Size = New System.Drawing.Size(337, 69)
        Me.lstCustomers.TabIndex = 4
        '
        'cmbReasonForTravel
        '
        Me.cmbReasonForTravel.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbReasonForTravel.Location = New System.Drawing.Point(773, 225)
        Me.cmbReasonForTravel.Name = "cmbReasonForTravel"
        Me.cmbReasonForTravel.Size = New System.Drawing.Size(207, 20)
        Me.cmbReasonForTravel.TabIndex = 22
        '
        'lblReasonForTravelHighLight
        '
        Me.lblReasonForTravelHighLight.BackColor = System.Drawing.Color.Pink
        Me.lblReasonForTravelHighLight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblReasonForTravelHighLight.Location = New System.Drawing.Point(640, 222)
        Me.lblReasonForTravelHighLight.Name = "lblReasonForTravelHighLight"
        Me.lblReasonForTravelHighLight.Size = New System.Drawing.Size(99, 16)
        Me.lblReasonForTravelHighLight.TabIndex = 21
        Me.lblReasonForTravelHighLight.Text = "Reason for Travel"
        Me.lblReasonForTravelHighLight.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'cmbCostCentre
        '
        Me.cmbCostCentre.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbCostCentre.Location = New System.Drawing.Point(773, 260)
        Me.cmbCostCentre.Name = "cmbCostCentre"
        Me.cmbCostCentre.Size = New System.Drawing.Size(207, 20)
        Me.cmbCostCentre.TabIndex = 24
        '
        'lblCostCentreHighlight
        '
        Me.lblCostCentreHighlight.BackColor = System.Drawing.Color.Pink
        Me.lblCostCentreHighlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblCostCentreHighlight.Location = New System.Drawing.Point(640, 257)
        Me.lblCostCentreHighlight.Name = "lblCostCentreHighlight"
        Me.lblCostCentreHighlight.Size = New System.Drawing.Size(69, 16)
        Me.lblCostCentreHighlight.TabIndex = 23
        Me.lblCostCentreHighlight.Text = "Cost Centre"
        Me.lblCostCentreHighlight.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'tabPNR
        '
        Me.tabPNR.Controls.Add(Me.tabPageFinisher)
        Me.tabPNR.Controls.Add(Me.tabPageItinerary)
        Me.tabPNR.Controls.Add(Me.tabOSM)
        Me.tabPNR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabPNR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.tabPNR.Location = New System.Drawing.Point(0, 0)
        Me.tabPNR.Name = "tabPNR"
        Me.tabPNR.SelectedPage = Me.tabPageFinisher
        Me.tabPNR.Size = New System.Drawing.Size(1396, 619)
        Me.tabPNR.TabIndex = 0
        CType(Me.tabPNR.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ShowItemPinButton = False
        CType(Me.tabPNR.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).StripButtons = Telerik.WinControls.UI.StripViewButtons.None
        CType(Me.tabPNR.GetChildAt(0), Telerik.WinControls.UI.RadPageViewStripElement).ShowItemCloseButton = False
        '
        'tabPageFinisher
        '
        Me.tabPageFinisher.Controls.Add(Me.cmdAdmin)
        Me.tabPageFinisher.Controls.Add(Me.cmdPNROnlyDocs)
        Me.tabPageFinisher.Controls.Add(Me.cmdPNRWriteWithDocs)
        Me.tabPageFinisher.Controls.Add(Me.txtAirlineEntries)
        Me.tabPageFinisher.Controls.Add(Me.lblSSRDocs)
        Me.tabPageFinisher.Controls.Add(Me.dgvApis)
        Me.tabPageFinisher.Controls.Add(Me.cmdAveragePrice)
        Me.tabPageFinisher.Controls.Add(Me.lblAveragePrice)
        Me.tabPageFinisher.Controls.Add(Me.lblAvPriceDetails)
        Me.tabPageFinisher.Controls.Add(Me.cmdCostCentre)
        Me.tabPageFinisher.Controls.Add(Me.cmdPNRReadAmadeusPNR)
        Me.tabPageFinisher.Controls.Add(Me.cmdExit)
        Me.tabPageFinisher.Controls.Add(Me.cmdOneTimeVessel)
        Me.tabPageFinisher.Controls.Add(Me.txtSubdepartment)
        Me.tabPageFinisher.Controls.Add(Me.txtCustomer)
        Me.tabPageFinisher.Controls.Add(Me.lblCostCentreHighlight)
        Me.tabPageFinisher.Controls.Add(Me.llbOptions)
        Me.tabPageFinisher.Controls.Add(Me.cmbCostCentre)
        Me.tabPageFinisher.Controls.Add(Me.cmdPNRWrite)
        Me.tabPageFinisher.Controls.Add(Me.lstCRM)
        Me.tabPageFinisher.Controls.Add(Me.lblSegs)
        Me.tabPageFinisher.Controls.Add(Me.txtVessel)
        Me.tabPageFinisher.Controls.Add(Me.lblReasonForTravelHighLight)
        Me.tabPageFinisher.Controls.Add(Me.txtCRM)
        Me.tabPageFinisher.Controls.Add(Me.lblPax)
        Me.tabPageFinisher.Controls.Add(Me.lstSubDepartments)
        Me.tabPageFinisher.Controls.Add(Me.cmbReasonForTravel)
        Me.tabPageFinisher.Controls.Add(Me.lblSubDepartment)
        Me.tabPageFinisher.Controls.Add(Me.lblPNR)
        Me.tabPageFinisher.Controls.Add(Me.lblCRM)
        Me.tabPageFinisher.Controls.Add(Me.lblDepartmentHighlight)
        Me.tabPageFinisher.Controls.Add(Me.lstVessels)
        Me.tabPageFinisher.Controls.Add(Me.lblVessel)
        Me.tabPageFinisher.Controls.Add(Me.lblBookedByHighlight)
        Me.tabPageFinisher.Controls.Add(Me.lstCustomers)
        Me.tabPageFinisher.Controls.Add(Me.lblCustomer)
        Me.tabPageFinisher.Controls.Add(Me.lblReference)
        Me.tabPageFinisher.Controls.Add(Me.cmbDepartment)
        Me.tabPageFinisher.Controls.Add(Me.lblAirlinePoints)
        Me.tabPageFinisher.Controls.Add(Me.cmbBookedby)
        Me.tabPageFinisher.Controls.Add(Me.txtReference)
        Me.tabPageFinisher.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.tabPageFinisher.ItemSize = New System.Drawing.SizeF(84.0!, 26.0!)
        Me.tabPageFinisher.Location = New System.Drawing.Point(10, 35)
        Me.tabPageFinisher.Name = "tabPageFinisher"
        Me.tabPageFinisher.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageFinisher.Size = New System.Drawing.Size(1375, 573)
        Me.tabPageFinisher.Text = "PNR Finisher"
        '
        'cmdAdmin
        '
        Me.cmdAdmin.Location = New System.Drawing.Point(1207, 27)
        Me.cmdAdmin.Name = "cmdAdmin"
        Me.cmdAdmin.Size = New System.Drawing.Size(63, 19)
        Me.cmdAdmin.TabIndex = 45
        Me.cmdAdmin.Text = "Admin"
        '
        'cmdPNROnlyDocs
        '
        Me.cmdPNROnlyDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNROnlyDocs.Location = New System.Drawing.Point(873, 6)
        Me.cmdPNROnlyDocs.Name = "cmdPNROnlyDocs"
        Me.cmdPNROnlyDocs.Size = New System.Drawing.Size(115, 35)
        Me.cmdPNROnlyDocs.TabIndex = 44
        Me.cmdPNROnlyDocs.Text = "Only DOCS"
        '
        'cmdPNRWriteWithDocs
        '
        Me.cmdPNRWriteWithDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdPNRWriteWithDocs.Location = New System.Drawing.Point(640, 6)
        Me.cmdPNRWriteWithDocs.Name = "cmdPNRWriteWithDocs"
        Me.cmdPNRWriteWithDocs.Size = New System.Drawing.Size(225, 35)
        Me.cmdPNRWriteWithDocs.TabIndex = 43
        Me.cmdPNRWriteWithDocs.Text = "Write to PNR with DOCS"
        '
        'txtAirlineEntries
        '
        Me.txtAirlineEntries.AutoSize = False
        Me.txtAirlineEntries.BackColor = System.Drawing.Color.Aqua
        Me.txtAirlineEntries.Font = New System.Drawing.Font("Courier New", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtAirlineEntries.ForeColor = System.Drawing.Color.Blue
        Me.txtAirlineEntries.Location = New System.Drawing.Point(990, 151)
        Me.txtAirlineEntries.Multiline = True
        Me.txtAirlineEntries.Name = "txtAirlineEntries"
        Me.txtAirlineEntries.Size = New System.Drawing.Size(280, 217)
        Me.txtAirlineEntries.TabIndex = 42
        '
        'lblSSRDocs
        '
        Me.lblSSRDocs.BackColor = System.Drawing.Color.Yellow
        Me.lblSSRDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblSSRDocs.Location = New System.Drawing.Point(13, 390)
        Me.lblSSRDocs.Name = "lblSSRDocs"
        Me.lblSSRDocs.Size = New System.Drawing.Size(67, 16)
        Me.lblSSRDocs.TabIndex = 41
        Me.lblSSRDocs.Text = "SSR DOCS"
        Me.lblSSRDocs.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'dgvApis
        '
        Me.dgvApis.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvApis.Location = New System.Drawing.Point(13, 406)
        '
        '
        '
        Me.dgvApis.MasterTemplate.AllowAddNewRow = False
        Me.dgvApis.MasterTemplate.AllowDeleteRow = False
        Me.dgvApis.MasterTemplate.AllowDragToGroup = False
        Me.dgvApis.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        Me.dgvApis.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect
        Me.dgvApis.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvApis.Name = "dgvApis"
        Me.dgvApis.Size = New System.Drawing.Size(1257, 179)
        Me.dgvApis.TabIndex = 40
        '
        'cmdAveragePrice
        '
        Me.cmdAveragePrice.Location = New System.Drawing.Point(990, 55)
        Me.cmdAveragePrice.Name = "cmdAveragePrice"
        Me.cmdAveragePrice.Size = New System.Drawing.Size(61, 39)
        Me.cmdAveragePrice.TabIndex = 32
        Me.cmdAveragePrice.Text = "Average Price"
        '
        'lblAveragePrice
        '
        Me.lblAveragePrice.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAveragePrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblAveragePrice.Location = New System.Drawing.Point(1064, 77)
        Me.lblAveragePrice.Name = "lblAveragePrice"
        Me.lblAveragePrice.Size = New System.Drawing.Size(2, 2)
        Me.lblAveragePrice.TabIndex = 34
        Me.lblAveragePrice.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'lblAvPriceDetails
        '
        Me.lblAvPriceDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAvPriceDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblAvPriceDetails.Location = New System.Drawing.Point(1064, 55)
        Me.lblAvPriceDetails.Name = "lblAvPriceDetails"
        Me.lblAvPriceDetails.Size = New System.Drawing.Size(80, 16)
        Me.lblAvPriceDetails.TabIndex = 33
        Me.lblAvPriceDetails.Text = "Average Price"
        Me.lblAvPriceDetails.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'cmdCostCentre
        '
        Me.cmdCostCentre.Location = New System.Drawing.Point(157, 6)
        Me.cmdCostCentre.Name = "cmdCostCentre"
        Me.cmdCostCentre.Size = New System.Drawing.Size(180, 35)
        Me.cmdCostCentre.TabIndex = 36
        Me.cmdCostCentre.Text = "Client Group Cost Centre Lookup"
        '
        'tabPageItinerary
        '
        Me.tabPageItinerary.Controls.Add(Me.cmdItnFormatOSMLoG)
        Me.tabPageItinerary.Controls.Add(Me.RadGroupBox2)
        Me.tabPageItinerary.Controls.Add(Me.RadGroupBox1)
        Me.tabPageItinerary.Controls.Add(Me.webItnDoc)
        Me.tabPageItinerary.Controls.Add(Me.lblItnPNRCounter)
        Me.tabPageItinerary.Controls.Add(Me.cmdItnRefresh)
        Me.tabPageItinerary.Controls.Add(Me.fraItnFormat)
        Me.tabPageItinerary.Controls.Add(Me.cmdItnExit)
        Me.tabPageItinerary.Controls.Add(Me.lstItnRemarks)
        Me.tabPageItinerary.Controls.Add(Me.lblItnRemarks)
        Me.tabPageItinerary.Controls.Add(Me.fraItnAirportName)
        Me.tabPageItinerary.Controls.Add(Me.fraItnOptions)
        Me.tabPageItinerary.Controls.Add(Me.rtbItnDoc)
        Me.tabPageItinerary.Controls.Add(Me.txtItnPNR)
        Me.tabPageItinerary.Controls.Add(Me.lblItnPNR)
        Me.tabPageItinerary.ItemSize = New System.Drawing.SizeF(84.0!, 26.0!)
        Me.tabPageItinerary.Location = New System.Drawing.Point(10, 35)
        Me.tabPageItinerary.Name = "tabPageItinerary"
        Me.tabPageItinerary.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageItinerary.Size = New System.Drawing.Size(1375, 573)
        Me.tabPageItinerary.Text = "PNR Itinerary"
        '
        'cmdItnFormatOSMLoG
        '
        Me.cmdItnFormatOSMLoG.Location = New System.Drawing.Point(615, 20)
        Me.cmdItnFormatOSMLoG.Name = "cmdItnFormatOSMLoG"
        Me.cmdItnFormatOSMLoG.Size = New System.Drawing.Size(108, 21)
        Me.cmdItnFormatOSMLoG.TabIndex = 19
        Me.cmdItnFormatOSMLoG.Text = "OSM LoG"
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox2.Controls.Add(Me.cmdItn1GReadCurrent)
        Me.RadGroupBox2.Controls.Add(Me.cmdItn1GReadPNR)
        Me.RadGroupBox2.Controls.Add(Me.cmdItn1GReadQueue)
        Me.RadGroupBox2.HeaderText = "Galileo"
        Me.RadGroupBox2.Location = New System.Drawing.Point(306, 6)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Size = New System.Drawing.Size(289, 46)
        Me.RadGroupBox2.TabIndex = 18
        Me.RadGroupBox2.Text = "Galileo"
        '
        'cmdItn1GReadCurrent
        '
        Me.cmdItn1GReadCurrent.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItn1GReadCurrent.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItn1GReadCurrent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItn1GReadCurrent.Location = New System.Drawing.Point(85, 14)
        Me.cmdItn1GReadCurrent.Name = "cmdItn1GReadCurrent"
        Me.cmdItn1GReadCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItn1GReadCurrent.Size = New System.Drawing.Size(99, 21)
        Me.cmdItn1GReadCurrent.TabIndex = 1
        Me.cmdItn1GReadCurrent.Text = "Read Current"
        '
        'cmdItn1GReadPNR
        '
        Me.cmdItn1GReadPNR.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItn1GReadPNR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItn1GReadPNR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItn1GReadPNR.Location = New System.Drawing.Point(6, 14)
        Me.cmdItn1GReadPNR.Name = "cmdItn1GReadPNR"
        Me.cmdItn1GReadPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItn1GReadPNR.Size = New System.Drawing.Size(73, 21)
        Me.cmdItn1GReadPNR.TabIndex = 0
        Me.cmdItn1GReadPNR.Text = "Read PNR"
        '
        'cmdItn1GReadQueue
        '
        Me.cmdItn1GReadQueue.Location = New System.Drawing.Point(190, 14)
        Me.cmdItn1GReadQueue.Name = "cmdItn1GReadQueue"
        Me.cmdItn1GReadQueue.Size = New System.Drawing.Size(73, 21)
        Me.cmdItn1GReadQueue.TabIndex = 13
        Me.cmdItn1GReadQueue.Text = "Read Queue"
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.Controls.Add(Me.cmdItn1AReadCurrent)
        Me.RadGroupBox1.Controls.Add(Me.cmdItn1AReadPNR)
        Me.RadGroupBox1.Controls.Add(Me.cmdItn1AReadQueue)
        Me.RadGroupBox1.HeaderText = "Amadeus"
        Me.RadGroupBox1.Location = New System.Drawing.Point(11, 6)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Size = New System.Drawing.Size(289, 46)
        Me.RadGroupBox1.TabIndex = 17
        Me.RadGroupBox1.Text = "Amadeus"
        '
        'cmdItn1AReadCurrent
        '
        Me.cmdItn1AReadCurrent.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItn1AReadCurrent.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItn1AReadCurrent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItn1AReadCurrent.Location = New System.Drawing.Point(85, 14)
        Me.cmdItn1AReadCurrent.Name = "cmdItn1AReadCurrent"
        Me.cmdItn1AReadCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItn1AReadCurrent.Size = New System.Drawing.Size(99, 21)
        Me.cmdItn1AReadCurrent.TabIndex = 1
        Me.cmdItn1AReadCurrent.Text = "Read Current"
        '
        'cmdItn1AReadPNR
        '
        Me.cmdItn1AReadPNR.BackColor = System.Drawing.SystemColors.Control
        Me.cmdItn1AReadPNR.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdItn1AReadPNR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdItn1AReadPNR.Location = New System.Drawing.Point(6, 14)
        Me.cmdItn1AReadPNR.Name = "cmdItn1AReadPNR"
        Me.cmdItn1AReadPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdItn1AReadPNR.Size = New System.Drawing.Size(73, 21)
        Me.cmdItn1AReadPNR.TabIndex = 0
        Me.cmdItn1AReadPNR.Text = "Read PNR"
        '
        'cmdItn1AReadQueue
        '
        Me.cmdItn1AReadQueue.Location = New System.Drawing.Point(190, 14)
        Me.cmdItn1AReadQueue.Name = "cmdItn1AReadQueue"
        Me.cmdItn1AReadQueue.Size = New System.Drawing.Size(73, 21)
        Me.cmdItn1AReadQueue.TabIndex = 13
        Me.cmdItn1AReadQueue.Text = "Read Queue"
        '
        'webItnDoc
        '
        Me.webItnDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webItnDoc.Location = New System.Drawing.Point(971, 20)
        Me.webItnDoc.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webItnDoc.Name = "webItnDoc"
        Me.webItnDoc.Size = New System.Drawing.Size(20, 20)
        Me.webItnDoc.TabIndex = 16
        Me.webItnDoc.Visible = False
        '
        'lblItnPNRCounter
        '
        Me.lblItnPNRCounter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblItnPNRCounter.BackColor = System.Drawing.Color.Aqua
        Me.lblItnPNRCounter.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblItnPNRCounter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblItnPNRCounter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblItnPNRCounter.Location = New System.Drawing.Point(13, 549)
        Me.lblItnPNRCounter.Name = "lblItnPNRCounter"
        Me.lblItnPNRCounter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblItnPNRCounter.Size = New System.Drawing.Size(30, 16)
        Me.lblItnPNRCounter.TabIndex = 15
        Me.lblItnPNRCounter.Text = "PNR"
        Me.lblItnPNRCounter.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'cmdItnRefresh
        '
        Me.cmdItnRefresh.Enabled = False
        Me.cmdItnRefresh.Location = New System.Drawing.Point(759, 20)
        Me.cmdItnRefresh.Name = "cmdItnRefresh"
        Me.cmdItnRefresh.Size = New System.Drawing.Size(80, 21)
        Me.cmdItnRefresh.TabIndex = 14
        Me.cmdItnRefresh.Text = "Refresh"
        '
        'fraItnFormat
        '
        Me.fraItnFormat.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.fraItnFormat.Controls.Add(Me.optItnFormatSeaChefsWith3LetterCode)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatEuronav)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatMSReport)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatSeaChefs)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatPlain)
        Me.fraItnFormat.Controls.Add(Me.optItnFormatDefault)
        Me.fraItnFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.fraItnFormat.HeaderText = "Custom Format"
        Me.fraItnFormat.Location = New System.Drawing.Point(333, 58)
        Me.fraItnFormat.Name = "fraItnFormat"
        Me.fraItnFormat.Size = New System.Drawing.Size(265, 130)
        Me.fraItnFormat.TabIndex = 5
        Me.fraItnFormat.TabStop = False
        Me.fraItnFormat.Text = "Custom Format"
        '
        'optItnFormatSeaChefsWith3LetterCode
        '
        Me.optItnFormatSeaChefsWith3LetterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatSeaChefsWith3LetterCode.Location = New System.Drawing.Point(17, 71)
        Me.optItnFormatSeaChefsWith3LetterCode.Name = "optItnFormatSeaChefsWith3LetterCode"
        Me.optItnFormatSeaChefsWith3LetterCode.Size = New System.Drawing.Size(161, 16)
        Me.optItnFormatSeaChefsWith3LetterCode.TabIndex = 7
        Me.optItnFormatSeaChefsWith3LetterCode.Text = "Sea Chefs with 3 letter code"
        '
        'optItnFormatEuronav
        '
        Me.optItnFormatEuronav.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatEuronav.Location = New System.Drawing.Point(17, 88)
        Me.optItnFormatEuronav.Name = "optItnFormatEuronav"
        Me.optItnFormatEuronav.Size = New System.Drawing.Size(62, 16)
        Me.optItnFormatEuronav.TabIndex = 6
        Me.optItnFormatEuronav.Text = "Euronav"
        '
        'optItnFormatMSReport
        '
        Me.optItnFormatMSReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatMSReport.Location = New System.Drawing.Point(17, 105)
        Me.optItnFormatMSReport.Name = "optItnFormatMSReport"
        Me.optItnFormatMSReport.Size = New System.Drawing.Size(74, 16)
        Me.optItnFormatMSReport.TabIndex = 5
        Me.optItnFormatMSReport.Text = "MS Report"
        '
        'optItnFormatSeaChefs
        '
        Me.optItnFormatSeaChefs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatSeaChefs.Location = New System.Drawing.Point(17, 54)
        Me.optItnFormatSeaChefs.Name = "optItnFormatSeaChefs"
        Me.optItnFormatSeaChefs.Size = New System.Drawing.Size(73, 16)
        Me.optItnFormatSeaChefs.TabIndex = 2
        Me.optItnFormatSeaChefs.Text = "Sea Chefs"
        '
        'optItnFormatPlain
        '
        Me.optItnFormatPlain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatPlain.Location = New System.Drawing.Point(17, 37)
        Me.optItnFormatPlain.Name = "optItnFormatPlain"
        Me.optItnFormatPlain.Size = New System.Drawing.Size(45, 16)
        Me.optItnFormatPlain.TabIndex = 1
        Me.optItnFormatPlain.Text = "Plain"
        '
        'optItnFormatDefault
        '
        Me.optItnFormatDefault.CheckState = System.Windows.Forms.CheckState.Checked
        Me.optItnFormatDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnFormatDefault.Location = New System.Drawing.Point(17, 20)
        Me.optItnFormatDefault.Name = "optItnFormatDefault"
        Me.optItnFormatDefault.Size = New System.Drawing.Size(56, 16)
        Me.optItnFormatDefault.TabIndex = 0
        Me.optItnFormatDefault.Text = "Default"
        Me.optItnFormatDefault.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'cmdItnExit
        '
        Me.cmdItnExit.Location = New System.Drawing.Point(843, 20)
        Me.cmdItnExit.Name = "cmdItnExit"
        Me.cmdItnExit.Size = New System.Drawing.Size(80, 21)
        Me.cmdItnExit.TabIndex = 12
        Me.cmdItnExit.Text = "Exit"
        '
        'lstItnRemarks
        '
        Me.lstItnRemarks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstItnRemarks.CheckOnClickMode = Telerik.WinControls.UI.CheckOnClickMode.FirstClick
        Me.lstItnRemarks.ItemSize = New System.Drawing.Size(100, 18)
        Me.lstItnRemarks.Location = New System.Drawing.Point(610, 65)
        Me.lstItnRemarks.Name = "lstItnRemarks"
        Me.lstItnRemarks.Size = New System.Drawing.Size(731, 109)
        Me.lstItnRemarks.TabIndex = 8
        '
        'lblItnRemarks
        '
        Me.lblItnRemarks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblItnRemarks.BackColor = System.Drawing.Color.Yellow
        Me.lblItnRemarks.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblItnRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblItnRemarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblItnRemarks.Location = New System.Drawing.Point(610, 48)
        Me.lblItnRemarks.Name = "lblItnRemarks"
        Me.lblItnRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblItnRemarks.Size = New System.Drawing.Size(53, 16)
        Me.lblItnRemarks.TabIndex = 7
        Me.lblItnRemarks.Text = "Remarks"
        Me.lblItnRemarks.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'fraItnAirportName
        '
        Me.fraItnAirportName.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportCityBoth)
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportCityName)
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportBoth)
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportname)
        Me.fraItnAirportName.Controls.Add(Me.optItnAirportCode)
        Me.fraItnAirportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.fraItnAirportName.HeaderText = "Airport Name"
        Me.fraItnAirportName.Location = New System.Drawing.Point(172, 58)
        Me.fraItnAirportName.Name = "fraItnAirportName"
        Me.fraItnAirportName.Size = New System.Drawing.Size(137, 118)
        Me.fraItnAirportName.TabIndex = 4
        Me.fraItnAirportName.TabStop = False
        Me.fraItnAirportName.Text = "Airport Name"
        '
        'optItnAirportCityBoth
        '
        Me.optItnAirportCityBoth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportCityBoth.Location = New System.Drawing.Point(7, 95)
        Me.optItnAirportCityBoth.Name = "optItnAirportCityBoth"
        Me.optItnAirportCityBoth.Size = New System.Drawing.Size(109, 16)
        Me.optItnAirportCityBoth.TabIndex = 4
        Me.optItnAirportCityBoth.Text = "Code / City Name"
        '
        'optItnAirportCityName
        '
        Me.optItnAirportCityName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportCityName.Location = New System.Drawing.Point(7, 79)
        Me.optItnAirportCityName.Name = "optItnAirportCityName"
        Me.optItnAirportCityName.Size = New System.Drawing.Size(94, 16)
        Me.optItnAirportCityName.TabIndex = 3
        Me.optItnAirportCityName.Text = "Full City Name"
        '
        'optItnAirportBoth
        '
        Me.optItnAirportBoth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportBoth.Location = New System.Drawing.Point(6, 62)
        Me.optItnAirportBoth.Name = "optItnAirportBoth"
        Me.optItnAirportBoth.Size = New System.Drawing.Size(123, 16)
        Me.optItnAirportBoth.TabIndex = 2
        Me.optItnAirportBoth.Text = "Code / Airport Name"
        '
        'optItnAirportname
        '
        Me.optItnAirportname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportname.Location = New System.Drawing.Point(6, 45)
        Me.optItnAirportname.Name = "optItnAirportname"
        Me.optItnAirportname.Size = New System.Drawing.Size(108, 16)
        Me.optItnAirportname.TabIndex = 1
        Me.optItnAirportname.Text = "Full Airport Name"
        '
        'optItnAirportCode
        '
        Me.optItnAirportCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.optItnAirportCode.Location = New System.Drawing.Point(6, 28)
        Me.optItnAirportCode.Name = "optItnAirportCode"
        Me.optItnAirportCode.Size = New System.Drawing.Size(89, 16)
        Me.optItnAirportCode.TabIndex = 0
        Me.optItnAirportCode.Text = "3 Letter Code"
        '
        'fraItnOptions
        '
        Me.fraItnOptions.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.fraItnOptions.Controls.Add(Me.chkItnCostCentre)
        Me.fraItnOptions.Controls.Add(Me.chkItnFlyingTime)
        Me.fraItnOptions.Controls.Add(Me.lblItnTextToBeAdded)
        Me.fraItnOptions.Controls.Add(Me.chkItnSeating)
        Me.fraItnOptions.Controls.Add(Me.chkItnUSAText)
        Me.fraItnOptions.Controls.Add(Me.chkItnStopovers)
        Me.fraItnOptions.Controls.Add(Me.chkItnBrazilText)
        Me.fraItnOptions.Controls.Add(Me.chkItnTerminal)
        Me.fraItnOptions.Controls.Add(Me.chkItnElecItemsBan)
        Me.fraItnOptions.Controls.Add(Me.chkItnPaxSegPerTicket)
        Me.fraItnOptions.Controls.Add(Me.chkItnTickets)
        Me.fraItnOptions.Controls.Add(Me.chkItnClass)
        Me.fraItnOptions.Controls.Add(Me.chkItnVessel)
        Me.fraItnOptions.Controls.Add(Me.chkItnAirlineLocator)
        Me.fraItnOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.fraItnOptions.HeaderText = "Options"
        Me.fraItnOptions.Location = New System.Drawing.Point(172, 194)
        Me.fraItnOptions.Name = "fraItnOptions"
        Me.fraItnOptions.Size = New System.Drawing.Size(137, 391)
        Me.fraItnOptions.TabIndex = 6
        Me.fraItnOptions.TabStop = False
        Me.fraItnOptions.Text = "Options"
        '
        'chkItnCostCentre
        '
        Me.chkItnCostCentre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnCostCentre.Location = New System.Drawing.Point(7, 249)
        Me.chkItnCostCentre.Name = "chkItnCostCentre"
        Me.chkItnCostCentre.Size = New System.Drawing.Size(80, 16)
        Me.chkItnCostCentre.TabIndex = 13
        Me.chkItnCostCentre.Text = "Cost Centre"
        '
        'chkItnFlyingTime
        '
        Me.chkItnFlyingTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnFlyingTime.Location = New System.Drawing.Point(6, 226)
        Me.chkItnFlyingTime.Name = "chkItnFlyingTime"
        Me.chkItnFlyingTime.Size = New System.Drawing.Size(79, 16)
        Me.chkItnFlyingTime.TabIndex = 12
        Me.chkItnFlyingTime.Text = "Flying Time"
        '
        'lblItnTextToBeAdded
        '
        Me.lblItnTextToBeAdded.Location = New System.Drawing.Point(6, 270)
        Me.lblItnTextToBeAdded.Name = "lblItnTextToBeAdded"
        Me.lblItnTextToBeAdded.Size = New System.Drawing.Size(103, 18)
        Me.lblItnTextToBeAdded.TabIndex = 8
        Me.lblItnTextToBeAdded.Text = "TEXT TO BE ADDED"
        '
        'chkItnSeating
        '
        Me.chkItnSeating.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnSeating.Location = New System.Drawing.Point(6, 153)
        Me.chkItnSeating.Name = "chkItnSeating"
        Me.chkItnSeating.Size = New System.Drawing.Size(120, 16)
        Me.chkItnSeating.TabIndex = 5
        Me.chkItnSeating.Text = "Seating assignment"
        '
        'chkItnUSAText
        '
        Me.chkItnUSAText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnUSAText.Location = New System.Drawing.Point(6, 343)
        Me.chkItnUSAText.Name = "chkItnUSAText"
        Me.chkItnUSAText.Size = New System.Drawing.Size(69, 16)
        Me.chkItnUSAText.TabIndex = 11
        Me.chkItnUSAText.Text = "USA Text"
        Me.ttpToolTip.SetToolTip(Me.chkItnUSAText, resources.GetString("chkItnUSAText.ToolTip"))
        '
        'chkItnStopovers
        '
        Me.chkItnStopovers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnStopovers.Location = New System.Drawing.Point(6, 203)
        Me.chkItnStopovers.Name = "chkItnStopovers"
        Me.chkItnStopovers.Size = New System.Drawing.Size(101, 16)
        Me.chkItnStopovers.TabIndex = 7
        Me.chkItnStopovers.Text = "Show stopovers"
        '
        'chkItnBrazilText
        '
        Me.chkItnBrazilText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnBrazilText.Location = New System.Drawing.Point(6, 318)
        Me.chkItnBrazilText.Name = "chkItnBrazilText"
        Me.chkItnBrazilText.Size = New System.Drawing.Size(81, 16)
        Me.chkItnBrazilText.TabIndex = 10
        Me.chkItnBrazilText.Text = "BRAZIL text"
        Me.ttpToolTip.SetToolTip(Me.chkItnBrazilText, resources.GetString("chkItnBrazilText.ToolTip"))
        '
        'chkItnTerminal
        '
        Me.chkItnTerminal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnTerminal.Location = New System.Drawing.Point(6, 178)
        Me.chkItnTerminal.Name = "chkItnTerminal"
        Me.chkItnTerminal.Size = New System.Drawing.Size(92, 16)
        Me.chkItnTerminal.TabIndex = 6
        Me.chkItnTerminal.Text = "Show terminal"
        '
        'chkItnElecItemsBan
        '
        Me.chkItnElecItemsBan.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.chkItnElecItemsBan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnElecItemsBan.Location = New System.Drawing.Point(6, 295)
        Me.chkItnElecItemsBan.Name = "chkItnElecItemsBan"
        Me.chkItnElecItemsBan.Size = New System.Drawing.Size(128, 16)
        Me.chkItnElecItemsBan.TabIndex = 9
        Me.chkItnElecItemsBan.Text = "2017 Elec. Items Ban"
        Me.ttpToolTip.SetToolTip(Me.chkItnElecItemsBan, resources.GetString("chkItnElecItemsBan.ToolTip"))
        '
        'chkItnPaxSegPerTicket
        '
        Me.chkItnPaxSegPerTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnPaxSegPerTicket.Location = New System.Drawing.Point(6, 128)
        Me.chkItnPaxSegPerTicket.Name = "chkItnPaxSegPerTicket"
        Me.chkItnPaxSegPerTicket.Size = New System.Drawing.Size(112, 16)
        Me.chkItnPaxSegPerTicket.TabIndex = 4
        Me.chkItnPaxSegPerTicket.Text = "Pax/Seg per ticket"
        '
        'chkItnTickets
        '
        Me.chkItnTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnTickets.Location = New System.Drawing.Point(6, 103)
        Me.chkItnTickets.Name = "chkItnTickets"
        Me.chkItnTickets.Size = New System.Drawing.Size(56, 16)
        Me.chkItnTickets.TabIndex = 3
        Me.chkItnTickets.Text = "Tickets"
        '
        'chkItnClass
        '
        Me.chkItnClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnClass.Location = New System.Drawing.Point(6, 53)
        Me.chkItnClass.Name = "chkItnClass"
        Me.chkItnClass.Size = New System.Drawing.Size(102, 16)
        Me.chkItnClass.TabIndex = 1
        Me.chkItnClass.Text = "Class of Service"
        '
        'chkItnVessel
        '
        Me.chkItnVessel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnVessel.Location = New System.Drawing.Point(6, 28)
        Me.chkItnVessel.Name = "chkItnVessel"
        Me.chkItnVessel.Size = New System.Drawing.Size(54, 16)
        Me.chkItnVessel.TabIndex = 0
        Me.chkItnVessel.Text = "Vessel"
        '
        'chkItnAirlineLocator
        '
        Me.chkItnAirlineLocator.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.chkItnAirlineLocator.Location = New System.Drawing.Point(6, 78)
        Me.chkItnAirlineLocator.Name = "chkItnAirlineLocator"
        Me.chkItnAirlineLocator.Size = New System.Drawing.Size(93, 16)
        Me.chkItnAirlineLocator.TabIndex = 2
        Me.chkItnAirlineLocator.Text = "Airline Locator"
        '
        'rtbItnDoc
        '
        Me.rtbItnDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbItnDoc.ContextMenuStrip = Me.menuITNSelectCopy
        Me.rtbItnDoc.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.rtbItnDoc.Location = New System.Drawing.Point(315, 194)
        Me.rtbItnDoc.Name = "rtbItnDoc"
        Me.rtbItnDoc.Size = New System.Drawing.Size(1026, 371)
        Me.rtbItnDoc.TabIndex = 11
        Me.rtbItnDoc.Text = ""
        '
        'menuITNSelectCopy
        '
        Me.menuITNSelectCopy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuCopyItn})
        Me.menuITNSelectCopy.Name = "menuSelectCopy"
        Me.menuITNSelectCopy.Size = New System.Drawing.Size(149, 26)
        '
        'MenuCopyItn
        '
        Me.MenuCopyItn.Name = "MenuCopyItn"
        Me.MenuCopyItn.Size = New System.Drawing.Size(148, 22)
        Me.MenuCopyItn.Text = "Copy Itinerary"
        '
        'txtItnPNR
        '
        Me.txtItnPNR.AcceptsReturn = True
        Me.txtItnPNR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtItnPNR.AutoSize = False
        Me.txtItnPNR.BackColor = System.Drawing.SystemColors.Window
        Me.txtItnPNR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtItnPNR.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtItnPNR.Location = New System.Drawing.Point(16, 74)
        Me.txtItnPNR.MaxLength = 0
        Me.txtItnPNR.Multiline = True
        Me.txtItnPNR.Name = "txtItnPNR"
        Me.txtItnPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtItnPNR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtItnPNR.Size = New System.Drawing.Size(134, 475)
        Me.txtItnPNR.TabIndex = 3
        '
        'lblItnPNR
        '
        Me.lblItnPNR.BackColor = System.Drawing.Color.Yellow
        Me.lblItnPNR.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblItnPNR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblItnPNR.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblItnPNR.Location = New System.Drawing.Point(13, 58)
        Me.lblItnPNR.Name = "lblItnPNR"
        Me.lblItnPNR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblItnPNR.Size = New System.Drawing.Size(31, 16)
        Me.lblItnPNR.TabIndex = 2
        Me.lblItnPNR.Text = "PNR"
        Me.lblItnPNR.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'tabOSM
        '
        Me.tabOSM.Controls.Add(Me.Label2)
        Me.tabOSM.Controls.Add(Me.cmbOSMVesselGroup)
        Me.tabOSM.Controls.Add(Me.chkOSMVesselInUse)
        Me.tabOSM.Controls.Add(Me.lblOSMMultipleSearchSeparator)
        Me.tabOSM.Controls.Add(Me.txtOSMAgentsFilter)
        Me.tabOSM.Controls.Add(Me.cmdOSMClearSelected)
        Me.tabOSM.Controls.Add(Me.cmdOSMEmailClear)
        Me.tabOSM.Controls.Add(Me.webOSMDoc)
        Me.tabOSM.Controls.Add(Me.lstOSMVessels)
        Me.tabOSM.Controls.Add(Me.cmdOSMCopyDocument)
        Me.tabOSM.Controls.Add(Me.cmdOSMPrepareDoc)
        Me.tabOSM.Controls.Add(Me.dgvOSMPax)
        Me.tabOSM.Controls.Add(Me.lblOSMPasteEmailsHere)
        Me.tabOSM.Controls.Add(Me.txtOSMPax)
        Me.tabOSM.Controls.Add(Me.lblOSMVessel)
        Me.tabOSM.Controls.Add(Me.cmdOSMVesselsEdit)
        Me.tabOSM.Controls.Add(Me.lblOSMVessels)
        Me.tabOSM.Controls.Add(Me.cmdOSMAgentEdit)
        Me.tabOSM.Controls.Add(Me.lblOSMAgents)
        Me.tabOSM.Controls.Add(Me.lstOSMAgents)
        Me.tabOSM.Controls.Add(Me.cmdOSMCopyCC)
        Me.tabOSM.Controls.Add(Me.cmdOSMCopyTo)
        Me.tabOSM.Controls.Add(Me.lblOSMEmailsCC)
        Me.tabOSM.Controls.Add(Me.lblOSMEmailsTo)
        Me.tabOSM.Controls.Add(Me.lstOSMCCEmail)
        Me.tabOSM.Controls.Add(Me.lstOSMToEmail)
        Me.tabOSM.Controls.Add(Me.cmdOSMRefresh)
        Me.tabOSM.ItemSize = New System.Drawing.SizeF(42.0!, 26.0!)
        Me.tabOSM.Location = New System.Drawing.Point(10, 35)
        Me.tabOSM.Name = "tabOSM"
        Me.tabOSM.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOSM.Size = New System.Drawing.Size(1375, 573)
        Me.tabOSM.Text = "OSM"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Vessel Group"
        Me.Label2.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'cmbOSMVesselGroup
        '
        Me.cmbOSMVesselGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOSMVesselGroup.FormattingEnabled = True
        Me.cmbOSMVesselGroup.Location = New System.Drawing.Point(18, 67)
        Me.cmbOSMVesselGroup.Name = "cmbOSMVesselGroup"
        Me.cmbOSMVesselGroup.Size = New System.Drawing.Size(193, 21)
        Me.cmbOSMVesselGroup.TabIndex = 26
        '
        'chkOSMVesselInUse
        '
        Me.chkOSMVesselInUse.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOSMVesselInUse.Location = New System.Drawing.Point(18, 121)
        Me.chkOSMVesselInUse.Name = "chkOSMVesselInUse"
        Me.chkOSMVesselInUse.Size = New System.Drawing.Size(77, 18)
        Me.chkOSMVesselInUse.TabIndex = 24
        Me.chkOSMVesselInUse.Text = "In Use Only"
        Me.chkOSMVesselInUse.ToggleState = Telerik.WinControls.Enumerations.ToggleState.[On]
        '
        'lblOSMMultipleSearchSeparator
        '
        Me.lblOSMMultipleSearchSeparator.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOSMMultipleSearchSeparator.Location = New System.Drawing.Point(217, 317)
        Me.lblOSMMultipleSearchSeparator.Name = "lblOSMMultipleSearchSeparator"
        Me.lblOSMMultipleSearchSeparator.Size = New System.Drawing.Size(121, 12)
        Me.lblOSMMultipleSearchSeparator.TabIndex = 23
        Me.lblOSMMultipleSearchSeparator.Text = "Multiple search separated with |"
        '
        'txtOSMAgentsFilter
        '
        Me.txtOSMAgentsFilter.Location = New System.Drawing.Point(217, 294)
        Me.txtOSMAgentsFilter.Name = "txtOSMAgentsFilter"
        Me.txtOSMAgentsFilter.Size = New System.Drawing.Size(166, 20)
        Me.txtOSMAgentsFilter.TabIndex = 22
        '
        'cmdOSMClearSelected
        '
        Me.cmdOSMClearSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOSMClearSelected.Location = New System.Drawing.Point(18, 515)
        Me.cmdOSMClearSelected.Name = "cmdOSMClearSelected"
        Me.cmdOSMClearSelected.Size = New System.Drawing.Size(483, 30)
        Me.cmdOSMClearSelected.TabIndex = 21
        Me.cmdOSMClearSelected.Text = "Clear Selected Vessel(s) and/or Agent(s)"
        '
        'cmdOSMEmailClear
        '
        Me.cmdOSMEmailClear.BackColor = System.Drawing.Color.Red
        Me.cmdOSMEmailClear.Location = New System.Drawing.Point(768, 54)
        Me.cmdOSMEmailClear.Name = "cmdOSMEmailClear"
        Me.cmdOSMEmailClear.Size = New System.Drawing.Size(21, 13)
        Me.cmdOSMEmailClear.TabIndex = 15
        Me.cmdOSMEmailClear.Text = "X"
        '
        'webOSMDoc
        '
        Me.webOSMDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webOSMDoc.Location = New System.Drawing.Point(508, 437)
        Me.webOSMDoc.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webOSMDoc.Name = "webOSMDoc"
        Me.webOSMDoc.Size = New System.Drawing.Size(820, 108)
        Me.webOSMDoc.TabIndex = 20
        '
        'lstOSMVessels
        '
        Me.lstOSMVessels.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstOSMVessels.FormattingEnabled = True
        Me.lstOSMVessels.Location = New System.Drawing.Point(18, 146)
        Me.lstOSMVessels.Name = "lstOSMVessels"
        Me.lstOSMVessels.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstOSMVessels.Size = New System.Drawing.Size(193, 342)
        Me.lstOSMVessels.TabIndex = 3
        '
        'cmdOSMCopyDocument
        '
        Me.cmdOSMCopyDocument.Enabled = False
        Me.cmdOSMCopyDocument.Location = New System.Drawing.Point(627, 405)
        Me.cmdOSMCopyDocument.Name = "cmdOSMCopyDocument"
        Me.cmdOSMCopyDocument.Size = New System.Drawing.Size(113, 30)
        Me.cmdOSMCopyDocument.TabIndex = 19
        Me.cmdOSMCopyDocument.Text = "Copy Document"
        '
        'cmdOSMPrepareDoc
        '
        Me.cmdOSMPrepareDoc.Location = New System.Drawing.Point(508, 405)
        Me.cmdOSMPrepareDoc.Name = "cmdOSMPrepareDoc"
        Me.cmdOSMPrepareDoc.Size = New System.Drawing.Size(113, 30)
        Me.cmdOSMPrepareDoc.TabIndex = 18
        Me.cmdOSMPrepareDoc.Text = "Prepare Document"
        '
        'dgvOSMPax
        '
        Me.dgvOSMPax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOSMPax.Location = New System.Drawing.Point(811, 67)
        '
        '
        '
        Me.dgvOSMPax.MasterTemplate.AllowAddNewRow = False
        Me.dgvOSMPax.MasterTemplate.AllowDeleteRow = False
        GridViewTextBoxColumn1.HeaderText = "Id"
        GridViewTextBoxColumn1.Name = "Id"
        GridViewTextBoxColumn2.HeaderText = "LastName"
        GridViewTextBoxColumn2.Name = "LastName"
        GridViewTextBoxColumn3.HeaderText = "FirstName"
        GridViewTextBoxColumn3.Name = "FirstName"
        GridViewTextBoxColumn4.HeaderText = "Nationality"
        GridViewTextBoxColumn4.Name = "Nationality"
        GridViewComboBoxColumn1.HeaderText = "JoinerLeaver"
        GridViewComboBoxColumn1.Name = "JoinerLeaver"
        GridViewComboBoxColumn2.HeaderText = "VisaType"
        GridViewComboBoxColumn2.Name = "VisaType"
        Me.dgvOSMPax.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewComboBoxColumn1, GridViewComboBoxColumn2})
        Me.dgvOSMPax.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvOSMPax.Name = "dgvOSMPax"
        Me.dgvOSMPax.Size = New System.Drawing.Size(517, 332)
        Me.dgvOSMPax.TabIndex = 17
        '
        'lblOSMPasteEmailsHere
        '
        Me.lblOSMPasteEmailsHere.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblOSMPasteEmailsHere.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOSMPasteEmailsHere.Location = New System.Drawing.Point(509, 54)
        Me.lblOSMPasteEmailsHere.Name = "lblOSMPasteEmailsHere"
        Me.lblOSMPasteEmailsHere.Size = New System.Drawing.Size(147, 16)
        Me.lblOSMPasteEmailsHere.TabIndex = 14
        Me.lblOSMPasteEmailsHere.Text = "PASTE OSM EMAIL HERE"
        Me.lblOSMPasteEmailsHere.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'txtOSMPax
        '
        Me.txtOSMPax.AllowDrop = True
        Me.txtOSMPax.AutoSize = False
        Me.txtOSMPax.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtOSMPax.Font = New System.Drawing.Font("Courier New", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtOSMPax.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOSMPax.Location = New System.Drawing.Point(507, 67)
        Me.txtOSMPax.Multiline = True
        Me.txtOSMPax.Name = "txtOSMPax"
        Me.txtOSMPax.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOSMPax.Size = New System.Drawing.Size(282, 332)
        Me.txtOSMPax.TabIndex = 16
        '
        'lblOSMVessel
        '
        Me.lblOSMVessel.BackColor = System.Drawing.Color.Yellow
        Me.lblOSMVessel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOSMVessel.Location = New System.Drawing.Point(217, 18)
        Me.lblOSMVessel.Name = "lblOSMVessel"
        Me.lblOSMVessel.Size = New System.Drawing.Size(2, 2)
        Me.lblOSMVessel.TabIndex = 4
        '
        'cmdOSMVesselsEdit
        '
        Me.cmdOSMVesselsEdit.Location = New System.Drawing.Point(113, 118)
        Me.cmdOSMVesselsEdit.Name = "cmdOSMVesselsEdit"
        Me.cmdOSMVesselsEdit.Size = New System.Drawing.Size(98, 21)
        Me.cmdOSMVesselsEdit.TabIndex = 2
        Me.cmdOSMVesselsEdit.Text = "Edit Vessels"
        '
        'lblOSMVessels
        '
        Me.lblOSMVessels.BackColor = System.Drawing.Color.Yellow
        Me.lblOSMVessels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOSMVessels.Location = New System.Drawing.Point(18, 97)
        Me.lblOSMVessels.Name = "lblOSMVessels"
        Me.lblOSMVessels.Size = New System.Drawing.Size(47, 16)
        Me.lblOSMVessels.TabIndex = 1
        Me.lblOSMVessels.Text = "Vessels"
        Me.lblOSMVessels.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'cmdOSMAgentEdit
        '
        Me.cmdOSMAgentEdit.Location = New System.Drawing.Point(404, 305)
        Me.cmdOSMAgentEdit.Name = "cmdOSMAgentEdit"
        Me.cmdOSMAgentEdit.Size = New System.Drawing.Size(98, 21)
        Me.cmdOSMAgentEdit.TabIndex = 12
        Me.cmdOSMAgentEdit.Text = "Edit Agents"
        '
        'lblOSMAgents
        '
        Me.lblOSMAgents.BackColor = System.Drawing.Color.Yellow
        Me.lblOSMAgents.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOSMAgents.Location = New System.Drawing.Point(217, 275)
        Me.lblOSMAgents.Name = "lblOSMAgents"
        Me.lblOSMAgents.Size = New System.Drawing.Size(43, 16)
        Me.lblOSMAgents.TabIndex = 11
        Me.lblOSMAgents.Text = "Agents"
        Me.lblOSMAgents.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'lstOSMAgents
        '
        Me.lstOSMAgents.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstOSMAgents.FormattingEnabled = True
        Me.lstOSMAgents.Location = New System.Drawing.Point(217, 328)
        Me.lstOSMAgents.Name = "lstOSMAgents"
        Me.lstOSMAgents.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstOSMAgents.Size = New System.Drawing.Size(285, 160)
        Me.lstOSMAgents.TabIndex = 13
        '
        'cmdOSMCopyCC
        '
        Me.cmdOSMCopyCC.Enabled = False
        Me.cmdOSMCopyCC.Location = New System.Drawing.Point(404, 165)
        Me.cmdOSMCopyCC.Name = "cmdOSMCopyCC"
        Me.cmdOSMCopyCC.Size = New System.Drawing.Size(98, 21)
        Me.cmdOSMCopyCC.TabIndex = 9
        Me.cmdOSMCopyCC.Text = "Copy CC"
        '
        'cmdOSMCopyTo
        '
        Me.cmdOSMCopyTo.Enabled = False
        Me.cmdOSMCopyTo.Location = New System.Drawing.Point(403, 46)
        Me.cmdOSMCopyTo.Name = "cmdOSMCopyTo"
        Me.cmdOSMCopyTo.Size = New System.Drawing.Size(98, 21)
        Me.cmdOSMCopyTo.TabIndex = 6
        Me.cmdOSMCopyTo.Text = "Copy TO"
        '
        'lblOSMEmailsCC
        '
        Me.lblOSMEmailsCC.Location = New System.Drawing.Point(217, 165)
        Me.lblOSMEmailsCC.Name = "lblOSMEmailsCC"
        Me.lblOSMEmailsCC.Size = New System.Drawing.Size(55, 18)
        Me.lblOSMEmailsCC.TabIndex = 8
        Me.lblOSMEmailsCC.Text = "emails CC"
        '
        'lblOSMEmailsTo
        '
        Me.lblOSMEmailsTo.Location = New System.Drawing.Point(217, 46)
        Me.lblOSMEmailsTo.Name = "lblOSMEmailsTo"
        Me.lblOSMEmailsTo.Size = New System.Drawing.Size(55, 18)
        Me.lblOSMEmailsTo.TabIndex = 5
        Me.lblOSMEmailsTo.Text = "emails TO"
        '
        'lstOSMCCEmail
        '
        Me.lstOSMCCEmail.FormattingEnabled = True
        Me.lstOSMCCEmail.Location = New System.Drawing.Point(217, 184)
        Me.lstOSMCCEmail.Name = "lstOSMCCEmail"
        Me.lstOSMCCEmail.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstOSMCCEmail.Size = New System.Drawing.Size(285, 82)
        Me.lstOSMCCEmail.TabIndex = 10
        '
        'lstOSMToEmail
        '
        Me.lstOSMToEmail.FormattingEnabled = True
        Me.lstOSMToEmail.Location = New System.Drawing.Point(217, 67)
        Me.lstOSMToEmail.Name = "lstOSMToEmail"
        Me.lstOSMToEmail.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstOSMToEmail.Size = New System.Drawing.Size(285, 82)
        Me.lstOSMToEmail.TabIndex = 7
        '
        'cmdOSMRefresh
        '
        Me.cmdOSMRefresh.Location = New System.Drawing.Point(14, 13)
        Me.cmdOSMRefresh.Name = "cmdOSMRefresh"
        Me.cmdOSMRefresh.Size = New System.Drawing.Size(70, 22)
        Me.cmdOSMRefresh.TabIndex = 0
        Me.cmdOSMRefresh.Text = "Refresh"
        '
        'frmPNR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1396, 619)
        Me.Controls.Add(Me.tabPNR)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPNR"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "ATPI Athens PNR"
        CType(Me.cmdExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdPNRReadAmadeusPNR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPNR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSegs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCRM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCRM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubdepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOneTimeVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReference, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAirlinePoints, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSubDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReference, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbBookedby, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdPNRWrite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBookedByHighlight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDepartmentHighlight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbReasonForTravel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReasonForTravelHighLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCostCentre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCostCentreHighlight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabPNR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPNR.ResumeLayout(False)
        Me.tabPageFinisher.ResumeLayout(False)
        Me.tabPageFinisher.PerformLayout()
        CType(Me.cmdAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdPNROnlyDocs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdPNRWriteWithDocs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAirlineEntries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSSRDocs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvApis.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvApis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdAveragePrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAveragePrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAvPriceDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdCostCentre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPageItinerary.ResumeLayout(False)
        Me.tabPageItinerary.PerformLayout()
        CType(Me.cmdItnFormatOSMLoG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        CType(Me.cmdItn1GReadCurrent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdItn1GReadPNR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdItn1GReadQueue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        CType(Me.cmdItn1AReadCurrent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdItn1AReadPNR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdItn1AReadQueue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItnPNRCounter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdItnRefresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fraItnFormat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraItnFormat.ResumeLayout(False)
        Me.fraItnFormat.PerformLayout()
        CType(Me.optItnFormatSeaChefsWith3LetterCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optItnFormatEuronav, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optItnFormatMSReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optItnFormatSeaChefs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optItnFormatPlain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optItnFormatDefault, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdItnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstItnRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItnRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fraItnAirportName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraItnAirportName.ResumeLayout(False)
        Me.fraItnAirportName.PerformLayout()
        CType(Me.optItnAirportCityBoth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optItnAirportCityName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optItnAirportBoth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optItnAirportname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optItnAirportCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fraItnOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraItnOptions.ResumeLayout(False)
        Me.fraItnOptions.PerformLayout()
        CType(Me.chkItnCostCentre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkItnFlyingTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItnTextToBeAdded, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkItnSeating, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkItnUSAText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkItnStopovers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkItnBrazilText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkItnTerminal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkItnElecItemsBan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkItnPaxSegPerTicket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkItnTickets, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkItnClass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkItnVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkItnAirlineLocator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuITNSelectCopy.ResumeLayout(False)
        CType(Me.txtItnPNR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItnPNR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabOSM.ResumeLayout(False)
        Me.tabOSM.PerformLayout()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOSMVesselInUse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOSMMultipleSearchSeparator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOSMAgentsFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMClearSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMEmailClear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMCopyDocument, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMPrepareDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOSMPax.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOSMPax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOSMPasteEmailsHere, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOSMPax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOSMVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMVesselsEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOSMVessels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMAgentEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOSMAgents, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMCopyCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMCopyTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOSMEmailsCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOSMEmailsTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOSMRefresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdPNRReadAmadeusPNR As Telerik.WinControls.UI.RadButton
    Friend WithEvents llbOptions As System.Windows.Forms.LinkLabel
    Friend WithEvents lblPNR As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblPax As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblSegs As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lstVessels As ListBox
    Friend WithEvents lblCRM As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lstSubDepartments As ListBox
    Friend WithEvents txtCRM As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtVessel As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lstCRM As ListBox
    Friend WithEvents txtSubdepartment As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmdOneTimeVessel As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtCustomer As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblReference As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblAirlinePoints As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblSubDepartment As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtReference As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblVessel As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbBookedby As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents lblCustomer As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbDepartment As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents cmdPNRWrite As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblBookedByHighlight As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblDepartmentHighlight As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lstCustomers As ListBox
    Friend WithEvents cmbReasonForTravel As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents lblReasonForTravelHighLight As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbCostCentre As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents lblCostCentreHighlight As Telerik.WinControls.UI.RadLabel
    Friend WithEvents tabPNR As Telerik.WinControls.UI.RadPageView
    Friend WithEvents tabPageFinisher As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents tabPageItinerary As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents lstItnRemarks As Telerik.WinControls.UI.RadCheckedListBox
    Public WithEvents lblItnRemarks As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkItnElecItemsBan As Telerik.WinControls.UI.RadCheckBox
    Public WithEvents cmdItn1AReadCurrent As Telerik.WinControls.UI.RadButton
    Friend WithEvents fraItnAirportName As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents optItnAirportBoth As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optItnAirportname As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optItnAirportCode As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents fraItnOptions As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents chkItnTickets As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkItnClass As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkItnVessel As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkItnAirlineLocator As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents rtbItnDoc As System.Windows.Forms.RichTextBox
    Public WithEvents cmdItn1AReadPNR As Telerik.WinControls.UI.RadButton
    Public WithEvents txtItnPNR As Telerik.WinControls.UI.RadTextBox
    Public WithEvents lblItnPNR As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdItnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdCostCentre As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdAveragePrice As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblAveragePrice As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblAvPriceDetails As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkItnPaxSegPerTicket As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkItnUSAText As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkItnBrazilText As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkItnStopovers As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkItnTerminal As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkItnSeating As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents fraItnFormat As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents optItnFormatSeaChefs As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optItnFormatPlain As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optItnFormatDefault As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optItnAirportCityName As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents optItnAirportCityBoth As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents tabOSM As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents cmdOSMRefresh As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblOSMEmailsCC As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblOSMEmailsTo As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lstOSMCCEmail As ListBox
    Friend WithEvents lstOSMToEmail As ListBox
    Friend WithEvents cmdOSMCopyCC As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdOSMCopyTo As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblOSMAgents As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lstOSMAgents As ListBox
    Friend WithEvents cmdOSMAgentEdit As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdOSMVesselsEdit As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblOSMVessels As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblOSMVessel As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtOSMPax As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblOSMPasteEmailsHere As Telerik.WinControls.UI.RadLabel
    Friend WithEvents dgvOSMPax As Telerik.WinControls.UI.RadGridView
    Friend WithEvents cmdOSMCopyDocument As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdOSMPrepareDoc As Telerik.WinControls.UI.RadButton
    Friend WithEvents Id As Telerik.WinControls.UI.GridViewTextBoxColumn
    Friend WithEvents LastName As Telerik.WinControls.UI.GridViewTextBoxColumn
    Friend WithEvents FirstName As Telerik.WinControls.UI.GridViewTextBoxColumn
    Friend WithEvents Nationality As Telerik.WinControls.UI.GridViewTextBoxColumn
    Friend WithEvents JoinerLeaver As Telerik.WinControls.UI.GridViewComboBoxColumn
    Friend WithEvents VisaType As Telerik.WinControls.UI.GridViewComboBoxColumn
    Friend WithEvents lstOSMVessels As ListBox
    Friend WithEvents webOSMDoc As System.Windows.Forms.WebBrowser
    Friend WithEvents cmdOSMEmailClear As Telerik.WinControls.UI.RadButton
    Friend WithEvents ttpToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents lblItnTextToBeAdded As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkItnFlyingTime As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents cmdItn1AReadQueue As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdItnRefresh As Telerik.WinControls.UI.RadButton
    Friend WithEvents chkItnCostCentre As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents cmdOSMClearSelected As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtOSMAgentsFilter As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblOSMMultipleSearchSeparator As Telerik.WinControls.UI.RadLabel
    Friend WithEvents optItnFormatMSReport As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents chkOSMVesselInUse As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents dgvApis As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblSSRDocs As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtAirlineEntries As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmdPNROnlyDocs As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdPNRWriteWithDocs As Telerik.WinControls.UI.RadButton
    Friend WithEvents menuITNSelectCopy As ContextMenuStrip
    Friend WithEvents MenuCopyItn As ToolStripMenuItem
    Public WithEvents lblItnPNRCounter As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdAdmin As Telerik.WinControls.UI.RadButton
    Friend WithEvents webItnDoc As WebBrowser
    Friend WithEvents optItnFormatEuronav As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents cmbOSMVesselGroup As ComboBox
    Friend WithEvents Label2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents optItnFormatSeaChefsWith3LetterCode As Telerik.WinControls.UI.RadRadioButton
    Friend WithEvents RadGroupBox1 As RadGroupBox
    Friend WithEvents cmdItnFormatOSMLoG As RadButton
    Friend WithEvents RadGroupBox2 As RadGroupBox
    Public WithEvents cmdItn1GReadCurrent As RadButton
    Public WithEvents cmdItn1GReadPNR As RadButton
    Friend WithEvents cmdItn1GReadQueue As RadButton
End Class
