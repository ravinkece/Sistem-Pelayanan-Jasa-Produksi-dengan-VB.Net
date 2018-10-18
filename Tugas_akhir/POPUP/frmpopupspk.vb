Public Class frmpopupspk
    Dim objspk As New clsspk
    Sub PilihBarisView()
        frmPP.txtkdpengajuan.Text = lvpp.FocusedItem.Text
        frmPP.txttglpengajuan.Text = lvpp.FocusedItem.SubItems(1).Text
        frmPP.txtnmcust.Text = lvpp.FocusedItem.SubItems(2).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupspk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class