namespace PetLaFormeWin.Forms
{
    partial class UserResetPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserResetPasswordForm));
            this.tbNickNameBox = new System.Windows.Forms.TextBox();
            this.tbResetCodeBox = new System.Windows.Forms.TextBox();
            this.lblNickNameTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPasswordConfirmBox = new System.Windows.Forms.TextBox();
            this.tbPasswordBox = new System.Windows.Forms.TextBox();
            this.gbAboutBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAskForNewCode = new System.Windows.Forms.Button();
            this.btnSavePassword = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbPasswordChangeAllow = new System.Windows.Forms.CheckBox();
            this.gbAboutBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbNickNameBox
            // 
            this.tbNickNameBox.Location = new System.Drawing.Point(9, 80);
            this.tbNickNameBox.Name = "tbNickNameBox";
            this.tbNickNameBox.Size = new System.Drawing.Size(375, 20);
            this.tbNickNameBox.TabIndex = 0;
            // 
            // tbResetCodeBox
            // 
            this.tbResetCodeBox.Location = new System.Drawing.Point(9, 139);
            this.tbResetCodeBox.Name = "tbResetCodeBox";
            this.tbResetCodeBox.Size = new System.Drawing.Size(375, 20);
            this.tbResetCodeBox.TabIndex = 1;
            // 
            // lblNickNameTitle
            // 
            this.lblNickNameTitle.AutoSize = true;
            this.lblNickNameTitle.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNickNameTitle.Location = new System.Drawing.Point(6, 57);
            this.lblNickNameTitle.Name = "lblNickNameTitle";
            this.lblNickNameTitle.Size = new System.Drawing.Size(383, 20);
            this.lblNickNameTitle.TabIndex = 2;
            this.lblNickNameTitle.Text = "Nom d\'utilisateur                                                                " +
    "     ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Code de restauration                                                             " +
    " ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Confirmer le mot de passe                                                     ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(381, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nouveau mot de passe                                                          ";
            // 
            // tbPasswordConfirmBox
            // 
            this.tbPasswordConfirmBox.Location = new System.Drawing.Point(10, 100);
            this.tbPasswordConfirmBox.Name = "tbPasswordConfirmBox";
            this.tbPasswordConfirmBox.PasswordChar = 'x';
            this.tbPasswordConfirmBox.Size = new System.Drawing.Size(373, 20);
            this.tbPasswordConfirmBox.TabIndex = 5;
            // 
            // tbPasswordBox
            // 
            this.tbPasswordBox.Location = new System.Drawing.Point(10, 41);
            this.tbPasswordBox.Name = "tbPasswordBox";
            this.tbPasswordBox.PasswordChar = 'x';
            this.tbPasswordBox.Size = new System.Drawing.Size(373, 20);
            this.tbPasswordBox.TabIndex = 4;
            // 
            // gbAboutBox
            // 
            this.gbAboutBox.Controls.Add(this.textBox1);
            this.gbAboutBox.Location = new System.Drawing.Point(12, 12);
            this.gbAboutBox.Name = "gbAboutBox";
            this.gbAboutBox.Size = new System.Drawing.Size(394, 78);
            this.gbAboutBox.TabIndex = 8;
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
            this.textBox1.Size = new System.Drawing.Size(377, 56);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // btnAskForNewCode
            // 
            this.btnAskForNewCode.Location = new System.Drawing.Point(69, 19);
            this.btnAskForNewCode.Name = "btnAskForNewCode";
            this.btnAskForNewCode.Size = new System.Drawing.Size(231, 23);
            this.btnAskForNewCode.TabIndex = 9;
            this.btnAskForNewCode.Text = "Nouveau code de restauration";
            this.btnAskForNewCode.UseVisualStyleBackColor = true;
            this.btnAskForNewCode.Click += new System.EventHandler(this.btnAskForNewCode_Click);
            // 
            // btnSavePassword
            // 
            this.btnSavePassword.Location = new System.Drawing.Point(69, 42);
            this.btnSavePassword.Name = "btnSavePassword";
            this.btnSavePassword.Size = new System.Drawing.Size(231, 23);
            this.btnSavePassword.TabIndex = 10;
            this.btnSavePassword.Text = "Sauvegarder le nouveau mot de passe";
            this.btnSavePassword.UseVisualStyleBackColor = true;
            this.btnSavePassword.Click += new System.EventHandler(this.btnSavePassword_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAskForNewCode);
            this.groupBox1.Controls.Add(this.lblNickNameTitle);
            this.groupBox1.Controls.Add(this.tbNickNameBox);
            this.groupBox1.Controls.Add(this.tbResetCodeBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 166);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Etape 1: Demander un code de restauration";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbPasswordBox);
            this.groupBox2.Controls.Add(this.tbPasswordConfirmBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 266);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 130);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Etape 2: Choisir un nouveau mot de passe";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbPasswordChangeAllow);
            this.groupBox3.Controls.Add(this.btnSavePassword);
            this.groupBox3.Location = new System.Drawing.Point(12, 402);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(394, 74);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Etape 3: Valider le changement de mot de passe";
            // 
            // cbPasswordChangeAllow
            // 
            this.cbPasswordChangeAllow.AutoSize = true;
            this.cbPasswordChangeAllow.Location = new System.Drawing.Point(6, 19);
            this.cbPasswordChangeAllow.Name = "cbPasswordChangeAllow";
            this.cbPasswordChangeAllow.Size = new System.Drawing.Size(257, 17);
            this.cbPasswordChangeAllow.TabIndex = 11;
            this.cbPasswordChangeAllow.Text = "Je confirme le changement de mon mot de passe";
            this.cbPasswordChangeAllow.UseVisualStyleBackColor = true;
            // 
            // UserResetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(417, 481);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbAboutBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserResetPasswordForm";
            this.Text = "Pet La Forme - Récupération de mot de passe";
            this.gbAboutBox.ResumeLayout(false);
            this.gbAboutBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbNickNameBox;
        private System.Windows.Forms.TextBox tbResetCodeBox;
        private System.Windows.Forms.Label lblNickNameTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPasswordConfirmBox;
        private System.Windows.Forms.TextBox tbPasswordBox;
        private System.Windows.Forms.GroupBox gbAboutBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAskForNewCode;
        private System.Windows.Forms.Button btnSavePassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbPasswordChangeAllow;
    }
}