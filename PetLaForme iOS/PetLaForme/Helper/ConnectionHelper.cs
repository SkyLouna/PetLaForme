using System;
using System.IO;
using System.Diagnostics;
using UIKit;
using System.Collections.Generic;
using Newtonsoft.Json;
using PetLaForme.Object.Connection;
using PLFAPI.Object.Ext;
using System.Xml;

namespace PetLaForme.Helper
{
    public class ConnectionHelper
    {
        const string CONNFILENAME = "ConnProf.plf";                 //connection profile file name


        /// <summary>
        /// Deletes the connection profile.
        /// </summary>
        public static void DeleteConnectionProfile()
        {
            //get documents path
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //create filename
            var fileName = Path.Combine(documents, CONNFILENAME);

            try
            {
                //delete file
                File.Delete(fileName);
            }
            catch
            {
                Console.WriteLine("Error on delete");
            }
        }

        public static void SaveConnectionProfile(String userName, String userPassword)
        {
            //create new connection profile
            ConnectionProfile connectionProfile = new ConnectionProfile(userName, userPassword.HashSHA256());

            //TODO: find wtf is going with json library
            var json = connectionProfile.UserName + "§" + connectionProfile.UserPassword;


            //get documents path
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //create filename
            var fileName = Path.Combine(documents, CONNFILENAME);

            try
            {
                //write text in file
                File.WriteAllText(fileName, json + "");
            }
            catch
            {
                Console.WriteLine("Error on write");
            }
        }

        /// <summary>
        /// Gets the reservations.
        /// </summary>
        /// <returns>The reservations.</returns>
        public static ConnectionProfile GetConnectionProfile()
        {
            //get documents path
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //create filename
            var fileName = Path.Combine(documents, CONNFILENAME);


            //if file doesn't exist
            if (!File.Exists(fileName))
                return null;

            var json = File.ReadAllText(fileName);

            try
            {
                //return readed connection profile
                return new ConnectionProfile(json.Split('§')[0], json.Split('§')[1]);
            }
            catch
            {
                return null;
            }
        }
    }
}
