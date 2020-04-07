using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatClient
{
    class Program
    {
        public static IChat ChatService = Helper.WcfClient<Data.IChat>.Channel("http://127.0.0.1:8383/chatservice");

        public static List<MessageDto> ProcessedMessages=new List<MessageDto>();

        static void Main(string[] args)
        {
            Console.WriteLine("CHAT CLIENT");
            Console.WriteLine("Nickname'inizi giriniz");
            string nickname = Console.ReadLine();
            Console.SetCursorPosition(0,Console.CursorTop -1);
            Console.WriteLine("Hoşgeldin "+ nickname + "!");

            
           

            new Thread(Pooling.Worker).Start();



            while (true)
            {
                string message = Console.ReadLine();
                Console.SetCursorPosition(0,Console.CursorTop -1);

                ChatService.SendMessage(nickname,message);
            }
        }

        public class Pooling
        {

            public static void Worker()
            {

                while (true)
                {
                    List<MessageDto> messages = ChatService.GetAllMessages();


                    
                    foreach (MessageDto message  in messages)
                    {
                        if (!ProcessedMessages.Any(a=>a.Id ==message.Id))
                        {
                            Console.WriteLine(message.SendDate.ToString("mm:ss")+ " " + message.Nickname + ": "+ message.Message);
                        }
                        
                    }


                    ProcessedMessages.AddRange(messages);

                    Thread.Sleep(100);
                }
            }
        }
    }
}
