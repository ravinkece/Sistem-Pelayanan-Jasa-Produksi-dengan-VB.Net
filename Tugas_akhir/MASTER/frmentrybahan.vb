Public Class frmentrybahan
    Dim objbahan As New clsbahan
    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        Dim nilai As Integer
        If txtnmbahan.Text = "" Or txthrg.Text = "" Or cmbjenis.Text = "" Then
            MsgBox("Terdapat Data Kosong")
        Else
            objbahan.PKdBahan = txtkdbahan.Text
            objbahan.PNmBahan = txtnmbahan.Text
            objbahan.PJnsBahan = cmbjenis.Text
            objbahan.PHrgBahan = txthrg.Text
            objbahan.PSatuan = txtsatuan.Text
            nilai = objbahan.simpan()
            If nilai = 1 Then
                MsgBox("Data Berhasil Disimpan")
            Else
                MsgBox("Data Gagal Disimpan")
            End If
            txtnmbahan.Clear()
            txthrg.Clear()
            cmbjenis.Text = ""
            txtsatuan.Clear()
            txtkdbahan.Text = objbahan.autonumber
            txtnmbahan.Focus()
        End If
    End Sub

    Private Sub btnubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnubah.Click
        Dim nilai As Integer
        objbahan.PKdBahan = txtkdbahan.Text
        objbahan.PNmBahan = txtnmbahan.Text
        objbahan.PJnsBahan = cmbjenis.Text
        objbahan.PHrgBahan = txthrg.Text
        objbahan.PSatuan = txtsatuan.Text
        nilai = objbahan.ubah()
        If nilai = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin mengubah data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Diubah")
            End If
        Else
            MsgBox("Data Gagal Diubah")
        End If
        txtnmbahan.Clear()
        txthrg.Clear()
        cmbjenis.Text = ""
        txtsatuan.Clear()
        txtkdbahan.Text = objbahan.autonumber
        txtkdbahan.Enabled = False
        btncari.Enabled = True
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtnmbahan.Focus()
    End Sub

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapus.Click
        Dim nilai As Integer
        objbahan.PKdBahan = txtkdbahan.Text
        objbahan.PNmBahan = txtnmbahan.Text
        objbahan.PJnsBahan = cmbjenis.Text
        objbahan.PHrgBahan = txthrg.Text
        objbahan.PSatuan = txtsatuan.Text
        nilai = objbahan.hapus()
        If nilai = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin menghapus data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Dihapus")
            End If
        Else
            MsgBox("Data Gagal Dihapus")
        End If
        txtnmbahan.Clear()
        txthrg.Clear()
        cmbjenis.Text = ""
        txtsatuan.Clear()
        txtkdbahan.Text = objbahan.autonumber
        txtkdbahan.Enabled = False
        btncari.Enabled = True
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtnmbahan.Focus()
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        txtnmbahan.Clear()
        txthrg.Clear()
        cmbjenis.Text = ""
        txtsatuan.Clear()
        txtkdbahan.Text = objbahan.autonumber
    End Sub

    Private Sub frmentrybahan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtkdbahan.Text = objbahan.autonumber
        txtkdbahan.Enabled = False
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txthrg.MaxLength = 10
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnmbahan.Clear()
            txthrg.Clear()
            cmbjenis.Text = ""
            txtsatuan.Clear()
            txtkdbahan.Text = objbahan.autonumber
        End If
    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        Dim opop As New frmpopupbahan
        opop.ShowDialog()

        If opop.refkdbahan <> "" Then
            txtkdbahan.Text = opop.refkdbahan
            txtnmbahan.Text = opop.refnmbahan
            txthrg.Text = opop.refhrg
            cmbjenis.Text = opop.refjenis
            txtsatuan.Text = opop.refsatuan
            btnsimpan.Enabled = False
            btnubah.Enabled = True
            btnhapus.Enabled = True
        End If
        txtkdbahan.Enabled = False
    End Sub

    Private Sub txthrg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthrg.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub

    Private Sub txthrg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthrg.TextChanged

    End Sub
End Class