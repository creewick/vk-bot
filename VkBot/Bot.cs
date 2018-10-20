using System;

namespace VkBot
{
    public class Bot
    {
        private readonly VkApi.VkApi api;
        private readonly VkCallbackApi.VkCallbackApi callbackApi;

        public Bot(string token, string confirmCode)
        {
            api = new VkApi.VkApi(token);
            Console.WriteLine("Success login VK");
            callbackApi = new VkCallbackApi.VkCallbackApi(confirmCode);
            Console.WriteLine("Success create callback API");
            callbackApi.OnRequest += OnRequest;
        }

        private static void OnRequest(VkCallbackApi.Models.CallbackRequest request)
        {
            Console.WriteLine("Request");
        }

        public void Send(long peerId, string message) => api.Send(peerId, message);
    }
}
