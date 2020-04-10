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
    public class ClientPacketDownloadPetsID : Packet
    {

        int userID;             //owner id

        public ClientPacketDownloadPetsID(int userID) : base(PacketType.CLIENTPACKETDOWNLOADPETSID)
        {
            this.userID = userID;
        }

        public int UserID { get => userID; set => userID = value; }
    }
}
