using System;
using LViOSLibrary.Object.MessageBar;
using UIKit;

namespace LViOSLibrary.Helper
{
    public class BarHelper
    {

        static ToastMessageBar actualMessageBar;

        public static ToastMessageBar DisplaySuccessBar(UIView view, String title = "", String description = "", int seconds = 5
                                                        , Action actionOnDisolve = null, Action actionOnTap = null, Action actionOnSwipe = null)
        {
            actualMessageBar?.Remove();

            int barWidth = (int) view.Frame.Width - 20;

            int yLoc = OSHelper.deviceHasNotch() ? 100 : 70;

            ToastMessageBar toastMessageBar = new ToastMessageBar(10, yLoc, seconds, title, description, new UIImage("Icons/mb-success.png"), barWidth);
            toastMessageBar.BackgroundColor = UIColor.Green;

            toastMessageBar.OnTap = actionOnTap;
            toastMessageBar.OnSwipe = actionOnSwipe;
            toastMessageBar.OnDisolve = actionOnDisolve;

            view.Add(toastMessageBar);
            view.BringSubviewToFront(toastMessageBar);

            actualMessageBar = toastMessageBar;

            return toastMessageBar;
        }

        public static ToastMessageBar DisplayErrorBar(UIView view, String title = "", String description = "", int seconds = 5
                                                        , Action actionOnDisolve = null, Action actionOnTap = null, Action actionOnSwipe = null)
        {
            actualMessageBar?.Remove();

            int barWidth = (int)view.Frame.Width - 20;

            int yLoc = OSHelper.deviceHasNotch() ? 100 : 70;

            ToastMessageBar toastMessageBar = new ToastMessageBar(10, yLoc, seconds, title, description, new UIImage("Icons/mb-error.png"), barWidth);
            toastMessageBar.BackgroundColor = UIColor.Red;

            toastMessageBar.OnTap = actionOnTap;
            toastMessageBar.OnSwipe = actionOnSwipe;
            toastMessageBar.OnDisolve = actionOnDisolve;

            view.Add(toastMessageBar);
            view.BringSubviewToFront(toastMessageBar);

            actualMessageBar = toastMessageBar;

            return toastMessageBar;
        }

        public static ToastMessageBar DisplayInfoBar(UIView view, String title = "", String description = "", int seconds = 5
                                                        , Action actionOnDisolve = null, Action actionOnTap = null, Action actionOnSwipe = null)
        {
            actualMessageBar?.Remove();

            int barWidth = (int)view.Frame.Width - 20;

            int yLoc = OSHelper.deviceHasNotch() ? 100 : 70;

            ToastMessageBar toastMessageBar = new ToastMessageBar(10, yLoc, seconds, title, description, new UIImage("Icons/mb-info.png"), barWidth);
            toastMessageBar.BackgroundColor = UIColor.Blue;

            toastMessageBar.OnTap = actionOnTap;
            toastMessageBar.OnSwipe = actionOnSwipe;
            toastMessageBar.OnDisolve = actionOnDisolve;

            view.Add(toastMessageBar);
            view.BringSubviewToFront(toastMessageBar);

            actualMessageBar = toastMessageBar;

            return toastMessageBar;
        }
    }
}
