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
    public class ClientPacketUserUpdateProfile : Packet
    {

        PLFUser user;               //user profile
        String userPassword;        //user password

        public ClientPacketUserUpdateProfile(PLFUser user, String userPassword) : base(PacketType.CLIENTPACKETUSERUPDATEPROFILE)
        {
            this.user = user;
            this.userPassword = userPassword;
        }

        public PLFUser User { get => user; set => user = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
    }
}
