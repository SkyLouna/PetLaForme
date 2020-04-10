using Foundation;
using LViOSLibrary.Helper;
using PetLaForme.Helper;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Communication.NetworkPackets.Server;
using System;
using UIKit;

namespace PetLaForme
{
    public partial class PasswordResetViewController : UIViewController
    {
        public PasswordResetViewController (IntPtr handle) : base (handle)
        {
        }

        partial void BtnAskForNewCode_TouchUpInside(UIButton sender)
        {
            //if fields are empty
            if (String.IsNullOrEmpty(tfNickNameField.Text))
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, "Vous devez remplir le champ 'Nom d'utilisateur'");
                return;
            }

            //send packet to server
            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.AskResetUserPassword(tfNickNameField.Text);

            //if success
            if (serverPacketConfirmation.ActionSuccess)
            {
                BarHelper.DisplayInfoBar(uivMainView, "Restauration de mot de passe", "Un nouveau code de restauration de mot de passe vous a été envoyé par mail !");
                btnAskForNewCode.Enabled = false;
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
            BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, messageError);
        }

        partial void BtnChangePassword_TouchUpInside(UIButton sender)
        {
            //if fields are empty
            if (String.IsNullOrEmpty(tfNickNameField.Text) || String.IsNullOrEmpty(tfCodeField.Text)
                || String.IsNullOrEmpty(tfPasswordField.Text))
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, MSGBank.ERROR_FILL_ALL_FIELDS);
                return;
            }

            //if not same password
            if (tfPasswordField.Text != tfPasswordConfirmField.Text)
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, MSGBank.ERROR_NOT_SAME_PASSWORD);
                return;
            }

            //send packet to server
            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.ResetUserPassword(tfNickNameField.Text, tfPasswordField.Text, tfCodeField.Text);
            if (serverPacketConfirmation.ActionSuccess)
            {
                MessageBox.ShowOK("Restauration de mot de passe", "Votre mot de passe a été mis à jour ! Vous pouvez désormais vous connecter avec celui-ci !", this, delegate { this.NavigationController.PopToRootViewController(true); });
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
            BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, messageError);
        }
    }
}