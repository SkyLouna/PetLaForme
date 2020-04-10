using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetLaFormeWin.Helper;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Helper;
using PLFAPI.Object.DAuth;

namespace PetLaFormeWin.Forms.User
{
    public partial class UserDAuthSettingsForm : Form
    {

        GoogleTOTP googleTOTP;

        public UserDAuthSettingsForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(delegate { Program.mainBoard.UserProfileBoard.UserDAuthSettingsForm = null; });
            if(Program.actualUserPrivateKey == null)
            {
                googleTOTP = new GoogleTOTP();
                btnDesactivateDAuth.Enabled = false;
                btnActivateDAuth.Enabled = true;
            } 
            else
            {
                googleTOTP = new GoogleTOTP(Program.actualUserPrivateKey);
                btnDesactivateDAuth.Enabled = true;
                btnActivateDAuth.Enabled = false;
            }

            pbQRCode.Image = googleTOTP.GenerateImage(256, 256, Program.acutalUser.UserEMail);
                
        }

        private void btnActivateDAuth_Click(object sender, EventArgs e)
        {

            if(String.IsNullOrEmpty(tbCodeBox.Text))
            {
                MessageBox.Show(MSGBank.ERROR_FILL_ALL_FIELDS, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (googleTOTP.GeneratePin().ToLower() != tbCodeBox.Text.ToLower())
            {
                MessageBox.Show("Code erroné", MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.EnableUserDAuth(Program.acutalUser, googleTOTP.getPrivateKey());

            //if success
            if (serverPacketConfirmation.ActionSuccess)
            {
                Program.actualUserPrivateKey = googleTOTP.getPrivateKey();
                DialogResult result = MessageBox.Show("La double authentification a bien été activée.", "Double authentification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    Program.mainBoard.UserProfileBoard.UserDAuthSettingsForm = null;
                    Program.mainBoard.UserProfileBoard.UpdateDAuthLogo();
                    this.Dispose();
                }
            }
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
                        errorMessage = $"Impossible d'activer la double authentification.";
                        break;
                }

                MessageBox.Show(errorMessage, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDesactivateDAuth_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Êtes vous sûr de vouloir supprimer la double authentification?", "Double Authentification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.Yes)
            {
                ServerPacketConfirmation serverPacketConfirmation = ServerHelper.DisableUserDAuth(Program.acutalUser);

                //if success
                if (serverPacketConfirmation.ActionSuccess)
                {
                    DialogResult result = MessageBox.Show("La double authentification a bien été désactivée.", "Double authentification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        Program.mainBoard.UserProfileBoard.UserDAuthSettingsForm = null;
                        Program.actualUserPrivateKey = null;
                        Program.mainBoard.UserProfileBoard.UpdateDAuthLogo();
                        this.Dispose();
                    }
                }
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
                            errorMessage = $"Impossible de désactiver la double authentification.";
                            break;
                    }

                    MessageBox.Show(errorMessage, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
