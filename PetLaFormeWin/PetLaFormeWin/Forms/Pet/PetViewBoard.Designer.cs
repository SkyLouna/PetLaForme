namespace PetLaFormeWin.Forms
{
    partial class PetViewBoard
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
            this.gbPetInfoContainer = new System.Windows.Forms.GroupBox();
            this.lblBtnDeletePet = new System.Windows.Forms.Label();
            this.lblBtnSharePetTitle = new System.Windows.Forms.Label();
            this.tbPetType = new System.Windows.Forms.TextBox();
            this.tbPetName = new System.Windows.Forms.TextBox();
            this.lblPetTypeTitle = new System.Windows.Forms.Label();
            this.lblPetNameTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbAttributBox = new System.Windows.Forms.GroupBox();
            this.gbPageControll = new System.Windows.Forms.GroupBox();
            this.pbBtnBackToMenu = new System.Windows.Forms.PictureBox();
            this.pbBtnDeletePet = new System.Windows.Forms.PictureBox();
            this.pbBtnSharePet = new System.Windows.Forms.PictureBox();
            this.pbPetImage = new System.Windows.Forms.PictureBox();
            this.pbBtnLeftPage = new System.Windows.Forms.PictureBox();
            this.pbBtnRightPage = new System.Windows.Forms.PictureBox();
            this.lblPageNav = new System.Windows.Forms.Label();
            this.gbPetInfoContainer.SuspendLayout();
            this.gbAttributBox.SuspendLayout();
            this.gbPageControll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnBackToMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnDeletePet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnSharePet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPetImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnLeftPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnRightPage)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPetInfoContainer
            // 
            this.gbPetInfoContainer.Controls.Add(this.pbBtnBackToMenu);
            this.gbPetInfoContainer.Controls.Add(this.pbBtnDeletePet);
            this.gbPetInfoContainer.Controls.Add(this.lblBtnDeletePet);
            this.gbPetInfoContainer.Controls.Add(this.pbBtnSharePet);
            this.gbPetInfoContainer.Controls.Add(this.lblBtnSharePetTitle);
            this.gbPetInfoContainer.Controls.Add(this.tbPetType);
            this.gbPetInfoContainer.Controls.Add(this.tbPetName);
            this.gbPetInfoContainer.Controls.Add(this.lblPetTypeTitle);
            this.gbPetInfoContainer.Controls.Add(this.lblPetNameTitle);
            this.gbPetInfoContainer.Controls.Add(this.pbPetImage);
            this.gbPetInfoContainer.Location = new System.Drawing.Point(-1, 58);
            this.gbPetInfoContainer.Name = "gbPetInfoContainer";
            this.gbPetInfoContainer.Size = new System.Drawing.Size(1180, 160);
            this.gbPetInfoContainer.TabIndex = 1;
            this.gbPetInfoContainer.TabStop = false;
            // 
            // lblBtnDeletePet
            // 
            this.lblBtnDeletePet.AutoSize = true;
            this.lblBtnDeletePet.Font = new System.Drawing.Font("Arial Narrow", 27.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBtnDeletePet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBtnDeletePet.Location = new System.Drawing.Point(536, 112);
            this.lblBtnDeletePet.Name = "lblBtnDeletePet";
            this.lblBtnDeletePet.Size = new System.Drawing.Size(260, 43);
            this.lblBtnDeletePet.TabIndex = 12;
            this.lblBtnDeletePet.Text = "          Supprimer ";
            this.lblBtnDeletePet.Click += new System.EventHandler(this.lblBtnDeletePet_Click);
            // 
            // lblBtnSharePetTitle
            // 
            this.lblBtnSharePetTitle.AutoSize = true;
            this.lblBtnSharePetTitle.Font = new System.Drawing.Font("Arial Narrow", 27.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBtnSharePetTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBtnSharePetTitle.Location = new System.Drawing.Point(537, 37);
            this.lblBtnSharePetTitle.Name = "lblBtnSharePetTitle";
            this.lblBtnSharePetTitle.Size = new System.Drawing.Size(267, 43);
            this.lblBtnSharePetTitle.TabIndex = 11;
            this.lblBtnSharePetTitle.Text = "               Partage  ";
            this.lblBtnSharePetTitle.Click += new System.EventHandler(this.lblBtnSharePetTitle_Click);
            // 
            // tbPetType
            // 
            this.tbPetType.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbPetType.Location = new System.Drawing.Point(235, 112);
            this.tbPetType.Name = "tbPetType";
            this.tbPetType.ReadOnly = true;
            this.tbPetType.Size = new System.Drawing.Size(279, 33);
            this.tbPetType.TabIndex = 9;
            this.tbPetType.Text = "My Pet Type";
            // 
            // tbPetName
            // 
            this.tbPetName.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbPetName.Location = new System.Drawing.Point(235, 38);
            this.tbPetName.Name = "tbPetName";
            this.tbPetName.ReadOnly = true;
            this.tbPetName.Size = new System.Drawing.Size(279, 33);
            this.tbPetName.TabIndex = 8;
            this.tbPetName.Text = "My Pet";
            // 
            // lblPetTypeTitle
            // 
            this.lblPetTypeTitle.AutoSize = true;
            this.lblPetTypeTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPetTypeTitle.Location = new System.Drawing.Point(233, 92);
            this.lblPetTypeTitle.Name = "lblPetTypeTitle";
            this.lblPetTypeTitle.Size = new System.Drawing.Size(284, 54);
            this.lblPetTypeTitle.TabIndex = 5;
            this.lblPetTypeTitle.Text = "Type de compagnon\r\n\r\n                                                            " +
    "         ";
            // 
            // lblPetNameTitle
            // 
            this.lblPetNameTitle.AutoSize = true;
            this.lblPetNameTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPetNameTitle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblPetNameTitle.Location = new System.Drawing.Point(233, 18);
            this.lblPetNameTitle.Name = "lblPetNameTitle";
            this.lblPetNameTitle.Size = new System.Drawing.Size(284, 54);
            this.lblPetNameTitle.TabIndex = 4;
            this.lblPetNameTitle.Text = "Nom du compagnon\r\n\r\n                                                             " +
    "        ";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial Narrow", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(-10, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1208, 57);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = " Mes animaux                                                                     " +
    "               ";
            // 
            // gbAttributBox
            // 
            this.gbAttributBox.Controls.Add(this.gbPageControll);
            this.gbAttributBox.Location = new System.Drawing.Point(-2, 221);
            this.gbAttributBox.Name = "gbAttributBox";
            this.gbAttributBox.Size = new System.Drawing.Size(1180, 480);
            this.gbAttributBox.TabIndex = 3;
            this.gbAttributBox.TabStop = false;
            // 
            // gbPageControll
            // 
            this.gbPageControll.Controls.Add(this.lblPageNav);
            this.gbPageControll.Controls.Add(this.pbBtnRightPage);
            this.gbPageControll.Controls.Add(this.pbBtnLeftPage);
            this.gbPageControll.Location = new System.Drawing.Point(253, 407);
            this.gbPageControll.Name = "gbPageControll";
            this.gbPageControll.Size = new System.Drawing.Size(300, 60);
            this.gbPageControll.TabIndex = 0;
            this.gbPageControll.TabStop = false;
            // 
            // pbBtnBackToMenu
            // 
            this.pbBtnBackToMenu.Image = global::PetLaFormeWin.Properties.Resources.returnToMenu;
            this.pbBtnBackToMenu.Location = new System.Drawing.Point(6, 38);
            this.pbBtnBackToMenu.Name = "pbBtnBackToMenu";
            this.pbBtnBackToMenu.Size = new System.Drawing.Size(80, 80);
            this.pbBtnBackToMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnBackToMenu.TabIndex = 13;
            this.pbBtnBackToMenu.TabStop = false;
            this.pbBtnBackToMenu.Click += new System.EventHandler(this.pbBtnBackToMenu_Click);
            // 
            // pbBtnDeletePet
            // 
            this.pbBtnDeletePet.Image = global::PetLaFormeWin.Properties.Resources.garbage;
            this.pbBtnDeletePet.Location = new System.Drawing.Point(544, 86);
            this.pbBtnDeletePet.Name = "pbBtnDeletePet";
            this.pbBtnDeletePet.Size = new System.Drawing.Size(64, 64);
            this.pbBtnDeletePet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnDeletePet.TabIndex = 10;
            this.pbBtnDeletePet.TabStop = false;
            this.pbBtnDeletePet.Click += new System.EventHandler(this.pbBtnDeletePet_Click);
            // 
            // pbBtnSharePet
            // 
            this.pbBtnSharePet.Image = global::PetLaFormeWin.Properties.Resources.share2;
            this.pbBtnSharePet.Location = new System.Drawing.Point(544, 11);
            this.pbBtnSharePet.Name = "pbBtnSharePet";
            this.pbBtnSharePet.Size = new System.Drawing.Size(64, 64);
            this.pbBtnSharePet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnSharePet.TabIndex = 2;
            this.pbBtnSharePet.TabStop = false;
            this.pbBtnSharePet.Click += new System.EventHandler(this.pbBtnSharePet_Click);
            // 
            // pbPetImage
            // 
            this.pbPetImage.Image = global::PetLaFormeWin.Properties.Resources.bone;
            this.pbPetImage.Location = new System.Drawing.Point(101, 18);
            this.pbPetImage.Name = "pbPetImage";
            this.pbPetImage.Size = new System.Drawing.Size(128, 128);
            this.pbPetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPetImage.TabIndex = 0;
            this.pbPetImage.TabStop = false;
            // 
            // pbBtnLeftPage
            // 
            this.pbBtnLeftPage.Image = global::PetLaFormeWin.Properties.Resources.left_arrow;
            this.pbBtnLeftPage.Location = new System.Drawing.Point(3, 8);
            this.pbBtnLeftPage.Name = "pbBtnLeftPage";
            this.pbBtnLeftPage.Size = new System.Drawing.Size(49, 49);
            this.pbBtnLeftPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnLeftPage.TabIndex = 0;
            this.pbBtnLeftPage.TabStop = false;
            this.pbBtnLeftPage.Click += new System.EventHandler(this.pbBtnLeftPage_Click);
            // 
            // pbBtnRightPage
            // 
            this.pbBtnRightPage.Image = global::PetLaFormeWin.Properties.Resources.right_arrow;
            this.pbBtnRightPage.Location = new System.Drawing.Point(249, 8);
            this.pbBtnRightPage.Name = "pbBtnRightPage";
            this.pbBtnRightPage.Size = new System.Drawing.Size(49, 49);
            this.pbBtnRightPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnRightPage.TabIndex = 1;
            this.pbBtnRightPage.TabStop = false;
            this.pbBtnRightPage.Click += new System.EventHandler(this.pbBtnRightPage_Click);
            // 
            // lblPageNav
            // 
            this.lblPageNav.AutoSize = true;
            this.lblPageNav.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageNav.Location = new System.Drawing.Point(109, 10);
            this.lblPageNav.Name = "lblPageNav";
            this.lblPageNav.Size = new System.Drawing.Size(82, 45);
            this.lblPageNav.TabIndex = 2;
            this.lblPageNav.Text = "1 / 1";
            this.lblPageNav.Click += new System.EventHandler(this.lblPageNav_Click);
            // 
            // PetViewBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(785, 700);
            this.Controls.Add(this.gbAttributBox);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbPetInfoContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PetViewBoard";
            this.Text = "PetViewBoard";
            this.gbPetInfoContainer.ResumeLayout(false);
            this.gbPetInfoContainer.PerformLayout();
            this.gbAttributBox.ResumeLayout(false);
            this.gbPageControll.ResumeLayout(false);
            this.gbPageControll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnBackToMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnDeletePet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnSharePet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPetImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnLeftPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnRightPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPetImage;
        private System.Windows.Forms.GroupBox gbPetInfoContainer;
        private System.Windows.Forms.Label lblPetTypeTitle;
        private System.Windows.Forms.Label lblPetNameTitle;
        private System.Windows.Forms.TextBox tbPetName;
        private System.Windows.Forms.TextBox tbPetType;
        private System.Windows.Forms.PictureBox pbBtnDeletePet;
        private System.Windows.Forms.PictureBox pbBtnSharePet;
        private System.Windows.Forms.Label lblBtnSharePetTitle;
        private System.Windows.Forms.Label lblBtnDeletePet;
        private System.Windows.Forms.PictureBox pbBtnBackToMenu;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbAttributBox;
        private System.Windows.Forms.GroupBox gbPageControll;
        private System.Windows.Forms.PictureBox pbBtnLeftPage;
        private System.Windows.Forms.PictureBox pbBtnRightPage;
        private System.Windows.Forms.Label lblPageNav;
    }
}