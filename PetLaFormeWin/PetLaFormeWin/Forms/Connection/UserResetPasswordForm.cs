using PetLaFormeWin.Helper;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Communication.NetworkPackets.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetLaFormeWin.Forms
{
    public partial class UserResetPasswordForm : Form
    {
        public UserResetPasswordForm(String userName)
        {
            InitializeComponent();
            tbNickNameBox.Text = userName;
            this.FormClosing += new FormClosingEventHandler(delegate { Program.formRegisterLogin.UserResetPasswordForm = null; this.Dispose(); });
        }

        private void btnAskForNewCode_Click(object sender, EventArgs e)
        {

            //if fields are empty
            if (String.IsNullOrEmpty(tbNickNameBox.Text))
            {
                MessageBox.Show("Vous devez remplir le champ 'Nom d'utilisateur'", MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.AskResetUserPassword(tbNickNameBox.Text);
            if (serverPacketConfirmation.ActionSuccess)
            {
                DialogResult result = MessageBox.Show($"Un nouveau code de restauration de mot de passe vous a été envoyé par mail !",
                    "Restauration de mot de passe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    btnAskForNewCode.Enabled = false;
                }
                return;
            }

            //chose right error message
            String messageError = string.Empty;
            switch (serverPacketConfirmation.NetworkError)
            {
                case NetworkError.GLOBAL_UNKNOWN:
                    goto default;
                case NetworkError.SERVER_UNAVAILABLE:
                    messageError = MSGBank.ERROR_NO_SERVER;
                    break;
                case NetworkError.SQL_USER_UNKNOWN:
                    messageError = MSGBank.ERROR_UNKNOWN_USER;
                    break;
                default:
                    messageError = MSGBank.ERROR_UNKNOWN;
                    break;
            }

            MessageBox.Show(messageError, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            //if fields are empty
            if (String.IsNullOrEmpty(tbNickNameBox.Text) || String.IsNullOrEmpty(tbResetCodeBox.Text)
                || String.IsNullOrEmpty(tbPasswordBox.Text))
            {
                MessageBox.Show(MSGBank.ERROR_FILL_ALL_FIELDS, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if not same password
            if (tbPasswordBox.Text != tbPasswordConfirmBox.Text)
            {
                MessageBox.Show(MSGBank.ERROR_NOT_SAME_PASSWORD, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if not accept 
            if (!cbPasswordChangeAllow.Checked)
            {
                MessageBox.Show("Vous devez accepter le changement de votre mot de passe !", MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.ResetUserPassword(tbNickNameBox.Text, tbPasswordBox.Text, tbResetCodeBox.Text);
            if (serverPacketConfirmation.ActionSuccess)
            {
                DialogResult result = MessageBox.Show($"Votre mot de passe a été mis à jour ! Vous pouvez désormais vous connecter avec celui-ci !",
                    "Restauration de mot de passe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Dispose();
                }
                return;
            }

            //chose right error message
            String messageError = string.Empty;
            switch (serverPacketConfirmation.NetworkError)
            {
                case NetworkError.GLOBAL_UNKNOWN:
                    goto default;
                case NetworkError.SERVER_UNAVAILABLE:
                    messageError = MSGBank.ERROR_NO_SERVER;
                    break;
                case NetworkError.SQL_USER_UNKNOWN:
                    messageError = MSGBank.ERROR_UNKNOWN_USER;
                    break;
                case NetworkError.SQL_USER_WRONG_ACCODE:
                    messageError = "Ce code de restauration n'existe pas ou n'est plus valide !";
                    break;
                default:
                    messageError = MSGBank.ERROR_UNKNOWN;
                    break;
            }

            MessageBox.Show(messageError, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
