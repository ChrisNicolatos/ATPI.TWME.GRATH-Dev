Imports System.IO
Imports System.Text
Imports Telerik.WinControls.UI

Module modPNR
    '
    ' Prepares the SQL connection string for the Travel Force Cosmos database
    '
    ' The SQL connection string for the Travel Force Cosmos database
    ' Returns the connection string to be used for SQLConnection
    ' The options for the connection string are bound to the application and cannot be modified by the user
    ' 

    Private Const MONTH_NAMES As String = "JANFEBMARAPRMAYJUNJULAUGSEPOCTNOVDEC"
    Private Const mstrDBConnectionsFileGT As String = "\\192.168.102.223\Common\Click-Once Applications\PNR Finisher ATH V2\Config\PNRFinisher.txt"
    Private Const mstrDBConnectionsFile As String = "\\ath2-svrdc1\PNR Finisher ATH Config\PNRFinisher.txt"
    Private Const msrtConfigFolder As String = "\\192.168.102.223\Common\Click-Once Applications\PNR Finisher ATH V2\Config"
    Private mstrDBConnectionFileActual As String

    Private mMySettings As Config
    Private mHomeSettings As Config
    Private mHomeSettingsExist As Boolean
    Private mstrRequestedPCC As String = ""
    Private mstrRequestedUser As String = ""

    Private mPnrDataSource As String = ""
    Private mPnrDataCatalog As String = ""
    Private mPnrUserName As String = ""
    Private mPnrPassword As String = ""

    Public Sub InitSettings(ByVal mGDSUser As GDSUser)
        Try
            mstrRequestedPCC = mGDSUser.PCC
            mstrRequestedUser = mGDSUser.User

            mMySettings = New Config(mGDSUser)
            If Not mHomeSettingsExist Then
                mHomeSettings = mMySettings
                mHomeSettingsExist = True
            End If
        Catch ex As Exception
            If mHomeSettingsExist Then
                mMySettings = mHomeSettings
            Else
                Throw New Exception(ex.Message)
            End If
        End Try

    End Sub
    Public ReadOnly Property MySettings As Config
        Get
            MySettings = mMySettings
        End Get

    End Property
    Public ReadOnly Property MyHomeSettings As Config
        Get
            MyHomeSettings = mHomeSettings
        End Get
    End Property
    Public ReadOnly Property MyConfigPath As String
        Get
            MyConfigPath = msrtConfigFolder
        End Get
    End Property
    Public ReadOnly Property RequestedPCC As String
        Get
            RequestedPCC = mstrRequestedPCC
        End Get
    End Property
    Public ReadOnly Property RequestedUser As String
        Get
            RequestedUser = mstrRequestedUser
        End Get
    End Property
    Public ReadOnly Property PNRDataSource As String
        Get
            PNRDataSource = mPnrDataSource
        End Get
    End Property
    Public ReadOnly Property PNRDataCatalog As String
        Get
            PNRDataCatalog = mPnrDataCatalog
        End Get
    End Property
    Public ReadOnly Property PNRUserName As String
        Get
            PNRUserName = mPnrUserName
        End Get
    End Property
    Public ReadOnly Property DBConnectionsFile As String
        Get
            DBConnectionsFile = mstrDBConnectionFileActual
        End Get
    End Property
    Private Sub ReadDBConnections()

        Dim pFileExists As Boolean = False

        If File.Exists(mstrDBConnectionsFile) Then
            mstrDBConnectionFileActual = mstrDBConnectionsFile
            pFileExists = True
        ElseIf File.Exists(mstrDBConnectionsFileGT) Then
            mstrDBConnectionFileActual = mstrDBConnectionsFileGT
            pFileExists = True
        End If

        If pFileExists Then
            Dim GDSData As StreamReader = File.OpenText(mstrDBConnectionFileActual)
            Dim xLine() As String = Split(GDSData.ReadToEnd, vbCrLf)
            GDSData.Close()

            If IsArray(xLine) Then
                For i As Integer = xLine.GetLowerBound(0) To xLine.GetUpperBound(0)
                    Dim pValues() As String = xLine(i).Split("=")
                    Select Case pValues(0).Trim.ToUpper
                        Case "DATASOURCEPNR"
                            mPnrDataSource = pValues(1).Trim
                        Case "DATACATALOGPNR"
                            mPnrDataCatalog = pValues(1).Trim
                        Case "DATAUSERNAMEPNR"
                            mPnrUserName = pValues(1).Trim
                        Case "DATAUSERPASSWORDPNR"
                            mPnrPassword = pValues(1).Trim
                    End Select
                Next
            Else
                Throw New Exception("Settings File Error" & vbCrLf & mstrDBConnectionFileActual)
            End If
        Else
            Throw New Exception("DB Connection file does not exist. Please contact you system administrator" & vbCrLf & mstrDBConnectionFileActual)
        End If

    End Sub

    Public ReadOnly Property ConnectionStringACC() As String
        Get
            If MySettings.PCCDBDataSource = "" Then
                ReadDBConnections()
            End If
            ConnectionStringACC = "Data Source=" & MySettings.PCCDBDataSource &
                                  ";Initial Catalog=" & MySettings.PCCDBInitialCatalog &
                                  ";User ID=" & MySettings.PCCDBUserId &
                                  ";Password=" & MySettings.PCCDBUserPassword

        End Get
    End Property

    '
    ' Prepares the SQL connection string for the Amadeus Reports database
    '
    ' The SQL connection string for the Amadeus Reports database
    ' Returns the connection string to be used for SQLConnection
    ' The options for the connection string are bound to the application and cannot be modified by the user. The Amadeus Reports database contains tables that are not part of the Travel Force Cosmos database
    Public ReadOnly Property ConnectionStringPNR() As String
        Get
            If mPnrDataSource = "" Then
                ReadDBConnections()
            End If
            ConnectionStringPNR = "Data Source=" & mPnrDataSource &
                                  ";Initial Catalog=" & mPnrDataCatalog &
                                  ";User ID=" & mPnrUserName &
                                  ";Password=" & mPnrPassword
        End Get
    End Property
    Public Function myCurr(ByVal StringToParse As String) As Decimal

        Dim i As Integer
        Dim pintPoint As Short
        Dim pintComma As Short

        Do While Not IsNumeric(Right(StringToParse, 1)) And Len(StringToParse) > 0
            StringToParse = Left(StringToParse, Len(StringToParse) - 1)
        Loop
        StringToParse = Trim(StringToParse)
        pintPoint = InStr(StringToParse, My.Application.Culture.NumberFormat.CurrencyGroupSeparator)
        pintComma = InStr(StringToParse, My.Application.Culture.NumberFormat.CurrencyDecimalSeparator)
        If pintPoint > pintComma Then
            If Len(StringToParse) > 2 Then
                If Mid(StringToParse, Len(StringToParse) - 2, 1) = My.Application.Culture.NumberFormat.CurrencyGroupSeparator Then
                    Mid(StringToParse, Len(StringToParse) - 2, 1) = My.Application.Culture.NumberFormat.CurrencyDecimalSeparator
                End If
            End If
        End If

        If IsDBNull(StringToParse) Then
            StringToParse = ""
        End If
        If IsNumeric(StringToParse) Then
            myCurr = CDec(StringToParse)
        Else
            myCurr = 0
            For i = 1 To Len(StringToParse)
                If IsNumeric(Mid(StringToParse, 1, i)) Then
                    myCurr = CDec(Mid(StringToParse, 1, i))
                Else
                    Exit For
                End If
            Next i
        End If

    End Function
    Public Sub OSMRefreshVessels(ByRef lstListBox As ListBox, ByVal InUseOnly As Boolean)

        Dim pOSMVessels As New osmVessels.VesselCollection

        If Not MySettings Is Nothing Then
            pOSMVessels.Load(MySettings.OSMVesselGroup)
        Else
            pOSMVessels.Load()
        End If
        lstListBox.Items.Clear()

        For Each pVessels As osmVessels.VesselItem In pOSMVessels.Values
            If Not InUseOnly Or pVessels.InUse Then
                lstListBox.Items.Add(pVessels)
            End If
        Next

    End Sub
    Public Sub OSMRefreshVessels(ByRef lstListBox As ListBox)

        Dim pOSMVessels As New osmVessels.VesselCollection

        pOSMVessels.Load()
        lstListBox.Items.Clear()

        For Each pVessels As osmVessels.VesselItem In pOSMVessels.Values
            lstListBox.Items.Add(pVessels)
        Next

    End Sub
    Public Sub OSMRefreshVesselGroup(ByRef cmbComboBox As ComboBox)

        Dim pOSMVesselGroup As New osmVessels.VesselGroupCollection

        pOSMVesselGroup.Load()
        cmbComboBox.Items.Clear()

        For Each PVesselGroup As osmVessels.VesselGroupItem In pOSMVesselGroup.Values
            cmbComboBox.Items.Add(PVesselGroup)
            If Not MySettings Is Nothing Then
                If PVesselGroup.Id = MySettings.OSMVesselGroup Then
                    cmbComboBox.SelectedItem = PVesselGroup
                End If
            End If
        Next

    End Sub
    Public Sub OSMDisplayVesselGroups(ByRef lstListBox As radCheckedListBox, ByVal pobjGroups As osmVessels.Vessel_VesselGroupCollection)

        lstListBox.Items.Clear()
        For Each Vessel_VesselGroup As osmVessels.Vessel_VesselGroupItem In pobjGroups.Values
            lstListBox.Items.Add(Vessel_VesselGroup, Vessel_VesselGroup.Exists)
        Next

    End Sub
    Public Sub OSMDisplayEmails(ByVal VesselList As ListBox, ByRef lstToEmail As ListBox, ByRef lstCCEmail As ListBox, ByRef lstAgentsEmail As ListBox)

        Dim pobjEmails As New osmVessels.EmailCollection

        lstToEmail.Items.Clear()
        lstCCEmail.Items.Clear()
        lstAgentsEmail.Items.Clear()
        lstAgentsEmail.Items.Add("")

        For Each SelectedVessel As osmVessels.VesselItem In VesselList.SelectedItems

            pobjEmails.Load(SelectedVessel.Id)

            For Each pEmail As osmVessels.emailItem In pobjEmails.Values
                With pEmail
                    If .EmailType = "TO" Then
                        Dim pFound As Boolean = False
                        For Each pItem As osmVessels.emailItem In lstToEmail.Items
                            If pEmail.ToString = pItem.ToString Then
                                pFound = True
                                Exit For
                            End If
                        Next
                        If Not pFound Then
                            lstToEmail.Items.Add(pEmail)
                        End If
                    ElseIf .EmailType = "CC" Then
                        Dim pFound As Boolean = False
                        For Each pItem As osmVessels.emailItem In lstCCEmail.Items
                            If pEmail.ToString = pItem.ToString Then
                                pFound = True
                                Exit For
                            End If
                        Next
                        If Not pFound Then
                            lstCCEmail.Items.Add(pEmail)
                        End If

                    ElseIf .EmailType = "AGENT" Then
                        lstAgentsEmail.Items.Add(pEmail)
                    End If
                End With
            Next
        Next

    End Sub
    Public Sub OSMDisplayEmails(ByVal VesselId As Integer, ByRef lstToEmail As ListBox, ByRef lstCCEmail As ListBox)

        Dim pobjEmails As New osmVessels.EmailCollection

        pobjEmails.Load(VesselId)

        lstToEmail.Items.Clear()
        lstCCEmail.Items.Clear()

        For Each pEmail As osmVessels.emailItem In pobjEmails.Values
            With pEmail
                If .EmailType = "TO" Then
                    lstToEmail.Items.Add(pEmail)
                ElseIf .EmailType = "CC" Then
                    lstCCEmail.Items.Add(pEmail)
                End If
            End With
        Next
    End Sub
    Public Sub OSMDisplayEmails(ByRef lstAgents As ListBox)

        Dim pobjEmails As New osmVessels.EmailCollection

        pobjEmails.Load()

        lstAgents.Items.Clear()

        For Each pEmail As osmVessels.emailItem In pobjEmails.Values
            With pEmail
                If .EmailType = "AGENT" Then
                    lstAgents.Items.Add(pEmail)
                End If
            End With
        Next
    End Sub

    Public Sub ListBox_DrawItem(sender As Object, e As DrawItemEventArgs)

        If e.Index >= 0 And e.Index < sender.Items.Count Then
            Dim stringToDraw As String = sender.Items(e.Index).ToString
            Dim VesselToDraw As osmVessels.VesselItem = sender.Items(e.Index)
            Dim C As Color
            If Not VesselToDraw.InUse Then
                C = Color.Red
            Else
                C = sender.ForeColor
            End If

            e.DrawBackground()
            e.DrawFocusRectangle()
            e.Graphics.DrawString(stringToDraw, e.Font, New SolidBrush(C), e.Bounds)
        End If

    End Sub
    Public Function APISDateFromIATA(ByVal InDate As String) As Date

        Dim pintDay As Integer
        Dim pintMonth As Integer
        Dim pintYear As Integer
        APISDateFromIATA = Now
        Try
            If Not Date.TryParse(InDate, APISDateFromIATA) Then
                APISDateFromIATA = Date.MinValue
                If InDate.Length > 5 Then
                    pintDay = InDate.Substring(0, 2)
                    pintMonth = (MONTH_NAMES.IndexOf(InDate.Substring(3, 3)) + 2) / 3
                    pintYear = InDate.Substring(5)

                    If pintMonth >= 1 Then
                        APISDateFromIATA = DateSerial(pintYear, pintMonth, pintDay)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Function

    Public Function APISDateToIATA(ByVal InDate As Date) As String

        APISDateToIATA = Format(InDate.Day, "00") & MONTH_NAMES.Substring(InDate.Month * 3 - 3, 3) & Format(InDate.Year Mod 100, "00")

    End Function
End Module
