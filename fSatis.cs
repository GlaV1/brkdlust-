using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluSatis
{
    public partial class fSatis : Form
    {
        public fSatis()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }
        BarkodDBEntities db = new BarkodDBEntities();
        private void tBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                string barkod = tBarkod.Text.Trim();
                if (barkod.Length<=2)
                {
                    tMiktar.Text = barkod;
                    tBarkod.Clear();
                    tBarkod.Focus();
                }
                else
                {
                    if(db.Urun.Any(a=>a.Barkod==barkod))
                    {
                        
                        var urun = db.Urun.Where(a => a.Barkod == barkod).FirstOrDefault();
                        UrunGetirListeye(urun, barkod, Convert.ToDouble(tMiktar.Text));

                    }
                    else
                    {
                        int onek = Convert.ToInt32(barkod.Substring(0, 2));
                        if(db.Terazi.Any(a=> a.TeraziOnEk==onek))
                        {
                            string teraziurunno = barkod.Substring(2, 5);
                            if (db.Urun.Any(a=> a.Barkod==teraziurunno))
                            {
                                var urunterazi = db.Urun.Where(a => a.Barkod == teraziurunno).FirstOrDefault();
                                double miktarkg = Convert.ToDouble(barkod.Substring(7, 5)) / 1000;
                                UrunGetirListeye(urunterazi, teraziurunno, miktarkg);
                            }
                            else
                            {
                                Console.Beep(900, 100);
                                MessageBox.Show("Kg Ürün Ekleme Sayfası");
                            }
                            
                        }
                        else
                        {
                            Console.Beep(900, 100);
                            MessageBox.Show("Normal Ürün Ekleme Sayfası");
                        }
                    }
                    
                }
                gridSatislistesi.ClearSelection();
                GenelToplam();
                
            }
        }

        private void GenelToplam()
        {
                double toplam = 0;
                for (int i = 0; i < gridSatislistesi.Rows.Count; i++)
                {
                    toplam += Convert.ToDouble(gridSatislistesi.Rows[i].Cells["Toplam"].Value);

                }
                tGeneltoplam.Text = toplam.ToString("C2");
            tMiktar.Text = "1";
                tBarkod.Clear();
                tBarkod.Focus();
        }

        private void bh_MouseDown(object sender,MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            {
                Button b = (Button)sender;
                if (!b.Text.StartsWith("-"))
                {
                    int butonid = Convert.ToInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));
                    ContextMenuStrip s = new ContextMenuStrip();
                    ToolStripMenuItem sil = new ToolStripMenuItem();
                    sil.Text = "Temizle - Buton No:" + butonid.ToString();
                    sil.Click += Sil_Click;
                    s.Items.Add(sil);
                    this.ContextMenuStrip = s;
                }
            }
        }

        private void Sil_Click(object sender, EventArgs e)
        {
            int butonid = Convert.ToInt16(sender.ToString().Substring(19, sender.ToString().Length - 19));
            var guncelle = db.HizliUrun.Find(butonid);
            guncelle.Barkod = "-";
            guncelle.UrunAd = "-";
            guncelle.Fiyat = 0;
            db.SaveChanges();
            double fiyat = 0;
            Button b = this.Controls.Find("bh" + butonid, true).FirstOrDefault() as Button;
            b.Text = "-" + "\n"  + fiyat.ToString("C2");
        }

        private void HizliButtonClick(object sender,EventArgs e )
        {
            
            Button b = (Button)sender;
            int butonid = Convert.ToInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));
            if (b.Text.ToString().StartsWith("-"))
            {
                fHizliButonUrunEkle f = new fHizliButonUrunEkle();
                f.lButonıd.Text = butonid.ToString();
                f.ShowDialog();
            }
            else
            {
                 
                var urunbarkod = db.HizliUrun.Where(a => a.Id == butonid).Select(a => a.Barkod).FirstOrDefault();
                var urun = db.Urun.Where(a => a.Barkod == urunbarkod).FirstOrDefault();
                UrunGetirListeye(urun, urunbarkod, Convert.ToDouble(tMiktar.Text));
                GenelToplam();
            }
        }

        private void tBarkod_TextChanged(object sender, EventArgs e )
        {
            
            
        }


        private void UrunGetirListeye(Urun urun, string barkod, double miktar)
        {
            int satirsayisi = gridSatislistesi.Rows.Count;
            //double miktar = Convert.ToDouble(tMiktar.Text);
            bool eklenmismi = false;
            if (satirsayisi > 0)
            {
                for (int i = 0; i < satirsayisi; i++)
                {
                    if (gridSatislistesi.Rows[i].Cells["Barkod"].Value.ToString() == barkod)
                    {
                        gridSatislistesi.Rows[i].Cells["Miktar"].Value = miktar + Convert.ToDouble(gridSatislistesi.Rows[i].Cells["Miktar"].Value);
                        gridSatislistesi.Rows[i].Cells["Toplam"].Value = Math.Round(Convert.ToDouble(gridSatislistesi.Rows[i].Cells["Miktar"].Value) * Convert.ToDouble(gridSatislistesi.Rows[i].Cells["Fiyat"].Value));
                        eklenmismi = true;
                    }
                }
            }
            if (!eklenmismi)
            {
                gridSatislistesi.Rows.Add();
                gridSatislistesi.Rows[satirsayisi].Cells["Barkod"].Value = barkod;
                gridSatislistesi.Rows[satirsayisi].Cells["UrunAdı"].Value = urun.UrunAd;
                gridSatislistesi.Rows[satirsayisi].Cells["UrunGrup"].Value = urun.UrunGrup;
                gridSatislistesi.Rows[satirsayisi].Cells["Birim"].Value = urun.Birim;
                gridSatislistesi.Rows[satirsayisi].Cells["Fiyat"].Value = urun.SatisFiyat;
                gridSatislistesi.Rows[satirsayisi].Cells["Miktar"].Value = miktar;
                gridSatislistesi.Rows[satirsayisi].Cells["Toplam"].Value = Math.Round(miktar * (double)urun.SatisFiyat, 2);
                gridSatislistesi.Rows[satirsayisi].Cells["AlisFiyati"].Value = urun.AlisFiyat;
                gridSatislistesi.Rows[satirsayisi].Cells["KdvTutari"].Value = urun.KdvTutari;
            }
        }

        private void gridSatislistesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                gridSatislistesi.Rows.Remove(gridSatislistesi.CurrentRow);
                gridSatislistesi.ClearSelection();
                GenelToplam();
                tBarkod.Focus();
            }
        }

        private void fSatis_Load(object sender, EventArgs e)
        {
            HizliButonDoldur();
            b5.Text = 5.ToString("C2");
            b10.Text = 10.ToString("C2");
            b20.Text = 20.ToString("C2");
            b50.Text = 50.ToString("C2");
            b100.Text = 100.ToString("C2");
            b200.Text = 200.ToString("C2");
        }
        private void HizliButonDoldur()
        {
            var hizliurun = db.HizliUrun.ToList();
            foreach (var item in hizliurun)
            {
                Button bh = this.Controls.Find("bh" + item.Id, true).FirstOrDefault() as Button;
                if (bh!=null)
                {
                    double fiyat = Islemler.DoubleYap(item.Fiyat.ToString());
                    bh.Text = item.UrunAd + "\n"+fiyat.ToString("C2"); 
                }
            }
        }
        
        private void bnx_Click(object sender,EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text==",")
            {
                int virgul = tNumarator.Text.Count(x => x == ',');
                if (virgul<1)
                {
                    tNumarator.Text += b.Text;
                }
            }
            else if (b.Text=="<")
            {
                if (tNumarator.Text.Length>0)
                {
                    tNumarator.Text = tNumarator.Text.Substring(0, tNumarator.Text.Length - 1);
                }
            }
            else
            {
                tNumarator.Text += b.Text;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void badet_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text!="")
            {
                tMiktar.Text = tNumarator.Text;
                tNumarator.Clear();
                tBarkod.Clear();
                tBarkod.Focus();
            }  
        }

        private void bodenen_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text!="")
            {
                double sonuc = Islemler.DoubleYap(tNumarator.Text) - Islemler.DoubleYap(tGeneltoplam.Text);
                tParaustu.Text = sonuc.ToString("C2");
                tNumarator.Clear();
                tBarkod.Focus();
            }
        }

        private void bBarkod_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text!="")
            {
                if (db.Urun.Any(a=>a.Barkod==tNumarator.Text))
                {
                    var urun = db.Urun.Where(a => a.Barkod == tNumarator.Text).FirstOrDefault();
                    UrunGetirListeye(urun, tNumarator.Text, Convert.ToDouble(tMiktar.Text));
                    tNumarator.Clear();
                    tBarkod.Focus();
                }
                else
                {
                    
                }
            }
        }
        private void ParaUstuHesapla_Click (object sender,EventArgs e)
        {
            Button b = (Button)sender;
            double sonuc = Islemler.DoubleYap(b.Text) - Islemler.DoubleYap(tGeneltoplam.Text);
            tParaustu.Text = sonuc.ToString("C2");
        }

        private void bdigerurun_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text!="")
            {
                int satirsayisi = gridSatislistesi.Rows.Count;
                gridSatislistesi.Rows.Add();
                gridSatislistesi.Rows[satirsayisi].Cells["Barkod"].Value = "1111111111113";
                gridSatislistesi.Rows[satirsayisi].Cells["UrunAdı"].Value = "Barkodsuz Ürün";
                gridSatislistesi.Rows[satirsayisi].Cells["UrunGrup"].Value = "Barkodsuz Ürün";
                gridSatislistesi.Rows[satirsayisi].Cells["Birim"].Value = "Adet";
                gridSatislistesi.Rows[satirsayisi].Cells["Miktar"].Value = 1;
                gridSatislistesi.Rows[satirsayisi].Cells["Fiyat"].Value = Convert.ToDouble(tNumarator.Text);
                gridSatislistesi.Rows[satirsayisi].Cells["KdvTutari"].Value = 0;
                gridSatislistesi.Rows[satirsayisi].Cells["Toplam"].Value = Convert.ToDouble(tNumarator.Text);
                tNumarator.Text = "";
                GenelToplam();
                tBarkod.Focus();
            }
        }

        private void bİade_Click(object sender, EventArgs e)
        {
            if (chSatisİslemi.Checked)
            {
                chSatisİslemi.Checked = false;
                chSatisİslemi.Text = "Satış Yapılıyor";
            }
            else
            {
                chSatisİslemi.Checked = true;
                chSatisİslemi.Text = "İade İşlemi";
            }
        }

        private void bTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void Temizle()
        {
            tMiktar.Text = "1";
            tBarkod.Clear();
            tOdenen.Clear();
            tParaustu.Clear();
            tGeneltoplam.Text = 0.ToString("C2");
            chSatisİslemi.Checked = false;
            tNumarator.Clear();
            gridSatislistesi.Rows.Clear();
            tBarkod.Clear();
            tBarkod.Focus();
        }
        private void SatisYap(string odemesekli)
        {
            int satirsayisi = gridSatislistesi.Rows.Count;
            bool satisiade = chSatisİslemi.Checked;
            double alisfiyattoplam = 0;
            if (satirsayisi>0)
            {
                int? islemno = db.İslem.First().İslemNo;
                Satis satis = new Satis();
                
                for (int i = 0; i < satirsayisi; i++)
                {
                    satis.İslemNo = (int)islemno;
                    satis.UrunAd = gridSatislistesi.Rows[i].Cells["UrunAdı"].Value.ToString();
                    satis.UrunGrup = gridSatislistesi.Rows[i].Cells["UrunGrup"].Value.ToString();
                    satis.Barkod = gridSatislistesi.Rows[i].Cells["Barkod"].Value.ToString();
                    satis.Birim = gridSatislistesi.Rows[i].Cells["Birim"].Value.ToString();
                    satis.AlisFiyat =Islemler.DoubleYap (gridSatislistesi.Rows[i].Cells["AlisFiyati"].Value.ToString());
                    satis.SatisFiyat = Islemler.DoubleYap(gridSatislistesi.Rows[i].Cells["Fiyat"].Value.ToString());
                    satis.Miktar = Islemler.DoubleYap(gridSatislistesi.Rows[i].Cells["Miktar"].Value.ToString());
                    satis.Toplam = Islemler.DoubleYap(gridSatislistesi.Rows[i].Cells["Toplam"].Value.ToString());
                    satis.KdvTutari = Islemler.DoubleYap(gridSatislistesi.Rows[i].Cells["KdvTutari"].Value.ToString()) * Islemler.DoubleYap(gridSatislistesi.Rows[i].Cells["Miktar"].Value.ToString());
                    satis.OdemeSekli = odemesekli;
                    satis.Iade = satisiade;
                    satis.Tarih = DateTime.Now;
                    satis.Kullanici = label3.Text;
                    db.Satis.Add(satis);
                    db.SaveChanges();
                    
                    

                    if (!satisiade)
                    {
                        Islemler.Stokazalt(gridSatislistesi.Rows[i].Cells["Barkod"].Value.ToString(), Islemler.DoubleYap(gridSatislistesi.Rows[i].Cells["Miktar"].Value.ToString()));
                    }
                    else
                    {
                        Islemler.Stokartir(gridSatislistesi.Rows[i].Cells["Barkod"].Value.ToString(), Islemler.DoubleYap(gridSatislistesi.Rows[i].Cells["Miktar"].Value.ToString()));
                    }
                    alisfiyattoplam += Islemler.DoubleYap(gridSatislistesi.Rows[i].Cells["AlisFiyati"].Value.ToString());



                }

                İslemOzet io = new İslemOzet();
                io.IslemNo = islemno;
                io.İade = satisiade;
                io.AlisFiyatToplam = alisfiyattoplam;
                io.Gelir = false;
                io.Gider = false;
                if (!satisiade)
                {
                    io.Acıklama = odemesekli + "Satış";
                    io.Acıklama = "İade işlemi(" + odemesekli + ")";
                }
                else
                {
                    io.Acıklama = "İade işlemi(" + odemesekli + ")";
                }
                io.OdemeSekli = odemesekli;
                io.Kullanici = label3.Text;
                io.Tarih = DateTime.Now;
                switch (odemesekli)
                {
                    case "Nakit":
                        io.Nakit = Islemler.DoubleYap(tGeneltoplam.Text);
                        io.Karrt = 0; break;
                    case "Kart":
                        io.Nakit = 0;
                        io.Karrt = Islemler.DoubleYap(tGeneltoplam.Text);break;
                    case "Kart-Nakit":
                        io.Nakit = Islemler.DoubleYap(label5.Text);
                        io.Karrt = Islemler.DoubleYap(label4.Text);break;
                }
                db.İslemOzet.Add(io);
                db.SaveChanges();

                var islemnoartir = db.İslem.First();
                islemnoartir.İslemNo += 1;
                db.SaveChanges();
                MessageBox.Show("Yazdırma İşlemi Yap");

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bNakit_Click(object sender, EventArgs e)
        {
            SatisYap("Nakit");
        }

        private void bKart_Click(object sender, EventArgs e)
        {
            SatisYap("Kart");
        }

        private void chSatisİslemi_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
