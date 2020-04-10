using Foundation;
using LViOSLibrary.Helper;
using PetLaForme.Helper;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Object.Pet;
using System;
using System.Collections.Generic;
using UIKit;

namespace PetLaForme
{
    public partial class PetShareViewController : UIViewController
    {

        PLFPet selectedPet;                             //selected pet


        /// <summary>
        /// Initializes a new instance of the <see cref="T:PetLaForme.PetShareViewController"/> class.
        /// </summary>
        /// <param name="handle">Handle.</param>
        public PetShareViewController (IntPtr handle) : base (handle)
        {
        }

        /// <summary>
        /// Views the did load.
        /// </summary>
        public override void ViewDidLoad()
        {
            //add event handlers
            tfShareUserName.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                return true;
            };
            base.ViewDidLoad();
        }

        /// <summary>
        /// Views the will appear.
        /// </summary>
        /// <param name="animated">If set to <c>true</c> animated.</param>
        public override void ViewWillAppear(bool animated)
        {
            //init picker
            InitPetPicker();

            //populate fields
            selectedPet = Application.PetManager.SelectedPet;
            ivPetIcon.Image = IosPetHelper.GetImageForPetType(Application.PetManager.SelectedPet.PetType);
        }

        partial void BtnSharePet_TouchUpInside(UIButton sender)
        {
            //if try to share to himself
            if (tfShareUserName.Text.ToLower() == Application.ActualUser.UserNickName.ToLower())
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, MSGBank.ERROR_SHARE_YOURSELF);
                return;
            }

            //send share pet packet to server
            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.SharePet(
                Application.ActualUser, selectedPet, tfShareUserName.Text, swAllowModifications.On ? 1 : 0);

            //if success share
            if (serverPacketConfirmation.ActionSuccess)
            {
                this.NavigationController.PopViewController(true);
                MessageBox.ShowOK("Partage", $"Votre familier a bien été partagé avec {tfShareUserName.Text}", this.NavigationController.ParentViewController);
                return;
            }

            //chose right error message
            String errorMessage = string.Empty;
            switch (serverPacketConfirmation.NetworkError)
            {
                case NetworkError.SERVER_UNAVAILABLE:
                    errorMessage = MSGBank.ERROR_NO_SERVER;
                    break;
                case NetworkError.SQL_USER_UNKNOWN:
                    errorMessage = MSGBank.ERROR_UNKNOWN_USER;
                    break;
                default:
                    errorMessage = $"Impossible de partager ce familier";
                    break;
            }
            //show error message
            BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, errorMessage);
        }

        public void InitPetPicker()
        {
            //create new picker model
            var petPickerModel = new PetPickerModel(Application.PetManager.UserOwnPets);

            //set picker view model
            pvUserPetView.Model = petPickerModel;

            //add event handler
            petPickerModel.petChangeEvent += (sender, e) =>
            {
                selectedPet = petPickerModel.selectedPet;

                ivPetIcon.Image = IosPetHelper.GetImageForPetType(selectedPet.PetType);
            };

        }


        //language picker model
        public class PetPickerModel : UIPickerViewModel
        {
            List<String> pets;                              //pet name list
            public EventHandler petChangeEvent;             //pet change event
            public PLFPet selectedPet;                      //selected pet

            /// <summary>
            /// Initializes a new instance of the <see cref="T:PetLaForme.PetShareViewController.PetPickerModel"/> class.
            /// </summary>
            /// <param name="pets">Pets.</param>
            public PetPickerModel(List<PLFPet> pets)
            {
                this.pets = new List<String>();

                //foreach pet add his name to list
                foreach (var pet in pets)
                    this.pets.Add(pet.PetName);
            }

            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
                return pets.Count;
            }

            public override nint GetComponentCount(UIPickerView pickerView)
            {
                return 1;
            }

            public override string GetTitle(UIPickerView pickerView, nint row, nint component)
            {
                return pets[(int)row];
            }

            public override void Selected(UIPickerView pickerView, nint row, nint component)
            {
                //set selected pet
                selectedPet = Application.PetManager.UserOwnPets[(int)row];

                //trigger event
                petChangeEvent?.Invoke(null, null);
            }

        }
    }
}