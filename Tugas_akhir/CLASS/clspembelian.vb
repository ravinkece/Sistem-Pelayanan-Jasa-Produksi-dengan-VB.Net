Imports System.Data.Odbc
Public Class clspembelian

    Private FNo_Pembelian As String
    Private FTgl_Pembelian As Date
    Private FKd_Staff As String
    Private FKd_Supplier As String
    Public Property PNo_Pembelian() As String
        Get
            Return FNo_Pembelian
        End Get
        Set(ByVal value As String)
            FNo_Pembelian = value
        End Set
    End Property

    Public Property PTgl_Pembelian() As Date
        Get
            Return FTgl_Pembelian
        End Get
        Set(ByVal value As Date)
            FTgl_Pembelian = value
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

    Public Property PKd_Supplier() As String
        Get
            Return FKd_Supplier
        End Get
        Set(ByVal value As String)
            FKd_Supplier = value
        End Set
    End Property
    Public Function Autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM pembelian ORDER BY no_pembelian desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("no_pembelian"), 3)) + 1
            Autonilai = "NP" & Right("00000", 5 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "NP00001"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function Simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO pembelian (no_pembelian, tgl_pembelian, kd_staff, kd_supplier)values (?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_pembelian", FNo_Pembelian)
        mycmd.Parameters.AddWithValue("tgl_pembelian", FTgl_Pembelian)
        mycmd.Parameters.AddWithValue("kd_staff", FKd_Staff)
        mycmd.Parameters.AddWithValue("kd_supplier", FKd_Supplier)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
End Class
