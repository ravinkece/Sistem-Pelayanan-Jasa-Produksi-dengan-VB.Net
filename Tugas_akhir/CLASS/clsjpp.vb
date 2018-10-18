Imports System.Data.Odbc
Public Class clsjpp

    Private FNo_JPP As String
    Private FTgl_JPP As Date

    Public Property PNo_JPP() As String
        Get
            Return FNo_JPP
        End Get
        Set(ByVal value As String)
            FNo_JPP = value
        End Set
    End Property

    Public Property PTgl_JPP() As Date
        Get
            Return FTgl_JPP
        End Get
        Set(ByVal value As Date)
            FTgl_JPP = value
        End Set
    End Property
    Public Function Autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM jpp ORDER BY no_jpp desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("no_jpp"), 4)) + 1
            Autonilai = "JPP" & Right("00000", 5 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "JPP00001"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function Simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO jpp (no_jpp, tgl_jpp)values (?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_jpp", FNo_JPP)
        mycmd.Parameters.AddWithValue("tgl_jpp", FTgl_JPP)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
End Class
