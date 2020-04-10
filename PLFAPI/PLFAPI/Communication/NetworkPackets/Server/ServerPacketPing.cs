using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLFAPI.Object.Packet;
using PLFAPI.Object.User;

namespace PLFAPI.Communication.NetworkPackets.Server
{
    [Serializable()]
    public class ServerPacketPing : Packet
    {

        long packetSendTime;                    //packet send time

        public ServerPacketPing(long packetSendTime) : base(PacketType.SERVERPACKETPING)
        {
            this.packetSendTime = packetSendTime;
        }

        public long PacketSendTime { get => packetSendTime; set => packetSendTime = value; }
    }
}
