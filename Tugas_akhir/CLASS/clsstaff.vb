Imports System.Data.Odbc
Public Class clsstaff

    Private FKdStaff As String
    Private FNmStaff As String
    Private FUsername As String
    Private FPassword As String
    Private FAlamat As String
    Private FTelp As String
    Private FEmail As String
    Public Property PKdStaff() As String
        Get
            Return FKdStaff
        End Get
        Set(ByVal value As String)
            FKdStaff = value
        End Set
    End Property

    Public Property PNmStaff() As String
        Get
            Return FNmStaff
        End Get
        Set(ByVal value As String)
            FNmStaff = value
        End Set
    End Property

    Public Property PUsername() As String
        Get
            Return FUsername
        End Get
        Set(ByVal value As String)
            FUsername = value
        End Set
    End Property

    Public Property PPassword() As String
        Get
            Return FPassword
        End Get
        Set(ByVal value As String)
            FPassword = value
        End Set
    End Property

    Public Property PAlamat() As String
        Get
            Return FAlamat
        End Get
        Set(ByVal value As String)
            FAlamat = value
        End Set
    End Property

    Public Property PTelp() As String
        Get
            Return FTelp
        End Get
        Set(ByVal value As String)
            FTelp = value
        End Set
    End Property

    Public Property PEmail() As String
        Get
            Return FEmail
        End Get
        Set(ByVal value As String)
            FEmail = value
        End Set
    End Property
    Public Function autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM staff ORDER BY kd_staff desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("kd_staff"), 4)) + 1
            Autonilai = "STF" & Right("00", 2 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "STF01"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function cari() As Boolean
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "SELECT * FROM staff WHERE kd_staff=?"
        xmycmd = New OdbcCommand(Query, MyCnn)
        xmycmd.Parameters.AddWithValue("kd_staff", FKdStaff)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            xmyread.Read()
            FNmStaff = xmyread.Item("nm_staff").ToString
            FUsername = xmyread.Item("username").ToString
            FPassword = xmyread.Item("password").ToString
            FAlamat = xmyread.Item("alamat").ToString
            FTelp = xmyread.Item("telp").ToString
            FEmail = xmyread.Item("email").ToString
            FKdStaff = xmyread.Item("kd_staff").ToString
            xmyread.Close()
            Return True
        Else
            xmyread.Close()
            Return False
        End If
    End Function

    Public Function tampildata(ByVal xdata As String) As List(Of clsstaff)
        Dim Q As String
        Dim xmycmd As OdbcCommand
        Dim xmyread As OdbcDataReader
        Dim tmpbaca As New List(Of clsstaff)

        Q = "Select * FROM staff WHERE nm_staff like '%" & xdata & "%'"
        xmycmd = New OdbcCommand(Q, MyCnn)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            While xmyread.Read
                Dim objtemp As New clsstaff
                objtemp.FKdStaff = xmyread.Item("kd_staff")
                objtemp.FNmStaff = xmyread.Item("nm_staff")
                objtemp.FUsername = xmyread.Item("username")
                objtemp.FPassword = xmyread.Item("password")
                objtemp.FAlamat = xmyread.Item("alamat")
                objtemp.FTelp = xmyread.Item("telp")
                objtemp.FEmail = xmyread.Item("email")
                tmpbaca.Add(objtemp)
            End While
        End If
        xmyread.Close()
        Return tmpbaca
    End Function

    Public Function simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO staff (kd_staff, nm_staff, username, password, alamat, telp, email)values (?,?,?,?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("kd_staff", FKdStaff)
        mycmd.Parameters.AddWithValue("nm_staff", FNmStaff)
        mycmd.Parameters.AddWithValue("username", FUsername)
        mycmd.Parameters.AddWithValue("password", FPassword)
        mycmd.Parameters.AddWithValue("alamat", FAlamat)
        mycmd.Parameters.AddWithValue("telp", FTelp)
        mycmd.Parameters.AddWithValue("email", FEmail)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function

    Public Function ubah() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim X As Integer

        sql = "UPDATE staff SET nm_staff=?, username=?, password=?, alamat=?, telp=?, email=?  WHERE kd_staff=?"

        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("nm_staff", FNmStaff)
        xmycmd.Parameters.AddWithValue("username", FUsername)
        xmycmd.Parameters.AddWithValue("password", FPassword)
        xmycmd.Parameters.AddWithValue("alamat", FAlamat)
        xmycmd.Parameters.AddWithValue("telp", FTelp)
        xmycmd.Parameters.AddWithValue("email", FEmail)
        xmycmd.Parameters.AddWithValue("kd_staff", FKdStaff)
        xmycmd.Prepare()
        X = xmycmd.ExecuteNonQuery()

        xmycmd.Dispose()
        Return X
    End Function

    Public Function hapus() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim x As Integer
        sql = "DELETE FROM staff WHERE kd_staff=?"
        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("kd_staff", FKdStaff)
        xmycmd.Prepare()
        x = xmycmd.ExecuteNonQuery()
        xmycmd.Dispose()
        Return x
    End Function
End Class
