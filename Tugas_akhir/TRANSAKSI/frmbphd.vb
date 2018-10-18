Imports System.Data.Odbc
Public Class frmbphd
    Dim objbphd As New clsbphd
    Dim Query As String
    Dim xmycmd As New OdbcCommand
    Dim xmyread As OdbcDataReader
    Dim objpp As New clspp
    Public Sub tampildatapp(ByVal xKriteria As String)

        Dim sql As String

        sql = "select produk.kd_produk, produk.nm_produk, produk.harga, detil_pp.jml_pesan, detil_pp.jml_harga from ((sample inner join produk on sample.kd_sample = produk.kd_sample)inner join detil_pp on sample.kd_sample = detil_pp.kd_sample) where detil_pp.no_pp like '%" & xKriteria & "%'"
        xmycmd = New OdbcCommand(sql, MyCnn)

        Try

            dreader = xmycmd.ExecuteReader
            lvpp.Items.Clear()

            While dreader.Read

                With lvpp.Items.Add(dreader("kd_produk"))
                    .subitems.add(dreader("nm_produk"))
                    .subitems.add(dreader("harga"))
                    .subitems.add(dreader("jml_pesan"))
                    .subitems.add(dreader("jml_harga"))
                End With
            End While
        Finally
        End Try
    End Sub
    Public Sub tampildatalbb(ByVal xKriteria As String)

        Dim sql As String

        sql = "select detil_lbb.no_lbb, lbb.tgl_lbb, bahan.kd_bahan, bahan.nm_bahan, bahan.hrg_bahan, detil_lbb.qty, detil_lbb.jml_harga from(lbb, detil_lbb, bahan) where lbb.no_lbb = detil_lbb.no_lbb and detil_lbb.kd_bahan = bahan.kd_bahan and lbb.no_pp like '%" & xKriteria & "%'"
        xmycmd = New OdbcCommand(sql, MyCnn)

        Try

            dreader = xmycmd.ExecuteReader
            lvbahan.Items.Clear()

            While dreader.Read

                With lvbahan.Items.Add(dreader("kd_bahan"))
                    .subitems.add(dreader("nm_bahan"))
                    .subitems.add(dreader("hrg_bahan"))
                    .subitems.add(dreader("qty"))
                    .subitems.add(dreader("jml_harga"))
                    txtnolbb.Text = dreader.Item("no_lbb")
                    txttgllbb.Text = dreader.Item("tgl_lbb")
                End With
            End While
        Finally
        End Try
    End Sub
    Private Sub frmbphd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtnobphd.Text = objbphd.autonumber
        txtnobphd.Enabled = False
        btnsimpan.Enabled = False
    End Sub

    Private Sub btncaripp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncaripp.Click
        frmpopupbphd.Show()
    End Sub

    Private Sub txtnopp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnopp.TextChanged
        Call tampildatapp(txtnopp.Text)
        btnsimpan.Enabled = True
        Call tampildatalbb(txtnopp.Text)
    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        If txtnopp.Text = "" Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Information, "INFORMASI")
        Else
            Dim nilaikembali1 As Integer
            objbphd.PNo_BPHD = txtnobphd.Text
            objbphd.PTgl_BPHD = Format(dtpbphd.Value, "yyy-MM-dd")
            objbphd.PNo_LBB = txtnolbb.Text
            objbphd.PNo_PP = txtnopp.Text
            nilaikembali1 = objbphd.simpan()
            If nilaikembali1 = 1 Then
                MsgBox("Data Berhasil Disimpan", MsgBoxStyle.Information, "INFORMASI")
            End If
            txtnobphd.Text = objbphd.autonumber
            txtnopp.Clear()
            txttglpp.Clear()
            txtnmcust.Clear()
            txtnolbb.Clear()
            txttgllbb.Clear()
            lvbahan.Items.Clear()
            lvpp.Items.Clear()
            btnsimpan.Enabled = False
        End If
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        txtnobphd.Text = objbphd.autonumber
        txtnopp.Clear()
        txttglpp.Clear()
        txtnmcust.Clear()
        txtnolbb.Clear()
        txttgllbb.Clear()
        lvbahan.Items.Clear()
        lvpp.Items.Clear()
        btnsimpan.Enabled = False
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnobphd.Text = objbphd.autonumber
            txtnopp.Clear()
            txttglpp.Clear()
            txtnmcust.Clear()
            txtnolbb.Clear()
            txttgllbb.Clear()
            lvbahan.Items.Clear()
            lvpp.Items.Clear()
            btnsimpan.Enabled = False
        End If
    End Sub
End Class