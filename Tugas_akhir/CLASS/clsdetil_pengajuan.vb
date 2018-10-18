Imports System.Data.Odbc
Public Class clsdetil_pengajuan

    Private FKd_Pengajuan As String
    Private FKd_Sample As String
    Private FKet As String
    Public Property PKd_Pengajuan() As String
        Get
            Return FKd_Pengajuan
        End Get
        Set(ByVal value As String)
            FKd_Pengajuan = value
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
        strSQL = "INSERT INTO detil_pengajuan (kd_pengajuan, kd_sample, ket)values (?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("kd_pengajuan", FKd_Pengajuan)
        mycmd.Parameters.AddWithValue("kd_sample", FKd_Sample)
        mycmd.Parameters.AddWithValue("ket", FKet)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function
End Class
