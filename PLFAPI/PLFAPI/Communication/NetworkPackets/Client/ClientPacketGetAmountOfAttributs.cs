using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLFAPI.Object.Packet;
using PLFAPI.Object.User;

namespace PLFAPI.Communication.NetworkPackets.Client
{
    [Serializable()]
    public class ClientPacketGetAmountOfAttributs : Packet
    {

        int petID;             //pet id

        public ClientPacketGetAmountOfAttributs(int petID) : base(PacketType.CLIENTPACKETGETAMOUNTOFATTRIBUTS)
        {
            this.petID = petID;
        }

        public int PetID { get => petID; set => petID = value; }

    }
}
