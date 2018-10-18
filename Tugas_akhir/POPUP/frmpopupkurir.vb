Public Class frmpopupkurir
    Dim objkurir As New clskurir
    Public refkdkurir As String
    Public refnmkurir As String
    Public refalamat As String
    Public reftelp As String
    Public refemail As String
    Sub IsiListView(Optional ByVal kriteria As String = "%")
        Dim xList As List(Of clskurir)
        xList = objkurir.tampidata(kriteria)
        lvkurir.Items.Clear()
        For baris As Integer = 0 To xList.Count - 1
            lvkurir.Items.Add(xList.Item(baris).PKdKurir)
            lvkurir.Items(baris).SubItems.Add(xList.Item(baris).PNmKurir)
            lvkurir.Items(baris).SubItems.Add(xList.Item(baris).PAlamat)
            lvkurir.Items(baris).SubItems.Add(xList.Item(baris).PTelp)
            lvkurir.Items(baris).SubItems.Add(xList.Item(baris).PEmail)
        Next
    End Sub

    Sub PilihBarisView()
        refkdkurir = lvkurir.FocusedItem.Text
        refnmkurir = lvkurir.FocusedItem.SubItems(1).Text
        refalamat = lvkurir.FocusedItem.SubItems(2).Text
        reftelp = lvkurir.FocusedItem.SubItems(3).Text
        refemail = lvkurir.FocusedItem.SubItems(4).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupkurir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call IsiListView()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If lvkurir.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub lvkurir_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvkurir.DoubleClick
        If lvkurir.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub
    Private Sub txtkatakunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkatakunci.TextChanged
        Call IsiListView(txtkatakunci.Text)
    End Sub
End Class