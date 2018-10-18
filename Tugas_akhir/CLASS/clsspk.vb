Imports System.Data.Odbc
Public Class clsspk

    Private FNo_SPK As String
    Private FTgl_SPK As Date
    Private FKd_Kurir As String
    Private FNo_Plat As String
    Private FKd_Staff As String
    Private FNo_Faktur As String
    Public Property PNo_SPK() As String
        Get
            Return FNo_SPK
        End Get
        Set(ByVal value As String)
            FNo_SPK = value
        End Set
    End Property

    Public Property PTgl_SPK() As Date
        Get
            Return FTgl_SPK
        End Get
        Set(ByVal value As Date)
            FTgl_SPK = value
        End Set
    End Property

    Public Property PKd_Kurir() As String
        Get
            Return FKd_Kurir
        End Get
        Set(ByVal value As String)
            FKd_Kurir = value
        End Set
    End Property

    Public Property PNo_Plat() As String
        Get
            Return FNo_Plat
        End Get
        Set(ByVal value As String)
            FNo_Plat = value
        End Set
    End Property

    Public Property PKd_Staff() As String
        Get
            Return FKd_Staff
        End Get
        Set(ByVal value As String)
            FKd_Staff = value
        End Set
    End Property

    Public Property PNo_Faktur() As String
        Get
            Return FNo_Faktur
        End Get
        Set(ByVal value As String)
            FNo_Faktur = value
        End Set
    End Property
    Public Function Autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM spk ORDER BY no_spk desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("no_spk"), 4)) + 1
            Autonilai = "SPK" & Right("00000", 5 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "SPK00001"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function Simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO spk (no_spk, tgl_spk, kd_kurir, no_plat, no_faktur)values (?,?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_spk", FNo_SPK)
        mycmd.Parameters.AddWithValue("tgl_spk", FTgl_SPK)
        mycmd.Parameters.AddWithValue("kd_kurir", FKd_Kurir)
        mycmd.Parameters.AddWithValue("no_plat", FNo_Plat)
        'mycmd.Parameters.AddWithValue("kd_staff", FKd_Staff)
        mycmd.Parameters.AddWithValue("no_faktur", FNo_Faktur)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
    Public Function Tampil(ByVal xdata As String) As List(Of clsspk)
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "select pp.no_pp, pp.tgl_pp, customer.nm_customer from ((pp inner join pengajuan on pp.kd_pengajuan = pengajuan.kd_pengajuan)inner join customer on pengajuan.kd_customer = customer.kd_customer) where pp.no_pp not in(select no_pp from faktur) and customer.nm_customer like '%" & xdata & "%'"

        xmycmd = New OdbcCommand(Query, MyCnn)
        Try
            xmyread = xmycmd.ExecuteReader
            BukaConn()
            frmpopupspk.lvpp.Items.Clear()
            While xmyread.Read
                With frmpopupspk.lvpp.Items.Add(xmyread("no_pp"))
                    .subitems.add(xmyread("tgl_pp"))
                    .subitems.add(xmyread("nm_customer"))
                End With
            End While
        Finally
        End Try
    End Function
    Public Function TampilKwt(ByVal xdata As String) As List(Of clsspk)
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "select spk.no_spk, spk.tgl_spk, kendaraan.nm_kendaraan, kendaraan.harga from kendaraan inner join spk on spk.no_plat = kendaraan.no_plat where spk.no_spk not in ( select no_spk from kwitansi) and kendaraan.nm_kendaraan like '%" & xdata & "%'"
        xmycmd = New OdbcCommand(Query, MyCnn)
        Try
            xmyread = xmycmd.ExecuteReader
            BukaConn()
            frmpopupkwt.lvkwt.Items.Clear()
            While xmyread.Read
                With frmpopupkwt.lvkwt.Items.Add(xmyread("no_spk"))
                    .subitems.add(xmyread("tgl_spk"))
                    .subitems.add(xmyread("nm_kendaraan"))
                    .subitems.add(xmyread("harga"))
                End With
            End While
        Finally
        End Try
    End Function
    Public Function Tampilspkjpp() As List(Of clsspk)
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "select spk.no_spk, spk.tgl_spk from spk"
        xmycmd = New OdbcCommand(Query, MyCnn)
        Try
            xmyread = xmycmd.ExecuteReader
            BukaConn()
            frmpopupspkjpp.lvspk.Items.Clear()
            While xmyread.Read
                With frmpopupspkjpp.lvspk.Items.Add(xmyread("no_spk"))
                    .subitems.add(xmyread("tgl_spk"))
                End With
            End While
        Finally
        End Try
    End Function
End Class
