Public Class frmpopupstaff
    Dim objstaff As New clsstaff
    Public refkdstaff As String
    Public refnmstaff As String
    Public reftelp As String
    Public refusername As String
    Public refalamat As String
    Public refemail As String
    Sub IsiListView(Optional ByVal kriteria As String = "%")
        Dim xList As List(Of clsstaff)
        xList = objstaff.tampildata(kriteria)
        lvstaff.Items.Clear()
        For baris As Integer = 0 To xList.Count - 1
            lvstaff.Items.Add(xList.Item(baris).PKdStaff)
            lvstaff.Items(baris).SubItems.Add(xList.Item(baris).PNmStaff)
            lvstaff.Items(baris).SubItems.Add(xList.Item(baris).PTelp)
            lvstaff.Items(baris).SubItems.Add(xList.Item(baris).PUsername)
            lvstaff.Items(baris).SubItems.Add(xList.Item(baris).PAlamat)
            lvstaff.Items(baris).SubItems.Add(xList.Item(baris).PEmail)
        Next
    End Sub

    Sub PilihBarisView()
        refkdstaff = lvstaff.FocusedItem.Text
        refnmstaff = lvstaff.FocusedItem.SubItems(1).Text
        reftelp = lvstaff.FocusedItem.SubItems(2).Text
        refusername = lvstaff.FocusedItem.SubItems(3).Text
        refalamat = lvstaff.FocusedItem.SubItems(4).Text
        refemail = lvstaff.FocusedItem.SubItems(5).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupstaff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call IsiListView()
    End Sub

    Private Sub btnpilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpilih.Click
        If lvstaff.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub lvstaff_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvstaff.DoubleClick
        If lvstaff.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub
    Private Sub txtkatakunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkatakunci.TextChanged
        Call IsiListView(txtkatakunci.Text)
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        Me.Close()
    End Sub
End Class