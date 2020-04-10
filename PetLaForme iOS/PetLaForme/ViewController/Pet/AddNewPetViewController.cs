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
    public partial class AddNewPetViewController : UIViewController
    {

        PetType selectedType = PetType.OTHER;                           //selected pet type


        /// <summary>
        /// Initializes a new instance of the <see cref="T:PetLaForme.AddNewPetViewController"/> class.
        /// </summary>
        /// <param name="handle">Handle.</param>
        public AddNewPetViewController (IntPtr handle) : base (handle)
        {
        }


        /// <summary>
        /// Views the did load.
        /// </summary>
        public override void ViewDidLoad()
        {
            //init picker
            InitPetTypePicke();

            //add event handlers
            tfPetNameField.ShouldReturn += (textField) =>
            {
                ((UITextField)textField).ResignFirstResponder();
                return true;
            };
        }

        /// <summary>
        /// Buttons the save pet touch up inside.
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void BtnSavePet_TouchUpInside(UIButton sender)
        {
            //create new pet with selected type
            PLFPet pet = new PLFPet(selectedType);
            pet.PetName = tfPetNameField.Text;

            //send pet register to server
            ServerPacketAddPet serverPacketAddPet = ServerHelper.AddPet(Application.ActualUser, pet);

            //if register success
            if(serverPacketAddPet.RegisterSuccess)
            {
                //set pet id
                pet.PetID = serverPacketAddPet.PetID;

                //add pet to user pet list
                Application.PetManager.AddPet(pet);

                //reset fields
                selectedType = PetType.OTHER;
                tfPetNameField.Text = "";

                //pop actual controller
                this.NavigationController.PopViewController(true);
                return;
            }

            //get the good error message
            String errorMessage = string.Empty;
            switch (serverPacketAddPet.NetworkError)
            {
                case NetworkError.SERVER_UNAVAILABLE:
                    errorMessage = MSGBank.ERROR_NO_SERVER;
                    break;
                default:
                    errorMessage = $"Impossible d'ajouter ce familier";
                    break;
            }
            BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, errorMessage);
        }

        public void InitPetTypePicke()
        {
            //create new picker model
            var petTypePicketModel = new PetTypePickerModel(Enum.GetValues(typeof(PetType)));

            //set picker view model
            pvPetTypePickerView.Model = petTypePicketModel;


            //add event handler
            petTypePicketModel.typeChangeEvent += (sender, e) =>
            {
                selectedType = petTypePicketModel.selectedType;
                ivPetIcon.Image = IosPetHelper.GetImageForPetType(selectedType);
            };

        }


        //language picker model
        public class PetTypePickerModel : UIPickerViewModel
        {
            List<String> petTypes;                              //pet type name list
            public EventHandler typeChangeEvent;                //type change event
            public PetType selectedType;                        //selected type

            /// <summary>
            /// Initializes a new instance of the <see cref="T:PetLaForme.AddNewPetViewController.PetTypePickerModel"/> class.
            /// </summary>
            /// <param name="petTypes">Pet types.</param>
            public PetTypePickerModel(Array petTypes)
            {
                this.petTypes = new List<string>();

                //foreach type add to string list
                foreach (var type in petTypes)
                    this.petTypes.Add(type.ToString().ToLower());
            }

            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
                return petTypes.Count;
            }

            public override nint GetComponentCount(UIPickerView pickerView)
            {
                return 1;
            }

            public override string GetTitle(UIPickerView pickerView, nint row, nint component)
            {
                return petTypes[(int)row];
            }

            public override void Selected(UIPickerView pickerView, nint row, nint component)
            {
                //Set selected type
                selectedType = (PetType)((int)row);

                //trigger event
                typeChangeEvent?.Invoke(null, null);
            }

        }
    }
}