namespace PetLaFormeWin.Forms
{
    partial class UserSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSettingsForm));
            this.gbAutoConnBox = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cbAllowAutoConnect = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.gbAboutBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbAutoConnBox.SuspendLayout();
            this.gbAboutBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAutoConnBox
            // 
            this.gbAutoConnBox.Controls.Add(this.textBox3);
            this.gbAutoConnBox.Controls.Add(this.cbAllowAutoConnect);
            this.gbAutoConnBox.Controls.Add(this.textBox2);
            this.gbAutoConnBox.Location = new System.Drawing.Point(12, 143);
            this.gbAutoConnBox.Name = "gbAutoConnBox";
            this.gbAutoConnBox.Size = new System.Drawing.Size(386, 143);
            this.gbAutoConnBox.TabIndex = 0;
            this.gbAutoConnBox.TabStop = false;
            this.gbAutoConnBox.Text = "Connexion automatique";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(7, 106);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(372, 31);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "La connexion automatique peut échouer s\'il n\'y a aucune connexion au serveur ou s" +
    "i vous avez changé votre mot de passe entre temps.";
            // 
            // cbAllowAutoConnect
            // 
            this.cbAllowAutoConnect.AutoSize = true;
            this.cbAllowAutoConnect.Location = new System.Drawing.Point(7, 83);
            this.cbAllowAutoConnect.Name = "cbAllowAutoConnect";
            this.cbAllowAutoConnect.Size = new System.Drawing.Size(137, 17);
            this.cbAllowAutoConnect.TabIndex = 2;
            this.cbAllowAutoConnect.Text = "Connexion automatique";
            this.cbAllowAutoConnect.UseVisualStyleBackColor = true;
            this.cbAllowAutoConnect.CheckedChanged += new System.EventHandler(this.cbAllowAutoConnect_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(8, 19);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(372, 57);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // gbAboutBox
            // 
            this.gbAboutBox.Controls.Add(this.textBox1);
            this.gbAboutBox.Location = new System.Drawing.Point(13, 13);
            this.gbAboutBox.Name = "gbAboutBox";
            this.gbAboutBox.Size = new System.Drawing.Size(385, 119);
            this.gbAboutBox.TabIndex = 1;
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
            this.textBox1.Size = new System.Drawing.Size(372, 93);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // UserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(411, 294);
            this.Controls.Add(this.gbAboutBox);
            this.Controls.Add(this.gbAutoConnBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserSettingsForm";
            this.Text = "Réglages";
            this.gbAutoConnBox.ResumeLayout(false);
            this.gbAutoConnBox.PerformLayout();
            this.gbAboutBox.ResumeLayout(false);
            this.gbAboutBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAutoConnBox;
        private System.Windows.Forms.GroupBox gbAboutBox;
        private System.Windows.Forms.CheckBox cbAllowAutoConnect;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
    }
}