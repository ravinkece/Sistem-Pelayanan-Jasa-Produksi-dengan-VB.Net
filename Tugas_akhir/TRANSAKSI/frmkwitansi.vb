Public Class frmkwitansi
    Dim objkwitansi As New clskwitansi
    Private Sub frmkwitansi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtnokwitansi.Text = objkwitansi.Autonumber
        txtnokwitansi.Enabled = False
        btnsimpan.Enabled = False
    End Sub

    Private Sub btncarispk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncarispk.Click
        frmpopupkwt.Show()
        btnsimpan.Enabled = True
    End Sub

    Private Sub btncetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        If txtnospk.Text = "" Or txtnmkendaraan.Text = "" Or txttglspk.Text = "" Or txtnominal.Text = "" Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Information, "INFORMASI")
        Else
            Dim nilaikembali1 As Integer
            objkwitansi.PNo_Kwitansi = txtnokwitansi.Text
            objkwitansi.PTgl_Kwitansi = Format(dtptglkwitansi.Value, "yyy-MM-dd")
            objkwitansi.PNo_SPK = txtnospk.Text
            nilaikembali1 = objkwitansi.Simpan()
            If nilaikembali1 = 1 Then
                MsgBox("Data Berhasil Disimpan", MsgBoxStyle.Information, "INFORMASI")
            End If
            txtnokwitansi.Text = objkwitansi.Autonumber
        End If
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnmkendaraan.Clear()
            txtnominal.Clear()
            txtnospk.Clear()
            txttglspk.Clear()
            txtnokwitansi.Text = objkwitansi.Autonumber
        End If
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        txtnmkendaraan.Clear()
        txtnominal.Clear()
        txtnospk.Clear()
        txttglspk.Clear()
        txtnokwitansi.Text = objkwitansi.Autonumber
        btnsimpan.Enabled = False
    End Sub
End Class