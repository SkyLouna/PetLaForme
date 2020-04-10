using Foundation;
using LViOSLibrary.Helper;
using PetLaForme.Helper;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Object.DAuth;
using SafariServices;
using System;
using UIKit;

namespace PetLaForme
{
    public partial class DAuthConfigViewController : UIViewController
    {

        GoogleTOTP googleTOTP;

        public DAuthConfigViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            if (Application.ActualUserPrivateKey == null)
            {
                googleTOTP = new GoogleTOTP();
                btnDesactivateDAuth.Enabled = false;
                btnActivateDAuth.Enabled = true;
            }
            else
            {
                googleTOTP = new GoogleTOTP(Application.ActualUserPrivateKey);
                btnDesactivateDAuth.Enabled = true;
                btnActivateDAuth.Enabled = false;
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        partial void BtnShowWebQR_TouchUpInside(UIButton sender)
        {
            var safariView = new SFSafariViewController(new NSUrl(googleTOTP.GetURL(256, 256, Application.ActualUser.UserEMail)));
            PresentViewController(safariView, true, null);
        }

        partial void BtnActivateDAuth_TouchUpInside(UIButton sender)
        {
            if (String.IsNullOrEmpty(tfCodeField.Text))
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, MSGBank.ERROR_FILL_ALL_FIELDS);
                return;
            }

            if (googleTOTP.GeneratePin().ToLower() != tfCodeField.Text.ToLower())
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, "Code erroné !");
                return;
            }

            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.EnableUserDAuth(Application.ActualUser, googleTOTP.getPrivateKey());

            //if success
            if (serverPacketConfirmation.ActionSuccess)
            {
                Application.ActualUserPrivateKey = googleTOTP.getPrivateKey();
                MessageBox.ShowOK("Double authentification", "La double authentification a bien été activée.", this, 
                                  delegate { this.NavigationController.PopToRootViewController(true); });
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
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, errorMessage);
            }

        }

        partial void BtnDesactivateDAuth_TouchUpInside(UIButton sender)
        {
            MessageBox.ShowYesNo("Double Authentification", "Êtes vous sûr de vouloir supprimer la double authentification?", 
            delegate
            {
                ServerPacketConfirmation serverPacketConfirmation = ServerHelper.DisableUserDAuth(Application.ActualUser);

                //if success
                if (serverPacketConfirmation.ActionSuccess)
                    MessageBox.ShowOK("Double authentification","La double authentification a bien été désactivée.", this, delegate {
                        Application.ActualUserPrivateKey = null;
                        this.NavigationController.PopToRootViewController(true);
                    });
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
                    BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, errorMessage);
                }
            }, 
            delegate
            {
                //no action
            }, 
            this);
        }
    }
}