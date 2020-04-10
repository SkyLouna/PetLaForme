namespace PetLaFormeWin.Forms
{
    partial class KillShareForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KillShareForm));
            this.tbPetType = new System.Windows.Forms.TextBox();
            this.tbPetName = new System.Windows.Forms.TextBox();
            this.lblPetTypeTitle = new System.Windows.Forms.Label();
            this.lblPetNameTitle = new System.Windows.Forms.Label();
            this.pbPetImage = new System.Windows.Forms.PictureBox();
            this.lblUserNick = new System.Windows.Forms.Label();
            this.lbUserShareList = new System.Windows.Forms.ListBox();
            this.pbBtnStopShare = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPetImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnStopShare)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPetType
            // 
            this.tbPetType.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbPetType.Location = new System.Drawing.Point(135, 95);
            this.tbPetType.Name = "tbPetType";
            this.tbPetType.ReadOnly = true;
            this.tbPetType.Size = new System.Drawing.Size(279, 33);
            this.tbPetType.TabIndex = 14;
            this.tbPetType.Text = "My Pet Type";
            // 
            // tbPetName
            // 
            this.tbPetName.Font = new System.Drawing.Font("Miriam Mono CLM", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbPetName.Location = new System.Drawing.Point(135, 21);
            this.tbPetName.Name = "tbPetName";
            this.tbPetName.ReadOnly = true;
            this.tbPetName.Size = new System.Drawing.Size(279, 33);
            this.tbPetName.TabIndex = 13;
            this.tbPetName.Text = "My Pet";
            // 
            // lblPetTypeTitle
            // 
            this.lblPetTypeTitle.AutoSize = true;
            this.lblPetTypeTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPetTypeTitle.Location = new System.Drawing.Point(133, 75);
            this.lblPetTypeTitle.Name = "lblPetTypeTitle";
            this.lblPetTypeTitle.Size = new System.Drawing.Size(284, 54);
            this.lblPetTypeTitle.TabIndex = 12;
            this.lblPetTypeTitle.Text = "Type de compagnon\r\n\r\n                                                            " +
    "         ";
            // 
            // lblPetNameTitle
            // 
            this.lblPetNameTitle.AutoSize = true;
            this.lblPetNameTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPetNameTitle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblPetNameTitle.Location = new System.Drawing.Point(133, 1);
            this.lblPetNameTitle.Name = "lblPetNameTitle";
            this.lblPetNameTitle.Size = new System.Drawing.Size(284, 54);
            this.lblPetNameTitle.TabIndex = 11;
            this.lblPetNameTitle.Text = "Nom du compagnon\r\n\r\n                                                             " +
    "        ";
            // 
            // pbPetImage
            // 
            this.pbPetImage.Image = global::PetLaFormeWin.Properties.Resources.bone;
            this.pbPetImage.Location = new System.Drawing.Point(1, 1);
            this.pbPetImage.Name = "pbPetImage";
            this.pbPetImage.Size = new System.Drawing.Size(128, 128);
            this.pbPetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPetImage.TabIndex = 10;
            this.pbPetImage.TabStop = false;
            // 
            // lblUserNick
            // 
            this.lblUserNick.AutoSize = true;
            this.lblUserNick.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNick.Location = new System.Drawing.Point(-4, 137);
            this.lblUserNick.Name = "lblUserNick";
            this.lblUserNick.Size = new System.Drawing.Size(424, 144);
            this.lblUserNick.TabIndex = 15;
            this.lblUserNick.Text = "Choisir un utilisateur\r\n\r\n\r\n\r\n\r\n                                                 " +
    "                    ";
            this.lblUserNick.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbUserShareList
            // 
            this.lbUserShareList.FormattingEnabled = true;
            this.lbUserShareList.Location = new System.Drawing.Point(1, 164);
            this.lbUserShareList.Name = "lbUserShareList";
            this.lbUserShareList.Size = new System.Drawing.Size(413, 108);
            this.lbUserShareList.TabIndex = 16;
            this.lbUserShareList.SelectedIndexChanged += new System.EventHandler(this.lbUserShareList_SelectedIndexChanged);
            // 
            // pbBtnStopShare
            // 
            this.pbBtnStopShare.Image = global::PetLaFormeWin.Properties.Resources.cancel_cloud;
            this.pbBtnStopShare.Location = new System.Drawing.Point(174, 300);
            this.pbBtnStopShare.Name = "pbBtnStopShare";
            this.pbBtnStopShare.Size = new System.Drawing.Size(80, 80);
            this.pbBtnStopShare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnStopShare.TabIndex = 17;
            this.pbBtnStopShare.TabStop = false;
            this.pbBtnStopShare.Click += new System.EventHandler(this.pbBtnStopShare_Click);
            // 
            // KillShareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 389);
            this.Controls.Add(this.pbBtnStopShare);
            this.Controls.Add(this.lbUserShareList);
            this.Controls.Add(this.lblUserNick);
            this.Controls.Add(this.tbPetType);
            this.Controls.Add(this.tbPetName);
            this.Controls.Add(this.lblPetTypeTitle);
            this.Controls.Add(this.lblPetNameTitle);
            this.Controls.Add(this.pbPetImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KillShareForm";
            this.ShowInTaskbar = false;
            this.Text = "Pet La Forme - Cesser le partage";
            ((System.ComponentModel.ISupportInitialize)(this.pbPetImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnStopShare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPetType;
        private System.Windows.Forms.TextBox tbPetName;
        private System.Windows.Forms.Label lblPetTypeTitle;
        private System.Windows.Forms.Label lblPetNameTitle;
        private System.Windows.Forms.PictureBox pbPetImage;
        private System.Windows.Forms.Label lblUserNick;
        private System.Windows.Forms.ListBox lbUserShareList;
        private System.Windows.Forms.PictureBox pbBtnStopShare;
    }
}