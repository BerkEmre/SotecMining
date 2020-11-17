using SMCore;
using System;
using System.Data;
using System.Windows.Forms;

namespace SMAdmin
{
    public partial class UrunEkleDuzenle : Form
    {
        int id;
        public UrunEkleDuzenle(int id)
        {
            this.id = id;

            InitializeComponent();

            lbl_urun_id.Text = id == 0 ? "" : id.ToString();
            btn_ekle_duzenle.Text = id == 0 ? "Ekle" : "Düzenle";
        }

        private void UrunEkleDuzenle_Load(object sender, EventArgs e)
        {
            if(id != 0)
            {
                DataRow drUrun = SQL.get("SELECT * FROM URUNLER WHERE id = " + id).Rows[0];

                tb_urunismi.Text = drUrun["urunismi"].ToString();
                tb_barkod.Text = drUrun["barkod"].ToString();
                tb_urunkodu.Text = drUrun["urunkodu"].ToString();
                cb_pasifmi.Checked = Convert.ToInt32(drUrun["pasifmi"]) == 0 ? false : true;
            }
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ekle_duzenle_Click(object sender, EventArgs e)
        {
            if(tb_urunismi.Text.Length <= 0)
            {
                MessageBox.Show("Ürün ismi giriniz!");
                return;
            }

            if (id != 0)
                SQL.set("UPDATE URUNLER SET urunismi = '" + tb_urunismi.Text + "', barkod = '" + tb_barkod.Text + "', urunkodu = '" + tb_urunkodu.Text + "', pasifmi = " + (cb_pasifmi.Checked ? "1" : "0") + " WHERE id = " + id);
            else
                SQL.set("INSERT INTO URUNLER (urunismi, barkod, urunkodu, pasifmi) VALUES ('" + tb_urunismi.Text + "', '" + tb_barkod.Text + "', '" + tb_urunkodu.Text + "', " + (cb_pasifmi.Checked ? "1" : "0") + ")");

            this.Close();
        }
    }
}
