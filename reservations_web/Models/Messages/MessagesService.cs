using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace reservations_web.Models.Messages
{
    public class MessagesService: IMessagesService
    {
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IList<Message> Messages
        {
            get
            {
                ITempDataDictionary tempData = GetTempData();

                if (tempData[MessageKey] is IList<string> messages)
                {
                    IList<Message> messagesAsObjects = messages.Select(JsonConvert.DeserializeObject<Message>).ToList();
                    Clear();
                    return messagesAsObjects;
                }

                return new List<Message>();
            }
        }

        public MessagesService(IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddMessage(Message message)
        {
            ITempDataDictionary tempData = GetTempData();

            if (tempData[MessageKey] == null) //Is the array containing the messages set?
                tempData[MessageKey] = new List<string>();

            string serializedMessage = JsonConvert.SerializeObject(message);
            (tempData[MessageKey] as IList<string>).Add(serializedMessage); //I Want to it crash, if it fails, for debugging reasons
        }

        public void Clear()
        {
            GetTempData()[MessageKey] = null;
        }

        private ITempDataDictionary GetTempData()
        {
            HttpContext context = _httpContextAccessor.HttpContext;
            return _tempDataDictionaryFactory.GetTempData(context);
        }

        private const string MessageKey = "messages";
    }
}