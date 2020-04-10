using PLFAPI.Helper;
using PLFAPI.Object.Packet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace PetLaForme.Network
{
    public class TCPClient
    {
        const string SERVERIP = "163.172.219.198";
        //"192.168.1.118";
        //"192.168.1.128";
        const int SERVERPORT = 32323;


        public static Packet SendPacket(Packet packet)
        {
            try
            {
                //init new tcp client
                TcpClient tcpclnt = new TcpClient();

                //connect to the server
                tcpclnt.Connect(SERVERIP, SERVERPORT);

                //get tcp stream
                Stream stm = tcpclnt.GetStream();

                //serilize packet to send
                byte[] packetBuffer = NetworkHelper.SerializePacket(packet);

                //write serialized packet
                stm.Write(packetBuffer, 0, packetBuffer.Length);

                //prepare for answer
                byte[] receiveBuffer = new byte[10240];
                int k = stm.Read(receiveBuffer, 0, 10240);

                //set the right size to received data
                byte[] receiveBufferComplete = new byte[k];
                for (int i = 0; i < k; i++)
                    receiveBufferComplete[i] = receiveBuffer[i];

                Console.WriteLine(packet.GetType().ToString() + "   -   Buffer: " + receiveBufferComplete.Length);

                //deserialize answer
                Packet packetAnswer = NetworkHelper.DeserializePacket(receiveBufferComplete);

                //close connection
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
