using System;

namespace PLFAPI.Object.Packet
{
    [Serializable]
    public abstract class Packet
    {
        PacketType packetType;                      //packet type

        public Packet(PacketType packetType)
        {
            //set local type
            this.packetType = packetType;
        }

		public PacketType PacketType { get => packetType; set => packetType = value; }
    }
}
