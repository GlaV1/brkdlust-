using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluSatis
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            girisyap();
        }

        private void girisyap()
        {
            if (tKullanıcı.Text != "" && tŞifre.Text != "")
            {
                try
                {
                    using (var db = new BarkodDBEntities())
                    {
                        if (db.Kullanici.Any())
                        {
                            var bak = db.Kullanici.Where(x => x.KullaniciAd == tKullanıcı.Text && x.Sifre == tŞifre.Text).FirstOrDefault();
                            if (bak != null)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                fBaslangic f = new fBaslangic();
                                f.bSatis.Enabled = (bool)bak.Satis;
                                f.bRapor.Enabled = (bool)bak.Rapor;
                                f.bStok.Enabled = (bool)bak.Stok;
                                f.bYedekle.Enabled = (bool)bak.Yedekleme;
                                f.bÜrün.Enabled = (bool)bak.UrunGiris;
                                f.bFiyat.Enabled = (bool)bak.FiyatGuncelle;
                                f.bAyarlar.Enabled = (bool)bak.Ayarlar;
                                f.ShowDialog();
                                this.Close();
                                Cursor.Current = Cursors.Default;
                            }
                            else
                            {
                                MessageBox.Show("Hatalı Giriş");
                            }


                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
            }
        }

        private void bGiriş_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                girisyap();
            }
        }
    }
}
