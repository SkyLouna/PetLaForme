using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLFAPI.Object.Packet;

namespace PLFAPI.Communication.NetworkPackets.Client
{
    [Serializable()]
    public class ClientPacketUserLogin : Packet
    {

        String userName;                    //user nick
        String userPassword;                //user password

        public ClientPacketUserLogin(String userName, String userPassword) : base(PacketType.CLIENTPACKETUSERLOGIN)
        {
            this.userName = userName;
            this.userPassword = userPassword;
        }

        public string UserName { get => userName; set => userName = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
    }
}
