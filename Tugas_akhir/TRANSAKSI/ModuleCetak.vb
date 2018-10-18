Module ModuleCetak
    Sub CetakCR_Faktur(ByVal xparameter As String)
        Dim xMyReport As New crcetakfaktur

        Dim filter As String
        filter = "{faktur.no_faktur}='" & xparameter & "'"
        Dim xTampung As New frmreportviewer
        xTampung.CrystalReportViewer1.ReportSource = xMyReport
        xTampung.CrystalReportViewer1.SelectionFormula = filter
        xTampung.CrystalReportViewer1.Refresh()
        xTampung.CrystalReportViewer1.DisplayGroupTree = False
        xTampung.CrystalReportViewer1.ShowGroupTreeButton = False
        xTampung.CrystalReportViewer1.Zoom(100)
        xTampung.WindowState = FormWindowState.Maximized
        xTampung.ShowDialog()
    End Sub
    Sub CetakCR_Retur(ByVal xparameter As String)
        Dim xMyReport As New crcetakretur

        Dim filter As String
        filter = "{retur.no_retur}='" & xparameter & "'"
        Dim xTampung As New frmreportviewer
        xTampung.CrystalReportViewer1.ReportSource = xMyReport
        xTampung.CrystalReportViewer1.SelectionFormula = filter
        xTampung.CrystalReportViewer1.Refresh()
        xTampung.CrystalReportViewer1.DisplayGroupTree = False
        xTampung.CrystalReportViewer1.ShowGroupTreeButton = False
        xTampung.CrystalReportViewer1.Zoom(100)
        xTampung.WindowState = FormWindowState.Maximized
        xTampung.ShowDialog()
    End Sub
    Sub CetakCR_SPK(ByVal xparameter As String)
        Dim xMyReport As New crcetakspk

        Dim filter As String
        filter = "{spk.no_spk}='" & xparameter & "'"
        Dim xTampung As New frmreportviewer
        xTampung.CrystalReportViewer1.ReportSource = xMyReport
        xTampung.CrystalReportViewer1.SelectionFormula = filter
        xTampung.CrystalReportViewer1.Refresh()
        xTampung.CrystalReportViewer1.DisplayGroupTree = False
        xTampung.CrystalReportViewer1.ShowGroupTreeButton = False
        xTampung.CrystalReportViewer1.Zoom(100)
        xTampung.WindowState = FormWindowState.Maximized
        xTampung.ShowDialog()
    End Sub
    Sub CetakCR_LBB(ByVal xparameter As String)
        Dim xMyReport As New crcetaklbb

        Dim filter As String
        filter = "{lbb.no_lbb}='" & xparameter & "'"
        Dim xTampung As New frmreportviewer
        xTampung.CrystalReportViewer1.ReportSource = xMyReport
        xTampung.CrystalReportViewer1.SelectionFormula = filter
        xTampung.CrystalReportViewer1.Refresh()
        xTampung.CrystalReportViewer1.DisplayGroupTree = False
        xTampung.CrystalReportViewer1.ShowGroupTreeButton = False
        xTampung.CrystalReportViewer1.Zoom(100)
        xTampung.WindowState = FormWindowState.Maximized
        xTampung.ShowDialog()
    End Sub
    Sub CetakCR_jpp(ByVal xparameter As String)
        Dim xMyReport As New crcetakjpp

        Dim filter As String
        filter = "{jpp.no_jpp}='" & xparameter & "'"
        Dim xTampung As New frmreportviewer
        xTampung.CrystalReportViewer1.ReportSource = xMyReport
        xTampung.CrystalReportViewer1.SelectionFormula = filter
        xTampung.CrystalReportViewer1.Refresh()
        xTampung.CrystalReportViewer1.DisplayGroupTree = False
        xTampung.CrystalReportViewer1.ShowGroupTreeButton = False
        xTampung.CrystalReportViewer1.Zoom(100)
        xTampung.WindowState = FormWindowState.Maximized
        xTampung.ShowDialog()
    End Sub
    Sub Cetak_Lap_penjualan(ByVal periode1 As Date, ByVal periode2 As Date)
        Dim xMyReport As New crlappenjualan

        Dim filter As String
        filter = "{pp.tgl_pp}>=#" & periode1 & "# AND {pp.tgl_pp}<=#" & periode2 & "#"

        Dim xTampung As New frmreportviewer
        xTampung.CrystalReportViewer1.ReportSource = xMyReport
        xMyReport.SetParameterValue("xtgl1", periode1)
        xMyReport.SetParameterValue("xtgl2", periode2)
        xTampung.CrystalReportViewer1.SelectionFormula = filter
        xTampung.CrystalReportViewer1.Refresh()
        xTampung.CrystalReportViewer1.DisplayGroupTree = False
        xTampung.CrystalReportViewer1.ShowGroupTreeButton = False
        xTampung.CrystalReportViewer1.Zoom(100)
        xTampung.WindowState = FormWindowState.Maximized
        xTampung.ShowDialog()
    End Sub
    Sub Cetak_Lappemesanankendaraan(ByVal periode1 As Date, ByVal periode2 As Date)
        Dim xMyReport As New crlappemesanankendaraan

        Dim filter As String
        filter = "{spk.tgl_spk}>=#" & periode1 & "# AND {spk.tgl_spk}<=#" & periode2 & "#"

        Dim xTampung As New frmreportviewer
        xTampung.CrystalReportViewer1.ReportSource = xMyReport
        xMyReport.SetParameterValue("xtgl1", periode1)
        xMyReport.SetParameterValue("xtgl2", periode2)
        xTampung.CrystalReportViewer1.SelectionFormula = filter
        xTampung.CrystalReportViewer1.Refresh()
        xTampung.CrystalReportViewer1.DisplayGroupTree = False
        xTampung.CrystalReportViewer1.ShowGroupTreeButton = False
        xTampung.CrystalReportViewer1.Zoom(100)
        xTampung.WindowState = FormWindowState.Maximized
        xTampung.ShowDialog()
    End Sub
    Sub Cetak_Lap_pembelian(ByVal periode1 As Date, ByVal periode2 As Date)
        Dim xMyReport As New crlappembelianbahan

        Dim filter As String
        filter = "{pembelian.tgl_pembelian}>=#" & periode1 & "# AND {pembelian.tgl_pembelian}<=#" & periode2 & "#"

        Dim xTampung As New frmreportviewer
        xTampung.CrystalReportViewer1.ReportSource = xMyReport
        xMyReport.SetParameterValue("Tgl1", periode1)
        xMyReport.SetParameterValue("Tgl2", periode2)
        xTampung.CrystalReportViewer1.SelectionFormula = filter
        xTampung.CrystalReportViewer1.Refresh()
        xTampung.CrystalReportViewer1.DisplayGroupTree = False
        xTampung.CrystalReportViewer1.ShowGroupTreeButton = False
        xTampung.CrystalReportViewer1.Zoom(100)
        xTampung.WindowState = FormWindowState.Maximized
        xTampung.ShowDialog()
    End Sub
    Sub Cetak_Lap_pengiriman(ByVal periode1 As Date, ByVal periode2 As Date)
        Dim xMyReport As New crlappengirimanbrg

        Dim filter As String
        filter = "{jpp.tgl_jpp}>=#" & periode1 & "# AND {jpp.tgl_jpp}<=#" & periode2 & "#"

        Dim xTampung As New frmreportviewer
        xTampung.CrystalReportViewer1.ReportSource = xMyReport
        xMyReport.SetParameterValue("Tgl1", periode1)
        xMyReport.SetParameterValue("Tgl2", periode2)
        xTampung.CrystalReportViewer1.SelectionFormula = filter
        xTampung.CrystalReportViewer1.Refresh()
        xTampung.CrystalReportViewer1.DisplayGroupTree = False
        xTampung.CrystalReportViewer1.ShowGroupTreeButton = False
        xTampung.CrystalReportViewer1.Zoom(100)
        xTampung.WindowState = FormWindowState.Maximized
        xTampung.ShowDialog()
    End Sub
    Sub Cetak_Lap_retur(ByVal periode1 As Date, ByVal periode2 As Date)
        Dim xMyReport As New crlapreturbrg

        Dim filter As String
        filter = "{retur.tgl_retur}>=#" & periode1 & "# AND {retur.tgl_retur}<=#" & periode2 & "#"

        Dim xTampung As New frmreportviewer
        xTampung.CrystalReportViewer1.ReportSource = xMyReport
        xMyReport.SetParameterValue("Tgl1", periode1)
        xMyReport.SetParameterValue("Tgl2", periode2)
        xTampung.CrystalReportViewer1.SelectionFormula = filter
        xTampung.CrystalReportViewer1.Refresh()
        xTampung.CrystalReportViewer1.DisplayGroupTree = False
        xTampung.CrystalReportViewer1.ShowGroupTreeButton = False
        xTampung.CrystalReportViewer1.Zoom(100)
        xTampung.WindowState = FormWindowState.Maximized
        xTampung.ShowDialog()
    End Sub
    Sub Cetak_Lap_Sepatuterbanyak(ByVal periode1 As Date, ByVal periode2 As Date)
        Dim xMyReport As New crlapterbanyak

        Dim filter As String
        filter = "{command.tgl_pp}>=#" & periode1 & "# AND {command.tgl_pp}<=#" & periode2 & "#"

        Dim xTampung As New frmreportviewer
        xTampung.CrystalReportViewer1.ReportSource = xMyReport
        xMyReport.SetParameterValue("Tgl1", periode1)
        xMyReport.SetParameterValue("Tgl2", periode2)
        xTampung.CrystalReportViewer1.SelectionFormula = filter
        xTampung.CrystalReportViewer1.Refresh()
        xTampung.CrystalReportViewer1.DisplayGroupTree = False
        xTampung.CrystalReportViewer1.ShowGroupTreeButton = False
        xTampung.CrystalReportViewer1.Zoom(100)
        xTampung.WindowState = FormWindowState.Maximized
        xTampung.ShowDialog()
    End Sub
    Sub CetakCR_pengajuan(ByVal xparameter As String)
        Dim xMyReport As New crcetakpengajuan

        Dim filter As String
        filter = "{pengajuan.kd_pengajuan}='" & xparameter & "'"
        Dim xTampung As New frmreportviewer
        xTampung.CrystalReportViewer1.ReportSource = xMyReport
        xTampung.CrystalReportViewer1.SelectionFormula = filter
        xTampung.CrystalReportViewer1.Refresh()
        xTampung.CrystalReportViewer1.DisplayGroupTree = False
        xTampung.CrystalReportViewer1.ShowGroupTreeButton = False
        xTampung.CrystalReportViewer1.Zoom(100)
        xTampung.WindowState = FormWindowState.Maximized
        xTampung.ShowDialog()
    End Sub
    Public Sub CetakCR_pengajuan1(ByVal xparameter As String)
        Dim myReport As New crcetakpengajuan
        myReport.SetParameterValue("kd_pengajuan", xparameter)
        myReport.RecordSelectionFormula = "{pengajuan.kd_pengajuan} = '" & xparameter & "'"
        Dim objX As New frmreportviewer
        objX.CrystalReportViewer1.ReportSource = myReport
        objX.CrystalReportViewer1.Zoom(100)
        objX.CrystalReportViewer1.ShowGroupTreeButton = False
        objX.WindowState = FormWindowState.Maximized
        objX.ShowDialog()
    End Sub
    Public Sub CetakCR_SPK1(ByVal xparameter As String)
        Dim myReport As New crcetakspk
        myReport.SetParameterValue("no_spk", xparameter)
        myReport.RecordSelectionFormula = "{spk.no_spk} = '" & xparameter & "'"
        Dim objX As New frmreportviewer
        objX.CrystalReportViewer1.ReportSource = myReport
        objX.CrystalReportViewer1.Zoom(100)
        objX.CrystalReportViewer1.ShowGroupTreeButton = False
        objX.WindowState = FormWindowState.Maximized
        objX.ShowDialog()
    End Sub
    Public Sub CetakCR_jpp1(ByVal xparameter As String)
        Dim myReport As New crcetakjpp
        myReport.SetParameterValue("no_jpp", xparameter)
        myReport.RecordSelectionFormula = "{jpp.no_jpp} = '" & xparameter & "'"
        Dim objX As New frmreportviewer
        objX.CrystalReportViewer1.ReportSource = myReport
        objX.CrystalReportViewer1.Zoom(100)
        objX.CrystalReportViewer1.ShowGroupTreeButton = False
        objX.WindowState = FormWindowState.Maximized
        objX.ShowDialog()
    End Sub
End Module
