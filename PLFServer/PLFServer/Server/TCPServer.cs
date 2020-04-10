using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using PLFAPI.Helper;
using PLFAPI.Object.Packet;
using System.Collections.Generic;

namespace PLFServer.Server
{
    public class TCPServer
    {

        String serverIP;
        IPAddress serverAdress;
        int serverPort;

        ServerState serverState;

        TcpListener tcpListener;

        Socket socket;

        public TCPServer(String serverIP, int serverPort)
        {
            this.serverIP = serverIP;
            this.serverPort = serverPort;

            this.serverState = ServerState.STOPPED;
            
        }

        public void Start()
        {
            serverState = ServerState.LAUNCHING;

            //parse server ip
            serverAdress = IPAddress.Parse(serverIP);

            ConsoleHelper.Write($"Launching server on endpoint {serverIP}:{serverPort}");

            StartListening();

            AcceptConnection();
        }

        public void Stop()
        {
            serverState = ServerState.STOPPED;
        }

        public void StartListening()
        {
            serverState = ServerState.RUNNING;

            //init new TCP listener
            tcpListener = new TcpListener(serverAdress, serverPort);

            tcpListener.Start();
        }

        public void AcceptConnection()
        {
            serverState = ServerState.RUNNING;
            socket = tcpListener.AcceptSocket();
            AcceptPacket();
        }

        public void AcceptPacket()
        {
            ConsoleHelper.Write("Accept packet");
            serverState = ServerState.BUSY;

            byte[] receiveBuffer = new byte[10240];

            //receive data
            int k = socket.Receive(receiveBuffer);

            //create a table with correct size ^^ 
            byte[] receiveBufferComplete = new byte[k];
            for (int i = 0; i < k; i++)
                receiveBufferComplete[i] = receiveBuffer[i];

            //decode received date
            String receivedData = UTF8Encoding.UTF8.GetString(receiveBufferComplete);

            Packet receivedPacket = NetworkHelper.DeserializePacket(receiveBufferComplete);

            //get renturn packet
            Packet returnPacket = Program.packetManager.HandleReceivedPacket(receivedPacket);

            //encode packet and send
            UTF8Encoding utf8Encoding = new UTF8Encoding();
            Console.WriteLine("Buffer: " + NetworkHelper.SerializePacket(returnPacket).Length);
            socket.Send(NetworkHelper.SerializePacket(returnPacket));

            //close socket and accept new connection
            socket.Close();
            AcceptConnection();
        }
    }
}
