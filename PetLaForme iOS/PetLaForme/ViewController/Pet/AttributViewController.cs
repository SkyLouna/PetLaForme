using Foundation;
using LViOSLibrary.Helper;
using PetLaForme.Helper;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Object.Pet.Attribute;
using System;
using System.Collections.Generic;
using UIKit;

namespace PetLaForme
{
    public partial class AttributViewController : UIViewController
    {

        PetAttribute petAttribute;                  //pet attribute
        int petAttributeID;                         //pet attribute ID

        PetAttributeType selectedType;              //selected attribute type

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PetLaForme.AttributViewController"/> class.
        /// </summary>
        /// <param name="handle">Handle.</param>
        public AttributViewController (IntPtr handle) : base (handle)
        {
        }

        /// <summary>
        /// Views the did load.
        /// </summary>
        public override void ViewDidLoad()
        {
            //init attribut picker
            InitAttributTypePicker();
            tvAttributDescription.ShouldEndEditing += (textView) =>
            {
                ((UITextView)textView).ResignFirstResponder();
                return true;
            };
            base.ViewDidLoad();
        }

        public override void ViewWillAppear(bool animated)
        {
            if (Application.PetManager.SelectedPetAttribute == null)
                return;

            //get selected attribute infos
            petAttribute = Application.PetManager.SelectedPetAttribute;
            petAttributeID = Application.PetManager.SelectedPetAttributeID;
            selectedType = petAttribute.PetAttributeType;
            pvAttributTypePicker.Select((int)selectedType, 0, true);

            //if can modify 
            if (Application.PetManager.SelectedPet.SharePower != 0)
            {
                btnSaveChanges.Enabled = true;
                btnDeleteAttribut.Enabled = true;
            }
            else
            {
                btnSaveChanges.Enabled = false;
                btnDeleteAttribut.Enabled = false;  
            }

            //update view
            UpdateAttributeView();
        }

        partial void BtnDeleteAttribut_TouchUpInside(UIButton sender)
        {
            //if is a new attribute
            if(petAttributeID == -1)
            {
                this.NavigationController.PopViewController(true);
                return;
            }

            //remove attribute
            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.DeleteAttribut(Application.PetManager.SelectedPet.PetID, petAttributeID);

            if (serverPacketConfirmation.ActionSuccess)
            {
                this.NavigationController.PopViewController(true);
                return;
            }

            //chose right error message
            String errorMessage = string.Empty;
            switch (serverPacketConfirmation.NetworkError)
            {
                case NetworkError.SERVER_UNAVAILABLE:
                    errorMessage = MSGBank.ERROR_NO_SERVER;
                    break;
                default:
                    errorMessage = $"Impossible de modifier les attributs";
                    break;
            }
            //show error message
            BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, errorMessage);
        }

        partial void BtnSaveChanges_TouchUpInside(UIButton sender)
        {
            //set pet attribute fields
            petAttribute.AttributeTitle = tfAttributName.Text;
            petAttribute.AttributeDescription = tvAttributDescription.Text;
            petAttribute.PetAttributeType = selectedType;

            //remove old attribute and add new one
            if (petAttributeID != -1)
                ServerHelper.DeleteAttribut(Application.PetManager.SelectedPet.PetID, petAttributeID);

            //send packet to server
            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.AddAttribut(Application.PetManager.SelectedPet.PetID, petAttribute);
            if (serverPacketConfirmation.ActionSuccess)
            {
                this.NavigationController.PopViewController(true);
                return;
            }

            //chose right error message
            String errorMessage = string.Empty;
            switch (serverPacketConfirmation.NetworkError)
            {
                case NetworkError.SERVER_UNAVAILABLE:
                    errorMessage = MSGBank.ERROR_NO_SERVER;
                    break;
                default:
                    errorMessage = $"Impossible de modifier les attributs";
                    break;
            }
            //show error message
            BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, errorMessage);
        }

        /// <summary>
        /// Updates the attribute view.
        /// </summary>
        public void UpdateAttributeView()
        {
            //populate fields
            tfAttributName.Text = petAttribute.AttributeTitle;
            tvAttributDescription.Text = petAttribute.AttributeDescription;
            ivAttributIcon.Image = IosPetHelper.GetImageForAttributeType(petAttribute.PetAttributeType);
        }

        /// <summary>
        /// Inits the attribut type picker.
        /// </summary>
        public void InitAttributTypePicker()
        {
            //create new picker model
            var petTypePicketModel = new PetTypePickerModel(Enum.GetValues(typeof(PetAttributeType)));

            //set picker view model
            pvAttributTypePicker.Model = petTypePicketModel;

            //add event handler
            petTypePicketModel.typeChangeEvent += (sender, e) =>
            {
                selectedType = petTypePicketModel.selectedType;
                ivAttributIcon.Image = IosPetHelper.GetImageForAttributeType(selectedType);
            };

        }


        //language picker model
        public class PetTypePickerModel : UIPickerViewModel
        {
            List<String> petTypes;                              //pet type name list
            public EventHandler typeChangeEvent;                //pet type change event
            public PetAttributeType selectedType;               //selected pet type

            /// <summary>
            /// Initializes a new instance of the <see cref="T:PetLaForme.AttributViewController.PetTypePickerModel"/> class.
            /// </summary>
            /// <param name="attTypes">Att types.</param>
            public PetTypePickerModel(Array attTypes)
            {
                this.petTypes = new List<string>();

                foreach (var type in attTypes)
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
                //set selected type
                selectedType = (PetAttributeType)((int)row);

                //trigger event
                typeChangeEvent?.Invoke(null, null);
            }

        }
    }
}