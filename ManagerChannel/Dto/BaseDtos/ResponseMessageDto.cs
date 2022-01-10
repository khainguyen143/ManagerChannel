using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dto
{
    public class ResponseMessageDto
    {
        public List<ResponseMessage> Messages { get; set; }

        public ResponseMessageDto(MessageType type, string message)
        {
            this.Messages = new List<ResponseMessage>
            {
                new ResponseMessage{ MessageType = type, Message = message }
            };
        }
    }

    public class ResponseMessage
    {
        public MessageType MessageType { get; set; }
        public string Message { get; set; }
    }

    public enum MessageType
    {
        Success,
        Info,
        Warning,
        Error
    }
}
