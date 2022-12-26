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
    public partial class fFiyatGuncelle : Form
    {
        public fFiyatGuncelle()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                using (var db=new BarkodDBEntities())
                {
                    if (db.Urun.Any(x=>x.Barkod==tBarkod.Text.Trim()))
                    {
                        var getir = db.Urun.Where(x => x.Barkod == tBarkod.Text).SingleOrDefault();
                        lBarkod.Text = getir.Barkod;
                        lÜrün.Text = getir.UrunAd;
                        double mevcutfiyat = Convert.ToDouble(getir.SatisFiyat);
                        lMevcutFiyat.Text = mevcutfiyat.ToString("C2");
                    }
                    else
                    {
                        MessageBox.Show("Ürün Kayıtlı değil");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text!=""&&lBarkod.Text!="")
            {
                using (var db = new BarkodDBEntities())
                {
                    var guncellenecek = db.Urun.Where(x => x.Barkod == lBarkod.Text).SingleOrDefault();
                    guncellenecek.SatisFiyat = Islemler.DoubleYap(textBox2.Text);
                    int kdvorani = Convert.ToInt16(guncellenecek.KdvOrani);
                    Math.Round(Islemler.DoubleYap(textBox2.Text) * kdvorani / 100, 2);
                    db.SaveChanges();
                    MessageBox.Show("Yeni Fiyat kaydedilmistir");
                    lBarkod.Text = "";
                    lÜrün.Text = "";
                    lMevcutFiyat.Text = "";
                    textBox2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Ürünü Okutunuz");
            }
        }

        private void fFiyatGuncelle_Load(object sender, EventArgs e)
        {
            lBarkod.Text = "";
            lÜrün.Text = "";
            lMevcutFiyat.Text = "";
        }

        private void bÇıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
