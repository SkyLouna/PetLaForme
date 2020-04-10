using PetLaFormeWin.Helper;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Helper;
using PLFAPI.Object.Pet;
using PLFAPI.Object.User;
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
    public partial class SharePetBoard : Form
    {

        Boolean allowModifications;                         //user allowed modifications
            
        PLFPet selectedPet;                                 //selected pet

        KillShareForm killShareForm;                        //kill share form


        public SharePetBoard(PLFPet selectedPet)
        {
            //init component
            InitializeComponent();

            //populate list box
            PopulateListBox();

            //set selected pet and icon
            this.selectedPet = selectedPet;
            if(selectedPet != null)
                pbPetImage.Image = PetHelper.GetImageForPetType(selectedPet.PetType);
        }

        private void PopulateListBox()
        {
            //foreach own user pet
            foreach (var pet in Program.petManager.UserOwnPets)
                lbUserPet.Items.Add(pet.PetName);
        }

        private void lbUserPet_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lbUserPet.SelectedIndex;

            //if selected index is not null
            if (selectedIndex == -1)
                return;

            //set selected pet and image
            selectedPet = Program.petManager.UserPets[selectedIndex];
            pbPetImage.Image = PetHelper.GetImageForPetType(selectedPet.PetType);
        }

        private void cbAllowModifications_CheckedChanged(object sender, EventArgs e)
        {
            //change state of allow modifications
            allowModifications = cbAllowModifications.Checked;
        }

        private void pbBtnShare_Click(object sender, EventArgs e)
        {
            //if try to share to himself
            if(tbUserNick.Text.ToLower() == Program.acutalUser.UserNickName.ToLower())
            {
                MessageBox.Show(MSGBank.ERROR_SHARE_YOURSELF, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //send share pet packet to server
            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.SharePet(
                Program.acutalUser, selectedPet, tbUserNick.Text, allowModifications ? 1 : 0);

            //if success share
            if (serverPacketConfirmation.ActionSuccess)
            {
                Program.mainBoard.HidePetShareBoard();
                MessageBox.Show($"Votre familier a bien été partagé avec {tbUserNick.Text}", "Partage", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MessageBox.Show(errorMessage, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void pbBtnStopShare_Click(object sender, EventArgs e)
        {
            //if form isn't null
            if (killShareForm != null)
            {
                //bring form to front
                killShareForm.BringToFront();
                return;
            }

            //get user share list online
            List<PLFUser> userList = ServerHelper.SharePetList(selectedPet.PetID).UserList;

            //if list is empty
            if(userList.Count <= 0)
            {
                MessageBox.Show("Ce familier n'est partagé avec personne !", MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //init and show kill share form
            killShareForm = new KillShareForm(selectedPet, userList);
            killShareForm.Show();
        }

        private void pbBtnReturnToMenu_Click(object sender, EventArgs e)
        {
            //hide pet share board
            Program.mainBoard.HidePetShareBoard();
        }

        public KillShareForm KillShareForm { get => killShareForm; set => killShareForm = value; }


    }
}
