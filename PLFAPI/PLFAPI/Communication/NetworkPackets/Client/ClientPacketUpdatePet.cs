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
    public class ClientPacketUpdatePet : Packet
    {

        PLFPet petProfile;              //pet profile

        public ClientPacketUpdatePet(int ownerUserID, PLFPet petProfile) : base(PacketType.CLIENTPACKETUPDATEPET)
        {
            this.petProfile = petProfile;
        }

        public PLFPet PetProfile { get => petProfile; set => petProfile = value; }
    }
}
