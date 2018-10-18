Public Class frmentrysupplier
    Dim objsupp As New clssupplier
    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        Dim nilai As Integer
        If txtnmsupp.Text = "" Or txtemail.Text = "" Or txttelp.Text = "" Or txtalamat.Text = "" Then
            MsgBox("Terdapat Data Kosong")
        Else
            objsupp.PKd_Supplier = txtkdsupp.Text
            objsupp.PNm_Supplier = txtnmsupp.Text
            objsupp.PAlamat = txtalamat.Text
            objsupp.PTelp = txttelp.Text
            objsupp.PEmail = txtemail.Text
            nilai = objsupp.Simpan()
            If nilai = 1 Then
                MsgBox("Data Berhasil Disimpan")
            Else
                MsgBox("Data Gagal Disimpan")
            End If
            txtnmsupp.Clear()
            txtalamat.Clear()
            txtemail.Clear()
            txttelp.Clear()
            txtkdsupp.Text = objsupp.Autonumber
            txtnmsupp.Focus()
        End If
    End Sub

    Private Sub frmentrysupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtkdsupp.Text = objsupp.Autonumber()
        txtkdsupp.Enabled = False
        txtnmsupp.Focus()
        txttelp.MaxLength = 12
        btnubah.Enabled = False
        btnhapus.Enabled = False
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnmsupp.Clear()
            txtalamat.Clear()
            txtemail.Clear()
            txttelp.Clear()
            txtkdsupp.Text = objsupp.Autonumber
        End If
    End Sub

    Private Sub btnubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnubah.Click
        Dim nilai As Integer
        objsupp.PKd_Supplier = txtkdsupp.Text
        objsupp.PNm_Supplier = txtnmsupp.Text
        objsupp.PAlamat = txtalamat.Text
        objsupp.PTelp = txttelp.Text
        objsupp.PEmail = txtemail.Text
        nilai = objsupp.Ubah()
        If nilai = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin mengubah data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Diubah")
            End If
        Else
            MsgBox("Data Gagal Diubah")
        End If
        txtnmsupp.Clear()
        txtalamat.Clear()
        txtemail.Clear()
        txttelp.Clear()
        txtkdsupp.Text = objsupp.Autonumber
        txtkdsupp.Enabled = False
        btncari.Enabled = True
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtnmsupp.Focus()
    End Sub

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapus.Click
        Dim nilai As Integer
        objsupp.PKd_Supplier = txtkdsupp.Text
        objsupp.PNm_Supplier = txtnmsupp.Text
        objsupp.PAlamat = txtalamat.Text
        objsupp.PTelp = txttelp.Text
        objsupp.PEmail = txtemail.Text
        nilai = objsupp.Hapus()
        If nilai = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin menghapus data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Dihapus")
            End If
        Else
            MsgBox("Data Gagal Dihapus")
        End If
        txtnmsupp.Clear()
        txtalamat.Clear()
        txtemail.Clear()
        txttelp.Clear()
        txtkdsupp.Text = objsupp.Autonumber
        txtkdsupp.Enabled = False
        btncari.Enabled = True
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtnmsupp.Focus()
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        txtnmsupp.Clear()
        txtalamat.Clear()
        txtemail.Clear()
        txttelp.Clear()
        txtkdsupp.Text = objsupp.Autonumber
        txtnmsupp.Focus()
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        Dim opop As New frmpopupsupplier
        opop.ShowDialog()

        If opop.refkdsupp <> "" Then
            txtkdsupp.Text = opop.refkdsupp
            txtnmsupp.Text = opop.refnmsupp
            txtalamat.Text = opop.refalamat
            txttelp.Text = opop.reftelp
            txtemail.Text = opop.refemail
            btnsimpan.Enabled = False
            btnubah.Enabled = True
            btnhapus.Enabled = True
        End If
        txtkdsupp.Enabled = False
    End Sub

    Private Sub txttelp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelp.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub
End Class