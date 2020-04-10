// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PetLaForme
{
    [Register ("ProfilePreviewViewController")]
    partial class ProfilePreviewViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDAuthShow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnEditProfile { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLogout { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblAmountOfPets { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblUserNameTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView uivMainView { get; set; }

        [Action ("BtnLogout_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnLogout_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnDAuthShow != null) {
                btnDAuthShow.Dispose ();
                btnDAuthShow = null;
            }

            if (btnEditProfile != null) {
                btnEditProfile.Dispose ();
                btnEditProfile = null;
            }

            if (btnLogout != null) {
                btnLogout.Dispose ();
                btnLogout = null;
            }

            if (lblAmountOfPets != null) {
                lblAmountOfPets.Dispose ();
                lblAmountOfPets = null;
            }

            if (lblUserNameTitle != null) {
                lblUserNameTitle.Dispose ();
                lblUserNameTitle = null;
            }

            if (uivMainView != null) {
                uivMainView.Dispose ();
                uivMainView = null;
            }
        }
    }
}