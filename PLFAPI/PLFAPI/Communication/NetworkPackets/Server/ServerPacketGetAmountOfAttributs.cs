using System;
using PLFAPI.Object.Packet;
using PLFAPI.Object.Pet;
using System.Collections.Generic;
using PLFAPI.Object.Pet.Attribute;

namespace PLFAPI.Communication.NetworkPackets.Server
{
    [Serializable()]
    public class ServerPacketGetAmountOfAttributs : Packet
    {

        int size;

        public ServerPacketGetAmountOfAttributs(int size) : base(PacketType.SERVERPACKETGETAMOUNTOFATTRIBUTS)
        {
            this.size = size;
        }

        public int Size { get => size; set => size = value; }
    }
}
