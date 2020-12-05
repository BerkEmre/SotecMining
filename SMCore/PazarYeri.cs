using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SMCore
{
    class PazarYeri
    {
        public int id { get; set; }
        public string pazarYeri { get; set; }
        public string searchURL { get; set; }
        public string fiyatRegex { get; set; }
        public string linkRegex { get; set; }
        public string resimRegex { get; set; }
        public string nodeText { get; set; }
        public string nodeItem { get; set; }
        public int urun_adi { get; set; }
        public int barkod { get; set; }
        public int urun_kodu { get; set; }

        private HtmlNodeCollection sonucListesi;
        private string siteData;
        private int bestFiyatIndex = -1;
        Regex decRegex = new Regex(@"[\d]*[\.|,]?[\d]*");

        public PazarYeri(int id, string pazarYeri, string searchURL, string fiyatRegex, string linkRegex, string resimRegex, string nodeText, string nodeItem, int urun_adi, int barkod, int urun_kodu)
        {
            this.id = id;
            this.pazarYeri = pazarYeri;
            this.searchURL = searchURL;
            this.fiyatRegex = fiyatRegex;
            this.linkRegex = linkRegex;
            this.resimRegex = resimRegex;
            this.nodeText = nodeText;
            this.nodeItem = nodeItem;
            this.urun_adi = urun_adi;
            this.barkod = barkod;
            this.urun_kodu = urun_kodu;
        }

        public string reAramaKelimesi(string input)
        {
            input = input.Replace("&", "%26");
            input = input.Replace("?", "%3F");
            input = input.Replace("/", "%2F");
            input = input.Replace(@"\", "%5C");
            input = input.Replace("'", "%27");

            return input;
        }

        public bool siteDateCek(string aramaKelimesi)
        {
            siteData = "";
            sonucListesi = null;
            aramaKelimesi = reAramaKelimesi(aramaKelimesi);
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko)");
                    Uri myUri = new Uri(String.Format(searchURL, aramaKelimesi), UriKind.Absolute);
                    siteData = client.DownloadString(myUri);
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(siteData);
                    HtmlNodeCollection htmlNodes = doc.DocumentNode.SelectNodes(@nodeText);
                    if (htmlNodes == null || htmlNodes.Count <= 0)
                    {
                        Log.WriteLog(String.Format(searchURL, aramaKelimesi) + " Arama nodu çekilemedi tasarım değişmiş olabilir.");
                        return false;
                    }

                    siteData = htmlNodes[0].InnerHtml;
                    HtmlNode anaNode = htmlNodes[0];

                    sonucListesi = anaNode.SelectNodes(@nodeItem);
                }
            }
            catch (Exception e)
            {
                Log.WriteLog(pazarYeri + " arama yaparken hata oluştu => " + e.Message);
                return false;
            }

            return true;
        }

        public decimal getFiyat()
        {
            decimal bestFiyat = 0;
            decimal fFiyat;
            string mFiyat;

            try
            {
                if (sonucListesi == null || sonucListesi.Count <= 0)
                {
                    bestFiyat = -1;
                    bestFiyatIndex = -1;
                    return bestFiyat;
                }

                for (int i = 0; i < sonucListesi.Count; i++)
                {
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(sonucListesi[i].InnerHtml);
                    HtmlNodeCollection fiyatNodes = doc.DocumentNode.SelectNodes(@fiyatRegex);
                    if(fiyatNodes != null && fiyatNodes.Count > 0)
                    {
                        HtmlNode fiyatNode = doc.DocumentNode.SelectNodes(@fiyatRegex)[0];
                        Match m = decRegex.Match(fiyatNode.InnerHtml);
                        if (m.Success)
                        {
                            mFiyat = m.Value;
                            fFiyat = Convert.ToDecimal(mFiyat);

                            if (bestFiyat == 0 || fFiyat < bestFiyat)
                            {
                                bestFiyat = fFiyat;
                                bestFiyatIndex = i;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.WriteLog(pazarYeri + " : fiyat ararken bir hata oluştu => " + e.Message);
                return bestFiyat;
            }

            return bestFiyat;
        }

        public string getURL()
        {
            string url = "";

            if (bestFiyatIndex == -1)
                return url;

            try
            {
                HtmlNode node = sonucListesi[bestFiyatIndex];

                Regex regex = new Regex(@linkRegex);
                MatchCollection matches = regex.Matches(node.InnerHtml);

                if (matches.Count <= 0)
                    url = "";
                else
                {
                    try
                    {
                        url = matches[0].Groups[1].Value;
                    }
                    catch
                    {
                        return url;
                    }
                }
            }
            catch (Exception e)
            {
                Log.WriteLog(pazarYeri + " URL çekilirken hata oluştu " + e.Message);
                url = "";
                return url;
            }

            return url;
        }

        public string getResim()
        {
            string resim = "";

            if (bestFiyatIndex == -1)
                return resim;

            try
            {
                HtmlNode node = sonucListesi[bestFiyatIndex];

                Regex regex = new Regex(@resimRegex);
                MatchCollection matches = regex.Matches(node.InnerHtml);

                if (matches.Count <= 0)
                    resim = "";
                else
                {
                    try
                    {
                        resim = matches[0].Groups[1].Value;
                    }
                    catch
                    {
                        return resim;
                    }
                }
            }
            catch (Exception e)
            {
                Log.WriteLog(pazarYeri + " resim çekilirken hata oluştu " + e.Message);
                resim = "";
                return resim;
            }

            return resim;
        }
    }
}
