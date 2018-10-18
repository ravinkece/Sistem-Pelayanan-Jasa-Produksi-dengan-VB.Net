Public Class frmpopuplbb
    Dim objpp As New clspp
    Sub PilihBarisView()
        frmlbb.txtnopp.Text = lvlbb.FocusedItem.Text
        frmlbb.txttglpp.Text = lvlbb.FocusedItem.SubItems(1).Text
        frmlbb.txtnmcust.Text = lvlbb.FocusedItem.SubItems(2).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopuplbb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call objpp.Tampillbb(txtkatakunci.Text)
    End Sub

    Private Sub btnpilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpilih.Click
        If lvlbb.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
            Me.Close()
        Else
            Call PilihBarisView()
            frmlbb.btncaribahan.Enabled = True
        End If
    End Sub

    Private Sub lvlbb_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvlbb.DoubleClick
        If lvlbb.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
            Me.Close()
        Else
            Call PilihBarisView()
            frmlbb.btncaribahan.Enabled = True
        End If
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        Me.Close()
    End Sub

    Private Sub txtkatakunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkatakunci.TextChanged
        Call objpp.Tampillbb(txtkatakunci.Text)
    End Sub
End Class