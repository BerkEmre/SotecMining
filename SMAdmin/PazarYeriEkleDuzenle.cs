using SMCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMAdmin
{
    public partial class PazarYeriEkleDuzenle : Form
    {
        int id;

        public PazarYeriEkleDuzenle(int id)
        {
            this.id = id;

            InitializeComponent();

            lbl_urun_id.Text = id == 0 ? "" : id.ToString();
            btn_ekle_duzenle.Text = id == 0 ? "Ekle" : "Düzenle";
        }

        private void PazarYeriEkleDuzenle_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                DataRow drUrun = SQL.get("SELECT * FROM PAZAR_YERLERI WHERE id = " + id).Rows[0];

                cb_pasifmi.Checked = Convert.ToInt32(drUrun["pasifmi"]) == 0 ? false : true;
                cb_urun_adi.Checked = Convert.ToInt32(drUrun["urun_adi"]) == 0 ? false : true;
                cb_urun_kodu.Checked = Convert.ToInt32(drUrun["urun_kodu"]) == 0 ? false : true;
                cb_barkod.Checked = Convert.ToInt32(drUrun["barkod"]) == 0 ? false : true;
            }
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ekle_duzenle_Click(object sender, EventArgs e)
        {
            if (id != 0)
                SQL.set("UPDATE PAZAR_YERLERI SET urun_adi = " + (cb_urun_adi.Checked ? "1" : "0") + ", urun_kodu = " + (cb_urun_kodu.Checked ? "1" : "0") + ", barkod = " + (cb_barkod.Checked ? "1" : "0") + ", pasifmi = " + (cb_pasifmi.Checked ? "1" : "0") + " WHERE id = " + id);
            //else
            //    SQL.set("INSERT INTO URUNLER (urunismi, barkod, urunkodu, pasifmi) VALUES ('" + tb_urunismi.Text + "', '" + tb_barkod.Text + "', '" + tb_urunkodu.Text + "', " + (cb_pasifmi.Checked ? "1" : "0") + ")");

            this.Close();
        }
    }
}
