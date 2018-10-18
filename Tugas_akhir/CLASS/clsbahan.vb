Imports System.Data.Odbc
Public Class clsbahan

    Private FKdBahan As String
    Private FNmBahan As String
    Private FJnsBahan As String
    Private FHrgBahan As Integer
    Private FSatuan As String
    Public Property PKdBahan() As String
        Get
            Return FKdBahan
        End Get
        Set(ByVal value As String)
            FKdBahan = value
        End Set
    End Property

    Public Property PNmBahan() As String
        Get
            Return FNmBahan
        End Get
        Set(ByVal value As String)
            FNmBahan = value
        End Set
    End Property

    Public Property PJnsBahan() As String
        Get
            Return FJnsBahan
        End Get
        Set(ByVal value As String)
            FJnsBahan = value
        End Set
    End Property

    Public Property PHrgBahan() As Integer
        Get
            Return FHrgBahan
        End Get
        Set(ByVal value As Integer)
            FHrgBahan = value
        End Set
    End Property
    Public Property PSatuan() As String
        Get
            Return FSatuan
        End Get
        Set(ByVal value As String)
            FSatuan = value
        End Set
    End Property
    Public Function autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM bahan ORDER BY kd_bahan desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("kd_bahan"), 4)) + 1
            Autonilai = "BHN" & Right("0000", 4 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "BHN0001"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function cari() As Boolean
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "SELECT * FROM bahan WHERE kd_bahan=?"
        xmycmd = New OdbcCommand(Query, MyCnn)
        xmycmd.Parameters.AddWithValue("kd_bahan", FKdBahan)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            xmyread.Read()
            FNmBahan = xmyread.Item("nm_bahan").ToString
            FJnsBahan = xmyread.Item("jns_bahan").ToString
            FHrgBahan = xmyread.Item("hrg_bahan").ToString
            FSatuan = xmyread.Item("satuan").ToString
            FKdBahan = xmyread.Item("kd_bahan").ToString
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
        strSQL = "INSERT INTO bahan (kd_bahan, nm_bahan, jns_bahan, hrg_bahan, satuan)values (?,?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("kd_bahan", FKdBahan)
        mycmd.Parameters.AddWithValue("nm_bahan", FNmBahan)
        mycmd.Parameters.AddWithValue("jns_bahan", FJnsBahan)
        mycmd.Parameters.AddWithValue("hrg_bahan", FHrgBahan)
        mycmd.Parameters.AddWithValue("satuan", FSatuan)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function

    Public Function ubah() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim X As Integer

        sql = "UPDATE bahan SET nm_bahan=?, jns_bahan=?, hrg_bahan=?, satuan=?  WHERE kd_bahan=?"

        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("nm_bahan", FNmBahan)
        xmycmd.Parameters.AddWithValue("jns_bahan", FJnsBahan)
        xmycmd.Parameters.AddWithValue("hrg_bahan", FHrgBahan)
        xmycmd.Parameters.AddWithValue("satuan", FSatuan)
        xmycmd.Parameters.AddWithValue("kd_bahan", FKdBahan)
        xmycmd.Prepare()
        X = xmycmd.ExecuteNonQuery()

        xmycmd.Dispose()
        Return X
    End Function

    Public Function hapus() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim x As Integer
        sql = "DELETE FROM bahan WHERE kd_bahan=?"
        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("kd_bahan", FKdBahan)
        xmycmd.Prepare()
        x = xmycmd.ExecuteNonQuery()
        xmycmd.Dispose()
        Return x
    End Function

    Public Function tampildata(ByVal xdata As String) As List(Of clsbahan)
        Dim Q As String
        Dim xmycmd As OdbcCommand
        Dim xmyread As OdbcDataReader
        Dim tmpbaca As New List(Of clsbahan)

        Q = "Select * FROM bahan WHERE nm_bahan like '%" & xdata & "%'"
        xmycmd = New OdbcCommand(Q, MyCnn)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            While xmyread.Read
                Dim objtemp As New clsbahan
                objtemp.FKdBahan = xmyread.Item("kd_bahan")
                objtemp.FNmBahan = xmyread.Item("nm_bahan")
                objtemp.FJnsBahan = xmyread.Item("jns_bahan")
                objtemp.FHrgBahan = xmyread.Item("hrg_bahan")
                objtemp.FSatuan = xmyread.Item("satuan")
                tmpbaca.Add(objtemp)
            End While
        End If
        xmyread.Close()
        Return tmpbaca
    End Function
End Class
