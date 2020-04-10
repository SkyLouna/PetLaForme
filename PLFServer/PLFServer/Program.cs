using PLFServer.Manager;

namespace PLFServer
{
    class Program
    {

        public static ServerManager serverManager;
        public static MySQLManager mySQLManager;
        public static PacketManager packetManager;
        public static MailManager mailManager;

        static void Main(string[] args)
        {
            serverManager = new ServerManager();
            mySQLManager = new MySQLManager();
            packetManager = new PacketManager();
            mailManager = new MailManager();

            serverManager.StartServer();
        }
    }
}
