using System.Drawing;

namespace PetLaFormeWin.Forms
{
    partial class PetsPreviewBoard
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
            this.gbHeaderBox = new System.Windows.Forms.GroupBox();
            this.pbBtnAddPet = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbPetList = new System.Windows.Forms.GroupBox();
            this.gbPetInfoContainer = new System.Windows.Forms.GroupBox();
            this.pbIsSharedPet = new System.Windows.Forms.PictureBox();
            this.pbBtnShowPet = new System.Windows.Forms.PictureBox();
            this.lblDeletePet = new System.Windows.Forms.Label();
            this.lblSharePetTitle = new System.Windows.Forms.Label();
            this.tbSelectedPetType = new System.Windows.Forms.TextBox();
            this.tbSelectedPetName = new System.Windows.Forms.TextBox();
            this.lblSelectedPetTypeTitle = new System.Windows.Forms.Label();
            this.lblSelectedPetNameTitle = new System.Windows.Forms.Label();
            this.pbSelectedPetImage = new System.Windows.Forms.PictureBox();
            this.gbPageControll = new System.Windows.Forms.GroupBox();
            this.lblPageNav = new System.Windows.Forms.Label();
            this.pbBtnRightPage = new System.Windows.Forms.PictureBox();
            this.pbBtnLeftPage = new System.Windows.Forms.PictureBox();
            this.gbHeaderBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnAddPet)).BeginInit();
            this.gbPetList.SuspendLayout();
            this.gbPetInfoContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIsSharedPet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnShowPet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedPetImage)).BeginInit();
            this.gbPageControll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnRightPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnLeftPage)).BeginInit();
            this.SuspendLayout();
            // 
            // gbHeaderBox
            // 
            this.gbHeaderBox.Controls.Add(this.pbBtnAddPet);
            this.gbHeaderBox.Controls.Add(this.lblTitle);
            this.gbHeaderBox.Location = new System.Drawing.Point(-1, -6);
            this.gbHeaderBox.Name = "gbHeaderBox";
            this.gbHeaderBox.Size = new System.Drawing.Size(1180, 65);
            this.gbHeaderBox.TabIndex = 0;
            this.gbHeaderBox.TabStop = false;
            // 
            // pbBtnAddPet
            // 
            this.pbBtnAddPet.Image = global::PetLaFormeWin.Properties.Resources.plus_button;
            this.pbBtnAddPet.Location = new System.Drawing.Point(734, 8);
            this.pbBtnAddPet.Name = "pbBtnAddPet";
            this.pbBtnAddPet.Size = new System.Drawing.Size(50, 50);
            this.pbBtnAddPet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnAddPet.TabIndex = 14;
            this.pbBtnAddPet.TabStop = false;
            this.pbBtnAddPet.Click += new System.EventHandler(this.pbBtnAddPet_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial Narrow", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(-9, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1208, 57);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = " Mes animaux                                                                     " +
    "               ";
            // 
            // gbPetList
            // 
            this.gbPetList.Controls.Add(this.gbPageControll);
            this.gbPetList.Location = new System.Drawing.Point(-3, 217);
            this.gbPetList.Name = "gbPetList";
            this.gbPetList.Size = new System.Drawing.Size(1180, 480);
            this.gbPetList.TabIndex = 1;
            this.gbPetList.TabStop = false;
            // 
            // gbPetInfoContainer
            // 
            this.gbPetInfoContainer.Controls.Add(this.pbIsSharedPet);
            this.gbPetInfoContainer.Controls.Add(this.pbBtnShowPet);
            this.gbPetInfoContainer.Controls.Add(this.lblDeletePet);
            this.gbPetInfoContainer.Controls.Add(this.lblSharePetTitle);
            this.gbPetInfoContainer.Controls.Add(this.tbSelectedPetType);
            this.gbPetInfoContainer.Controls.Add(this.tbSelectedPetName);
            this.gbPetInfoContainer.Controls.Add(this.lblSelectedPetTypeTitle);
            this.gbPetInfoContainer.Controls.Add(this.lblSelectedPetNameTitle);
            this.gbPetInfoContainer.Controls.Add(this.pbSelectedPetImage);
            this.gbPetInfoContainer.Location = new System.Drawing.Point(-3, 56);
            this.gbPetInfoContainer.Name = "gbPetInfoContainer";
            this.gbPetInfoContainer.Size = new System.Drawing.Size(1180, 160);
            this.gbPetInfoContainer.TabIndex = 2;
            this.gbPetInfoContainer.TabStop = false;
            // 
            // pbIsSharedPet
            // 
            this.pbIsSharedPet.BackColor = System.Drawing.Color.Transparent;
            this.pbIsSharedPet.Image = global::PetLaFormeWin.Properties.Resources.share;
            this.pbIsSharedPet.Location = new System.Drawing.Point(753, 32);
            this.pbIsSharedPet.Name = "pbIsSharedPet";
            this.pbIsSharedPet.Size = new System.Drawing.Size(32, 32);
            this.pbIsSharedPet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIsSharedPet.TabIndex = 14;
            this.pbIsSharedPet.TabStop = false;
            // 
            // pbBtnShowPet
            // 
            this.pbBtnShowPet.Image = global::PetLaFormeWin.Properties.Resources.search;
            this.pbBtnShowPet.Location = new System.Drawing.Point(696, 52);
            this.pbBtnShowPet.Name = "pbBtnShowPet";
            this.pbBtnShowPet.Size = new System.Drawing.Size(80, 80);
            this.pbBtnShowPet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnShowPet.TabIndex = 13;
            this.pbBtnShowPet.TabStop = false;
            this.pbBtnShowPet.Click += new System.EventHandler(this.pbBtnShowPet_Click);
            // 
            // lblDeletePet
            // 
            this.lblDeletePet.AutoSize = true;
            this.lblDeletePet.Font = new System.Drawing.Font("Arial Narrow", 27.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletePet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDeletePet.Location = new System.Drawing.Point(463, 112);
            this.lblDeletePet.Name = "lblDeletePet";
            this.lblDeletePet.Size = new System.Drawing.Size(0, 43);
            this.lblDeletePet.TabIndex = 12;
            // 
            // lblSharePetTitle
            // 
            this.lblSharePetTitle.AutoSize = true;
            this.lblSharePetTitle.Font = new System.Drawing.Font("Arial Narrow", 27.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSharePetTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSharePetTitle.Location = new System.Drawing.Point(464, 37);
            this.lblSharePetTitle.Name = "lblSharePetTitle";
            this.lblSharePetTitle.Size = new System.Drawing.Size(0, 43);
            this.lblSharePetTitle.TabIndex = 11;
            // 
            // tbSelectedPetType
            // 
            this.tbSelectedPetType.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbSelectedPetType.Location = new System.Drawing.Point(149, 112);
            this.tbSelectedPetType.Name = "tbSelectedPetType";
            this.tbSelectedPetType.ReadOnly = true;
            this.tbSelectedPetType.Size = new System.Drawing.Size(500, 33);
            this.tbSelectedPetType.TabIndex = 9;
            this.tbSelectedPetType.Text = "My Pet Type";
            // 
            // tbSelectedPetName
            // 
            this.tbSelectedPetName.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbSelectedPetName.Location = new System.Drawing.Point(149, 38);
            this.tbSelectedPetName.Name = "tbSelectedPetName";
            this.tbSelectedPetName.ReadOnly = true;
            this.tbSelectedPetName.Size = new System.Drawing.Size(500, 33);
            this.tbSelectedPetName.TabIndex = 8;
            this.tbSelectedPetName.Text = "My Pet";
            // 
            // lblSelectedPetTypeTitle
            // 
            this.lblSelectedPetTypeTitle.AutoSize = true;
            this.lblSelectedPetTypeTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedPetTypeTitle.Location = new System.Drawing.Point(147, 92);
            this.lblSelectedPetTypeTitle.Name = "lblSelectedPetTypeTitle";
            this.lblSelectedPetTypeTitle.Size = new System.Drawing.Size(504, 54);
            this.lblSelectedPetTypeTitle.TabIndex = 5;
            this.lblSelectedPetTypeTitle.Text = "Type de compagnon\r\n\r\n                                                            " +
    "                                                                \r\n";
            // 
            // lblSelectedPetNameTitle
            // 
            this.lblSelectedPetNameTitle.AutoSize = true;
            this.lblSelectedPetNameTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedPetNameTitle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblSelectedPetNameTitle.Location = new System.Drawing.Point(147, 18);
            this.lblSelectedPetNameTitle.Name = "lblSelectedPetNameTitle";
            this.lblSelectedPetNameTitle.Size = new System.Drawing.Size(504, 54);
            this.lblSelectedPetNameTitle.TabIndex = 4;
            this.lblSelectedPetNameTitle.Text = "Nom du compagnon\r\n\r\n                                                             " +
    "                                                               ";
            // 
            // pbSelectedPetImage
            // 
            this.pbSelectedPetImage.Image = global::PetLaFormeWin.Properties.Resources.bone;
            this.pbSelectedPetImage.Location = new System.Drawing.Point(13, 18);
            this.pbSelectedPetImage.Name = "pbSelectedPetImage";
            this.pbSelectedPetImage.Size = new System.Drawing.Size(128, 128);
            this.pbSelectedPetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSelectedPetImage.TabIndex = 0;
            this.pbSelectedPetImage.TabStop = false;
            // 
            // gbPageControll
            // 
            this.gbPageControll.Controls.Add(this.lblPageNav);
            this.gbPageControll.Controls.Add(this.pbBtnRightPage);
            this.gbPageControll.Controls.Add(this.pbBtnLeftPage);
            this.gbPageControll.Location = new System.Drawing.Point(237, 411);
            this.gbPageControll.Name = "gbPageControll";
            this.gbPageControll.Size = new System.Drawing.Size(300, 60);
            this.gbPageControll.TabIndex = 1;
            this.gbPageControll.TabStop = false;
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
            // PetsPreviewBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(785, 700);
            this.Controls.Add(this.gbPetInfoContainer);
            this.Controls.Add(this.gbPetList);
            this.Controls.Add(this.gbHeaderBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PetsPreviewBoard";
            this.Text = "PetsPreviewBoard";
            this.gbHeaderBox.ResumeLayout(false);
            this.gbHeaderBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnAddPet)).EndInit();
            this.gbPetList.ResumeLayout(false);
            this.gbPetInfoContainer.ResumeLayout(false);
            this.gbPetInfoContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIsSharedPet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnShowPet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedPetImage)).EndInit();
            this.gbPageControll.ResumeLayout(false);
            this.gbPageControll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnRightPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnLeftPage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHeaderBox;
        private System.Windows.Forms.GroupBox gbPetList;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbPetInfoContainer;
        private System.Windows.Forms.Label lblDeletePet;
        private System.Windows.Forms.Label lblSharePetTitle;
        private System.Windows.Forms.TextBox tbSelectedPetType;
        private System.Windows.Forms.TextBox tbSelectedPetName;
        private System.Windows.Forms.Label lblSelectedPetTypeTitle;
        private System.Windows.Forms.Label lblSelectedPetNameTitle;
        private System.Windows.Forms.PictureBox pbSelectedPetImage;
        private System.Windows.Forms.PictureBox pbBtnShowPet;
        private System.Windows.Forms.PictureBox pbBtnAddPet;
        private System.Windows.Forms.PictureBox pbIsSharedPet;
        private System.Windows.Forms.GroupBox gbPageControll;
        private System.Windows.Forms.Label lblPageNav;
        private System.Windows.Forms.PictureBox pbBtnRightPage;
        private System.Windows.Forms.PictureBox pbBtnLeftPage;
    }
}