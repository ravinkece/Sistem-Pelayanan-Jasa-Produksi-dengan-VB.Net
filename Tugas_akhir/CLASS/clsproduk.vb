Imports System.Data.Odbc
Public Class clsproduk

    Private FKdProduk As String
    Private FNmProduk As String
    Private FHrgProduk As Integer
    Private FKdSample As String
    Public Property PKdProduk() As String
        Get
            Return FKdProduk
        End Get
        Set(ByVal value As String)
            FKdProduk = value
        End Set
    End Property

    Public Property PKdSample() As String
        Get
            Return FKdSample
        End Get
        Set(ByVal value As String)
            FKdSample = value
        End Set
    End Property

    Public Property PNmProduk() As String
        Get
            Return FNmProduk
        End Get
        Set(ByVal value As String)
            FNmProduk = value
        End Set
    End Property

    Public Property PHrgProduk() As Integer
        Get
            Return FHrgProduk
        End Get
        Set(ByVal value As Integer)
            FHrgProduk = value
        End Set
    End Property
    Public Function autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM produk ORDER BY kd_produk desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("kd_produk"), 4)) + 1
            Autonilai = "PRD" & Right("00000", 5 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "PRD00001"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function cari() As Boolean
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "SELECT * FROM produk WHERE kd_produk=?"
        xmycmd = New OdbcCommand(Query, MyCnn)
        xmycmd.Parameters.AddWithValue("kd_produk", FKdProduk)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            xmyread.Read()
            FNmProduk = xmyread.Item("nm_produk").ToString
            FHrgProduk = xmyread.Item("hrg_produk").ToString
            FKdSample = xmyread.Item("kd_sample").ToString
            FKdProduk = xmyread.Item("kd_produk").ToString
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
        strSQL = "INSERT INTO produk (kd_produk, nm_produk, harga, kd_sample)values (?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("kd_produk", FKdProduk)
        mycmd.Parameters.AddWithValue("nm_produk", FNmProduk)
        mycmd.Parameters.AddWithValue("harga", FHrgProduk)
        mycmd.Parameters.AddWithValue("kd_sample", FKdSample)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function

    Public Function ubah() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim X As Integer

        sql = "UPDATE produk SET nm_produk=?, hrg_produk=?, kd_sample=? WHERE kd_produk=?"

        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("nm_produk", FNmProduk)
        xmycmd.Parameters.AddWithValue("hrg_produk", FHrgProduk)
        xmycmd.Parameters.AddWithValue("kd_sample", FKdSample)
        xmycmd.Parameters.AddWithValue("kd_produk", FKdProduk)

        xmycmd.Prepare()
        X = xmycmd.ExecuteNonQuery()

        xmycmd.Dispose()
        Return X
    End Function

    Public Function hapus() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim x As Integer
        sql = "DELETE FROM produk WHERE kd_produk=?"
        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("kd_produk", FKdProduk)
        xmycmd.Prepare()
        x = xmycmd.ExecuteNonQuery()
        xmycmd.Dispose()
        Return x
    End Function

    Public Function tampildata(ByVal xdata As String) As List(Of clsproduk)
        Dim Q As String
        Dim xmycmd As OdbcCommand
        Dim xmyread As OdbcDataReader
        Dim tmpbaca As New List(Of clsproduk)

        Q = "Select * FROM produk WHERE nm_produk like '%" & xdata & "%'"
        xmycmd = New OdbcCommand(Q, MyCnn)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            While xmyread.Read
                Dim objtemp As New clsproduk
                objtemp.FKdProduk = xmyread.Item("kd_produk")
                objtemp.FNmProduk = xmyread.Item("nm_produk")
                objtemp.FHrgProduk = xmyread.Item("hrg_produk")
                objtemp.FKdSample = xmyread.Item("kd_sample")
                tmpbaca.Add(objtemp)
            End While
        End If
        xmyread.Close()
        Return tmpbaca

    End Function
End Class
