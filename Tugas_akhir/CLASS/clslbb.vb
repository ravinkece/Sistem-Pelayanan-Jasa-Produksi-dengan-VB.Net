Imports System.Data.Odbc
Public Class clslbb

    Private FNo_LBB As String
    Private FTgl_LBB As Date
    Private FNo_PP As String
    Public Property PNo_LBB() As String
        Get
            Return FNo_LBB
        End Get
        Set(ByVal value As String)
            FNo_LBB = value
        End Set
    End Property

    Public Property PTgl_LBB() As Date
        Get
            Return FTgl_LBB
        End Get
        Set(ByVal value As Date)
            FTgl_LBB = value
        End Set
    End Property

    Public Property PNo_PP() As String
        Get
            Return FNo_PP
        End Get
        Set(ByVal value As String)
            FNo_PP = value
        End Set
    End Property
    Public Function Autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM lbb ORDER BY no_lbb desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("no_lbb"), 4)) + 1
            Autonilai = "LBB" & Right("00000", 5 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "LBB00001"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function Simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO lbb (no_lbb, tgl_lbb, no_pp)values (?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_lbb", FNo_LBB)
        mycmd.Parameters.AddWithValue("tgl_lbb", FTgl_LBB)
        mycmd.Parameters.AddWithValue("no_pp", FNo_PP)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
End Class
