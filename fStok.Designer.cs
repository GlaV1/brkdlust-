namespace BarkodluSatis
{
    partial class fStok
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fStok));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bÇıkıs = new System.Windows.Forms.Button();
            this.gridozel = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridozel)).BeginInit();
            this.SuspendLayout();
            // 
            // bÇıkıs
            // 
            this.bÇıkıs.BackColor = System.Drawing.Color.Maroon;
            this.bÇıkıs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bÇıkıs.Font = new System.Drawing.Font("Oswald", 24.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.bÇıkıs.ForeColor = System.Drawing.Color.White;
            this.bÇıkıs.Image = ((System.Drawing.Image)(resources.GetObject("bÇıkıs.Image")));
            this.bÇıkıs.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bÇıkıs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bÇıkıs.Location = new System.Drawing.Point(1621, 909);
            this.bÇıkıs.Margin = new System.Windows.Forms.Padding(0);
            this.bÇıkıs.Name = "bÇıkıs";
            this.bÇıkıs.Size = new System.Drawing.Size(290, 171);
            this.bÇıkıs.TabIndex = 0;
            this.bÇıkıs.Text = "ÇIKIŞ";
            this.bÇıkıs.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.bÇıkıs.UseVisualStyleBackColor = false;
            this.bÇıkıs.Click += new System.EventHandler(this.bÇıkıs_Click);
            // 
            // gridozel
            // 
            this.gridozel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridozel.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridozel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridozel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridozel.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridozel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridozel.Location = new System.Drawing.Point(0, 0);
            this.gridozel.Name = "gridozel";
            this.gridozel.RowHeadersVisible = false;
            this.gridozel.Size = new System.Drawing.Size(1920, 1080);
            this.gridozel.TabIndex = 35;
            this.gridozel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridozel_CellContentClick);
            // 
            // fStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.bÇıkıs);
            this.Controls.Add(this.gridozel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fStok";
            this.Text = "Stok İzleme";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fStok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridozel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bÇıkıs;
        public System.Windows.Forms.DataGridView gridozel;
    }
}