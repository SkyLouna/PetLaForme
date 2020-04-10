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
    [Register ("DAuthLoginViewController")]
    partial class DAuthLoginViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnConfirmDAuth { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnResetPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfCodeField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView uivMainView { get; set; }

        [Action ("BtnConfirmDAuth_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnConfirmDAuth_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnConfirmDAuth != null) {
                btnConfirmDAuth.Dispose ();
                btnConfirmDAuth = null;
            }

            if (btnResetPassword != null) {
                btnResetPassword.Dispose ();
                btnResetPassword = null;
            }

            if (tfCodeField != null) {
                tfCodeField.Dispose ();
                tfCodeField = null;
            }

            if (uivMainView != null) {
                uivMainView.Dispose ();
                uivMainView = null;
            }
        }
    }
}