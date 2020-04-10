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
    public class ClientPacketSharePetList : Packet
    {

        int petID;              //pet id

        public ClientPacketSharePetList(int petID) : base(PacketType.CLIENTPACKETSHAREPETLIST)
        {
            this.petID = petID;
        }

        public int PetID { get => petID; set => petID = value; }
    }
}
