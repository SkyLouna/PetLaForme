using Foundation;
using PetLaForme.Helper;
using PLFAPI.Object.User;
using PLFAPI.Object.Ext;
using System;
using UIKit;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Communication.NetworkError;
using LViOSLibrary.Helper;

namespace PetLaForme
{
    public partial class ProfileModifyViewController : UIViewController
    {
        public ProfileModifyViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {

            //populate fields with selected user properties
            PLFUser selectedUser = Application.ActualUser;

            //populate fields
            tfUserNickNameField.Text = selectedUser.UserNickName;
            tfUserSurnameField.Text = selectedUser.UserSurname;
            tfUserNameField.Text = selectedUser.UserName;
            tfUserEmailField.Text = selectedUser.UserEMail;

            tfUserPasswordField.Text = Application.UserPassword;
            tfUserPasswordConfirmField.Text = Application.UserPassword;

            //add event handlers
            tfUserNickNameField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                return true;
            };
            tfUserSurnameField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                return true;
            };
            tfUserNameField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                return true;
            };
            tfUserEmailField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                return true;
            };
            tfUserPasswordField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                tfUserPasswordConfirmField.BecomeFirstResponder();
                return true;
            };
            tfUserPasswordConfirmField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                return true;
            };
        }

        partial void BtnSaveEdit_TouchUpInside(UIButton sender)
        {

            //if some fields are empty
            if (String.IsNullOrEmpty(tfUserEmailField.Text) || String.IsNullOrEmpty(tfUserPasswordField.Text))
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, MSGBank.ERROR_FILL_ALL_FIELDS);
                return;
            }

            //if email is valid
            if (!tfUserEmailField.Text.IsValidEmail())
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, MSGBank.ERROR_WRONG_EMAIL);
                return;
            }

            //if the two passwords are the same
            if (tfUserPasswordField.Text != tfUserPasswordConfirmField.Text)
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, MSGBank.ERROR_NOT_SAME_PASSWORD);
                return;
            }

            //change actual user infos
            PLFUser actualUser = Application.ActualUser;
            actualUser.UserName = tfUserNameField.Text;
            actualUser.UserSurname = tfUserSurnameField.Text;
            actualUser.UserEMail = tfUserEmailField.Text;

            //send profile update to server
            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.UpdateUserProfile(actualUser, tfUserPasswordField.Text);

            //if success
            if (serverPacketConfirmation.ActionSuccess)
                BarHelper.DisplayInfoBar(uivMainView, "Profil", "Votre profil a correctement été mis à jour.");
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
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, errorMessage);
            }

        }
    }
}