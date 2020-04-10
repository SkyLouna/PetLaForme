using Foundation;
using LViOSLibrary.Helper;
using PetLaForme.Helper;
using PetLaForme.Object.Card;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Object.Pet;
using PLFAPI.Object.Pet.Attribute;
using System;
using System.Collections.Generic;
using UIKit;

namespace PetLaForme
{
    public partial class UserPetViewController : UIViewController
    {

        PLFPet actualPet;                                       //selected pet

        List<PetAttribute> petAttributes;                       //pet attributes
        Dictionary<PetAttribute, int> petAttributesID;          //pet attributes id

        public UserPetViewController (IntPtr handle) : base (handle)
        {
        }

        /// <summary>
        /// Views the will appear.
        /// </summary>
        /// <param name="animated">If set to <c>true</c> animated.</param>
        public override void ViewWillAppear(bool animated)
        {
            //if no selected pet
            if (Application.PetManager.SelectedPet == null)
                return;

            //get actual pet
            actualPet = Application.PetManager.SelectedPet;

            //update fields
            UpdatePetView();
            UpdatePetAttributes();
            UpdateScrollView();


        }

        /// <summary>
        /// Buttons the delete pet touch up inside.
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void BtnDeletePet_TouchUpInside(UIButton sender)
        {
            //ask yes no  delete
            MessageBox.ShowYesNo("Suppression de familier", "Etes vous sûr de vouloir supprimer ce familier ?", delegate
            {
                //yes
                //send delete pet to server
                ServerPacketConfirmation serverPacketConfirmation = ServerHelper.DeletePet(Application.ActualUser, actualPet);

                //if pet successfuly delete
                if (serverPacketConfirmation.ActionSuccess)
                {
                    //delete from list
                    Application.PetManager.DeletePet(actualPet);

                    //pop view controller
                    this.NavigationController.PopViewController(true);
                    return;
                }

                //switch for the good error msg
                String errorMessage = string.Empty;
                switch (serverPacketConfirmation.NetworkError)
                {
                    case NetworkError.SERVER_UNAVAILABLE:
                        errorMessage = MSGBank.ERROR_NO_SERVER;
                        break;
                    default:
                        errorMessage = $"Impossible de supprimer ce familier";
                        break;
                }
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, errorMessage);
                //Show error message

            }, delegate
            {
                //no
                //nothing

            }, this);
        }

        partial void BtnSharePet_TouchUpInside(UIButton sender)
        {
        }

        /// <summary>
        /// Buttons the add attribut touch up inside.
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void BtnAddAttribut_TouchUpInside(UIButton sender)
        {
            //set selected attribute with a fake attribute with -1 id wich mean new attribute
            Application.PetManager.SelectedPetAttribute = new PetAttribute(PetAttributeType.OTHER, "Titre","Description");
            Application.PetManager.SelectedPetAttributeID = -1;
        }

        /// <summary>
        /// Updates the pet view.
        /// </summary>
        public void UpdatePetView()
        {
            //populate fields
            lblPetName.Text = actualPet.PetName;
            lblPetType.Text = actualPet.PetType.ToString().ToLower();
            ivPetIcon.Image = IosPetHelper.GetImageForPetType(actualPet.PetType);

            //change fields if share pet or not

            if (actualPet.Shared)
                ivIsSharedPet.Alpha = 100;
            else ivIsSharedPet.Alpha = 0;

            btnSharePet.Enabled = actualPet.SharePower == 0 ? false : true;
            btnDeletePet.Enabled = actualPet.SharePower == 0 ? false : true;
            btnAddAttribut.Enabled = actualPet.SharePower == 0 ? false : true;

            if(actualPet.SharePower > 0)
            {
                btnSharePet.Enabled = false;
                btnDeletePet.Enabled = false;
                btnAddAttribut.Enabled = true;
            }
        }

        /// <summary>
        /// Updates the pet attributes.
        /// </summary>
        public void UpdatePetAttributes()
        {
            //download pets attributs
            petAttributes = Application.PetManager.DownloadPetAttributs(actualPet.PetID);
            petAttributesID = new Dictionary<PetAttribute, int>();
            for (int i = 0; i < petAttributes.Count; i++)
                petAttributesID.Add(petAttributes[i], i);
        }

        public void UpdateScrollView()
        {
            //display pet cards
            int yAxisLocation = 10;

            //foreach attributs
            foreach (var att in petAttributes)
            {
                AttributCard attributCard = new AttributCard(att, petAttributesID[att]);
                attributCard.Show(svAttributListView, this, new System.Drawing.Point(0, yAxisLocation));
                yAxisLocation += 310;
            }

            //change scroll view scroll infos
            svAttributListView.ScrollEnabled = true;

            svAttributListView.ShowsVerticalScrollIndicator = false;
            svAttributListView.ShowsHorizontalScrollIndicator = false;

            //set the new content size
            svAttributListView.ContentSize = new CoreGraphics.CGSize(svAttributListView.Bounds.Width, yAxisLocation + 10);
        }
    }
}