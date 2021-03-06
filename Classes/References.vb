﻿Imports System.IO
Imports System.Text

Public Class References

    Private Const CONFileName As String = "\PNRFinisher\PNRFinisher.txt"
    Private Const CONNumberOfElements As Integer = 58


    ' database references
    Private Const CONXDataSourceACC As String = "DataSourceACC"
    Private Const CONDataSourceACC As String = "192.168.101.35"
    Private Const CONXDataCatalogACC As String = "DataCatalogACC"
    Private Const CONDataCatalogACC As String = "TravelForceCosmos"
    Private Const CONXDataUserNameACC As String = "DataUserNameACC"
    Private Const CONDataUserNameACC As String = "AmadeusReports"
    Private Const CONXDataUserPasswordACC As String = "DataUserPasswordACC"
    Private Const CONDataUserPasswordACC As String = "AmadeusReports"
    '---------------------------------------------------------------------
    Private Const CONXDataSourcePNR As String = "DataSourcePNR"
    Private Const CONDataSourcePNR As String = "192.168.101.35"
    Private Const CONXDataCatalogPNR As String = "DataCatalogPNR"
    Private Const CONDataCatalogPNR As String = "AmadeusReports"
    Private Const CONXDataUserNamePNR As String = "DataUserNamePNR"
    Private Const CONDataUserNamePNR As String = "AmadeusReports"
    Private Const CONXDataUserPasswordPNR As String = "DataUserPasswordPNR"
    Private Const CONDataUserPasswordPNR As String = "AmadeusReports"
    '---------------------------------------------------------------------
    Private Const CONXTextAP As String = "TextAP"
    Private Const CONTextAPAmadeus As String = "AP %CITYCODE%*%PHONE% %OFFICENAME% REF %AGENTNAME% Q%AGENTQ%"
    Private Const CONTextAPGalileo As String = "P.%CITYCODE%T*%PHONE% %OFFICENAME% REF %AGENTNAME% Q%AGENTQ%"
    '---------------------------------------------------------------------
    Private Const CONXTextAOH As String = "TextAOH"
    Private Const CONTextAOHAmadeus As String = "SR OTHS - %CITYCODE% AFTER OFFICE HOURS TELEPHONE %CITYNAME% %AOHP%"
    Private Const CONTextAOHGalileo As String = "P.%CITYCODE%T*%AOHP% AFTER OFFICE HOURS TELEPHONE %CITYNAME%"
    '---------------------------------------------------------------------
    Private Const CONXTextAOH_ToFind As String = "TextAOH_ToFind"
    Private Const CONTextAOH_ToFindAmadeus As String = "SSR OTHS YY ATH AFTER OFFICE HOURS"
    '---------------------------------------------------------------------
    Private Const CONXTextAPE As String = "TextAPE"
    Private Const CONTextAPEAmadeus As String = "APE-%AGENTEMAIL%"
    Private Const CONTEXTAPEGalileo As String = "MT.%AGENTEMAIL%"
    '---------------------------------------------------------------------
    Private Const CONXTextAGT As String = "TextAGT"
    Private Const CONTextAGTAmadeus As String = "RM *%MID%ACE/AGT/%AgentID%"
    Private Const CONTextAGTGalileo As String = "DI.FT-%MID%ACE/AGT/%AgentID%"
    '---------------------------------------------------------------------
    Private Const CONXTextTTL As String = "TextTTL"
    Private Const CONTextTTLAmadeus As String = "TK TL"
    Private Const CONTextTTLGalileo As String = "T.TAU/"
    '---------------------------------------------------------------------
    Private Const CONXTextAMR As String = "TextAMR"
    Private Const CONXTextAMRAmadeus As String = "RM *AMA 30038880"
    Private Const CONXTextAMRGalileo As String = ""
    '---------------------------------------------------------------------
    Private Const CONXTextBBY As String = "TextBBY"
    Private Const CONTextBBYAmadeus As String = "RM *%MID%ACE/BBY/"
    Private Const CONTextBBYGalileo As String = "DI.FT-%MID%ACE/BBY/"
    '---------------------------------------------------------------------
    Private Const CONXTextCC As String = "TextCC"
    Private Const CONTextCCRAmadeus As String = "RM *%MID%ACE/CC/"
    Private Const CONTextCCRGalileo As String = "DI.FT-%MID%ACE/CC/"
    '---------------------------------------------------------------------
    Private Const CONXTextCLA As String = "TextCLA"
    Private Const CONTextCLAAmadeus As String = "RM *%MID%ACE/CLA/"
    Private Const CONTextCLAGalileo As String = "DI.FT-%MID%ACE/CLA/"
    '---------------------------------------------------------------------
    Private Const CONXTextCLN As String = "TextCLN"
    Private Const CONTextCLNAmadeus As String = "RM *%MID%ACE/CLN/"
    Private Const CONTextCLNGalileo As String = "DI.FT-%MID%ACE/CLN/"
    '---------------------------------------------------------------------
    Private Const CONXTextCRA As String = "TextCRA"
    Private Const CONTextCRAAmadeus As String = "RM *%MID%ACE/CRA/"
    Private Const CONTextCRAGalileo As String = "DI.FT-%MID%ACE/CRA/"
    '---------------------------------------------------------------------
    Private Const CONXTextCRN As String = "TextCRN"
    Private Const CONTextCRNAmadeus As String = "RM *%MID%ACE/CRN/"
    Private Const CONTextCRNGalileo As String = "DI.FT-%MID%ACE/CRN/"
    '---------------------------------------------------------------------
    Private Const CONXTextDPT As String = "TextDPT"
    Private Const CONTextDPTAmadeus As String = "RM *%MID%ACE/DPT/"
    Private Const CONTextDPTGalileo As String = "DI.FT-%MID%ACE/DPT/"
    '---------------------------------------------------------------------
    Private Const CONXTextLOS As String = "TextLOS"
    Private Const CONTextLOSAmadeus As String = "RM *%MID%ACE/LOS/"
    Private Const CONTextLOSGalileo As String = "DI.FT-%MID%ACE/LOS/"
    '---------------------------------------------------------------------
    Private Const CONXTextMISSegmentCommand As String = "TextMISSegmentCommand"
    Private Const CONTextMISSegmentCommandAmadeus As String = "RU 1A HK"
    Private Const CONTextMISSegmentCommandGalileo As String = "RT.T/"
    '---------------------------------------------------------------------
    Private Const CONXTextMISSegmentLookup As String = "TextMISSegmentLookup"
    Private Const CONTextMISSegmentLookup As String = "MIS 1A HK"
    '---------------------------------------------------------------------
    Private Const CONXTextMISSegmentText As String = "TextMISSegmentText"
    Private Const CONTextMISSegmentText As String = "RETAIN"
    '---------------------------------------------------------------------
    Private Const CONXTextOPC As String = "TextOPC"
    Private Const CONTextOPCAmadeus As String = "OP "
    Private Const CONTextOPCGalileo As String = "RB."
    '---------------------------------------------------------------------
    Private Const CONXTextOPB As String = "TextOPB"
    Private Const CONTextOPBAmadeus As String = "OP "
    Private Const CONTextOPBGalileo As String = "RB."
    '---------------------------------------------------------------------
    Private Const CONXTextOP As String = "TextOP"
    Private Const CONTextOPAmadeus As String = "OP "
    Private Const CONTextOPGalileo As String = "RB."
    '---------------------------------------------------------------------
    Private Const CONXTextREF As String = "TextREF"
    Private Const CONTextREFAmadeus As String = "RM *%MID%ACE/REF/"
    Private Const CONTextREFGalileo As String = "DI.FT-%MID%ACE/REF/"
    '---------------------------------------------------------------------
    Private Const CONXTextREG As String = "TextREG"
    Private Const CONTextREG As String = " REG "
    '---------------------------------------------------------------------
    Private Const CONXTextRFT As String = "TextRFT"
    Private Const CONTextRFTAmadeus As String = "RM *%MID%ACE/RFT/"
    Private Const CONTextRFTGalileo As String = "DI.FT-%MID%ACE/RFT/"
    '---------------------------------------------------------------------
    Private Const CONXTextSAV As String = "TextSAV"
    Private Const CONTextSAVAmadeus As String = "RM *%MID%ACE/SAV/"
    Private Const CONTextSAVGalileo As String = "DI.FT-%MID%ACE/RFT/"
    '---------------------------------------------------------------------
    Private Const CONXTextSBA As String = "TextSBA"
    Private Const CONTextSBAAmadeus As String = "RM *%MID%ACE/SBA/"
    Private Const CONTextSBAGalileo As String = "DI.FT-%MID%ACE/SBA/"
    '---------------------------------------------------------------------
    Private Const CONXTextSBN As String = "TextSBN"
    Private Const CONTextSBNAmadeus As String = "RM *%MID%ACE/SBN/"
    Private Const CONTextSBNGalileo As String = "DI.FT-%MID%ACE/SBN/"
    '---------------------------------------------------------------------
    Private Const CONXTextSLP As String = "TextSLP"
    Private Const CONTextSLPAmadeus As String = "RM *%MID%ACE/SLP/"
    Private Const CONTextSLPGalileo As String = "DI.FT-%MID%ACE/SLP/"
    '---------------------------------------------------------------------
    Private Const CONXTextVOS As String = "TextVOS"
    Private Const CONTextVOSAmadeus As String = "OS YY SEMN/VESSEL-"
    Private Const CONTextVOSGalileo As String = "SI.YY*SEMN/VESSEL-"
    '---------------------------------------------------------------------
    Private Const CONXTextVOSI As String = "TextVOSI"
    Private Const CONTextVOSIAmadeus As String = "OSI YY SEMN/VESSEL-"
    Private Const CONTextVOSIGalileo As String = "OSI YY SEMN/VESSEL-"
    '---------------------------------------------------------------------
    Private Const CONXTextVSL As String = "TextVSL"
    Private Const CONTextVSLAmadeus As String = "RM *%MID%ACE/VSL/"
    Private Const CONTextVSLGalileo As String = "DI.FT-%MID%ACE/VSL/"
    '---------------------------------------------------------------------
    Private Const CONXTextVSR As String = "TextVSR"
    Private Const CONTextVSRAmadeus As String = "RM *%MID%ACE/VSR/"
    Private Const CONTextVSRGalileo As String = "DI.FT-%MID%ACE/VSR/"

    '---------------------------------------------------------------------
    'Private Const CONXOfficePCC As String = "OfficePCC" ' %PCC%
    Private Const CONXAgentID As String = "AgentID"
    Private Const CONXAgentQueue As String = "AgentQueue" ' %AGENTQ%
    Private Const CONXAgentOPQueue As String = "AgentOPQueue" ' %AGENTOPQ%
    Private Const CONXAgentName As String = "AgentName" ' %AGENTNAME%
    Private Const CONXAgentEmail As String = "AgentEmail" ' %AGENTEMAIL%
    Private Const CONXOfficeCityCode As String = "OfficeCityCode" ' %CITYCODE%
    Private Const CONXCountryCode As String = "CountryCode" ' %MID%
    Private Const CONXAOHPhone As String = "AOHPhone" ' %AOHP%
    Private Const CONXPhone As String = "Phone" ' %PHONE%
    Private Const CONXCityName As String = "CityName" ' %CityName%
    Private Const CONXOfficeName As String = "OfficeName" ' %OfficeName%

    ' Itinerary Remarks
    Private Const CONXAirportName As String = "AirportName"
    Private Const CONXAirlineLocator As String = "AirlineLocator"
    Private Const CONXClassOfService As String = "ClassOfService"
    Private Const CONXVessel As String = "Vessel"
    Private Const CONXBanElectricalEquipment As String = "BanElectricalEquipment"
    Private Const CONXTextTickets As String = "Tickets"
    Private Const CONXTextPaxSegPerTkt As String = "PaxSegPerTkt"
    Private Const CONXTextBrazilText As String = "BrazilText"
    Private Const CONXTextUSAText As String = "USAText"
    Private Const CONXTextShowTerminal As String = "ShowTerminal"
    Private Const CONXTextShowStopovers As String = "ShowStopovers"
    Private Const CONXTextPlainFormat As String = "PlainFormat"
    Private Const CONXTextSeating As String = "Seating"
    Private Const CONXTextFlyingTime As String = "FlyingTime"
    Private Const CONXTextCostCentre As String = "CostCentre"

    Private Structure ClassProps
        Dim ReferenceName As String
        Dim ReferenceAmadeus As String
        Dim ReferenceGalileo As String
    End Structure
    Private mudtProps As ClassProps

    Dim mFileName As String
    Dim mReferences As New Collections.Generic.Dictionary(Of String, ClassProps)

    Public Sub New()

        Dim LocalAppData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

        mFileName = LocalAppData & CONFileName

        ReadFile()


    End Sub

   
    Private Sub ReadFile()

        CheckFileExists()

        Dim GDSData As StreamReader = File.OpenText(mFileName)
        Dim xLine() As String = Split(GDSData.ReadToEnd, vbCrLf)
        GDSData.Close()
        mReferences.Clear()

        If IsArray(xLine) Then
            For i As Integer = xLine.GetLowerBound(0) To xLine.GetUpperBound(0)
                Dim delim As Integer = xLine(i).IndexOf("=")
                If delim > 0 Then
                    Dim pValues() As String = xLine(i).Substring(delim + 1).Split("|")
                    If pValues.GetUpperBound(0) = 1 Then
                        AddReference(xLine(i).Substring(0, delim), pValues(0), pValues(1))
                    End If
                End If
            Next
            If xLine.GetUpperBound(0) <> CONNumberOfElements - 1 Then
                CheckFileExists(True)
            End If
        Else
            Throw New Exception("Settings File Error" & vbCrLf & mFileName)
        End If

    End Sub

    Public Sub AddReference(ByVal Key As String, ByVal AmadeusValue As String, ByVal GalileoValue As String)

        If Not mReferences.ContainsKey(Key) Then
            Dim pItem As ClassProps
            pItem.ReferenceName = Key
            pItem.ReferenceAmadeus = AmadeusValue
            pItem.ReferenceGalileo = GalileoValue
            mReferences.Add(Key, pItem)
        Else
            Dim pItem As ClassProps = mReferences.Item(Key)
            pItem.ReferenceAmadeus = AmadeusValue
            pItem.ReferenceGalileo = GalileoValue
            pItem.ReferenceName = Key
            mReferences.Item(Key) = pItem
        End If

    End Sub

    Private Sub AddReference(ByVal Key As String, ByVal Value As String)

        If Not mReferences.ContainsKey(Key) Then
            Dim pItem As ClassProps
            pItem.ReferenceName = Key
            pItem.ReferenceAmadeus = Value
            pItem.ReferenceGalileo = Value
            mReferences.Add(Key, pItem)
        End If

    End Sub

    Private Sub FillReference()

        AddReference(CONXDataSourceACC, CONDataSourceACC)
        AddReference(CONXDataCatalogACC, CONDataCatalogACC)
        AddReference(CONXDataUserNameACC, CONDataUserNameACC)
        AddReference(CONXDataUserPasswordACC, CONDataUserPasswordACC)

        AddReference(CONXDataCatalogPNR, CONDataCatalogPNR)
        AddReference(CONXDataSourcePNR, CONDataSourcePNR)
        AddReference(CONXDataUserNamePNR, CONDataUserNamePNR)
        AddReference(CONXDataUserPasswordPNR, CONDataUserPasswordPNR)

        AddReference(CONXTextAGT, CONTextAGTAmadeus, CONTextAGTGalileo)
        AddReference(CONXTextAOH, CONTextAOHAmadeus, CONTextAOHGalileo)
        AddReference(CONXTextAOH_ToFind, CONTextAOH_ToFindAmadeus)
        AddReference(CONXTextAP, CONTextAPAmadeus, CONTextAPGalileo)
        AddReference(CONXTextAPE, CONTextAPEAmadeus, CONTEXTAPEGalileo)
        AddReference(CONXTextTTL, CONTextTTLAmadeus, CONTextTTLGalileo)
        AddReference(CONXTextAMR, CONXTextAMRAmadeus, CONXTextAMRGalileo)

        AddReference(CONXTextBBY, CONTextBBYAmadeus, CONTextBBYGalileo)
        AddReference(CONXTextCC, CONTextCCRAmadeus, CONTextCCRGalileo)
        AddReference(CONXTextCLA, CONTextCLAAmadeus, CONTextCLAGalileo)
        AddReference(CONXTextCLN, CONTextCLNAmadeus, CONTextCLNGalileo)
        AddReference(CONXTextCRA, CONTextCRAAmadeus, CONTextCRAGalileo)
        AddReference(CONXTextCRN, CONTextCRNAmadeus, CONTextCRNGalileo)
        AddReference(CONXTextDPT, CONTextDPTAmadeus, CONTextDPTGalileo)
        AddReference(CONXTextLOS, CONTextLOSAmadeus, CONTextLOSGalileo)
        AddReference(CONXTextMISSegmentCommand, CONTextMISSegmentCommandAmadeus, CONTextMISSegmentCommandGalileo)
        AddReference(CONXTextMISSegmentLookup, CONTextMISSegmentLookup)
        AddReference(CONXTextMISSegmentText, CONTextMISSegmentText)
        AddReference(CONXTextOPC, CONTextOPCAmadeus, CONTextOPCGalileo)
        AddReference(CONXTextOPB, CONTextOPBAmadeus, CONTextOPBGalileo)
        AddReference(CONXTextREF, CONTextREFAmadeus, CONTextREFGalileo)
        AddReference(CONXTextOP, CONTextOPAmadeus, CONTextOPGalileo)
        AddReference(CONXTextREG, CONTextREG)
        AddReference(CONXTextRFT, CONTextRFTAmadeus, CONTextRFTGalileo)
        AddReference(CONXTextSAV, CONTextSAVAmadeus, CONTextSAVGalileo)
        AddReference(CONXTextSBA, CONTextSBAAmadeus, CONTextSBAGalileo)
        AddReference(CONXTextSBN, CONTextSBNAmadeus, CONTextSBNGalileo)
        AddReference(CONXTextSLP, CONTextSLPAmadeus, CONTextSLPGalileo)
        AddReference(CONXTextVOS, CONTextVOSAmadeus, CONTextVOSGalileo)
        AddReference(CONXTextVOSI, CONTextVOSIAmadeus, CONTextVOSIGalileo)
        AddReference(CONXTextVSL, CONTextVSLAmadeus, CONTextVSLGalileo)
        AddReference(CONXTextVSR, CONTextVSRAmadeus, CONTextVSRGalileo)
        AddReference(CONXOfficePCC, "")
        AddReference(CONXAgentName, "")
        AddReference(CONXAgentQueue, "")
        AddReference(CONXAgentOPQueue, "")
        AddReference(CONXAgentEmail, "")
        AddReference(CONXAgentID, "")
        AddReference(CONXOfficeCityCode, "")
        AddReference(CONXCountryCode, "")
        AddReference(CONXCityName, "")
        AddReference(CONXAOHPhone, "")
        AddReference(CONXPhone, "")
        AddReference(CONXOfficeName, "")

        If mReferences.ContainsKey(CONXAirportName) Then
            AddReference(CONXAirportName, mReferences(CONXAirportName).ReferenceAmadeus, mReferences(CONXAirportName).ReferenceAmadeus)
        Else
            AddReference(CONXAirportName, "0")
        End If
        If mReferences.ContainsKey(CONXAirlineLocator) Then
            AddReference(CONXAirlineLocator, mReferences(CONXAirlineLocator).ReferenceAmadeus, mReferences(CONXAirlineLocator).ReferenceAmadeus)
        Else
            AddReference(CONXAirlineLocator, "0")
        End If
        If mReferences.ContainsKey(CONXClassOfService) Then
            AddReference(CONXClassOfService, mReferences(CONXClassOfService).ReferenceAmadeus, mReferences(CONXClassOfService).ReferenceAmadeus)
        Else
            AddReference(CONXClassOfService, "0")
        End If
        If mReferences.ContainsKey(CONXBanElectricalEquipment) Then
            AddReference(CONXBanElectricalEquipment, mReferences(CONXBanElectricalEquipment).ReferenceAmadeus, mReferences(CONXBanElectricalEquipment).ReferenceAmadeus)
        Else
            AddReference(CONXBanElectricalEquipment, "0")
        End If

        If mReferences.ContainsKey(CONXTextBrazilText) Then
            AddReference(CONXTextBrazilText, mReferences(CONXTextBrazilText).ReferenceAmadeus, mReferences(CONXTextBrazilText).ReferenceAmadeus)
        Else
            AddReference(CONXTextBrazilText, "0")
        End If

        If mReferences.ContainsKey(CONXTextUSAText) Then
            AddReference(CONXTextUSAText, mReferences(CONXTextUSAText).ReferenceAmadeus, mReferences(CONXTextUSAText).ReferenceAmadeus)
        Else
            AddReference(CONXTextUSAText, "0")
        End If

        If mReferences.ContainsKey(CONXTextTickets) Then
            AddReference(CONXTextTickets, mReferences(CONXTextTickets).ReferenceAmadeus, mReferences(CONXTextTickets).ReferenceAmadeus)
        Else
            AddReference(CONXTextTickets, "0")
        End If
        If mReferences.ContainsKey(CONXTextPaxSegPerTkt) Then
            AddReference(CONXTextPaxSegPerTkt, mReferences(CONXTextPaxSegPerTkt).ReferenceAmadeus, mReferences(CONXTextPaxSegPerTkt).ReferenceAmadeus)
        Else
            AddReference(CONXTextPaxSegPerTkt, "0")
        End If
        If mReferences.ContainsKey(CONXTextShowStopovers) Then
            AddReference(CONXTextShowStopovers, mReferences(CONXTextShowStopovers).ReferenceAmadeus, mReferences(CONXTextShowStopovers).ReferenceAmadeus)
        Else
            AddReference(CONXTextShowStopovers, "0")
        End If
        If mReferences.ContainsKey(CONXTextShowTerminal) Then
            AddReference(CONXTextShowTerminal, mReferences(CONXTextShowTerminal).ReferenceAmadeus, mReferences(CONXTextShowTerminal).ReferenceAmadeus)
        Else
            AddReference(CONXTextShowTerminal, "0")
        End If
        If mReferences.ContainsKey(CONXTextFlyingTime) Then
            AddReference(CONXTextFlyingTime, mReferences(CONXTextFlyingTime).ReferenceAmadeus, mReferences(CONXTextFlyingTime).ReferenceAmadeus)
        Else
            AddReference(CONXTextFlyingTime, "0")
        End If
        If mReferences.ContainsKey(CONXTextCostCentre) Then
            AddReference(CONXTextCostCentre, mReferences(CONXTextCostCentre).ReferenceAmadeus, mReferences(CONXTextCostCentre).ReferenceAmadeus)
        Else
            AddReference(CONXTextCostCentre, "0")
        End If
        If mReferences.ContainsKey(CONXTextSeating) Then
            AddReference(CONXTextSeating, mReferences(CONXTextSeating).ReferenceAmadeus, mReferences(CONXTextSeating).ReferenceAmadeus)
        Else
            AddReference(CONXTextSeating, "0")
        End If

        If mReferences.ContainsKey(CONXTextPlainFormat) Then
            AddReference(CONXTextPlainFormat, mReferences(CONXTextPlainFormat).ReferenceAmadeus, mReferences(CONXTextPlainFormat).ReferenceAmadeus)
        Else
            AddReference(CONXTextPlainFormat, "0")
        End If

        If mReferences.ContainsKey(CONXVessel) Then
            AddReference(CONXVessel, mReferences(CONXVessel).ReferenceAmadeus, mReferences(CONXVessel).ReferenceAmadeus)
        Else
            AddReference(CONXVessel, "0")
        End If

    End Sub

    Private Sub CheckFileExists(Optional ByVal Rewrite As Boolean = False)

        Dim f As New FileInfo(mFileName)

        If Rewrite Or Not f.Exists Then
            If Not f.Directory.Exists Then
                f.Directory.Create()
            End If
            Dim GDSData As StreamWriter = f.CreateText()
            Dim xFile As New StringBuilder
            xFile.Clear()
            FillReference()

            For Each xKey As String In mReferences.Keys
                xFile.AppendLine(xKey & "=" & mReferences.Item(xKey).ReferenceAmadeus & "|" & mReferences.Item(xKey).ReferenceGalileo)
            Next

            GDSData.Write(xFile)
            GDSData.Close()

        End If

    End Sub

    Public Sub Save()
        CheckFileExists(True)
    End Sub

    Public ReadOnly Property Value(ByVal Key As String) As String
        Get

            ' "CountryCode"    ' %MID%
            ' "OfficePCC"      ' %PCC%
            ' "AgentQueue"     ' %AGENTQ%
            ' "AgentOPQueue"   ' %AGENTOPQ%
            ' "AgentName"      ' %AGENTNAME%
            ' "AgentEmail"     ' %AGENTEMAIL%
            ' "OfficeCityCode" ' %CITYCODE%
            ' "AOHPhone"       ' %AOHP%
            ' "Phone"          ' %PHONE%
            ' "AgentID"        ' %AgentID%
            ' "CityName"       ' %CITYNAME%

            Try

                Dim TempVal As String = ""

               
                TempVal = mReferences.Item(Key).ReferenceAmadeus

                If TempVal.IndexOf("%") >= 0 Then
                    TempVal = ReplaceReference(TempVal, "%MID%", "CountryCode")
                    TempVal = ReplaceReference(TempVal, "%PCC%", "OfficePCC")
                    TempVal = ReplaceReference(TempVal, "%AGENTQ%", "AgentQueue")
                    TempVal = ReplaceReference(TempVal, "%AGENTOPQ%", "AgentOPQueue")
                    TempVal = ReplaceReference(TempVal, "%AGENTNAME%", "AgentName")
                    TempVal = ReplaceReference(TempVal, "%AGENTEMAIL%", "AgentEmail")
                    TempVal = ReplaceReference(TempVal, "%CITYCODE%", "OfficeCityCode")
                    TempVal = ReplaceReference(TempVal, "%CITYNAME%", "CityName")
                    TempVal = ReplaceReference(TempVal, "%AOHP%", "AOHPhone")
                    TempVal = ReplaceReference(TempVal, "%PHONE%", "Phone")
                    TempVal = ReplaceReference(TempVal, "%OFFICENAME%", "OfficeName")
                    TempVal = ReplaceReference(TempVal, "%AgentID%", "AgentID")
                End If
                Value = TempVal

            Catch ex As Exception

                Throw New Exception("Key:" & Key & " not found in the collection")

            End Try
        End Get

    End Property

    Public ReadOnly Property isValid As Boolean
        Get
            With mReferences
                isValid = .Item("OfficePCC").ReferenceAmadeus <> "" And .Item("OfficePCC").ReferenceGalileo <> "" And _
                          .Item("AgentQueue").ReferenceAmadeus <> "" And .Item("AgentQueue").ReferenceGalileo <> "" And _
                          .Item("AgentOPQueue").ReferenceAmadeus <> "" And .Item("AgentOPQueue").ReferenceGalileo <> "" And _
                          .Item("AgentID").ReferenceAmadeus <> "" And .Item("AgentID").ReferenceGalileo <> "" And _
                          .Item("CountryCode").ReferenceAmadeus <> "" And _
                          .Item("AgentName").ReferenceAmadeus <> "" And _
                          .Item("AgentEmail").ReferenceAmadeus <> "" And _
                          .Item("OfficeCityCode").ReferenceAmadeus <> "" And _
                          .Item("CityName").ReferenceAmadeus <> "" And _
                          .Item("OfficeName").ReferenceAmadeus <> "" And _
                          .Item("AOHPhone").ReferenceAmadeus <> "" And _
                          .Item("Phone").ReferenceAmadeus <> "" And _
                          .Item("DataSourceACC").ReferenceAmadeus <> "" And
                          .Item("DataCatalogACC").ReferenceAmadeus <> "" And _
                          .Item("DataUserNameACC").ReferenceAmadeus <> "" And
                          .Item("DataUserPasswordACC").ReferenceAmadeus <> "" And _
                          .Item("DataSourcePNR").ReferenceAmadeus <> "" And
                          .Item("DataCatalogPNR").ReferenceAmadeus <> "" And _
                          .Item("DataUserNamePNR").ReferenceAmadeus <> "" And
                          .Item("DataUserPasswordPNR").ReferenceAmadeus <> ""
            End With
        End Get
    End Property

    Private Function ReplaceReference(ByVal InputValue As String, ByVal RefKey As String, ByVal RefValue As String)
        If InputValue.IndexOf(RefKey) >= 0 Then
            ReplaceReference = InputValue.Replace(RefKey, Value(RefValue))
        Else
            ReplaceReference = InputValue
        End If
    End Function
End Class
