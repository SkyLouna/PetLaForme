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
    public partial class UserAccountConfirmForm : Form
    {
        public UserAccountConfirmForm()
        {
            InitializeComponent();
            this.FormClosing += delegate {
                //set actual user to null
                Program.acutalUser = null;

                ConnectionHelper.DeleteConnectionProfile();

                //dispose this form and show login form
                Program.mainBoard.Dispose();
                Program.formRegisterLogin.Show();
            };
        }

        private void btnActivateAccount_Click(object sender, EventArgs e)
        {
            String confirmationCode = tbUserCodeBox.Text;

            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.ConfirmUserAccount(Program.acutalUser, confirmationCode);

            if(serverPacketConfirmation.ActionSuccess)
            {
               DialogResult result = MessageBox.Show("Votre compte a été confirmé ! ", "Compte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    //set actual user to null
                    Program.acutalUser = null;

                    ConnectionHelper.DeleteConnectionProfile();

                    //dispose this form and show login form
                    Program.mainBoard.Dispose();
                    Program.formRegisterLogin.Show();
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
                case NetworkError.SQL_USER_WRONG_ACCODE:
                    messageError = "Ce code d'activation n'existe pas.";
                    break;
                case NetworkError.SERVER_UNAVAILABLE:
                    messageError = MSGBank.ERROR_NO_SERVER;
                    break;
                default:
                    messageError = MSGBank.ERROR_UNKNOWN;
                    break;
            }

            MessageBox.Show(messageError, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnNewCode_Click(object sender, EventArgs e)
        {
            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.AskConfirmUserAccount(Program.acutalUser, Program.formRegisterLogin.ActualUserPassword);
            if (serverPacketConfirmation.ActionSuccess)
            {
                DialogResult result = MessageBox.Show($"Un nouveau code d'activation a été envoyé par mail à  {Program.acutalUser.UserEMail}.", 
                    "Compte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    btnNewCode.Enabled = false;
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
                default:
                    messageError = MSGBank.ERROR_UNKNOWN;
                    break;
            }

            MessageBox.Show(messageError, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
