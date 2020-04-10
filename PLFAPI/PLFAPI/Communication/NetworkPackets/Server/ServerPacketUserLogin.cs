using System;
using PLFAPI.Object.User;
using PLFAPI.Object.Packet;

namespace PLFAPI.Communication.NetworkPackets.Server
{
    [Serializable()]
    public class ServerPacketUserLogin : Packet
    {
        NetworkError.NetworkError networkError;                     //network error
        PLFUser userProfile;                                        //user profile
        Boolean userAccountActivate;
        byte[] userDAuthPrivateKey;

        public ServerPacketUserLogin(NetworkError.NetworkError networkError, PLFUser userProfile, Boolean userAccountActivate, byte[] userDAuthPrivateKey) : base(PacketType.SERVERPACKETUSERLOGIN)
        {
            this.networkError = networkError;
            this.userProfile = userProfile;
            this.userAccountActivate = userAccountActivate;
            this.userDAuthPrivateKey = userDAuthPrivateKey;
        }

        public NetworkError.NetworkError NetworkError { get => networkError; set => networkError = value; }
        public PLFUser UserProfile { get => userProfile; set => userProfile = value; }
        public bool UserAccountActivate { get => userAccountActivate; set => userAccountActivate = value; }
        public byte[] UserDAuthPrivateKey { get => userDAuthPrivateKey; set => userDAuthPrivateKey = value; }
    }
}
