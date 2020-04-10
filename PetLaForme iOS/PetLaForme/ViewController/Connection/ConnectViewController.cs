using Foundation;

using System;
using UIKit;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Object.Ext;
using PetLaForme.Helper;
using PLFAPI.Communication.NetworkError;
using PetLaForme.Object.Connection;
using LocalAuthentication;
using LViOSLibrary.Helper;


namespace PetLaForme
{
    public partial class ConnectViewController : UIViewController
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PetLaForme.ConnectViewController"/> class.
        /// </summary>
        /// <param name="handle">Handle.</param>
        public ConnectViewController (IntPtr handle) : base (handle)
        {
        }

        /// <summary>
        /// Views the will appear.
        /// </summary>
        /// <param name="animated">If set to <c>true</c> animated.</param>
        public override void ViewWillAppear(bool animated)
        {
            //get user connection profile
            ConnectionProfile connectionProfile = ConnectionHelper.GetConnectionProfile();
            if (connectionProfile == null)
                return;

            //create nre Local Auth context
            var laContext = new LAContext();
            NSError AuthError;

            var authReason = new NSString("Connect to pet la forme");

            //if can evaluate policy with biometrics (FACE/TOUCH ID)
            if (laContext.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out AuthError))
            {
                //new reply handler 
                var replyHandler = new LAContextReplyHandler((success, error) =>
                {
                    this.InvokeOnMainThread(() =>
                    {
                        if (success)
                        {
                            Auth(connectionProfile);
                        }
                        else
                            Console.WriteLine("Auth fail");
                    });
                });
                //evaluate policy in actual local context
                laContext.EvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, authReason, replyHandler);
            }
            else
            {
                //also connect user because ios simulator don't have secret code and biometrics
                Auth(connectionProfile);
            }
        }

        /// <summary>
        /// Auth the specified connectionProfile.
        /// </summary>
        /// <param name="connectionProfile">Connection profile.</param>
        public void Auth(ConnectionProfile connectionProfile)
        {
            //send login packet
            ServerPacketUserLogin serverPacketUserLogin = ServerHelper.LoginUserHashed(connectionProfile.UserName, connectionProfile.UserPassword);

            //if login success
            if (serverPacketUserLogin.NetworkError == NetworkError.NONE)
            {
                //set actual user infos
                Application.ActualUser = serverPacketUserLogin.UserProfile;
                Application.UserPassword = tfPasswordField.Text;


                if(serverPacketUserLogin.UserAccountActivate)
                {

                    if (serverPacketUserLogin.UserDAuthPrivateKey != null)
                    {
                        Application.ActualUserPrivateKey = serverPacketUserLogin.UserDAuthPrivateKey;

                        PerformSegue("DAuthLoginSegue", this);
                        return;
                    }


                    //load user pets
                    Application.PetManager.LoadUserPetList(serverPacketUserLogin.UserProfile);

                    //instantiate main view controller
                    UIStoryboard mainBoard = UIStoryboard.FromName("Main", null);
                    MainTabBarController mainTabBarController = mainBoard.InstantiateViewController("MainTabBarController") as MainTabBarController;
                    PresentViewController(mainTabBarController, true, null);
                }
                else
                    PerformSegue("ConnectConfirmAccountSegue", this);
                return;
            }

            //chose right error message
            String messageError = string.Empty;
            switch (serverPacketUserLogin.NetworkError)
            {
                case NetworkError.GLOBAL_UNKNOWN:
                    goto default;
                case NetworkError.SQL_USER_UNKNOWN:
                    messageError = "Utilisateur ou mot de passe incorect";
                    break;
                case NetworkError.SERVER_UNAVAILABLE:
                    messageError = MSGBank.ERROR_NO_SERVER;
                    break;
                default:
                    messageError = MSGBank.ERROR_UNKNOWN;
                    break;
            }
            BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, messageError, 5);
            //ßMessageBox.ShowOK(MSGBank.ERROR_TITLE, messageError, this);
        }

        public override void ViewDidLoad()
        {
            //add events hadnlers
            tfNickField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                tfPasswordField.BecomeFirstResponder();
                return true;
            };
            tfPasswordField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                Connect();
                return true;
            };
            base.ViewDidLoad();
        }

        partial void BtnConnect_TouchUpInside(UIButton sender)
        {
            Connect();
        }

        private void Connect()
        {
            //if empty fields
            if (String.IsNullOrEmpty(tfNickField.Text) || String.IsNullOrEmpty(tfPasswordField.Text))
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, MSGBank.ERROR_FILL_ALL_FIELDS, 3);
                return;
            }

            ConnectionHelper.SaveConnectionProfile(tfNickField.Text, tfPasswordField.Text);

            Auth(new ConnectionProfile(tfNickField.Text, tfPasswordField.Text.HashSHA256()));
        }
    }
}