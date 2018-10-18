Public Class frmpopupproduk
    Dim objsample As New clssample
    Sub PilihBarisView()
        frmentryproduk.txtkdsample.Text = lvproduk.FocusedItem.Text
        frmentryproduk.txtnmproduk.Text = lvproduk.FocusedItem.SubItems(1).Text
        frmentryproduk.txthrg.Text = lvproduk.FocusedItem.SubItems(2).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupproduk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call objsample.Tampilproduk(txtkatakunci.Text)
    End Sub

    Private Sub btnpilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpilih.Click
        If lvproduk.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
            Me.Close()
        Else
            Call PilihBarisView()
            frmentryproduk.btnsimpan.Enabled = True
        End If
    End Sub

    Private Sub lvproduk_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvproduk.DoubleClick
        If lvproduk.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
            Me.Close()
        Else
            Call PilihBarisView()
            frmentryproduk.btnsimpan.Enabled = True
        End If
    End Sub
    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        Me.Close()
    End Sub

    Private Sub txtkatakunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkatakunci.TextChanged
        Call objsample.Tampilproduk(txtkatakunci.Text)
    End Sub
End Class