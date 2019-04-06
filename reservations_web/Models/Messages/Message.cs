namespace reservations_web.Models.Messages
{
    public class Message
    {
        public string Body { get; }
        public MessageType MessageType { get; }

        public string StyleClass
        {
            get
            {
                switch (MessageType)
                {
                    case MessageType.Success:
                        return "alert-success";
                    case MessageType.Danger:
                        return "alert-danger";
                    default:
                        return "alert-primary";        
                }
            }
        }
        
        public Message(string body, MessageType messageType = MessageType.Danger)
        {
            Body = body;
            MessageType = messageType;
        }
    }
}