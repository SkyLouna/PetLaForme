using PetLaFormeWin.Object.Connection;
using PLFAPI.Object.Ext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLaFormeWin.Helper
{
    public class ConnectionHelper
    {
        const string CONNFILENAME = "ConnProf.plf";


        public static void DeleteConnectionProfile()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fileName = Path.Combine(documents, CONNFILENAME);
            try
            {
                File.Delete(fileName);
            }
            catch
            {
                Console.WriteLine("Error on delete");
            }
        }

        public static void SaveConnectionProfile(String userName, String userPassword)
        {
            ConnectionProfile connectionProfile = new ConnectionProfile(userName, userPassword.HashSHA256());

            var json = connectionProfile.UserName + "§" + connectionProfile.UserPassword;

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fileName = Path.Combine(documents, CONNFILENAME);

            try
            {
                File.WriteAllText(fileName, json + "");
            }
            catch
            {
                Console.WriteLine("Error on write");
            }
            Console.WriteLine("Saving profile: " + json);
        }

        /// <summary>
        /// Gets the reservations.
        /// </summary>
        /// <returns>The reservations.</returns>
        public static ConnectionProfile GetConnectionProfile()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fileName = Path.Combine(documents, CONNFILENAME);


            //if file doesn't exist
            if (!File.Exists(fileName))
                return null;

            var json = File.ReadAllText(fileName);

            Console.WriteLine("Readed data: " + json);

            try
            {
                return new ConnectionProfile(json.Split('§')[0], json.Split('§')[1]);
            }
            catch
            {
                return null;
            }
        }
    }
}
