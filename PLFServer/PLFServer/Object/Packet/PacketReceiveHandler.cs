namespace PLFServer.Object.Packet
{
    public abstract class PacketReceiveHandler
    {

        public abstract PLFAPI.Object.Packet.Packet OnPacketReceive(PLFAPI.Object.Packet.Packet receivedPacket);

    }
}
