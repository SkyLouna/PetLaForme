using PetLaFormeWin.Helper;
using PetLaFormeWin.Object.Cards;
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
    public partial class PetViewBoard : Form
    {
        PLFPet pet;                                 //selected pet

        List<ImageCard> attributCardList;           //selected pet attributs list

        List<PetAttribute> petAttributes;
        Dictionary<PetAttribute, int> petAttributesID;


        /////////////////////////////////////////////////// PAGE CONTROLL //////////////////////////////////////////

        int actualPage;

        int amountOfPage;

        public PetViewBoard(PLFPet pet)
        {
            //init component
            InitializeComponent();

            this.pet = pet;
            this.actualPage = 0;
            this.amountOfPage = 0;

            //populate fields with pet infos
            pbPetImage.Image = PetHelper.GetImageForPetType(pet.PetType);
            tbPetName.Text = pet.PetName;
            tbPetType.Text = pet.PetType.ToString();

            //create new list of attributs card
            attributCardList = new List<ImageCard>();

            //add event handlers
            this.SizeChanged += new EventHandler(OnSizeChanged);

            UpdatePetAttributes();

            //if shared pet hide some shit
            if(pet.Shared)
            {
                lblBtnDeletePet.Hide();
                lblBtnSharePetTitle.Hide();
                pbBtnDeletePet.Hide();
                pbBtnSharePet.Hide();
            }
        }

        //
        //              Event handlerss
        //
        private void pbBtnBackToMenu_Click(object sender, EventArgs e)
        {
            Program.mainBoard.HidePetAttributPreview();
            Program.mainBoard.ShowPetList(false);
        }

        private void pbBtnDeletePet_Click(object sender, EventArgs e)
        {
            DeletePet();
        }

        private void lblBtnDeletePet_Click(object sender, EventArgs e)
        {
            DeletePet();
        }

        //
        //              Other methods
        //

        public void UpdatePetAttributes()
        {
            petAttributes = Program.petManager.DownloadPetAttributs(pet.PetID);
            petAttributesID = new Dictionary<PetAttribute, int>();
            for (int i = 0; i < petAttributes.Count; i++)
                petAttributesID.Add(petAttributes[i], i);
            Console.WriteLine("Attributs: " + petAttributes.Count);
        }

        public void DeletePet()
        {
            //new instance of dialog result
            DialogResult dialogResult = MessageBox.Show(
                "Etes vous sûr de vouloir supprimer ce familier ?", "Suppression de familier", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if user answer yes
            if (dialogResult == DialogResult.Yes)
            {
                //send delete pet to server
                ServerPacketConfirmation serverPacketConfirmation = ServerHelper.DeletePet(Program.acutalUser, pet);

                //if pet successfuly delete
                if (serverPacketConfirmation.ActionSuccess)
                {
                    Program.petManager.DeletePet(pet);
                    Program.mainBoard.HidePetAttributPreview();
                    Program.mainBoard.ShowPetList(true);
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
                //Show error message
                MessageBox.Show(errorMessage, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DrawAttributList()
        {
            ResetAttributList();

            //get max width size
            int maxXSize = this.Size.Width;

            //count amount of pet attributs
            int amountOfAttributs = petAttributes.Count + ((pet.SharePower == -1 || pet.SharePower > 0) ? 1 : 0);

            //Calculate amount per page (A card takes 180 px of width, and there are two rows)
            int maxAmountPerPage = maxXSize / 90;

            //calculate amount of pages
            amountOfPage = amountOfAttributs / maxAmountPerPage + (amountOfAttributs % maxAmountPerPage == 0 ? 0 : 1);

            //if actual page is to bigger when user resize
            if (actualPage >= amountOfPage)
                actualPage = amountOfPage - 1;

            int card = 0;

            int x = 8;
            int y = 8;

            //foreach pet attributs
            foreach (var attribute in petAttributes)
            {
                //if card is on page
                if (card >= actualPage * maxAmountPerPage && card < (actualPage + 1) * maxAmountPerPage)
                {
                    //create new attribut card
                    AttributCard attributCard = new AttributCard(attribute,
                        delegate { Program.mainBoard.ShowPetAttributPreview(pet, attribute, petAttributesID[attribute]); },
                        delegate { Program.mainBoard.ShowPetAttributPreview(pet, attribute, petAttributesID[attribute]); });
                    attributCard.SetLocation(x, y, gbAttributBox);
                    attributCard.DrawForm();

                    attributCardList.Add(attributCard);

                    //increment positions
                    x += 196;
                    if (x > maxXSize)
                    {
                        x = 8;
                        y += 196;
                    }
                }
                card++;
            }

            //if user has enough share power
            if ((pet.SharePower == -1 || pet.SharePower > 0) && card >= actualPage * maxAmountPerPage && card < (actualPage + 1) * maxAmountPerPage)
            {

                //create add attribut card
                AddCard addNewAttributCard = new AddCard(
                  delegate { Program.mainBoard.ShowPetAttributPreview(pet, null, -1); },
                  delegate { Program.mainBoard.ShowPetAttributPreview(pet, null, -1); });

                addNewAttributCard.SetLocation(x, y, gbAttributBox);
                addNewAttributCard.DrawForm();

                attributCardList.Add(addNewAttributCard);
            }

            //update label page
            lblPageNav.Text = $"{actualPage + 1} / {amountOfPage}";
        }

        public void ResetAttributList()
        {
            //foreach card, dispose
            foreach (var card in attributCardList)
                card.Dispose();
            attributCardList.Clear();
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            //get reseize width
            const int resizeWidth = 250;

            //reset lists with new size
            DrawAttributList();

            //redraw share and delete buttons position
            pbBtnDeletePet.Location = new Point(this.Size.Width - resizeWidth, pbBtnDeletePet.Location.Y);
            pbBtnSharePet.Location = new Point(this.Size.Width - resizeWidth, pbBtnSharePet.Location.Y);

            lblBtnDeletePet.Location = new Point(this.Size.Width - resizeWidth, lblBtnDeletePet.Location.Y);
            lblBtnSharePetTitle.Location = new Point(this.Size.Width - resizeWidth, lblBtnSharePetTitle.Location.Y);

            gbPageControll.Location = new Point((this.Size.Width / 2) - (gbPageControll.Size.Width / 2) , gbPageControll.Location.Y);
        }

        private void pbBtnSharePet_Click(object sender, EventArgs e)
        {
            //show pet list share board
            Program.mainBoard.ShowPetShareBoard(pet);
        }

        private void lblBtnSharePetTitle_Click(object sender, EventArgs e)
        {
            //show pet list share board
            Program.mainBoard.ShowPetShareBoard(pet);
        }

        private void lblPageNav_Click(object sender, EventArgs e)
        {

        }

        private void pbBtnLeftPage_Click(object sender, EventArgs e)
        {
            //if already on first page
            if (actualPage <= 0)
                return;

            //decrement page and redraw
            actualPage--;
            DrawAttributList();
        }

        private void pbBtnRightPage_Click(object sender, EventArgs e)
        {
            //if already on last page
            if (actualPage >= amountOfPage - 1)
                return;

            //increment page and redraw
            actualPage++;
            DrawAttributList();
        }

        public PLFPet Pet { get => pet; set => pet = value; }
    }
}
