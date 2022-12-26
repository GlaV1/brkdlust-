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
    public partial class fGelir : Form
    {
        public fGelir()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public string gelirgider { get; set; }
        public string kullanici { get; set; }

        private void fGelirGider_Load(object sender, EventArgs e)
        {
            label1.Text = gelirgider + " İşlemi Yapılıyor";
        }

        private void bEkle_Click(object sender, EventArgs e)
        {
            if (cÖdemeTürü.Text!="")
            {
                if (tNakit.Text!=""&&tKart.Text!="")
                {
                    using (var db=new BarkodDBEntities())
                    {
                        Ozet io = new Ozet();
                        var islemnoartir = db.İslem.First();
                        
                        islemnoartir.İslemNo += 1;
                        io.İade = false;
                        io.OdemeSekli = cÖdemeTürü.Text;
                        io.Nakit = Islemler.DoubleYap(tNakit.Text);
                        io.Kart=Islemler.DoubleYap(tKart.Text);
                        io.Gider = false;
                        io.Gelir = true;
                        io.AlisFiyatToplam = 0;
                        io.Acıklama = gelirgider + " | " + tAçıklama.Text;
                        io.Tarih = tarih.Value;
                        db.Ozet.Add(io);
                        db.SaveChanges();
                        MessageBox.Show(gelirgider+ " İşlemi Kaydedildi ");
                        tNakit.Text = "0";
                        tKart.Text = "0";
                        tAçıklama.Clear();
                        cÖdemeTürü.Text = "";
                        fRapor f = (fRapor)Application.OpenForms["fRapor"];
                        if (f != null)
                        {
                            f.bGöster_Click(null, null);
                        }
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen ödeme türünü belirleyiniz");
            }
        }

        private void cÖdemeTürü_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cÖdemeTürü.SelectedIndex==0)
            {
                tNakit.Enabled = true;
                tKart.Enabled = false;
            }
            else if (cÖdemeTürü.SelectedIndex == 1)
            {
                tNakit.Enabled = false;
                tKart.Enabled = true;
            }
            tNakit.Text = "0";
            tKart.Text = "0";
        }

        private void tKart_TextChanged(object sender, EventArgs e)
        {

        }

        private void tNakit_TextChanged(object sender, EventArgs e)
        {

        }

        private void tAçıklama_TextChanged(object sender, EventArgs e)
        {

        }

        private void tarih_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
