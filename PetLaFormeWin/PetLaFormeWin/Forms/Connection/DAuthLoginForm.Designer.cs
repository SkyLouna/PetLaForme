namespace PetLaFormeWin.Forms.Connection
{
    partial class DAuthLoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DAuthLoginForm));
            this.gbAboutBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbCodeBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendCode = new System.Windows.Forms.Button();
            this.gbAboutBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAboutBox
            // 
            this.gbAboutBox.Controls.Add(this.textBox1);
            this.gbAboutBox.Location = new System.Drawing.Point(12, 12);
            this.gbAboutBox.Name = "gbAboutBox";
            this.gbAboutBox.Size = new System.Drawing.Size(302, 119);
            this.gbAboutBox.TabIndex = 2;
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
            this.textBox1.Size = new System.Drawing.Size(282, 93);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // tbCodeBox
            // 
            this.tbCodeBox.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCodeBox.Location = new System.Drawing.Point(66, 167);
            this.tbCodeBox.Name = "tbCodeBox";
            this.tbCodeBox.Size = new System.Drawing.Size(191, 31);
            this.tbCodeBox.TabIndex = 3;
            this.tbCodeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Code de double authentification";
            // 
            // btnSendCode
            // 
            this.btnSendCode.Location = new System.Drawing.Point(120, 204);
            this.btnSendCode.Name = "btnSendCode";
            this.btnSendCode.Size = new System.Drawing.Size(92, 23);
            this.btnSendCode.TabIndex = 5;
            this.btnSendCode.Text = "Se connecter";
            this.btnSendCode.UseVisualStyleBackColor = true;
            this.btnSendCode.Click += new System.EventHandler(this.btnSendCode_Click);
            // 
            // DAuthLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(326, 242);
            this.Controls.Add(this.btnSendCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCodeBox);
            this.Controls.Add(this.gbAboutBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DAuthLoginForm";
            this.Text = "PetLaForme - Double Authentification";
            this.gbAboutBox.ResumeLayout(false);
            this.gbAboutBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAboutBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbCodeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendCode;
    }
}