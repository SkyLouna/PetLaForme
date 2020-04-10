using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PLFAPI.Object.User;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Communication.NetworkPackets.Client;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Object.Ext;
using PetLaFormeWin.Helper;
using PetLaFormeWin.Forms.User;

namespace PetLaFormeWin.Forms
{
    public partial class UserProfileBoard : Form
    {

        UserDAuthSettingsForm userDAuthSettingsForm;

      

        public UserProfileBoard()
        {
            //init component
            InitializeComponent();

            //add some event handlers
            this.Shown += new EventHandler(OnFormShow);
            this.Disposed += new EventHandler(OnFormDispose);
        }

        private void pbBtnLogout_Click(object sender, EventArgs e)
        {
            //logout user 
            Program.acutalUser = null;

            if (Program.mainBoard.UserSettingsForm != null)
                Program.mainBoard.UserSettingsForm.Dispose();
            Program.mainBoard.UserSettingsForm = null;

            //hide some forms
            Program.mainBoard.Hide();
            Program.mainBoard.UserProfileBoard.Dispose();
            Program.formRegisterLogin.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //if some fields are empty
            if (String.IsNullOrEmpty(tbUserEmail.Text) || String.IsNullOrEmpty(tbUserPassword.Text))
            {
                MessageBox.Show(MSGBank.ERROR_FILL_ALL_FIELDS, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if email is valid
            if (!tbUserEmail.Text.IsValidEmail())
            {
                MessageBox.Show(MSGBank.ERROR_WRONG_EMAIL, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if the two passwords are the same
            if (tbUserPassword.Text != tbUserPasswordConfirm.Text)
            {
                MessageBox.Show(MSGBank.ERROR_NOT_SAME_PASSWORD, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //change actual user infos
            PLFUser actualUser = Program.acutalUser;
            actualUser.UserName = tbUserName.Text;
            actualUser.UserSurname = tbUserSurname.Text;
            actualUser.UserEMail = tbUserEmail.Text;

            //send profile update to server
            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.UpdateUserProfile(actualUser, tbUserPassword.Text);

            //if success
            if (serverPacketConfirmation.ActionSuccess)
                MessageBox.Show("Votre profil a correctement été mis à jour", "Profil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                //get the good error message
                String errorMessage = string.Empty;
                switch (serverPacketConfirmation.NetworkError)
                {
                    case NetworkError.SERVER_UNAVAILABLE:
                        errorMessage = MSGBank.ERROR_NO_SERVER;
                        break;
                    default:
                        errorMessage = $"Impossible de mettre à jour votre profil.";
                        break;
                }

                MessageBox.Show(errorMessage, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void UpdateDAuthLogo()
        {
            dAuthBtn.Image = Program.actualUserPrivateKey == null ? Properties.Resources.dauth_unlocked : Properties.Resources.dauth_locked;
        }

        private void OnFormShow(object sender, EventArgs e)
        {
            //get actual user
            PLFUser actualUser = Program.acutalUser;
            if (actualUser == null)
                return;

            //populate fields with user infos
            tbUserNick.Text = actualUser.UserNickName;
            tbUserSurname.Text = actualUser.UserSurname;
            tbUserName.Text = actualUser.UserName;

            tbUserEmail.Text = actualUser.UserEMail;

            tbUserPassword.Text = Program.formRegisterLogin.ActualUserPassword;
            tbUserPasswordConfirm.Text = Program.formRegisterLogin.ActualUserPassword;

            UpdateDAuthLogo();
        }

        private void OnFormDispose(object sender, EventArgs e)
        {
            //set board to null
            Program.mainBoard.UserProfileBoard = null;
            userDAuthSettingsForm?.Dispose();
            userDAuthSettingsForm = null;

        }

        private void pbBtnHideMenu_Click(object sender, EventArgs e)
        {
            //hide user profile board
            Program.mainBoard.HideUserProfile();
            userDAuthSettingsForm?.Dispose();
            userDAuthSettingsForm = null;
        }

        private void dAuthBtn_Click(object sender, EventArgs e)
        {
            if(userDAuthSettingsForm != null)
            {
                userDAuthSettingsForm.BringToFront();
                return;
            }

            userDAuthSettingsForm = new UserDAuthSettingsForm();
            userDAuthSettingsForm.Show();
        }

        public UserDAuthSettingsForm UserDAuthSettingsForm { get => userDAuthSettingsForm; set => userDAuthSettingsForm = value; }
    }
}
