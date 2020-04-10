using System;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace PLFAPI.Object.Ext
{
    public static class ObjectExt
    {
        //------------------------------------------------------------------------------------------
        //
        //                                  BYTE EXTENDERS
        //
        //------------------------------------------------------------------------------------------

        /// <summary>
        /// Adds the length.
        /// </summary>
        /// <returns>The length.</returns>
        /// <param name="array">Array.</param>
        public static byte[] AddLength(this byte[] array)
        {
            byte[] lengthPrefix = BitConverter.GetBytes(array.Length + 4);
            //create new byte array
            byte[] newArray = new byte[lengthPrefix.Length + array.Length];

            //copy old to new
            lengthPrefix.CopyTo(newArray, 0);
            array.CopyTo(newArray, lengthPrefix.Length);

            //return new array
            return newArray;
        }

        //------------------------------------------------------------------------------------------
        //
        //                                  STRING EXTENDERS
        //
        //------------------------------------------------------------------------------------------

        /// <summary>
        /// Is a potential valid email.
        /// </summary>
        /// <returns><c>true</c>, if valid email was ised, <c>false</c> otherwise.</returns>
        /// <param name="emailAdress">Email adress.</param>
        public static Boolean IsValidEmail(this String emailAdress)
        {
            try
            {
                //create email from string and check if attribute is good
                return new MailAddress(emailAdress).Address == emailAdress;
            }
            catch
            {
                return false;
            }
        }

        public static String ToSQL(this String text)
        {
            return text.Replace("'", @"\'");
        }


        /// <summary>
        /// Hashs the SHA 256.
        /// </summary>
        /// <returns>The SHA 256.</returns>
        /// <param name="value">Value.</param>
        public static String HashSHA256(this String value)
        {
            var encodedValue = Encoding.ASCII.GetBytes(value);

            SHA256Managed sha256Managed = new SHA256Managed();

            string hashString = string.Empty;

            var hashBytes = sha256Managed.ComputeHash(encodedValue);


            foreach (byte byt in hashBytes)
            {
                hashString += String.Format("{0:x2}", byt);
            }

            return hashString;
        }


        //------------------------------------------------------------------------------------------
        //
        //                                  INTEGER EXTENDERS
        //
        //------------------------------------------------------------------------------------------

        /// <summary>
        /// Tos the negative.
        /// </summary>
        /// <returns>The negative.</returns>
        /// <param name="value">Value.</param>
        public static int ToNegative(this int value)
        {
            return value < 0 ? value : value * -1;
        }

        /// <summary>
        /// Tos the chrono hour.
        /// </summary>
        /// <returns>The chrono hour.</returns>
        /// <param name="value">Value.</param>
        public static String ToChronoHour(this int value)
        {
            if (value < 10)
                return $"0{value}";
            return $"{value}";
        }

        //------------------------------------------------------------------------------------------
        //
        //                                  DATETIME EXTENDERS
        //
        //------------------------------------------------------------------------------------------

        /// <summary>
        /// Ises the same day.
        /// </summary>
        /// <returns><c>true</c>, if same day was ised, <c>false</c> otherwise.</returns>
        /// <param name="datetime1">Datetime1.</param>
        /// <param name="datetime2">Datetime2.</param>
        public static bool IsSameDay(this DateTime datetime1, DateTime datetime2)
        {
            return datetime1.Year == datetime2.Year
                && datetime1.Month == datetime2.Month
                && datetime1.Day == datetime2.Day;
        }
    }
}

