using System;
using PLFAPI.Object.Packet;
using PLFAPI.Object.Pet.Attribute;

namespace PLFAPI.Communication.NetworkPackets.Client
{
    [Serializable()]
    public class ClientPacketAddAttribut : Packet
    {

        int petID;             //owner id
        PetAttribute petAttribute;

        public ClientPacketAddAttribut(int petID, PetAttribute petAttribute) : base(PacketType.CLIENTPACKETADDATTRIBUT)
        {
            this.petID = petID;
            this.petAttribute = petAttribute;
        }

        public int PetID { get => petID; set => petID = value; }
        public PetAttribute PetAttribute { get => petAttribute; set => petAttribute = value; }
    }
}
