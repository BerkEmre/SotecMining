using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace SMCore
{
    public class MiningCore
    {
        enum Kaynak { Barkod = 0, UrunIsmi = 1, UrunKodu = 2};

        int beklemeSuresi;

        List<PazarYeri> pazarYeris = new List<PazarYeri>();
        List<Urun> uruns = new List<Urun>();

        public void Start()
        {
            string currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            XmlTextReader reader = new XmlTextReader(currentPath + @"\CONFIG.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "BEKLEME_SURESI")
                    {
                        beklemeSuresi = Convert.ToInt32(reader.ReadString());
                        break;
                    }
                }   
            }
            reader.Close();

            while (!SQL.baglanti_test())
            {
                Thread.Sleep(10000);
            }

            while(true)
            {
                while(!Load())
                {
                    Thread.Sleep(10000);
                }

                Run();
                Thread.Sleep(beklemeSuresi);
            }
        }

        public void Stop()
        {

        }

        public bool Load()
        {
            try
            {
                foreach (DataRow dr in SQL.get("SELECT * FROM PAZAR_YERLERI WHERE pasifmi = 0").Rows)
                {
                    pazarYeris.Add(new PazarYeri(Convert.ToInt32(dr["id"]), dr["adi"].ToString(), dr["search_url"].ToString(), dr["fiyat_regex"].ToString(), dr["link_regex"].ToString(), dr["resim_regex"].ToString(), dr["node_text"].ToString(), dr["node_item"].ToString()));
                }
                foreach(DataRow dr in SQL.get("SELECT * FROM URUNLER WHERE pasifmi = 0").Rows)
                {
                    uruns.Add(new Urun(Convert.ToInt32(dr["id"]), dr["urunismi"].ToString(), dr["urunkodu"].ToString(), dr["barkod"].ToString()));
                }

                return true;
            }
            catch(Exception e)
            {
                Log.WriteLog("Pazar Yerleri ve Ürünler SQL den okunurken bir hata oluştu => " + e.Message);
                return false;
            }
        }

        public void Run()
        {
            string aramaKelimesi;
            decimal fiyat;
            string url;
            string resim;

            foreach (Urun urun in uruns)
            {
                foreach (PazarYeri pazarYeri in pazarYeris)
                {
                    try
                    {
                        //Ürün ismine göre arama
                        aramaKelimesi = urun.urunIsmi;
                        if (aramaKelimesi.Length > 0)
                        {
                            pazarYeri.siteDateCek(aramaKelimesi);
                            fiyat = pazarYeri.getFiyat();
                            url = pazarYeri.getURL();
                            resim = pazarYeri.getResim();
                            Save(urun.id, pazarYeri.id, 1, fiyat, url, resim);
                        }
                        //Ürün barkoduna göre arama
                        aramaKelimesi = urun.barkod;
                        if (aramaKelimesi.Length > 0)
                        {
                            pazarYeri.siteDateCek(aramaKelimesi);
                            fiyat = pazarYeri.getFiyat();
                            url = pazarYeri.getURL();
                            resim = pazarYeri.getResim();
                            Save(urun.id, pazarYeri.id, 0, fiyat, url, resim);
                        }
                        //Ürün koduna göre arama
                        aramaKelimesi = urun.urunKodu;
                        if (aramaKelimesi.Length > 0)
                        {
                            pazarYeri.siteDateCek(aramaKelimesi);
                            fiyat = pazarYeri.getFiyat();
                            url = pazarYeri.getURL();
                            resim = pazarYeri.getResim();
                            Save(urun.id, pazarYeri.id, 2, fiyat, url, resim);
                        }
                    }
                    catch (Exception e)
                    {
                        Log.WriteLog(pazarYeri.pazarYeri + " Pazaryerinde " + urun.urunIsmi + "Ürünü aranırken bir hata oluştu => " + e.Message);
                    }
                    
                }
            }
        }

        public void Save(int urun_id, int pazaryeri_id, int kaynak, decimal fiyat, string link, string resim)
        {
            DataTable dt = SQL.get("SELECT TOP 1 * FROM FIYATLAR WHERE urunid = " + urun_id + " AND pazaryeriid = " + pazaryeri_id + " AND kaynak = " + kaynak + " AND fiyat = " + fiyat.ToString().Replace(',', '.') + " ORDER by kayitzamani DESC");
            if(dt.Rows.Count <= 0)
                SQL.set("INSERT INTO FIYATLAR (urunid, pazaryeriid, kaynak, fiyat, kayitzamani, link, resimurl1, resimurl2, resimurl3) " +
                    "VALUES (" + urun_id + ", " + pazaryeri_id + ", " + kaynak + ", " + fiyat.ToString().Replace(',', '.') + ", GETDATE(), '" + link + "', '" + resim + "', '', '')");
        }
    
        public int getUrunsCount()
        {
            return uruns.Count();
        }
    
        public void getOnlyUrun(int cnt)
        {
            string aramaKelimesi;
            decimal fiyat;
            string url;
            string resim;

            Urun urun = uruns[cnt];

            foreach (PazarYeri pazarYeri in pazarYeris)
            {
                try
                {
                    //Ürün ismine göre arama
                    aramaKelimesi = urun.urunIsmi;
                    if (aramaKelimesi.Length > 0)
                    {
                        pazarYeri.siteDateCek(aramaKelimesi);
                        fiyat = pazarYeri.getFiyat();
                        url = pazarYeri.getURL();
                        resim = pazarYeri.getResim();
                        Save(urun.id, pazarYeri.id, 1, fiyat, url, resim);
                    }
                    //Ürün barkoduna göre arama
                    aramaKelimesi = urun.barkod;
                    if (aramaKelimesi.Length > 0)
                    {
                        pazarYeri.siteDateCek(aramaKelimesi);
                        fiyat = pazarYeri.getFiyat();
                        url = pazarYeri.getURL();
                        resim = pazarYeri.getResim();
                        Save(urun.id, pazarYeri.id, 0, fiyat, url, resim);
                    }
                    //Ürün koduna göre arama
                    aramaKelimesi = urun.urunKodu;
                    if (aramaKelimesi.Length > 0)
                    {
                        pazarYeri.siteDateCek(aramaKelimesi);
                        fiyat = pazarYeri.getFiyat();
                        url = pazarYeri.getURL();
                        resim = pazarYeri.getResim();
                        Save(urun.id, pazarYeri.id, 2, fiyat, url, resim);
                    }
                }
                catch (Exception e)
                {
                    Log.WriteLog(pazarYeri.pazarYeri + " Pazaryerinde " + urun.urunIsmi + "Ürünü aranırken bir hata oluştu => " + e.Message);
                }

            }
        }
    }
}
