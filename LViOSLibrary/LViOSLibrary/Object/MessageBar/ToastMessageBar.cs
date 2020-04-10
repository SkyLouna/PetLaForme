using System;
using System.Collections.Generic;
using System.Threading;
using CoreGraphics;
using Foundation;
using UIKit;
namespace LViOSLibrary.Object.MessageBar
{
    public class ToastMessageBar : UIView
    {

        UILabel lblTitle;
        UILabel lblDescription;
        UIImageView ivIcon;

        Timer disolveTimer;

        Action onTap;
        Action onSwipe;
        Action onDisolve;

        public ToastMessageBar(int x, int y, int seconds, String title, String desc, UIImage icon, int width = 384) : base(new CGRect(x, y, width, 80))
        {
            this.ClipsToBounds = true;
            this.Layer.CornerRadius = 25;
            this.Alpha = (nfloat)0.9;
            this.BackgroundColor = new UIColor(0, 0, 0, 1);
            this.UserInteractionEnabled = true;

            lblTitle = new UILabel(new CGRect(95, 8, 250, 20));
            lblTitle.Text = title;
            lblTitle.Lines = 1;
            lblTitle.Font = UIFont.PreferredTitle1.WithSize(24);
            lblTitle.TextColor = UIColor.White;
            lblTitle.UserInteractionEnabled = true;

            lblDescription = new UILabel(new CGRect(95, 32, 250, 40));
            lblDescription.Text = desc;
            lblDescription.Lines = 2;
            lblDescription.Font = UIFont.PreferredBody.WithSize(14);
            lblDescription.TextColor = UIColor.White;
            lblDescription.UserInteractionEnabled = true;

            ivIcon = new UIImageView(new CGRect(20, 8, 64, 64));
            ivIcon.Image = icon;
            ivIcon.UserInteractionEnabled = true;

            disolveTimer = new Timer((object state) => { disolveTimer.Dispose(); InvokeOnMainThread(() => this.RemoveFromSuperview());  onDisolve?.Invoke(); }, null, seconds * 1000, 0);

            #region GestureRecognizers

            this.AddGestureRecognizer(new UITapGestureRecognizer(OnBarTap));
            lblTitle.AddGestureRecognizer(new UITapGestureRecognizer(OnBarTap));
            ivIcon.AddGestureRecognizer(new UITapGestureRecognizer(OnBarTap));
            lblDescription.AddGestureRecognizer(new UITapGestureRecognizer(OnBarTap));

            this.AddGestureRecognizer(new UISwipeGestureRecognizer(OnBarSwipe));
            lblTitle.AddGestureRecognizer(new UISwipeGestureRecognizer(OnBarSwipe));
            lblDescription.AddGestureRecognizer(new UISwipeGestureRecognizer(OnBarSwipe));
            ivIcon.AddGestureRecognizer(new UISwipeGestureRecognizer(OnBarSwipe));

            #endregion

            this.Add(lblTitle);
            this.Add(lblDescription);
            this.Add(ivIcon);
        }

        public void Remove()
        {
            disolveTimer.Dispose();
            this.RemoveFromSuperview();
        }

        public void PopBar()
        {
            disolveTimer.Dispose();
            this.RemoveFromSuperview();
        }

        private void OnBarTap(UITapGestureRecognizer tapGestureRecognizer)
        {
            InvokeOnMainThread(() => { onTap?.Invoke(); PopBar(); });
        }

        private void OnBarSwipe(UISwipeGestureRecognizer swipeGestureRecognizer)
        {
            InvokeOnMainThread(() => { onSwipe?.Invoke(); PopBar(); });
        }

        public UILabel LblTitle { get => lblTitle; set => lblTitle = value; }
        public UILabel LblDescription { get => lblDescription; set => lblDescription = value; }
        public UIImageView IvIcon { get => ivIcon; set => ivIcon = value; }
        public Action OnTap { get => onTap; set => onTap = value; }
        public Action OnSwipe { get => onSwipe; set => onSwipe = value; }
        public Action OnDisolve { get => onDisolve; set => onDisolve = value; }
    }
}
