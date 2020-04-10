using System;
using PLFAPI.Object.Packet;
using PLFAPI.Object.Pet;
using System.Collections.Generic;

namespace PLFAPI.Communication.NetworkPackets.Server
{
    [Serializable()]
    public class ServerPacketDownloadPetsID : Packet
    {

        int[] idList;                 //pet list
        int[] sharedIdList;

        public ServerPacketDownloadPetsID(int[] idList, int[] sharedIdList) : base(PacketType.SERVERPACKETDOWNLOADPETSID)
        {
            this.idList = idList;
            this.sharedIdList = sharedIdList;
        }

        public int[] IdList { get => idList; set => idList = value; }
        public int[] SharedIdList { get => sharedIdList; set => sharedIdList = value; }
    }
}
