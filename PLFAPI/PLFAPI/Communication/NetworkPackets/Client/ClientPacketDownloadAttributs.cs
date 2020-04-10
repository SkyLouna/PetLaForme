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
    public class ClientPacketDownloadAttributs : Packet
    {

        int petID;             //owner id

        public ClientPacketDownloadAttributs(int petID) : base(PacketType.CLIENTPACKETDOWNLOADATTRIBUTS)
        {
            this.petID = petID;
        }

        public int PetID { get => petID; set => petID = value; }

    }
}
