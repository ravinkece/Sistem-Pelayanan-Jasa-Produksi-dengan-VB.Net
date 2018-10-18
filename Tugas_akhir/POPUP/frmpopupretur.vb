Public Class frmpopupretur
    Dim objfaktur As New clsfaktur
    Sub PilihBarisView()
        frmretur.txtnofaktur.Text = lvretur.FocusedItem.Text
        frmretur.txttglfaktur.Text = lvretur.FocusedItem.SubItems(1).Text
        frmretur.txtnmcust.Text = lvretur.FocusedItem.SubItems(2).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupretur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call objfaktur.tampildata(txtkatakunci.Text)
    End Sub

    Private Sub lvretur_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvretur.DoubleClick
        If lvretur.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub btnpilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpilih.Click
        If lvretur.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        Me.Close()
    End Sub

    Private Sub txtkatakunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkatakunci.TextChanged
        Call objfaktur.tampildata(txtkatakunci.Text)
    End Sub
End Class