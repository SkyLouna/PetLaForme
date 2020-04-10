using PLFAPI.Object.Packet;
using PLFAPI.Object.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLFAPI.Communication.NetworkPackets.Client
{
    [Serializable]
    public class ClientPacketDisableDAuth : Packet
    {

        PLFUser plfUser;
        public ClientPacketDisableDAuth(PLFUser plfUser) : base(PacketType.CLIENTPACKETDISABLEDAUTH)
        {
            this.plfUser = plfUser;
        }

        public PLFUser PlfUser { get => plfUser; set => plfUser = value; }
    }
}
