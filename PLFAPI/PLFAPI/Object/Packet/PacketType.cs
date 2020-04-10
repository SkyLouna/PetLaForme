using System;
namespace PLFAPI.Object.Packet
{
    public enum PacketType
    {
        CLIENTPACKETPING, SERVERPACKETPING,                                             //PING PACKETS
        CLIENTPACKETUSERLOGIN, SERVERPACKETUSERLOGIN,                                   //LOGIN PACKETS
        CLIENTPACKETUSERREGISTER, SERVERPACKETUSERREGISTER,                             //REGISTER PACKETS
        CLIENTPACKETACTIVEACCOUNT,                                                      //ACCOUNT ACTIVATION PACKET
        CLIENTPACKETASKACTIVEACCOUNT,                                                   //ASK FOR ACCOUNT ACTIVATION PACKET
        CLIENTPACKETASKRESETPASSWORD,                                                   //CLIENT ASK FOR RESET PASSWORD PACKET
        CLIENTPACKETRESETPASSWORD,                                                      //CLIENT RESET PASSWORD PACKET
        CLIENTPACKETUSERUPDATEPROFILE,                                                  //UPDATE PROFILE PACKET
        CLIENTPACKETENABLEDAUTH,                                                        //D-AUTH ENABLE PACKET
        CLIENTPACKETDISABLEDAUTH,                                                       //D-AUTH DISABLE PACKET
        CLIENTPACKETDOWNLOADPETS, SERVERPACKETDOWNLOADPETS,                             //DOWNLOAD PETS PACKETS
        CLIENTPACKETDOWNLOADPETSID, SERVERPACKETDOWNLOADPETSID,                         //DOWNLOAD PETS ID PACKETS
        CLIENTPACKETDOWNLOADPET, SERVERPACKETDOWNLOADPET,                               //DOWNLOAD PET PACKETS
        CLIENTPACKETDOWNLOADATTRIBUT, SERVERPACKETDOWNLOADATTRIBUT,                     //DOWNLOAD ATTRIBUT PACKETS
        CLIENTPACKETDOWNLOADATTRIBUTS, SERVERPACKETDOWNLOADATTRIBUTS,                   //DOWNLOAD ATTRIBUT PACKETS
        CLIENTPACKETGETAMOUNTOFATTRIBUTS, SERVERPACKETGETAMOUNTOFATTRIBUTS,             //GET AMOUNT OF ATTRIBUTS PACKET
        CLIENTPACKETDELETEATTRIBUT,                                                     //DELETE ATTRIBUT PACKET
        CLIENTPACKETADDATTRIBUT,                                                        //ADD ATTRIBUT PACKET
        CLIENTPACKETADDPET, SERVERPACKETADDPET,                                         //ADD PET PACKETS
        CLIENTPACKETDELETEPET, SERVERPACKETDELETEPET,                                   //DELETE PET PACKETS
        CLIENTPACKETUPDATEPET,                                                          //UPDATE PET PACKET
        CLIENTPACKETUPDATEATTRIBUTES,                                                   //UPDATE ATTRIBUTES PACKET
        SERVERPACKETCONFIRMATION,                                                       //CONFIRMATION PACKET
        CLIENTPACKETSHAREPET,                                                           //SHARE PET PACKET
        CLIENTPACKETSHAREPETLIST, SERVERPACKETSHAREPETLIST,                             //SHARE PET LIST PACKETS
        CLIENTPACKETKILLSHAREPET                                                        //KILL SHARE PET PACKET
    }

}
