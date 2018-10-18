Public Class frmentrykendaraan
    Dim objkend As New clskendaraan
    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        Dim opop As New frmpopupkendaraan
        opop.ShowDialog()
        If opop.refnoplat <> "" Then
            txtnoplat.Text = opop.refnoplat
            txtnmkend.Text = opop.refnmkend
            cmbjenis.Text = opop.refjenis
            txtmerk.Text = opop.refmerk
            txtmuatan.Text = opop.refmuatan
            txthrg.Text = opop.refharga
            btnsimpan.Enabled = False
            btnubah.Enabled = True
            btnhapus.Enabled = True
        End If
    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        Dim nilai As Integer
        If txtnoplat.Text = "" Or txtnmkend.Text = "" Or txtmerk.Text = "" Or txthrg.Text = "" Or cmbjenis.Text = "" Or txtmuatan.Text = "" Then
            MsgBox("Terdapat Data Kosong")
        Else
            objkend.PNoPlat = txtnoplat.Text
            objkend.PNmKend = txtnmkend.Text
            objkend.PJnsKend = cmbjenis.Text
            objkend.PMerk = txtmerk.Text
            objkend.PMuatan = txtmuatan.Text
            objkend.PHarga = txthrg.Text
            nilai = objkend.simpan()
            If nilai = 1 Then
                MsgBox("Data Berhasil Disimpan")
            Else
                MsgBox("Data Gagal Disimpan")
            End If
            txtnoplat.Clear()
            txtnmkend.Clear()
            txtmuatan.Clear()
            txtmerk.Clear()
            cmbjenis.Text = ""
            txthrg.Clear()
            txtnoplat.Focus()
        End If
    End Sub

    Private Sub btnubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnubah.Click
        Dim nilai As Integer
        objkend.PNoPlat = txtnoplat.Text
        objkend.PNmKend = txtnmkend.Text
        objkend.PJnsKend = cmbjenis.Text
        objkend.PMerk = txtmerk.Text
        objkend.PMuatan = txtmuatan.Text
        objkend.PHarga = txthrg.Text
        nilai = objkend.ubah()
        If nilai = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin mengubah data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Diubah")
            End If
        Else
            MsgBox("Data Gagal Diubah")
        End If
        txtnoplat.Clear()
        txtmerk.Clear()
        txthrg.Clear()
        txtmuatan.Clear()
        txtnmkend.Clear()
        cmbjenis.Text = ""
        btncari.Enabled = True
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtnoplat.Focus()
    End Sub

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapus.Click
        Dim nilai As Integer
        objkend.PNoPlat = txtnoplat.Text
        objkend.PNmKend = txtnmkend.Text
        objkend.PJnsKend = cmbjenis.Text
        objkend.PMerk = txtmerk.Text
        objkend.PMuatan = txtmuatan.Text
        objkend.PHarga = txthrg.Text
        nilai = objkend.hapus()
        If nilai = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin menghapus data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Dihapus")
            End If
        Else
            MsgBox("Data Gagal Dihapus")
        End If
        txtnoplat.Clear()
        txtmerk.Clear()
        txthrg.Clear()
        txtmuatan.Clear()
        txtnmkend.Clear()
        cmbjenis.Text = ""
        btncari.Enabled = True
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtnoplat.Focus()
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        txtnoplat.Focus()
        txtmerk.Clear()
        txtnmkend.Clear()
        txtmuatan.Clear()
        cmbjenis.Text = ""
        txthrg.Clear()
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnoplat.Clear()
            txtnmkend.Clear()
            txtmuatan.Clear()
            txtmerk.Clear()
            cmbjenis.Text = ""
            txthrg.Clear()
        End If
    End Sub

    Private Sub frmentrykendaraan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtnoplat.Focus()
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtmuatan.MaxLength = 5
        txtnoplat.MaxLength = 10
        txthrg.MaxLength = 10
    End Sub

    Private Sub txtmuatan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmuatan.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub

    Private Sub txthrg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthrg.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub
End Class