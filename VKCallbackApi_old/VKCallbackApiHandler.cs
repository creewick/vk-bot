using Newtonsoft.Json;
using System;
using VKCallbackApi.Models;

namespace VKCallbackApi
{
    public class VKCallbackApiHandler
    {

        public string ConfirmationToken { get; set; }
        public string Secret { get; set; }

        public delegate void RequestHandler(CallbackRequest request);
        public event RequestHandler OnRequest;

        public VKCallbackApiHandler()
        {
            OnRequest += (x) => { };
        }

        public string HandleResponse(CallbackRequest request)
        {
            try
            {
                if (request.Type == Models.Enums.EventType.Сonfirmation)
                {
                    return ConfirmationToken;
                }
                OnRequest(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "ok";
        }

        public string HandleResponse(string stringData)
        {
            var data = JsonConvert.DeserializeObject<CallbackRequest>(stringData);
            return HandleResponse(data);
        }



    }
}
