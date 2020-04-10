using System;
using PLFAPI.Object.Packet;

namespace PLFAPI.Communication.NetworkPackets.Client
{
    [Serializable()]
    public class ClientPacketDeleteAttribut : Packet
    {

        int petID;             //owner id
        int attributID;

        public ClientPacketDeleteAttribut(int petID, int attributID) : base(PacketType.CLIENTPACKETDELETEATTRIBUT)
        {
            this.petID = petID;
            this.attributID = attributID;
        }

        public int PetID { get => petID; set => petID = value; }
        public int AttributID { get => attributID; set => attributID = value; }
    }
}
