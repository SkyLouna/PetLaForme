namespace PetLaFormeWin.Forms
{
    partial class UserAccountConfirmForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccountConfirmForm));
            this.gbAboutBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbUserCodeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActivateAccount = new System.Windows.Forms.Button();
            this.btnNewCode = new System.Windows.Forms.Button();
            this.gbAboutBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAboutBox
            // 
            this.gbAboutBox.Controls.Add(this.textBox1);
            this.gbAboutBox.Location = new System.Drawing.Point(12, 12);
            this.gbAboutBox.Name = "gbAboutBox";
            this.gbAboutBox.Size = new System.Drawing.Size(385, 73);
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
            this.textBox1.Size = new System.Drawing.Size(372, 45);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Lors de votre inscription un email a été envoyé a votre adresse mail.\r\nCelui ci c" +
    "ontient un code d\'activation. Veuillez le rentrer ci dessous puis appuier sur co" +
    "nfirmer mon compte.";
            // 
            // tbUserCodeBox
            // 
            this.tbUserCodeBox.Location = new System.Drawing.Point(65, 127);
            this.tbUserCodeBox.Name = "tbUserCodeBox";
            this.tbUserCodeBox.Size = new System.Drawing.Size(247, 20);
            this.tbUserCodeBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Code de confirmation";
            // 
            // btnActivateAccount
            // 
            this.btnActivateAccount.Location = new System.Drawing.Point(65, 153);
            this.btnActivateAccount.Name = "btnActivateAccount";
            this.btnActivateAccount.Size = new System.Drawing.Size(113, 23);
            this.btnActivateAccount.TabIndex = 5;
            this.btnActivateAccount.Text = "Activer mon compte";
            this.btnActivateAccount.UseVisualStyleBackColor = true;
            this.btnActivateAccount.Click += new System.EventHandler(this.btnActivateAccount_Click);
            // 
            // btnNewCode
            // 
            this.btnNewCode.Location = new System.Drawing.Point(199, 153);
            this.btnNewCode.Name = "btnNewCode";
            this.btnNewCode.Size = new System.Drawing.Size(113, 23);
            this.btnNewCode.TabIndex = 6;
            this.btnNewCode.Text = "Nouveau code";
            this.btnNewCode.UseVisualStyleBackColor = true;
            this.btnNewCode.Click += new System.EventHandler(this.btnNewCode_Click);
            // 
            // UserAccountConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 192);
            this.Controls.Add(this.btnNewCode);
            this.Controls.Add(this.btnActivateAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUserCodeBox);
            this.Controls.Add(this.gbAboutBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserAccountConfirmForm";
            this.Text = "Confimer mon compte";
            this.gbAboutBox.ResumeLayout(false);
            this.gbAboutBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAboutBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbUserCodeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActivateAccount;
        private System.Windows.Forms.Button btnNewCode;
    }
}