Public Class frmpembelianbahan
    Dim objpembelian As New clspembelian
    Dim objdetil As New clsdetil_pembelian

    Private Sub frmpembelianbahan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtnopembelian.Text = objpembelian.Autonumber
        txtnopembelian.Enabled = False
        btnsimpan.Enabled = False
        txtkdsup.Enabled = False
        txtnmsup.Enabled = False
        txtemail.Enabled = False
        txtnotelp.Enabled = False
        txtkdbahan.Enabled = False
        txtnmbahan.Enabled = False
        txthrgbhn.Enabled = False
        txtjmlhrg.Enabled = False
        btncaribahan.Enabled = False
    End Sub
    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        If lvpembelian.Items.Count = 0 Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Information, "INFORMASI")
        Else
            Dim nilaikembali1, nilaikembali2 As Integer
            objpembelian.PNo_Pembelian = txtnopembelian.Text
            objpembelian.PTgl_Pembelian = Format(dtptglbeli.Value, "yyy-MM-dd")
            objpembelian.PKd_Staff = txtkdstaff.Text
            objpembelian.PKd_Supplier = txtkdsup.Text
            nilaikembali1 = objpembelian.Simpan()
            For x As Integer = 0 To lvpembelian.Items.Count - 1
                objdetil.PNo_Pembelian = txtnopembelian.Text
                objdetil.PKd_Bahan = lvpembelian.Items(x).SubItems(0).Text
                objdetil.PQty = lvpembelian.Items(x).SubItems(3).Text
                objdetil.PJml_Hrg = lvpembelian.Items(x).SubItems(4).Text
                nilaikembali2 = objdetil.simpan()
            Next
            If nilaikembali1 = 1 And nilaikembali2 = 1 Then
                MsgBox("Data Berhasil Disimpan", MsgBoxStyle.Information, "INFORMASI")
            End If
            txtnopembelian.Text = objpembelian.Autonumber
            btncarisup.Enabled = True
            btnsimpan.Enabled = False
            lvpembelian.Items.Clear()
            txtkdsup.Clear()
            txtnmsup.Clear()
            txtemail.Clear()
            txtnotelp.Clear()
            btncaribahan.Enabled = False
        End If
    End Sub

    Private Sub btntambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntambah.Click
        Dim n As Integer
        If txtkdbahan.Text = "" Or txtnmbahan.Text = "" Or txthrgbhn.Text = "" Or txtjmlhrg.Text = "" Or txtqty.Text = "" Then
            MsgBox("Terdapat Data Kosong")
        Else
            For n = 0 To lvpembelian.Items.Count - 1
                If lvpembelian.Items(n).Text = txtkdbahan.Text Then
                    MsgBox("Data Sudah Ada Pada List")
                    Exit Sub
                End If
            Next
            lvpembelian.Items.Add(txtkdbahan.Text)
            lvpembelian.Items(n).SubItems.Add(txtnmbahan.Text)
            lvpembelian.Items(n).SubItems.Add(txthrgbhn.Text)
            lvpembelian.Items(n).SubItems.Add(txtqty.Text)
            lvpembelian.Items(n).SubItems.Add(txtjmlhrg.Text)
            txtkdbahan.Clear()
            txtnmbahan.Clear()
            txthrgbhn.Clear()
            txtjmlhrg.Clear()
            txtqty.Clear()
            btnsimpan.Enabled = True
            btncarisup.Enabled = False
        End If
    End Sub

    Private Sub btncarisup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncarisup.Click
        Dim opop As New frmpopupsupplier
        opop.ShowDialog()

        If opop.refkdsupp <> "" Then
            txtkdsup.Text = opop.refkdsupp
            txtnmsup.Text = opop.refnmsupp
            txtnotelp.Text = opop.reftelp
            txtemail.Text = opop.refemail
            btnsimpan.Enabled = False
            btncaribahan.Enabled = True
        End If
        txtkdsup.Enabled = False
        txtnmsup.Enabled = False
        txtnotelp.Enabled = False
        txtemail.Enabled = False
    End Sub

    Private Sub btncaribahan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncaribahan.Click
        Dim opop As New frmpopupbahan
        opop.ShowDialog()

        If opop.refkdbahan <> "" Then
            txtkdbahan.Text = opop.refkdbahan
            txtnmbahan.Text = opop.refnmbahan
            txthrgbhn.Text = opop.refhrg
            btnsimpan.Enabled = False
        End If
        txtkdbahan.Enabled = False
        txtnmbahan.Enabled = False
        txthrgbhn.Enabled = False
        txtqty.Focus()
    End Sub

    Private Sub txtqty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty.TextChanged
        txtjmlhrg.Text = Val(txtqty.Text) * Val(txthrgbhn.Text)
    End Sub

    Private Sub btnbataltambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbataltambah.Click
        txtkdbahan.Clear()
        txtnmbahan.Clear()
        txthrgbhn.Clear()
        txtqty.Clear()
        txtjmlhrg.Clear()
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        lvpembelian.Items.Clear()
        btncarisup.Enabled = True
        btncaribahan.Enabled = False
        txtkdsup.Clear()
        txtnmsup.Clear()
        txtemail.Clear()
        txtnotelp.Clear()
        btnsimpan.Enabled = False
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtkdbahan.Clear()
            txtnmbahan.Clear()
            txthrgbhn.Clear()
            txtqty.Clear()
            txtjmlhrg.Clear()
            txtkdsup.Clear()
            txtnmsup.Clear()
            txtnotelp.Clear()
            txtemail.Clear()
            txtnopembelian.Text = objpembelian.Autonumber
            btncaribahan.Enabled = False
            btnsimpan.Enabled = False
            btncarisup.Enabled = True
            lvpembelian.Items.Clear()
        End If
    End Sub
End Class