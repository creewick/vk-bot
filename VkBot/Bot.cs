using System;
using VkCallback = VkCallbackApi.VkCallbackApi;

namespace VkBot
{
    public class Bot
    {
        private readonly VkApi.VkApi api = new VkApi.VkApi();
        private readonly VkCallback callback;

        public Bot(string token)
        {
            api.Login(token);
            callback = new VkCallback {ConfirmationToken = "f8ff207a"};
            callback.OnRequest += req =>
            {
                if (req.Type == VkCallbackApi.Models.Enums.EventType.MessageNew)
                {
                    Send(req.Object.Id, "Да, привет!");
                }
            };
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine('a');
            }
        }

        public void Send(long peerId, string message) => api.Send(peerId, message);
    }
}
