Public Class frmpopupbahan
    Dim objbahan As New clsbahan
    Public refkdbahan As String
    Public refnmbahan As String
    Public refjenis As String
    Public refhrg As String
    Public refsatuan As String
    Sub IsiListView(Optional ByVal kriteria As String = "%")
        Dim xList As List(Of clsbahan)
        xList = objbahan.tampildata(kriteria)
        lvbahan.Items.Clear()
        For baris As Integer = 0 To xList.Count - 1
            lvbahan.Items.Add(xList.Item(baris).PKdBahan)
            lvbahan.Items(baris).SubItems.Add(xList.Item(baris).PNmBahan)
            lvbahan.Items(baris).SubItems.Add(xList.Item(baris).PJnsBahan)
            lvbahan.Items(baris).SubItems.Add(xList.Item(baris).PHrgBahan)
            lvbahan.Items(baris).SubItems.Add(xList.Item(baris).PSatuan)
        Next
    End Sub

    Sub PilihBarisView()
        refkdbahan = lvbahan.FocusedItem.Text
        refnmbahan = lvbahan.FocusedItem.SubItems(1).Text
        refjenis = lvbahan.FocusedItem.SubItems(2).Text
        refhrg = lvbahan.FocusedItem.SubItems(3).Text
        refsatuan = lvbahan.FocusedItem.SubItems(3).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupbahan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call IsiListView()
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        Me.Close()
    End Sub

    Private Sub btnpilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpilih.Click
        If lvbahan.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub txtkatakunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkatakunci.TextChanged
        Call IsiListView(txtkatakunci.Text)
    End Sub

    Private Sub lvbahan_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvbahan.DoubleClick
        If lvbahan.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

End Class