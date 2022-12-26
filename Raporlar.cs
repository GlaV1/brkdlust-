using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace BarkodluSatis
{
    internal class Raporlar
    {
        public static string Baslik { get; set; }

        public static string TarihBaslangic { get; set; }

        public static string TarihBitis { get; set; }
        
        public static string SatisNakit { get; set; }
        public static string Satiskart { get; set; }
        
        public static string İadeNakit { get; set; }
        
        public static string İadeKart { get; set; }
        
        public static string GelirKart { get; set; }
        
        public static string GelirNakit { get; set; }

        public static string GiderNakit { get; set; }
        
        public static string GiderKart { get; set; }

        public static string KdvToplam  { get; set; }

        internal static void RaporSayfasiRaporu(DataGridView dgv)
        {
            Cursor.Current= Cursors.WaitCursor;
            List<Ozet> list = new List<Ozet>();
            list.Clear();
            for (int i = 0; i < dgv.Rows.Count; i++)
            { 
                list.Add(new Ozet
                {
                    İslemNo = Convert.ToInt32(dgv.Rows[i].Cells["İslemNo"].Value.ToString()),
                    İade=Convert.ToBoolean(dgv.Rows[i].Cells["İade"].Value),
                    OdemeSekli= dgv.Rows[i].Cells["OdemeSekli"].Value.ToString(),
                    Nakit=Islemler.DoubleYap(dgv.Rows[i].Cells["Nakit"].Value.ToString()),
                    Kart=Islemler.DoubleYap(dgv.Rows[i].Cells["Kart"].Value.ToString()),
                    Gelir=Convert.ToBoolean(dgv.Rows[i].Cells["Gelir"].Value.ToString()),
                    Gider=Convert.ToBoolean(dgv.Rows[i].Cells["Gider"].Value.ToString()),
                    AlisFiyatToplam= Islemler.DoubleYap(dgv.Rows[i].Cells["AlisFiyatToplam"].Value.ToString()),
                    Acıklama = dgv.Rows[i].Cells["Acıklama"].Value.ToString(),
                    Tarih = Convert.ToDateTime(dgv.Rows[i].Cells["Tarih"].Value.ToString())
                });
                
            }
            
            ReportDataSource rs = new ReportDataSource();
            rs.Name = "dsGenelRapor";
            rs.Value = list;
            
            fRaporGoster dsa = new fRaporGoster();
            dsa.reportViewer1.LocalReport.DataSources.Clear();
            dsa.reportViewer1.LocalReport.DataSources.Add(rs);
            dsa.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Report1.rdlc";
                
            ReportParameter[] prm = new ReportParameter[12];
            prm[0] = new ReportParameter("Baslik", Baslik);
            prm[1] = new ReportParameter("BaslangicTarihi",TarihBaslangic );
            prm[2] = new ReportParameter("BitisTarihi",TarihBitis);
            prm[3] = new ReportParameter("SatisNakit",SatisNakit);
            prm[4] = new ReportParameter("SatisKart",Satiskart);
            prm[5] = new ReportParameter("İadeNakit",İadeNakit);
            prm[6] = new ReportParameter("İadeKart",İadeKart);
            prm[7] = new ReportParameter("GelirNakit",GelirNakit);
            prm[8] = new ReportParameter("GelirKart",GelirKart);
            prm[9] = new ReportParameter("GiderNakit",GiderNakit);
            prm[10] = new ReportParameter("GiderKart",GiderKart);
            prm[11] = new ReportParameter("KdvToplam", KdvToplam);
            dsa.reportViewer1.LocalReport.SetParameters(prm);
            dsa.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            dsa.reportViewer1.ZoomMode=ZoomMode.PageWidth;
            dsa.ShowDialog();
            Cursor.Current = Cursors.Default;

        }
        public static void pdfKaydet(DataGridView veriTablosu)
        {
            try
            {
                PdfPTable pdfTablosu = new PdfPTable(veriTablosu.ColumnCount);
                pdfTablosu.DefaultCell.Padding = 3;
                pdfTablosu.WidthPercentage = 100;
                pdfTablosu.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTablosu.DefaultCell.BorderWidth = 1;
                foreach (DataGridViewColumn sutun in veriTablosu.Columns)
                {
                    PdfPCell pdfHucresi = new PdfPCell(new Phrase(sutun.HeaderText));

                    pdfTablosu.AddCell(pdfHucresi);
                }
                foreach (DataGridViewRow satir in veriTablosu.Rows)
                {
                    foreach (DataGridViewCell cell in satir.Cells)
                    {
                        pdfTablosu.AddCell(cell.Value.ToString());
                    }
                }

                SaveFileDialog dosyakaydet = new SaveFileDialog();
                dosyakaydet.FileName = "projePDfDosyaAdı";
                dosyakaydet.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                dosyakaydet.Filter = "PDF Dosyası|*.pdf";
                if (dosyakaydet.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(dosyakaydet.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(pdfTablosu);
                        pdfDoc.Close();
                        stream.Close();
                        MessageBox.Show("PDF dosyası başarıyla oluşturuldu!\n" + "Dosya Konumu: " + dosyakaydet.FileName, "İşlem Tamam");
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}
