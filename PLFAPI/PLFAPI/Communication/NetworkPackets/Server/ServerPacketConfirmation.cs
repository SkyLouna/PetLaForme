using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Object.Packet;

namespace PLFAPI.Communication.NetworkPackets.Server
{
    [Serializable()]
    public class ServerPacketConfirmation : Packet
    {

        Boolean success;                                    //action success
        NetworkError.NetworkError networkError;             //network error

        public ServerPacketConfirmation(Boolean success, NetworkError.NetworkError networkError) : base(PacketType.SERVERPACKETCONFIRMATION)
        {
            this.success = success;
            this.networkError = networkError;
        }

        public bool ActionSuccess { get => success; set => success = value; }
        public NetworkError.NetworkError NetworkError { get => networkError; set => networkError = value; }
    }
}
