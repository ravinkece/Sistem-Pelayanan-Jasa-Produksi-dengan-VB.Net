Public Class frmpopupsample
    Dim objsample As New clssample
    Public refkdsample As String
    Public refnmsample As String
    Public refgmbr As String
    Public refhrg As String
    Sub IsiListView(Optional ByVal kriteria As String = "%")
        Dim xList As List(Of clssample)
        xList = objsample.tampildata(kriteria)
        lvsample.Items.Clear()
        For baris As Integer = 0 To xList.Count - 1
            lvsample.Items.Add(xList.Item(baris).PKdSample)
            lvsample.Items(baris).SubItems.Add(xList.Item(baris).PNmSample)
            lvsample.Items(baris).SubItems.Add(xList.Item(baris).PGambar)
            lvsample.Items(baris).SubItems.Add(xList.Item(baris).PHrgSample)
        Next
    End Sub

    Sub PilihBarisView()
        refkdsample = lvsample.FocusedItem.Text
        refnmsample = lvsample.FocusedItem.SubItems(1).Text
        refgmbr = lvsample.FocusedItem.SubItems(2).Text
        refhrg = lvsample.FocusedItem.SubItems(3).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupsample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call IsiListView()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If lvsample.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub lvsample_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvsample.DoubleClick
        If lvsample.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub lvsample_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvsample.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub txtkatakunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkatakunci.TextChanged
        Call IsiListView(txtkatakunci.Text)
    End Sub
End Class