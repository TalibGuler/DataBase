﻿namespace BankaUygulamasi
{
    partial class KrediForm
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
            this.tboxTutar = new System.Windows.Forms.TextBox();
            this.cboxType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFaizOrani = new System.Windows.Forms.Label();
            this.btnKrediCek = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tboxTutar
            // 
            this.tboxTutar.Location = new System.Drawing.Point(115, 37);
            this.tboxTutar.Name = "tboxTutar";
            this.tboxTutar.Size = new System.Drawing.Size(121, 20);
            this.tboxTutar.TabIndex = 2;
            // 
            // cboxType
            // 
            this.cboxType.FormattingEnabled = true;
            this.cboxType.Location = new System.Drawing.Point(115, 10);
            this.cboxType.Name = "cboxType";
            this.cboxType.Size = new System.Drawing.Size(121, 21);
            this.cboxType.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kredi Tipi : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kredi Tutarı : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Faiz Oranı : ";
            // 
            // lblFaizOrani
            // 
            this.lblFaizOrani.AutoSize = true;
            this.lblFaizOrani.Location = new System.Drawing.Point(349, 18);
            this.lblFaizOrani.Name = "lblFaizOrani";
            this.lblFaizOrani.Size = new System.Drawing.Size(35, 13);
            this.lblFaizOrani.TabIndex = 7;
            this.lblFaizOrani.Text = "label4";
            // 
            // btnKrediCek
            // 
            this.btnKrediCek.Location = new System.Drawing.Point(250, 37);
            this.btnKrediCek.Name = "btnKrediCek";
            this.btnKrediCek.Size = new System.Drawing.Size(134, 23);
            this.btnKrediCek.TabIndex = 8;
            this.btnKrediCek.Text = "KREDI CEK";
            this.btnKrediCek.UseVisualStyleBackColor = true;
            this.btnKrediCek.Click += new System.EventHandler(this.BtnKrediCek_Click);
            // 
            // KrediForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 80);
            this.Controls.Add(this.btnKrediCek);
            this.Controls.Add(this.lblFaizOrani);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxType);
            this.Controls.Add(this.tboxTutar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "KrediForm";
            this.Text = "KrediForm";
            this.Load += new System.EventHandler(this.KrediForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboxTutar;
        private System.Windows.Forms.ComboBox cboxType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFaizOrani;
        private System.Windows.Forms.Button btnKrediCek;
    }
}