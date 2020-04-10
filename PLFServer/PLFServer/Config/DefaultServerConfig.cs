using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLFServer.Object.Config;
using PLFAPI.Helper;

namespace PLFServer.Config
{
    public class DefaultServerConfig : ServerConfig
    {
        public DefaultServerConfig(string serverIP, int serverPort) : base(serverIP, serverPort)
        {
        }

        //get local ip as default config
        public DefaultServerConfig() : base(NetworkHelper.GetLocalAdress(), 32323)
        {

        }
    }
}
