Imports System.Data.Odbc
Public Class frmPP
    Dim objpp As New clspp
    Dim Mycmd As New OdbcCommand
    Dim dreader As OdbcDataReader
    Dim objdetil As New clsdetil_pp
    Public Sub tampildatasample(ByVal xKriteria As String)

        Dim sql As String

        sql = "select sample.kd_sample, sample.nm_sample, sample.harga from ((sample inner join detil_pengajuan on sample.kd_sample = detil_pengajuan.kd_sample) inner join pengajuan on detil_pengajuan.kd_pengajuan = pengajuan.kd_pengajuan) where pengajuan.kd_pengajuan like '%" & xKriteria & "%'"
        Mycmd = New OdbcCommand(sql, MyCnn)

        Try

            dreader = Mycmd.ExecuteReader
            lvpp.Items.Clear()

            While dreader.Read

                With lvpp.Items.Add(dreader("kd_sample"))
                    .subitems.add(dreader("nm_sample"))
                    .subitems.add(dreader("harga"))
                End With
            End While
        Finally
            MyCnn.Close()
        End Try
    End Sub
    Private Sub frmPP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtnopp.Text = objpp.Autonumber
        txtnopp.Enabled = False
        btnsimpan.Enabled = False
        txtkdpengajuan.Enabled = False
        txttglpengajuan.Enabled = False
        txtnmcust.Enabled = False
        txtkdsample.Enabled = False
        txtnmsample.Enabled = False
        txthrg.Enabled = False
        btntambah.Enabled = True
        btnbataltambah.Enabled = False
    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        frmpopupPP.Show()
    End Sub

    Private Sub txtkdpengajuan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkdpengajuan.TextChanged
        Call tampildatasample(txtkdpengajuan.Text)
    End Sub

    Private Sub lvpp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvpp.DoubleClick
        Me.txtkdsample.Text = lvpp.FocusedItem.Text
        Me.txtnmsample.Text = lvpp.FocusedItem.SubItems(1).Text
        Me.txthrg.Text = lvpp.FocusedItem.SubItems(2).Text
    End Sub

    Private Sub txtjmlpesan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtjmlpesan.TextChanged
        txtjmlhrg.Text = Val(txthrg.Text) * Val(txtjmlpesan.Text)
    End Sub

    Private Sub btntambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntambah.Click
        Dim n As Integer
        For n = 0 To lvsample.Items.Count - 1
            If lvsample.Items(n).Text = txtkdsample.Text Then
                MsgBox("Data Sudah Ada Pada List")
                Exit Sub
            End If
        Next
        lvsample.Items.Add(txtkdsample.Text)
        lvsample.Items(n).SubItems.Add(txtnmsample.Text)
        lvsample.Items(n).SubItems.Add(txthrg.Text)
        lvsample.Items(n).SubItems.Add(txtjmlpesan.Text)
        lvsample.Items(n).SubItems.Add(txtjmlhrg.Text)
        txtkdsample.Clear()
        txtnmsample.Clear()
        txthrg.Clear()
        txtjmlpesan.Clear()
        txtjmlhrg.Clear()
        btnsimpan.Enabled = True
        btncari.Enabled = False
    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        If lvsample.Items.Count = 0 Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Information, "INFORMASI")
        Else
            Dim nilaikembali1, nilaikembali2 As Integer
            objpp.PNo_PP = txtnopp.Text
            objpp.PTgl_PP = Format(dtptglpp.Value, "yyy-MM-dd")
            objpp.PKd_Pengajuan = txtkdpengajuan.Text
            nilaikembali1 = objpp.Simpan()
            For x As Integer = 0 To lvsample.Items.Count - 1
                objdetil.PNo_PP = txtnopp.Text
                objdetil.PKd_Sample = lvsample.Items(x).SubItems(0).Text
                objdetil.PJml_Pesan = lvsample.Items(x).SubItems(3).Text
                objdetil.PJml_Hrg = lvsample.Items(x).SubItems(4).Text
                nilaikembali2 = objdetil.simpan()
            Next
            If nilaikembali1 = 1 And nilaikembali2 = 1 Then
                MsgBox("Data Berhasil Disimpan", MsgBoxStyle.Information, "INFORMASI")
            End If
            txtnopp.Text = objpp.Autonumber
        End If
    End Sub
    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnopp.Text = objpp.Autonumber
        End If
    End Sub

    Private Sub btnbataltambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbataltambah.Click
        txtkdsample.Clear()
        txtnmsample.Clear()
        txthrg.Clear()
        txtjmlpesan.Clear()
        txtjmlhrg.Clear()
    End Sub

    Private Sub lvpp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvpp.SelectedIndexChanged

    End Sub
End Class