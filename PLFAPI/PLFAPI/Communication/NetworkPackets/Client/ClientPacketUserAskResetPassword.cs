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
    public class ClientPacketUserAskResetPassword : Packet
    {

        String userName;

        public ClientPacketUserAskResetPassword(String userName) : base(PacketType.CLIENTPACKETASKRESETPASSWORD)
        {
            this.userName = userName;

        }

        public string UserName { get => userName; set => userName = value; }

    }
}
