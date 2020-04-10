using System;
using PLFAPI.Object.Packet;
using PLFAPI.Object.Pet;
using System.Collections.Generic;
using PLFAPI.Object.User;

namespace PLFAPI.Communication.NetworkPackets.Server
{
    [Serializable()]
    public class ServerPacketSharePetList : Packet
    {

        List<PLFUser> userList;                 //shared user list

        public ServerPacketSharePetList(List<PLFUser> userList) : base(PacketType.SERVERPACKETSHAREPETLIST)
        {
            this.UserList = userList;
        }

        public List<PLFUser> UserList { get => userList; set => userList = value; }
    }
}
