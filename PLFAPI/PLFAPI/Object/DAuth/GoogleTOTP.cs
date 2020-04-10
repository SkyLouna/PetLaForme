using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PLFAPI.Object.DAuth
{

    /*
     * 
     * AUTHOR: esp0
     * LINK: https://github.com/esp0/googleAuthNet
     * COMMENTS: tranava
     * 
     */
    public class GoogleTOTP
    {
        RNGCryptoServiceProvider rnd;                                                                                           //RND Provider
        protected string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";                //free chars

        private int intervalLength;                                                                                             //code refresh interval (30s)
        private int pinCodeLength;                                                                                              //code length
        private int pinModulo;                                                                                                  //code modulo

        private byte[] randomBytes = new byte[10];                                                                              //user private key

        public GoogleTOTP(byte[] privateKey)
        {
            //new instance of rng provider
            rnd = new RNGCryptoServiceProvider();
                
            //set length to 6 chars
            pinCodeLength = 6;     
            //set refresh to 30 sec
            intervalLength = 30;
            //calculate pin modulo
            pinModulo = (int)Math.Pow(10, pinCodeLength);

            randomBytes = privateKey;
        }

        public GoogleTOTP()
        {
            //new instance of rng provider
            rnd = new RNGCryptoServiceProvider();

            //set length to 6 chars
            pinCodeLength = 6;
            //set refresh to 30 sec
            intervalLength = 30;
            //calculate pin modulo
            pinModulo = (int)Math.Pow(10, pinCodeLength);

            //get random key bytes
            rnd.GetBytes(randomBytes);
        }

        public byte[] getPrivateKey()
        {
            return randomBytes;
        }

        /// <summary>
        /// Generates a PIN of desired length when given a challenge (counter)
        /// </summary>
        /// <param name="challenge">Counter to calculate hash</param>
        /// <returns>Desired length PIN</returns>
        private String generateResponseCode(long challenge, byte[] randomBytes)
        {
            //create hmacsha1 instance and init
            HMACSHA1 myHmac = new HMACSHA1(randomBytes);
            myHmac.Initialize();

            //convert interval to bytes
            byte[] value = BitConverter.GetBytes(challenge);
            Array.Reverse(value); //reverses the challenge array due to differences in c# vs java
            myHmac.ComputeHash(value);

            //Get hash
            byte[] hash = myHmac.Hash;
            int offset = hash[hash.Length - 1] & 0xF;
            byte[] selectedFourBytes = new byte[4];
            //selected bytes are actually reversed due to c# again, thus the weird stuff here
            selectedFourBytes[0] = hash[offset];
            selectedFourBytes[1] = hash[offset + 1];
            selectedFourBytes[2] = hash[offset + 2];
            selectedFourBytes[3] = hash[offset + 3];
            Array.Reverse(selectedFourBytes);
            int finalInt = BitConverter.ToInt32(selectedFourBytes, 0);
            int truncatedHash = finalInt & 0x7FFFFFFF; //remove the most significant bit for interoperability as per HMAC standards
            int pinValue = truncatedHash % pinModulo; //generate 10^d digits where d is the number of digits
            return padOutput(pinValue);
        }

        /// <summary>
        /// Gets current interval number since Unix Epoch based on given interval length
        /// </summary>
        /// <returns>Current interval number</returns>
        public long getCurrentInterval()
        {
            TimeSpan TS = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long currentTimeSeconds = (long)Math.Floor(TS.TotalSeconds);
            long currentInterval = currentTimeSeconds / intervalLength; // 30 Seconds
            return currentInterval;
        }

        /// <summary>
        /// Pads the output string with leading zeroes just in case the result is less than the length of desired digits
        /// </summary>
        /// <param name="value">Value to pad</param>
        /// <returns>Padded Result</returns>
        private String padOutput(int value)
        {
            String result = value.ToString();
            for (int i = result.Length; i < pinCodeLength; i++)
                result = "0" + result;
            return result;
        }

        /// <summary>
        /// This is a different Url Encode implementation since the default .NET one outputs the percent encoding in lower case.
        /// While this is not a problem with the percent encoding spec, it is used in upper case throughout OAuth
        /// </summary>
        /// <param name="value">The value to Url encode</param>
        /// <returns>Returns a Url encoded string</returns>
        protected string UrlEncode(string value)
        {
            StringBuilder result = new StringBuilder();

            foreach (char symbol in value)
                if (unreservedChars.IndexOf(symbol) != -1)
                    result.Append(symbol);
                else
                    result.Append('%' + String.Format("{0:X2}", (int)symbol));

            return result.ToString();
        }

        public Image GenerateImage(int width, int height, string email)
        {

            var url = GetURL(width, height, email);

            //create new web client and download image
            WebClient wc = new WebClient();
            var data = wc.DownloadData(url);

            //open memory stream to downloaded data
            using (var imageStream = new MemoryStream(data))
            {
                //create new image
                return new Bitmap(imageStream);
            }
        }

        /// <summary>
        /// Get the page wich contains the automatic generate QR code 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public String GetURL(int width, int height, String email)
        {
            //create random base32 url-part using user private key
            string randomString = CreativeCommons.Transcoder.Base32Encode(randomBytes);
            //generate otpauth url using user email param and privateKey
            string provisionUrl = UrlEncode(String.Format("otpauth://totp/{0}?secret={1}", $"PetLaForme:{email}", randomString));
            //get image url 
            return String.Format("http://chart.apis.google.com/chart?cht=qr&chs={0}x{1}&chl={2}", width, height, provisionUrl);
        }

        public string GeneratePin()
        {
            return generateResponseCode(getCurrentInterval(), randomBytes);
        }

    }
}
