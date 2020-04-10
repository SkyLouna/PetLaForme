using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLFServer.Object.Config;
using PLFServer.Server;
using PLFServer.Config;

namespace PLFServer.Manager
{ 
    public class ServerManager
    {

        ServerConfig serverConfig;

        readonly TCPServer mainServer;

        public ServerManager()
        {
            serverConfig = new DefaultServerConfig();

            mainServer = new TCPServer(serverConfig.ServerIP, serverConfig.ServerPort);
        }

        public void StartServer()
        {
            mainServer.Start();
        }

        public ServerConfig ServerConfig { get => serverConfig; set => serverConfig = value; }
        public TCPServer MainServer { get => mainServer;}
    }
}
