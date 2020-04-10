using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLFServer.Object.Config
{
    public class ServerConfig
    {
        String serverIP;                    //server ip
        int serverPort;                     //server port

        public ServerConfig(String serverIP, int serverPort)
        {
            this.serverIP = serverIP;
            this.serverPort = serverPort;
        }

        public string ServerIP { get => serverIP; set => serverIP = value; }
        public int ServerPort { get => serverPort; set => serverPort = value; }
    }
}
