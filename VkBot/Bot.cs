using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VkBot
{
    public class Bot
    {
        private readonly VkApi.VkApi api;
        const string Calling = @"\[club172770222\|.*\]";

        public Bot(string token)
        {
            api = new VkApi.VkApi(token);
            Console.WriteLine("Success login ВК");
        }

        public void NewMessage(int peerId, string text)
        {
            if (Regex.IsMatch(text, Calling) || peerId < 2000000000)
            {
                var i = new Random().Next(5);
                Send(peerId, i == 0 ? "Destroy the humanity!" : "zzz");
            }
        }

        public void Send(long peerId, string message) => api.Send(peerId, message);
    }
}
