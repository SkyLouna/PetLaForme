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
    [Register ("RegisterViewController")]
    partial class RegisterViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnRegister { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfEmailField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfNameField { get; set; }

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
        UIKit.UITextField tfSurnameField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView uivMainView { get; set; }

        [Action ("BtnRegister_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnRegister_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnRegister != null) {
                btnRegister.Dispose ();
                btnRegister = null;
            }

            if (tfEmailField != null) {
                tfEmailField.Dispose ();
                tfEmailField = null;
            }

            if (tfNameField != null) {
                tfNameField.Dispose ();
                tfNameField = null;
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

            if (tfSurnameField != null) {
                tfSurnameField.Dispose ();
                tfSurnameField = null;
            }

            if (uivMainView != null) {
                uivMainView.Dispose ();
                uivMainView = null;
            }
        }
    }
}