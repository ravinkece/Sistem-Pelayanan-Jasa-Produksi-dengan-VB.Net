Public Class frmpopupsampleajuan
    Dim objsample As New clssample
    Sub PilihBarisView()
        frmpengajuan.txtkdsample.Text = lvsample.FocusedItem.Text
        frmpengajuan.txtnmsample.Text = lvsample.FocusedItem.SubItems(1).Text
        frmpengajuan.txthrg.Text = lvsample.FocusedItem.SubItems(2).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupsampleajuan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call objsample.Tampilsampleaju(frmpengajuan.txtkdcust.Text)
    End Sub

    Private Sub btnpilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpilih.Click
        If lvsample.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub lvsample_DockChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvsample.DockChanged
     
    End Sub

    Private Sub lvsample_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvsample.SelectedIndexChanged

    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        Me.Close()
    End Sub

    Private Sub txtkatakunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkatakunci.TextChanged
        Call objsample.Tampilsampleaju(txtkatakunci.Text)
    End Sub
End Class