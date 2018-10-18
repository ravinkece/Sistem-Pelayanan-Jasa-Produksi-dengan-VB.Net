Imports System.Data.Odbc
Public Class clsdetil_pp

    Private FNo_PP As String
    Private FKd_Sample As String
    Private FJml_Pesan As Integer
    Private FJml_Hrg As Integer
    Public Property PNo_PP() As String
        Get
            Return FNo_PP
        End Get
        Set(ByVal value As String)
            FNo_PP = value
        End Set
    End Property

    Public Property PKd_Sample() As String
        Get
            Return FKd_Sample
        End Get
        Set(ByVal value As String)
            FKd_Sample = value
        End Set
    End Property

    Public Property PJml_Pesan() As Integer
        Get
            Return FJml_Pesan
        End Get
        Set(ByVal value As Integer)
            FJml_Pesan = value
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
    Public Function simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO detil_pp (no_pp, kd_sample, jml_pesan, jml_harga) values (?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_pp", FNo_PP)
        mycmd.Parameters.AddWithValue("kd_sample", FKd_Sample)
        mycmd.Parameters.AddWithValue("jml_pesan", FJml_Pesan)
        mycmd.Parameters.AddWithValue("jml_harga", FJml_Hrg)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
End Class
