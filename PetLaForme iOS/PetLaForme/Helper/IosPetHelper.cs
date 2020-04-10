using System;
using PLFAPI.Object.Pet;
using PLFAPI.Object.Pet.Attribute;
using UIKit;
namespace PetLaForme.Helper
{
    public static class IosPetHelper
    {

        /// <summary>
        /// Gets the type of the image for pet.
        /// </summary>
        /// <returns>The image for pet type.</returns>
        /// <param name="petType">Pet type.</param>
        public static UIImage GetImageForPetType(PetType petType)
        {
            UIImage image;

            try
            {
                //try to load image with pet type 
                image = new UIImage($"Pet/{petType.ToString().ToLower()}.png");
            }
            catch
            {
                image = new UIImage("Pet/other.png");
            }

            return image;
        }

        public static UIImage GetImageForAttributeType(PetAttributeType attributeType)
        {
            UIImage image;

            try
            {
                //try to load image with attribute type
                image = new UIImage($"Attribute/{attributeType.ToString().ToLower()}.png");
            }
            catch
            {
                image = new UIImage("Pet/other.png");
            }

            return image;
        }

    }
}
