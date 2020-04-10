using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLFAPI.Object.Packet;
using PLFAPI.Object.Pet;

namespace PLFAPI.Communication.NetworkPackets.Client
{
    [Serializable()]
    public class ClientPacketKillSharePet : Packet
    {

        int petID;                  //pet id
        int receiverUserID;         //receiver id

        public ClientPacketKillSharePet(int petID, int receiverUserID) : base(PacketType.CLIENTPACKETKILLSHAREPET)
        {
            this.petID = petID;
            this.receiverUserID = receiverUserID;
        }

        public int PetID { get => petID; set => petID = value; }
        public int ReceiverUserID { get => receiverUserID; set => receiverUserID = value; }

    }
}
