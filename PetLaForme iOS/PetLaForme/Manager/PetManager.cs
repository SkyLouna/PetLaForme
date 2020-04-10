using System;
using System.Collections.Generic;
using PetLaForme.Helper;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Object.Pet;
using PLFAPI.Object.Pet.Attribute;
using PLFAPI.Object.User;

namespace PetLaForme.Manager
{
    public class PetManager
    {
        int[] userPetsID;                               //user pets list id
        List<PLFPet> userPets;                          //user pets list
        PLFPet selectedPet;                             //selected pet

        PetAttribute selectedPetAttribute;              //selected attribute 
        int selectedPetAttributeID;                     //selected attribute id

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PetLaForme.Manager.PetManager"/> class.
        /// </summary>
        public PetManager()
        {
            //init variables
            userPets = new List<PLFPet>();
            selectedPet = null;
        }

        /// <summary>
        /// Adds the pet.
        /// </summary>
        /// <param name="pet">Pet.</param>
        public void AddPet(PLFPet pet)
        {
            //add pet to list
            userPets.Add(pet);
        }

        /// <summary>
        /// Deletes the pet.
        /// </summary>
        /// <param name="pet">Pet.</param>
        public void DeletePet(PLFPet pet)
        {
            //remove pet from list
            userPets.Remove(pet);
        }

        /// <summary>
        /// Loads the user pet list.
        /// </summary>
        /// <param name="user">User.</param>
        public void LoadUserPetList(PLFUser user)
        {
            //clear actual petlist
            userPets.Clear();

            //send download pets id packet
            ServerPacketDownloadPetsID serverPacketDownloadPetsID = ServerHelper.DownloadPetsID(user);
            userPetsID = serverPacketDownloadPetsID.IdList;

            //foreach user own pets id
            foreach (var id in userPetsID)
            {
                //download pet infos from server
                PLFPet pet = ServerHelper.DownloadPet(id).Pet;

                //if pet isn't null
                if (pet != null)
                    userPets.Add(pet);
            }

            //get shared pets id
            int[] sharePetsId = serverPacketDownloadPetsID.SharedIdList;

            //foreach user share pets id
            foreach (var id in sharePetsId)
            {
                //download shared pet infos from server
                PLFPet pet = ServerHelper.DownloadPet(id, true).Pet;

                //if pet isn't null
                if (pet != null)
                    userPets.Add(pet);
            }


        }

        /// <summary>
        /// Downloads the pet attributs.
        /// </summary>
        /// <returns>The pet attributs.</returns>
        /// <param name="petID">Pet identifier.</param>
        public List<PetAttribute> DownloadPetAttributs(int petID)
        {
            List<PetAttribute> petAttributes = new List<PetAttribute>();

            //get amount of pet attributes
            int amount = ServerHelper.DownloadAmountOfAttributs(petID).Size;

            //foreach attribute
            for (int i = 0; i < amount; i++)
            {
                //download attribute
                PetAttribute petAttribute = ServerHelper.DownloadAttribut(petID, i).PetAttribut;

                //if attribute isn't null
                if (petAttribute != null)
                    petAttributes.Add(petAttribute);
            }

            return petAttributes;
        }

        /// <summary>
        /// Gets the user own pets.
        /// </summary>
        /// <value>The user own pets.</value>
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
        public PetAttribute SelectedPetAttribute { get => selectedPetAttribute; set => selectedPetAttribute = value; }
        public int SelectedPetAttributeID { get => selectedPetAttributeID; set => selectedPetAttributeID = value; }
    }
}
