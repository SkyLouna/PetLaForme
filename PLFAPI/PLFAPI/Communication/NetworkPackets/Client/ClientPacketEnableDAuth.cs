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
    public class ClientPacketEnableDAuth : Packet
    {

        PLFUser plfUser;
        byte[] userPrivateKey;

        public ClientPacketEnableDAuth(PLFUser plfUser, byte[] userPrivateKey) : base(PacketType.CLIENTPACKETENABLEDAUTH)
        {
            this.plfUser = plfUser;
            this.userPrivateKey = userPrivateKey;

        }

        public PLFUser PlfUser { get => plfUser; set => plfUser = value; }
        public byte[] UserPrivateKey { get => userPrivateKey; set => userPrivateKey = value; }
    }
}
