using PetLaFormeWin.Helper;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Object.Pet;
using PLFAPI.Object.Pet.Attribute;
using PLFAPI.Object.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLaFormeWin.Manager
{
    public class PetManager
    {
        int[] userPetsID;
        List<PLFPet> userPets;                          //user pets list
        PLFPet selectedPet;                             //selected pet

        public PetManager()
        {
            //init variables
            userPets = new List<PLFPet>();
            selectedPet = null;
        }

        public void AddPet(PLFPet pet)
        {
            //add pet to list
            userPets.Add(pet);
        }

        public void DeletePet(PLFPet pet)
        {
            //remove pet from list
            userPets.Remove(pet);
        }
        
        public void LoadUserPetList(PLFUser user)
        {
            //download petlist from server
            //userPets = ServerHelper.DownloadPets(user).PetList;
            userPets.Clear();

            ServerPacketDownloadPetsID serverPacketDownloadPetsID =  ServerHelper.DownloadPetsID(user);
            userPetsID = serverPacketDownloadPetsID.IdList;


            foreach (var id in userPetsID)
            {
                PLFPet pet = ServerHelper.DownloadPet(id).Pet;
                if (pet != null)
                    userPets.Add(pet);
            }

            int[] sharePetsId = serverPacketDownloadPetsID.SharedIdList;

            foreach (var id in sharePetsId)
            {
                PLFPet pet = ServerHelper.DownloadPet(id, true).Pet;
                if (pet != null)
                    userPets.Add(pet);
            }
        }

        public List<PetAttribute> DownloadPetAttributs(int petID)
        {
            List<PetAttribute> petAttributes = new List<PetAttribute>();

            int amount = ServerHelper.DownloadAmountOfAttributs(petID).Size;

            for(int i = 0; i < amount; i++)
            {
                PetAttribute petAttribute = ServerHelper.DownloadAttribut(petID, i).PetAttribut;
                if (petAttribute != null)
                    petAttributes.Add(petAttribute);
            }

            return petAttributes;
        }

        public List<PLFPet> UserOwnPets
        {
            get
            {
                //get only own pet
                List<PLFPet> userPetList = new List<PLFPet>();
                foreach (var pet in UserPets)
                    if (!pet.Shared)
                        userPetList.Add(pet);
                return userPetList;
            }
        }

        public List<PLFPet> UserPets { get => userPets; set => userPets = value; }
        public PLFPet SelectedPet { get => selectedPet; set => selectedPet = value; }
    }
}
