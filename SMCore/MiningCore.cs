using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Xml;

namespace SMCore
{
    public class MiningCore
    {
        enum Kaynak { Barkod = 0, UrunIsmi = 1, UrunKodu = 2};
        Thread thread;
        int beklemeSuresi;
        string text = ""; 
        int siraSayisi;

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
                    else if (reader.Name == "CON_STR")
                    {
                        text = reader.ReadString();
                        break;
                    }
                }   
            }
            Log.WriteLog("CONFIG.xml okundu.");
            reader.Close();

            while (!SQL.baglanti_test())
            {
                Thread.Sleep(10000);
            }

            thread = new Thread(Exec);
            thread.Start();
        }

        public void Exec()
        {
            while (true)
            {
                while (!Load())
                {
                    Thread.Sleep(10000);
                }
                RunAsync();

                Thread.Sleep(beklemeSuresi);
            }
        }

        public void RunAsync()
        {
            Thread t0, t1, t2;

            for (int i = 0; i < siraSayisi; i++)
            {
                int index = i;

                t0 = new Thread(() => PazarYeriData((index * 3)));
                t0.Start();
                t1 = new Thread(() => PazarYeriData((index * 3) + 1));
                t1.Start();
                t2 = new Thread(() => PazarYeriData((index * 3) + 2));
                t2.Start();
                t0.Join();
                t1.Join();
                t2.Join();
            }
        }

        public void PazarYeriData(int index)
        {
            if (index >= pazarYeris.Count)
                return;

            PazarYeri pazarYeri = pazarYeris[index];

            string aramaKelimesi;
            decimal fiyat;
            string url;
            string resim;

            for (int i = 0; i < uruns.Count; i++)
            {
                aramaKelimesi = "";
                fiyat = -1;
                url = "";
                resim = "";

                Urun urun = uruns[i];
                try
                {
                    //Ürün ismine göre arama
                    aramaKelimesi = urun.urunIsmi;
                    if (aramaKelimesi.Length > 0 && pazarYeri.urun_adi == 1)
                    {
                        pazarYeri.siteDateCek(aramaKelimesi);
                        fiyat = pazarYeri.getFiyat();
                        url = pazarYeri.getURL();
                        resim = pazarYeri.getResim();
                        Save(urun.id, pazarYeri.id, 1, fiyat, url, resim);
                    }
                    //Ürün barkoduna göre arama
                    aramaKelimesi = urun.barkod;
                    if (aramaKelimesi.Length > 0 && pazarYeri.barkod == 1)
                    {
                        pazarYeri.siteDateCek(aramaKelimesi);
                        fiyat = pazarYeri.getFiyat();
                        url = pazarYeri.getURL();
                        resim = pazarYeri.getResim();
                        Save(urun.id, pazarYeri.id, 0, fiyat, url, resim);
                    }
                    //Ürün koduna göre arama
                    aramaKelimesi = urun.urunKodu;
                    if (aramaKelimesi.Length > 0 && pazarYeri.urun_kodu == 1)
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

        public void Stop()
        {
            if (thread.IsAlive)
                thread.Abort();
        }

        public bool Load()
        {
            try
            {
                foreach (DataRow dr in SQL.get("SELECT * FROM PAZAR_YERLERI WHERE pasifmi = 0").Rows)
                {
                    pazarYeris.Add(new PazarYeri(Convert.ToInt32(dr["id"]), dr["adi"].ToString(), dr["search_url"].ToString(), dr["fiyat_regex"].ToString(), dr["link_regex"].ToString(), dr["resim_regex"].ToString(), dr["node_text"].ToString(), dr["node_item"].ToString(), Convert.ToInt32(dr["urun_adi"]), Convert.ToInt32(dr["barkod"]), Convert.ToInt32(dr["urun_kodu"])));
                }
                siraSayisi = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(pazarYeris.Count) / 3));
                foreach (DataRow dr in SQL.get("SELECT * FROM URUNLER WHERE pasifmi = 0").Rows)
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
                        if (aramaKelimesi.Length > 0 && pazarYeri.urun_adi == 1)
                        {
                            pazarYeri.siteDateCek(aramaKelimesi);
                            fiyat = pazarYeri.getFiyat();
                            url = pazarYeri.getURL();
                            resim = pazarYeri.getResim();
                            Save(urun.id, pazarYeri.id, 1, fiyat, url, resim);
                        }
                        //Ürün barkoduna göre arama
                        aramaKelimesi = urun.barkod;
                        if (aramaKelimesi.Length > 0 && pazarYeri.barkod == 1)
                        {
                            pazarYeri.siteDateCek(aramaKelimesi);
                            fiyat = pazarYeri.getFiyat();
                            url = pazarYeri.getURL();
                            resim = pazarYeri.getResim();
                            Save(urun.id, pazarYeri.id, 0, fiyat, url, resim);
                        }
                        //Ürün koduna göre arama
                        aramaKelimesi = urun.urunKodu;
                        if (aramaKelimesi.Length > 0 && pazarYeri.urun_kodu == 1)
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
            //try
            //{
            //    if(SQL.getU("SELECT TOP 1 * FROM FIYATLAR WHERE urunid = " + urun_id + " AND pazaryeriid = " + pazaryeri_id + " AND kaynak = " + kaynak + " AND fiyat = " + fiyat.ToString().Replace(',', '.') + " ORDER by kayitzamani DESC").Rows.Count <= 0)
            //        SQL.setU("INSERT INTO FIYATLAR (urunid, pazaryeriid, kaynak, fiyat, kayitzamani, link, resimurl1, resimurl2, resimurl3) VALUES (" + urun_id + ", " + pazaryeri_id + ", " + kaynak + ", " + fiyat.ToString().Replace(',', '.') + ", GETDATE(), '" + link + "', '" + resim + "', '', '')");
            //}
            //catch { }

            try
            {
                DataTable dt = SQL.getU("SELECT TOP 1 * FROM FIYATLAR WHERE urunid = " + urun_id + " AND pazaryeriid = " + pazaryeri_id + " AND kaynak = " + kaynak + " ORDER by kayitzamani DESC");

                if (dt == null)
                    return;

                if (dt.Rows.Count == 0)
                    SQL.setU("INSERT INTO FIYATLAR (urunid, pazaryeriid, kaynak, fiyat, kayitzamani, link, resimurl1, resimurl2, resimurl3) VALUES (" + urun_id + ", " + pazaryeri_id + ", " + kaynak + ", " + fiyat.ToString().Replace(',', '.') + ", GETDATE(), '" + link + "', '" + resim + "', '', '')");
                else if (Convert.ToDecimal(dt.Rows[0]["fiyat"]) != fiyat)
                    SQL.setU("INSERT INTO FIYATLAR (urunid, pazaryeriid, kaynak, fiyat, kayitzamani, link, resimurl1, resimurl2, resimurl3) VALUES (" + urun_id + ", " + pazaryeri_id + ", " + kaynak + ", " + fiyat.ToString().Replace(',', '.') + ", GETDATE(), '" + link + "', '" + resim + "', '', '')");
            }
            catch { }
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
