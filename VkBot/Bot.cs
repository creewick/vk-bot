using System;
using System.Threading.Tasks;
using System.Timers;

namespace VkBot
{
    public class Bot
    {
        private readonly VkApi.VkApi api;

        public Bot(string token)
        {
            api = new VkApi.VkApi();
            api.Login(token);
        }

        public async void Run()
        {
        }

        public void Send(long peerId, string message) => api.Send(peerId, message);
    }
}
