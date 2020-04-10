using Foundation;
using LViOSLibrary.Helper;
using PetLaForme.Helper;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Communication.NetworkPackets.Server;
using System;
using UIKit;

namespace PetLaForme
{
    public partial class AccountConfirmViewController : UIViewController
    {
        public AccountConfirmViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //add event handlers
            tfConfirmationCodeField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                ConfirmAccount();
                return true;
            };
        }

        partial void BtnAskForNewCode_TouchUpInside(UIButton sender)
        {
            //send packet to server
            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.AskConfirmUserAccount(Application.ActualUser, Application.UserPassword);

            //if success
            if (serverPacketConfirmation.ActionSuccess)
            {
                BarHelper.DisplayInfoBar(uivMainView, "Compte", $"Un nouveau code d'activation a été envoyé par mail à  {Application.ActualUser.UserEMail}.",10,
                                         delegate { tfConfirmationCodeField.BecomeFirstResponder(); btnAskForNewCode.Enabled = false; },
                                         delegate { tfConfirmationCodeField.BecomeFirstResponder(); btnAskForNewCode.Enabled = false; });
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

            MessageBox.ShowOK(MSGBank.ERROR_TITLE, messageError, this);
        }

        partial void UIButton63670_TouchUpInside(UIButton sender)
        {
            //confirm account
            ConfirmAccount();
        }

        public void ConfirmAccount()
        {
            //get confirmation code
            String confirmationCode = tfConfirmationCodeField.Text;

            //send packet to server
            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.ConfirmUserAccount(Application.ActualUser, confirmationCode);

            //if success
            if (serverPacketConfirmation.ActionSuccess)
            {
                BarHelper.DisplayInfoBar(uivMainView, "Compte", "Votre compte a été confirmé", 5, delegate 
                { 
                    //load user pets
                    Application.PetManager.LoadUserPetList(Application.ActualUser);

                    //instantiate main view controller
                    UIStoryboard mainBoard = UIStoryboard.FromName("Main", null);
                    MainTabBarController mainTabBarController = mainBoard.InstantiateViewController("MainTabBarController") as MainTabBarController;
                    PresentViewController(mainTabBarController, true, null);
                }, delegate 
                {
                    //load user pets
                    Application.PetManager.LoadUserPetList(Application.ActualUser);

                    //instantiate main view controller
                    UIStoryboard mainBoard = UIStoryboard.FromName("Main", null);
                    MainTabBarController mainTabBarController = mainBoard.InstantiateViewController("MainTabBarController") as MainTabBarController;
                    PresentViewController(mainTabBarController, true, null);
                });

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
            BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, messageError);
        }
    }
}