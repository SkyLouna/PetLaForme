using System;
using PLFAPI.Object.Packet;

namespace PLFAPI.Communication.NetworkPackets.Server
{
    [Serializable()]
    public class ServerPacketAddPet : Packet
    {

        Boolean registerSuccess;                        //success
        int petID;                                      //pet id
        NetworkError.NetworkError networkError;         //network error

        public ServerPacketAddPet(Boolean registerSuccess, int petID, NetworkError.NetworkError networkError) : base(PacketType.SERVERPACKETADDPET)
        {
            this.registerSuccess = registerSuccess;
            this.petID = petID;
            this.networkError = networkError;
        }

        public bool RegisterSuccess { get => registerSuccess; set => registerSuccess = value; }
        public int PetID { get => petID; set => petID = value; }
        public NetworkError.NetworkError NetworkError { get => networkError; set => networkError = value; }
    }
}
