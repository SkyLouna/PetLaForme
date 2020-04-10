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
    [Register ("AttributViewController")]
    partial class AttributViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDeleteAttribut { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSaveChanges { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ivAttributIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView pvAttributTypePicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfAttributName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView tvAttributDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView uivMainView { get; set; }

        [Action ("BtnDeleteAttribut_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnDeleteAttribut_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnSaveChanges_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSaveChanges_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnDeleteAttribut != null) {
                btnDeleteAttribut.Dispose ();
                btnDeleteAttribut = null;
            }

            if (btnSaveChanges != null) {
                btnSaveChanges.Dispose ();
                btnSaveChanges = null;
            }

            if (ivAttributIcon != null) {
                ivAttributIcon.Dispose ();
                ivAttributIcon = null;
            }

            if (pvAttributTypePicker != null) {
                pvAttributTypePicker.Dispose ();
                pvAttributTypePicker = null;
            }

            if (tfAttributName != null) {
                tfAttributName.Dispose ();
                tfAttributName = null;
            }

            if (tvAttributDescription != null) {
                tvAttributDescription.Dispose ();
                tvAttributDescription = null;
            }

            if (uivMainView != null) {
                uivMainView.Dispose ();
                uivMainView = null;
            }
        }
    }
}