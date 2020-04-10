using MySql.Data.MySqlClient;
using PLFAPI.Object.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLFServer
{
    public static class SQLHelper
    {
        public static List<int> GetIDList(String query, int column)
        {
            //new id list
            List<int> idList = new List<int>();

            //download id list command
            MySqlCommand downloadIDList = new MySqlCommand();
            downloadIDList.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            downloadIDList.CommandText = query;

            MySqlDataReader mysqlDataReader = null;

            try
            {
                //execute reader
                mysqlDataReader = downloadIDList.ExecuteReader();

                //open reader
                while (mysqlDataReader.Read())
                    idList.Add(mysqlDataReader.GetInt32(column));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //close reader
            if (mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            return idList;
        }

        public static Dictionary<int, int> GetPetSharePower(List<int> petIDList)
        {
            //new dictionary with pet share power
            Dictionary<int, int> petSharePower = new Dictionary<int, int>();

            //if empty pet id list
            if (petIDList.Count <= 0)
                return petSharePower;

            //download share power 
            MySqlCommand downloadSharePowerCommand = new MySqlCommand();
            downloadSharePowerCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            downloadSharePowerCommand.CommandText = $"SELECT * FROM `T_Share` WHERE `fkPetID` IN ({IntListToString(petIDList)})";

            MySqlDataReader mysqlDataReader = null;

            try
            {
                //execute reader
                mysqlDataReader = downloadSharePowerCommand.ExecuteReader();

                //open reader
                while (mysqlDataReader.Read())
                    petSharePower.Add(mysqlDataReader.GetInt32(1), mysqlDataReader.GetInt32(3));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //close reader
            if (mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            return petSharePower;
        }

        public static int GetUserID(String userNick)
        {
            int userID = -1;

            //download user profile command
            MySqlCommand downloadUserProfileCommand = new MySqlCommand();
            downloadUserProfileCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            downloadUserProfileCommand.CommandText = $"SELECT * FROM `T_User` WHERE userNick='{userNick}'";

            MySqlDataReader mysqlDataReader = null;

            try
            {
                //execute reader
                mysqlDataReader = downloadUserProfileCommand.ExecuteReader();

                //open reader
                while (mysqlDataReader.Read())
                    userID = mysqlDataReader.GetInt32(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Close reader
            if (mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            return userID;
        }

        public static PLFUser GetUserProfile(String userNick)
        {
            //get user profile command
            MySqlCommand downloadUserProfileCommand = new MySqlCommand();
            downloadUserProfileCommand.Connection = Program.mySQLManager.MySQLConnection.MysqlConnection;
            downloadUserProfileCommand.CommandText = $"SELECT * FROM `T_User` WHERE userNick='{userNick}'";

            MySqlDataReader mysqlDataReader = null;

            PLFUser user = null;

            try
            {
                //execute reader
                mysqlDataReader = downloadUserProfileCommand.ExecuteReader();

                //open reader
                while (mysqlDataReader.Read())
                    user = new PLFUser(mysqlDataReader.GetInt32(0), mysqlDataReader.GetString(2), mysqlDataReader.GetString(3), mysqlDataReader.GetString(4), mysqlDataReader.GetString(5));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            //Close reader
            if (mysqlDataReader != null && !mysqlDataReader.IsClosed)
                mysqlDataReader.Close();

            return user;
        }

        public static String IntListToString(List<int> intLST)
        {
            //if empty list
            if (intLST.Count <= 0)
                return "";

            StringBuilder stringBuilder = new StringBuilder();

            //Append int to string with '', separator
            for (int i = 0; i < intLST.Count - 1; i++)
                stringBuilder.Append($"'{intLST[i]}',");
            stringBuilder.Append($"'{intLST[intLST.Count - 1]}'");

            return stringBuilder.ToString();
        }
    }
}
