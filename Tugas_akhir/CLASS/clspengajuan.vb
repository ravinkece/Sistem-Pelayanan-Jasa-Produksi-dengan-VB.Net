Imports System.Data.Odbc
Public Class clspengajuan

    Private FKd_Pengajuan As String
    Private FTgl_Pengajuan As Date
    Private FKd_Staff As String
    Private FKd_Customer As String
    Public Property PKd_Pengajuan() As String
        Get
            Return FKd_Pengajuan
        End Get
        Set(ByVal value As String)
            FKd_Pengajuan = value
        End Set
    End Property

    Public Property PTgl_Pengajuan() As Date
        Get
            Return FTgl_Pengajuan
        End Get
        Set(ByVal value As Date)
            FTgl_Pengajuan = value
        End Set
    End Property

    Public Property PKd_Staff() As String
        Get
            Return FKd_Staff
        End Get
        Set(ByVal value As String)
            FKd_Staff = value
        End Set
    End Property

    Public Property PKd_Customer() As String
        Get
            Return FKd_Customer
        End Get
        Set(ByVal value As String)
            FKd_Customer = value
        End Set
    End Property
    Public Function Autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM pengajuan ORDER BY kd_pengajuan desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("kd_pengajuan"), 3)) + 1
            Autonilai = "KP" & Right("00000", 5 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "KP00001"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function Simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO pengajuan (kd_pengajuan, tgl_pengajuan, kd_staff, kd_customer)values (?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("kd_pengajuan", FKd_Pengajuan)
        mycmd.Parameters.AddWithValue("tgl_pengajuan", FTgl_Pengajuan)
        mycmd.Parameters.AddWithValue("kd_staff", FKd_Staff)
        mycmd.Parameters.AddWithValue("kd_customer", FKd_Customer)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
End Class
