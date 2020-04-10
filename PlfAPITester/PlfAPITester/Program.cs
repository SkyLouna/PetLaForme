using System;
using PLFAPI.Object.Ext;
using PLFAPI.Object.Pet;
using Newtonsoft.Json;
using PLFAPI.Object.Pet.Attribute;
using System.Collections.Generic;

namespace PlfAPITester
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("test1".HashSHA256());
            Console.WriteLine("test1".HashSHA256());
            Console.WriteLine("test3".HashSHA256());

            Console.WriteLine((int)PetType.LIZARD);

            List<PetAttribute> list = new List<PetAttribute>();
            list.Add(new PetAttribute(PetAttributeType.COMPETITION, "Test", "lol"));

            Console.WriteLine(JsonConvert.SerializeObject(list));

            JsonConvert.DeserializeObject<List<PetAttribute>>(JsonConvert.SerializeObject(list));

            Console.ReadKey();
        }
    }
}
