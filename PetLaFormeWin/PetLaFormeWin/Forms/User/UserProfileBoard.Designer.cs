namespace PetLaFormeWin.Forms
{
    partial class UserProfileBoard
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
            this.lblProfileTitle = new System.Windows.Forms.Label();
            this.lblNickTitle = new System.Windows.Forms.Label();
            this.lblUserNameSurnameTitle = new System.Windows.Forms.Label();
            this.lblUserEmailTitle = new System.Windows.Forms.Label();
            this.lblPasswordTitle = new System.Windows.Forms.Label();
            this.tbUserNick = new System.Windows.Forms.TextBox();
            this.tbUserSurname = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbUserEmail = new System.Windows.Forms.TextBox();
            this.tbUserPassword = new System.Windows.Forms.TextBox();
            this.tbUserPasswordConfirm = new System.Windows.Forms.TextBox();
            this.pbBtnHideMenu = new System.Windows.Forms.PictureBox();
            this.pbBtnSave = new System.Windows.Forms.PictureBox();
            this.pbBtnLogout = new System.Windows.Forms.PictureBox();
            this.dAuthBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnHideMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dAuthBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProfileTitle
            // 
            this.lblProfileTitle.AutoSize = true;
            this.lblProfileTitle.Font = new System.Drawing.Font("Arial Narrow", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfileTitle.Location = new System.Drawing.Point(-10, 3);
            this.lblProfileTitle.Name = "lblProfileTitle";
            this.lblProfileTitle.Size = new System.Drawing.Size(426, 57);
            this.lblProfileTitle.TabIndex = 1;
            this.lblProfileTitle.Text = " Mon Profil                  ";
            // 
            // lblNickTitle
            // 
            this.lblNickTitle.AutoSize = true;
            this.lblNickTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNickTitle.Location = new System.Drawing.Point(23, 88);
            this.lblNickTitle.Name = "lblNickTitle";
            this.lblNickTitle.Size = new System.Drawing.Size(355, 66);
            this.lblNickTitle.TabIndex = 3;
            this.lblNickTitle.Text = "Nom d\'utilisateur\r\n\r\n                                                            " +
    "         ";
            this.lblNickTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUserNameSurnameTitle
            // 
            this.lblUserNameSurnameTitle.AutoSize = true;
            this.lblUserNameSurnameTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNameSurnameTitle.Location = new System.Drawing.Point(23, 184);
            this.lblUserNameSurnameTitle.Name = "lblUserNameSurnameTitle";
            this.lblUserNameSurnameTitle.Size = new System.Drawing.Size(355, 66);
            this.lblUserNameSurnameTitle.TabIndex = 4;
            this.lblUserNameSurnameTitle.Text = "Nom                           Prénom                    \r\n\r\n                     " +
    "                                                ";
            this.lblUserNameSurnameTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUserEmailTitle
            // 
            this.lblUserEmailTitle.AutoSize = true;
            this.lblUserEmailTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserEmailTitle.Location = new System.Drawing.Point(23, 280);
            this.lblUserEmailTitle.Name = "lblUserEmailTitle";
            this.lblUserEmailTitle.Size = new System.Drawing.Size(355, 66);
            this.lblUserEmailTitle.TabIndex = 5;
            this.lblUserEmailTitle.Text = "Adresse E-Mail\r\n\r\n                                                               " +
    "      ";
            this.lblUserEmailTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPasswordTitle
            // 
            this.lblPasswordTitle.AutoSize = true;
            this.lblPasswordTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordTitle.Location = new System.Drawing.Point(23, 375);
            this.lblPasswordTitle.Name = "lblPasswordTitle";
            this.lblPasswordTitle.Size = new System.Drawing.Size(355, 110);
            this.lblPasswordTitle.TabIndex = 6;
            this.lblPasswordTitle.Text = "Mot de Passe\r\n\r\nNouveau                    Confirmer                 \r\n\r\n        " +
    "                                                             ";
            this.lblPasswordTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbUserNick
            // 
            this.tbUserNick.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbUserNick.Location = new System.Drawing.Point(27, 118);
            this.tbUserNick.Name = "tbUserNick";
            this.tbUserNick.ReadOnly = true;
            this.tbUserNick.Size = new System.Drawing.Size(345, 33);
            this.tbUserNick.TabIndex = 7;
            this.tbUserNick.Text = "My UserNick";
            // 
            // tbUserSurname
            // 
            this.tbUserSurname.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbUserSurname.Location = new System.Drawing.Point(26, 214);
            this.tbUserSurname.Name = "tbUserSurname";
            this.tbUserSurname.Size = new System.Drawing.Size(165, 33);
            this.tbUserSurname.TabIndex = 8;
            this.tbUserSurname.Text = "My Username";
            // 
            // tbUserName
            // 
            this.tbUserName.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbUserName.Location = new System.Drawing.Point(206, 214);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(165, 33);
            this.tbUserName.TabIndex = 9;
            this.tbUserName.Text = "My UserSurname";
            // 
            // tbUserEmail
            // 
            this.tbUserEmail.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbUserEmail.Location = new System.Drawing.Point(27, 309);
            this.tbUserEmail.Name = "tbUserEmail";
            this.tbUserEmail.Size = new System.Drawing.Size(345, 33);
            this.tbUserEmail.TabIndex = 10;
            this.tbUserEmail.Text = "My UserEmail";
            // 
            // tbUserPassword
            // 
            this.tbUserPassword.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbUserPassword.Location = new System.Drawing.Point(27, 449);
            this.tbUserPassword.Name = "tbUserPassword";
            this.tbUserPassword.PasswordChar = 'X';
            this.tbUserPassword.Size = new System.Drawing.Size(165, 33);
            this.tbUserPassword.TabIndex = 11;
            this.tbUserPassword.Text = "My Password";
            // 
            // tbUserPasswordConfirm
            // 
            this.tbUserPasswordConfirm.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbUserPasswordConfirm.Location = new System.Drawing.Point(206, 449);
            this.tbUserPasswordConfirm.Name = "tbUserPasswordConfirm";
            this.tbUserPasswordConfirm.PasswordChar = 'X';
            this.tbUserPasswordConfirm.Size = new System.Drawing.Size(165, 33);
            this.tbUserPasswordConfirm.TabIndex = 12;
            this.tbUserPasswordConfirm.Text = "My Password";
            // 
            // pbBtnHideMenu
            // 
            this.pbBtnHideMenu.Image = global::PetLaFormeWin.Properties.Resources.rewind_double_arrows_angles;
            this.pbBtnHideMenu.Location = new System.Drawing.Point(100, 600);
            this.pbBtnHideMenu.Name = "pbBtnHideMenu";
            this.pbBtnHideMenu.Size = new System.Drawing.Size(70, 70);
            this.pbBtnHideMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnHideMenu.TabIndex = 13;
            this.pbBtnHideMenu.TabStop = false;
            this.pbBtnHideMenu.Click += new System.EventHandler(this.pbBtnHideMenu_Click);
            // 
            // pbBtnSave
            // 
            this.pbBtnSave.Image = global::PetLaFormeWin.Properties.Resources.check;
            this.pbBtnSave.Location = new System.Drawing.Point(230, 600);
            this.pbBtnSave.Name = "pbBtnSave";
            this.pbBtnSave.Size = new System.Drawing.Size(70, 70);
            this.pbBtnSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnSave.TabIndex = 2;
            this.pbBtnSave.TabStop = false;
            this.pbBtnSave.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pbBtnLogout
            // 
            this.pbBtnLogout.Image = global::PetLaFormeWin.Properties.Resources.logout;
            this.pbBtnLogout.Location = new System.Drawing.Point(348, 2);
            this.pbBtnLogout.Name = "pbBtnLogout";
            this.pbBtnLogout.Size = new System.Drawing.Size(50, 50);
            this.pbBtnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnLogout.TabIndex = 0;
            this.pbBtnLogout.TabStop = false;
            this.pbBtnLogout.Click += new System.EventHandler(this.pbBtnLogout_Click);
            // 
            // dAuthBtn
            // 
            this.dAuthBtn.Image = global::PetLaFormeWin.Properties.Resources.dauth_unlocked;
            this.dAuthBtn.Location = new System.Drawing.Point(292, 2);
            this.dAuthBtn.Name = "dAuthBtn";
            this.dAuthBtn.Size = new System.Drawing.Size(50, 50);
            this.dAuthBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dAuthBtn.TabIndex = 14;
            this.dAuthBtn.TabStop = false;
            this.dAuthBtn.Click += new System.EventHandler(this.dAuthBtn_Click);
            // 
            // UserProfileBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(400, 700);
            this.Controls.Add(this.dAuthBtn);
            this.Controls.Add(this.pbBtnHideMenu);
            this.Controls.Add(this.tbUserPasswordConfirm);
            this.Controls.Add(this.tbUserPassword);
            this.Controls.Add(this.tbUserEmail);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.tbUserSurname);
            this.Controls.Add(this.tbUserNick);
            this.Controls.Add(this.lblPasswordTitle);
            this.Controls.Add(this.lblUserEmailTitle);
            this.Controls.Add(this.lblUserNameSurnameTitle);
            this.Controls.Add(this.lblNickTitle);
            this.Controls.Add(this.pbBtnSave);
            this.Controls.Add(this.pbBtnLogout);
            this.Controls.Add(this.lblProfileTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserProfileBoard";
            this.Text = "UserProfileBoard";
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnHideMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dAuthBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBtnLogout;
        private System.Windows.Forms.Label lblProfileTitle;
        private System.Windows.Forms.PictureBox pbBtnSave;
        private System.Windows.Forms.Label lblNickTitle;
        private System.Windows.Forms.Label lblUserNameSurnameTitle;
        private System.Windows.Forms.Label lblUserEmailTitle;
        private System.Windows.Forms.Label lblPasswordTitle;
        private System.Windows.Forms.TextBox tbUserNick;
        private System.Windows.Forms.TextBox tbUserSurname;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbUserEmail;
        private System.Windows.Forms.TextBox tbUserPassword;
        private System.Windows.Forms.TextBox tbUserPasswordConfirm;
        private System.Windows.Forms.PictureBox pbBtnHideMenu;
        private System.Windows.Forms.PictureBox dAuthBtn;
    }
}