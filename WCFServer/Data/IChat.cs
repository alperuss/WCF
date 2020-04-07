using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Singletons
    {

        public static List<MessageDto> Messages = new List<MessageDto>();
    }
    [ServiceContract]
    public interface IChat
    {
        [OperationContract]
        void SendMessage(string nickname, string message);

        [OperationContract]
        List<MessageDto> GetAllMessages();
    }



    public class ChatService : IChat
    {
        public void SendMessage(string nickname, string message)
        {
            
            Singletons.Messages.Add(new MessageDto() { 
            
            Id=Guid.NewGuid(),
            Nickname=nickname,
            Message = message,
            SendDate=DateTime.Now
            
            
            });
            Console.WriteLine(nickname + ": " + message );

        }

        public List<MessageDto> GetAllMessages()
        {

            return Singletons.Messages;
        }
           
    }

    public class MessageDto
    {
        public Guid Id { get; set; }
        public DateTime SendDate { get; set; }

        public string Nickname { get; set; }
        public string Message { get; set; }
    }
}
