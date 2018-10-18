Public Class frmspk
    Dim objspk As New clsspk
    Private Sub frmspk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtnospk.Text = objspk.Autonumber
        txtnospk.Enabled = False
        dtptglspk.Enabled = False
    End Sub

    Private Sub btncetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncetak.Click
        If txtkdkurir.Text = "" Or txtnoplat.Text = "" Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Information, "INFORMASI")
        Else
            Dim nilaikembali1 As Integer
            objspk.PNo_SPK = txtnospk.Text
            objspk.PTgl_SPK = Format(dtptglspk.Value, "yyy-MM-dd")
            objspk.PNo_Plat = txtnoplat.Text
            objspk.PKd_Kurir = txtkdkurir.Text
            objspk.PKd_Staff = txtkdstaff.Text
            objspk.PNo_Faktur = txtnofaktur.Text
            nilaikembali1 = objspk.Simpan()
            If nilaikembali1 = 1 Then
                MsgBox("Data Berhasil Disimpan", MsgBoxStyle.Information, "INFORMASI")
                ModuleCetak.CetakCR_SPK1(txtnospk.Text)
            End If
            txtnospk.Text = objspk.Autonumber
        End If
    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        Dim opop As New frmpopupkurir
        opop.ShowDialog()

        If opop.refkdkurir <> "" Then
            txtkdkurir.Text = opop.refkdkurir
            txtnmkurir.Text = opop.refnmkurir
            txtnotelp.Text = opop.reftelp
        End If
    End Sub

    Private Sub btncarikend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncarikend.Click
        Dim opop As New frmpopupkendaraan
        opop.ShowDialog()
        If opop.refnoplat <> "" Then
            txtnoplat.Text = opop.refnoplat
            txtnmkend.Text = opop.refnmkend
            txtjenis.Text = opop.refjenis
            txtmerk.Text = opop.refmerk
            txtmuatan.Text = opop.refmuatan
            txtharga.Text = opop.refharga
        End If
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        txtnospk.Text = objspk.Autonumber
        txtkdkurir.Clear()
        txtnmkurir.Clear()
        txtnotelp.Clear()
        txtnoplat.Clear()
        txtnmkend.Clear()
        txtjenis.Clear()
        txtharga.Clear()
        txtmerk.Clear()
        txtmuatan.Clear()
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        Form1.Show()
        'frmspk.Hide()
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class