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
    public class ClientPacketDownloadPets : Packet
    {

        int userID;             //owner id

        public ClientPacketDownloadPets(int userID) : base(PacketType.CLIENTPACKETDOWNLOADPETS)
        {
            this.userID = userID;
        }

        public int UserID { get => userID; set => userID = value; }

    }
}
