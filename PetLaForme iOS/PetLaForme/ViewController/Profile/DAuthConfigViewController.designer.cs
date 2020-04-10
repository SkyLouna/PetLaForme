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
    [Register ("DAuthConfigViewController")]
    partial class DAuthConfigViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnActivateDAuth { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDesactivateDAuth { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnShowWebQR { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tfCodeField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView uivMainView { get; set; }

        [Action ("BtnActivateDAuth_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnActivateDAuth_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnDesactivateDAuth_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnDesactivateDAuth_TouchUpInside (UIKit.UIButton sender);

        [Action ("BtnShowWebQR_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnShowWebQR_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnActivateDAuth != null) {
                btnActivateDAuth.Dispose ();
                btnActivateDAuth = null;
            }

            if (btnDesactivateDAuth != null) {
                btnDesactivateDAuth.Dispose ();
                btnDesactivateDAuth = null;
            }

            if (btnShowWebQR != null) {
                btnShowWebQR.Dispose ();
                btnShowWebQR = null;
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