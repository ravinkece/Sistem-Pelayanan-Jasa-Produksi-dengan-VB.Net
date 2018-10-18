Imports System.Data.Odbc
Public Class clskwitansi

    Private FNo_Kwitanis As String
    Private FTgl_Kwitansi As Date
    Private FNo_SPK As String
    Public Property PNo_Kwitansi() As String
        Get
            Return FNo_Kwitanis
        End Get
        Set(ByVal value As String)
            FNo_Kwitanis = value
        End Set
    End Property

    Public Property PTgl_Kwitansi() As Date
        Get
            Return FTgl_Kwitansi
        End Get
        Set(ByVal value As Date)
            FTgl_Kwitansi = value
        End Set
    End Property

    Public Property PNo_SPK() As String
        Get
            Return FNo_SPK
        End Get
        Set(ByVal value As String)
            FNo_SPK = value
        End Set
    End Property
    Public Function Autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM kwitansi ORDER BY no_kwitansi desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("no_kwitansi"), 4)) + 1
            Autonilai = "KWT" & Right("00000", 5 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "KWT00001"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function Simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO kwitansi (no_kwitansi, tgl_kwitansi, no_spk)values (?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("no_kwitansi", FNo_Kwitanis)
        mycmd.Parameters.AddWithValue("tgl_kwitansi", FTgl_Kwitansi)
        mycmd.Parameters.AddWithValue("no_spk", FNo_SPK)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
End Class
