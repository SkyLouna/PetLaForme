using System;
using PLFAPI.Object.Packet;

namespace PLFAPI.Communication.NetworkPackets.Server
{
    [Serializable]
    public class ServerPacketUserRegister : Packet
    {

        Boolean registerSuccess;                                    //register success
        int userID;                                                 //user id
        NetworkError.NetworkError networkError;                     //network error

        public ServerPacketUserRegister(Boolean registerSuccess, int userID, NetworkError.NetworkError networkError) 
            : base(PacketType.SERVERPACKETUSERREGISTER)
        {
            this.registerSuccess = registerSuccess;
            this.userID = userID;
            this.networkError = networkError;
        }

        public bool RegisterSuccess { get => registerSuccess; set => registerSuccess = value; }
        public int UserID { get => userID; set => userID = value; }
        public NetworkError.NetworkError NetworkError { get => networkError; set => networkError = value; }
    }
}
