Public Class frmpopupfakturjpp
    Dim objfaktur As New clsfaktur
    Sub PilihBarisView()
        frmjpp.txtnofaktur.Text = lvpp.FocusedItem.Text
        frmjpp.txttglfaktur.Text = lvpp.FocusedItem.SubItems(1).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupfakturjpp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call objfaktur.tampildatafaktur()
    End Sub
    Private Sub btnpilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpilih.Click
        If lvpp.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
            Me.Close()
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        Me.Close()
    End Sub

    Private Sub lvpp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvpp.DoubleClick
        If lvpp.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
            Me.Close()
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub lvpp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvpp.SelectedIndexChanged

    End Sub
End Class