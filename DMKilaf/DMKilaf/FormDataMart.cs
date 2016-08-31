using DevExpress.XtraPrinting;
using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMKilaf
{
    public partial class FormDataMart : DevExpress.XtraEditors.XtraForm
    {
        public FormDataMart()
        {
            InitializeComponent();
        }

        //========== TAMPIL DATA DIMENSI DAN FAKTA ==========
        void DimWaktu()
        {
            string connection_string = @"Data Source = IHSAN-PC; Initial Catalog = db_kertas_dm; Integrated Security = True";
            SqlConnection koneksi = new SqlConnection(connection_string);
            koneksi.Open();
            string query = "SELECT id_waktu AS 'ID', tanggal AS 'TANGGAL', bulan_nama AS 'BULAN', tahun AS 'TAHUN', full_date AS 'DATE' FROM dim_waktu";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            koneksi.Close();
            gridDimWaktu.DataSource = dt;
        }

        void DimKertas()
        {
            string connection_string = @"Data Source = IHSAN-PC; Initial Catalog = db_kertas_dm; Integrated Security = True";
            SqlConnection koneksi = new SqlConnection(connection_string);
            koneksi.Open();
            string query = "SELECT id_kertas AS 'ID', jenis_kertas AS 'JENIS KERTAS' FROM dim_kertas";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            koneksi.Close();
            gridDimKertas.DataSource = dt;
        }

        void DimKonsumen()
        {
            string connection_string = @"Data Source = IHSAN-PC; Initial Catalog = db_kertas_dm; Integrated Security = True";
            SqlConnection koneksi = new SqlConnection(connection_string);
            koneksi.Open();
            string query = "SELECT id_konsumen AS 'ID', nama_konsumen AS 'NAMA KONSUMEN' FROM dim_konsumen";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            koneksi.Close();
            gridDimKonsumen.DataSource = dt;
        }

        void DimPenjualan()
        {
            string connection_string = @"Data Source = IHSAN-PC; Initial Catalog = db_kertas_dm; Integrated Security = True";
            SqlConnection koneksi = new SqlConnection(connection_string);
            koneksi.Open();
            string query = "SELECT no_faktur AS 'NO FAKTUR', nama_konsumen AS 'KONSUMEN' FROM dim_penjualan p JOIN dim_konsumen k ON p.id_konsumen=k.id_konsumen";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            koneksi.Close();
            gridDimPenjualan.DataSource = dt;
        }

        void DimNPK()
        {
            string connection_string = @"Data Source = IHSAN-PC; Initial Catalog = db_kertas_dm; Integrated Security = True";
            SqlConnection koneksi = new SqlConnection(connection_string);
            koneksi.Open();
            string query = "SELECT no_npk AS 'NO NPK', no_kendaraan AS 'NO KENDARAAN' FROM dim_npk";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            koneksi.Close();
            gridDimNPK.DataSource = dt;
        }

        void FactPenjualan()
        {
            string connection_string = @"Data Source = IHSAN-PC; Initial Catalog = db_kertas_dm; Integrated Security = True";
            SqlConnection koneksi = new SqlConnection(connection_string);
            koneksi.Open();
            string query = "SELECT p.no_faktur AS 'NO FAKTUR', k.jenis_kertas AS 'JENIS KERTAS', w.tanggal AS 'TANGGAL', w.bulan_nama AS 'BULAN', w.tahun AS 'TAHUN', p.quantum AS 'QUANTUM', p.total AS 'TOTAL' FROM fact_penjualan p JOIN dim_kertas k ON p.id_kertas=k.id_kertas JOIN dim_waktu w ON p.id_waktu=w.id_waktu";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            koneksi.Close();
            gridFact_penjualan.DataSource = dt;
        }

        void FactNPK()
        {
            string connection_string = @"Data Source = IHSAN-PC; Initial Catalog = db_kertas_dm; Integrated Security = True";
            SqlConnection koneksi = new SqlConnection(connection_string);
            koneksi.Open();
            string query = "SELECT n.no_npk AS 'NO NPK', n.no_faktur AS 'NO FAKTUR', w.tanggal AS 'TANGGAL', w.bulan_nama AS 'BULAN', w.tahun AS 'TAHUN', n.quantum AS 'QUANTUM' FROM fact_npk n JOIN dim_waktu w ON n.id_waktu=w.id_waktu";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            koneksi.Close();
            gridFactNPK.DataSource = dt;
        }

        void FactRetur()
        {
            string connection_string = @"Data Source = IHSAN-PC; Initial Catalog = db_kertas_dm; Integrated Security = True";
            SqlConnection koneksi = new SqlConnection(connection_string);
            koneksi.Open();
            string query = "SELECT r.no_faktur AS 'NO FAKTUR', k.jenis_kertas AS 'JENIS KERTAS', w.tanggal AS 'TANGGAL', w.bulan_nama AS 'BULAN', w.tahun AS 'TAHUN', SUM(r.quantum) AS 'QUANTUM' FROM fact_retur r JOIN dim_waktu w ON r.id_waktu=w.id_waktu JOIN dim_kertas k ON r.id_kertas=k.id_kertas GROUP BY r.no_faktur, k.jenis_kertas, w.tanggal, w.bulan_nama, w.tahun";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            koneksi.Close();
            gridFactRetur.DataSource = dt;
        }
        //========== END TAMPIL DATA DIMENSI DAN FAKTA ==========

        //========== ETL UPDATE DATA MART ==========
        private void btnUpdateETL_Click(object sender, EventArgs e)
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                Cursor.Current = Cursors.WaitCursor;
                string lokasi = Environment.CurrentDirectory.ToString() + "\\Resources\\Package.dtsx";
                DTSExecResult pkgResults_Sql;
                Microsoft.SqlServer.Dts.Runtime.Application app = new Microsoft.SqlServer.Dts.Runtime.Application();
                Microsoft.SqlServer.Dts.Runtime.Package pkg = new Microsoft.SqlServer.Dts.Runtime.Package();
                pkg = app.LoadPackage(lokasi, null);
                pkgResults_Sql = pkg.Execute();
                splashScreenManager1.CloseWaitForm();
                MessageBox.Show("Data berhasil di-Update.", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilData();
            }
            catch (System.Exception f)
            {
                MessageBox.Show(f.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        //========== END ETL UPDATE DATA MART ==========

        //========== ANALISIS DATA PENJUALAN ==========
        private void btnPivotPenjualan_Click(object sender, EventArgs e)
        {
            pivotGridOlapPenjualan.Visible = true;
            chartOlapPenjualan.Visible = false;
        }

        private void btnGrafikPenjualan_Click(object sender, EventArgs e)
        {
            pivotGridOlapPenjualan.Visible = false;
            chartOlapPenjualan.Visible = true;
        }

        private void btnCetakPenjualan_Click(object sender, EventArgs e)
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = pivotGridOlapPenjualan;
            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderAreaPenjualan);
            link.CreateMarginalFooterArea += new CreateAreaEventHandler(Link_CreateMarginalFooterAreaPenjualan);
            link.CreateReportHeaderArea += new CreateAreaEventHandler(Link_CreateReportHeaderAreaPenjualan);
            link.CreateDocument();
            link.ShowPreview();
        }

        private void Link_CreateReportHeaderAreaPenjualan(object sender, CreateAreaEventArgs e)
        {
            string reportHeader = "Data Penjualan Kertas";
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font("Time News Roman", 14, FontStyle.Bold);
            RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 40);
            e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None);
        }

        private void Link_CreateMarginalFooterAreaPenjualan(object sender, CreateAreaEventArgs e)
        {
            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.None, "KERTAS PADALARANG", Color.Black, new RectangleF(0, 0, 500, 40), BorderSide.None);
            brick.LineAlignment = BrickAlignment.Center;
            brick.Alignment = BrickAlignment.Far;
            brick.AutoWidth = true;
            brick.Font = new Font("Time News Roman", 10);
        }

        private void Link_CreateMarginalHeaderAreaPenjualan(object sender, CreateAreaEventArgs e)
        {
            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.None, "KERTAS PADALARANG", Color.Black, new RectangleF(0, 0, 500, 40), BorderSide.None);
            brick.Alignment = BrickAlignment.Near;
            brick.AutoWidth = true;
            brick.Font = new Font("Time News Roman", 16, FontStyle.Bold);
        }
        //========== END ANALISIS DATA PENJUALAN ==========

        //========== ANALISIS DATA PENDAPATAN ==========
        private void btnPivotPendapatan_Click(object sender, EventArgs e)
        {
            pivotGridOlapPendapatan.Visible = true;
            chartOlapPendapatan.Visible = false;
        }

        private void btnGrafikPendapatan_Click(object sender, EventArgs e)
        {
            pivotGridOlapPendapatan.Visible = false;
            chartOlapPendapatan.Visible = true;
        }

        private void btnCetakPendapatan_Click(object sender, EventArgs e)
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = pivotGridOlapPendapatan;
            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderAreaPendapatan);
            link.CreateMarginalFooterArea += new CreateAreaEventHandler(Link_CreateMarginalFooterAreaPendapatan);
            link.CreateReportHeaderArea += new CreateAreaEventHandler(Link_CreateReportHeaderAreaPendapatan);
            link.CreateDocument();
            link.ShowPreview();
        }

        private void Link_CreateReportHeaderAreaPendapatan(object sender, CreateAreaEventArgs e)
        {
            string reportHeader = "Data Pendapatan Penjualan";
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font("Time News Roman", 14, FontStyle.Bold);
            RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 40);
            e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None);
        }

        private void Link_CreateMarginalFooterAreaPendapatan(object sender, CreateAreaEventArgs e)
        {
            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.None, "KERTAS PADALARSNG", Color.Black, new RectangleF(0, 0, 500, 40), BorderSide.None);
            brick.LineAlignment = BrickAlignment.Center;
            brick.Alignment = BrickAlignment.Far;
            brick.AutoWidth = true;
            brick.Font = new Font("Time News Roman", 10);
        }

        private void Link_CreateMarginalHeaderAreaPendapatan(object sender, CreateAreaEventArgs e)
        {
            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.None, "KERTAS PADALARANG", Color.Black, new RectangleF(0, 0, 500, 40), BorderSide.None);
            brick.Alignment = BrickAlignment.Near;
            brick.AutoWidth = true;
            brick.Font = new Font("Time News Roman", 16, FontStyle.Bold);
        }
        //========== END ANALISIS DATA PENDAPATAN ==========

        //========== ANALISIS DATA NOTA PENYERAHAN KERTAS ==========
        private void btnPivotNotaPenyerahanKertas_Click(object sender, EventArgs e)
        {
            pivotGridOlapNotaPenyerahanKertas.Visible = true;
            chartOlapNotaPenyerahanKertas.Visible = false;
        }

        private void btnGrafikNotaPenyerahanKertas_Click(object sender, EventArgs e)
        {
            pivotGridOlapNotaPenyerahanKertas.Visible = false;
            chartOlapNotaPenyerahanKertas.Visible = true;
        }

        private void btnCetakNotaPenyerahanKertas_Click(object sender, EventArgs e)
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = pivotGridOlapNotaPenyerahanKertas;
            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderAreaNpk);
            link.CreateMarginalFooterArea += new CreateAreaEventHandler(Link_CreateMarginalFooterAreaNpk);
            link.CreateReportHeaderArea += new CreateAreaEventHandler(Link_CreateReportHeaderAreaNpk);
            link.CreateDocument();
            link.ShowPreview();
        }

        private void Link_CreateReportHeaderAreaNpk(object sender, CreateAreaEventArgs e)
        {
            string reportHeader = "Data Nota Penyerahan Kertas";
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font("Time News Roman", 14, FontStyle.Bold);
            RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 40);
            e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None);
        }

        private void Link_CreateMarginalFooterAreaNpk(object sender, CreateAreaEventArgs e)
        {
            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.None, "KERTAS PADALARANG", Color.Black, new RectangleF(0, 0, 500, 40), BorderSide.None);
            brick.LineAlignment = BrickAlignment.Center;
            brick.Alignment = BrickAlignment.Far;
            brick.AutoWidth = true;
            brick.Font = new Font("Time News Roman", 10);
        }

        private void Link_CreateMarginalHeaderAreaNpk(object sender, CreateAreaEventArgs e)
        {
            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.None, "KERTAS PADALARANG", Color.Black, new RectangleF(0, 0, 500, 40), BorderSide.None);
            brick.Alignment = BrickAlignment.Near;
            brick.AutoWidth = true;
            brick.Font = new Font("Time News Roman", 16, FontStyle.Bold);
        }
        //========== END ANALISIS DATA NOTA PENYERAHAN KERTAS ==========

        //========== END ANALISIS DATA RETUR ==========
        private void btnPivotRetur_Click(object sender, EventArgs e)
        {
            pivotGridOlapRetur.Visible = true;
            chartOlapRetur.Visible = false;
        }

        private void btnGrafikRetur_Click(object sender, EventArgs e)
        {
            pivotGridOlapRetur.Visible = false;
            chartOlapRetur.Visible = true;
        }

        private void btnCetakRetur_Click(object sender, EventArgs e)
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = pivotGridOlapRetur;
            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderAreaRetur);
            link.CreateMarginalFooterArea += new CreateAreaEventHandler(Link_CreateMarginalFooterAreaRetur);
            link.CreateReportHeaderArea += new CreateAreaEventHandler(Link_CreateReportHeaderAreaRetur);
            link.CreateDocument();
            link.ShowPreview();
        }

        private void Link_CreateReportHeaderAreaRetur(object sender, CreateAreaEventArgs e)
        {
            string reportHeader = "Data Retur Penjualan";
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font("Time News Roman", 14, FontStyle.Bold);
            RectangleF rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 40);
            e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None);
        }

        private void Link_CreateMarginalFooterAreaRetur(object sender, CreateAreaEventArgs e)
        {
            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.None, "KERTAS PADALARANG", Color.Black, new RectangleF(0, 0, 500, 40), BorderSide.None);
            brick.LineAlignment = BrickAlignment.Center;
            brick.Alignment = BrickAlignment.Far;
            brick.AutoWidth = true;
            brick.Font = new Font("Time News Roman", 10);
        }

        private void Link_CreateMarginalHeaderAreaRetur(object sender, CreateAreaEventArgs e)
        {
            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.None, "KERTAS PADALARANG", Color.Black, new RectangleF(0, 0, 500, 40), BorderSide.None);
            brick.Alignment = BrickAlignment.Near;
            brick.AutoWidth = true;
            brick.Font = new Font("Time News Roman", 16, FontStyle.Bold);
        }
        //========== END ANALISIS DATA RETUR ==========

        //========== LOGIN ==========
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = "manajer";
            string password = "manajer";
            if (textUsername.Text == username && textPassword.Text == password)
            {
                panelLogin.Visible = false;
                tabDataMart.Visible = true;
            }
            else
            {
                MessageBox.Show("Username atau Password salah.");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textUsername.Text = "";
            textPassword.Text = "";
        }
        //========== END LOGIN ==========

        //========== TAMPIL DATA ==========
        void TampilData()
        {
            string connection_string = @"Data Source = IHSAN-PC; Initial Catalog = db_kertas_dm; Integrated Security = True";
            SqlConnection koneksi = new SqlConnection(connection_string);
            koneksi.Open();
            string query = "SELECT * FROM dim_waktu";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            koneksi.Close();

            if (dt.Rows.Count == 0)
            {
                labelHome.Visible = false;

                xtraTabControl3.Visible = false;
                labelLihatData.Visible = true;

                xtraTabControl2.Visible = false;
                labelAnalisis.Visible = true;
            }
            else
            {
                labelHome.Visible = true;

                xtraTabControl3.Visible = true;
                labelLihatData.Visible = false;

                xtraTabControl2.Visible = true;
                labelAnalisis.Visible = false;

                DimWaktu();
                DimKertas();
                DimKonsumen();
                DimPenjualan();
                DimNPK();
                FactPenjualan();
                FactNPK();
                FactRetur();
            }
        }
        //========== END TAMPIL DATA ==========

        //========== FORM LOAD ==========
        private void FormDataMart_Load(object sender, EventArgs e)
        {
            TampilData();
            panelLogin.Visible = true;
            tabDataMart.Visible = false;

            labelAnalisis.Visible = false;
            labelLihatData.Visible = false;
        }
    }
}
