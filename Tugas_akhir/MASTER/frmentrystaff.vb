Public Class frmentrystaff
    Dim objstaff As New clsstaff
    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        Dim opop As New frmpopupstaff
        opop.ShowDialog()

        If opop.refkdstaff <> "" Then
            txtkdstaff.Text = opop.refkdstaff
            txtnmstaff.Text = opop.refnmstaff
            txtalamat.Text = opop.refalamat
            txttelp.Text = opop.reftelp
            txtemail.Text = opop.refemail
            txtusername.Text = opop.refusername
            btnsimpan.Enabled = False
            btnubah.Enabled = True
            btnhapus.Enabled = True
        End If
        txtkdstaff.Enabled = False
    End Sub

    Private Sub frmentrystaff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtkdstaff.Text = objstaff.autonumber()
        txtkdstaff.Enabled = False
        txtnmstaff.Focus()
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txttelp.MaxLength = 12
        txtpass.PasswordChar = "*"
        txtkonfirm.PasswordChar = "*"
    End Sub

    Private Sub txttelp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelp.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub
    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        Dim nilai As Integer
        If txtnmstaff.Text = "" Or txtalamat.Text = "" Or txtemail.Text = "" Or txttelp.Text = "" Or txtusername.Text = "" Or txtpass.Text = "" Or txtkonfirm.Text = "" Then
            MsgBox("Terdapat Data Kosong")
        ElseIf txtpass.Text <> txtkonfirm.Text Then
            MsgBox("Password Tidak Sama")
            txtkonfirm.Focus()
            txtkonfirm.Clear()
        Else
            objstaff.PKdStaff = txtkdstaff.Text
            objstaff.PNmStaff = txtnmstaff.Text
            objstaff.PAlamat = txtalamat.Text
            objstaff.PTelp = txttelp.Text
            objstaff.PEmail = txtemail.Text
            objstaff.PUsername = txtusername.Text
            objstaff.PPassword = txtpass.Text
            nilai = objstaff.simpan()
            If nilai = 1 Then
                MsgBox("Data Berhasil Disimpan")
            Else
                MsgBox("Data Gagal Disimpan")
            End If
            txtnmstaff.Clear()
            txtalamat.Clear()
            txttelp.Clear()
            txtemail.Clear()
            txtusername.Clear()
            txtpass.Clear()
            txtkonfirm.Clear()
            txtkdstaff.Text = objstaff.autonumber
            txtnmstaff.Focus()
        End If
    End Sub

    Private Sub btnubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnubah.Click
        Dim nilai As Integer
        objstaff.PKdStaff = txtkdstaff.Text
        objstaff.PNmStaff = txtnmstaff.Text
        objstaff.PAlamat = txtalamat.Text
        objstaff.PTelp = txttelp.Text
        objstaff.PEmail = txtemail.Text
        objstaff.PUsername = txtusername.Text
        objstaff.PPassword = txtpass.Text
        If nilai = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin mengubah data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Diubah")
            End If
        Else
            MsgBox("Data Gagal Diubah")

        End If
        txtkdstaff.Text = objstaff.autonumber
        txtnmstaff.Clear()
        txtalamat.Clear()
        txttelp.Clear()
        txtemail.Clear()
        txtusername.Clear()
        txtpass.Clear()
        txtkonfirm.Clear()
        txtkdstaff.Enabled = False
        btncari.Enabled = True
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtnmstaff.Focus()
    End Sub

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapus.Click
        Dim nilai As Integer
        objstaff.PKdStaff = txtkdstaff.Text
        objstaff.PNmStaff = txtnmstaff.Text
        objstaff.PAlamat = txtalamat.Text
        objstaff.PTelp = txttelp.Text
        objstaff.PEmail = txtemail.Text
        objstaff.PUsername = txtusername.Text
        objstaff.PPassword = txtpass.Text
        If nilai = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin menghapus data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Dihapus")
            End If
        Else
            MsgBox("Data Gagal Dihapus")
        End If
        txtkdstaff.Text = objstaff.autonumber
        txtnmstaff.Clear()
        txtalamat.Clear()
        txttelp.Clear()
        txtemail.Clear()
        txtusername.Clear()
        txtpass.Clear()
        txtkonfirm.Clear()
        txtkdstaff.Enabled = False
        btncari.Enabled = True
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtnmstaff.Focus()
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnmstaff.Clear()
            txtalamat.Clear()
            txtpass.Clear()
            txtkonfirm.Clear()
            txtemail.Clear()
            txttelp.Clear()
            txtkdstaff.Text = objstaff.autonumber
        End If
    End Sub

    Private Sub txtkonfirm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkonfirm.TextChanged
        ' If txtpass.TextLength < 8 Then
        'MessageBox.Show("Minimal Password 8 Character")
        'txtpass.Clear()
        ' txtkonfirm.Clear()
        ' txtpass.Focus()
        ' Else
        ' txtkonfirm.Focus()
        ' End If
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        txtkdstaff.Text = objstaff.autonumber
        txtnmstaff.Clear()
        txtalamat.Clear()
        txttelp.Clear()
        txtemail.Clear()
        txtusername.Clear()
        txtpass.Clear()
        txtkonfirm.Clear()
        btnsimpan.Enabled = True
    End Sub
End Class