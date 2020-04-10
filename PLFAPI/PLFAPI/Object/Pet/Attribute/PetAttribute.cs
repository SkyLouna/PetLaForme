using System;

namespace PLFAPI.Object.Pet.Attribute
{
    [Serializable()]
    public class PetAttribute
    {

        PetAttributeType petAttributeType;                      //attribute type

        String attributeTitle;                                  //attribute title
        String attributeDescription;                            //attribute description

        public PetAttribute(PetAttributeType petAttributeType, String attributeTitle, String attributeDescription)
        {
            this.petAttributeType = petAttributeType;
            this.attributeTitle = attributeTitle;
            this.attributeDescription = attributeDescription;
        }

        public PetAttributeType PetAttributeType { get => petAttributeType; set => petAttributeType = value; }
        public string AttributeTitle { get => attributeTitle; set => attributeTitle = value; }
        public string AttributeDescription { get => attributeDescription; set => attributeDescription = value; }
    }
}
