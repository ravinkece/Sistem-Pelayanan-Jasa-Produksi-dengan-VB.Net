Imports System.Data.Odbc
Public Class clsbphd

    Private FNo_BPHD As String
    Private FTgl_BPHD As Date
    Private FNo_LBB As String
    Private FNo_PP As String
    Public Property PNo_BPHD() As String
        Get
            Return FNo_BPHD
        End Get
        Set(ByVal value As String)
            FNo_BPHD = value
        End Set
    End Property

    Public Property PTgl_BPHD() As Date
        Get
            Return FTgl_BPHD
        End Get
        Set(ByVal value As Date)
            FTgl_BPHD = value
        End Set
    End Property

    Public Property PNo_LBB() As String
        Get
            Return FNo_LBB
        End Get
        Set(ByVal value As String)
            FNo_LBB = value
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
    Public Function autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM bphd ORDER BY no_bphd desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("no_bphd"), 4)) + 1
            Autonilai = "BPH" & Right("00000", 5 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "BPH00001"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO bphd (no_bphd, tgl_bphd, no_lbb, no_pp)values (?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_bphd", FNo_BPHD)
        mycmd.Parameters.AddWithValue("tgl_bphd", FTgl_BPHD)
        mycmd.Parameters.AddWithValue("no_lbb", FNo_LBB)
        mycmd.Parameters.AddWithValue("no_pp", FNo_PP)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
End Class
