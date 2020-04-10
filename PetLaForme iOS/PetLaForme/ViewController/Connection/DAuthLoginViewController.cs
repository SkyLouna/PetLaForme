using Foundation;
using LViOSLibrary.Helper;
using PetLaForme.Helper;
using PLFAPI.Helper;
using System;
using UIKit;

namespace PetLaForme
{
    public partial class DAuthLoginViewController : UIViewController
    {
        public DAuthLoginViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        partial void BtnConfirmDAuth_TouchUpInside(UIButton sender)
        {
            if (String.IsNullOrEmpty(tfCodeField.Text))
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, MSGBank.ERROR_FILL_ALL_FIELDS);
                return;
            }

            String userCode = DAuthHelper.GetUserCode(Application.ActualUserPrivateKey);

            if (tfCodeField.Text.ToLower() != userCode.ToLower())
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, "Ce code est erroné");
                return;
            }

            //load user pets
            Application.PetManager.LoadUserPetList(Application.ActualUser);

            //instantiate main view controller
            UIStoryboard mainBoard = UIStoryboard.FromName("Main", null);
            MainTabBarController mainTabBarController = mainBoard.InstantiateViewController("MainTabBarController") as MainTabBarController;
            PresentViewController(mainTabBarController, true, null);
        }
    }
}