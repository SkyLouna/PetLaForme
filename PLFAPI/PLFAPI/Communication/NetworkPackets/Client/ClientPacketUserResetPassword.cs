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
    public class ClientPacketUserResetPassword : Packet
    {

        String userName;
        String newPassword;
        String code;

        public ClientPacketUserResetPassword(String userName, String newPassword, String code) : base(PacketType.CLIENTPACKETRESETPASSWORD)
        {
            this.userName = userName;
            this.newPassword = newPassword;
            this.code = code;
        }

        public string UserName { get => userName; set => userName = value; }
        public string NewPassword { get => newPassword; set => newPassword = value; }
        public string Code { get => code; set => code = value; }
    }
}
