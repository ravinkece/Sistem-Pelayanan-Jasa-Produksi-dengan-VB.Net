Public Class frmpopupspkjpp
    Dim objspk As New clsspk
    Sub PilihBarisView()
        frmjpp.txtnospk.Text = lvspk.FocusedItem.Text
        frmjpp.txttglspk.Text = lvspk.FocusedItem.SubItems(1).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupspkjpp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call objspk.Tampilspkjpp()
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        Me.Close()
    End Sub

    Private Sub btnpilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpilih.Click
        If lvspk.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
            Me.Close()
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub lvspk_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvspk.DoubleClick
        If lvspk.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
            Me.Close()
        Else
            Call PilihBarisView()
        End If
    End Sub
End Class