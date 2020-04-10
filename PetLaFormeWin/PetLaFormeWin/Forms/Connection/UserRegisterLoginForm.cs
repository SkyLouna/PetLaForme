using PLFAPI.Object.User;
using System;
using System.Windows.Forms;
using PLFAPI.Communication.NetworkPackets.Server;
using PetLaFormeWin.Helper;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Object.Ext;
using PetLaFormeWin.Object.Connection;
using PetLaFormeWin.Forms;
using PetLaFormeWin.Forms.Connection;
using PLFAPI.Helper;

namespace PetLaFormeWin
{
    public partial class FormRegisterLogin : Form
    {

        protected String actualUserPassword;            //actual user protected password

        UserResetPasswordForm userResetPasswordForm;

        DAuthLoginForm dAuthLoginForm;

        public FormRegisterLogin()
        {
            //init component
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            if (!Properties.Settings.Default.AllowAutoLogin)
                return;

            ConnectionProfile connectionProfile = ConnectionHelper.GetConnectionProfile();
            if (connectionProfile == null)
                return;

            Auth(connectionProfile);
        }

        public void Auth(ConnectionProfile connectionProfile)
        {
            //send login packet
            ServerPacketUserLogin serverPacketUserLogin = ServerHelper.LoginUserHashed(connectionProfile.UserName, connectionProfile.UserPassword);

            //if login success
            if (serverPacketUserLogin.NetworkError == NetworkError.NONE)
            {
                //set actual user
                Program.acutalUser = serverPacketUserLogin.UserProfile;
                Program.actualUserConfirmed = serverPacketUserLogin.UserAccountActivate;
                actualUserPassword = tbConnectionUserPassword.Text;

                if (serverPacketUserLogin.UserDAuthPrivateKey != null)
                {
                    this.Enabled = false;

                    Program.actualUserPrivateKey = serverPacketUserLogin.UserDAuthPrivateKey;

                    dAuthLoginForm = new DAuthLoginForm();
                    dAuthLoginForm.Show();
                    dAuthLoginForm.BringToFront();
                    return;
                }

                //reset connection fields
                tbConnectionUserName.Text = "";
                tbConnectionUserPassword.Text = "";

                //hide register form and show main board
                Program.formRegisterLogin.Hide();
                Program.mainBoard = new MainBoard();
                Program.mainBoard.Show();
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

            MessageBox.Show(messageError, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //if fields are empty
            if (String.IsNullOrEmpty(tbRegisterUserNick.Text) || String.IsNullOrEmpty(tbRegisterUserEmail.Text)
                || String.IsNullOrEmpty(tbRegisterUserPassword.Text))
            {
                MessageBox.Show(MSGBank.ERROR_FILL_ALL_FIELDS, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if invalid email
            if (!tbRegisterUserEmail.Text.IsValidEmail())
            {
                MessageBox.Show(MSGBank.ERROR_WRONG_EMAIL, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if not same password
            if (tbRegisterUserPassword.Text != tbRegisterUserPasswordConfirm.Text)
            {
                MessageBox.Show(MSGBank.ERROR_NOT_SAME_PASSWORD, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //init new user with register properties
            PLFUser user = new PLFUser();
            user.UserName = tbRegisterUserName.Text;
            user.UserSurname = tbRegisterUserSurName.Text;
            user.UserEMail = tbRegisterUserEmail.Text;
            user.UserNickName = tbRegisterUserNick.Text;

            //send register packet
            ServerPacketUserRegister serverPacketUserRegister = ServerHelper.RegisterUser(user, tbRegisterUserPassword.Text);

            //if register success
            if (serverPacketUserRegister.RegisterSuccess)
            {
                //fill connection fields
                tbConnectionUserName.Text = user.UserNickName;
                tbConnectionUserPassword.Text = tbRegisterUserPassword.Text;

                ConnectionHelper.SaveConnectionProfile(user.UserNickName, tbRegisterUserPassword.Text);

                //show register confirmation
                MessageBox.Show($"Super ! Vous vous êtes bien inscrit sous le nom de {user.UserNickName} !", "Inscription",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                user.ID = serverPacketUserRegister.UserID;

                //reset register fields
                tbRegisterUserName.Text = string.Empty;
                tbRegisterUserSurName.Text = string.Empty;
                tbRegisterUserEmail.Text = string.Empty;
                tbRegisterUserNick.Text = string.Empty;
                tbRegisterUserPassword.Text = string.Empty;
                tbRegisterUserPasswordConfirm.Text = string.Empty;

                return;
            }

            //chose right error message
            String messageError = string.Empty;
            switch(serverPacketUserRegister.NetworkError)
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

            MessageBox.Show(messageError, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            //if empty fields
            if (String.IsNullOrEmpty(tbConnectionUserName.Text) || String.IsNullOrEmpty(tbConnectionUserPassword.Text))
            {
                MessageBox.Show(MSGBank.ERROR_FILL_ALL_FIELDS, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //send login packet
            ServerPacketUserLogin serverPacketUserLogin = ServerHelper.LoginUser(tbConnectionUserName.Text, tbConnectionUserPassword.Text);

            //if login success
            if(serverPacketUserLogin.NetworkError == NetworkError.NONE)
            {
                //set actual user
                Program.acutalUser = serverPacketUserLogin.UserProfile;
                Program.actualUserConfirmed = serverPacketUserLogin.UserAccountActivate;
                actualUserPassword = tbConnectionUserPassword.Text;

                //save user connection profile
                ConnectionHelper.SaveConnectionProfile(tbConnectionUserName.Text, tbConnectionUserPassword.Text);

                //if user has an double auth key
                if(serverPacketUserLogin.UserDAuthPrivateKey != null)
                {
                    //disable main form
                    this.Enabled = false;
                    //set actual key
                    Program.actualUserPrivateKey = serverPacketUserLogin.UserDAuthPrivateKey;
                    dAuthLoginForm = new DAuthLoginForm();
                    dAuthLoginForm.Show();
                    dAuthLoginForm.BringToFront();
                    return;
                }

                //reset connection fields
                tbConnectionUserName.Text = "";
                tbConnectionUserPassword.Text = "";

                //hide register form and show main board
                Program.formRegisterLogin.Hide();
                Program.mainBoard = new MainBoard();
                Program.mainBoard.Show();

                if (userResetPasswordForm != null)
                    userResetPasswordForm.Dispose();


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

            MessageBox.Show(messageError, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
              
        private void lblPasswordLost_Click(object sender, EventArgs e)
        {
            if(userResetPasswordForm != null)
            {
                userResetPasswordForm.BringToFront();
                return;
            }
            userResetPasswordForm = new UserResetPasswordForm(tbConnectionUserName.Text);
            userResetPasswordForm.Show();
        }

        public string ActualUserPassword { get => actualUserPassword; set => actualUserPassword = value; }
        public UserResetPasswordForm UserResetPasswordForm { get => userResetPasswordForm; set => userResetPasswordForm = value; }
        public DAuthLoginForm DAuthLoginForm { get => dAuthLoginForm; set => dAuthLoginForm = value; }
    }
}
