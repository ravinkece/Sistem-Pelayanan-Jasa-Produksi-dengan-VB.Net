Imports System.Data.Odbc
Public Class clsdetil_jpp
    Private FNo_Jpp As String
    Private FNo_Spk As String
    Private FKet As String

    Public Property PNo_Jpp() As String
        Get
            Return FNo_Jpp
        End Get
        Set(ByVal value As String)
            FNo_Jpp = value
        End Set
    End Property

    Public Property PNo_Spk() As String
        Get
            Return FNo_Spk
        End Get
        Set(ByVal value As String)
            FNo_Spk = value
        End Set
    End Property

    Public Property PKet() As String
        Get
            Return FKet
        End Get
        Set(ByVal value As String)
            FKet = value
        End Set
    End Property
    Public Function simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO detil_jpp (no_jpp, no_spk, ket)values (?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_jpp", FNo_Jpp)
        mycmd.Parameters.AddWithValue("no_spk", FNo_Spk)
        mycmd.Parameters.AddWithValue("ket", FKet)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
End Class
