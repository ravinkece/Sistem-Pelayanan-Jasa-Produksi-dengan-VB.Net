Imports System.Data.Odbc
Public Class frmretur
    Dim Mycmd As New OdbcCommand
    Dim dreader As OdbcDataReader
    Dim objretur As New clsretur
    Dim objclsdetil As New clsdetil_retur
    Public Sub tampildatapp(ByVal xKriteria As String)

        Dim sql As String

        sql = "select produk.kd_produk, produk.nm_produk, produk.harga, detil_pp.jml_pesan from ((((produk inner join sample on produk.kd_sample = sample.kd_sample)inner join detil_pp on sample.kd_sample = detil_pp.kd_sample)inner join pp on detil_pp.no_pp = pp.no_pp)inner join faktur on pp.no_pp = faktur.no_pp) where faktur.no_faktur like '%" & xKriteria & "%'"
        Mycmd = New OdbcCommand(sql, MyCnn)

        Try

            dreader = Mycmd.ExecuteReader
            lvfaktur.Items.Clear()

            While dreader.Read

                With lvfaktur.Items.Add(dreader("kd_produk"))
                    .subitems.add(dreader("nm_produk"))
                    .subitems.add(dreader("harga"))
                    .subitems.add(dreader("jml_pesan"))
                End With
            End While
        Finally
        End Try
    End Sub
    Private Sub frmretur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtnoretur.Text = objretur.Autonumber
        txtnoretur.Enabled = False
    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        frmpopupretur.Show()
    End Sub

    Private Sub txtnofaktur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnofaktur.TextChanged
        Call tampildatapp(txtnofaktur.Text)
    End Sub

    Private Sub lvfaktur_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvfaktur.DoubleClick
        Me.txtkdproduk.Text = lvfaktur.FocusedItem.Text
        Me.txtnmproduk.Text = lvfaktur.FocusedItem.SubItems(1).Text
        Me.txthrg.Text = lvfaktur.FocusedItem.SubItems(2).Text
        Me.txtjmlkrm.Text = lvfaktur.FocusedItem.SubItems(3).Text
    End Sub

    Private Sub lvfaktur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvfaktur.SelectedIndexChanged

    End Sub

    Private Sub btntambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntambah.Click
        Dim n As Integer
        For n = 0 To lvretur.Items.Count - 1
            If lvretur.Items(n).Text = txtkdproduk.Text Then
                MsgBox("Data Sudah Ada Pada List")
                Exit Sub
            End If
        Next
        lvretur.Items.Add(txtkdproduk.Text)
        lvretur.Items(n).SubItems.Add(txtnmproduk.Text)
        lvretur.Items(n).SubItems.Add(txthrg.Text)
        lvretur.Items(n).SubItems.Add(txtjmlretur.Text)
        btnsimpan.Enabled = True
    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        If lvretur.Items.Count = 0 Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Information, "INFORMASI")
        Else
            Dim nilaikembali1, nilaikembali2 As Integer
            objretur.PNo_Retur = txtnoretur.Text
            objretur.PTgl_Retur = Format(dtptglretur.Value, "yyy-MM-dd")
            objretur.PKet = txtket.Text
            objretur.PNo_Faktur = txtnofaktur.Text
            nilaikembali1 = objretur.Simpan()
            For x As Integer = 0 To lvretur.Items.Count - 1
                objclsdetil.PNo_Retur = txtnoretur.Text
                objclsdetil.PKd_Produk = lvretur.Items(x).SubItems(0).Text
                objclsdetil.PJml_Brgretur = lvretur.Items(x).SubItems(3).Text
                nilaikembali2 = objclsdetil.simpan()
            Next
            If nilaikembali1 = 1 And nilaikembali2 = 1 Then
                MsgBox("Data Berhasil Disimpan", MsgBoxStyle.Information, "INFORMASI")
                ModuleCetak.CetakCR_Retur(txtnoretur.Text)
            End If
            txtnoretur.Text = objretur.Autonumber
            btncari.Enabled = True
        End If
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnoretur.Text = objretur.Autonumber
        End If
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click

    End Sub

    Private Sub btnbataltambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbataltambah.Click
        txtkdproduk.Clear()
        txtnmproduk.Clear()
        txthrg.Clear()
        txtjmlkrm.Clear()
        txtjmlretur.Clear()
    End Sub
End Class