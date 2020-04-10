using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetLaFormeWin.Manager;
using PetLaFormeWin.Object.Cards;
using PLFAPI.Helper;
using PLFAPI.Object.Pet;

namespace PetLaFormeWin.Forms
{
    public partial class PetsPreviewBoard : Form
    {
        PLFPet selectedPet;                     //selected pet

        List<ImageCard> petCards;                 //list of pet cards

        List<PLFPet> pets;

        /////////////////////////////////////////////////// PAGE CONTROLL //////////////////////////////////////////

        int actualPage;

        int amountOfPage;

        public PetsPreviewBoard()
        {
            InitializeComponent();
                 
            //init pet cards
            petCards = new List<ImageCard>();

            this.actualPage = 0;
            this.amountOfPage = 0;
           
            //add event handlers
            this.Shown += new EventHandler(OnFormShow);
            this.SizeChanged += new EventHandler(OnSizeChanged);

        }

        public void UpdateUserPets()
        {
            //load user pet list from server
            Program.petManager.LoadUserPetList(Program.acutalUser);
            pets = Program.petManager.UserPets;
        }

        public void UpdateSelectedPet()
        {
            //if null
            if(selectedPet == null)
            {
                gbPetInfoContainer.Hide();
                return;
            }

            //show container and populate fields
            gbPetInfoContainer.Show();
            tbSelectedPetName.Text = selectedPet.PetName;
            tbSelectedPetType.Text = selectedPet.PetType.ToString();
            pbSelectedPetImage.Image = PetHelper.GetImageForPetType(selectedPet.PetType);

            //show shared logo if shared pet
            if (selectedPet.Shared)
                pbIsSharedPet.Show();
            else
                pbIsSharedPet.Hide();
               
        }

        public void DrawPetList()
        {
            pets = Program.petManager.UserPets;
            //get max width size
            int maxXSize = this.Size.Width;

            //count amount of pets + 1 because of add new pet card
            int amountOfAttributs = pets.Count + 1;

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

            //foreach user pets
            foreach(var pet in pets)
            {

                //if card is on page
                if (card >= actualPage * maxAmountPerPage && card < (actualPage + 1) * maxAmountPerPage)
                {

                    //create new pet card
                    PetCard petCard = new PetCard(pet, null,
                    delegate { selectedPet = pet; UpdateSelectedPet(); Program.mainBoard.ShowSelectedPet(pet); });
                    petCard.SetLocation(x, y, gbPetList);
                    petCard.DrawForm();
                    petCard.ActionOnClick = delegate
                    {
                    //reset all cards border color
                    foreach (var ptCard in petCards)
                        {
                            ptCard.GbBoxContainer.BorderColor = Color.Black;
                            ptCard.GbBoxContainer.Refresh();
                        }

                    //change selected pet border and update
                    selectedPet = pet; UpdateSelectedPet();
                        petCard.GbBoxContainer.BorderColor = Color.Blue;
                        petCard.GbBoxContainer.Refresh();
                    };

                    //add card to list
                    petCards.Add(petCard);

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

            //if is on right page
            if (card >= actualPage * maxAmountPerPage && card < (actualPage + 1) * maxAmountPerPage)
            {

                //create add attribut card
                AddCard addNewAttributCard = new AddCard(delegate { Program.mainBoard.ShowAddPet(); });

                addNewAttributCard.SetLocation(x, y, gbPetList);
                addNewAttributCard.DrawForm();

                petCards.Add(addNewAttributCard);
            }
        }

        public void ResetPetList()
        {
            //foreach existing cards
            foreach (var card in petCards)
                card.Dispose();

            //clear list
            petCards.Clear();
        }

        private void OnFormShow(object sender, EventArgs e)
        {

        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            //redraw pet list
            ResetPetList();
            DrawPetList();

            //change btn location
            int btnAddYLocation = pbBtnAddPet.Location.Y;
            int btnAddXLocation = this.Size.Width - pbBtnAddPet.Size.Width;
            pbBtnAddPet.Location = new Point(btnAddXLocation, btnAddYLocation);

            gbPageControll.Location = new Point((this.Size.Width / 2) - (gbPageControll.Size.Width / 2), gbPageControll.Location.Y);
        }

        private void pbBtnShowPet_Click(object sender, EventArgs e)
        {
            //show selected pet view
            Program.mainBoard.ShowSelectedPet(selectedPet);
        }

        private void pbBtnAddPet_Click(object sender, EventArgs e)
        {
            //show add pet view
            Program.mainBoard.ShowAddPet();
        }

        private void pbBtnLeftPage_Click(object sender, EventArgs e)
        {
            if (actualPage <= 0)
                return;

            actualPage--;
            ResetPetList();
            DrawPetList();
        }

        private void pbBtnRightPage_Click(object sender, EventArgs e)
        {
            if (actualPage >= amountOfPage - 1)
                return;
            actualPage++;
            ResetPetList();
            DrawPetList();
        }
    }
}
