using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using PLFAPI.Helper;
using PLFAPI.Object.Packet;
using PLFAPI.Communication.NetworkPackets.Client;
using PLFAPI.Communication.NetworkPackets.Server;
using Newtonsoft.Json;
using PLFAPI.Object.User;

namespace PLFClient
{
    class Program
    {
        const string SERVERIP = "172.16.30.172";
            //"192.168.1.128";
        const int SERVERPORT = 32323;

        static void Main(string[] args)
        {
            while (true)
            {
         
                String typed = Console.ReadLine();
                //if ping query
                if (typed == "ping")
                {
                    long actualTime = DateTime.UtcNow.Ticks;
                    ClientPacketPing clientPing = new ClientPacketPing(actualTime);

                    Packet answer = SendPacket(NetworkHelper.SerializePacket(clientPing));

                    Console.WriteLine("Answer:" + answer);

                    ServerPacketPing serverPing = answer as ServerPacketPing;

                    if (serverPing == null)
                        break;

                    Console.WriteLine("Packet infos: " + serverPing.PacketSendTime);
                    long answerTime = serverPing.PacketSendTime;
                    Console.WriteLine("Ping : " + ((answerTime - actualTime) / 1000) + " ticks");
                }

                if (typed == "user")
                {
                    PLFUser newUser = new PLFUser();
                    newUser.UserNickName = "UserTest";
                    newUser.UserName = "UserTest Name";
                    newUser.UserSurname = "UserTest Surname";
                    newUser.UserEMail = "UserTest@tst.test";

                    ClientPacketUserRegister clientPacketUserRegister = new ClientPacketUserRegister(newUser, "mdp");

                    Packet answer = SendPacket(NetworkHelper.SerializePacket(clientPacketUserRegister));

                    Console.WriteLine("Answer:" + answer);

                    ServerPacketUserRegister serverPacketUserRegister = answer as ServerPacketUserRegister;

                    if (serverPacketUserRegister == null)
                        break;


                    int userID = serverPacketUserRegister.UserID;
                    Console.WriteLine(
                        $"Register: {serverPacketUserRegister.RegisterSuccess} - {userID} - {serverPacketUserRegister.ErrorMessage}");
                }

                System.Threading.Thread.Sleep(1000);
                Console.ReadKey();
                Console.Clear();
            }


        }

        public static Packet SendPacket(byte[] packet)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();

                tcpclnt.Connect(SERVERIP, SERVERPORT);

                Console.WriteLine("Connected\n");

                Stream stm = tcpclnt.GetStream();

                stm.Write(packet, 0, packet.Length);

                byte[] receiveBuffer = new byte[3072];
                int k = stm.Read(receiveBuffer, 0, 3072);

                byte[] receiveBufferComplete = new byte[k];
                for (int i = 0; i < k; i++)
                    receiveBufferComplete[i] = receiveBuffer[i];

                Packet packetAnswer = NetworkHelper.DeserializePacket(receiveBufferComplete);

                Console.WriteLine("Disconected\n");
                tcpclnt.Close();

                return packetAnswer;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
            return null;
        }

    }
}
