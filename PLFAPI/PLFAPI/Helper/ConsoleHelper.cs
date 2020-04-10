using System;
namespace PLFAPI.Helper
{
    public class ConsoleHelper
    {
        /// <summary>
        /// Write the specified text.
        /// </summary>
        /// <returns>The write.</returns>
        /// <param name="text">Text.</param>
        public static void Write(String text)
        {
            //write in console with date time
            Console.WriteLine(DateTime.UtcNow.ToString("T") + " > " + text);
        }
    }
}
