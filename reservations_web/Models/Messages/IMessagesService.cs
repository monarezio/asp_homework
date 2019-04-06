using System.Collections.Generic;

namespace reservations_web.Models.Messages
{
    public interface IMessagesService
    {
        IList<Message> Messages { get; }

        void AddMessage(Message message);

        void Clear();
    }
}