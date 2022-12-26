using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;

namespace BarkodluSatis
{
    public partial class fUrunGiris : Form
    {
        public fUrunGiris()
        {
            InitializeComponent();
        }
        

        private void bStandart2_Click(object sender, EventArgs e)
        {
            var barkodno = db.Barkod.First();
            int karakter = barkodno.BarkodNo.ToString().Length;
            string sifirlar=string.Empty;
            for (int i = 0; i < 8-karakter; i++)
            {
                sifirlar = sifirlar + "0";
            }
            string olusanbarkod = sifirlar + barkodno.BarkodNo.ToString();
            tBarkod.Text=olusanbarkod;
            tStandart2.Focus();
        }
        BarkodDBEntities db=new BarkodDBEntities();
        private void tBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                string barkod = tBarkod.Text.Trim();
                if (db.Urun.Any(a=>a.Barkod==barkod))
                {
                    var urun=db.Urun.Where(a=>a.Barkod==barkod).SingleOrDefault ();
                    tStandart2.Text = urun.UrunAd;
                    tStandart3.Text= urun.Aciklama;
                    comboBox1.Text = urun.UrunGrup;
                    tNumeric1.Text=urun.AlisFiyat.ToString();
                    tNumeric2.Text = urun.SatisFiyat.ToString();
                    tNumeric3.Text = urun.Miktar.ToString();
                    tNumeric4.Text = urun.KdvOrani.ToString();
                    if (urun.Birim=="Kg")
                    {
                        chSatisİslemi.Checked = true;
                    }
                    else
                    {
                        chSatisİslemi.Checked=false;
                    }
                }
                else
                {
                    MessageBox.Show("Ürün kayıtlı değil,Kaydedebilirsiniz...");
                }
            }
        }

        private void bStandart4_Click(object sender, EventArgs e)
        {
            if (tBarkod.Text!=""&&tStandart2.Text!=""
                && comboBox1.Text != "" && tNumeric1.Text!=""&&tNumeric2.Text!=""&&tNumeric3.Text!="" && tNumeric4.Text != "")
            {
                if (db.Urun.Any(a=>a.Barkod==tBarkod.Text))
                {
                    var guncelle = db.Urun.Where(a => a.Barkod == tBarkod.Text).SingleOrDefault();
                    guncelle.Barkod = tBarkod.Text;
                    guncelle.UrunAd = tStandart2.Text;
                    guncelle.Aciklama = tStandart3.Text;
                    guncelle.UrunGrup = comboBox1.Text;
                    guncelle.AlisFiyat = Convert.ToDouble(tNumeric1.Text);
                    guncelle.SatisFiyat = Convert.ToDouble(tNumeric2.Text);
                    guncelle.KdvOrani = Convert.ToInt32(tNumeric4.Text);
                    guncelle.KdvTutari = Math.Round(Islemler.DoubleYap(tNumeric2.Text) * Convert.ToInt32(tNumeric4.Text) / 100, 2);
                    guncelle.Miktar += Convert.ToDouble(tNumeric3.Text);
                    if (chSatisİslemi.Checked)
                    {
                        guncelle.Birim = "Kg";
                    }
                    else
                    {
                        guncelle.Birim = "Adet";
                    }
                    guncelle.Tarih = DateTime.Now;
                    guncelle.Kullanici = lKullanıcı.Text;
                    
                    db.SaveChanges();

                    gridozel.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(10).ToList();
                }
                else
                {
                    Urun urun = new Urun();
                    urun.Barkod = tBarkod.Text;
                    urun.UrunAd = tStandart2.Text;
                    urun.Aciklama = tStandart3.Text;
                    urun.UrunGrup = comboBox1.Text;
                    urun.AlisFiyat = Convert.ToDouble(tNumeric1.Text);
                    urun.SatisFiyat = Convert.ToDouble(tNumeric2.Text);
                    urun.KdvOrani = Convert.ToInt32(tNumeric4.Text);
                    urun.KdvTutari = Math.Round(Islemler.DoubleYap(tNumeric2.Text) * Convert.ToInt32(tNumeric4.Text) / 100, 2);
                    urun.Miktar = Convert.ToDouble(tNumeric3.Text);
                    if (chSatisİslemi.Checked)
                    {
                        urun.Birim = "Kg";
                    }
                    else
                    {
                        urun.Birim = "Adet";
                    }
                    urun.Tarih = DateTime.Now;
                    urun.Kullanici = lKullanıcı.Text;
                    db.Urun.Add(urun);
                    db.SaveChanges();
                    if (tBarkod.Text.Length==8)
                    {
                        var ozelbarkod = db.Barkod.First();
                        ozelbarkod.BarkodNo += 1;
                        db.SaveChanges();
                    }
                    temizle();
                    gridozel.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(10).ToList();
                }

            }
            else
            {
                MessageBox.Show("Bilgi Girişlerinin Kontrol Ediniz");
                tBarkod.Focus();
            }
            
           
        }

        private void gridozel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void tStandart4_TextChanged(object sender, EventArgs e)
        {
            if (tStandart4.Text.Length>2)
            {
                string urunad = tStandart4.Text;
                gridozel.DataSource = db.Urun.Where(a => a.UrunAd.Contains(urunad)).ToList();

            }
        }
        private void temizle()
        {
            tBarkod.Clear();
            tStandart2.Clear();
            tStandart3.Clear();
            tNumeric1.Text = "0";
            tNumeric2.Text = "0";
            tNumeric3.Text = "0";
            tNumeric4.Text = "8";
            tBarkod.Focus();
            chSatisİslemi.Checked = false;
        }

        private void bStandart3_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void fUrunGiris_Load(object sender, EventArgs e)
        {
            bStandart5.Text = "";
            bStandart1.Text = "";
            tNumeric5.Text=db.Urun.Count().ToString();
             gridozel.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(1000).ToList();

        }

        private void tNumeric3_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridozel_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void tNumeric5_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void bStandart1_Click(object sender, EventArgs e)
        {
            
        }
        

        private void tNumeric1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tNumeric1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44 && e.KeyChar != (char)45)
            {
                e.Handled = true;
            }
        }

        private void tNumeric1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44 && e.KeyChar != (char)45)
            {
                e.Handled = true;
            }
        }

        private void chSatisİslemi_CheckedChanged(object sender, EventArgs e)
        {
            if (chSatisİslemi.Checked)
            {
                chSatisİslemi.Text = "Gramajlı Ürün İşlemi";
                bStandart2.Enabled=false;

            }
            else
            {
                chSatisİslemi.Text = "Barkodlu Ürün İşlemi";
                bStandart2.Enabled = true;
            }
        }

        private void bStandart5_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application excel = new Excel.Application();
                excel.Visible = true;
                object Missing = Type.Missing;
                Workbook workbook = excel.Workbooks.Add(Missing);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                for (int j = 0; j < gridozel.Columns.Count; j++)
                {
                    Range myRange = (Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = gridozel.Columns[j].HeaderText;
                }
                StartRow++;
                for (int i = 0; i < gridozel.Columns.Count; i++)
                {
                    for (int j = 0; j < gridozel.Columns.Count; j++)
                    {
                        Range myRange = (Range)sheet1.Cells[StartRow + i, StartCol + j];
                        myRange.Value2 = gridozel[j, i].Value == null ? "" : gridozel[j, i].Value;
                        myRange.Select();


                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(gridozel.SelectedRows.Count > 0)
            {
                gridozel.Rows.RemoveAt(gridozel.SelectedRows[1].Index);
            }

            else
            {
                MessageBox.Show("Lüffen Silinecek Satırı Seçin!");
            }
        }
        
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int secilenId = Convert.ToInt16(gridozel.CurrentRow.Cells[0].Value);
            var kullanici = db.Urun.Where(x => x.UrunId == secilenId).FirstOrDefault();
            db.Urun.Remove(kullanici);
            db.SaveChanges();
            listelete();
        }

        public void listelete()
        {
            
            var kullanicilar = db.Urun.ToList();
            gridozel.DataSource = kullanicilar.ToList();
        }



        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridozel.Rows.Count>0)
            {
                tBarkod.Text = gridozel.CurrentRow.Cells["Barkod"].Value.ToString();
                tStandart2.Text = gridozel.CurrentRow.Cells["UrunAd"].Value.ToString();
                tStandart3.Text = gridozel.CurrentRow.Cells["Aciklama"].Value.ToString();
                tNumeric1.Text = gridozel.CurrentRow.Cells["AlisFiyat"].Value.ToString();
                tNumeric2.Text = gridozel.CurrentRow.Cells["SatisFiyat"].Value.ToString();
                tNumeric3.Text = gridozel.CurrentRow.Cells["Miktar"].Value.ToString();
                tNumeric4.Text = gridozel.CurrentRow.Cells["KdvOrani"].Value.ToString();
                string birim = gridozel.CurrentRow.Cells["Birim"].Value.ToString();
            }
        }
        public void DatagridviewSetting(DataGridView datagridview)
        {
            gridozel.RowHeadersVisible = false;
            gridozel.BorderStyle=BorderStyle.None;
            gridozel.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            gridozel.DefaultCellStyle.SelectionBackColor = Color.White;
            gridozel.DefaultCellStyle.SelectionForeColor = Color.Black;
            gridozel.EnableHeadersVisualStyles = false;
            gridozel.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridozel.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            gridozel.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            gridozel.SelectionMode=DataGridViewSelectionMode.FullRowSelect; 
            gridozel.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {

        }

        private void bÇıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bStandart1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.FileName = DateTime.Now.ToString();
            save.DefaultExt = "pdf";
            save.Filter = "PDF Dosyaları (*.pdf)|*.pdf|Tüm Dosyalar(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                PdfPTable pdfTable = new PdfPTable(gridozel.ColumnCount);


                pdfTable.DefaultCell.Padding = 3;
                pdfTable.WidthPercentage = 80;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 1;


                foreach (DataGridViewColumn column in gridozel.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfTable.AddCell(cell);
                }
                try
                {
                    foreach (DataGridViewRow row in gridozel.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value.ToString());
                        }
                    }
                }
                catch (NullReferenceException)
                {
                }
                using (FileStream stream = new FileStream(save.FileName + ".pdf", FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }
                MessageBox.Show("Veriler PDF dosyasına aktarıldı", "durum");


            }
        }
    }
}
