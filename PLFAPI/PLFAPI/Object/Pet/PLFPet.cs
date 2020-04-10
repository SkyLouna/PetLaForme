using System;
using System.Collections.Generic;
using PLFAPI.Object.Pet.Attribute;

namespace PLFAPI.Object.Pet
{
    [Serializable()]
    public class PLFPet
    {
        int petID;
        PetType petType;
        String petName;
        int sharePower;

       
        //new instance of profile with ID (Server)
        public PLFPet(int petID, PetType petType, String petName, int sharePower =-1)
        {
            this.petID = petID;
            this.petType = petType;
            this.petName = petName;
            this.sharePower = sharePower;
        }

        //New instance of profile without id (Client)
        public PLFPet(PetType petType)
        {
            this.petID = -1;
            this.petType = petType;
            this.petName = petType.ToString();
            this.sharePower = -1;
        }

        public int PetID { get => petID; set => petID = value; }
        public PetType PetType { get => petType; set => petType = value; }
        public string PetName { get => petName; set => petName = value; }
        public bool Shared { get => sharePower != -1; }
        public int SharePower { get => sharePower; set => sharePower = value; }
    }
}
