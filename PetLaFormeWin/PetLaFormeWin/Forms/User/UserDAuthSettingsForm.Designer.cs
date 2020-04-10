namespace PetLaFormeWin.Forms.User
{
    partial class UserDAuthSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDAuthSettingsForm));
            this.gbAboutBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbCodeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActivateDAuth = new System.Windows.Forms.Button();
            this.btnDesactivateDAuth = new System.Windows.Forms.Button();
            this.pbQRCode = new System.Windows.Forms.PictureBox();
            this.gbAboutBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAboutBox
            // 
            this.gbAboutBox.Controls.Add(this.textBox1);
            this.gbAboutBox.Location = new System.Drawing.Point(12, 12);
            this.gbAboutBox.Name = "gbAboutBox";
            this.gbAboutBox.Size = new System.Drawing.Size(407, 119);
            this.gbAboutBox.TabIndex = 2;
            this.gbAboutBox.TabStop = false;
            this.gbAboutBox.Text = "À propos";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(7, 20);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(394, 93);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // tbCodeBox
            // 
            this.tbCodeBox.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodeBox.Location = new System.Drawing.Point(276, 203);
            this.tbCodeBox.Name = "tbCodeBox";
            this.tbCodeBox.Size = new System.Drawing.Size(142, 31);
            this.tbCodeBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Code GAuthentificator";
            // 
            // btnActivateDAuth
            // 
            this.btnActivateDAuth.Location = new System.Drawing.Point(276, 240);
            this.btnActivateDAuth.Name = "btnActivateDAuth";
            this.btnActivateDAuth.Size = new System.Drawing.Size(142, 23);
            this.btnActivateDAuth.TabIndex = 6;
            this.btnActivateDAuth.Text = "Activer la double auth";
            this.btnActivateDAuth.UseVisualStyleBackColor = true;
            this.btnActivateDAuth.Click += new System.EventHandler(this.btnActivateDAuth_Click);
            // 
            // btnDesactivateDAuth
            // 
            this.btnDesactivateDAuth.Location = new System.Drawing.Point(276, 311);
            this.btnDesactivateDAuth.Name = "btnDesactivateDAuth";
            this.btnDesactivateDAuth.Size = new System.Drawing.Size(142, 23);
            this.btnDesactivateDAuth.TabIndex = 7;
            this.btnDesactivateDAuth.Text = "Désactiver la double auth";
            this.btnDesactivateDAuth.UseVisualStyleBackColor = true;
            this.btnDesactivateDAuth.Click += new System.EventHandler(this.btnDesactivateDAuth_Click);
            // 
            // pbQRCode
            // 
            this.pbQRCode.Location = new System.Drawing.Point(14, 138);
            this.pbQRCode.Name = "pbQRCode";
            this.pbQRCode.Size = new System.Drawing.Size(256, 256);
            this.pbQRCode.TabIndex = 3;
            this.pbQRCode.TabStop = false;
            // 
            // UserDAuthSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(431, 400);
            this.Controls.Add(this.btnDesactivateDAuth);
            this.Controls.Add(this.btnActivateDAuth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCodeBox);
            this.Controls.Add(this.pbQRCode);
            this.Controls.Add(this.gbAboutBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserDAuthSettingsForm";
            this.Text = "Pet La Forme - Double Authentification";
            this.gbAboutBox.ResumeLayout(false);
            this.gbAboutBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAboutBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pbQRCode;
        private System.Windows.Forms.TextBox tbCodeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActivateDAuth;
        private System.Windows.Forms.Button btnDesactivateDAuth;
    }
}