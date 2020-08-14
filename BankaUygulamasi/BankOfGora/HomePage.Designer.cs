namespace BankaUygulamasi
{
    partial class HomePage
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
            this.btnGoLogin = new System.Windows.Forms.Button();
            this.btnGoRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGoLogin
            // 
            this.btnGoLogin.Location = new System.Drawing.Point(12, 12);
            this.btnGoLogin.Name = "btnGoLogin";
            this.btnGoLogin.Size = new System.Drawing.Size(183, 57);
            this.btnGoLogin.TabIndex = 0;
            this.btnGoLogin.Text = "GİRİŞ YAP";
            this.btnGoLogin.UseVisualStyleBackColor = true;
            this.btnGoLogin.Click += new System.EventHandler(this.BtnGoLogin_Click);
            // 
            // btnGoRegister
            // 
            this.btnGoRegister.Location = new System.Drawing.Point(201, 12);
            this.btnGoRegister.Name = "btnGoRegister";
            this.btnGoRegister.Size = new System.Drawing.Size(183, 57);
            this.btnGoRegister.TabIndex = 2;
            this.btnGoRegister.Text = "KAYIT OL";
            this.btnGoRegister.UseVisualStyleBackColor = true;
            this.btnGoRegister.Click += new System.EventHandler(this.BtnGoRegister_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 92);
            this.Controls.Add(this.btnGoRegister);
            this.Controls.Add(this.btnGoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGoLogin;
        private System.Windows.Forms.Button btnGoRegister;
    }
}