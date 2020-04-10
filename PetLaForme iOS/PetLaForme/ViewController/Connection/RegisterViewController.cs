using Foundation;
using System;
using UIKit;
using PLFAPI.Object.Ext;
using PLFAPI.Object.User;
using PetLaForme.Helper;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Communication.NetworkError;
using LViOSLibrary.Helper;

namespace PetLaForme
{
    public partial class RegisterViewController : UIViewController
    {
        public RegisterViewController (IntPtr handle) : base (handle)
        {
        }

        /// <summary>
        /// Views the did load.
        /// </summary>
        public override void ViewDidLoad()
        {
            //add event handlers
            tfSurnameField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                tfNameField.BecomeFirstResponder();
                return true;
            };
            tfNameField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                tfEmailField.BecomeFirstResponder();
                return true;
            };
            tfEmailField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                tfNickNameField.BecomeFirstResponder();
                return true;
            };
            tfNickNameField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                tfPasswordField.BecomeFirstResponder();
                return true;
            };
            tfPasswordField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                tfPasswordConfirmField.BecomeFirstResponder();
                return true;
            };
            tfPasswordConfirmField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                Register();
                return true;
            };
        }

        /// <summary>
        /// Buttons the register touch up inside.
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void BtnRegister_TouchUpInside(UIButton sender)
        {
            Register();
        }

        /// <summary>
        /// Register this instance.
        /// </summary>
        void Register()
        {
            //if fields are empty
            if (String.IsNullOrEmpty(tfNickNameField.Text) || String.IsNullOrEmpty(tfEmailField.Text)
                || String.IsNullOrEmpty(tfPasswordField.Text))
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, MSGBank.ERROR_FILL_ALL_FIELDS);
                return;
            }

            //if invalid email
            if (!tfEmailField.Text.IsValidEmail())
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, MSGBank.ERROR_WRONG_EMAIL);
                return;
            }

            //if not same password
            if (tfPasswordField.Text != tfPasswordConfirmField.Text)
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, MSGBank.ERROR_NOT_SAME_PASSWORD);
                return;
            }

            //init new user with register properties
            PLFUser user = new PLFUser();
            user.UserName = tfNameField.Text;
            user.UserSurname = tfSurnameField.Text;
            user.UserEMail = tfEmailField.Text;
            user.UserNickName = tfNickNameField.Text;

            //send register packet
            ServerPacketUserRegister serverPacketUserRegister = ServerHelper.RegisterUser(user, tfPasswordField.Text);

            //if register success
            if (serverPacketUserRegister.RegisterSuccess)
            {
                //Set user id with received user id
                user.ID = serverPacketUserRegister.UserID;

                //set the actual user
                Application.ActualUser = user;
                Application.UserPassword = tfPasswordField.Text;

                //load user pet list
                Application.PetManager.LoadUserPetList(user);

                BarHelper.DisplayInfoBar(uivMainView, "Inscription", $"Super ! Vous vous êtes bien inscrit sous le nom de {user.UserNickName} !", 3,
                 delegate {
                    ConnectionHelper.SaveConnectionProfile(tfNickNameField.Text, tfPasswordField.Text);
                    PerformSegue("RegisterConfirmAccountSegue", this);

                    //reset register fields
                    tfNameField.Text = string.Empty;
                    tfSurnameField.Text = string.Empty;
                    tfEmailField.Text = string.Empty;
                    tfNickNameField.Text = string.Empty;
                    tfPasswordField.Text = string.Empty;
                    tfPasswordConfirmField.Text = string.Empty;

                },
                delegate {
                    ConnectionHelper.SaveConnectionProfile(tfNickNameField.Text, tfPasswordField.Text);
                    PerformSegue("RegisterConfirmAccountSegue", this);

                    //reset register fields
                    tfNameField.Text = string.Empty;
                    tfSurnameField.Text = string.Empty;
                    tfEmailField.Text = string.Empty;
                    tfNickNameField.Text = string.Empty;
                    tfPasswordField.Text = string.Empty;
                    tfPasswordConfirmField.Text = string.Empty;

                });

                return;
            }

            //chose right error message
            String messageError = string.Empty;
            switch (serverPacketUserRegister.NetworkError)
            {
                case NetworkError.GLOBAL_UNKNOWN:
                    goto default;
                case NetworkError.SERVER_UNAVAILABLE:
                    messageError = MSGBank.ERROR_NO_SERVER;
                    break;
                case NetworkError.SQL_USER_EXIST:
                    messageError = "Ce nom d'utilisateur est deja pris !";
                    break;
                default:
                    messageError = MSGBank.ERROR_UNKNOWN;
                    break;
            }

            BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, messageError);
            
        }
    }
}