using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLFAPI.Object.Packet;

namespace PLFAPI.Communication.NetworkPackets.Client
{
    [Serializable()]
    public class ClientPacketPing : Packet
    {

        long packetSendTime;                //packet send time
        
        public ClientPacketPing(long packetSendTime) : base(PacketType.CLIENTPACKETPING)
        {
            this.packetSendTime = packetSendTime;
        }

        public long PacketSendTime { get => packetSendTime; set => packetSendTime = value; }
    }
}
