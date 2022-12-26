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
    public partial class fGider : Form
    {
        public fGider()
        {
            InitializeComponent();
        }

        public string gider { get; set; }
        public string kullanici { get; set; }
        private void bEkle_Click(object sender, EventArgs e)
        {
            if (cÖdemeTürü.Text != "")
            {
                if (tNakit.Text != "" && tKart.Text != "")
                {
                    using (var db = new BarkodDBEntities())
                    {
                        Ozet io = new Ozet();
                        int? islemno = db.İslem.First().İslemNo;
                        islemno = 1;
                        var islemnoartir = db.İslem.First();
                        islemnoartir.İslemNo += 1;
                        io.İade = false;
                        io.OdemeSekli = cÖdemeTürü.Text;
                        io.Nakit = Islemler.DoubleYap(tNakit.Text);
                        io.Kart = Islemler.DoubleYap(tKart.Text);
                        io.Gider = true;
                        io.Gelir = false;
                        io.AlisFiyatToplam = 0;
                        io.Acıklama = gider + " | " + tAçıklama.Text;
                        io.Tarih = tarih.Value;
                        db.Ozet.Add(io);
                        db.SaveChanges();
                        MessageBox.Show(gider + " İşlemi Kaydedildi ");
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

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = gider + " İşlemi Yapılıyor";
        }

        private void cÖdemeTürü_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cÖdemeTürü.SelectedIndex == 0)
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
    }
}
