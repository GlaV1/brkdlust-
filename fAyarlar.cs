using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace BarkodluSatis
{
    public partial class fAyarlar : Form
    {
        private object TTeraziOnek()
        {

        }
        

        public fAyarlar()
        {
            InitializeComponent();
        }

        private void doldur()
        {
            using (var db = new BarkodDBEntities())
            {
                if (db.Kullanici.Any())
                {
                    gridlisteKullanıcı.DataSource = db.Kullanici.Select(x => new { x.Id, x.AdSoyad, x.KullaniciAd, x.Telefon }).ToList();

                }
                Islemler.SabitVarsayilan();
                var yazici = db.Sabit.FirstOrDefault();
                rjToggleButton1.Checked = (bool)yazici.Yazici;

                var sabitler = db.Sabit.FirstOrDefault();
                tKartKomisyon.Text = sabitler.KartKomisyon.ToString();


                var terazi = db.Terazi.ToList();
                cmbTeraziÖnEkAyar.DisplayMember = "TeraziOnek";
                cmbTeraziÖnEkAyar.ValueMember = "Id";
                cmbTeraziÖnEkAyar.DataSource = terazi;
            }
        }
        private void fAyarlar_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            doldur();

            Cursor.Current = Cursors.Default;
        }
        private void Temizle()
        {
            tAdSoyad.Text = "";
            mTelefon.Text = "";
            tEposta.Text = "";
            tKullanıcı.Text = "";
            tŞifre.Text = "";
            cAyarlar.Checked = false;
            cRapor.Checked = false;
            cSatis.Checked = false;
            cStok.Checked = false;
            cFiyat.Checked = false;
            cYedekle.Checked = false;
            cUrun.Checked = false;
        }
        private void bkaydet_Click(object sender, EventArgs e)
        {
            if (bkaydet.Text == "Kaydet")
            {
                if (tAdSoyad.Text != "" && mTelefon.Text != "" && tKullanıcı.Text != "" && tŞifre.Text != "" && tŞifreTekrar.Text != "")
                {
                    if (tŞifre.Text == tŞifreTekrar.Text)
                    {


                        using (var db = new BarkodDBEntities())
                        {
                            if (!db.Kullanici.Any(x => x.KullaniciAd == tKullanıcı.Text))
                            {
                                Kullanici k = new Kullanici();
                                k.AdSoyad = tAdSoyad.Text;
                                k.Telefon = mTelefon.Text;
                                k.EPosta = tEposta.Text;
                                k.KullaniciAd = tKullanıcı.Text.Trim();
                                k.Sifre = tŞifre.Text;
                                k.Satis = cSatis.Checked;
                                k.Rapor = cRapor.Checked;
                                k.Stok = cStok.Checked;
                                k.UrunGiris = cUrun.Checked;
                                k.Ayarlar = cAyarlar.Checked;
                                k.FiyatGuncelle = cFiyat.Checked;
                                k.Yedekleme = cYedekle.Checked;
                                db.Kullanici.Add(k);
                                db.SaveChanges();
                                doldur();
                                Temizle();
                            }
                            else
                            {
                                MessageBox.Show("Bu kullanıcı zaten kayıtlı!");
                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("Şifreler Biribirine uyuşmuyor");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu girişleri yazınız" + "\nAd soyad \nTelefon \nKullanıcı Adı \nŞifre \nŞifre Tekrar");
                }
            }
            else if (bkaydet.Text != "Düzenle/Kaydet")
            {
                if (tAdSoyad.Text != "" && mTelefon.Text != "" && tKullanıcı.Text != "" && tŞifre.Text != "" && tŞifreTekrar.Text != "")
                {
                    if (tŞifre.Text == tŞifreTekrar.Text)
                    {
                        int Id = Convert.ToInt32(lKullanıcı.Text);
                        using (var db = new BarkodDBEntities())
                        {
                            var guncelle = db.Kullanici.Where(x => x.Id == Id).FirstOrDefault();
                            guncelle.AdSoyad = tAdSoyad.Text;
                            guncelle.Telefon = mTelefon.Text;
                            guncelle.EPosta = tEposta.Text;
                            guncelle.KullaniciAd = tKullanıcı.Text.Trim();
                            guncelle.Sifre = tŞifre.Text;
                            guncelle.Satis = cSatis.Checked;
                            guncelle.Rapor = cRapor.Checked;
                            guncelle.Stok = cStok.Checked;
                            guncelle.UrunGiris = cUrun.Checked;
                            guncelle.Ayarlar = cAyarlar.Checked;
                            guncelle.FiyatGuncelle = cFiyat.Checked;
                            guncelle.Yedekleme = cYedekle.Checked;
                            db.SaveChanges();
                            MessageBox.Show("Güncelleme yapılmıştır");
                            bkaydet.Text = "Kaydet";
                            Temizle();
                            doldur();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyuşmuyor");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu girişleri yazınız" + "\nAd soyad \nTelefon \nKullanıcı Adı \nŞifre \nŞifre Tekrar");
                }
            }

        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridlisteKullanıcı.Rows.Count > 0)
            {
                int id = Convert.ToInt32(gridlisteKullanıcı.CurrentRow.Cells["Id"].Value.ToString());
                lKullanıcı.Text = id.ToString();
                using (var db = new BarkodDBEntities())
                {
                    var getir = db.Kullanici.Where(x => x.Id == id).FirstOrDefault();
                    tAdSoyad.Text = getir.AdSoyad;
                    mTelefon.Text = getir.Telefon;
                    tEposta.Text = getir.EPosta;
                    tKullanıcı.Text = getir.KullaniciAd;
                    tŞifre.Text = getir.Sifre;
                    tŞifreTekrar.Text = getir.Sifre;
                    cSatis.Checked = (bool)getir.Satis;
                    cRapor.Checked = (bool)getir.Rapor;
                    cStok.Checked = (bool)getir.Stok;
                    cUrun.Checked = (bool)getir.UrunGiris;
                    cAyarlar.Checked = (bool)getir.Ayarlar;
                    cFiyat.Checked = (bool)getir.FiyatGuncelle;
                    cYedekle.Checked = (bool)getir.Yedekleme;
                    bkaydet.Text = "Düzenle/Kaydet";
                    doldur();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Seçiniz!");
            }
        }

        private void bİptal_Click(object sender, EventArgs e)
        {

        }

        private void bÇıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rjToggleButton1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void rjToggleButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            using (var db = new BarkodDBEntities())
            {
                if (rjToggleButton1.Checked)
                {
                    Islemler.SabitVarsayilan();

                    var ayarla = db.Sabit.FirstOrDefault();
                    ayarla.Yazici = true;
                    db.SaveChanges();
                    label9.Text = "Yazma Durumu AKTİF";
                }
                else
                {
                    Islemler.SabitVarsayilan();
                    var ayarla = db.Sabit.FirstOrDefault();
                    ayarla.Yazici = false;
                    db.SaveChanges();
                    label9.Text = "Yazma Durumu PASİF";
                }

            }
        }

        private void bKartKomisyon_Click(object sender, EventArgs e)
        {
            if (tKartKomisyon.Text != "")
            {


                using (var db = new BarkodDBEntities())
                {
                    var sabit = db.Sabit.FirstOrDefault();
                    sabit.KartKomisyon = Convert.ToInt16(tKartKomisyon.Text);
                    db.SaveChanges();
                    MessageBox.Show("Kart Komisyon Ayarlandı");


                }
            }
            else
            {
                MessageBox.Show("Kart Komisyon Bilgileri Giriniz");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bTeraziÖnEkAyar_Click(object sender, EventArgs e)
        {
            //if (tTeraziOnek.Text != "")
            {
                int onek = Convert.ToInt16(tTeraziOnek.Text);
                using (var db = new BarkodDBEntities())
                {
                    if (db.Terazi.Any(x => x.TeraziOnEk == onek))
                    {
                        MessageBox.Show(onek.ToString() + "ön zaten kayıtlı");
                    }
                    else
                    {
                        Terazi t = new Terazi();
                        t.TeraziOnEk = onek;
                        db.Terazi.Add(t);
                        db.SaveChanges();
                        MessageBox.Show("Bilgiler Kaydedilmiştir");
                        cmbTeraziÖnEkAyar.DisplayMember = "TeraziOnEk";
                        cmbTeraziÖnEkAyar.ValueMember = "Id";
                        cmbTeraziÖnEkAyar.DataSource = db.Terazi.ToList();
                        //tTeraziOnek.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Tereazi Önek Bilgisi Giriniz.");
            }
        }

        private void bTeraziÖnEkSil_Click(object sender, EventArgs e)
        {
            if (cmbTeraziÖnEkAyar.Text != "")
            {
                int ornekid = Convert.ToInt16(cmbTeraziÖnEkAyar.SelectedValue);
                DialogResult onay = MessageBox.Show(cmbTeraziÖnEkAyar.Text + "öneki silmek istiyor musunuz?", "Terazi Önek Silme İşlemi", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    using (var db = new BarkodDBEntities())
                    {
                        var onek = db.Terazi.Find(ornekid);
                        db.Terazi.Remove(onek);
                        db.SaveChanges();
                        cmbTeraziÖnEkAyar.DisplayMember = "TeraziOnEk";
                        cmbTeraziÖnEkAyar.ValueMember = "Id";
                        cmbTeraziÖnEkAyar.DataSource = db.Terazi.ToList();
                        MessageBox.Show("Önek Silinmiştir.");
                    }
                }
                else
                {
                    MessageBox.Show("Örnek Seçiniz");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\WindowsFormsApp6.exe");
            Application.Exit();
        }
    }
}
