using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLFAPI.Object.Packet;
using PLFAPI.Object.Pet;

namespace PLFAPI.Communication.NetworkPackets.Client
{
    [Serializable()]
    public class ClientPacketSharePet : Packet
    {

        int ownerUserID;                    //owner user id
        int petID;                          //pet id
        String receiverUserNick;            //receiver nick

        int sharePower;                     //share power

        public ClientPacketSharePet(int ownerUserID, int petID, String receiverUserNick, int sharePower) : base(PacketType.CLIENTPACKETSHAREPET)
        {
            this.ownerUserID = ownerUserID;
            this.petID = petID;
            this.receiverUserNick = receiverUserNick;
            this.sharePower = sharePower;
        }

        public int OwnerUserID { get => ownerUserID; set => ownerUserID = value; }
        public int PetID { get => petID; set => petID = value; }
        public string ReceiverUserNick { get => receiverUserNick; set => receiverUserNick = value; }
        public int SharePower { get => sharePower; set => sharePower = value; }

    }
}
