Public Class frmpopupkendaraan
    Dim objkendaraan As New clskendaraan
    Public refnoplat As String
    Public refnmkend As String
    Public refjenis As String
    Public refmerk As String
    Public refmuatan As String
    Public refharga As String
    Sub IsiListView(Optional ByVal kriteria As String = "%")
        Dim xList As List(Of clskendaraan)
        xList = objkendaraan.tampildata(kriteria)
        lvkendaraan.Items.Clear()
        For baris As Integer = 0 To xList.Count - 1
            lvkendaraan.Items.Add(xList.Item(baris).PNoPlat)
            lvkendaraan.Items(baris).SubItems.Add(xList.Item(baris).PNmKend)
            lvkendaraan.Items(baris).SubItems.Add(xList.Item(baris).PJnsKend)
            lvkendaraan.Items(baris).SubItems.Add(xList.Item(baris).PMerk)
            lvkendaraan.Items(baris).SubItems.Add(xList.Item(baris).PMuatan)
            lvkendaraan.Items(baris).SubItems.Add(xList.Item(baris).PHarga)
        Next
    End Sub

    Sub PilihBarisView()
        refnoplat = lvkendaraan.FocusedItem.Text
        refnmkend = lvkendaraan.FocusedItem.SubItems(1).Text
        refjenis = lvkendaraan.FocusedItem.SubItems(2).Text
        refmerk = lvkendaraan.FocusedItem.SubItems(3).Text
        refmuatan = lvkendaraan.FocusedItem.SubItems(4).Text
        refharga = lvkendaraan.FocusedItem.SubItems(5).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupkendaraan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call IsiListView()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If lvkendaraan.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub lvkendaraan_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvkendaraan.DoubleClick
        If lvkendaraan.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub lvkendaraan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvkendaraan.SelectedIndexChanged

    End Sub

    Private Sub txtkatakunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkatakunci.TextChanged
        Call IsiListView(txtkatakunci.Text)
    End Sub
End Class