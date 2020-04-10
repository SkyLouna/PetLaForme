using Foundation;
using PetLaForme.Helper;
using System;
using UIKit;

namespace PetLaForme
{
    public partial class ProfilePreviewViewController : UIViewController
    {
        public ProfilePreviewViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if (Application.ActualUserPrivateKey == null)
                btnDAuthShow.SetImage(new UIImage("Icon/dauth-unlocked.png"), UIControlState.Normal);
            else 
                btnDAuthShow.SetImage(new UIImage("Icon/dauth-locked.png"), UIControlState.Normal);
        }

        public override void ViewDidLoad()
        {
            //populate fields
            lblUserNameTitle.Text = Application.ActualUser.UserNickName;
            lblAmountOfPets.Text = $"Nombre de familiers: {Application.PetManager.UserOwnPets.Count}";
        }

        partial void BtnLogout_TouchUpInside(UIButton sender)
        {
            //set actual user to false
            Application.ActualUser = null;
            Application.UserPassword = "";
            Application.ActualUserPrivateKey = null;

            //delete conn profile
            ConnectionHelper.DeleteConnectionProfile();

        }
    }
}