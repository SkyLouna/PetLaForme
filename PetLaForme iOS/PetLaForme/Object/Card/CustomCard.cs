using System;
using UIKit;
using Foundation;
using System.Drawing;

namespace PetLaForme.Object.Card
{
    public abstract class CustomCard
    {

        //const int FRAMEWIDTH = 300;
        const int FRAMEHEIGHT = 300;

        Point location;                             //Card locationm

        nfloat scrollViewWidth;                     //card scroll view width

        UIView vwStoryCardView;                     //use as group view
        UIImageView ivBackgroundImage;              //background image
        UIImageView ivBadgeImage;                   //badge image
        UILabel lblTitle;                           //title


        UIViewController uivcMainController;        //main container controller           


        /// <summary>
        /// Initializes a new instance of the <see cref="T:PetLaForme.Object.Card.CustomCard"/> class.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="imagePath">Image path.</param>
        /// <param name="badgePath">Badge path.</param>
        public CustomCard(String title, String imagePath, String badgePath = "null")
        {
            //new uiview
            VwStoryCardView = new UIView();
            ivBadgeImage = new UIImageView();
            ivBackgroundImage = new UIImageView();

            //try to load images
            try
            {
                ivBackgroundImage.Image = new UIImage(imagePath);

                if(badgePath != "null")
                    ivBadgeImage.Image = new UIImage(badgePath);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error while loading image : " + e.StackTrace);
            }

            //create text lbl
            lblTitle = new UILabel()
            {
                Text = title,


                Font = UIFont.FromName("Helvetica-Bold", 32),
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0,
                TextColor = UIColor.Black
            };


            //Set background color 
            vwStoryCardView.BackgroundColor = UIColor.FromRGB(245, 245, 245);

            //add shadow (doesn't work :( )
            vwStoryCardView.Layer.ShadowColor = UIColor.Black.CGColor;
            vwStoryCardView.Layer.ShadowOpacity = 1;
            vwStoryCardView.Layer.ShadowRadius = 10;
            vwStoryCardView.Layer.ShadowOffset = new CoreGraphics.CGSize(0, 0);
            vwStoryCardView.Layer.BorderWidth = 2;
            vwStoryCardView.Layer.BorderColor = new CoreGraphics.CGColor((nfloat)0.7, (nfloat)0.7, (nfloat)0.7);

            vwStoryCardView.Add(ivBackgroundImage);
            vwStoryCardView.Add(ivBadgeImage);
            vwStoryCardView.Add(lblTitle);

            //make corners rounded
            vwStoryCardView.Layer.MasksToBounds = true;
            vwStoryCardView.Layer.CornerRadius = 20;

            //enable user interact
            vwStoryCardView.UserInteractionEnabled = true;


        }

        /// <summary>
        /// Show the specified uivMainContainerView, uivcMainController and location.
        /// </summary>
        /// <param name="uivMainContainerView">Uiv main container view.</param>
        /// <param name="uivcMainController">Uivc main controller.</param>
        /// <param name="location">Location.</param>
        public void Show(UIView uivMainContainerView, UIViewController uivcMainController, Point location)
        {
            //define scroll view width
            scrollViewWidth = uivMainContainerView.Frame.Width;

            //change location
            Location = location;

            //add group view to main view
            uivMainContainerView.AddSubview(vwStoryCardView);

            //assign controller and container
            this.uivcMainController = uivcMainController;


            //add gestures recognizers
            UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(Tap);
            UIPinchGestureRecognizer pinchGesture = new UIPinchGestureRecognizer(Pinch);
            UISwipeGestureRecognizer swipeGesture = new UISwipeGestureRecognizer(Swipe);
            UILongPressGestureRecognizer longPressGesture = new UILongPressGestureRecognizer(LongPress);

            vwStoryCardView.AddGestureRecognizer(tapGesture);
            vwStoryCardView.AddGestureRecognizer(pinchGesture);
            vwStoryCardView.AddGestureRecognizer(swipeGesture);
            vwStoryCardView.AddGestureRecognizer(longPressGesture);
        }

        /// <summary>
        /// Releases all resource used by the <see cref="T:PetLaForme.Object.Card.CustomCard"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the
        /// <see cref="T:PetLaForme.Object.Card.CustomCard"/>. The <see cref="Dispose"/> method leaves the
        /// <see cref="T:PetLaForme.Object.Card.CustomCard"/> in an unusable state. After calling <see cref="Dispose"/>,
        /// you must release all references to the <see cref="T:PetLaForme.Object.Card.CustomCard"/> so the garbage
        /// collector can reclaim the memory that the <see cref="T:PetLaForme.Object.Card.CustomCard"/> was occupying.</remarks>
        public void Dispose()
        {
            vwStoryCardView.Dispose();
            ivBackgroundImage.Dispose();
            ivBadgeImage.Dispose();
            lblTitle.Dispose();
        }

        //---------------------------------------------------------------------------------
        //
        //                  Abstracts methods
        //
        //---------------------------------------------------------------------------------

        public abstract void Tap(UITapGestureRecognizer tap);

        public abstract void Pinch(UIPinchGestureRecognizer pinch);

        public abstract void Swipe(UISwipeGestureRecognizer swipe);

        public abstract void LongPress(UILongPressGestureRecognizer longPress);



        //---------------------------------------------------------------------------------
        //
        //                  Getters and setters
        //
        //---------------------------------------------------------------------------------

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public Point Location
        {
            get => location;
            set
            {
                location = value;
                vwStoryCardView.Frame = new CoreGraphics.CGRect(location.X + 25, location.Y, scrollViewWidth - 50, FRAMEHEIGHT);
                ivBackgroundImage.Frame = new CoreGraphics.CGRect(
                    (scrollViewWidth - 50 - FRAMEHEIGHT + 100) / 2, 100, FRAMEHEIGHT - 100, FRAMEHEIGHT - 100);
                ivBadgeImage.Frame = new CoreGraphics.CGRect(scrollViewWidth - 100, 30, 32, 32);
                lblTitle.Frame = new CoreGraphics.CGRect(10, 0, scrollViewWidth - 30, 100);
            }
        }

        public UIView VwStoryCardView { get => vwStoryCardView; set => vwStoryCardView = value; }
        public UIViewController UivcMainController { get => uivcMainController; set => uivcMainController = value; }
        public UIImageView IvBackgroundImage { get => ivBackgroundImage; set => ivBackgroundImage = value; }
    }
}
