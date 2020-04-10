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
    public class ClientPacketAddPet : Packet
    {

        int ownerUserID;                //owner ID
        PLFPet newPet;                  //pet

        public ClientPacketAddPet(int ownerUserID, PLFPet newPet) : base(PacketType.CLIENTPACKETADDPET)
        {
            this.ownerUserID = ownerUserID;
            this.newPet = newPet;
        }

        public int OwnerUserID { get => ownerUserID; set => ownerUserID = value; }
        public PLFPet NewPet { get => newPet; set => newPet = value; }
    }
}
