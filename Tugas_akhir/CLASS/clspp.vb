Imports System.Data.Odbc
Public Class clspp

    Private FNo_PP As String
    Private FTgl_PP As Date
    Private FKd_Pengajuan As String
    Public Property PNo_PP() As String
        Get
            Return FNo_PP
        End Get
        Set(ByVal value As String)
            FNo_PP = value
        End Set
    End Property

    Public Property PTgl_PP() As Date
        Get
            Return FTgl_PP
        End Get
        Set(ByVal value As Date)
            FTgl_PP = value
        End Set
    End Property

    Public Property PKd_Pengajuan() As String
        Get
            Return FKd_Pengajuan
        End Get
        Set(ByVal value As String)
            FKd_Pengajuan = value
        End Set
    End Property
    Public Function Autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM pp ORDER BY no_pp desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("no_pp"), 3)) + 1
            Autonilai = "PP" & Right("00000", 5 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "PP00001"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function Simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO pp (no_pp, tgl_pp, kd_pengajuan)values (?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("kd_pp", FNo_PP)
        mycmd.Parameters.AddWithValue("tgl_pp", FTgl_PP)
        mycmd.Parameters.AddWithValue("kd_pengajuan", FKd_Pengajuan)
        MyCnn.Open()
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function

    Public Function Tampil(ByVal xdata As String) As List(Of clspp)
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "select pengajuan.kd_pengajuan, pengajuan.tgl_pengajuan, customer.nm_customer from pengajuan inner join customer on pengajuan.kd_customer = customer.kd_customer where customer.nm_customer like '%" & xdata & "%'"
        xmycmd = New OdbcCommand(Query, MyCnn)
        Try
            xmyread = xmycmd.ExecuteReader
            BukaConn()
            frmpopupPP.lvpp.Items.Clear()
            While xmyread.Read
                With frmpopupPP.lvpp.Items.Add(xmyread("kd_pengajuan"))
                    .subitems.add(xmyread("tgl_pengajuan"))
                    .subitems.add(xmyread("nm_customer"))
                End With
            End While
        Finally
        End Try
    End Function

    Public Function Tampillbb(ByVal xdata As String) As List(Of clspp)
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "select pp.no_pp, pp.tgl_pp, customer.nm_customer from ((pp inner join pengajuan on pp.kd_pengajuan = pengajuan.kd_pengajuan)inner join customer on pengajuan.kd_customer = customer.kd_customer) where pp.no_pp not in (select no_pp from lbb) and customer.nm_customer like '%" & xdata & "%'"
        xmycmd = New OdbcCommand(Query, MyCnn)
        Try
            xmyread = xmycmd.ExecuteReader
            BukaConn()
            frmpopuplbb.lvlbb.Items.Clear()
            While xmyread.Read
                With frmpopuplbb.lvlbb.Items.Add(xmyread("no_pp"))
                    .subitems.add(xmyread("tgl_pp"))
                    .subitems.add(xmyread("nm_customer"))
                End With
            End While
        Finally
        End Try
    End Function

    Public Function TampilFaktur(ByVal xdata As String) As List(Of clspp)
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "select pp.no_pp, pp.tgl_pp, customer.nm_customer from ((pp inner join pengajuan on pp.kd_pengajuan = pengajuan.kd_pengajuan)inner join customer on pengajuan.kd_customer = customer.kd_customer) where pp.no_pp not in(select no_pp from faktur) and customer.nm_customer like '%" & xdata & "%'"

        xmycmd = New OdbcCommand(Query, MyCnn)
        Try
            xmyread = xmycmd.ExecuteReader
            BukaConn()
            frmpopupfaktur.lvpp.Items.Clear()
            While xmyread.Read
                With frmpopupfaktur.lvpp.Items.Add(xmyread("no_pp"))
                    .subitems.add(xmyread("tgl_pp"))
                    .subitems.add(xmyread("nm_customer"))
                End With
            End While
        Finally
        End Try
    End Function
    Public Function Tampilbphd(ByVal xdata As String) As List(Of clspp)
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "select pp.no_pp, pp.tgl_pp, customer.nm_customer from ((pp inner join pengajuan on pp.kd_pengajuan = pengajuan.kd_pengajuan)inner join customer on pengajuan.kd_customer = customer.kd_customer) where customer.nm_customer like '%" & xdata & "%' and pp.no_pp not in ( select no_pp from bphd)"
        xmycmd = New OdbcCommand(Query, MyCnn)
        Try
            xmyread = xmycmd.ExecuteReader
            BukaConn()
            frmpopupbphd.lvlbb.Items.Clear()
            While xmyread.Read
                With frmpopupbphd.lvlbb.Items.Add(xmyread("no_pp"))
                    .subitems.add(xmyread("tgl_pp"))
                    .subitems.add(xmyread("nm_customer"))
                End With
            End While
        Finally
        End Try
    End Function
End Class
