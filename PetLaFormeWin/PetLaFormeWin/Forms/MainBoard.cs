using PetLaFormeWin.Helper;
using PLFAPI.Object.Pet;
using PLFAPI.Object.Pet.Attribute;
using PLFAPI.Object.User;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetLaFormeWin.Forms
{
    public partial class MainBoard : Form
    {

        UserProfileBoard userProfileBoard;                          //user profile board
        PetsPreviewBoard petsPreviewBoard;                          //pets preview form
        PetViewBoard petViewBoard;                                  //pet view form
        AddPetBoard addPetBoard;                                    //add pet form
        PetAttributePreviewBoard petAttributePreview;               //pet attribute form
        SharePetBoard sharePetBoard;

        UserSettingsForm userSettingsForm;
        UserAccountConfirmForm userAccountConfirmForm;

        

        public MainBoard()
        {
            InitializeComponent();

            //add event handlers
            this.FormClosing += delegate { Application.Exit(); };
            this.Shown += new EventHandler(OnFormShow);

            if(!Program.actualUserConfirmed)
            {
                userAccountConfirmForm = new UserAccountConfirmForm();
                userAccountConfirmForm.Show();
                userAccountConfirmForm.BringToFront();
                return;
            }

            //hide panel 1 and expand panel 2
            mainSplitContainer.Panel1.ClientSize = new Size(0, 700);
            mainSplitContainer.SplitterDistance = 0;

            //show pet list
            ShowPetList(true);
        }

        private void pbBtnMainSettings_Click(object sender, EventArgs e)
        {
            if(userSettingsForm != null)
            {
                userSettingsForm.BringToFront();
                return;
            }

            userSettingsForm = new UserSettingsForm();
            userSettingsForm.Show();
        }

        private void pbBtnUserProfile_Click(object sender, EventArgs e)
        {
            //show user profile
            ShowUserProfile();
        }

        private void lblConnectedAs_Click(object sender, EventArgs e)
        {
            //show user profile
            ShowUserProfile();
        }

        private void pbBtnLogout_Click(object sender, EventArgs e)
        {
            //set actual user to null
            Program.acutalUser = null;

            ConnectionHelper.DeleteConnectionProfile();

            if (userSettingsForm != null)
                userSettingsForm.Dispose();
            userSettingsForm = null;

            //dispose this form and show login form
            this.Dispose();
            Program.formRegisterLogin.Show();
        }

        private void OnFormShow(object sender, EventArgs e)
        {
            //updatescreen infos and hide user profile
            UpdateScreenInfos();
            HideUserProfile();
        }
        
        public void ShowUserProfile()
        {

            HidePetAttributPreview();
            HidePetShareBoard();

            //if user profile isn't null
            if (userProfileBoard != null)
            {
                HideUserProfile();
                return;
            }

            //create new user profile board
            userProfileBoard = new UserProfileBoard();
            userProfileBoard.TopLevel = false;
            
            //add to split container and show panel 1
            mainSplitContainer.Panel1.Controls.Add(userProfileBoard);
            mainSplitContainer.Panel1.ClientSize = new Size(400, 700);
            mainSplitContainer.SplitterDistance = 399;

            //show user profile board
            userProfileBoard.Show();

            //update other components
            UpdatePetList();
            UpdateAddPet();
            UpdateSelectedPet();
        }

        public void HideUserProfile()
        {
            //if no user profile board
            if (userProfileBoard == null)
                return;

            //dispose user profile and hide panel 1
            userProfileBoard.Dispose();
            mainSplitContainer.Panel1.ClientSize = new Size(0, 700);
            mainSplitContainer.SplitterDistance = 0;

            //update other components
            UpdatePetList();
            UpdateAddPet();
            UpdateSelectedPet();
        }

        public void ShowPetAttributPreview(PLFPet pet, PetAttribute petAttribute, int petAttributeID)
        {
            //hide user profile
            HideUserProfile();
            HidePetShareBoard();

            //if there is a petAttributePreview board
            if (petAttributePreview != null)
            {
                //dispose anb create new with attribute
                petAttributePreview.Dispose();
                petAttributePreview = new PetAttributePreviewBoard(pet, petAttribute, petAttributeID);
                petAttributePreview.TopLevel = false;
                mainSplitContainer.Panel1.Controls.Add(petAttributePreview);
            }
            else
            {
                //create new board with specific attribute and specific pet
                petAttributePreview = new PetAttributePreviewBoard(pet, petAttribute, petAttributeID);
                petAttributePreview.TopLevel = false;
                mainSplitContainer.Panel1.Controls.Add(petAttributePreview);
                mainSplitContainer.Panel1.ClientSize = new Size(400, 700);
                mainSplitContainer.SplitterDistance = 399;
            }

            //show pet attribute view
            petAttributePreview.Show();

            //update other components
            UpdatePetList();
            UpdateAddPet();
            UpdateSelectedPet();
        }

        public void HidePetAttributPreview()
        {
            //if pet attribute preview board is null
            if (petAttributePreview == null)
                return;

            //dispose board
            petAttributePreview.Dispose();
            petAttributePreview = null;

            //hide panel 1
            mainSplitContainer.Panel1.ClientSize = new Size(0, 700);
            mainSplitContainer.SplitterDistance = 0;

            //update other components
            UpdatePetList();
            UpdateAddPet();
            UpdateSelectedPet();
        }

        public void ShowPetShareBoard(PLFPet pet)
        {
            //hide user profile
            HideUserProfile();
            HidePetAttributPreview();

            //if there is a petAttributePreview board
            if (sharePetBoard != null)
            {
                //dispose anb create new with attribute
                sharePetBoard.Dispose();
                sharePetBoard = new SharePetBoard(pet);
                sharePetBoard.TopLevel = false;
                mainSplitContainer.Panel1.Controls.Add(sharePetBoard);
            }
            else
            {
                //create new board with specific attribute and specific pet
                sharePetBoard = new SharePetBoard(pet);
                sharePetBoard.TopLevel = false;
                mainSplitContainer.Panel1.Controls.Add(sharePetBoard);
                mainSplitContainer.Panel1.ClientSize = new Size(400, 700);
                mainSplitContainer.SplitterDistance = 399;
            }

            //show pet attribute view
            sharePetBoard.Show();

            //update other components
            UpdatePetList();
            UpdateAddPet();
            UpdateSelectedPet();
        }

        public void HidePetShareBoard()
        {
            //if pet attribute preview board is null
            if (sharePetBoard == null)
                return;

            //dispose board
            sharePetBoard.Dispose();
            sharePetBoard = null;

            //hide panel 1
            mainSplitContainer.Panel1.ClientSize = new Size(0, 700);
            mainSplitContainer.SplitterDistance = 0;

            //update other components
            UpdatePetList();
            UpdateAddPet();
            UpdateSelectedPet();
        }


        public void ShowPetList(Boolean petUpdate)
        {
            //dispose other components
            DisposeSelectedPet();
            DisposeAddPet();

            //create new pets preview board
            petsPreviewBoard = new PetsPreviewBoard();
            petsPreviewBoard.TopLevel = false;
            mainSplitContainer.Panel2.Controls.Add(petsPreviewBoard);

            if (petUpdate)
                petsPreviewBoard.UpdateUserPets();
                        
            petsPreviewBoard.Show();

            //update pet list
            UpdatePetList();
            petsPreviewBoard.DrawPetList();
            petsPreviewBoard.UpdateSelectedPet();
        }

        public void DisposePetList()
        {
            //if pet preview board is null
            if (petsPreviewBoard == null)
                return;

            //remove form and dispose
            mainSplitContainer.Panel2.Controls.Remove(petsPreviewBoard);
            petsPreviewBoard.Dispose();
        }

        public void UpdatePetList()
        {
            //if pet preview board is null
            if (petsPreviewBoard == null)
                return;

            //calculate x and y size
            int xSize = 1180 - mainSplitContainer.SplitterDistance;
            int ySize = petsPreviewBoard.Size.Height;

            //set new size to board
            petsPreviewBoard.Size = new Size(xSize, ySize);
        }

        public void ShowSelectedPet(PLFPet selectedPet)
        {
            //dispose pet list
            DisposePetList();

            //create new pet board
            petViewBoard = new PetViewBoard(selectedPet);
            petViewBoard.TopLevel = false;
            mainSplitContainer.Panel2.Controls.Add(petViewBoard);

            //show pet board
            petViewBoard.Show();

            UpdateSelectedPet();
        }

        public void UpdateSelectedPet()
        {
            //if pet view board is null
            if (petViewBoard == null)
                return;

            //calculate new size
            int xSize = 1180 - mainSplitContainer.SplitterDistance;
            int ySize = petViewBoard.Size.Height;

            //set size
            petViewBoard.Size = new Size(xSize, ySize);
        }

        public void DisposeSelectedPet()
        {
            //if pet view is null
            if (petViewBoard == null)
                return;

            //remove and dispose
            mainSplitContainer.Panel2.Controls.Remove(petViewBoard);
            petViewBoard.Dispose();
        }

        public void ShowAddPet()
        {
            //dispose pet list
            DisposePetList();

            //add new add pet board
            addPetBoard = new AddPetBoard();
            addPetBoard.TopLevel = false;
            mainSplitContainer.Panel2.Controls.Add(addPetBoard);

            //show
            addPetBoard.Show();

            UpdateAddPet();
        }

        public void DisposeAddPet()
        {
            //if not null
            if (addPetBoard == null)
                return;

            //remove and dispose
            mainSplitContainer.Panel2.Controls.Remove(addPetBoard);
            addPetBoard.Dispose();
        }

        public void UpdateAddPet()
        {
            //if not null
            if (addPetBoard == null)
                return;

            //calculate size
            int xSize = 1180 - mainSplitContainer.SplitterDistance;
            int ySize = addPetBoard.Size.Height;

            //set size
            addPetBoard.Size = new Size(xSize, ySize);
        }

        public void UpdateScreenInfos()
        {
            //get actual user
            PLFUser actualUser = Program.acutalUser;

            //if not null
            if (actualUser == null)
                return;

            //replace text with username
            lblConnectedAs.Text = lblConnectedAs.Text.Replace("{USERNAME}", actualUser.UserNickName);
        }

        public PetsPreviewBoard PetsPreviewBoard { get => petsPreviewBoard; set => petsPreviewBoard = value; }
        public PetViewBoard PetViewBoard { get => petViewBoard; set => petViewBoard = value; }
        public AddPetBoard AddPetBoard { get => addPetBoard; set => addPetBoard = value; }
        public PetAttributePreviewBoard PetAttributePreview { get => petAttributePreview; set => petAttributePreview = value; }
        public SharePetBoard SharePetBoard { get => sharePetBoard; set => sharePetBoard = value; }
        public UserProfileBoard UserProfileBoard { get => userProfileBoard; set => userProfileBoard = value; }
        public UserSettingsForm UserSettingsForm { get => userSettingsForm; set => userSettingsForm = value; }
        public UserAccountConfirmForm UserAccountConfirmForm { get => userAccountConfirmForm; set => userAccountConfirmForm = value; }
    }
}
