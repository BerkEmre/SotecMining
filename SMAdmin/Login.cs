using SMCore;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SMAdmin
{
    public partial class Login : Form
    {
        public int progress = 0;

        private Point mouseOffset;
        private bool isMouseDown = false;

        int maxUrun;

        public Login()
        {
            InitializeComponent();
#if (DEBUG)
            btn_servis_debug.Visible = true;
#endif
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (!SQL.baglanti_test())
            {
                btn_sql.ForeColor = Color.Red;
                btn_sql.FlatAppearance.BorderColor = Color.Red;
            }
            else
            {
                btn_sql.ForeColor = Color.GreenYellow;
                btn_sql.FlatAppearance.BorderColor = Color.GreenYellow;
            }

            DataTable dtUrunler = SQL.get("SELECT id, barkod, urunismi, urunkodu, pasifmi FROM URUNLER");
            gv_urunler.DataSource = dtUrunler;

            DataTable dtPazarYerleri = SQL.get("SELECT id, adi, urun_adi, urun_kodu, barkod, pasifmi FROM PAZAR_YERLERI");
            gv_pazaryeri.DataSource = dtPazarYerleri;
        }

        #region Form Olayları
        private void btn_kapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_simge_durumu_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isMouseDown = false;
        }
        #endregion

        private void btn_sql_Click(object sender, EventArgs e)
        {
            if (!SQL.baglanti_test())
            {
                btn_sql.ForeColor = Color.Red;
                btn_sql.FlatAppearance.BorderColor = Color.Red;
            }
            else
            {
                btn_sql.ForeColor = Color.GreenYellow;
                btn_sql.FlatAppearance.BorderColor = Color.GreenYellow;
            }
        }

        private void btn_servis_debug_Click(object sender, EventArgs e)
        {
            MiningCore miningCore = new MiningCore();
            miningCore.Start();
        }

        private void btn_yeni_urun_Click(object sender, EventArgs e)
        {
            UrunEkleDuzenle f = new UrunEkleDuzenle(0);
            f.FormClosing += F_FormClosing;
            f.Show();
        }

        private void F_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable dtUrunler = SQL.get("SELECT id, barkod, urunismi, urunkodu, pasifmi FROM URUNLER");
            gv_urunler.DataSource = dtUrunler;
        }

        private void gv_urunler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(gv_urunler.SelectedRows.Count > 0)
            {
                UrunEkleDuzenle f = new UrunEkleDuzenle(Convert.ToInt32(gv_urunler.SelectedRows[0].Cells["id"].Value));
                f.FormClosing += F_FormClosing;
                f.Show();
            }
        }

        private void gv_urunler_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if (gv_urunler.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(gv_urunler.SelectedRows[0].Cells["id"].Value);
                    DialogResult dialog = new DialogResult();
                    dialog = MessageBox.Show(id + " ID li ürünü silmek istediğinize emin misiniz?", "DİKKAT", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        SQL.set("DELETE FROM URUNLER WHERE id = " + id);

                        DataTable dtUrunler = SQL.get("SELECT id, barkod, urunismi, urunkodu, pasifmi FROM URUNLER");
                        gv_urunler.DataSource = dtUrunler;
                    }
                } 
            }
            if(e.KeyCode == Keys.Enter)
            {
                if (gv_urunler.SelectedRows.Count > 0)
                {
                    UrunEkleDuzenle f = new UrunEkleDuzenle(Convert.ToInt32(gv_urunler.SelectedRows[0].Cells["id"].Value));
                    f.FormClosing += F_FormClosing;
                    f.Show();
                }
            }
        }

        private void bw_debug_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            MiningCore miningCore = new MiningCore();
            miningCore.Load();
            for (int i = 0; i < maxUrun; i++)
            {
                miningCore.getOnlyUrun(i);
                bw_debug.ReportProgress(i);
            }
            bw_debug.ReportProgress(maxUrun);
        }

        private void bw_debug_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pb_debug.Value = e.ProgressPercentage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dtUrunler = SQL.get("SELECT COUNT(id) FROM URUNLER WHERE pasifmi = 0");
            maxUrun = Convert.ToInt32(dtUrunler.Rows[0][0]);

            pb_debug.Maximum = maxUrun;

            bw_debug.RunWorkerAsync();

            pb_debug.UseWaitCursor = true;
            button2.Text = "...";
            button2.Enabled = false;
        }

        private void bw_debug_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pb_debug.UseWaitCursor = false;
            button2.Text = "VERİ ÇEK";
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dtVeriler = SQL.get(
                "SELECT " +
                "    * " +
                "FROM " +
                "( " +
                "    SELECT " +
                "        urun_id = u.id, " +
                "        urun_adi = u.urunismi, " +
                "        pazar_yeri = p.adi, " +
                "        kaynak = CASE f1.kaynak WHEN 0 THEN 'barkod' WHEN 1 THEN 'isim' WHEN 2 THEN 'kod' END, " +
                "        fiyat = f1.fiyat " +
                "    FROM " +
                "        (SELECT f.urunid, f.pazaryeriid, f.kaynak, kayitzamani = MAX(f.kayitzamani) FROM FIYATLAR f GROUP by f.urunid, f.pazaryeriid, f.kaynak) f " +
                "        INNER JOIN FIYATLAR f1     ON f1.urunid = f.urunid AND f1.pazaryeriid = f.pazaryeriid AND f1.kaynak = f.kaynak AND f1.kayitzamani = f.kayitzamani " +
                "        INNER JOIN URUNLER u       ON u.id = f1.urunid " +
                "        INNER JOIN PAZAR_YERLERI p ON p.id = f1.pazaryeriid " +
                ") as baseTable " +
                "PIVOT " +
                "( " +
                "    SUM(fiyat) FOR kaynak IN([kod], [isim], [barkod]) " +
                ") as pivotTable");
            gv_veriler.DataSource = dtVeriler;
        }

        private void gv_pazaryeri_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gv_pazaryeri.SelectedRows.Count > 0)
            {
                PazarYeriEkleDuzenle f = new PazarYeriEkleDuzenle(Convert.ToInt32(gv_pazaryeri.SelectedRows[0].Cells["cb_id"].Value));
                f.FormClosing += F_FormClosing1;
                f.Show();
            }
        }

        private void F_FormClosing1(object sender, FormClosingEventArgs e)
        {
            DataTable dtPazarYerleri = SQL.get("SELECT id, adi, urun_adi, urun_kodu, barkod, pasifmi FROM PAZAR_YERLERI");
            gv_pazaryeri.DataSource = dtPazarYerleri;
        }
    }
}
