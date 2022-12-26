namespace BarkodluSatis
{
    partial class fGider
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fGider));
            this.bEkle = new System.Windows.Forms.Button();
            this.tarih = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cÖdemeTürü = new System.Windows.Forms.ComboBox();
            this.tKart = new System.Windows.Forms.TextBox();
            this.tNakit = new System.Windows.Forms.TextBox();
            this.tAçıklama = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bEkle
            // 
            this.bEkle.BackColor = System.Drawing.Color.Black;
            this.bEkle.FlatAppearance.BorderSize = 0;
            this.bEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bEkle.ForeColor = System.Drawing.Color.White;
            this.bEkle.Image = ((System.Drawing.Image)(resources.GetObject("bEkle.Image")));
            this.bEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEkle.Location = new System.Drawing.Point(21, 391);
            this.bEkle.Name = "bEkle";
            this.bEkle.Size = new System.Drawing.Size(200, 73);
            this.bEkle.TabIndex = 23;
            this.bEkle.Text = "EKLE";
            this.bEkle.UseVisualStyleBackColor = false;
            this.bEkle.Click += new System.EventHandler(this.bEkle_Click);
            // 
            // tarih
            // 
            this.tarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tarih.Location = new System.Drawing.Point(21, 359);
            this.tarih.Name = "tarih";
            this.tarih.Size = new System.Drawing.Size(200, 26);
            this.tarih.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(17, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Tarih";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(12, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Açıklama";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Nakit ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Ödeme Türü";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(118, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Kart";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "0";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cÖdemeTürü
            // 
            this.cÖdemeTürü.BackColor = System.Drawing.Color.Black;
            this.cÖdemeTürü.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cÖdemeTürü.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cÖdemeTürü.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cÖdemeTürü.ForeColor = System.Drawing.Color.White;
            this.cÖdemeTürü.FormattingEnabled = true;
            this.cÖdemeTürü.Items.AddRange(new object[] {
            "NAKİT",
            "KART"});
            this.cÖdemeTürü.Location = new System.Drawing.Point(16, 83);
            this.cÖdemeTürü.Name = "cÖdemeTürü";
            this.cÖdemeTürü.Size = new System.Drawing.Size(206, 28);
            this.cÖdemeTürü.TabIndex = 15;
            this.cÖdemeTürü.SelectedIndexChanged += new System.EventHandler(this.cÖdemeTürü_SelectedIndexChanged);
            // 
            // tKart
            // 
            this.tKart.BackColor = System.Drawing.Color.Black;
            this.tKart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tKart.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tKart.Enabled = false;
            this.tKart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tKart.ForeColor = System.Drawing.Color.White;
            this.tKart.Location = new System.Drawing.Point(122, 142);
            this.tKart.Multiline = true;
            this.tKart.Name = "tKart";
            this.tKart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tKart.Size = new System.Drawing.Size(100, 29);
            this.tKart.TabIndex = 14;
            this.tKart.Text = "0";
            this.tKart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tNakit
            // 
            this.tNakit.BackColor = System.Drawing.Color.Black;
            this.tNakit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tNakit.Enabled = false;
            this.tNakit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tNakit.ForeColor = System.Drawing.Color.White;
            this.tNakit.Location = new System.Drawing.Point(16, 142);
            this.tNakit.Multiline = true;
            this.tNakit.Name = "tNakit";
            this.tNakit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tNakit.Size = new System.Drawing.Size(100, 29);
            this.tNakit.TabIndex = 13;
            this.tNakit.Text = "0";
            this.tNakit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tAçıklama
            // 
            this.tAçıklama.BackColor = System.Drawing.Color.Black;
            this.tAçıklama.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tAçıklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tAçıklama.ForeColor = System.Drawing.Color.White;
            this.tAçıklama.Location = new System.Drawing.Point(16, 206);
            this.tAçıklama.Multiline = true;
            this.tAçıklama.Name = "tAçıklama";
            this.tAçıklama.Size = new System.Drawing.Size(206, 103);
            this.tAçıklama.TabIndex = 12;
            // 
            // fGider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(249, 469);
            this.Controls.Add(this.bEkle);
            this.Controls.Add(this.tarih);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cÖdemeTürü);
            this.Controls.Add(this.tKart);
            this.Controls.Add(this.tNakit);
            this.Controls.Add(this.tAçıklama);
            this.Name = "fGider";
            this.Text = "Gider";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bEkle;
        private System.Windows.Forms.DateTimePicker tarih;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cÖdemeTürü;
        private System.Windows.Forms.TextBox tKart;
        private System.Windows.Forms.TextBox tNakit;
        private System.Windows.Forms.TextBox tAçıklama;
    }
}