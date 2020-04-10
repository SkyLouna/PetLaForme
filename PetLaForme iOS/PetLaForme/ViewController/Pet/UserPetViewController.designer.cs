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
    [Register ("UserPetViewController")]
    partial class UserPetViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAddAttribut { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDeletePet { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSharePet { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ivIsSharedPet { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ivPetIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPetName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPetType { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView svAttributListView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView uivMainView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView uivPetInfosContainer { get; set; }

        [Action ("BtnAddAttribut_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnAddAttribut_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnDeletePet_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnDeletePet_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnSharePet_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSharePet_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnAddAttribut != null) {
                btnAddAttribut.Dispose ();
                btnAddAttribut = null;
            }

            if (btnDeletePet != null) {
                btnDeletePet.Dispose ();
                btnDeletePet = null;
            }

            if (btnSharePet != null) {
                btnSharePet.Dispose ();
                btnSharePet = null;
            }

            if (ivIsSharedPet != null) {
                ivIsSharedPet.Dispose ();
                ivIsSharedPet = null;
            }

            if (ivPetIcon != null) {
                ivPetIcon.Dispose ();
                ivPetIcon = null;
            }

            if (lblPetName != null) {
                lblPetName.Dispose ();
                lblPetName = null;
            }

            if (lblPetType != null) {
                lblPetType.Dispose ();
                lblPetType = null;
            }

            if (svAttributListView != null) {
                svAttributListView.Dispose ();
                svAttributListView = null;
            }

            if (uivMainView != null) {
                uivMainView.Dispose ();
                uivMainView = null;
            }

            if (uivPetInfosContainer != null) {
                uivPetInfosContainer.Dispose ();
                uivPetInfosContainer = null;
            }
        }
    }
}