Imports System.Data.Odbc
Public Class clsdetil_retur

    Private FNo_Retur As String
    Private FKd_Produk As String
    Private FJml_Brgretur As Integer
    Public Property PNo_Retur() As String
        Get
            Return FNo_Retur
        End Get
        Set(ByVal value As String)
            FNo_Retur = value
        End Set
    End Property

    Public Property PKd_Produk() As String
        Get
            Return FKd_Produk
        End Get
        Set(ByVal value As String)
            FKd_Produk = value
        End Set
    End Property

    Public Property PJml_Brgretur() As Integer
        Get
            Return FJml_Brgretur
        End Get
        Set(ByVal value As Integer)
            FJml_Brgretur = value
        End Set
    End Property
    Public Function simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO detil_retur (no_retur, kd_produk, jml_brgretur)values (?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_retur", FNo_Retur)
        mycmd.Parameters.AddWithValue("kd_produk", FKd_Produk)
        mycmd.Parameters.AddWithValue("jml_brgretur", FJml_Brgretur)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
End Class
