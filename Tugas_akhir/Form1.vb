Imports System.Data.Odbc
Public Class Form1
    Dim Query As String
    Dim xmyread As OdbcDataReader
    Dim xmycmd As OdbcCommand
    Public Sub tampildata()

        Dim sql As String

        sql = "SELECT no_faktur,tgl_kirim, DATE_SUB(tgl_kirim, INTERVAL 3 DAY) as '1' from(faktur) where no_faktur not in( select no_faktur from spk) and DATE_SUB(tgl_kirim, INTERVAL 3 DAY) like curdate()"
        xmycmd = New OdbcCommand(sql, MyCnn)

        Try

            dreader = xmycmd.ExecuteReader
            lvpp.Items.Clear()
            While dreader.Read

                With lvpp.Items.Add(dreader("no_faktur"))
                    txttgl.Text = dreader.Item("1")
                    frmspk.txtnofaktur.Text = dreader.Item("no_faktur")

                End With
            End While
        Finally
        End Try
    End Sub

    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call tampildata()
        If txttgl.Text = "" Then
            Timer1.Enabled = True
        Else
            MessageBox.Show("Pemesanan Kendaraan Harus dilakukan", "Peringatan", MessageBoxButtons.OK)
            frmspk.ShowDialog()
            txttgl.Text = frmspk.dtptglspk.Value
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        'txttglskr.Text = "2018-01-25"
        
        Timer1.Enabled = True
        Dim hari As String
        hari = Format(Now, "dddd")
        Select Case hari.ToLower
            Case "sunday" : hari = "Minggu"
            Case "monday" : hari = "Senin"
            Case "tuesday" : hari = "Selasa"
            Case "wednesday" : hari = "Rabu"
            Case "thursday" : hari = "Kamis"
            Case "friday" : hari = "Jumat"
            Case "saturday" : hari = "Sabtu"
        End Select
        StatusStrip1.Items(0).Text = " " & hari & ", " & Format(Now, "dd-MM-yyyy") & " "
        Timer2.Start()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            LoginForm1.Show()
            LoginForm1.txtuser.Clear()
            LoginForm1.txtpass.Clear()
            LoginForm1.txtuser.Focus()
            frmspk.txtkdstaff.Clear()
            frmpembelianbahan.txtkdstaff.Clear()
            frmpengajuan.txtkdstaff.Clear()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        StatusStrip1.Items(0).Text = "  " & CStr(TimeOfDay)
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Label2.Left = Label2.Left + 1
        If Label2.Width <= 0 Then
            Label2.Left = Label2.Left - 1
        End If
    End Sub

    Private Sub ENTRYCUSTOMERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRYCUSTOMERToolStripMenuItem.Click
        frmentrycustomer.Show()
    End Sub

    Private Sub ENTRYSTAFFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRYSTAFFToolStripMenuItem.Click
        frmentrystaff.Show()
    End Sub

    Private Sub ENTRYBAHANToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRYBAHANToolStripMenuItem.Click
        frmentrybahan.Show()
    End Sub

    Private Sub ENTRYPRODUKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRYPRODUKToolStripMenuItem.Click
        frmentryproduk.Show()
    End Sub

    Private Sub ENTRYSAMPLEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRYSAMPLEToolStripMenuItem.Click
        frmsample.Show()
    End Sub

    Private Sub ENTRYKENDARAANToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRYKENDARAANToolStripMenuItem.Click
        frmentrykendaraan.Show()
    End Sub

    Private Sub ENTRYKURIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRYKURIRToolStripMenuItem.Click
        frmentrykurir.Show()
    End Sub
    Private Sub ENTRYSUPPLIERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRYSUPPLIERToolStripMenuItem.Click
        frmentrysupplier.Show()
    End Sub

    Private Sub ENTRYPEMBELIANBAHANToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRYPEMBELIANBAHANToolStripMenuItem.Click
        frmpembelianbahan.Show()
    End Sub

    Private Sub PENGADAANBARANGToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PENGADAANBARANGToolStripMenuItem.Click
        frmpengajuan.Show()
    End Sub

    Private Sub ENTRYPPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRYPPToolStripMenuItem.Click
        frmPP.Show()
    End Sub

    Private Sub CETAKLBBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CETAKLBBToolStripMenuItem.Click
        frmlbb.Show()
    End Sub

    Private Sub CETAKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CETAKToolStripMenuItem.Click
        frmfaktur.Show()
    End Sub

    Private Sub ENTRYKWITANSIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENTRYKWITANSIToolStripMenuItem.Click
        frmkwitansi.Show()
    End Sub

    Private Sub CETAKToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmspk.Show()
    End Sub

    Private Sub CETAKJPPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmjpp.Show()
    End Sub

    Private Sub CETAKToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CETAKToolStripMenuItem2.Click
        frmretur.Show()
    End Sub

    Private Sub PENGEMBALIANBARANGToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PENGEMBALIANBARANGToolStripMenuItem.Click
        frmbphd.Show()
    End Sub

    Private Sub LAPORANPEMINJAMANToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LAPORANPEMINJAMANToolStripMenuItem.Click
        frmlappenjualan.Show()
    End Sub

    Private Sub LAPORANPENGADAANToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LAPORANPENGADAANToolStripMenuItem.Click
        frmlappemesanankendaraan.Show()
    End Sub

    Private Sub LAPORANINVENTARISToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LAPORANINVENTARISToolStripMenuItem.Click
        frmlappengirimanbrgvb.Show()
    End Sub

    Private Sub LAPORANPEMBELIANBAHANToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LAPORANPEMBELIANBAHANToolStripMenuItem.Click
        frmlappembelianbahan.Show()
    End Sub

    Private Sub LAPORANRETURBARANGToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LAPORANRETURBARANGToolStripMenuItem.Click
        frmlapretur.Show()
    End Sub

    Private Sub LAPORANSEPATUTERBANYAKDIPESANToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LAPORANSEPATUTERBANYAKDIPESANToolStripMenuItem.Click
        frmlapsepatuterbanyak.Show()
    End Sub
End Class
