Imports System.Data.Odbc
Public Class frmfaktur
    Dim Mycmd As New OdbcCommand
    Dim dreader As OdbcDataReader
    Dim objfaktur As New clsfaktur
    Function total() As Double
        Dim GT As Double = 0
        For i As Integer = 0 To lvfaktur.Items.Count - 1
            GT = GT + CDbl(lvfaktur.Items(i).SubItems(4).Text)
        Next
        Return GT
    End Function
    Public Sub tampildatapp(ByVal xKriteria As String)

        Dim sql As String

        sql = "select produk.kd_produk, produk.nm_produk, produk.harga, detil_pp.jml_pesan, detil_pp.jml_harga from (produk inner join sample on produk.kd_sample = sample.kd_sample)inner join detil_pp on sample.kd_sample = detil_pp.kd_sample where detil_pp.no_pp like '%" & xKriteria & "%'"
        Mycmd = New OdbcCommand(sql, MyCnn)

        Try

            dreader = Mycmd.ExecuteReader
            lvfaktur.Items.Clear()

            While dreader.Read

                With lvfaktur.Items.Add(dreader("kd_produk"))
                    .subitems.add(dreader("nm_produk"))
                    .subitems.add(dreader("harga"))
                    .subitems.add(dreader("jml_pesan"))
                    .subitems.add(dreader("jml_harga"))
                End With
            End While
        Finally
        End Try
    End Sub
    Private Sub frmfaktur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtnofaktur.Text = objfaktur.autonumber
        txtnofaktur.Enabled = False
        btnsimpan.Enabled = False
    End Sub

    Private Sub txtnopp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnopp.TextChanged
        Call tampildatapp(txtnopp.Text)
        txttotal.Text = Format(CDbl(total()), "###,###,###")
    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        frmpopupfaktur.Show()
    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        If lvfaktur.Items.Count = 0 Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Information, "INFORMASI")
        Else
            Dim nilaikembali1 As Integer
            objfaktur.PNo_Faktur = txtnofaktur.Text
            objfaktur.PTgl_Faktur = Format(dtptglfaktur.Value, "yyy-MM-dd")
            objfaktur.PNo_PP = txtnopp.Text
            objfaktur.PTgl_Kirim = Format(dtpestimasi.Value, "yyy-MM-dd")
            nilaikembali1 = objfaktur.simpan()
            If nilaikembali1 = 1 Then
                MsgBox("Data Berhasil Disimpan", MsgBoxStyle.Information, "INFORMASI")
                ModuleCetak.CetakCR_Faktur(txtnofaktur.Text)
            End If
            txtnofaktur.Text = objfaktur.autonumber
            btncari.Enabled = True
            btnsimpan.Enabled = False
            txtnopp.Clear()
            txttglpp.Clear()
            txtnmcust.Clear()
            lvfaktur.Items.Clear()
            txttotal.Clear()
        End If
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        txtnopp.Clear()
        txttglpp.Clear()
        txtnmcust.Clear()
        lvfaktur.Items.Clear()
        txttotal.Clear()
        txtnofaktur.Text = objfaktur.autonumber
        btnsimpan.Enabled = False
        btncari.Enabled = True
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnopp.Clear()
            txttglpp.Clear()
            txtnmcust.Clear()
            lvfaktur.Items.Clear()
            txttotal.Clear()
            btnsimpan.Enabled = False
            btncari.Enabled = True
            txtnofaktur.Text = objfaktur.autonumber
        End If
    End Sub

    Private Sub dtpestimasi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpestimasi.ValueChanged

    End Sub
End Class