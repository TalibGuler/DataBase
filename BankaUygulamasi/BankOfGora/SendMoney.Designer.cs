namespace BankaUygulamasi
{
    partial class SendMoney
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
            this.cboxUser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tboxTutar = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.pbRun = new System.Windows.Forms.ProgressBar();
            this.lblPro = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboxUser
            // 
            this.cboxUser.FormattingEnabled = true;
            this.cboxUser.Location = new System.Drawing.Point(116, 6);
            this.cboxUser.Name = "cboxUser";
            this.cboxUser.Size = new System.Drawing.Size(121, 21);
            this.cboxUser.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gonderilecek Kişi : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tutar : ";
            // 
            // tboxTutar
            // 
            this.tboxTutar.Location = new System.Drawing.Point(116, 34);
            this.tboxTutar.Name = "tboxTutar";
            this.tboxTutar.Size = new System.Drawing.Size(121, 20);
            this.tboxTutar.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(162, 60);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "GONDER";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // pbRun
            // 
            this.pbRun.Location = new System.Drawing.Point(15, 96);
            this.pbRun.Name = "pbRun";
            this.pbRun.Size = new System.Drawing.Size(254, 32);
            this.pbRun.TabIndex = 5;
            // 
            // lblPro
            // 
            this.lblPro.AutoSize = true;
            this.lblPro.Location = new System.Drawing.Point(15, 77);
            this.lblPro.Name = "lblPro";
            this.lblPro.Size = new System.Drawing.Size(68, 13);
            this.lblPro.TabIndex = 6;
            this.lblPro.Text = "Processing...";
            // 
            // SendMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 146);
            this.Controls.Add(this.lblPro);
            this.Controls.Add(this.pbRun);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tboxTutar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "SendMoney";
            this.Text = "SendMoney";
            this.Load += new System.EventHandler(this.SendMoney_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tboxTutar;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ProgressBar pbRun;
        private System.Windows.Forms.Label lblPro;
    }
}