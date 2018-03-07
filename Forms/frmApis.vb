Public Class frmApis


    Private WithEvents mobjHostSession As k1aHostToolKit.HostSession
    Private mstrResponse As String

    Private mobjPNR As s1aPNR.PNR
    'Private mflgQRSegment As Boolean




    Private Sub mobjHostSession_ReceivedResponse(ByRef newResponse As k1aHostToolKit.CHostResponse) Handles mobjHostSession.ReceivedResponse

        mstrResponse = newResponse.Text

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Me.Close()

    End Sub

    Private Sub frmApis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        APISPrepareGrid()

    End Sub

    Private Sub APISPrepareGrid()

        dgvApis.Columns.Clear()
        dgvApis.Columns.Add("Id", "Id")
        dgvApis.Columns.Add("Surname", "Surname")
        dgvApis.Columns.Add("FirstName", "First Name")
        dgvApis.Columns.Add("IssuingCountry", "Issuing Country")
        dgvApis.Columns.Add("Passportnumber", "Passport number")
        dgvApis.Columns.Add("Nationality", "Nationality")
        dgvApis.Columns.Add("BirthDate", "Birth Date")
        dgvApis.Columns.Add("Gender", "Gender")
        dgvApis.Columns.Add("ExpiryDate", "Expiry Date")
        dgvApis.Columns.Add("QRFreqFlyer", "QR FRreq.Flyer")

    End Sub


End Class
