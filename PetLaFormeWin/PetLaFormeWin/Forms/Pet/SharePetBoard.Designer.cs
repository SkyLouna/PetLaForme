namespace PetLaFormeWin.Forms
{
    partial class SharePetBoard
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
            this.lblShareTitle = new System.Windows.Forms.Label();
            this.lblPetTitle = new System.Windows.Forms.Label();
            this.lbUserPet = new System.Windows.Forms.ListBox();
            this.lblUserNick = new System.Windows.Forms.Label();
            this.tbUserNick = new System.Windows.Forms.TextBox();
            this.cbAllowModifications = new System.Windows.Forms.CheckBox();
            this.pbBtnStopShare = new System.Windows.Forms.PictureBox();
            this.pbBtnShare = new System.Windows.Forms.PictureBox();
            this.pbPetImage = new System.Windows.Forms.PictureBox();
            this.pbBtnReturnToMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnStopShare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnShare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPetImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnReturnToMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblShareTitle
            // 
            this.lblShareTitle.AutoSize = true;
            this.lblShareTitle.Font = new System.Drawing.Font("Arial Narrow", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShareTitle.Location = new System.Drawing.Point(-10, 3);
            this.lblShareTitle.Name = "lblShareTitle";
            this.lblShareTitle.Size = new System.Drawing.Size(433, 57);
            this.lblShareTitle.TabIndex = 2;
            this.lblShareTitle.Text = " Partage                       ";
            // 
            // lblPetTitle
            // 
            this.lblPetTitle.AutoSize = true;
            this.lblPetTitle.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPetTitle.Location = new System.Drawing.Point(3, 226);
            this.lblPetTitle.Name = "lblPetTitle";
            this.lblPetTitle.Size = new System.Drawing.Size(400, 72);
            this.lblPetTitle.TabIndex = 8;
            this.lblPetTitle.Text = "  Nom du familier  \r\n\r\n                                                          " +
    "       ";
            this.lblPetTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbUserPet
            // 
            this.lbUserPet.FormattingEnabled = true;
            this.lbUserPet.Location = new System.Drawing.Point(117, 251);
            this.lbUserPet.Name = "lbUserPet";
            this.lbUserPet.Size = new System.Drawing.Size(169, 43);
            this.lbUserPet.TabIndex = 9;
            this.lbUserPet.SelectedIndexChanged += new System.EventHandler(this.lbUserPet_SelectedIndexChanged);
            // 
            // lblUserNick
            // 
            this.lblUserNick.AutoSize = true;
            this.lblUserNick.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNick.Location = new System.Drawing.Point(0, 364);
            this.lblUserNick.Name = "lblUserNick";
            this.lblUserNick.Size = new System.Drawing.Size(400, 72);
            this.lblUserNick.TabIndex = 10;
            this.lblUserNick.Text = "  Nom de l\'utilisateur  \r\n\r\n                                                     " +
    "            ";
            this.lblUserNick.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbUserNick
            // 
            this.tbUserNick.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbUserNick.Location = new System.Drawing.Point(7, 399);
            this.tbUserNick.Name = "tbUserNick";
            this.tbUserNick.Size = new System.Drawing.Size(385, 33);
            this.tbUserNick.TabIndex = 11;
            this.tbUserNick.Text = "Receiver UserNick";
            // 
            // cbAllowModifications
            // 
            this.cbAllowModifications.AutoSize = true;
            this.cbAllowModifications.Location = new System.Drawing.Point(7, 501);
            this.cbAllowModifications.Name = "cbAllowModifications";
            this.cbAllowModifications.Size = new System.Drawing.Size(147, 17);
            this.cbAllowModifications.TabIndex = 13;
            this.cbAllowModifications.Text = "Autoriser les modifications";
            this.cbAllowModifications.UseVisualStyleBackColor = true;
            this.cbAllowModifications.CheckedChanged += new System.EventHandler(this.cbAllowModifications_CheckedChanged);
            // 
            // pbBtnStopShare
            // 
            this.pbBtnStopShare.Image = global::PetLaFormeWin.Properties.Resources.cancel_cloud;
            this.pbBtnStopShare.Location = new System.Drawing.Point(291, 2);
            this.pbBtnStopShare.Name = "pbBtnStopShare";
            this.pbBtnStopShare.Size = new System.Drawing.Size(50, 50);
            this.pbBtnStopShare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnStopShare.TabIndex = 14;
            this.pbBtnStopShare.TabStop = false;
            this.pbBtnStopShare.Click += new System.EventHandler(this.pbBtnStopShare_Click);
            // 
            // pbBtnShare
            // 
            this.pbBtnShare.Image = global::PetLaFormeWin.Properties.Resources.allow_cloud;
            this.pbBtnShare.Location = new System.Drawing.Point(136, 560);
            this.pbBtnShare.Name = "pbBtnShare";
            this.pbBtnShare.Size = new System.Drawing.Size(128, 128);
            this.pbBtnShare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnShare.TabIndex = 12;
            this.pbBtnShare.TabStop = false;
            this.pbBtnShare.Click += new System.EventHandler(this.pbBtnShare_Click);
            // 
            // pbPetImage
            // 
            this.pbPetImage.Image = global::PetLaFormeWin.Properties.Resources.bone;
            this.pbPetImage.Location = new System.Drawing.Point(136, 70);
            this.pbPetImage.Name = "pbPetImage";
            this.pbPetImage.Size = new System.Drawing.Size(128, 128);
            this.pbPetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPetImage.TabIndex = 7;
            this.pbPetImage.TabStop = false;
            // 
            // pbBtnReturnToMenu
            // 
            this.pbBtnReturnToMenu.Image = global::PetLaFormeWin.Properties.Resources.returnToMenu;
            this.pbBtnReturnToMenu.Location = new System.Drawing.Point(347, 2);
            this.pbBtnReturnToMenu.Name = "pbBtnReturnToMenu";
            this.pbBtnReturnToMenu.Size = new System.Drawing.Size(50, 50);
            this.pbBtnReturnToMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnReturnToMenu.TabIndex = 6;
            this.pbBtnReturnToMenu.TabStop = false;
            this.pbBtnReturnToMenu.Click += new System.EventHandler(this.pbBtnReturnToMenu_Click);
            // 
            // SharePetBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 700);
            this.Controls.Add(this.pbBtnStopShare);
            this.Controls.Add(this.cbAllowModifications);
            this.Controls.Add(this.pbBtnShare);
            this.Controls.Add(this.tbUserNick);
            this.Controls.Add(this.lblUserNick);
            this.Controls.Add(this.lbUserPet);
            this.Controls.Add(this.lblPetTitle);
            this.Controls.Add(this.pbPetImage);
            this.Controls.Add(this.pbBtnReturnToMenu);
            this.Controls.Add(this.lblShareTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SharePetBoard";
            this.Text = "SharePetBoard";
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnStopShare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnShare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPetImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnReturnToMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblShareTitle;
        private System.Windows.Forms.PictureBox pbBtnReturnToMenu;
        private System.Windows.Forms.PictureBox pbPetImage;
        private System.Windows.Forms.Label lblPetTitle;
        private System.Windows.Forms.ListBox lbUserPet;
        private System.Windows.Forms.Label lblUserNick;
        private System.Windows.Forms.TextBox tbUserNick;
        private System.Windows.Forms.PictureBox pbBtnShare;
        private System.Windows.Forms.CheckBox cbAllowModifications;
        private System.Windows.Forms.PictureBox pbBtnStopShare;
    }
}