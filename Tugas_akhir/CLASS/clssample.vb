Imports System.Data.Odbc
Public Class clssample

    Private FKdSample As String
    Private FNmSample As String
    Private FHrgSample As Integer
    Private FGambar As String

    Public Property PKdSample() As String
        Get
            Return FKdSample
        End Get
        Set(ByVal value As String)
            FKdSample = value
        End Set
    End Property

    Public Property PNmSample() As String
        Get
            Return FNmSample
        End Get
        Set(ByVal value As String)
            FNmSample = value
        End Set
    End Property
    Public Property PHrgSample() As Integer
        Get
            Return FHrgSample
        End Get
        Set(ByVal value As Integer)
            FHrgSample = value
        End Set
    End Property

    Public Property PGambar() As String
        Get
            Return FGambar
        End Get
        Set(ByVal value As String)
            FGambar = value
        End Set
    End Property
    Public Function autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM sample ORDER BY kd_sample desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("kd_sample"), 4)) + 1
            Autonilai = "SMP" & Right("00000", 5 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "SMP00001"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function cari() As Boolean
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "SELECT * FROM sample WHERE kd_sample=?"
        xmycmd = New OdbcCommand(Query, MyCnn)
        xmycmd.Parameters.AddWithValue("kd_sample", FKdSample)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            xmyread.Read()
            FNmSample = xmyread.Item("nm_sample").ToString
            FGambar = xmyread.Item("gambar").ToString
            FHrgSample = xmyread.Item("harga").ToString
            FKdSample = xmyread.Item("kd_sample").ToString
            xmyread.Close()
            Return True
        Else
            xmyread.Close()
            Return False
        End If
    End Function

    Public Function tampildata(ByVal xdata As String) As List(Of clssample)
        Dim Q As String
        Dim xmycmd As OdbcCommand
        Dim xmyread As OdbcDataReader
        Dim tmpbaca As New List(Of clssample)

        Q = "Select * from sample WHERE nm_sample like '%" & xdata & "%'"
        xmycmd = New OdbcCommand(Q, MyCnn)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            While xmyread.Read
                Dim objtemp As New clssample
                objtemp.FKdSample = xmyread.Item("kd_sample")
                objtemp.FNmSample = xmyread.Item("nm_sample")
                objtemp.FGambar = xmyread.Item("gambar")
                objtemp.FHrgSample = xmyread.Item("harga")
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
        strSQL = "INSERT INTO sample (kd_sample, nm_sample, gambar, harga)values (?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("kd_sample", FKdSample)
        mycmd.Parameters.AddWithValue("nm_sample", FNmSample)
        mycmd.Parameters.AddWithValue("gambar", FGambar)
        mycmd.Parameters.AddWithValue("harga", FHrgSample)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function

    Public Function ubah() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim X As Integer

        sql = "UPDATE sample SET nm_sample=?, gambar=?, harga=? WHERE kd_sample=?"

        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("nm_sample", FNmSample)
        xmycmd.Parameters.AddWithValue("gambar", FGambar)
        xmycmd.Parameters.AddWithValue("harga", FHrgSample)
        xmycmd.Parameters.AddWithValue("kd_sample", FKdSample)
        xmycmd.Prepare()
        X = xmycmd.ExecuteNonQuery()

        xmycmd.Dispose()
        Return X
    End Function

    Public Function hapus() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim x As Integer
        sql = "DELETE FROM sample WHERE kd_sample=?"
        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("kd_sample", FKdSample)
        xmycmd.Prepare()
        x = xmycmd.ExecuteNonQuery()
        xmycmd.Dispose()
        Return x
    End Function

    Public Function Tampilproduk(ByVal xdata As String) As List(Of clssample)
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "select sample.kd_sample, sample.nm_sample, sample.harga from(sample)where sample.kd_sample not in (select kd_sample from produk) and sample.kd_sample like '%" & xdata & "%'"
        xmycmd = New OdbcCommand(Query, MyCnn)
        Try
            xmyread = xmycmd.ExecuteReader
            BukaConn()
            frmpopupproduk.lvproduk.Items.Clear()
            While xmyread.Read
                With frmpopupproduk.lvproduk.Items.Add(xmyread("kd_sample"))
                    .subitems.add(xmyread("nm_sample"))
                    .subitems.add(xmyread("harga"))
                End With
            End While
        Finally
        End Try
    End Function

    Public Function Tampilsampleaju(ByVal xdata As String) As List(Of clssample)
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "select sample.kd_sample, sample.nm_sample, sample.harga from(sample, pengajuan) where sample.kd_sample not in (SELECT kd_sample from detil_pengajuan) and pengajuan.kd_customer like '%" & xdata & "%'"
        xmycmd = New OdbcCommand(Query, MyCnn)
        Try
            xmyread = xmycmd.ExecuteReader
            BukaConn()
            frmpopupsampleajuan.lvsample.Items.Clear()
            While xmyread.Read
                With frmpopupsampleajuan.lvsample.Items.Add(xmyread("kd_sample"))
                    .subitems.add(xmyread("nm_sample"))
                    .subitems.add(xmyread("harga"))
                End With
            End While
        Finally
        End Try
    End Function
End Class
