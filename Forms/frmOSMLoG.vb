Public Class FrmOSMLoG
    Private mflgLoading As Boolean
    Private mobjAgent As osmVessels.emailItem
    Private mobjPNR As GDSPnr

    Friend Sub New(ByRef pPNR As GDSPnr)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mobjPNR = pPNR

    End Sub
    Public ReadOnly Property PortAgent As osmVessels.emailItem
        Get
            PortAgent = mobjAgent
        End Get
    End Property
    Public ReadOnly Property NoPortAgent As Boolean
        Get
            NoPortAgent = chkNoPortAgent.Checked
        End Get
    End Property
    Public ReadOnly Property SignedBy As String
        Get
            SignedBy = txtSignedBy.Text
        End Get
    End Property

    Private Sub FrmOSMLoG_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            mflgLoading = True
            If MySettings.OSMLoGPerPax Then
                optPerPax.IsChecked = True
            Else
                optPerPNR.IsChecked = True
            End If
            If MySettings.OSMLoGOnSigner Then
                optOnSigners.IsChecked = True
            Else
                optOffSigners.IsChecked = True
            End If
            If System.IO.Directory.Exists(MySettings.OSMLoGPath) Then
                brwFileDestination.Value = MySettings.OSMLoGPath
            Else
                brwFileDestination.Value = ""
            End If
            LoadAgents()
            ShowPNRDetails()
            EnableSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Close()
        Finally
            mflgLoading = False
        End Try
    End Sub
    Private Sub ShowPNRDetails()

        With mobjPNR
            If .Passengers.Count > 1 Then
                lblPax.Text = .Passengers.Count & " Passengers" & vbCrLf
            Else
                lblPax.Text = .Passengers.Count & " Passenger" & vbCrLf
            End If
            For Each pPax As GDSPax.GDSPaxitem In .Passengers.Values
                lblPax.Text &= pPax.ElementNo & ". " & pPax.PaxName & vbCrLf
            Next

            lblSegs.Text = ""
            For Each pSeg As GDSSeg.GDSSegItem In .Segments.Values
                With pSeg
                    lblSegs.Text &= .Airline & " " & .FlightNo.PadLeft(5) & " " & .DepartureDateIATA.PadLeft(6) & " " & .BoardPoint & " " & .OffPoint & " " & Format(.DepartTime, "HHmm") & vbCrLf
                End With
            Next
            If .BookedBy.IndexOf("-") > 0 Then
                txtSignedBy.Text = .BookedBy.Substring(0, .BookedBy.IndexOf("-"))
            Else
                txtSignedBy.Text = .BookedBy
            End If

        End With
    End Sub
    Private Sub LoadAgents()

        Dim pAgents As New osmVessels.EmailCollection
        mflgLoading = True
        pAgents.Load()

        lstPortAgent.Items.Clear()
        For Each pAgent As osmVessels.emailItem In pAgents.Values
            pAgent.SetNameOnly()
            lstPortAgent.Items.Add(pAgent)
        Next
        mflgLoading = False
    End Sub
    Private Sub lstPortAgent_SelectedItemChanged(sender As Object, e As EventArgs) Handles lstPortAgent.SelectedItemChanged
        If Not mflgLoading Then
            Dim pAgent As New osmVessels.emailItem
            If Not lstPortAgent.SelectedItem Is Nothing AndAlso Object.ReferenceEquals(lstPortAgent.SelectedItem.Value.GetType, pAgent.GetType) Then
                mobjAgent = lstPortAgent.SelectedItem.Value
                RadGroupBox3.Text = mobjAgent.Name
            Else
                mobjAgent = Nothing
                RadGroupBox3.Text = "Port Agent"
            End If
            chkNoPortAgent.Checked = False
            EnableSelection()
        End If
    End Sub
    Private Sub EnableSelection()
        cmdCreatePDF.Enabled = ((optPerPax.IsChecked Or optPerPNR.IsChecked) And (optOnSigners.IsChecked Or optOffSigners.IsChecked) And brwFileDestination.Value <> "" And (Not mobjAgent Is Nothing Or chkNoPortAgent.Checked))
    End Sub
    Private Sub Option_CheckedChanged(sender As Object, e As EventArgs) Handles optPerPax.CheckStateChanged, optPerPNR.CheckStateChanged, optOnSigners.CheckStateChanged, optOffSigners.CheckStateChanged, brwFileDestination.ValueChanged, chkNoPortAgent.CheckStateChanged
        If Not mflgLoading Then
            If chkNoPortAgent.Checked Then
                RadGroupBox3.Text = "No Port Agent"
            ElseIf Not mobjAgent Is Nothing Then
                RadGroupBox3.Text = mobjAgent.Name
            Else
                RadGroupBox3.Text = "Port Agent"
            End If
            MySettings.OSMLoGPerPax = optPerPax.IsChecked
            MySettings.OSMLoGOnSigner = optOnSigners.IsChecked
            MySettings.OSMLoGPath = brwFileDestination.Value ' txtFileDestination.Text
            MySettings.Save()
            EnableSelection()
        End If
    End Sub
    Private Sub cmdCreatePDF_Click(sender As Object, e As EventArgs) Handles cmdCreatePDF.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub brwFileDestination_ValueChanged(sender As Object, e As EventArgs) Handles brwFileDestination.ValueChanged
        EnableSelection()
    End Sub
End Class
