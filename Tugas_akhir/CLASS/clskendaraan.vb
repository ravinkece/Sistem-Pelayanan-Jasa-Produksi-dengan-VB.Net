Imports System.Data.Odbc
Public Class clskendaraan

    Private FNoPlat As String
    Private FNmKend As String
    Private FJnsKend As String
    Private FMerk As String
    Private FMuatan As Integer
    Private FHarga As Integer
    Public Property PNoPlat() As String
        Get
            Return FNoPlat
        End Get
        Set(ByVal value As String)
            FNoPlat = value
        End Set
    End Property

    Public Property PNmKend() As String
        Get
            Return FNmKend
        End Get
        Set(ByVal value As String)
            FNmKend = value
        End Set
    End Property

    Public Property PJnsKend() As String
        Get
            Return FJnsKend
        End Get
        Set(ByVal value As String)
            FJnsKend = value
        End Set
    End Property

    Public Property PMerk() As String
        Get
            Return FMerk
        End Get
        Set(ByVal value As String)
            FMerk = value
        End Set
    End Property

    Public Property PMuatan() As Integer
        Get
            Return FMuatan
        End Get
        Set(ByVal value As Integer)
            FMuatan = value
        End Set
    End Property

    Public Property PHarga() As Integer
        Get
            Return FHarga
        End Get
        Set(ByVal value As Integer)
            FHarga = value
        End Set
    End Property
    Public Function cari() As Boolean
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "SELECT * FROM kendaraan WHERE no_plat=?"
        xmycmd = New OdbcCommand(Query, MyCnn)
        xmycmd.Parameters.AddWithValue("no_plat", FNoPlat)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            xmyread.Read()
            FNmKend = xmyread.Item("nm_kendaraan").ToString
            FJnsKend = xmyread.Item("jenis_kendaraan").ToString
            FMerk = xmyread.Item("merk").ToString
            FMuatan = xmyread.Item("muatan").ToString
            FNoPlat = xmyread.Item("no_plat").ToString
            FHarga = xmyread.Item("harga").ToString
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
        strSQL = "INSERT INTO kendaraan (no_plat, nm_kendaraan, jenis_kendaraan, merk, muatan, harga)values (?,?,?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_plat", FNoPlat)
        mycmd.Parameters.AddWithValue("nm_kendaraan", FNmKend)
        mycmd.Parameters.AddWithValue("jenis_kendaraan", FJnsKend)
        mycmd.Parameters.AddWithValue("merk", FMerk)
        mycmd.Parameters.AddWithValue("muatan", FMuatan)
        mycmd.Parameters.AddWithValue("harga", FHarga)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function

    Public Function ubah() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim X As Integer

        sql = "UPDATE kendaraan SET nm_kendaraan=?, jenis_kendaraan=?, merk=?, muatan=?, harga=? WHERE no_plat=?"

        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("nm_kendaraan", FNmKend)
        xmycmd.Parameters.AddWithValue("jenis_kendaraan", FJnsKend)
        xmycmd.Parameters.AddWithValue("merk", FMerk)
        xmycmd.Parameters.AddWithValue("muatan", FMuatan)
        xmycmd.Parameters.AddWithValue("harga", FHarga)
        xmycmd.Parameters.AddWithValue("no_plat", FNoPlat)
        xmycmd.Prepare()
        X = xmycmd.ExecuteNonQuery()

        xmycmd.Dispose()
        Return X
    End Function

    Public Function hapus() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim x As Integer
        sql = "DELETE FROM kendaraan WHERE no_plat=?"
        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("no_plat", FNoPlat)
        xmycmd.Prepare()
        x = xmycmd.ExecuteNonQuery()
        xmycmd.Dispose()
        Return x
    End Function

    Public Function tampildata(ByVal xdata As String) As List(Of clskendaraan)
        Dim Q As String
        Dim xmycmd As OdbcCommand
        Dim xmyread As OdbcDataReader
        Dim tmpbaca As New List(Of clskendaraan)

        Q = "Select * FROM kendaraan WHERE nm_kendaraan like '%" & xdata & "%'"
        xmycmd = New OdbcCommand(Q, MyCnn)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            While xmyread.Read
                Dim objtemp As New clskendaraan
                objtemp.FNoPlat = xmyread.Item("no_plat")
                objtemp.FNmKend = xmyread.Item("nm_kendaraan")
                objtemp.FJnsKend = xmyread.Item("jenis_kendaraan")
                objtemp.FMerk = xmyread.Item("merk")
                objtemp.FMuatan = xmyread.Item("muatan")
                objtemp.FHarga = xmyread.Item("harga")
                tmpbaca.Add(objtemp)
            End While
        End If
        xmyread.Close()
        Return tmpbaca
    End Function
End Class
