using System;
using UIKit;

namespace PetLaForme.Helper
{
    public class MessageBox
    {
        
        /// <summary>
        /// Shows the ok.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="content">Content.</param>
        /// <param name="action">Action.</param>
        /// <param name="viewController">View controller.</param>
        public static void ShowOK(String title, String content,  UIViewController viewController, Action<UIAlertAction> action = null)
        {
            //create new instance of an alert view controller
            UIAlertController showOKBox = UIAlertController.Create(title, content, UIAlertControllerStyle.Alert);
            showOKBox.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, action == null ? delegate { } : action));

            //show alert
            viewController.PresentViewController(showOKBox, true, null);
        }

        /// <summary>
        /// Shows the yes no alert.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="content">Content.</param>
        /// <param name="yesAction">Yes action.</param>
        /// <param name="noAction">No action.</param>
        /// <param name="viewController">View controller.</param>
        public static void ShowYesNo(String title, String content, Action<UIAlertAction> yesAction, Action<UIAlertAction> noAction, UIViewController viewController)
        {
            //create new instance of an alert view controller
            UIAlertController showOKBox = UIAlertController.Create(title, content, UIAlertControllerStyle.Alert);
            showOKBox.AddAction(UIAlertAction.Create("Oui", UIAlertActionStyle.Default, yesAction));
            showOKBox.AddAction(UIAlertAction.Create("Non", UIAlertActionStyle.Default, noAction));

            //show alert
            viewController.PresentViewController(showOKBox, true, null);
        }
    }
}
