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
    public partial class fStok : Form
    {
        public fStok()
        {
            InitializeComponent();
            
        }
        BarkodDBEntities db = new BarkodDBEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            
                
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void chTumu_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void fStok_Load(object sender, EventArgs e)
        {
            gridozel.DataSource = db.Urun.ToList();
        }

        private void bÇıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridozel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
