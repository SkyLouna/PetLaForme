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
    public class ClientPacketDownloadAttribut : Packet
    {

        int petID;             //owner id
        int attributID;

        public ClientPacketDownloadAttribut(int petID, int attributID) : base(PacketType.CLIENTPACKETDOWNLOADATTRIBUT)
        {
            this.petID = petID;
            this.attributID = attributID;
        }

        public int PetID { get => petID; set => petID = value; }
        public int AttributID { get => attributID; set => attributID = value; }
    }
}
