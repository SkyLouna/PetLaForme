using PLFAPI.Object.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetLaFormeWin.Forms;
using PetLaFormeWin.Manager;

namespace PetLaFormeWin
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        ///

        public static PLFUser acutalUser;                               //actual connected user
        public static Boolean actualUserConfirmed;                      //actual user profile is confirmed
        public static byte[] actualUserPrivateKey;                      //actual user private dauth key
        public static FormRegisterLogin formRegisterLogin;              //login form
        public static MainBoard mainBoard;                              //main board form

        public static PetManager petManager;                            //pet manager

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //init pet manager
            Program.petManager = new PetManager();

            formRegisterLogin = new FormRegisterLogin();

            Application.Run(formRegisterLogin);
        }
    }
}
