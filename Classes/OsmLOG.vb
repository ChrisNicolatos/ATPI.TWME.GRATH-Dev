Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Friend Class OsmLOG
    Private mobjPNR As GDSPnr
    Private mobjPortAgent As osmVessels.emailItem
    Private mflgNoPortAgent As Boolean
    Private mstrSignedBy As String
    Public Sub CreatePDF(ByRef pPNR As GDSPnr)

        mobjPNR = pPNR
        ReadOptions()

    End Sub
    Private Function CreateDocs() As String

        Dim pFileName As String = ""
        Dim pstrTextCrewMembers As String = "crew member listed below is scheduled" ' default text is for one pax

        CreateDocs = ""
        If MySettings.OSMLoGPerPax Then
            For Each pPax As GDSPax.GDSPaxitem In mobjPNR.Passengers.Values
                pFileName = GetPDFFileName(mobjPNR.RequestedPNR & "-" & pPax.ElementNo & pPax.LastName)
                MakePDFDocument(pFileName, pstrTextCrewMembers, pPax)
                CreateDocs &= pFileName & vbCrLf
            Next pPax
        Else
            If mobjPNR.Passengers.Count > 1 Then
                pstrTextCrewMembers = "crew members listed below are scheduled"
            End If
            pFileName = GetPDFFileName(mobjPNR.RequestedPNR)
            MakePDFDocument(pFileName, pstrTextCrewMembers)
            CreateDocs = pFileName
        End If


    End Function
    Private Sub MakePDFDocument(ByVal pFileName As String, ByVal CrewMembersText As String, Optional ByRef pPax As GDSPax.GDSPaxitem = Nothing)

        Dim pLogoFile As String = System.IO.Path.Combine(MyConfigPath, "OSM Maritime logo.png")
        Dim gif As Image = Image.GetInstance(pLogoFile)
        Dim pDoc As New Document(PageSize.A4, 36, 36, 36, 36)
        Dim pArial11 As Font = FontFactory.GetFont("arial", 11, FontStyle.Regular)
        Dim pArial11b As Font = FontFactory.GetFont("arial", 11, FontStyle.Bold)
        Dim pArial12 As Font = FontFactory.GetFont("arial", 12, FontStyle.Regular)
        Dim pArial16b As Font = FontFactory.GetFont("arial", 16, FontStyle.Bold)

        PdfWriter.GetInstance(pDoc, New FileStream(pFileName, FileMode.Create))
        pDoc.Open()
        gif.ScalePercent(40)
        pDoc.Add(gif)

        pDoc.Add(AddParagraph("LETTER OF GUARANTEE", pArial16b, 14, 14, "Center"))
        pDoc.Add(AddParagraph(Format(Now, "dd/MM/yyyy"), pArial12, 0, 14, "Right"))

        pDoc.Add(AddParagraph("To Whom It May Concern", pArial11, 0, 14, "Left"))

        If MySettings.OSMLoGOnSigner Then
            pDoc.Add(AddParagraph("We hereby declare that our " & CrewMembersText & " to arrive on " & mobjPNR.LastSegment.ArrivalDate & " to embark the vessel/rig " & mobjPNR.VesselName & " in " & mobjPNR.LastSegment.OffPointCityName & If(mobjPNR.LastSegment.OffPointCountryName <> "", ", " & mobjPNR.LastSegment.OffPointCountryName, ""), pArial11, 0, 6, "Left"))
        Else
            pDoc.Add(AddParagraph("We hereby declare that our " & CrewMembersText & " to depart on " & mobjPNR.FirstSegment.DepartureDate & " to disembark the vessel/rig " & mobjPNR.VesselName & " in " & mobjPNR.FirstSegment.BoardCityName & If(mobjPNR.FirstSegment.BoardCountryName <> "", ", " & mobjPNR.FirstSegment.BoardCountryName, ""), pArial11, 0, 6, "Left"))
        End If
        pDoc.Add(AddParagraph("By carrying this letter, the crew is entitled to travel on maritime/offshore fares.", pArial11, 0, 0, "Left"))

        If pPax Is Nothing Then
            pDoc.Add(MakePaxTable(mobjPNR.Passengers, pArial11, pArial11b))
        Else
            pDoc.Add(MakePaxTable(pPax, pArial11, pArial11b))
        End If

        pDoc.Add(AddParagraph("Travel Itinerary (subject to change):", pArial11b, 0, 0, "Left"))
        pDoc.Add(MakeSegTable(mobjPNR.Segments, pArial11))

        If Not mflgNoPortAgent And Not mobjPortAgent Is Nothing Then
            pDoc.Add(AddParagraph("PORT AGENT", pArial11b, 7, 0, "Left"))
            pDoc.Add(AddParagraph(mobjPortAgent.Name, pArial11, 0, 0, "Left"))
            pDoc.Add(AddParagraph(mobjPortAgent.Details, pArial11, 0, 0, "Left"))
            pDoc.Add(AddParagraph(mobjPortAgent.Email, pArial11, 0, 7, "Left"))
        End If
        pDoc.Add(AddParagraph("We ask you kindly to render all necessary assistance.", pArial11, 0, 0, "Left"))
        pDoc.Add(AddParagraph("We confirm that " & mobjPNR.ClientName & " will cover all expenses that may occur in connection with our employee's travel.", pArial11, 0, 14, "Left"))
        pDoc.Add(AddParagraph("If you need any further information, please contact our employer as stated below.", pArial11, 0, 14, "Left"))
        pDoc.Add(AddParagraph("Sincerely,", pArial11, 0, 14, "Left"))
        pDoc.Add(AddParagraph(mstrSignedBy, pArial11, 0, 0, "Left"))
        pDoc.Add(AddParagraph("Crewing", pArial11, 0, 14, "Left"))
        pDoc.Add(AddParagraph("On behalf of", pArial11, 0, 0, "Left"))
        pDoc.Add(AddParagraph("OSM Crew Management Limited", pArial11b, 0, 0, "Left"))
        pDoc.Add(AddParagraph("Address: OSM HOUSE, 22 Amathountos Avenue Agios Tychonas 4532 Limassol, Cyprus", pArial11, 0, 0, "Left"))
        pDoc.Add(AddParagraph("Phone: +357 25 33 55 01", pArial11, 0, 0, "Left"))

        pDoc.Close()

    End Sub
    Private Function GetPDFFileName(ByVal FileNameDetails As String) As String
        If FileNameDetails = "" Then
            FileNameDetails = "PNR" & Format(Now, "yyyyMMdd")
        End If
        GetPDFFileName = System.IO.Path.Combine(MySettings.OSMLoGPath, FileNameDetails & ".pdf")
        Dim pTemp As Integer = 0
        Do While System.IO.File.Exists(GetPDFFileName)
            pTemp += 1
            GetPDFFileName = System.IO.Path.Combine(MySettings.OSMLoGPath, FileNameDetails & "-" & pTemp & ".pdf")
        Loop

    End Function
    Private Function AddParagraph(ByVal pText As String, ByVal pFont As Font, ByVal pSpacingBefore As Integer, ByVal pSpacingAfter As Integer, ByVal pAlignment As String) As Paragraph

        Dim x2 As New Paragraph(pText, pFont) With {
            .SpacingBefore = pSpacingBefore,
            .SpacingAfter = pSpacingAfter
        }
        x2.SetAlignment(pAlignment)

        AddParagraph = x2

    End Function
    Private Function MakePaxTable(ByRef pPassengers As GDSPax.GDSPaxColl, ByVal pFont As Font, ByVal pHeaderFont As Font) As PdfPTable

        Dim Table As New PdfPTable(2) With {
            .LockedWidth = False,
            .HorizontalAlignment = 0,
            .SpacingBefore = 14,
            .SpacingAfter = 14
        }

        Dim pPosition As Boolean = False
        For Each pPax As GDSPax.GDSPaxitem In pPassengers.Values
            If pPax.IdNo <> "" Then
                pPosition = True
                Exit For
            End If
        Next pPax
        'relative col widths in proportions - 2/3 And 1/3
        Dim widths() As Single = {2, 1}
        Table.SetWidths(widths)
        Table.AddCell(AddCell("Name", pHeaderFont))
        If pPosition Then
            Table.AddCell(AddCell("Position", pHeaderFont))
        Else
            Table.AddCell(AddCell(" ", pHeaderFont))
        End If

        For Each pPax As GDSPax.GDSPaxitem In pPassengers.Values
            Table.AddCell(AddCell(pPax.PaxName, pFont))
            Table.AddCell(AddCell(pPax.IdNo, pFont))
        Next pPax

        MakePaxTable = Table

    End Function
    Private Function MakePaxTable(ByRef pPax As GDSPax.GDSPaxitem, ByVal pFont As Font, ByVal pHeaderFont As Font) As PdfPTable

        Dim Table As New PdfPTable(2) With {
            .LockedWidth = False,
            .HorizontalAlignment = 0,
            .SpacingBefore = 14,
            .SpacingAfter = 14
        }

        'relative col widths in proportions - 2/3 And 1/3
        Dim widths() As Single = {2, 1}
        Table.SetWidths(widths)
        Table.AddCell(AddCell("Name", pHeaderFont))
        If pPax.IdNo = "" Then
            Table.AddCell(AddCell(" ", pHeaderFont))
        Else
            Table.AddCell(AddCell("Position", pHeaderFont))
        End If

        Table.AddCell(AddCell(pPax.PaxName, pFont))
        Table.AddCell(AddCell(pPax.IdNo, pFont))


        MakePaxTable = Table

    End Function
    Private Function MakeSegTable(ByRef pSegs As GDSSeg.GDSSegColl, ByVal pFont As Font) As PdfPTable

        Dim pWidths(6) As Integer
        Dim pVBFont As New Drawing.Font(pFont.Familyname, pFont.Size, If(pFont.IsBold, FontStyle.Bold, FontStyle.Regular))
        Dim pfrm As New frmOSMLoG(mobjPNR)
        Dim g As Graphics = pfrm.CreateGraphics

        Dim Table As New PdfPTable(7) With {
            .LockedWidth = False,
            .HorizontalAlignment = 0,
            .SpacingBefore = 14,
            .SpacingAfter = 14
        }
        For Each pSeg As GDSSeg.GDSSegItem In pSegs.Values
            With pSeg

                pWidths(0) = Math.Max(pWidths(0), g.MeasureString(.Airline, pVBFont).Width)
                pWidths(1) = Math.Max(pWidths(1), g.MeasureString(.FlightNo, pVBFont).Width)
                pWidths(2) = Math.Max(pWidths(2), g.MeasureString(.DepartureDateIATA, pVBFont).Width)
                pWidths(3) = Math.Max(pWidths(3), g.MeasureString(.BoardCityName, pVBFont).Width)
                pWidths(4) = Math.Max(pWidths(4), g.MeasureString(.OffPointCityName, pVBFont).Width)
                pWidths(5) = Math.Max(pWidths(5), g.MeasureString(Format(.DepartTime, "HHmm"), pVBFont).Width)
                pWidths(6) = Math.Max(pWidths(6), g.MeasureString(Format(.ArriveTime, "HHmm"), pVBFont).Width)
            End With
        Next
        'relative col widths in proportions - 2/3 And 1/3

        Table.SetWidths(pWidths)

        For Each pSeg As GDSSeg.GDSSegItem In pSegs.Values
            With pSeg
                Table.AddCell(AddCell(.Airline, pFont))
                Table.AddCell(AddCell(.FlightNo, pFont))
                Table.AddCell(AddCell(.DepartureDateIATA, pFont))
                Table.AddCell(AddCell(.BoardCityName, pFont))
                Table.AddCell(AddCell(.OffPointCityName, pFont))
                Table.AddCell(AddCell(Format(.DepartTime, "HHmm"), pFont))
                Table.AddCell(AddCell(Format(.ArriveTime, "HHmm"), pFont))
            End With
        Next

        MakeSegTable = Table

    End Function
    Private Function AddCell(ByVal pText As String, ByVal pFont As Font) As PdfPCell
        Dim c1 As New PdfPCell(New Phrase(pText, pFont)) With {
                    .Border = Rectangle.NO_BORDER
                }
        AddCell = c1
    End Function
    Private Sub ReadOptions()

        Dim pFrm As New frmOSMLoG(mobjPNR)
        If pFrm.ShowDialog() = DialogResult.OK Then
            mflgNoPortAgent = pFrm.NoPortAgent
            mobjPortAgent = pFrm.PortAgent
            mstrSignedBy = pFrm.SignedBy
            pFrm.Close()
            Dim pStatus As String = CreateDocs()
            MessageBox.Show(pStatus, "Create PDF File(s)", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Cancelled")
        End If

    End Sub
End Class
