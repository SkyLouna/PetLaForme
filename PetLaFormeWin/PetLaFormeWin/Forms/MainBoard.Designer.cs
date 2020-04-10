namespace PetLaFormeWin.Forms
{
    partial class MainBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainBoard));
            this.gbTopMenuGroup = new System.Windows.Forms.GroupBox();
            this.pbBtnLogout = new System.Windows.Forms.PictureBox();
            this.lblConnectedAs = new System.Windows.Forms.Label();
            this.pbBtnMainSettings = new System.Windows.Forms.PictureBox();
            this.pbBtnUserProfile = new System.Windows.Forms.PictureBox();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.gbTopMenuGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnMainSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnUserProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTopMenuGroup
            // 
            this.gbTopMenuGroup.BackColor = System.Drawing.Color.LightGray;
            this.gbTopMenuGroup.Controls.Add(this.pbBtnLogout);
            this.gbTopMenuGroup.Controls.Add(this.lblConnectedAs);
            this.gbTopMenuGroup.Controls.Add(this.pbBtnMainSettings);
            this.gbTopMenuGroup.Controls.Add(this.pbBtnUserProfile);
            this.gbTopMenuGroup.Location = new System.Drawing.Point(-3, -7);
            this.gbTopMenuGroup.Name = "gbTopMenuGroup";
            this.gbTopMenuGroup.Size = new System.Drawing.Size(1200, 65);
            this.gbTopMenuGroup.TabIndex = 1;
            this.gbTopMenuGroup.TabStop = false;
            // 
            // pbBtnLogout
            // 
            this.pbBtnLogout.Image = global::PetLaFormeWin.Properties.Resources.logout;
            this.pbBtnLogout.InitialImage = global::PetLaFormeWin.Properties.Resources.user2;
            this.pbBtnLogout.Location = new System.Drawing.Point(1133, 12);
            this.pbBtnLogout.Name = "pbBtnLogout";
            this.pbBtnLogout.Size = new System.Drawing.Size(50, 50);
            this.pbBtnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnLogout.TabIndex = 3;
            this.pbBtnLogout.TabStop = false;
            this.pbBtnLogout.Click += new System.EventHandler(this.pbBtnLogout_Click);
            // 
            // lblConnectedAs
            // 
            this.lblConnectedAs.AutoSize = true;
            this.lblConnectedAs.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectedAs.Location = new System.Drawing.Point(121, 18);
            this.lblConnectedAs.Name = "lblConnectedAs";
            this.lblConnectedAs.Size = new System.Drawing.Size(512, 32);
            this.lblConnectedAs.TabIndex = 2;
            this.lblConnectedAs.Text = "Connecté(e) en tant que {USERNAME}";
            this.lblConnectedAs.Click += new System.EventHandler(this.lblConnectedAs_Click);
            // 
            // pbBtnMainSettings
            // 
            this.pbBtnMainSettings.Image = global::PetLaFormeWin.Properties.Resources.settings;
            this.pbBtnMainSettings.InitialImage = global::PetLaFormeWin.Properties.Resources.settings;
            this.pbBtnMainSettings.Location = new System.Drawing.Point(9, 9);
            this.pbBtnMainSettings.Name = "pbBtnMainSettings";
            this.pbBtnMainSettings.Size = new System.Drawing.Size(50, 50);
            this.pbBtnMainSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnMainSettings.TabIndex = 0;
            this.pbBtnMainSettings.TabStop = false;
            this.pbBtnMainSettings.Click += new System.EventHandler(this.pbBtnMainSettings_Click);
            // 
            // pbBtnUserProfile
            // 
            this.pbBtnUserProfile.Image = global::PetLaFormeWin.Properties.Resources.user2;
            this.pbBtnUserProfile.InitialImage = global::PetLaFormeWin.Properties.Resources.user2;
            this.pbBtnUserProfile.Location = new System.Drawing.Point(65, 9);
            this.pbBtnUserProfile.Name = "pbBtnUserProfile";
            this.pbBtnUserProfile.Size = new System.Drawing.Size(50, 50);
            this.pbBtnUserProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnUserProfile.TabIndex = 1;
            this.pbBtnUserProfile.TabStop = false;
            this.pbBtnUserProfile.Click += new System.EventHandler(this.pbBtnUserProfile_Click);
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 60);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.BackColor = System.Drawing.Color.Black;
            this.mainSplitContainer.Panel1MinSize = 0;
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.BackColor = System.Drawing.Color.Black;
            this.mainSplitContainer.Panel2MinSize = 780;
            this.mainSplitContainer.Size = new System.Drawing.Size(1185, 700);
            this.mainSplitContainer.SplitterDistance = 399;
            this.mainSplitContainer.SplitterWidth = 1;
            this.mainSplitContainer.TabIndex = 2;
            // 
            // MainBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.gbTopMenuGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainBoard";
            this.Text = "Pet La Forme - Tableau de bord";
            this.gbTopMenuGroup.ResumeLayout(false);
            this.gbTopMenuGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnMainSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnUserProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBtnMainSettings;
        private System.Windows.Forms.GroupBox gbTopMenuGroup;
        private System.Windows.Forms.PictureBox pbBtnUserProfile;
        private System.Windows.Forms.Label lblConnectedAs;
        private System.Windows.Forms.PictureBox pbBtnLogout;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
    }
}