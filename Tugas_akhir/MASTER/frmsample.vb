Imports System.Data.Odbc
Public Class frmsample
    Dim objsample As New clssample
    Private strSql As String = String.Empty
    Dim mycmd As OdbcCommand
    Dim nil As Integer
    Private PathFile As String = Nothing
    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        Dim nilai As Integer
        If txtnmsample.Text = "" Or txthrgsample.Text = "" Then
            MsgBox("Terdapat Data Kosong")
        Else
            objsample.PKdSample = txtkdsample.Text
            objsample.PNmSample = txtnmsample.Text
            objsample.PGambar = lblket.Text()
            objsample.PHrgSample = txthrgsample.Text
            nilai = objsample.simpan()
            If nilai = 1 Then
                MsgBox("Data Berhasil Disimpan")
            Else
                MsgBox("Data Gagal Disimpan")
            End If
            txtnmsample.Clear()
            txthrgsample.Clear()
            lblket.Text = ""
            gmbr.Image = Nothing
            txtkdsample.Text = objsample.autonumber
            txtnmsample.Focus()
        End If
    End Sub

    Private Sub frmsample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BukaConn()
        txtkdsample.Text = objsample.autonumber()
        txtkdsample.Enabled = False
        txtnmsample.Focus()
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txthrgsample.MaxLength = 10
    End Sub

    Private Sub btnbrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'On Error Resume Next
        ' OpenFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|GIF Files(*.gif)|*.gif|PNG Files(*.png)|*.png|BMP Files(*.bmp)|*.bmp|TIFF Files(*.tiff)|*.tiff"
        'OpenFileDialog1.FileName = ""
        'If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        'gmbr.SizeMode = PictureBoxSizeMode.StretchImage
        'gmbr.Image = New Bitmap(OpenFileDialog1.FileName)
        'PathFile = OpenFileDialog1.FileName
        'txtgmbr.Text = PathFile.Substring(PathFile.LastIndexOf("\") + 1)
        ' Label10.Text = OpenFileDialog1.FileName
        'gmbr.Image = Image.FromFile(Label10.Text)
        'End If
    End Sub

    Private Sub btnubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnubah.Click
        Dim nilaikembali As Integer
        objsample.PKdSample = txtkdsample.Text
        objsample.PNmSample = txtnmsample.Text
        objsample.PGambar = lblket.Text
        objsample.PHrgSample = txthrgsample.Text
        nilaikembali = objsample.ubah()
        If nilaikembali = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin mengubah data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Diubah")
            End If
        Else
            MsgBox("Data Gagal Diubah")
        End If
        txtnmsample.Clear()
        txthrgsample.Clear()
        gmbr.Image = Nothing
        lblket.Text = ""
        txtkdsample.Text = objsample.autonumber
        txtkdsample.Enabled = False
        btncari.Enabled = True
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtnmsample.Focus()
    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        Dim opop As New frmpopupsample
        opop.ShowDialog()

        If opop.refkdsample <> "" Then
            txtkdsample.Text = opop.refkdsample
            txtnmsample.Text = opop.refnmsample
            txthrgsample.Text = opop.refhrg
            lblket.Text = opop.refgmbr
            gmbr.ImageLocation = opop.refgmbr
            gmbr.SizeMode = PictureBoxSizeMode.StretchImage
            btnsimpan.Enabled = False
            btnubah.Enabled = True
            btnhapus.Enabled = True
        End If
        txtkdsample.Enabled = False
    End Sub

    Private Sub btnhapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhapus.Click
        Dim nilai As Integer
        objsample.PKdSample = txtkdsample.Text
        objsample.PNmSample = txtnmsample.Text
        objsample.PGambar = lblket.Text
        objsample.PHrgSample = txthrgsample.Text
        nilai = objsample.hapus()
        If nilai = 1 Then
            If MessageBox.Show("Apakah anda yakin ingin menghapus data ?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                MsgBox("Data Berhasil Dihapus")
            End If
        Else
            MsgBox("Data Gagal Dihapus")
        End If
        txtnmsample.Clear()
        txthrgsample.Clear()
        lblket.Text = ""
        gmbr.Image = Nothing
        txtkdsample.Text = objsample.autonumber
        txtkdsample.Enabled = False
        btncari.Enabled = True
        btnsimpan.Enabled = True
        btnubah.Enabled = False
        btnhapus.Enabled = False
        txtnmsample.Focus()
    End Sub

    Private Sub btnbatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbatal.Click
        txtnmsample.Clear()
        txthrgsample.Clear()
        lblket.Text = ""
        gmbr.Image = Nothing
        txtkdsample.Text = objsample.autonumber
        txtkdsample.Enabled = False
    End Sub

    Private Sub btnkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnkeluar.Click
        If (MessageBox.Show("Apakah yakin ingin keluar?", "Konfirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
            Me.Close()
            txtnmsample.Clear()
            lblket.Text = ""
            gmbr.Image = Nothing
            txthrgsample.Clear()
            txtkdsample.Text = objsample.autonumber
        End If
    End Sub

    Private Sub txthrgsample_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthrgsample.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled() = True
    End Sub

    Private Sub txthrgsample_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthrgsample.TextChanged

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub btncarigbr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncarigbr.Click
        On Error Resume Next
        OpenFileDialog1.Filter = "JPG Files(*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|GIF Files(*.gif)|*.gif|PNG Files(*.png)|*.png|BMP Files(*.bmp)|*.bmp|TIFF Files(*.tiff)|*.tiff"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            gmbr.SizeMode = PictureBoxSizeMode.StretchImage
            gmbr.Image = New Bitmap(OpenFileDialog1.FileName)
            PathFile = OpenFileDialog1.FileName
            lblket.Text = OpenFileDialog1.FileName
            gmbr.Image = Image.FromFile(lblket.Text)
        End If
    End Sub
End Class