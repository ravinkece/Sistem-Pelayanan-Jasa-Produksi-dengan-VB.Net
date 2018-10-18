Public Class frmpopupcustomer
    Dim objcustomer As New clscustomer
    Public refkdcustomer As String
    Public refnmcustomer As String
    Public refalamat As String
    Public reftelp As String
    Public refemail As String
    Sub IsiListView(Optional ByVal kriteria As String = "%")
        Dim xList As List(Of clscustomer)
        xList = objcustomer.tampildata(kriteria)
        lvcustomer.Items.Clear()
        For baris As Integer = 0 To xList.Count - 1
            lvcustomer.Items.Add(xList.Item(baris).PKdCust)
            lvcustomer.Items(baris).SubItems.Add(xList.Item(baris).PNmCust)
            lvcustomer.Items(baris).SubItems.Add(xList.Item(baris).PAlamat)
            lvcustomer.Items(baris).SubItems.Add(xList.Item(baris).PTelp)
            lvcustomer.Items(baris).SubItems.Add(xList.Item(baris).PEmail)
        Next
    End Sub

    Sub PilihBarisView()
        refkdcustomer = lvcustomer.FocusedItem.Text
        refnmcustomer = lvcustomer.FocusedItem.SubItems(1).Text
        refalamat = lvcustomer.FocusedItem.SubItems(2).Text
        reftelp = lvcustomer.FocusedItem.SubItems(3).Text
        refemail = lvcustomer.FocusedItem.SubItems(4).Text
        Me.Dispose()
    End Sub
    Private Sub frmpopupcustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call IsiListView()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If lvcustomer.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub lvkurir_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvcustomer.DoubleClick
        If lvcustomer.Items.Count = 0 Then
            MsgBox("Belum Ada Data")
        Else
            Call PilihBarisView()
        End If
    End Sub
    Private Sub txtkatakunci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtkatakunci.TextChanged
        Call IsiListView(txtkatakunci.Text)
    End Sub

    Private Sub lvcustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvcustomer.SelectedIndexChanged

    End Sub
End Class