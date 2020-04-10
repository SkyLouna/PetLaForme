using System;
using PLFAPI.Object.Packet;
using PLFAPI.Object.User;

namespace PLFAPI.Communication.NetworkPackets.Client
{
    [Serializable()]
    public class ClientPacketAskUserActivateAccout : Packet
    {

        PLFUser user;
        String userPassword;

        public ClientPacketAskUserActivateAccout(PLFUser user, String userPassword) : base(PacketType.CLIENTPACKETASKACTIVEACCOUNT)
        {
            this.user = user;
            this.userPassword = userPassword;
        }
   
        public string UserPassword { get => userPassword; set => userPassword = value; }
        public PLFUser User { get => user; set => user = value; }
    }
}
