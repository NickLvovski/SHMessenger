using System;
using Newtonsoft.Json;

namespace SHMessenger
{
    class Program
    {
        private static int MessageID;
        private static string UserName;
        private static MessengerClientAPI API = new MessengerClientAPI();

        private static void GetNewMessages()
        {
            Message msg = API.GetMessage(MessageID);
            while (msg != null)
            {
                Console.WriteLine(msg);
                MessageID++;
                msg = API.GetMessage(MessageID);
            }        
        }

        static void Main(string[] args)
        {
            MessageID = 1;
            Console.WriteLine("Введите Ваше имя: ");
            UserName = Console.ReadLine();
            string MessageText = "";
            
            while (MessageText.ToLower() != "exit")
            {
                GetNewMessages();
                MessageText = Console.ReadLine();
                if (MessageText.Length > 1)
                {
                    Message Sendmsg = new Message(UserName, MessageText, DateTime.Now);
                    API.SendMessage(Sendmsg);
                }
            }
            
            //Message msg = new Message("Shnucker", "Hi", DateTime.UtcNow);
            //string output = JsonConvert.SerializeObject(msg);
            //Console.WriteLine(output);
            //Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            //Console.WriteLine(deserializedMsg);
            ////{"UserName":"Shnucker","MessageText":"Hi","TimeStamp":"2022-01-22T15:36:30.2664146Z"}
            ////Shnucker < 22.01.2022 15:36:30 >: Hi
        }
    }
}
