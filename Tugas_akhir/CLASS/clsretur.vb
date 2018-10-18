Imports System.Data.Odbc
Public Class clsretur

    Private FNo_Retur As String
    Private FTgl_Retur As Date
    Private FKet As String
    Private FNo_Faktur As String
    Public Property PNo_Retur() As String
        Get
            Return FNo_Retur
        End Get
        Set(ByVal value As String)
            FNo_Retur = value
        End Set
    End Property

    Public Property PTgl_Retur() As Date
        Get
            Return FTgl_Retur
        End Get
        Set(ByVal value As Date)
            FTgl_Retur = value
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

    Public Property PNo_Faktur() As String
        Get
            Return FNo_Faktur
        End Get
        Set(ByVal value As String)
            FNo_Faktur = value
        End Set
    End Property
    Public Function Autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM retur ORDER BY no_retur desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("no_retur"), 4)) + 1
            Autonilai = "RTR" & Right("00000", 5 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "RTR00001"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function Simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO retur (no_retur, tgl_retur, ket, no_faktur)values (?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_retur", FNo_Retur)
        mycmd.Parameters.AddWithValue("tgl_retur", FTgl_Retur)
        mycmd.Parameters.AddWithValue("ket", FKet)
        mycmd.Parameters.AddWithValue("no_faktur", FNo_Faktur)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
End Class
