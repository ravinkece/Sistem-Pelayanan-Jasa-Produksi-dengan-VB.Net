Public Class frmpopupkwt
    Dim objspk As New clsspk
    Sub PilihBarisView()
        frmkwitansi.txtnospk.Text = lvkwt.FocusedItem.Text
        frmkwitansi.txttglspk.Text = lvkwt.FocusedItem.SubItems(1).Text
        frmkwitansi.txtnmkendaraan.Text = lvkwt.FocusedItem.SubItems(2).Text
        frmkwitansi.txtnominal.Text = lvkwt.FocusedItem.SubItems(3).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupkwt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call objspk.TampilKwt(txtkatakunci.Text)
    End Sub

    Private Sub btnpilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpilih.Click
        If lvkwt.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub lvkwt_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvkwt.DoubleClick
        If lvkwt.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub lvkwt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvkwt.SelectedIndexChanged

    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        Me.Close()
    End Sub

    Private Sub txtkatakunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkatakunci.TextChanged
        Call objspk.TampilKwt(txtkatakunci.Text)
    End Sub
End Class