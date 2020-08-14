namespace BankaUygulamasi
{
    partial class HesapForm
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
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.lblKullaniciSoyadi = new System.Windows.Forms.Label();
            this.lblParaTL = new System.Windows.Forms.Label();
            this.lblParaUSD = new System.Windows.Forms.Label();
            this.lblParaEUR = new System.Windows.Forms.Label();
            this.lblParaSTR = new System.Windows.Forms.Label();
            this.btnOdeme = new System.Windows.Forms.Button();
            this.btnKredi = new System.Windows.Forms.Button();
            this.lblHesapAdi = new System.Windows.Forms.Label();
            this.lblUserType = new System.Windows.Forms.Label();
            this.lblHesapTuru = new System.Windows.Forms.Label();
            this.btnParaGonder = new System.Windows.Forms.Button();
            this.btnBorc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Location = new System.Drawing.Point(12, 39);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(22, 13);
            this.lblKullaniciAdi.TabIndex = 0;
            this.lblKullaniciAdi.Text = "Adi";
            // 
            // lblKullaniciSoyadi
            // 
            this.lblKullaniciSoyadi.AutoSize = true;
            this.lblKullaniciSoyadi.Location = new System.Drawing.Point(12, 59);
            this.lblKullaniciSoyadi.Name = "lblKullaniciSoyadi";
            this.lblKullaniciSoyadi.Size = new System.Drawing.Size(39, 13);
            this.lblKullaniciSoyadi.TabIndex = 1;
            this.lblKullaniciSoyadi.Text = "Soyadi";
            // 
            // lblParaTL
            // 
            this.lblParaTL.AutoSize = true;
            this.lblParaTL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParaTL.Location = new System.Drawing.Point(12, 122);
            this.lblParaTL.Name = "lblParaTL";
            this.lblParaTL.Size = new System.Drawing.Size(59, 17);
            this.lblParaTL.TabIndex = 2;
            this.lblParaTL.Text = "parasiTl";
            // 
            // lblParaUSD
            // 
            this.lblParaUSD.AutoSize = true;
            this.lblParaUSD.Location = new System.Drawing.Point(12, 152);
            this.lblParaUSD.Name = "lblParaUSD";
            this.lblParaUSD.Size = new System.Drawing.Size(35, 13);
            this.lblParaUSD.TabIndex = 3;
            this.lblParaUSD.Text = "label4";
            // 
            // lblParaEUR
            // 
            this.lblParaEUR.AutoSize = true;
            this.lblParaEUR.Location = new System.Drawing.Point(12, 171);
            this.lblParaEUR.Name = "lblParaEUR";
            this.lblParaEUR.Size = new System.Drawing.Size(35, 13);
            this.lblParaEUR.TabIndex = 4;
            this.lblParaEUR.Text = "label5";
            // 
            // lblParaSTR
            // 
            this.lblParaSTR.AutoSize = true;
            this.lblParaSTR.Location = new System.Drawing.Point(12, 190);
            this.lblParaSTR.Name = "lblParaSTR";
            this.lblParaSTR.Size = new System.Drawing.Size(35, 13);
            this.lblParaSTR.TabIndex = 5;
            this.lblParaSTR.Text = "label6";
            // 
            // btnOdeme
            // 
            this.btnOdeme.Location = new System.Drawing.Point(224, 171);
            this.btnOdeme.Name = "btnOdeme";
            this.btnOdeme.Size = new System.Drawing.Size(116, 23);
            this.btnOdeme.TabIndex = 6;
            this.btnOdeme.Text = "ODEME YAP";
            this.btnOdeme.UseVisualStyleBackColor = true;
            this.btnOdeme.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnKredi
            // 
            this.btnKredi.Location = new System.Drawing.Point(224, 200);
            this.btnKredi.Name = "btnKredi";
            this.btnKredi.Size = new System.Drawing.Size(116, 32);
            this.btnKredi.TabIndex = 7;
            this.btnKredi.Text = "KREDI CEK";
            this.btnKredi.UseVisualStyleBackColor = true;
            this.btnKredi.Click += new System.EventHandler(this.BtnKredi_Click);
            // 
            // lblHesapAdi
            // 
            this.lblHesapAdi.AutoSize = true;
            this.lblHesapAdi.Location = new System.Drawing.Point(135, 9);
            this.lblHesapAdi.Name = "lblHesapAdi";
            this.lblHesapAdi.Size = new System.Drawing.Size(53, 13);
            this.lblHesapAdi.TabIndex = 8;
            this.lblHesapAdi.Text = "HesapAdi";
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.Location = new System.Drawing.Point(12, 82);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(35, 13);
            this.lblUserType.TabIndex = 9;
            this.lblUserType.Text = "label1";
            // 
            // lblHesapTuru
            // 
            this.lblHesapTuru.AutoSize = true;
            this.lblHesapTuru.Location = new System.Drawing.Point(12, 219);
            this.lblHesapTuru.Name = "lblHesapTuru";
            this.lblHesapTuru.Size = new System.Drawing.Size(35, 13);
            this.lblHesapTuru.TabIndex = 10;
            this.lblHesapTuru.Text = "label1";
            // 
            // btnParaGonder
            // 
            this.btnParaGonder.Location = new System.Drawing.Point(224, 142);
            this.btnParaGonder.Name = "btnParaGonder";
            this.btnParaGonder.Size = new System.Drawing.Size(116, 23);
            this.btnParaGonder.TabIndex = 11;
            this.btnParaGonder.Text = "PARA GONDER";
            this.btnParaGonder.UseVisualStyleBackColor = true;
            this.btnParaGonder.Click += new System.EventHandler(this.BtnParaGonder_Click);
            // 
            // btnBorc
            // 
            this.btnBorc.Location = new System.Drawing.Point(224, 113);
            this.btnBorc.Name = "btnBorc";
            this.btnBorc.Size = new System.Drawing.Size(116, 23);
            this.btnBorc.TabIndex = 12;
            this.btnBorc.Text = "BORCLAR";
            this.btnBorc.UseVisualStyleBackColor = true;
            this.btnBorc.Click += new System.EventHandler(this.BtnBorc_Click);
            // 
            // HesapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 241);
            this.Controls.Add(this.btnBorc);
            this.Controls.Add(this.btnParaGonder);
            this.Controls.Add(this.lblHesapTuru);
            this.Controls.Add(this.lblUserType);
            this.Controls.Add(this.lblHesapAdi);
            this.Controls.Add(this.btnKredi);
            this.Controls.Add(this.btnOdeme);
            this.Controls.Add(this.lblParaSTR);
            this.Controls.Add(this.lblParaEUR);
            this.Controls.Add(this.lblParaUSD);
            this.Controls.Add(this.lblParaTL);
            this.Controls.Add(this.lblKullaniciSoyadi);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Name = "HesapForm";
            this.Text = "HesapForm";
            this.Load += new System.EventHandler(this.HesapForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.Label lblKullaniciSoyadi;
        private System.Windows.Forms.Label lblParaTL;
        private System.Windows.Forms.Label lblParaUSD;
        private System.Windows.Forms.Label lblParaEUR;
        private System.Windows.Forms.Label lblParaSTR;
        private System.Windows.Forms.Button btnOdeme;
        private System.Windows.Forms.Button btnKredi;
        private System.Windows.Forms.Label lblHesapAdi;
        private System.Windows.Forms.Label lblUserType;
        private System.Windows.Forms.Label lblHesapTuru;
        private System.Windows.Forms.Button btnParaGonder;
        private System.Windows.Forms.Button btnBorc;
    }
}