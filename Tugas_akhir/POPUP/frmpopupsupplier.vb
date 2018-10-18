Public Class frmpopupsupplier
    Dim objsupplier As New clssupplier
    Public refkdsupp As String
    Public refnmsupp As String
    Public refalamat As String
    Public reftelp As String
    Public refemail As String
    Sub IsiListView(Optional ByVal kriteria As String = "%")
        Dim xList As List(Of clssupplier)
        xList = objsupplier.Tampildata(kriteria)
        lvsupplier.Items.Clear()
        For baris As Integer = 0 To xList.Count - 1
            lvsupplier.Items.Add(xList.Item(baris).PKd_Supplier)
            lvsupplier.Items(baris).SubItems.Add(xList.Item(baris).PNm_Supplier)
            lvsupplier.Items(baris).SubItems.Add(xList.Item(baris).PAlamat)
            lvsupplier.Items(baris).SubItems.Add(xList.Item(baris).PTelp)
            lvsupplier.Items(baris).SubItems.Add(xList.Item(baris).PEmail)
        Next
    End Sub

    Sub PilihBarisView()
        refkdsupp = lvsupplier.FocusedItem.Text
        refnmsupp = lvsupplier.FocusedItem.SubItems(1).Text
        refalamat = lvsupplier.FocusedItem.SubItems(2).Text
        reftelp = lvsupplier.FocusedItem.SubItems(3).Text
        refemail = lvsupplier.FocusedItem.SubItems(4).Text
        Me.Dispose()
    End Sub
    Private Sub btnpilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpilih.Click
        If lvsupplier.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub lvsupplier_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvsupplier.DoubleClick
        If lvsupplier.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub
    Private Sub txtkatakunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkatakunci.TextChanged
        Call IsiListView(txtkatakunci.Text)
    End Sub

    Private Sub frmpopupsupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call IsiListView()
    End Sub
End Class