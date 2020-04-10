using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLFAPI.Communication.NetworkPackets.Client;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Object.User;
using PLFAPI.Object.Ext;
using PetLaFormeWin.Network;
using System.Windows.Forms;
using PLFAPI.Object.Pet;
using PLFAPI.Object.Pet.Attribute;
using PLFAPI.Helper;

namespace PetLaFormeWin.Helper
{
    public static class ServerHelper
    {

        public static ServerPacketUserRegister RegisterUser(PLFUser user, String userPassword)
        {
            //hash user password
            String hashPassword = userPassword.HashSHA256();

            //new user register packet
            ClientPacketUserRegister clientPacketUserRegister = new ClientPacketUserRegister(user, hashPassword);

            //send packet to server
            ServerPacketUserRegister serverPacketUserRegister = TCPClient.SendPacket(clientPacketUserRegister) as ServerPacketUserRegister;

            //if no answer
            if (serverPacketUserRegister == null)
                return new ServerPacketUserRegister(false, -1, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketUserRegister;
        }

        public static ServerPacketUserLogin LoginUser(String userNick, String userPassword)
        {
            //hash user password
            String hashPassword = userPassword.HashSHA256();

            //new user login packet
            ClientPacketUserLogin clientPacketUserLogin = new ClientPacketUserLogin(userNick, hashPassword);

            //send login to server
            ServerPacketUserLogin serverPacketUserLogin = TCPClient.SendPacket(clientPacketUserLogin) as ServerPacketUserLogin;

            //if no answer
            if (serverPacketUserLogin == null)
                return new ServerPacketUserLogin(NetworkError.SERVER_UNAVAILABLE, null, false, null);

            return serverPacketUserLogin;
        }

        public static ServerPacketUserLogin LoginUserHashed(String userNick, String userPassword)
        {
            //new user login packet
            ClientPacketUserLogin clientPacketUserLogin = new ClientPacketUserLogin(userNick, userPassword);

            //send login to server
            ServerPacketUserLogin serverPacketUserLogin = TCPClient.SendPacket(clientPacketUserLogin) as ServerPacketUserLogin;

            //if no answer
            if (serverPacketUserLogin == null)
                return new ServerPacketUserLogin(NetworkError.SERVER_UNAVAILABLE, null, false, null);

            return serverPacketUserLogin;
        }

        public static ServerPacketConfirmation ConfirmUserAccount(PLFUser user, String code)
        {
            ClientPacketUserActivateAccount clientPacketUserActivateAccount = new ClientPacketUserActivateAccount(user, code);

            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketUserActivateAccount) as ServerPacketConfirmation;

            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        public static ServerPacketConfirmation AskConfirmUserAccount(PLFUser user, String userPassword)
        {
            ClientPacketAskUserActivateAccout clientPacketAskUserActivateAccout = new ClientPacketAskUserActivateAccout(user, userPassword.HashSHA256());

            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketAskUserActivateAccout) as ServerPacketConfirmation;

            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        public static ServerPacketConfirmation ResetUserPassword(String userName, String userNewPassword, String userCode)
        {
            ClientPacketUserResetPassword clientPacketUserResetPassword = new ClientPacketUserResetPassword(userName, userNewPassword.HashSHA256(), userCode);

            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketUserResetPassword) as ServerPacketConfirmation;

            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        public static ServerPacketConfirmation AskResetUserPassword(String userName)
        {
            ClientPacketUserAskResetPassword clientPacketUserAskResetPassword = new ClientPacketUserAskResetPassword(userName);

            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketUserAskResetPassword) as ServerPacketConfirmation;

            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        public static ServerPacketConfirmation UpdateUserProfile(PLFUser user, String userPassword)
        {
            //hash user profile
            String hashPassword = userPassword.HashSHA256();

            //create new user update profile packet
            ClientPacketUserUpdateProfile clientPacketUserUpdateProfile = new ClientPacketUserUpdateProfile(user, hashPassword);
            
            //send update packet to server
            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketUserUpdateProfile) as ServerPacketConfirmation;

            //if no answer
            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        public static ServerPacketConfirmation EnableUserDAuth(PLFUser plfUser, byte[] privateKey)
        {

            ClientPacketEnableDAuth clientPacketEnableDAuth = new ClientPacketEnableDAuth(plfUser, privateKey);

            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketEnableDAuth) as ServerPacketConfirmation;

            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        public static ServerPacketConfirmation DisableUserDAuth(PLFUser plfUser)
        {
            ClientPacketDisableDAuth clientPacketDisableDAuth = new ClientPacketDisableDAuth(plfUser);

            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketDisableDAuth) as ServerPacketConfirmation;

            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        public static ServerPacketAddPet AddPet(PLFUser user, PLFPet pet)
        {
            //get user ID
            int userID = user.ID;

            //create new client add pet packet
            ClientPacketAddPet clientPacketAddPet = new ClientPacketAddPet(userID, pet);

            //send packet to server
            ServerPacketAddPet serverPacketAddPet = TCPClient.SendPacket(clientPacketAddPet) as ServerPacketAddPet;

            //if no answer
            if (serverPacketAddPet == null)
                return new ServerPacketAddPet(false, -1, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketAddPet;
        }

        public static ServerPacketConfirmation DeletePet(PLFUser user, PLFPet pet)
        {
            //get user and pet id
            int userID = user.ID;
            int petID = pet.PetID;

            //new client delete pet
            ClientPacketDeletePet clientPacketDeletePet = new ClientPacketDeletePet(userID, petID);

            //send delete packet to the server
            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketDeletePet) as ServerPacketConfirmation;

            //if no answer
            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;

        }

        public static ServerPacketConfirmation UpdatePet(PLFPet pet)
        {
            //create new client packet update pet
            ClientPacketUpdatePet clientPacketUpdatePet = new ClientPacketUpdatePet(0, pet);

            //send packet to the server
            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketUpdatePet) as ServerPacketConfirmation;

            //if no answer
            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        public static ServerPacketConfirmation SharePet(PLFUser user, PLFPet pet, String receiverUserName, int sharePower)
        {
            //get user id
            int userID = user.ID;

            //create new packet share pet
            ClientPacketSharePet clientPacketSharePet = new ClientPacketSharePet(userID, pet.PetID, receiverUserName, sharePower);

            //send packet to the server
            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketSharePet) as ServerPacketConfirmation;

            //if no answer
            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        public static ServerPacketSharePetList SharePetList(int petID)
        {
            //create new packet share pet list
            ClientPacketSharePetList clientPacketSharePetList = new ClientPacketSharePetList(petID);

            //send packet to server
            ServerPacketSharePetList serverPacketSharePetList = TCPClient.SendPacket(clientPacketSharePetList) as ServerPacketSharePetList;

            //if no answer
            if (serverPacketSharePetList == null)
                return new ServerPacketSharePetList(new List<PLFUser>());

            return serverPacketSharePetList;
        }

        public static ServerPacketConfirmation KillSharePet(int petID, int userID)
        {
            //create new packet kill share pet
            ClientPacketKillSharePet clientPacketKillSharePet = new ClientPacketKillSharePet(petID, userID);

            //send packet to server
            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketKillSharePet) as ServerPacketConfirmation;

            //if no answer
            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        public static ServerPacketDownloadPets DownloadPets(PLFUser user)
        {
            //get user id
            int userID = user.ID;

            //create new packet download pets
            ClientPacketDownloadPets clientPacketDownloadPets = new ClientPacketDownloadPets(userID);

            //send packet to server
            ServerPacketDownloadPets serverPacketDownloadPets = TCPClient.SendPacket(clientPacketDownloadPets) as ServerPacketDownloadPets;

            //if no answer
            if (serverPacketDownloadPets == null)
                return new ServerPacketDownloadPets(new List<PLFPet>());

            return serverPacketDownloadPets;
        }

        public static ServerPacketDownloadPetsID DownloadPetsID(PLFUser user)
        {
            int userID = user.ID;

            ClientPacketDownloadPetsID clientPacketDownloadPetsID = new ClientPacketDownloadPetsID(userID);

            ServerPacketDownloadPetsID serverPacketDownloadPetsID = TCPClient.SendPacket(clientPacketDownloadPetsID) as ServerPacketDownloadPetsID;

            if (serverPacketDownloadPetsID == null)
                return new ServerPacketDownloadPetsID(new int[0], new int[0]);

            return serverPacketDownloadPetsID;
        }

        public static ServerPacketDownloadPet DownloadPet(int petID, Boolean shared = false)
        {
            ClientPacketDownloadPet clientPacketDownloadPet = new ClientPacketDownloadPet(petID, shared);

            ServerPacketDownloadPet serverPacketDownloadPet = TCPClient.SendPacket(clientPacketDownloadPet) as ServerPacketDownloadPet;

            if (serverPacketDownloadPet == null)
                return new ServerPacketDownloadPet(null);

            return serverPacketDownloadPet;
        }

        public static ServerPacketGetAmountOfAttributs DownloadAmountOfAttributs(int petID)
        {
            ClientPacketGetAmountOfAttributs clientPacketGetAmountOfAttributs = new ClientPacketGetAmountOfAttributs(petID);

            ServerPacketGetAmountOfAttributs serverPacketGetAmountOfAttributs = TCPClient.SendPacket(clientPacketGetAmountOfAttributs) as ServerPacketGetAmountOfAttributs;

            if (serverPacketGetAmountOfAttributs == null)
                return new ServerPacketGetAmountOfAttributs(0);

            return serverPacketGetAmountOfAttributs;
        }

        public static ServerPacketDownloadAttributs DownloadAttributs(int petID)
        {
            ClientPacketDownloadAttributs clientPacketDownloadAttributs = new ClientPacketDownloadAttributs(petID);

            ServerPacketDownloadAttributs serverPacketDownloadAttributs = TCPClient.SendPacket(clientPacketDownloadAttributs) as ServerPacketDownloadAttributs;

            if (serverPacketDownloadAttributs == null)
                return new ServerPacketDownloadAttributs(new List<PetAttribute>());

            return serverPacketDownloadAttributs;
        }

        public static ServerPacketDownloadAttribut DownloadAttribut(int petID, int attributID)
        {
            ClientPacketDownloadAttribut clientPacketDownloadAttribut = new ClientPacketDownloadAttribut(petID, attributID);

            ServerPacketDownloadAttribut serverPacketDownloadAttribut = TCPClient.SendPacket(clientPacketDownloadAttribut) as ServerPacketDownloadAttribut;

            if (serverPacketDownloadAttribut == null)
                return new ServerPacketDownloadAttribut(null);

            return serverPacketDownloadAttribut;
        }

        public static ServerPacketConfirmation AddAttribut(int petID, PetAttribute petAttribut)
        {
            ClientPacketAddAttribut clientPacketAddAttribut = new ClientPacketAddAttribut(petID, petAttribut);

            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketAddAttribut) as ServerPacketConfirmation;

            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        public static ServerPacketConfirmation DeleteAttribut(int petID, int attributID)
        {
            ClientPacketDeleteAttribut clientPacketDeleteAttribut = new ClientPacketDeleteAttribut(petID, attributID);

            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketDeleteAttribut) as ServerPacketConfirmation;

            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }
    }
}
