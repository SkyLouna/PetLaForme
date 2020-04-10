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
    [Register ("PasswordResetViewController")]
    partial class PasswordResetViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAskForNewCode { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnChangePassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfCodeField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfNickNameField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfPasswordConfirmField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfPasswordField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView uivMainView { get; set; }

        [Action ("BtnAskForNewCode_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnAskForNewCode_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnChangePassword_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnChangePassword_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnAskForNewCode != null) {
                btnAskForNewCode.Dispose ();
                btnAskForNewCode = null;
            }

            if (btnChangePassword != null) {
                btnChangePassword.Dispose ();
                btnChangePassword = null;
            }

            if (tfCodeField != null) {
                tfCodeField.Dispose ();
                tfCodeField = null;
            }

            if (tfNickNameField != null) {
                tfNickNameField.Dispose ();
                tfNickNameField = null;
            }

            if (tfPasswordConfirmField != null) {
                tfPasswordConfirmField.Dispose ();
                tfPasswordConfirmField = null;
            }

            if (tfPasswordField != null) {
                tfPasswordField.Dispose ();
                tfPasswordField = null;
            }

            if (uivMainView != null) {
                uivMainView.Dispose ();
                uivMainView = null;
            }
        }
    }
}