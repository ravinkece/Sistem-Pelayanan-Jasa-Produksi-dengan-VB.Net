Imports System.Data.Odbc
Module ModuleKoneksi
    Public strConn As String
    Public MyCnn As New OdbcConnection
    Public dreader As OdbcDataReader
    Public Sub BukaConn()
        strConn = "Dsn=db_ta;"

        MyCnn = New OdbcConnection(strConn)
        If MyCnn.State = ConnectionState.Closed Then
            Try
                MyCnn.Open()

            Catch ex As Exception
                MsgBox(ex.Message)
                Application.Exit()
            End Try
        End If
    End Sub
End Module
