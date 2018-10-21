using System.Threading;

namespace VkBot
{
    public class Bot
    {
        private readonly VkApi.VkApi api;

        public Bot(string token)
        {
            api = new VkApi.VkApi();
            api.Login(token);
            while (true)
            {
                api.Mention();
            }
        }

        public void Send(long peerId, string message) => api.Send(peerId, message);
    }
}
