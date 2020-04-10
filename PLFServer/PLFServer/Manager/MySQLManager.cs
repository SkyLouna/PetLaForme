using PLFAPI.Helper;
using PLFServer.Object.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PLFServer.Manager
{
    public class MySQLManager
    {
        MySQLConnection mySQLConnection;                    //mysql connection

        /// <summary>
        /// Create a new instance of the <see cref="T:MarshApp.Manager.MySQLManager"/> class.
        /// </summary>
        public MySQLManager()
        {
            //database login informations
            mySQLConnection = new MySQLConnection("address", "db", "user", "password :)");
            mySQLConnection.CreateConnection();

            //mysql heartbeat timer, 10secs to keep db connection alive
            Timer heartBeatTimer = new Timer(DBConnectHeartBeat, null, 0, 10000);


        }


        /// <summary>
        /// DBCs the onnect heart beat.
        /// </summary>
        /// <param name="o">O.</param>
        void DBConnectHeartBeat(System.Object o)
        {
            //wr
            ConsoleHelper.Write("DBConnect - I'm still alive, please don't kill me");
            mySQLConnection.Ping();

        }

        public MySQLConnection MySQLConnection { get => mySQLConnection; set => mySQLConnection = value; }
    }
}
