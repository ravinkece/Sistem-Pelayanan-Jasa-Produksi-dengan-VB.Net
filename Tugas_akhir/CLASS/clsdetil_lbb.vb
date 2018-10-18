Imports System.Data.Odbc
Public Class clsdetil_lbb

    Private FKdBahan As String
    Private FNo_LBB As String
    Private FQty As Integer
    Private FJml_Harga As Integer
    Public Property PNo_LBB() As String
        Get
            Return FNo_LBB
        End Get
        Set(ByVal value As String)
            FNo_LBB = value
        End Set
    End Property

    Public Property PKd_Bahan() As String
        Get
            Return FKdBahan
        End Get
        Set(ByVal value As String)
            FKdBahan = value
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

    Public Property PJml_Harga() As Integer
        Get
            Return FJml_Harga
        End Get
        Set(ByVal value As Integer)
            FJml_Harga = value
        End Set
    End Property
    Public Function simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO detil_lbb (no_lbb, kd_bahan, qty, jml_harga)values (?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_lbb", FNo_LBB)
        mycmd.Parameters.AddWithValue("kd_bahan", FKdBahan)
        mycmd.Parameters.AddWithValue("qty", FQty)
        mycmd.Parameters.AddWithValue("jml_harga", FJml_Harga)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
End Class
