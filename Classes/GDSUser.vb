Option Strict Off
Option Explicit On
Public Class GDSUser

    Private Structure ClassProps
        Dim GDSCode As Config.GDSCode
        Dim PCC As String
        Dim User As String
        Private Sub New(ByVal pGDS As String)
            GDSCode = Config.GDSCode.GDSisUnknown
            PCC = ""
            User = ""
        End Sub
    End Structure
    Private WithEvents mobjSession As k1aHostToolKit.HostSession
    Private mudtProps As New ClassProps
    Private mstrResponse As String

    Public Sub New(ByVal pGDSCode As Config.GDSCode)

        Try
            mudtProps.GDSCode = pGDSCode
            mudtProps.PCC = ""
            mudtProps.User = ""
            If pGDSCode = Config.GDSCode.GDSisAmadeus Then
                Read1AUser()
            ElseIf pGDSCode = Config.GDSCode.GDSisGalileo Then
                Read1GUser()
            Else
                Throw New Exception("GDS not available")
            End If

            If mudtProps.PCC = "" Or mudtProps.User = "" Then
                Throw New Exception("Please start " & If(mudtProps.GDSCode = Config.GDSCode.GDSisAmadeus, "Amadeus", "Galileo") & " and restart the program")
            End If
        Catch ex As Exception
            Throw New Exception("GDS Error" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Read1AUser()

        Dim Sessions As k1aHostToolKit.HostSessions
        ' To be able to retrieve the PNR that have been created we need to link our '
        ' application to the current session of the FOS                             '
        Sessions = New k1aHostToolKit.HostSessions
        If Sessions.Count > 0 Then
            ' There is at least one session opened.                    '
            ' We link our application to the active session of the FOS '
            mobjSession = Sessions.UIActiveSession
            mobjSession.Send("JGD/C")
            Dim pLines() As String = mstrResponse.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            For i As Integer = 0 To pLines.GetUpperBound(0)
                If pLines(i).Trim.StartsWith("OFFICE") Then
                    mudtProps.PCC = pLines(i).Substring(pLines(i).IndexOf("-") + 1).Trim
                ElseIf pLines(i).Trim.StartsWith("SIGN ") Then
                    mudtProps.User = pLines(i).Substring(pLines(i).IndexOf("-") + 1).Trim
                End If
            Next
        End If
    End Sub
    Private Sub Read1GUser()
        Try
            Dim Session As New Travelport.TravelData.Factory.GalileoDesktopFactory("SPG720", "MYCONNECTION", False, True, "SMRT")
            Dim response() As String = Session.SendTerminalCommand("OP/W*").ToArray
            For i As Integer = 0 To response.GetUpperBound(0)
                If response(i).Length > 45 AndAlso response(i).Substring(31, 6) = "ACTIVE" Then
                    mudtProps.User = response(i).Substring(12, 6)
                    mudtProps.PCC = response(i).Substring(24, 4)
                    Exit For
                End If
            Next
            If mudtProps.User = "" Then
                Throw New Exception(response(0))
            End If
        Catch ex As Travelport.TravelData.DesktopUserNotSignedOnException
            Throw New Exception("Please sign in to Galileo/Smartpoint")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
    Public ReadOnly Property GDSCode As Config.GDSCode
        Get
            GDSCode = mudtProps.GDSCode
        End Get
    End Property
    Public ReadOnly Property PCC As String
        Get
            PCC = mudtProps.PCC.ToUpper
        End Get
    End Property
    Public ReadOnly Property User As String
        Get
            User = mudtProps.User.ToUpper
        End Get
    End Property
    Private Sub mobjSession_ReceivedResponse(ByRef newResponse As k1aHostToolKit.CHostResponse) Handles mobjSession.ReceivedResponse

        mstrResponse = newResponse.Text

    End Sub


End Class
