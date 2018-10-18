Public Class frmpopupbphd
    Dim objpp As New clspp
    Sub PilihBarisView()
        frmbphd.txtnopp.Text = lvlbb.FocusedItem.Text
        frmbphd.txttglpp.Text = lvlbb.FocusedItem.SubItems(1).Text
        frmbphd.txtnmcust.Text = lvlbb.FocusedItem.SubItems(2).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupbphd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call objpp.Tampilbphd(txtkatakunci.Text)
    End Sub

    Private Sub btnpilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpilih.Click
        If lvlbb.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub lvlbb_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvlbb.DoubleClick
        If lvlbb.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub lvlbb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvlbb.SelectedIndexChanged

    End Sub

    Private Sub txtkatakunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkatakunci.TextChanged
        Call objpp.Tampilbphd(txtkatakunci.Text)
    End Sub
End Class