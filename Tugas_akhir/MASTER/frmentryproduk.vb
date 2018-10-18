Public Class frmentryproduk
    Dim objproduk As New clsproduk
    Private Sub frmentryproduk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtkdproduk.Text = objproduk.autonumber()
        txtkdproduk.Enabled = False
        txtnmproduk.Focus()
        txtnmproduk.Enabled = False
        txthrg.Enabled = False
        btnsimpan.Enabled = False
    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        Dim nilai As Integer
        If txtnmproduk.Text = "" Or txtnmproduk.Text = "" Then
            MsgBox("Terdapat Data Kosong")
        Else
            objproduk.PKdSample = txtkdsample.Text
            objproduk.PNmProduk = txtnmproduk.Text
            objproduk.PHrgProduk = txthrg.Text
            objproduk.PKdProduk = txtkdproduk.Text
            nilai = objproduk.simpan()
            If nilai = 1 Then
                MsgBox("Data Berhasil Disimpan")
            Else
                MsgBox("Data Gagal Disimpan")
            End If
            txtnmproduk.Clear()
            txthrg.Clear()
            txtkdproduk.Text = objproduk.autonumber
            txtnmproduk.Focus()
            btnsimpan.Enabled = False
        End If
    End Sub

    Private Sub btnubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nilaikembali As Integer
        objproduk.PKdSample = txtkdproduk.Text
        objproduk.PNmProduk = txtnmproduk.Text
        objproduk.PHrgProduk = txthrg.Text
        nilaikembali = objproduk.ubah()
        If nilaikembali = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin mengubah data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Diubah")
            End If
        Else
            MsgBox("Data Gagal Diubah")
        End If
        txtkdproduk.Text = objproduk.autonumber
        txtkdproduk.Enabled = False
        btncari.Enabled = True
        btnsimpan.Enabled = True
        txtnmproduk.Focus()
    End Sub

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nilaikembali As Integer
        objproduk.PKdSample = txtkdproduk.Text
        objproduk.PNmProduk = txtnmproduk.Text
        objproduk.PHrgProduk = txthrg.Text
        nilaikembali = objproduk.hapus()
        If nilaikembali = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin menghapus data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Dihapus")
            End If
        Else
            MsgBox("Data Gagal Dihapus")
        End If
        txtkdproduk.Text = objproduk.autonumber
        txtkdproduk.Enabled = False
        btncari.Enabled = True
        btnsimpan.Enabled = True
        txtnmproduk.Focus()
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        txtkdproduk.Text = objproduk.autonumber
        txtnmproduk.Focus()
        btnsimpan.Enabled = False
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnmproduk.Clear()
            txthrg.Clear()
            txtkdproduk.Text = objproduk.autonumber
        End If
    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        frmpopupproduk.Show()
    End Sub
End Class