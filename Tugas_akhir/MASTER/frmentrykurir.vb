Public Class frmentrykurir
    Dim objkurir As New clskurir
    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        Dim nilai As Integer
        If txtnmkurir.Text = "" Or txttelp.Text = "" Or txtemail.Text = "" Or txtalamat.Text = "" Then
            MsgBox("Terdapat Data Kosong")
        Else
            objkurir.PKdKurir = txtkdkurir.Text
            objkurir.PNmKurir = txtnmkurir.Text
            objkurir.PAlamat = txtalamat.Text
            objkurir.PTelp = txttelp.Text
            objkurir.PEmail = txtemail.Text
            nilai = objkurir.simpan()
            If nilai = 1 Then
                MsgBox("Data Berhasil Disimpan")
            Else
                MsgBox("Data Gagal Disimpan")
            End If
            txtnmkurir.Clear()
            txtalamat.Clear()
            txtemail.Clear()
            txttelp.Clear()
            txtkdkurir.Text = objkurir.autonumber
            txtnmkurir.Focus()
        End If
    End Sub

    Private Sub btnubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnubah.Click
        Dim nilaikembali As Integer
        objkurir.PKdKurir = txtkdkurir.Text
        objkurir.PNmKurir = txtnmkurir.Text
        objkurir.PAlamat = txtalamat.Text
        objkurir.PTelp = txttelp.Text
        objkurir.PEmail = txtemail.Text
        nilaikembali = objkurir.ubah()
        If nilaikembali = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin mengubah data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Diubah")
            End If
        Else
            MsgBox("Data Gagal Diubah")
        End If
        txtnmkurir.Clear()
        txtalamat.Clear()
        txttelp.Clear()
        txtemail.Clear()
        txtkdkurir.Text = objkurir.autonumber
        txtkdkurir.Enabled = False
        btncari.Enabled = True
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtnmkurir.Focus()
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        txtnmkurir.Clear()
        txtalamat.Clear()
        txttelp.Clear()
        txtemail.Clear()
        txtkdkurir.Text = objkurir.autonumber
        txtnmkurir.Focus()
        btnsimpan.Enabled = True
    End Sub

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapus.Click
        Dim nilaikembali As Integer
        objkurir.PKdKurir = txtkdkurir.Text
        objkurir.PNmKurir = txtnmkurir.Text
        objkurir.PAlamat = txtalamat.Text
        objkurir.PTelp = txttelp.Text
        objkurir.PEmail = txtemail.Text
        nilaikembali = objkurir.hapus()
        If nilaikembali = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin menghapus data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Dihapus")
            End If
        Else
            MsgBox("Data Gagal Dihapus")
        End If
        txtnmkurir.Clear()
        txtalamat.Clear()
        txttelp.Clear()
        txtemail.Clear()
        txtkdkurir.Text = objkurir.autonumber
        txtkdkurir.Enabled = False
        btncari.Enabled = True
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtnmkurir.Focus()
    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        Dim opop As New frmpopupkurir
        opop.ShowDialog()

        If opop.refkdkurir <> "" Then
            txtkdkurir.Text = opop.refkdkurir
            txtnmkurir.Text = opop.refnmkurir
            txtalamat.Text = opop.refalamat
            txttelp.Text = opop.reftelp
            txtemail.Text = opop.refemail
            btnsimpan.Enabled = False
            btnubah.Enabled = True
            btnhapus.Enabled = True
        End If
        txtkdkurir.Enabled = False

    End Sub

    Private Sub frmentrykurir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtkdkurir.Text = objkurir.autonumber()
        txtkdkurir.Enabled = False
        txtnmkurir.Focus()
        txttelp.MaxLength = 12
        btnubah.Enabled = False
        btnhapus.Enabled = False
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnmkurir.Clear()
            txtalamat.Clear()
            txtemail.Clear()
            txttelp.Clear()
            txtkdkurir.Text = objkurir.autonumber
        End If
    End Sub

    Private Sub txttelp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelp.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub
End Class