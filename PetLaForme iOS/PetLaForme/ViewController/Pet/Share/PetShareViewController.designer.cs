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
    [Register ("PetShareViewController")]
    partial class PetShareViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCancelShare { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSharePet { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ivPetIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView pvUserPetView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch swAllowModifications { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfShareUserName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView uivMainView { get; set; }

        [Action ("BtnSharePet_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSharePet_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnCancelShare != null) {
                btnCancelShare.Dispose ();
                btnCancelShare = null;
            }

            if (btnSharePet != null) {
                btnSharePet.Dispose ();
                btnSharePet = null;
            }

            if (ivPetIcon != null) {
                ivPetIcon.Dispose ();
                ivPetIcon = null;
            }

            if (pvUserPetView != null) {
                pvUserPetView.Dispose ();
                pvUserPetView = null;
            }

            if (swAllowModifications != null) {
                swAllowModifications.Dispose ();
                swAllowModifications = null;
            }

            if (tfShareUserName != null) {
                tfShareUserName.Dispose ();
                tfShareUserName = null;
            }

            if (uivMainView != null) {
                uivMainView.Dispose ();
                uivMainView = null;
            }
        }
    }
}