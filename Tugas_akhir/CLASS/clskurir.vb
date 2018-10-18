Imports System.Data.Odbc
Public Class clskurir

    Private FKdKurir As String
    Private FNmKurir As String
    Private FAlamat As String
    Private FTelp As String
    Private FEmail As String
    Public Property PKdKurir() As String
        Get
            Return FKdKurir
        End Get
        Set(ByVal value As String)
            FKdKurir = value
        End Set
    End Property

    Public Property PNmKurir() As String
        Get
            Return FNmKurir
        End Get
        Set(ByVal value As String)
            FNmKurir = value
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

        SQL = "SELECT * FROM kurir ORDER BY kd_kurir desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("kd_kurir"), 4)) + 1
            Autonilai = "KUR" & Right("00", 2 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "KUR01"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function cari() As Boolean
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "SELECT * FROM kurir WHERE kd_kurir=?"
        xmycmd = New OdbcCommand(Query, MyCnn)
        xmycmd.Parameters.AddWithValue("kd_kurir", FKdKurir)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            xmyread.Read()
            FNmKurir = xmyread.Item("nm_kurir").ToString
            FAlamat = xmyread.Item("alamat").ToString
            FTelp = xmyread.Item("telp").ToString
            FEmail = xmyread.Item("email").ToString
            FKdKurir = xmyread.Item("kd_kurir").ToString
            xmyread.Close()
            Return True
        Else
            xmyread.Close()
            Return False
        End If
    End Function

    Public Function simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO kurir (kd_kurir, nm_kurir, alamat, telp, email)values (?,?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("kd_kurir", FKdKurir)
        mycmd.Parameters.AddWithValue("nm_kurir", FNmKurir)
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

        sql = "UPDATE kurir SET nm_kurir=?, alamat=?, telp=?, email=? WHERE kd_kurir=?"

        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("nm_kurir", FNmKurir)
        xmycmd.Parameters.AddWithValue("alamat", FAlamat)
        xmycmd.Parameters.AddWithValue("telp", FTelp)
        xmycmd.Parameters.AddWithValue("email", FEmail)
        xmycmd.Parameters.AddWithValue("kd_kurir", FKdKurir)
        xmycmd.Prepare()
        X = xmycmd.ExecuteNonQuery()

        xmycmd.Dispose()
        Return X
    End Function

    Public Function hapus() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim x As Integer
        sql = "DELETE FROM kurir WHERE kd_kurir=?"
        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("kd_kurir", FKdKurir)
        xmycmd.Prepare()
        x = xmycmd.ExecuteNonQuery()
        xmycmd.Dispose()
        Return x
    End Function

    Public Function tampidata(ByVal xdata As String) As List(Of clskurir)
        Dim Q As String
        Dim xmycmd As OdbcCommand
        Dim xmyread As OdbcDataReader
        Dim tmpbaca As New List(Of clskurir)

        Q = "Select * FROM kurir WHERE nm_kurir like '%" & xdata & "%'"
        xmycmd = New OdbcCommand(Q, MyCnn)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            While xmyread.Read
                Dim objtemp As New clskurir
                objtemp.FKdKurir = xmyread.Item("kd_kurir")
                objtemp.FNmKurir = xmyread.Item("nm_kurir")
                objtemp.FAlamat = xmyread.Item("alamat")
                objtemp.FTelp = xmyread.Item("telp")
                objtemp.FEmail = xmyread.Item("email")
                tmpbaca.Add(objtemp)
            End While
        End If
        xmyread.Close()
        Return tmpbaca
    End Function
End Class
