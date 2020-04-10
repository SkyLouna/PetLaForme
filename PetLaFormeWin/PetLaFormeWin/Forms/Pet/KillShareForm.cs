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
    public partial class KillShareForm : Form
    {

        PLFPet pet;
        List<PLFUser> userList;

        PLFUser selectedUser;

        public KillShareForm(PLFPet pet, List<PLFUser> userList)
        {
            InitializeComponent();

            this.pet = pet;
            this.userList = userList;

            selectedUser = null;

            this.Disposed += new EventHandler(delegate{ Program.mainBoard.SharePetBoard.KillShareForm = null; });

            PopulateListBox();

            tbPetName.Text = pet.PetName;
            tbPetType.Text = pet.PetType.ToString();
            pbPetImage.Image = PetHelper.GetImageForPetType(pet.PetType);

        }

        private void PopulateListBox()
        {
            foreach (var user in userList)
                lbUserShareList.Items.Add($"{user.UserNickName} ({user.UserName} - {user.UserSurname})");
        }

        private void pbBtnStopShare_Click(object sender, EventArgs e)
        {
            if(selectedUser == null)
            {
                MessageBox.Show("Il faut sélectionner un utilisateur !", MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.KillSharePet(pet.PetID, selectedUser.ID);

            if (serverPacketConfirmation.ActionSuccess)
            {
                MessageBox.Show($"Le partage a bien été céssé avec {selectedUser.UserNickName} !", "Partage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
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
                    errorMessage = $"Impossible de césser le partage de ce familier !";
                    break;
            }
            //show error message
            MessageBox.Show(errorMessage, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void lbUserShareList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lbUserShareList.SelectedIndex;

            if (selectedIndex == -1)
                return;

            selectedUser = userList[selectedIndex];
        }
    }
}
