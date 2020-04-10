using System;
using PLFAPI.Object.Pet;
using UIKit;

namespace PetLaForme.Object.Card
{
    public class PetCard : CustomCard
    {
        PLFPet pet;             //pet

        public PetCard(PLFPet pet) : base(pet.PetName, $"Pet/{pet.PetType.ToString().ToLower()}.png", pet.Shared ? "Icon/share.png" : "null")
        {
            this.pet = pet;
        }

        public override void LongPress(UILongPressGestureRecognizer longPress)
        {
        }

        public override void Pinch(UIPinchGestureRecognizer pinch)
        {
        }

        public override void Swipe(UISwipeGestureRecognizer swipe)
        {
        }

        public override void Tap(UITapGestureRecognizer tap)
        {
            //Set selected pet
            Application.PetManager.SelectedPet = pet;

            //perform segue
            UivcMainController.PerformSegue("ShowPetSegue", UivcMainController);
        }
    }
}
