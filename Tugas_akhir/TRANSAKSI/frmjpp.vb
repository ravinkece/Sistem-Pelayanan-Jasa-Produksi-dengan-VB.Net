Public Class frmjpp
    Dim objjpp As New clsjpp
    Dim objada As New clsada
    Dim objdetil As New clsdetil_jpp
    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnofaktur.Clear()
            txttglfaktur.Clear()
            txtketpp.Clear()
            txtnospk.Clear()
            txttglspk.Clear()
            txtketspk.Clear()
            txtnojpp.Text = objjpp.Autonumber
            btncetak.Enabled = False
            lvjpp.Items.Clear()
        End If
    End Sub

    Private Sub frmjpp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtptgljpp.Value = Now
        dtptgljpp.Enabled = False
        txtnojpp.Text = objjpp.Autonumber
    End Sub

    Private Sub btncarifaktur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncarifaktur.Click
        frmpopupfakturjpp.Show()
    End Sub

    Private Sub btncarispk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncarispk.Click
        frmpopupspkjpp.Show()
       
    End Sub

    Private Sub btntambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntambah.Click
        Dim n As Integer
        txtnospk.Enabled = False
        txttglspk.Enabled = False
        txtketspk.Enabled = False
        If txtnojpp.Text = "" Or txtnospk.Text = "" Or txtketspk.Text = "" Or txtketpp.Text = "" Then
            MsgBox("Terdapat Data Kosong")

        Else
            For n = 0 To lvjpp.Items.Count - 1
                If lvjpp.Items(n).Text = txtnofaktur.Text Then
                    MsgBox("Data Sudah Ada Pada List")
                    Exit Sub
                End If
            Next
            lvjpp.Items.Add(txtnofaktur.Text)
            lvjpp.Items(n).SubItems.Add(txtketpp.Text)
            lvjpp.Items(n).SubItems.Add(txtnospk.Text)
            lvjpp.Items(n).SubItems.Add(txtketspk.Text)
            txtnofaktur.Clear()
            txttglfaktur.Clear()
            txtketpp.Clear()
            'txtnospk.Clear()
            'txttglspk.Clear()
            'txtketspk.Clear()
            btncetak.Enabled = True
        End If
    End Sub

    Private Sub btnbataltambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbataltambah.Click
        txtnofaktur.Clear()
        txttglfaktur.Clear()
        txtketpp.Clear()
        txtnospk.Clear()
        txttglspk.Clear()
        txtketspk.Clear()
    End Sub

    Private Sub btncetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncetak.Click
        If lvjpp.Items.Count = 0 Then
            MsgBox("Data Belum Lengkap", MsgBoxStyle.Information, "INFORMASI")
        Else
            Dim nilaikembali1, nilaikembali2, nilaikembali3 As Integer
            objjpp.PNo_JPP = txtnojpp.Text
            objjpp.PTgl_JPP = Format(dtptgljpp.Value, "yyy-MM-dd")
            nilaikembali1 = objjpp.Simpan()
            For x As Integer = 0 To lvjpp.Items.Count - 1
                objdetil.PNo_Jpp = txtnojpp.Text
                objdetil.PNo_Spk = lvjpp.Items(x).SubItems(2).Text
                objdetil.PKet = lvjpp.Items(x).SubItems(3).Text
                nilaikembali2 = objdetil.simpan()
                objada.PNo_JPP = txtnojpp.Text
                objada.PNo_Faktur = lvjpp.Items(x).SubItems(0).Text
                objada.PKet = lvjpp.Items(x).SubItems(1).Text
                nilaikembali3 = objada.simpan()
            Next
            If nilaikembali1 = 1 And nilaikembali2 = 1 And nilaikembali3 = 1 Then
                MsgBox("Data Berhasil Disimpan", MsgBoxStyle.Information, "INFORMASI")
                ModuleCetak.CetakCR_jpp1(txtnojpp.Text)
            End If
            txtnofaktur.Clear()
            txttglfaktur.Clear()
            txtketpp.Clear()
            txtnospk.Clear()
            txttglspk.Clear()
            txtketspk.Clear()
            txtnojpp.Text = objjpp.Autonumber
            btncetak.Enabled = False
            lvjpp.Items.Clear()
        End If
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        txtnofaktur.Clear()
        txttglfaktur.Clear()
        txtketpp.Clear()
        txtnospk.Clear()
        txttglspk.Clear()
        txtketspk.Clear()
        txtnojpp.Text = objjpp.Autonumber
        btncetak.Enabled = False
        lvjpp.Items.Clear()
    End Sub
End Class