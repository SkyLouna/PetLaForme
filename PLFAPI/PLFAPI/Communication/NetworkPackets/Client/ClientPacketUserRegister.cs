using System;
using PLFAPI.Object.Packet;
using PLFAPI.Object.User;

namespace PLFAPI.Communication.NetworkPackets.Client
{
    [Serializable]
    public class ClientPacketUserRegister : Packet
    {

        PLFUser user;                   //user profile
        String userPassword;            //user password

        public ClientPacketUserRegister(PLFUser user, String userPassword) : base(PacketType.CLIENTPACKETUSERREGISTER)
        {
            this.user = user;
            this.userPassword = userPassword;
        }

        public PLFUser User { get => user; set => user = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
    }
}
