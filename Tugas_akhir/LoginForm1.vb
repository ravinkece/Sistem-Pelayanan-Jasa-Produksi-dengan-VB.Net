Imports System.Data.Odbc
Public Class LoginForm1
    Dim CMD As New OdbcCommand
    Dim RD As OdbcDataReader
    Dim DrawingFont As New Font("Arial", 20)
    Dim CaptchaImage As New Bitmap(140, 40)
    Dim CaptchaGraf As Graphics = Graphics.FromImage(CaptchaImage)
    Dim Alphabet As String = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz"
    Dim CaptchaString, TickRandom As String
    Dim ProcessNumber As Integer

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtuser.MaxLength = 10
        txtpass.PasswordChar = "*"
        txtuser.Clear()
        txtpass.Clear()
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        Dim sql As String
        Dim tmpBaca As New List(Of clsstaff)
        If txtuser.Text = "" Or txtpass.Text = "" Then
            MsgBox("Harap Input Username dan Password")
        Else
            Call BukaConn()
            sql = "select * from staff where username='" & txtuser.Text & "' and password='" & txtpass.Text & "'"
            CMD = New OdbcCommand(sql, MyCnn)
            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows Then
                Me.Hide()
                Form1.Show()
                frmpengajuan.txtkdstaff.Text = RD("kd_staff")
                frmpembelianbahan.txtkdstaff.Text = RD("kd_staff")
                frmspk.txtkdstaff.Text = RD("kd_staff")
                'Form1.LAPORANPENGADAANToolStripMenuItem.Enabled = True
            Else
                MsgBox("Username atau Password salah")
                txtuser.Clear()
                txtpass.Clear()
                txtuser.Focus()
            End If
        End If
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        If (MessageBox.Show("Apakah Anda Yakin Ingin Mematikan Sistem?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
        End If
    End Sub
End Class
