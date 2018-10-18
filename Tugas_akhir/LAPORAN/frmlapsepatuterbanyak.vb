Public Class frmlapsepatuterbanyak

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        Me.Close()
    End Sub

    Private Sub btncetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncetak.Click
        Cetak_Lap_Sepatuterbanyak(dtp1.Value, dtp2.Value)
    End Sub
End Class