Imports System.Data.Odbc
Public Class clscustomer

    Private FKdCust As String
    Private FNmCust As String
    Private FAlamat As String
    Private FTelp As String
    Private FEmail As String
    Public Property PKdCust() As String
        Get
            Return FKdCust
        End Get
        Set(ByVal value As String)
            FKdCust = value
        End Set
    End Property

    Public Property PNmCust() As String
        Get
            Return FNmCust
        End Get
        Set(ByVal value As String)
            FNmCust = value
        End Set
    End Property

    Public Property PAlamat() As String
        Get
            Return FAlamat
        End Get
        Set(ByVal value As String)
            FAlamat = value
        End Set
    End Property

    Public Property PEmail() As String
        Get
            Return FEmail
        End Get
        Set(ByVal value As String)
            FEmail = value
        End Set
    End Property

    Public Property PTelp() As String
        Get
            Return FTelp
        End Get
        Set(ByVal value As String)
            FTelp = value
        End Set
    End Property
    Public Function autonumber() As String
        Dim Mycmmd As New OdbcCommand
        Dim Myreader As OdbcDataReader
        Dim SQL As String
        Dim Autonilai As String

        SQL = "SELECT * FROM customer ORDER BY kd_customer desc"
        Mycmmd = New OdbcCommand(SQL, MyCnn)
        Myreader = Mycmmd.ExecuteReader
        If Myreader.HasRows Then
            Myreader.Read()
            Autonilai = Val(Mid(Myreader.Item("kd_customer"), 4)) + 1
            Autonilai = "CST" & Right("0000", 4 - Autonilai.Length) & Autonilai
        Else
            Autonilai = "CST0001"
        End If
        Myreader.Close()
        Return Autonilai
    End Function

    Public Function cari() As Boolean
        Dim Query As String
        Dim xmyread As OdbcDataReader
        Dim xmycmd As OdbcCommand

        Query = "SELECT * FROM customer WHERE kd_customer=?"
        xmycmd = New OdbcCommand(Query, MyCnn)
        xmycmd.Parameters.AddWithValue("kd_customer", FKdCust)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            xmyread.Read()
            FNmCust = xmyread.Item("nm_customer").ToString
            FAlamat = xmyread.Item("alamat").ToString
            FTelp = xmyread.Item("telp").ToString
            FEmail = xmyread.Item("email").ToString
            FKdCust = xmyread.Item("kd_customer").ToString
            xmyread.Close()
            Return True
        Else
            xmyread.Close()
            Return False
        End If
    End Function

    Public Function simpan() As Integer
        Dim mycmd As OdbcCommand
        Dim strSQL As String
        Dim nilx As Integer
        strSQL = "INSERT INTO customer (kd_customer, nm_customer, alamat, telp, email)values (?,?,?,?,?)"
        mycmd = New OdbcCommand(strSQL, MyCnn)
        mycmd.Parameters.AddWithValue("kd_customer", FKdCust)
        mycmd.Parameters.AddWithValue("nm_customer", FNmCust)
        mycmd.Parameters.AddWithValue("alamat", FAlamat)
        mycmd.Parameters.AddWithValue("telp", FTelp)
        mycmd.Parameters.AddWithValue("email", FEmail)
        mycmd.Prepare()
        nilx = mycmd.ExecuteNonQuery
        mycmd.Dispose()
        Return nilx
    End Function

    Public Function ubah() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim X As Integer

        sql = "UPDATE customer SET nm_customer=?, alamat=?, telp=?, email=? WHERE kd_customer=?"

        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("nm_customer", FNmCust)
        xmycmd.Parameters.AddWithValue("alamat", FAlamat)
        xmycmd.Parameters.AddWithValue("telp", FTelp)
        xmycmd.Parameters.AddWithValue("email", FEmail)
        xmycmd.Parameters.AddWithValue("kd_customer", FKdCust)
        xmycmd.Prepare()
        X = xmycmd.ExecuteNonQuery()

        xmycmd.Dispose()
        Return X
    End Function

    Public Function hapus() As Integer
        Dim sql As String
        Dim xmycmd As OdbcCommand
        Dim x As Integer
        sql = "DELETE FROM customer WHERE kd_customer=?"
        xmycmd = New OdbcCommand(sql, MyCnn)
        xmycmd.Parameters.AddWithValue("kd_customer", FKdCust)
        xmycmd.Prepare()
        x = xmycmd.ExecuteNonQuery()
        xmycmd.Dispose()
        Return x
    End Function

    Public Function tampildata(ByVal xdata As String) As List(Of clscustomer)
        Dim Q As String
        Dim xmycmd As OdbcCommand
        Dim xmyread As OdbcDataReader
        Dim tmpbaca As New List(Of clscustomer)

        Q = "Select * FROM customer WHERE nm_customer like '%" & xdata & "%'"
        xmycmd = New OdbcCommand(Q, MyCnn)
        xmyread = xmycmd.ExecuteReader
        If xmyread.HasRows Then
            While xmyread.Read
                Dim objtemp As New clscustomer
                objtemp.FKdCust = xmyread.Item("kd_customer")
                objtemp.FNmCust = xmyread.Item("nm_customer")
                objtemp.FAlamat = xmyread.Item("alamat")
                objtemp.FTelp = xmyread.Item("telp")
                objtemp.FEmail = xmyread.Item("email")
                tmpbaca.Add(objtemp)
            End While
        End If
        xmyread.Close()
        Return tmpbaca
    End Function
End Class
