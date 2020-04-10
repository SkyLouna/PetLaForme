using System;
using PLFAPI.Object.Pet;
using PLFAPI.Object.Pet.Attribute;
using UIKit;

namespace PetLaForme.Object.Card
{
    public class AttributCard : CustomCard
    {
        PetAttribute petAttribut;               //pet attribut
        int attributID;                         //pet attribut id


        /// <summary>
        /// Initializes a new instance of the <see cref="T:PetLaForme.Object.Card.AttributCard"/> class.
        /// </summary>
        /// <param name="petAttribut">Pet attribut.</param>
        /// <param name="attributID">Attribut identifier.</param>
        public AttributCard(PetAttribute petAttribut, int attributID) : base(petAttribut.AttributeTitle, $"Attribute/{petAttribut.PetAttributeType.ToString().ToLower()}.png")
        {
            this.petAttribut = petAttribut;
            this.attributID = attributID;
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
            //set selected pet
            Application.PetManager.SelectedPetAttribute = petAttribut;
            Application.PetManager.SelectedPetAttributeID = attributID;

            //perform show attribut segue
            this.UivcMainController.PerformSegue("ShowAttributSegue", UivcMainController);
        }
    }
}
