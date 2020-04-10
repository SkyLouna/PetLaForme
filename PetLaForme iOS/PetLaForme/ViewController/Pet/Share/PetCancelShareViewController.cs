using Foundation;
using LViOSLibrary.Helper;
using PetLaForme.Helper;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Object.Pet;
using PLFAPI.Object.User;
using System;
using System.Collections.Generic;
using UIKit;

namespace PetLaForme
{
    public partial class PetCancelShareViewController : UIViewController
    {

        PLFUser selectedUser;                       //selected share user
        PLFPet selectedPet;                         //selected share user

        public PetCancelShareViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            //get selected pet and populate fields
            selectedPet = Application.PetManager.SelectedPet;
            lblPetName.Text = selectedPet.PetName;
            ivPetIcon.Image = IosPetHelper.GetImageForPetType(selectedPet.PetType);

            //load page
            LoadPage();

        }

        /// <summary>
        /// Loads the page.
        /// </summary>
        public void LoadPage()
        {
            //get user share list online
            List<PLFUser> userList = ServerHelper.SharePetList(selectedPet.PetID).UserList;

            //if no 
            if (userList.Count <= 0)
            {
                InitUserPicker(new List<PLFUser>());
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, "Ce familier n'est partagé avec personne !");
                return;
            }

            //init user picker with downloaded list
            InitUserPicker(userList);
            selectedUser = userList[0];
            pvUserPicker.SelectedRowInComponent(0);
        }

        partial void BtnCancelShare_TouchUpInside(UIButton sender)
        {
            //if no user selected
            if (selectedUser == null)
            {
                BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, "Il faut sélectionner un utilisateur !");
                return;
            }

            //send kill share pet to server
            ServerPacketConfirmation serverPacketConfirmation = ServerHelper.KillSharePet(selectedPet.PetID, selectedUser.ID);

            //if success
            if (serverPacketConfirmation.ActionSuccess)
            {
                BarHelper.DisplayInfoBar(uivMainView,"Partage", $"Le partage a bien été cessé avec {selectedUser.UserNickName} !");
                //reload page
                LoadPage();
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
            BarHelper.DisplayErrorBar(uivMainView, MSGBank.ERROR_TITLE, errorMessage);


        }

        /// <summary>
        /// Inits the user picker.
        /// </summary>
        /// <param name="users">Users.</param>
        public void InitUserPicker(List<PLFUser> users)
        {

            //new picket model
            var userPickerModel = new PetTypePickerModel(users);

            //set picker view model
            pvUserPicker.Model = userPickerModel;

            //add event handler
            userPickerModel.userChangeEvent += (sender, e) =>
            {
                selectedUser = userPickerModel.selectedUser;
            };

        }


        //language picker model
        public class PetTypePickerModel : UIPickerViewModel
        {
            List<String> users;                                     //user name list
            public EventHandler userChangeEvent;                    //user change event
            public PLFUser selectedUser;                            //selected user
            List<PLFUser> plfUsers;                                 //user list

            /// <summary>
            /// Initializes a new instance of the
            /// <see cref="T:PetLaForme.PetCancelShareViewController.PetTypePickerModel"/> class.
            /// </summary>
            /// <param name="users">Users.</param>
            public PetTypePickerModel(List<PLFUser> users)
            {
                this.plfUsers = users;
                this.users = new List<String>();

                //foreach user add name to string list
                foreach (var user in plfUsers)
                    this.users.Add($"{user.UserNickName} ({user.UserSurname} - {user.UserName})");
            }

            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
                //user list size
                return users.Count;
            }

            public override nint GetComponentCount(UIPickerView pickerView)
            {
                return 1;
            }

            public override string GetTitle(UIPickerView pickerView, nint row, nint component)
            {
                return users[(int)row];
            }

            public override void Selected(UIPickerView pickerView, nint row, nint component)
            {
                //Change selected user
                selectedUser = plfUsers[(int)row];

                //trigger event
                userChangeEvent?.Invoke(null, null);
            }

        }
    }
}