using PLFAPI.Object.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PLFAPI.Helper
{
    public static class NetworkHelper
    {

        /// <summary>
        /// Gets the actual pc local machine
        /// </summary>
        /// <returns>Application local adress</returns>
        public static String GetLocalAdress()
        {
            //using socket on internetowrk target
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                //connect to anycast ip
                socket.Connect("8.8.8.8", 65530);

                //get local endpoint
                IPEndPoint localEndPoint = socket.LocalEndPoint as IPEndPoint;
                return localEndPoint.Address.ToString();
            }
        }

        /// <summary>
        /// Serializes the packet.
        /// </summary>
        /// <returns>The packet.</returns>
        /// <param name="packet">Packet.</param>
        public static byte[] SerializePacket(Packet packet)
        {
            //new instance of stream and byte formatter
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter byteFormatter = new BinaryFormatter();

            //serialize the packet
            byteFormatter.Serialize(memoryStream, packet);

            //return serialized bytes
            return memoryStream.ToArray();
        }

        /// <summary>
        /// Deserializes the packet.
        /// </summary>
        /// <returns>The packet.</returns>
        /// <param name="data">Packet Data.</param>
        public static Packet DeserializePacket(byte[] data)
        {
            //new instance of stream and byte formatter
            MemoryStream memoryStream = new MemoryStream(data);
            BinaryFormatter byteFormatter = new BinaryFormatter();

            //deserialize as packet
            Packet deserializedPacket = byteFormatter.Deserialize(memoryStream) as Packet;

            return deserializedPacket;
        }

        /// <summary>
        /// Serialize the user private key into string
        /// </summary>
        /// <param name="key">User private key</param>
        /// <returns></returns>
        public static String SerializePrivateKey(byte[] key)
        {
            return ByteTableToString(key);
        }

        /// <summary>
        /// Deserialize a string private key
        /// </summary>
        /// <param name="key">String serialized key</param>
        /// <returns></returns>
        public static byte[] DeserializePrivateKey(String key)
        {
            //create new buffer for private key
            byte[] privateKey = new byte[10];
            int i = 0;
            //foreach number convert and add to the key table
            foreach (var bit in key.Split('§'))
                privateKey[i++] = Convert.ToByte(bit);

            return privateKey;
        }

        /// <summary>
        /// Transform a byte table into a string 
        /// </summary>
        /// <param name="bytes">The byte table</param>
        /// <returns>The converted byte table</returns>
        public static String ByteTableToString(byte[] bytes)
        {
            //if table is empty
            if (bytes.Length <= 0)
                return "";

            StringBuilder stringBuilder = new StringBuilder();

            //foreach table valuer add and split with §
            for (int i = 0; i < bytes.Length - 1; i++)
                stringBuilder.Append($"{bytes[i]}§");
            stringBuilder.Append($"{bytes[bytes.Length - 1]}");

            return stringBuilder.ToString();
        }

    }
}
