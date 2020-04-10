using System;
using System.Collections.Generic;
using PLFAPI.Communication.NetworkPackets.Client;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Object.User;
using PLFAPI.Object.Ext;
using PLFAPI.Object.Pet;
using PetLaForme.Network;
using PLFAPI.Object.Pet.Attribute;

namespace PetLaForme.Helper
{
    public static class ServerHelper
    {

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="user">User.</param>
        /// <param name="userPassword">User password.</param>
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

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <returns>The user.</returns>
        /// <param name="userNick">User nick.</param>
        /// <param name="userPassword">User password.</param>
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

        /// <summary>
        /// Logins the user hashed.
        /// </summary>
        /// <returns>The user hashed.</returns>
        /// <param name="userNick">User nick.</param>
        /// <param name="userPassword">User hashed password.</param>
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

        /// <summary>
        /// Confirms the user account.
        /// </summary>
        /// <returns>The user account.</returns>
        /// <param name="user">User.</param>
        /// <param name="code">Code.</param>
        public static ServerPacketConfirmation ConfirmUserAccount(PLFUser user, String code)
        {
            ClientPacketUserActivateAccount clientPacketUserActivateAccount = new ClientPacketUserActivateAccount(user, code);

            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketUserActivateAccount) as ServerPacketConfirmation;

            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        /// <summary>
        /// Asks the confirm user account.
        /// </summary>
        /// <returns>The confirm user account.</returns>
        /// <param name="user">User.</param>
        /// <param name="userPassword">User password.</param>
        public static ServerPacketConfirmation AskConfirmUserAccount(PLFUser user, String userPassword)
        {
            ClientPacketAskUserActivateAccout clientPacketAskUserActivateAccout = new ClientPacketAskUserActivateAccout(user, userPassword.HashSHA256());

            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketAskUserActivateAccout) as ServerPacketConfirmation;

            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        /// <summary>
        /// Resets the user password.
        /// </summary>
        /// <returns>The user password.</returns>
        /// <param name="userName">User name.</param>
        /// <param name="userNewPassword">User new password.</param>
        /// <param name="userCode">User code.</param>
        public static ServerPacketConfirmation ResetUserPassword(String userName, String userNewPassword, String userCode)
        {
            ClientPacketUserResetPassword clientPacketUserResetPassword = new ClientPacketUserResetPassword(userName, userNewPassword.HashSHA256(), userCode);

            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketUserResetPassword) as ServerPacketConfirmation;

            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        /// <summary>
        /// Asks the reset user password.
        /// </summary>
        /// <returns>The reset user password.</returns>
        /// <param name="userName">User name.</param>
        public static ServerPacketConfirmation AskResetUserPassword(String userName)
        {
            ClientPacketUserAskResetPassword clientPacketUserAskResetPassword = new ClientPacketUserAskResetPassword(userName);

            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketUserAskResetPassword) as ServerPacketConfirmation;

            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }


        /// <summary>
        /// Updates the user profile.
        /// </summary>
        /// <returns>The user profile.</returns>
        /// <param name="user">User.</param>
        /// <param name="userPassword">User password.</param>
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

        /// <summary>
        /// Enables the user DA uth.
        /// </summary>
        /// <returns>The user DA uth.</returns>
        /// <param name="plfUser">Plf user.</param>
        /// <param name="privateKey">Private key.</param>
        public static ServerPacketConfirmation EnableUserDAuth(PLFUser plfUser, byte[] privateKey)
        {

            ClientPacketEnableDAuth clientPacketEnableDAuth = new ClientPacketEnableDAuth(plfUser, privateKey);

            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketEnableDAuth) as ServerPacketConfirmation;

            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }

        /// <summary>
        /// Disables the user DA uth.
        /// </summary>
        /// <returns>The user DA uth.</returns>
        /// <param name="plfUser">Plf user.</param>
        public static ServerPacketConfirmation DisableUserDAuth(PLFUser plfUser)
        {
            ClientPacketDisableDAuth clientPacketDisableDAuth = new ClientPacketDisableDAuth(plfUser);

            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketDisableDAuth) as ServerPacketConfirmation;

            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            return serverPacketConfirmation;
        }


        /// <summary>
        /// Adds the pet.
        /// </summary>
        /// <returns>The pet.</returns>
        /// <param name="user">User.</param>
        /// <param name="pet">Pet.</param>
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

        /// <summary>
        /// Deletes the pet.
        /// </summary>
        /// <returns>The pet.</returns>
        /// <param name="user">User.</param>
        /// <param name="pet">Pet.</param>
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

        /// <summary>
        /// Updates the pet.
        /// </summary>
        /// <returns>The pet.</returns>
        /// <param name="pet">Pet.</param>
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

        /// <summary>
        /// Shares the pet.
        /// </summary>
        /// <returns>The pet.</returns>
        /// <param name="user">User.</param>
        /// <param name="pet">Pet.</param>
        /// <param name="receiverUserName">Receiver user name.</param>
        /// <param name="sharePower">Share power.</param>
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

        /// <summary>
        /// Shares the pet list.
        /// </summary>
        /// <returns>The pet list.</returns>
        /// <param name="petID">Pet identifier.</param>
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

        /// <summary>
        /// Kills the share pet.
        /// </summary>
        /// <returns>The share pet.</returns>
        /// <param name="petID">Pet identifier.</param>
        /// <param name="userID">User identifier.</param>
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

        /// <summary>
        /// Downloads the pets.
        /// </summary>
        /// <returns>The pets.</returns>
        /// <param name="user">User.</param>
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

        /// <summary>
        /// Downloads the pets identifier.
        /// </summary>
        /// <returns>The pets identifier.</returns>
        /// <param name="user">User.</param>
        public static ServerPacketDownloadPetsID DownloadPetsID(PLFUser user)
        {
            //get user id
            int userID = user.ID;

            //create new client packet download pets id
            ClientPacketDownloadPetsID clientPacketDownloadPetsID = new ClientPacketDownloadPetsID(userID);

            //send packet to the server
            ServerPacketDownloadPetsID serverPacketDownloadPetsID = TCPClient.SendPacket(clientPacketDownloadPetsID) as ServerPacketDownloadPetsID;

            //if null answer, return vanilla packet
            if (serverPacketDownloadPetsID == null)
                return new ServerPacketDownloadPetsID(new int[0], new int[0]);

            //return packet
            return serverPacketDownloadPetsID;
        }

        /// <summary>
        /// Downloads the pet.
        /// </summary>
        /// <returns>The pet.</returns>
        /// <param name="petID">Pet identifier.</param>
        /// <param name="shared">If set to <c>true</c> shared.</param>
        public static ServerPacketDownloadPet DownloadPet(int petID, Boolean shared = false)
        {
            //create new client packet download pet
            ClientPacketDownloadPet clientPacketDownloadPet = new ClientPacketDownloadPet(petID, shared);

            //send packet to server
            ServerPacketDownloadPet serverPacketDownloadPet = TCPClient.SendPacket(clientPacketDownloadPet) as ServerPacketDownloadPet;

            //if no answer
            if (serverPacketDownloadPet == null)
                return new ServerPacketDownloadPet(null);

            //return packet
            return serverPacketDownloadPet;
        }

        /// <summary>
        /// Downloads the amount of attributs.
        /// </summary>
        /// <returns>The amount of attributs.</returns>
        /// <param name="petID">Pet identifier.</param>
        public static ServerPacketGetAmountOfAttributs DownloadAmountOfAttributs(int petID)
        {
            //create new client packet get amount of attributs
            ClientPacketGetAmountOfAttributs clientPacketGetAmountOfAttributs = new ClientPacketGetAmountOfAttributs(petID);

            //send packet to server
            ServerPacketGetAmountOfAttributs serverPacketGetAmountOfAttributs = TCPClient.SendPacket(clientPacketGetAmountOfAttributs) as ServerPacketGetAmountOfAttributs;

            //if no answer
            if (serverPacketGetAmountOfAttributs == null)
                return new ServerPacketGetAmountOfAttributs(0);

            //return packet
            return serverPacketGetAmountOfAttributs;
        }

        /// <summary>
        /// Downloads the attributs.
        /// </summary>
        /// <returns>The attributs.</returns>
        /// <param name="petID">Pet identifier.</param>
        public static ServerPacketDownloadAttributs DownloadAttributs(int petID)
        {
            //create new client packet download attributs
            ClientPacketDownloadAttributs clientPacketDownloadAttributs = new ClientPacketDownloadAttributs(petID);

            //Send packet to server
            ServerPacketDownloadAttributs serverPacketDownloadAttributs = TCPClient.SendPacket(clientPacketDownloadAttributs) as ServerPacketDownloadAttributs;

            //if no answer
            if (serverPacketDownloadAttributs == null)
                return new ServerPacketDownloadAttributs(new List<PetAttribute>());

            //return packet
            return serverPacketDownloadAttributs;
        }

        /// <summary>
        /// Downloads the attribut.
        /// </summary>
        /// <returns>The attribut.</returns>
        /// <param name="petID">Pet identifier.</param>
        /// <param name="attributID">Attribut identifier.</param>
        public static ServerPacketDownloadAttribut DownloadAttribut(int petID, int attributID)
        {
            //create new client packet download attribut
            ClientPacketDownloadAttribut clientPacketDownloadAttribut = new ClientPacketDownloadAttribut(petID, attributID);

            //send packet to server
            ServerPacketDownloadAttribut serverPacketDownloadAttribut = TCPClient.SendPacket(clientPacketDownloadAttribut) as ServerPacketDownloadAttribut;

            //if no answer
            if (serverPacketDownloadAttribut == null)
                return new ServerPacketDownloadAttribut(null);

            //return packet
            return serverPacketDownloadAttribut;
        }

        /// <summary>
        /// Adds the attribut.
        /// </summary>
        /// <returns>The attribut.</returns>
        /// <param name="petID">Pet identifier.</param>
        /// <param name="petAttribut">Pet attribut.</param>
        public static ServerPacketConfirmation AddAttribut(int petID, PetAttribute petAttribut)
        {
            //create new client packet download attribut
            ClientPacketAddAttribut clientPacketAddAttribut = new ClientPacketAddAttribut(petID, petAttribut);

            //send packet to server
            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketAddAttribut) as ServerPacketConfirmation;

            //if no answer
            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            //return packet
            return serverPacketConfirmation;
        }

        /// <summary>
        /// Deletes the attribut.
        /// </summary>
        /// <returns>The attribut.</returns>
        /// <param name="petID">Pet identifier.</param>
        /// <param name="attributID">Attribut identifier.</param>
        public static ServerPacketConfirmation DeleteAttribut(int petID, int attributID)
        {
            //create new client packet delete attribut
            ClientPacketDeleteAttribut clientPacketDeleteAttribut = new ClientPacketDeleteAttribut(petID, attributID);

            //send packet to server
            ServerPacketConfirmation serverPacketConfirmation = TCPClient.SendPacket(clientPacketDeleteAttribut) as ServerPacketConfirmation;

            //if no answer
            if (serverPacketConfirmation == null)
                return new ServerPacketConfirmation(false, NetworkError.SERVER_UNAVAILABLE);

            //return packet
            return serverPacketConfirmation;
        }
    }
}
