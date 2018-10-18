Public Class frmentrycustomer
    Dim objcustomer As New clscustomer
    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        Dim nilai As Integer
        If txtnmcust.Text = "" Or txtalamat.Text = "" Or txtemail.Text = "" Or txttelp.Text = "" Then
            MsgBox("Terdapat Data Kosong")
        Else
            objcustomer.PKdCust = txtkdcust.Text
            objcustomer.PNmCust = txtnmcust.Text
            objcustomer.PAlamat = txtalamat.Text
            objcustomer.PTelp = txttelp.Text
            objcustomer.PEmail = txtemail.Text
            nilai = objcustomer.simpan()
            If nilai = 1 Then
                MsgBox("Data Berhasil Disimpan")
            Else
                MsgBox("Data Gagal Disimpan")
            End If
            txtnmcust.Clear()
            txtalamat.Clear()
            txttelp.Clear()
            txtemail.Clear()
            txtkdcust.Text = objcustomer.autonumber
            txtnmcust.Focus()
        End If
    End Sub

    Private Sub btnubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnubah.Click
        Dim nilaikembali As Integer
        objcustomer.PKdCust = txtkdcust.Text
        objcustomer.PNmCust = txtnmcust.Text
        objcustomer.PAlamat = txtalamat.Text
        objcustomer.PTelp = txttelp.Text
        objcustomer.PEmail = txtemail.Text
        nilaikembali = objcustomer.ubah()
        If nilaikembali = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin mengubah data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Diubah")
            End If
        Else
            MsgBox("Data Gagal Diubah")
        End If
        txtnmcust.Clear()
        txtalamat.Clear()
        txttelp.Clear()
        txtemail.Clear()
        txtkdcust.Text = objcustomer.autonumber
        txtkdcust.Enabled = False
        btncari.Enabled = True
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtnmcust.Focus()
    End Sub

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapus.Click
        Dim nilaikembali As Integer
        objcustomer.PKdCust = txtkdcust.Text
        objcustomer.PNmCust = txtnmcust.Text
        objcustomer.PAlamat = txtalamat.Text
        objcustomer.PTelp = txttelp.Text
        objcustomer.PEmail = txtemail.Text
        nilaikembali = objcustomer.hapus()
        If nilaikembali = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin menghapus data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Dihapus")
            End If
        Else
            MsgBox("Data Gagal Dihapus")
        End If
        txtnmcust.Clear()
        txtalamat.Clear()
        txttelp.Clear()
        txtemail.Clear()
        txtkdcust.Text = objcustomer.autonumber
        txtkdcust.Enabled = False
        btncari.Enabled = True
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtnmcust.Focus()
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        txtkdcust.Text = objcustomer.autonumber
        txtnmcust.Focus()
        txtnmcust.Clear()
        txtalamat.Clear()
        txttelp.Clear()
        txtemail.Clear()
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnmcust.Clear()
            txtalamat.Clear()
            txttelp.Clear()
            txtemail.Clear()
            txtkdcust.Text = objcustomer.autonumber
        End If
    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        Dim opop As New frmpopupcustomer
        opop.ShowDialog()

        If opop.refkdcustomer <> "" Then
            txtkdcust.Text = opop.refkdcustomer
            txtnmcust.Text = opop.refnmcustomer
            txtalamat.Text = opop.refalamat
            txttelp.Text = opop.reftelp
            txtemail.Text = opop.refemail
            btnsimpan.Enabled = False
            btnubah.Enabled = True
            btnhapus.Enabled = True
        End If
        txtkdcust.Enabled = False

    End Sub

    Private Sub frmentrycustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtkdcust.Text = objcustomer.autonumber
        txtkdcust.Enabled = False
        txttelp.MaxLength = 12
        btnubah.Enabled = False
        btnhapus.Enabled = False
    End Sub

    Private Sub txttelp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelp.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub

    Private Sub txttelp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttelp.TextChanged

    End Sub
End Class