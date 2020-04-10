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
    public class ClientPacketDeletePet : Packet
    {

        int userID;             //owner id
        int petID;              //pet id

        public ClientPacketDeletePet(int userID, int petID) : base(PacketType.CLIENTPACKETDELETEPET)
        {
            this.userID = userID;
            this.petID = petID;
        }

        public int UserID { get => userID; set => userID = value; }
        public int PetID { get => petID; set => petID = value; }
    }
}
