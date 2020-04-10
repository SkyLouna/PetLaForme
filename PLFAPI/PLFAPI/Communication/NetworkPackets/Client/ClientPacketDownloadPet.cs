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
    public class ClientPacketDownloadPet : Packet
    {

        int petID;             //pet id
        Boolean shared;

        public ClientPacketDownloadPet(int petID, Boolean shared) : base(PacketType.CLIENTPACKETDOWNLOADPET)
        {
            this.petID = petID;
            this.shared = shared;
        }

        public int PetID { get => petID; set => petID = value; }
        public bool Shared { get => shared; set => shared = value; }

    }
}
