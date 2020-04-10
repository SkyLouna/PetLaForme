using PetLaFormeWin.Helper;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Helper;
using PLFAPI.Object.Pet;
using PLFAPI.Object.Pet.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetLaFormeWin.Forms
{
    public partial class PetAttributePreviewBoard : Form
    {
        PLFPet pet;                                 //pet
        PetAttribute petAttribute;                  //pet specific attribute
        int petAttributeID;

        public PetAttributePreviewBoard(PLFPet pet, PetAttribute petAttribute, int petAttributeID)
        {
            InitializeComponent();

            //populate pet list
            PopulatePetTypeList();

            this.pet = pet;
            this.petAttribute = petAttribute;
            this.petAttributeID = petAttributeID;

            //if null
            if (this.petAttribute == null)
                this.petAttribute = new PetAttribute(PetAttributeType.OTHER, "", "");

            //populate form fields with attribute infos
            tbUserAttributeTitle.Text = this.petAttribute.AttributeTitle;
            tbUserAttributDescription.Text = this.petAttribute.AttributeDescription;

            lbUserAttribute.SelectedIndex = (int)this.petAttribute.PetAttributeType;

            pbAttributeIcon.Image = PetHelper.GetImageForPetAttributeType(this.petAttribute.PetAttributeType);

            //hide if share power is not enough
            if (!(pet.SharePower == -1 || pet.SharePower > 0))
            {
                pbBtnDelete.Hide();
                pbBtnSave.Hide();
                lbUserAttribute.Enabled = false;
            }
        }

        public void PopulatePetTypeList()
        {
            //foreach existing pet attribute type
            foreach (var type in typeof(PetAttributeType).GetEnumValues())
                lbUserAttribute.Items.Add(type.ToString());
        }

        private void pbBtnSave_Click(object sender, EventArgs e)
        {
            //set pet attribute fields
            petAttribute.AttributeTitle = tbUserAttributeTitle.Text;
            petAttribute.AttributeDescription = tbUserAttributDescription.Text;

            //remove old attribute and add new one
            if(petAttributeID != -1)
            ServerHelper.DeleteAttribut(pet.PetID, petAttributeID);

            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.AddAttribut(pet.PetID, petAttribute);
            if (serverPacketConfirmation.ActionSuccess)
            {
                Program.mainBoard.HidePetAttributPreview();
                Program.mainBoard.PetViewBoard.UpdatePetAttributes();
                Program.mainBoard.PetViewBoard.DrawAttributList();
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
            MessageBox.Show(errorMessage, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void pbBtnDelete_Click(object sender, EventArgs e)
        {
            //remove attribute
            ServerPacketConfirmation serverPacketConfirmation =  ServerHelper.DeleteAttribut(pet.PetID, petAttributeID);

            if(serverPacketConfirmation.ActionSuccess)
            {
                Program.mainBoard.HidePetAttributPreview();
                Program.mainBoard.PetViewBoard.UpdatePetAttributes();
                Program.mainBoard.PetViewBoard.DrawAttributList();
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
            MessageBox.Show(errorMessage, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void pbBtnReturnToMenu_Click(object sender, EventArgs e)
        {
            //hide attribute view
            Program.mainBoard.HidePetAttributPreview();
        }

        private void lbUserAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get selected index
            int selectedIndex = lbUserAttribute.SelectedIndex;

            if (selectedIndex == -1)
                return;

            //set pet attribute type
            petAttribute.PetAttributeType = (PetAttributeType)selectedIndex;

            //set pet attribute icon
            pbAttributeIcon.Image = PetHelper.GetImageForPetAttributeType(petAttribute.PetAttributeType);
        }

        private void tbUserAttributDescription_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
