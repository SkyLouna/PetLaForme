using PLFAPI.Object.Packet;
using PLFServer.Handler.PacketList;
using PLFServer.Object.Packet;
using System.Collections.Generic;

namespace PLFServer.Manager
{
    public class PacketManager
    {
        Dictionary<PacketType, PacketReceiveHandler> packetHandlers;

        public PacketManager()
        {
            packetHandlers = new Dictionary<PacketType, PacketReceiveHandler>();

            AddHandler(PacketType.CLIENTPACKETPING, new PingPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETUSERREGISTER, new UserRegisterPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETUSERLOGIN, new UserLoginPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETACTIVEACCOUNT, new UserActivateAccountPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETASKACTIVEACCOUNT, new UserAskActivateAccountPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETRESETPASSWORD, new UserPasswordResetPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETASKRESETPASSWORD, new UserAskResetPasswordPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETUSERUPDATEPROFILE, new UserUpdateProfilePacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETENABLEDAUTH, new DAuthEnablePacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETDISABLEDAUTH, new DAuthDisablePacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETADDPET, new AddPetPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETDOWNLOADPETS, new DownloadPetsPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETDELETEPET, new DeletePetPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETUPDATEPET, new UpdatePetPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETSHAREPET, new SharePetPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETSHAREPETLIST, new PetShareListPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETKILLSHAREPET, new KillPetSharePacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETDOWNLOADPETSID, new DownloadPetsIDPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETDOWNLOADPET, new DownloadPetPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETGETAMOUNTOFATTRIBUTS, new GetAmountOfAttributsPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETDOWNLOADATTRIBUTS, new DownloadAttribusPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETDOWNLOADATTRIBUT, new DownloadAttributPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETDELETEATTRIBUT, new DeleteAttributPacketReceiveHandler());
            AddHandler(PacketType.CLIENTPACKETADDATTRIBUT, new AddAttributPacketReceiveHandler());
        }

        public void AddHandler(PacketType packetType, PacketReceiveHandler handler)
        {
            packetHandlers.Add(packetType, handler);
        }

        public Packet HandleReceivedPacket(Packet packet)
        {
            return packetHandlers[packet.PacketType].OnPacketReceive(packet);
        }
       

    }
}
