using Foundation;
using PetLaForme.Object.Card;
using PLFAPI.Object.Pet;
using System;
using System.Collections.Generic;
using UIKit;

namespace PetLaForme
{
    public partial class PetViewController : UIViewController
    {

        List<PetCard> petCards = new List<PetCard>();

        public PetViewController (IntPtr handle) : base (handle)
        {
        }


        public override void ViewWillAppear(bool animated)
        {
            //update view
            UpdateView();
        }


        /// <summary>
        /// Updates the view.
        /// </summary>
        public void UpdateView()
        {
            //get actual scroll frame and remove from superview
            CoreGraphics.CGRect scrollViewSize = svPetListView.Frame;
            svPetListView.RemoveFromSuperview();

            //create new scroll view with old scroll view size
            svPetListView = new UIScrollView(scrollViewSize);
            uivMainView.Add(svPetListView);

            //get user pets
            List<PLFPet> userPetList = Application.PetManager.UserPets;

            //display pet cards
            int yAxisLocation = 10;

            //foreach card, dispose
            foreach (var card in petCards)
                card.Dispose();

            //create new list of card
            petCards = new List<PetCard>();

            //Foreach user pet
            foreach (var pet in userPetList)
            {
                //create new card
                PetCard petCard = new PetCard(pet);
                petCard.Show(svPetListView, this, new System.Drawing.Point(0, yAxisLocation));

                petCards.Add(petCard);

                yAxisLocation += 310;
            }

            svPetListView.ScrollEnabled = true;

            //set the new content size
            svPetListView.ContentSize = new CoreGraphics.CGSize(svPetListView.Bounds.Width, yAxisLocation + 20);
        }
    }
}