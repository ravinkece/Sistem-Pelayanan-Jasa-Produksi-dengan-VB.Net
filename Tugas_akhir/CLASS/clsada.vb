Imports System.Data.Odbc
Public Class clsada

    Private FNo_Faktur As String
    Private FNo_JPP As String
    Private FKet As String
    Public Property PNo_Faktur() As String
        Get
            Return FNo_Faktur
        End Get
        Set(ByVal value As String)
            FNo_Faktur = value
        End Set
    End Property

    Public Property PNo_JPP() As String
        Get
            Return FNo_JPP
        End Get
        Set(ByVal value As String)
            FNo_JPP = value
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
        strSQL = "INSERT INTO ada (no_faktur, no_jpp, ket)values (?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_faktur", FNo_Faktur)
        mycmd.Parameters.AddWithValue("no_jpp", FNo_JPP)
        mycmd.Parameters.AddWithValue("ket", FKet)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
End Class
