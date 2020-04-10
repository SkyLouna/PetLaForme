using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLFAPI.Object.Packet;
using PLFAPI.Communication.NetworkPackets.Client;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFServer.Object.Packet;
using PLFAPI.Helper;

namespace PLFServer.Handler.PacketList
{
    public class PingPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            Packet pingPacket = receivedPacket as ClientPacketPing;

            ConsoleHelper.Write("Receive - ClientPacketPing");

            ServerPacketPing serverPacketPing = new ServerPacketPing(DateTime.Now.Ticks);

            ConsoleHelper.Write("Send - ServerPacketPing");

            return serverPacketPing;

        }
    }
}
