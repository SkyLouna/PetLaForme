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
    public class ClientPacketUserActivateAccount: Packet
    {

        PLFUser user;                   //user profile
        String userCode;                //use rcode

        public ClientPacketUserActivateAccount(PLFUser user, String userCode) : base(PacketType.CLIENTPACKETACTIVEACCOUNT)
        {
            this.user = user;
            this.userCode = userCode;

        }

        public PLFUser User { get => user; set => user = value; }
        public string UserCode { get => userCode; set => userCode = value; }
    }
}
