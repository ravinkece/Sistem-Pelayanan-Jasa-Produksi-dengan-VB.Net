Imports System.Data.Odbc
Public Class clsfaktur

    Private FNo_Faktur As String
    Private FTgl_faktur As Date
    Private FNo_PP As String
    Private FTgl_Kirim As Date
    Public Property PNo_Faktur() As String
        Get
            Return FNo_Faktur
        End Get
        Set(ByVal value As String)
            FNo_Faktur = value
        End Set
    End Property

    Public Property PTgl_Faktur() As Date
        Get
            Return FTgl_faktur
        End Get
        Set(ByVal value As Date)
            FTgl_faktur = value
        End Set
    End Property

    Public Property PNo_PP() As String
        Get
            Return FNo_PP
        End Get
        Set(ByVal value As String)
            FNo_PP = value
        End Set
    End Property

    Public Property PTgl_Kirim() As Date
        Get
            Return FTgl_Kirim
        End Get
        Set(ByVal value As Date)
            FTgl_Kirim = value
        End Set
    End Property
    Public Function autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM faktur ORDER BY no_faktur desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("no_faktur"), 3)) + 1
            Autonilai = "FK" & Right("00000", 5 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "FK00001"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO faktur (no_faktur, tgl_faktur, no_pp,tgl_kirim)values (?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_faktur", FNo_Faktur)
        mycmd.Parameters.AddWithValue("tgl_faktur", FTgl_faktur)
        mycmd.Parameters.AddWithValue("no_pp", FNo_PP)
        mycmd.Parameters.AddWithValue("tgl_kirim", FTgl_Kirim)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function

    Public Function tampildata(ByVal xdata As String) As List(Of clsfaktur)
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "select faktur.no_faktur, faktur.tgl_faktur, customer.nm_customer from (((faktur inner join pp on faktur.no_pp = pp.no_pp) inner join pengajuan on pp.kd_pengajuan = pengajuan.kd_pengajuan)inner join customer on pengajuan.kd_customer = customer.kd_customer) where faktur.no_faktur not in(select no_faktur from retur) and customer.nm_customer like '%" & xdata & "%'"
        xmycmd = New OdbcCommand(Query, MyCnn)
        Try
            xmyread = xmycmd.ExecuteReader
            BukaConn()
            frmpopupretur.lvretur.Items.Clear()
            While xmyread.Read
                With frmpopupretur.lvretur.Items.Add(xmyread("no_faktur"))
                    .subitems.add(xmyread("tgl_faktur"))
                    .subitems.add(xmyread("nm_customer"))
                End With
            End While
        Finally
        End Try
    End Function
    Public Function tampildatafaktur() As List(Of clsfaktur)
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "select faktur.no_faktur, faktur.tgl_faktur from faktur"
        xmycmd = New OdbcCommand(Query, MyCnn)
        Try
            xmyread = xmycmd.ExecuteReader
            BukaConn()
            frmpopupfakturjpp.lvpp.Items.Clear()
            While xmyread.Read
                With frmpopupfakturjpp.lvpp.Items.Add(xmyread("no_faktur"))
                    .subitems.add(xmyread("tgl_faktur"))
                End With
            End While
        Finally
        End Try
    End Function

   
End Class
