Public Class frmpopupfaktur
    Dim objpp As New clspp
    Sub PilihBarisView()
        frmfaktur.txtnopp.Text = lvpp.FocusedItem.Text
        frmfaktur.txttglpp.Text = lvpp.FocusedItem.SubItems(1).Text
        frmfaktur.txtnmcust.Text = lvpp.FocusedItem.SubItems(2).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupfaktur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call objpp.TampilFaktur(txtkatakunci.Text)
    End Sub

    Private Sub btnpilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpilih.Click
        If lvpp.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
            Me.Close()
        Else
            Call PilihBarisView()
            frmfaktur.btnsimpan.Enabled = True
        End If
    End Sub

    Private Sub lvpp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvpp.DoubleClick
        If lvpp.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
            Me.Close()
        Else
            Call PilihBarisView()
            frmfaktur.btnsimpan.Enabled = True
        End If
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        Me.Close()
    End Sub

    Private Sub txtkatakunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkatakunci.TextChanged
        Call objpp.TampilFaktur(txtkatakunci.Text)
    End Sub
End Class