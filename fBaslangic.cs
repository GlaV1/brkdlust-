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
    public partial class fBaslangic : Form
    {
        public fBaslangic()
        {
            InitializeComponent();
        }

        private void bSatis_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fSatis f = new fSatis();
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void bÇıkıs_Click(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("Sistem Kapatılsın Mı?", "Barkodlı Satıs Programı", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
               
            }

            
            
        }

        private void bYedekle_Click(object sender, EventArgs e)
        {
            Islemler.Backup();
        }

        private void bÜrün_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fUrunGiris f = new fUrunGiris();
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void bAyarlar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fAyarlar F = new fAyarlar();
            F.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void bRapor_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fRapor rapor = new fRapor();
            rapor.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void bStok_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fStok f = new fStok();
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void bFiyat_Click(object sender, EventArgs e)
        {
            fFiyatGuncelle f = new fFiyatGuncelle();
            f.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mesafeokullari.com");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
