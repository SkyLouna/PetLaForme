namespace PetLaFormeWin
{
    partial class FormRegisterLogin
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegisterLogin));
            this.gbConnectContainer = new System.Windows.Forms.GroupBox();
            this.lblPasswordLost = new System.Windows.Forms.Label();
            this.tbConnectionUserPassword = new System.Windows.Forms.TextBox();
            this.tbConnectionUserName = new System.Windows.Forms.TextBox();
            this.lblConnectionUserPasswordTitle = new System.Windows.Forms.Label();
            this.lblConnectionUserNameTitle = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblConnectTitle = new System.Windows.Forms.Label();
            this.gbRegisterContainer = new System.Windows.Forms.GroupBox();
            this.tbRegisterUserSurName = new System.Windows.Forms.TextBox();
            this.lblRegisterSurnameTitle = new System.Windows.Forms.Label();
            this.lblRegisterUserNameTitle = new System.Windows.Forms.Label();
            this.tbRegisterUserName = new System.Windows.Forms.TextBox();
            this.lblRegisterUserEmailTitle = new System.Windows.Forms.Label();
            this.tbRegisterUserEmail = new System.Windows.Forms.TextBox();
            this.tbRegisterUserPasswordConfirm = new System.Windows.Forms.TextBox();
            this.lblRegisterUserPasswordConfirmTitle = new System.Windows.Forms.Label();
            this.tbRegisterUserPassword = new System.Windows.Forms.TextBox();
            this.lblRegisterUserPasswordTitle = new System.Windows.Forms.Label();
            this.tbRegisterUserNick = new System.Windows.Forms.TextBox();
            this.lblRegisterUserNickTitle = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblRegisterTitle = new System.Windows.Forms.Label();
            this.gbConnectContainer.SuspendLayout();
            this.gbRegisterContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConnectContainer
            // 
            this.gbConnectContainer.Controls.Add(this.lblPasswordLost);
            this.gbConnectContainer.Controls.Add(this.tbConnectionUserPassword);
            this.gbConnectContainer.Controls.Add(this.tbConnectionUserName);
            this.gbConnectContainer.Controls.Add(this.lblConnectionUserPasswordTitle);
            this.gbConnectContainer.Controls.Add(this.lblConnectionUserNameTitle);
            this.gbConnectContainer.Controls.Add(this.btnConnect);
            this.gbConnectContainer.Controls.Add(this.lblConnectTitle);
            resources.ApplyResources(this.gbConnectContainer, "gbConnectContainer");
            this.gbConnectContainer.Name = "gbConnectContainer";
            this.gbConnectContainer.TabStop = false;
            // 
            // lblPasswordLost
            // 
            resources.ApplyResources(this.lblPasswordLost, "lblPasswordLost");
            this.lblPasswordLost.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPasswordLost.Name = "lblPasswordLost";
            this.lblPasswordLost.Click += new System.EventHandler(this.lblPasswordLost_Click);
            // 
            // tbConnectionUserPassword
            // 
            resources.ApplyResources(this.tbConnectionUserPassword, "tbConnectionUserPassword");
            this.tbConnectionUserPassword.Name = "tbConnectionUserPassword";
            // 
            // tbConnectionUserName
            // 
            resources.ApplyResources(this.tbConnectionUserName, "tbConnectionUserName");
            this.tbConnectionUserName.Name = "tbConnectionUserName";
            // 
            // lblConnectionUserPasswordTitle
            // 
            resources.ApplyResources(this.lblConnectionUserPasswordTitle, "lblConnectionUserPasswordTitle");
            this.lblConnectionUserPasswordTitle.Name = "lblConnectionUserPasswordTitle";
            // 
            // lblConnectionUserNameTitle
            // 
            resources.ApplyResources(this.lblConnectionUserNameTitle, "lblConnectionUserNameTitle");
            this.lblConnectionUserNameTitle.Name = "lblConnectionUserNameTitle";
            // 
            // btnConnect
            // 
            resources.ApplyResources(this.btnConnect, "btnConnect");
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.UseMnemonic = false;
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblConnectTitle
            // 
            resources.ApplyResources(this.lblConnectTitle, "lblConnectTitle");
            this.lblConnectTitle.Name = "lblConnectTitle";
            // 
            // gbRegisterContainer
            // 
            this.gbRegisterContainer.Controls.Add(this.tbRegisterUserSurName);
            this.gbRegisterContainer.Controls.Add(this.lblRegisterSurnameTitle);
            this.gbRegisterContainer.Controls.Add(this.lblRegisterUserNameTitle);
            this.gbRegisterContainer.Controls.Add(this.tbRegisterUserName);
            this.gbRegisterContainer.Controls.Add(this.lblRegisterUserEmailTitle);
            this.gbRegisterContainer.Controls.Add(this.tbRegisterUserEmail);
            this.gbRegisterContainer.Controls.Add(this.tbRegisterUserPasswordConfirm);
            this.gbRegisterContainer.Controls.Add(this.lblRegisterUserPasswordConfirmTitle);
            this.gbRegisterContainer.Controls.Add(this.tbRegisterUserPassword);
            this.gbRegisterContainer.Controls.Add(this.lblRegisterUserPasswordTitle);
            this.gbRegisterContainer.Controls.Add(this.tbRegisterUserNick);
            this.gbRegisterContainer.Controls.Add(this.lblRegisterUserNickTitle);
            this.gbRegisterContainer.Controls.Add(this.btnRegister);
            this.gbRegisterContainer.Controls.Add(this.lblRegisterTitle);
            resources.ApplyResources(this.gbRegisterContainer, "gbRegisterContainer");
            this.gbRegisterContainer.Name = "gbRegisterContainer";
            this.gbRegisterContainer.TabStop = false;
            // 
            // tbRegisterUserSurName
            // 
            resources.ApplyResources(this.tbRegisterUserSurName, "tbRegisterUserSurName");
            this.tbRegisterUserSurName.Name = "tbRegisterUserSurName";
            // 
            // lblRegisterSurnameTitle
            // 
            resources.ApplyResources(this.lblRegisterSurnameTitle, "lblRegisterSurnameTitle");
            this.lblRegisterSurnameTitle.Name = "lblRegisterSurnameTitle";
            // 
            // lblRegisterUserNameTitle
            // 
            resources.ApplyResources(this.lblRegisterUserNameTitle, "lblRegisterUserNameTitle");
            this.lblRegisterUserNameTitle.Name = "lblRegisterUserNameTitle";
            // 
            // tbRegisterUserName
            // 
            resources.ApplyResources(this.tbRegisterUserName, "tbRegisterUserName");
            this.tbRegisterUserName.Name = "tbRegisterUserName";
            // 
            // lblRegisterUserEmailTitle
            // 
            resources.ApplyResources(this.lblRegisterUserEmailTitle, "lblRegisterUserEmailTitle");
            this.lblRegisterUserEmailTitle.Name = "lblRegisterUserEmailTitle";
            // 
            // tbRegisterUserEmail
            // 
            resources.ApplyResources(this.tbRegisterUserEmail, "tbRegisterUserEmail");
            this.tbRegisterUserEmail.Name = "tbRegisterUserEmail";
            // 
            // tbRegisterUserPasswordConfirm
            // 
            resources.ApplyResources(this.tbRegisterUserPasswordConfirm, "tbRegisterUserPasswordConfirm");
            this.tbRegisterUserPasswordConfirm.Name = "tbRegisterUserPasswordConfirm";
            // 
            // lblRegisterUserPasswordConfirmTitle
            // 
            resources.ApplyResources(this.lblRegisterUserPasswordConfirmTitle, "lblRegisterUserPasswordConfirmTitle");
            this.lblRegisterUserPasswordConfirmTitle.Name = "lblRegisterUserPasswordConfirmTitle";
            // 
            // tbRegisterUserPassword
            // 
            resources.ApplyResources(this.tbRegisterUserPassword, "tbRegisterUserPassword");
            this.tbRegisterUserPassword.Name = "tbRegisterUserPassword";
            // 
            // lblRegisterUserPasswordTitle
            // 
            resources.ApplyResources(this.lblRegisterUserPasswordTitle, "lblRegisterUserPasswordTitle");
            this.lblRegisterUserPasswordTitle.Name = "lblRegisterUserPasswordTitle";
            // 
            // tbRegisterUserNick
            // 
            resources.ApplyResources(this.tbRegisterUserNick, "tbRegisterUserNick");
            this.tbRegisterUserNick.Name = "tbRegisterUserNick";
            // 
            // lblRegisterUserNickTitle
            // 
            resources.ApplyResources(this.lblRegisterUserNickTitle, "lblRegisterUserNickTitle");
            this.lblRegisterUserNickTitle.Name = "lblRegisterUserNickTitle";
            // 
            // btnRegister
            // 
            resources.ApplyResources(this.btnRegister, "btnRegister");
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.UseMnemonic = false;
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblRegisterTitle
            // 
            resources.ApplyResources(this.lblRegisterTitle, "lblRegisterTitle");
            this.lblRegisterTitle.Name = "lblRegisterTitle";
            // 
            // FormRegisterLogin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbRegisterContainer);
            this.Controls.Add(this.gbConnectContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormRegisterLogin";
            this.gbConnectContainer.ResumeLayout(false);
            this.gbConnectContainer.PerformLayout();
            this.gbRegisterContainer.ResumeLayout(false);
            this.gbRegisterContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConnectContainer;
        private System.Windows.Forms.GroupBox gbRegisterContainer;
        private System.Windows.Forms.Label lblConnectTitle;
        private System.Windows.Forms.Label lblRegisterTitle;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox tbConnectionUserName;
        private System.Windows.Forms.Label lblConnectionUserPasswordTitle;
        private System.Windows.Forms.Label lblConnectionUserNameTitle;
        private System.Windows.Forms.TextBox tbConnectionUserPassword;
        private System.Windows.Forms.TextBox tbRegisterUserSurName;
        private System.Windows.Forms.Label lblRegisterSurnameTitle;
        private System.Windows.Forms.Label lblRegisterUserNameTitle;
        private System.Windows.Forms.TextBox tbRegisterUserName;
        private System.Windows.Forms.Label lblRegisterUserEmailTitle;
        private System.Windows.Forms.TextBox tbRegisterUserEmail;
        private System.Windows.Forms.TextBox tbRegisterUserPasswordConfirm;
        private System.Windows.Forms.Label lblRegisterUserPasswordConfirmTitle;
        private System.Windows.Forms.TextBox tbRegisterUserPassword;
        private System.Windows.Forms.Label lblRegisterUserPasswordTitle;
        private System.Windows.Forms.TextBox tbRegisterUserNick;
        private System.Windows.Forms.Label lblRegisterUserNickTitle;
        private System.Windows.Forms.Label lblPasswordLost;
    }
}

