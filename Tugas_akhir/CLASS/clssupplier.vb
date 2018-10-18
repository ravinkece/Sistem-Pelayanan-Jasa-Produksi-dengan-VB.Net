Imports System.Data.Odbc
Public Class clssupplier

    Private FKd_Supplier As String
    Private FNm_Supplier As String
    Private FAlamat As String
    Private FTelp As String
    Private FEmail As String
    Public Property PKd_Supplier() As String
        Get
            Return FKd_Supplier
        End Get
        Set(ByVal value As String)
            FKd_Supplier = value
        End Set
    End Property

    Public Property PNm_Supplier() As String
        Get
            Return FNm_Supplier
        End Get
        Set(ByVal value As String)
            FNm_Supplier = value
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
    Public Function Autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM supplier ORDER BY kd_supplier desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("kd_supplier"), 4)) + 1
            Autonilai = "SUP" & Right("00", 2 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "SUP01"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function Tampildata(ByVal xdata As String) As List(Of clssupplier)
        Dim Q As String
        Dim xmycmd As OdbcCommand
        Dim xmyread As OdbcDataReader
        Dim tmpbaca As New List(Of clssupplier)

        Q = "Select * FROM supplier WHERE nm_supplier like '%" & xdata & "%'"
        xmycmd = New OdbcCommand(Q, MyCnn)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            While xmyread.Read
                Dim objtemp As New clssupplier
                objtemp.FKd_Supplier = xmyread.Item("kd_supplier")
                objtemp.FNm_Supplier = xmyread.Item("nm_supplier")
                objtemp.FAlamat = xmyread.Item("alamat")
                objtemp.FTelp = xmyread.Item("telp")
                objtemp.FEmail = xmyread.Item("email")
                tmpbaca.Add(objtemp)
            End While
        End If
        xmyread.Close()
        Return tmpbaca
    End Function

    Public Function Cari() As Boolean
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "SELECT * FROM supplier WHERE nm_supplier=?"
        xmycmd = New OdbcCommand(Query, MyCnn)
        xmycmd.Parameters.AddWithValue("kd_supplier", FKd_Supplier)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            xmyread.Read()
            FNm_Supplier = xmyread.Item("nm_supplier").ToString
            FAlamat = xmyread.Item("alamat").ToString
            FTelp = xmyread.Item("telp").ToString
            FEmail = xmyread.Item("email").ToString
            FKd_Supplier = xmyread.Item("kd_supplier").ToString
            xmyread.Close()
            Return True
        Else
            xmyread.Close()
            Return False
        End If
    End Function

    Public Function Simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO supplier (kd_supplier, nm_supplier, alamat, telp, email)values (?,?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("kd_supplier", FKd_Supplier)
        mycmd.Parameters.AddWithValue("nm_supplier", FNm_Supplier)
        mycmd.Parameters.AddWithValue("alamat", FAlamat)
        mycmd.Parameters.AddWithValue("telp", FTelp)
        mycmd.Parameters.AddWithValue("email", FEmail)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function

    Public Function Ubah() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim X As Integer

        sql = "UPDATE bahan SET nm_supplier=?, alamat=?, telp=?, email=?  WHERE kd_supplier=?"

        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("nm_supplier", FNm_Supplier)
        xmycmd.Parameters.AddWithValue("alamat", FAlamat)
        xmycmd.Parameters.AddWithValue("telp", FTelp)
        xmycmd.Parameters.AddWithValue("email", FEmail)
        xmycmd.Parameters.AddWithValue("kd_supplier", FKd_Supplier)
        xmycmd.Prepare()
        X = xmycmd.ExecuteNonQuery()

        xmycmd.Dispose()
        Return X
    End Function

    Public Function Hapus() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim x As Integer
        sql = "DELETE FROM supplier WHERE kd_supplier=?"
        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("kd_supplier", FKd_Supplier)
        xmycmd.Prepare()
        x = xmycmd.ExecuteNonQuery()
        xmycmd.Dispose()
        Return x
    End Function
End Class
