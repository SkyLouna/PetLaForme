namespace PetLaFormeWin.Forms
{
    partial class AddPetBoard
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbPetInfoContainer = new System.Windows.Forms.GroupBox();
            this.pbBtnSavePet = new System.Windows.Forms.PictureBox();
            this.pbBtnCancelAdd = new System.Windows.Forms.PictureBox();
            this.tbPetType = new System.Windows.Forms.TextBox();
            this.tbPetName = new System.Windows.Forms.TextBox();
            this.lblPetTypeTitle = new System.Windows.Forms.Label();
            this.lblPetNameTitle = new System.Windows.Forms.Label();
            this.pbPetImage = new System.Windows.Forms.PictureBox();
            this.gbUserPetNameContainer = new System.Windows.Forms.GroupBox();
            this.pbUserPetTypeIcon = new System.Windows.Forms.PictureBox();
            this.tbUserPetName = new System.Windows.Forms.TextBox();
            this.lbUserPetType = new System.Windows.Forms.ListBox();
            this.lblUserPetNameTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAttributBox = new System.Windows.Forms.GroupBox();
            this.gbPetInfoContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnSavePet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnCancelAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPetImage)).BeginInit();
            this.gbUserPetNameContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPetTypeIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial Narrow", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(-10, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1270, 57);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = " Ajout d\'un familier                                                             " +
    "                    ";
            // 
            // gbPetInfoContainer
            // 
            this.gbPetInfoContainer.Controls.Add(this.pbBtnSavePet);
            this.gbPetInfoContainer.Controls.Add(this.pbBtnCancelAdd);
            this.gbPetInfoContainer.Controls.Add(this.tbPetType);
            this.gbPetInfoContainer.Controls.Add(this.tbPetName);
            this.gbPetInfoContainer.Controls.Add(this.lblPetTypeTitle);
            this.gbPetInfoContainer.Controls.Add(this.lblPetNameTitle);
            this.gbPetInfoContainer.Controls.Add(this.pbPetImage);
            this.gbPetInfoContainer.Location = new System.Drawing.Point(-1, 57);
            this.gbPetInfoContainer.Name = "gbPetInfoContainer";
            this.gbPetInfoContainer.Size = new System.Drawing.Size(1180, 160);
            this.gbPetInfoContainer.TabIndex = 4;
            this.gbPetInfoContainer.TabStop = false;
            this.gbPetInfoContainer.Text = "Aperçu";
            // 
            // pbBtnSavePet
            // 
            this.pbBtnSavePet.Image = global::PetLaFormeWin.Properties.Resources.save;
            this.pbBtnSavePet.Location = new System.Drawing.Point(108, 38);
            this.pbBtnSavePet.Name = "pbBtnSavePet";
            this.pbBtnSavePet.Size = new System.Drawing.Size(80, 80);
            this.pbBtnSavePet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnSavePet.TabIndex = 7;
            this.pbBtnSavePet.TabStop = false;
            this.pbBtnSavePet.Click += new System.EventHandler(this.pbBtnSavePet_Click);
            // 
            // pbBtnCancelAdd
            // 
            this.pbBtnCancelAdd.Image = global::PetLaFormeWin.Properties.Resources.close;
            this.pbBtnCancelAdd.Location = new System.Drawing.Point(6, 38);
            this.pbBtnCancelAdd.Name = "pbBtnCancelAdd";
            this.pbBtnCancelAdd.Size = new System.Drawing.Size(80, 80);
            this.pbBtnCancelAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnCancelAdd.TabIndex = 13;
            this.pbBtnCancelAdd.TabStop = false;
            this.pbBtnCancelAdd.Click += new System.EventHandler(this.pbBtnCancelAdd_Click);
            // 
            // tbPetType
            // 
            this.tbPetType.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbPetType.Location = new System.Drawing.Point(499, 112);
            this.tbPetType.Name = "tbPetType";
            this.tbPetType.ReadOnly = true;
            this.tbPetType.Size = new System.Drawing.Size(279, 33);
            this.tbPetType.TabIndex = 9;
            this.tbPetType.Text = "My Pet Type";
            // 
            // tbPetName
            // 
            this.tbPetName.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbPetName.Location = new System.Drawing.Point(499, 38);
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
            this.lblPetTypeTitle.Location = new System.Drawing.Point(497, 92);
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
            this.lblPetNameTitle.Location = new System.Drawing.Point(497, 18);
            this.lblPetNameTitle.Name = "lblPetNameTitle";
            this.lblPetNameTitle.Size = new System.Drawing.Size(284, 54);
            this.lblPetNameTitle.TabIndex = 4;
            this.lblPetNameTitle.Text = "Nom du compagnon\r\n\r\n                                                             " +
    "        ";
            // 
            // pbPetImage
            // 
            this.pbPetImage.Image = global::PetLaFormeWin.Properties.Resources.bone;
            this.pbPetImage.Location = new System.Drawing.Point(365, 18);
            this.pbPetImage.Name = "pbPetImage";
            this.pbPetImage.Size = new System.Drawing.Size(128, 128);
            this.pbPetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPetImage.TabIndex = 0;
            this.pbPetImage.TabStop = false;
            // 
            // gbUserPetNameContainer
            // 
            this.gbUserPetNameContainer.Controls.Add(this.pbUserPetTypeIcon);
            this.gbUserPetNameContainer.Controls.Add(this.tbUserPetName);
            this.gbUserPetNameContainer.Controls.Add(this.lbUserPetType);
            this.gbUserPetNameContainer.Controls.Add(this.lblUserPetNameTitle);
            this.gbUserPetNameContainer.Controls.Add(this.label1);
            this.gbUserPetNameContainer.Location = new System.Drawing.Point(-2, 204);
            this.gbUserPetNameContainer.Name = "gbUserPetNameContainer";
            this.gbUserPetNameContainer.Size = new System.Drawing.Size(1180, 117);
            this.gbUserPetNameContainer.TabIndex = 5;
            this.gbUserPetNameContainer.TabStop = false;
            // 
            // pbUserPetTypeIcon
            // 
            this.pbUserPetTypeIcon.Image = global::PetLaFormeWin.Properties.Resources.bone;
            this.pbUserPetTypeIcon.Location = new System.Drawing.Point(179, 42);
            this.pbUserPetTypeIcon.Name = "pbUserPetTypeIcon";
            this.pbUserPetTypeIcon.Size = new System.Drawing.Size(69, 69);
            this.pbUserPetTypeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUserPetTypeIcon.TabIndex = 6;
            this.pbUserPetTypeIcon.TabStop = false;
            // 
            // tbUserPetName
            // 
            this.tbUserPetName.Font = new System.Drawing.Font("Miriam Mono CLM", 33.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbUserPetName.Location = new System.Drawing.Point(306, 47);
            this.tbUserPetName.Name = "tbUserPetName";
            this.tbUserPetName.Size = new System.Drawing.Size(489, 62);
            this.tbUserPetName.TabIndex = 8;
            this.tbUserPetName.Text = "My Pet";
            this.tbUserPetName.TextChanged += new System.EventHandler(this.tbUserPetName_TextChanged);
            // 
            // lbUserPetType
            // 
            this.lbUserPetType.FormattingEnabled = true;
            this.lbUserPetType.Location = new System.Drawing.Point(4, 42);
            this.lbUserPetType.Name = "lbUserPetType";
            this.lbUserPetType.Size = new System.Drawing.Size(169, 69);
            this.lbUserPetType.TabIndex = 5;
            this.lbUserPetType.SelectedIndexChanged += new System.EventHandler(this.lbUserPetType_SelectedIndexChanged);
            // 
            // lblUserPetNameTitle
            // 
            this.lblUserPetNameTitle.AutoSize = true;
            this.lblUserPetNameTitle.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserPetNameTitle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblUserPetNameTitle.Location = new System.Drawing.Point(300, 7);
            this.lblUserPetNameTitle.Name = "lblUserPetNameTitle";
            this.lblUserPetNameTitle.Size = new System.Drawing.Size(1113, 108);
            this.lblUserPetNameTitle.TabIndex = 4;
            this.lblUserPetNameTitle.Text = "Nom du familier\r\n\r\n                                                              " +
    "                                                            ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(-4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 108);
            this.label1.TabIndex = 9;
            this.label1.Text = "Type de familier\r\n\r\n                                   ";
            // 
            // gbAttributBox
            // 
            this.gbAttributBox.Location = new System.Drawing.Point(-2, 313);
            this.gbAttributBox.Name = "gbAttributBox";
            this.gbAttributBox.Size = new System.Drawing.Size(1180, 392);
            this.gbAttributBox.TabIndex = 6;
            this.gbAttributBox.TabStop = false;
            // 
            // AddPetBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(785, 700);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbPetInfoContainer);
            this.Controls.Add(this.gbUserPetNameContainer);
            this.Controls.Add(this.gbAttributBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddPetBoard";
            this.Text = "AddPetBoard";
            this.gbPetInfoContainer.ResumeLayout(false);
            this.gbPetInfoContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnSavePet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnCancelAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPetImage)).EndInit();
            this.gbUserPetNameContainer.ResumeLayout(false);
            this.gbUserPetNameContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPetTypeIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbPetInfoContainer;
        private System.Windows.Forms.PictureBox pbBtnCancelAdd;
        private System.Windows.Forms.TextBox tbPetType;
        private System.Windows.Forms.TextBox tbPetName;
        private System.Windows.Forms.Label lblPetTypeTitle;
        private System.Windows.Forms.Label lblPetNameTitle;
        private System.Windows.Forms.PictureBox pbPetImage;
        private System.Windows.Forms.GroupBox gbUserPetNameContainer;
        private System.Windows.Forms.TextBox tbUserPetName;
        private System.Windows.Forms.Label lblUserPetNameTitle;
        private System.Windows.Forms.ListBox lbUserPetType;
        private System.Windows.Forms.PictureBox pbUserPetTypeIcon;
        private System.Windows.Forms.PictureBox pbBtnSavePet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbAttributBox;
    }
}