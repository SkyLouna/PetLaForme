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
    [Register ("ProfileModifyViewController")]
    partial class ProfileModifyViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSaveEdit { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfUserEmailField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfUserNameField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfUserNickNameField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfUserPasswordConfirmField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfUserPasswordField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfUserSurnameField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView uivMainView { get; set; }

        [Action ("BtnSaveEdit_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSaveEdit_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnSaveEdit != null) {
                btnSaveEdit.Dispose ();
                btnSaveEdit = null;
            }

            if (tfUserEmailField != null) {
                tfUserEmailField.Dispose ();
                tfUserEmailField = null;
            }

            if (tfUserNameField != null) {
                tfUserNameField.Dispose ();
                tfUserNameField = null;
            }

            if (tfUserNickNameField != null) {
                tfUserNickNameField.Dispose ();
                tfUserNickNameField = null;
            }

            if (tfUserPasswordConfirmField != null) {
                tfUserPasswordConfirmField.Dispose ();
                tfUserPasswordConfirmField = null;
            }

            if (tfUserPasswordField != null) {
                tfUserPasswordField.Dispose ();
                tfUserPasswordField = null;
            }

            if (tfUserSurnameField != null) {
                tfUserSurnameField.Dispose ();
                tfUserSurnameField = null;
            }

            if (uivMainView != null) {
                uivMainView.Dispose ();
                uivMainView = null;
            }
        }
    }
}