using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLFServer.Object.MySQL
{
    public class MySQLConnection
    {

        String strServer;           //server address
        String strDatabase;         //database name
        String strUserID;           //database login
        String strPassword;         //database password
        Boolean blnPooling;         //database pooling

        MySqlConnection mysqlConnection;    //mySQLConnection

        /// <summary>
        /// Create a new instance of the <see cref="T:MarshApp.Objects.MySQL.MySQLConnection"/> class.
        /// </summary>
        /// <param name="strServer">server address</param>
        /// <param name="strDatabase">DB name</param>
        /// <param name="strUserID">DB login</param>
        /// <param name="strPassword">DB password</param>
        /// <param name="blnPooling">DB pooling</param>
        public MySQLConnection(String strServer, String strDatabase, String strUserID, String strPassword, Boolean blnPooling = false)
        {
            this.strServer = strServer;
            this.strDatabase = strDatabase;
            this.strUserID = strUserID;
            this.strPassword = strPassword;
            this.blnPooling = blnPooling;
        }
        /// <summary>
        /// Create connection to Database
        /// </summary>
        public void CreateConnection()
        {
            try
            {
                mysqlConnection = new MySqlConnection(ConnectionString());
                mysqlConnection.Open();
                //Console.WriteLine("Connected to DB");
            }
            catch (MySqlException mysqlException)
            {
                Trace.TraceError(mysqlException.Message);
            }
        }
        /// <summary>
        /// Disconnect from Database
        /// </summary>
        public void CloseConnection()
        {
            //if connection exists
            if (mysqlConnection != null)
            {
                mysqlConnection.Close();
                //Console.WriteLine("Disconnected from DB");
            }

        }
        /// <summary>
        /// Insert query in DB
        /// </summary>
        /// <param name="strTableName">table name</param>
        /// <param name="strValue">values to insert</param>
        public void InsertQuery(String strTableName, String strValue)
        {
            MySqlCommand mscmdCommand = new MySqlCommand();
            mscmdCommand.Connection = mysqlConnection;
            mscmdCommand.CommandText = "INSERT INTO " + strTableName + " VALUES(" + strValue + ")";

            mscmdCommand.Prepare();

            mscmdCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// Delete values from DB
        /// </summary>
        /// <param name="strTableName">table name</param>
        /// <param name="strDeleteCondition">Delete condition</param>
        public void DeleteQuery(String strTableName, String strDeleteCondition)
        {
            MySqlCommand mscmdCommand = new MySqlCommand();
            mscmdCommand.Connection = mysqlConnection;
            mscmdCommand.CommandText = "DELETE FROM " + strTableName + " WHERE " + strDeleteCondition;

            mscmdCommand.Prepare();

            mscmdCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// Update values in DB
        /// </summary>
        /// <param name="strTableName">table name</param>
        /// <param name="strUpdateValues">values to update</param>
        /// <param name="strUpdateConditions">Update condition</param>
        public void UpdateQuery(String strTableName, String strUpdateValues, String strUpdateConditions)
        {
            MySqlCommand mscmdCommand = new MySqlCommand();
            mscmdCommand.Connection = mysqlConnection;
            mscmdCommand.CommandText = "UPDATE " + strTableName + " SET " + strUpdateValues + " WHERE " + strUpdateConditions;

            mscmdCommand.Prepare();

            mscmdCommand.ExecuteNonQuery();
        }

        public void Ping()
        {
            MySqlCommand mscmdCommand = new MySqlCommand();
            mscmdCommand.Connection = mysqlConnection;
            mscmdCommand.CommandText = "SELECT 1 FROM DUAL";

            mscmdCommand.Prepare();
            mscmdCommand.ExecuteNonQuery();
        }


        /// <summary>
        /// Gets the connection string
        /// </summary>
        /// <returns>The string.</returns>
        public string ConnectionString()
        {
            return "Server=" + strServer
                + ";Database=" + strDatabase
                + ";User ID=" + strUserID
                + ";Password=" + strPassword
                + ";Pooling=" + blnPooling;
        }

        //--------------------------------------------------------------------
        //
        //                          Getters and Setters
        //
        //--------------------------------------------------------------------

        public string StrServer { get => strServer; set => strServer = value; }
        public string StrDatabase { get => strDatabase; set => strDatabase = value; }
        public string StrUserID { get => strUserID; set => strUserID = value; }
        public string StrPassword { get => strPassword; set => strPassword = value; }
        public Boolean BlnPooling { get => blnPooling; set => blnPooling = value; }
        public MySqlConnection MysqlConnection { get => mysqlConnection; set => mysqlConnection = value; }
    }
}
