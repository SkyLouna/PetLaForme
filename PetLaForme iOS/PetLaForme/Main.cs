using UIKit;
using PLFAPI.Object.User;
using PetLaForme.Manager;

namespace PetLaForme
{
    public class Application
    {

        static PLFUser actualUser;                          //actual user
        static string userPassword;                         //Actual user password
        static byte[] actualUserPrivateKey;                 //actual user private dauth key

        static PetManager petManager;                       //Pet manager
            


        // This is the main entry point of the application.
        static void Main(string[] args)
        {


            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");

        }

        public static string UserPassword { get => userPassword; set => userPassword = value; }
        public static PLFUser ActualUser { get => actualUser; set => actualUser = value; }
        public static PetManager PetManager { get => petManager; set => petManager = value; }
        public static byte[] ActualUserPrivateKey { get => actualUserPrivateKey; set => actualUserPrivateKey = value; }
    }
}
