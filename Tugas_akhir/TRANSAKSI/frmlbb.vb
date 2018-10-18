Imports System.Data.Odbc
Public Class frmlbb
    Dim objlbb As New clslbb
    Dim objdetil As New clsdetil_lbb
    Dim Mycmd As New OdbcCommand
    Dim dreader As OdbcDataReader
    Public Sub tampildatapp(ByVal xKriteria As String)

        Dim sql As String

        sql = "select produk.kd_produk, produk.nm_produk, produk.harga from ((produk inner join sample on produk.kd_sample = sample.kd_sample) inner join detil_pp on sample.kd_sample = detil_pp.kd_sample) where detil_pp.no_pp like '%" & xKriteria & "%'"
        Mycmd = New OdbcCommand(sql, MyCnn)

        Try

            dreader = Mycmd.ExecuteReader
            lvlbb.Items.Clear()

            While dreader.Read

                With lvlbb.Items.Add(dreader("kd_produk"))
                    .subitems.add(dreader("nm_produk"))
                    .subitems.add(dreader("harga"))
                End With
            End While
        Finally
        End Try
    End Sub
    Private Sub frmlbb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtnolbb.Text = objlbb.Autonumber
        txtnolbb.Enabled = False
        btncaribahan.Enabled = False
        btnsimpan.Enabled = False
        btntambah.Enabled = False
    End Sub

    Private Sub btncaripp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncaripp.Click
        frmpopuplbb.Show()

    End Sub

    Private Sub txtnopp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnopp.TextChanged
        Call tampildatapp(txtnopp.Text)
    End Sub

    Private Sub btncaribahan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncaribahan.Click
        Dim opop As New frmpopupbahan
        opop.ShowDialog()

        If opop.refkdbahan <> "" Then
            txtkdbahan.Text = opop.refkdbahan
            txtnmbahan.Text = opop.refnmbahan
            txthrgbhn.Text = opop.refhrg
            btntambah.Enabled = True
        End If
    End Sub

    Private Sub btntambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntambah.Click
        Dim n As Integer
        For n = 0 To lvbahan.Items.Count - 1
            If lvbahan.Items(n).Text = txtkdbahan.Text Then
                MsgBox("Data Sudah Ada Pada List")
            ElseIf txtkdbahan.Text = "" Or txtnmbahan.Text = "" Or txthrgbhn.Text = "" Or txtqty.Text = "" Or txtjmlhrg.Text = "" Then
                MsgBox("Terdapat Data Kosong")
            End If
        Next
        lvbahan.Items.Add(txtkdbahan.Text)
        lvbahan.Items(n).SubItems.Add(txtnmbahan.Text)
        lvbahan.Items(n).SubItems.Add(txthrgbhn.Text)
        lvbahan.Items(n).SubItems.Add(txtqty.Text)
        lvbahan.Items(n).SubItems.Add(txtjmlhrg.Text)
        txtkdbahan.Clear()
        txtnmbahan.Clear()
        txthrgbhn.Clear()
        txtqty.Clear()
        txtjmlhrg.Clear()
        btnsimpan.Enabled = True
        btncaripp.Enabled = False
    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        If lvbahan.Items.Count = 0 Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Information, "INFORMASI")
        Else
            Dim nilaikembali1, nilaikembali2 As Integer
            objlbb.PNo_LBB = txtnolbb.Text
            objlbb.PTgl_LBB = Format(dtptgllbb.Value, "yyy-MM-dd")
            objlbb.PNo_PP = txtnopp.Text
            nilaikembali1 = objlbb.Simpan()
            For x As Integer = 0 To lvbahan.Items.Count - 1
                objdetil.PNo_LBB = txtnolbb.Text
                objdetil.PKd_Bahan = lvbahan.Items(x).SubItems(0).Text
                objdetil.PQty = lvbahan.Items(x).SubItems(3).Text
                objdetil.PJml_Harga = lvbahan.Items(x).SubItems(4).Text
                nilaikembali2 = objdetil.simpan()
            Next
            If nilaikembali1 = 1 And nilaikembali2 = 1 Then
                MsgBox("Data Berhasil Disimpan", MsgBoxStyle.Information, "INFORMASI")
                ModuleCetak.CetakCR_LBB(txtnolbb.Text)
            End If
            txtnolbb.Text = objlbb.Autonumber
            txtkdbahan.Clear()
            txtnmbahan.Clear()
            txthrgbhn.Clear()
            txtqty.Clear()
            txtjmlhrg.Clear()
            btncaribahan.Enabled = False
            txtnopp.Clear()
            txttglpp.Clear()
            txtnmcust.Clear()
        End If
    End Sub

    Private Sub txtjmlhrg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtjmlhrg.TextChanged

    End Sub

    Private Sub txtqty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty.TextChanged
        txtjmlhrg.Text = Val(txtqty.Text) * Val(txthrgbhn.Text)
    End Sub

    Private Sub btnbataltambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbataltambah.Click
        txtkdbahan.Clear()
        txtnmbahan.Clear()
        txthrgbhn.Clear()
        txtjmlhrg.Clear()
        txtqty.Clear()
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnopp.Clear()
            txttglpp.Clear()
            txtnmcust.Clear()
            lvbahan.Items.Clear()
            lvlbb.Items.Clear()
            txtkdbahan.Clear()
            txtnmbahan.Clear()
            txthrgbhn.Clear()
            txtqty.Clear()
            txtjmlhrg.Clear()
            txtnolbb.Text = objlbb.Autonumber
        End If
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        txtnopp.Clear()
        txttglpp.Clear()
        txtnmcust.Clear()
        lvbahan.Items.Clear()
        lvlbb.Items.Clear()
        txtkdbahan.Clear()
        txtnmbahan.Clear()
        txthrgbhn.Clear()
        txtqty.Clear()
        txtjmlhrg.Clear()
        txtnolbb.Text = objlbb.Autonumber
        btncaribahan.Enabled = False
        btncaripp.Enabled = True
        btnsimpan.Enabled = False
        btntambah.Enabled = False
    End Sub
End Class