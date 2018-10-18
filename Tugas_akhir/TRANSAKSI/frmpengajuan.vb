Public Class frmpengajuan
    Dim objpengajuan As New clspengajuan
    Dim objdetilpengajuan As New clsdetil_pengajuan
    Private Sub btntambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntambah.Click
        Dim n As Integer
        If txtkdsample.Text = "" Or txtnmsample.Text = "" Or txthrg.Text = "" Or txtket.Text = "" Then
            MsgBox("Terdapat Data Kosong")
        End If
        For n = 0 To lvpengajuan.Items.Count - 1
            If lvpengajuan.Items(n).Text = txtkdsample.Text Then
                MsgBox("Data Sudah Ada Pada List")
                Exit Sub
            End If
        Next
        lvpengajuan.Items.Add(txtkdsample.Text)
        lvpengajuan.Items(n).SubItems.Add(txtnmsample.Text)
        lvpengajuan.Items(n).SubItems.Add(txthrg.Text)
        lvpengajuan.Items(n).SubItems.Add(txtket.Text)
        txtkdsample.Clear()
        txtnmsample.Clear()
        txthrg.Clear()
        txtket.Clear()
        btnsimpan.Enabled = True
        btncaricust.Enabled = False
    End Sub
    Private Sub frmpengajuan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtkdpengajuan.Text = objpengajuan.Autonumber
        txtkdpengajuan.Enabled = False
        txtkdcust.Enabled = False
        txtnmcust.Enabled = False
        txtemail.Enabled = False
        txtnotelp.Enabled = False
        txtkdsample.Enabled = False
        txtnmsample.Enabled = False
        txthrg.Enabled = False
    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        If lvpengajuan.Items.Count = 0 Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Information, "INFORMASI")
        Else
            Dim nilaikembali1, nilaikembali2 As Integer
            objpengajuan.PKd_Pengajuan = txtkdpengajuan.Text
            objpengajuan.PTgl_Pengajuan = Format(dtptglpengajuan.Value, "yyy-MM-dd")
            objpengajuan.PKd_Staff = txtkdstaff.Text
            objpengajuan.PKd_Customer = txtkdcust.Text
            nilaikembali1 = objpengajuan.Simpan()
            For x As Integer = 0 To lvpengajuan.Items.Count - 1
                objdetilpengajuan.PKd_Pengajuan = txtkdpengajuan.Text
                objdetilpengajuan.PKd_Sample = lvpengajuan.Items(x).SubItems(0).Text
                objdetilpengajuan.PKet = lvpengajuan.Items(x).SubItems(3).Text
                nilaikembali2 = objdetilpengajuan.simpan()
            Next
            If nilaikembali1 = 1 And nilaikembali2 = 1 Then
                MsgBox("Data Berhasil Disimpan", MsgBoxStyle.Information, "INFORMASI")
                ModuleCetak.CetakCR_pengajuan1(txtkdpengajuan.Text)
            End If
            txtkdpengajuan.Text = objpengajuan.Autonumber
            btncaricust.Enabled = True
        End If
    End Sub

    Private Sub btncaricust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncaricust.Click
        Dim opop As New frmpopupcustomer
        opop.ShowDialog()

        If opop.refkdcustomer <> "" Then
            txtkdcust.Text = opop.refkdcustomer
            txtnmcust.Text = opop.refnmcustomer
            txtnotelp.Text = opop.reftelp
            txtemail.Text = opop.refemail
            btnsimpan.Enabled = False
        End If
        txtkdcust.Enabled = False
    End Sub

    Private Sub btncarisample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncarisample.Click
        Dim opop As New frmpopupsample
        opop.ShowDialog()

        If opop.refkdsample <> "" Then
            txtkdsample.Text = opop.refkdsample
            txtnmsample.Text = opop.refnmsample
            txthrg.Text = opop.refhrg
        End If
        txtkdsample.Enabled = False
    End Sub

    Private Sub txtnotelp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnotelp.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub

    Private Sub txthrg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthrg.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub

    Private Sub btnbataltambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbataltambah.Click
        txtkdsample.Clear()
        txtnmsample.Clear()
        txthrg.Clear()
        txtket.Clear()
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        'If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
        '    Me.Close()
        '    txtkdpengajuan.Text = objpengajuan.Autonumber
        'End If
        Form1.Show()
        'frmspk.Hide()
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class