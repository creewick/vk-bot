using System;
using System.Net;
using Newtonsoft.Json;
using VkCallbackApi.Models;

namespace VkCallbackApi
{
    public class VkCallbackApi
    {
        public string ConfirmationToken { get; set; }
        public string Secret { get; set; }

        public delegate void RequestHandler(CallbackRequest request);
        public event RequestHandler OnRequest;

        private readonly HttpListener httpListener = new HttpListener();

        public VkCallbackApi()
        {
            OnRequest += (x) => { };

            httpListener.Prefixes.Add("http://+:80/");
            httpListener.Start();
            var content = httpListener.GetContext();
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
