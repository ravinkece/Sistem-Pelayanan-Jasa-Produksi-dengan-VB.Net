Imports System.Data.Odbc
Public Class clsdetil_pembelian

    Private FNo_Pembelian As String
    Private FKd_Bahan As String
    Private FJml_Hrg As Integer
    Private FQty As Integer
    Public Property PNo_Pembelian() As String
        Get
            Return FNo_Pembelian
        End Get
        Set(ByVal value As String)
            FNo_Pembelian = value
        End Set
    End Property

    Public Property PKd_Bahan() As String
        Get
            Return FKd_Bahan
        End Get
        Set(ByVal value As String)
            FKd_Bahan = value
        End Set
    End Property

    Public Property PJml_Hrg() As Integer
        Get
            Return FJml_Hrg
        End Get
        Set(ByVal value As Integer)
            FJml_Hrg = value
        End Set
    End Property

    Public Property PQty() As Integer
        Get
            Return FQty
        End Get
        Set(ByVal value As Integer)
            FQty = value
        End Set
    End Property
    Public Function simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO detil_pembelian (no_pembelian, kd_bahan, jml_hrg, qty)values (?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_pembelian", FNo_Pembelian)
        mycmd.Parameters.AddWithValue("kd_bahan", FKd_Bahan)
        mycmd.Parameters.AddWithValue("jml_hrg", FJml_Hrg)
        mycmd.Parameters.AddWithValue("qty", FQty)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
End Class
