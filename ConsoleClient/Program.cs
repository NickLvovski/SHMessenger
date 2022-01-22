using System;
using Newtonsoft.Json;

namespace SHMessenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Message msg = new Message("Shnucker", "Hi", DateTime.UtcNow);
            string output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);
            Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserializedMsg);
            //{ "UserName":"Shnucker","MessageText":"Hi","TimeStamp":"2022-01-22T15:36:30.2664146Z"}
            //Shnucker < 22.01.2022 15:36:30 >: Hi
        }
    }
}
