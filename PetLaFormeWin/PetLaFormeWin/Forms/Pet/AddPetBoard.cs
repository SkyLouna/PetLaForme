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
    public partial class AddPetBoard : Form
    {
        public AddPetBoard()
        {
            InitializeComponent();

            //populate list box
            PopulatePetTypeList();

            //add new event handler
            this.SizeChanged += new EventHandler(OnSizeChanged);
        }

        public void PopulatePetTypeList()
        {
            //foreach existing pet type add to list
            foreach (var type in typeof(PetType).GetEnumValues())
                lbUserPetType.Items.Add(type.ToString());
        }

        private void pbBtnCancelAdd_Click(object sender, EventArgs e)
        {
            //show pet list
            Program.mainBoard.ShowPetList(false);
        }

        private void lbUserPetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get list box selected index
            int selectedIndex = lbUserPetType.SelectedIndex;

            if (selectedIndex == -1)
                return;

            //set the two logos
            pbUserPetTypeIcon.Image = PetHelper.GetImageForPetType((PetType)selectedIndex);
            pbPetImage.Image = pbUserPetTypeIcon.Image;

            //set type text
            tbPetType.Text = ((PetType)selectedIndex).ToString();
        }

        private void pbBtnSavePet_Click(object sender, EventArgs e)
        {
            //get list box selected index
            int selectedIndex = lbUserPetType.SelectedIndex;

            //create new pet with form infos
            PLFPet pet = new PLFPet((PetType)selectedIndex);
            pet.PetName = tbUserPetName.Text;
            //pet.PetAttributs = PetHelper.GetDefaultAttributs();

            //send server add pet packet to server
            ServerPacketAddPet serverPacketAddPet = ServerHelper.AddPet(Program.acutalUser, pet);

            //if error during register
            if (!serverPacketAddPet.RegisterSuccess)
            {

                //chose right error message
                String errorMessage = string.Empty;
                switch(serverPacketAddPet.NetworkError)
                {
                    case NetworkError.SERVER_UNAVAILABLE:
                        errorMessage = MSGBank.ERROR_NO_SERVER;
                        break;
                    default:
                        errorMessage = $"Impossible d'ajouter ce nouveau familier";
                        break;
                }
                //show error message
                MessageBox.Show(errorMessage, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //set pet id with server answer
            pet.PetID = serverPacketAddPet.PetID;

            //add pet to user pet list
            Program.petManager.AddPet(pet);

            //show pet list
            Program.mainBoard.ShowPetList(true);
        }

        private void tbUserPetName_TextChanged(object sender, EventArgs e)
        {
            //change pet preview text
            tbPetName.Text = tbUserPetName.Text;
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {

        }
    }
}
