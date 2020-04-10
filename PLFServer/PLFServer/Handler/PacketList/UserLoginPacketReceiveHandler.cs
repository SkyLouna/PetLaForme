using System;
using PLFAPI.Object.Packet;
using PLFAPI.Object.Ext;
using PLFAPI.Communication.NetworkPackets.Client;
using PLFAPI.Communication.NetworkPackets.Server;
using PLFServer.Object.Packet;
using MySql.Data.MySqlClient;
using PLFAPI.Object.User;
using PLFAPI.Communication.NetworkError;
using PLFAPI.Helper;
using Newtonsoft.Json;

namespace PLFServer.Handler.PacketList
{
    public class UserLoginPacketReceiveHandler : PacketReceiveHandler
    {
        public override Packet OnPacketReceive(Packet receivedPacket)
        {
            ClientPacketUserLogin clientPacketUserLogin = receivedPacket as ClientPacketUserLogin;

            ConsoleHelper.Write("Receive - ClientPacketUserLogin");

            String userNick = clientPacketUserLogin.UserName.ToSQL();
            String userPassword = clientPacketUserLogin.UserPassword.ToSQL();

            //login user db command
            MySqlCommand loginUserCommand = new MySqlCommand();
            loginUserCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            loginUserCommand.CommandText =
                $"SELECT * FROM `T_User` WHERE userNick='{userNick}' AND userPassword='{userPassword}'";

            MySqlDataReader mysqlDataReader = null;

            ServerPacketUserLogin serverPacketUserLogin;

            Boolean userAccountActive = false;

            try
            {
                mysqlDataReader = loginUserCommand.ExecuteReader();

                PLFUser user = null;

                //open reader
                while (mysqlDataReader.Read())
                {
                    user = new PLFUser(mysqlDataReader.GetInt32(0), mysqlDataReader.GetString(2), mysqlDataReader.GetString(3), mysqlDataReader.GetString(4), mysqlDataReader.GetString(5));
                    userAccountActive = mysqlDataReader.GetBoolean(6);
                }

                mysqlDataReader.Close();

                if (user != null)
                {
                    //login user db command
                    MySqlCommand getUserDAuthKeyCommand = new MySqlCommand();
                    getUserDAuthKeyCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
                    getUserDAuthKeyCommand.CommandText =
                        $"SELECT * FROM `T_DoubleAuth` WHERE `daUserID`='{user.ID}'";

                    mysqlDataReader = getUserDAuthKeyCommand.ExecuteReader();

                    String userKey = "null";

                    while (mysqlDataReader.Read())
                        userKey = mysqlDataReader.GetString(1);


                    serverPacketUserLogin = new ServerPacketUserLogin(NetworkError.NONE, user, userAccountActive, userKey == null ? null: JsonConvert.DeserializeObject<byte[]>(userKey));
                }
                else
                    serverPacketUserLogin = new ServerPacketUserLogin(NetworkError.SQL_USER_UNKNOWN, null, false, null);

            }
            catch(Exception e)
            {
                serverPacketUserLogin = new ServerPacketUserLogin(NetworkError.GLOBAL_UNKNOWN, null, false, null);
                Console.WriteLine(e.Message);
            }

            if(mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            ConsoleHelper.Write("Send - ServerPacketUserLogin");



            return serverPacketUserLogin;

        }
    }
}
