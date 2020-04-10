namespace PetLaFormeWin.Forms
{
    partial class PetAttributePreviewBoard
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
            this.lblAttributeTitle = new System.Windows.Forms.Label();
            this.pbBtnSave = new System.Windows.Forms.PictureBox();
            this.pbBtnDelete = new System.Windows.Forms.PictureBox();
            this.pbBtnReturnToMenu = new System.Windows.Forms.PictureBox();
            this.pbAttributeIcon = new System.Windows.Forms.PictureBox();
            this.lblUserAttributTitle = new System.Windows.Forms.Label();
            this.tbUserAttributeTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUserAttributDescription = new System.Windows.Forms.TextBox();
            this.lblUserAttributeTypeTitle = new System.Windows.Forms.Label();
            this.lbUserAttribute = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnReturnToMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAttributeIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAttributeTitle
            // 
            this.lblAttributeTitle.AutoSize = true;
            this.lblAttributeTitle.Font = new System.Drawing.Font("Arial Narrow", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttributeTitle.Location = new System.Drawing.Point(-10, 3);
            this.lblAttributeTitle.Name = "lblAttributeTitle";
            this.lblAttributeTitle.Size = new System.Drawing.Size(430, 57);
            this.lblAttributeTitle.TabIndex = 2;
            this.lblAttributeTitle.Text = " Attribut                       ";
            // 
            // pbBtnSave
            // 
            this.pbBtnSave.Image = global::PetLaFormeWin.Properties.Resources.save;
            this.pbBtnSave.Location = new System.Drawing.Point(235, 2);
            this.pbBtnSave.Name = "pbBtnSave";
            this.pbBtnSave.Size = new System.Drawing.Size(50, 50);
            this.pbBtnSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnSave.TabIndex = 3;
            this.pbBtnSave.TabStop = false;
            this.pbBtnSave.Click += new System.EventHandler(this.pbBtnSave_Click);
            // 
            // pbBtnDelete
            // 
            this.pbBtnDelete.Image = global::PetLaFormeWin.Properties.Resources.garbage;
            this.pbBtnDelete.Location = new System.Drawing.Point(291, 2);
            this.pbBtnDelete.Name = "pbBtnDelete";
            this.pbBtnDelete.Size = new System.Drawing.Size(50, 50);
            this.pbBtnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnDelete.TabIndex = 4;
            this.pbBtnDelete.TabStop = false;
            this.pbBtnDelete.Click += new System.EventHandler(this.pbBtnDelete_Click);
            // 
            // pbBtnReturnToMenu
            // 
            this.pbBtnReturnToMenu.Image = global::PetLaFormeWin.Properties.Resources.returnToMenu;
            this.pbBtnReturnToMenu.Location = new System.Drawing.Point(347, 2);
            this.pbBtnReturnToMenu.Name = "pbBtnReturnToMenu";
            this.pbBtnReturnToMenu.Size = new System.Drawing.Size(50, 50);
            this.pbBtnReturnToMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBtnReturnToMenu.TabIndex = 5;
            this.pbBtnReturnToMenu.TabStop = false;
            this.pbBtnReturnToMenu.Click += new System.EventHandler(this.pbBtnReturnToMenu_Click);
            // 
            // pbAttributeIcon
            // 
            this.pbAttributeIcon.Image = global::PetLaFormeWin.Properties.Resources.bone;
            this.pbAttributeIcon.Location = new System.Drawing.Point(0, 62);
            this.pbAttributeIcon.Name = "pbAttributeIcon";
            this.pbAttributeIcon.Size = new System.Drawing.Size(128, 128);
            this.pbAttributeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAttributeIcon.TabIndex = 6;
            this.pbAttributeIcon.TabStop = false;
            // 
            // lblUserAttributTitle
            // 
            this.lblUserAttributTitle.AutoSize = true;
            this.lblUserAttributTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserAttributTitle.Location = new System.Drawing.Point(125, 59);
            this.lblUserAttributTitle.Name = "lblUserAttributTitle";
            this.lblUserAttributTitle.Size = new System.Drawing.Size(295, 66);
            this.lblUserAttributTitle.TabIndex = 7;
            this.lblUserAttributTitle.Text = "Nom de l\'attribut\r\n\r\n                                                         ";
            this.lblUserAttributTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbUserAttributeTitle
            // 
            this.tbUserAttributeTitle.Font = new System.Drawing.Font("Miriam Mono CLM", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbUserAttributeTitle.Location = new System.Drawing.Point(129, 84);
            this.tbUserAttributeTitle.Name = "tbUserAttributeTitle";
            this.tbUserAttributeTitle.Size = new System.Drawing.Size(268, 37);
            this.tbUserAttributeTitle.TabIndex = 8;
            this.tbUserAttributeTitle.Text = "My Attribut";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-6, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 506);
            this.label1.TabIndex = 9;
            this.label1.Text = "Description de l\'attribut\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n            " +
    "                                                                     ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbUserAttributDescription
            // 
            this.tbUserAttributDescription.Font = new System.Drawing.Font("Miriam CLM", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbUserAttributDescription.Location = new System.Drawing.Point(12, 222);
            this.tbUserAttributDescription.Multiline = true;
            this.tbUserAttributDescription.Name = "tbUserAttributDescription";
            this.tbUserAttributDescription.Size = new System.Drawing.Size(376, 466);
            this.tbUserAttributDescription.TabIndex = 10;
            this.tbUserAttributDescription.TextChanged += new System.EventHandler(this.tbUserAttributDescription_TextChanged);
            // 
            // lblUserAttributeTypeTitle
            // 
            this.lblUserAttributeTypeTitle.AutoSize = true;
            this.lblUserAttributeTypeTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserAttributeTypeTitle.Location = new System.Drawing.Point(125, 127);
            this.lblUserAttributeTypeTitle.Name = "lblUserAttributeTypeTitle";
            this.lblUserAttributeTypeTitle.Size = new System.Drawing.Size(295, 66);
            this.lblUserAttributeTypeTitle.TabIndex = 11;
            this.lblUserAttributeTypeTitle.Text = "Type D\'attribut\r\n\r\n                                                         ";
            this.lblUserAttributeTypeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbUserAttribute
            // 
            this.lbUserAttribute.FormattingEnabled = true;
            this.lbUserAttribute.Location = new System.Drawing.Point(129, 154);
            this.lbUserAttribute.Name = "lbUserAttribute";
            this.lbUserAttribute.Size = new System.Drawing.Size(156, 30);
            this.lbUserAttribute.TabIndex = 12;
            this.lbUserAttribute.SelectedIndexChanged += new System.EventHandler(this.lbUserAttribute_SelectedIndexChanged);
            // 
            // PetAttributePreviewBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 700);
            this.Controls.Add(this.lbUserAttribute);
            this.Controls.Add(this.tbUserAttributDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUserAttributeTitle);
            this.Controls.Add(this.pbAttributeIcon);
            this.Controls.Add(this.pbBtnReturnToMenu);
            this.Controls.Add(this.pbBtnDelete);
            this.Controls.Add(this.pbBtnSave);
            this.Controls.Add(this.lblAttributeTitle);
            this.Controls.Add(this.lblUserAttributTitle);
            this.Controls.Add(this.lblUserAttributeTypeTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PetAttributePreviewBoard";
            this.Text = "PetAttributePreviewBoard";
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnReturnToMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAttributeIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAttributeTitle;
        private System.Windows.Forms.PictureBox pbBtnSave;
        private System.Windows.Forms.PictureBox pbBtnDelete;
        private System.Windows.Forms.PictureBox pbBtnReturnToMenu;
        private System.Windows.Forms.PictureBox pbAttributeIcon;
        private System.Windows.Forms.Label lblUserAttributTitle;
        private System.Windows.Forms.TextBox tbUserAttributeTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUserAttributDescription;
        private System.Windows.Forms.Label lblUserAttributeTypeTitle;
        private System.Windows.Forms.ListBox lbUserAttribute;
    }
}