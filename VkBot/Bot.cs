using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VkBot
{
    public class Bot
    {
        private readonly VkApi.VkApi api;
        const string Calling = @"\[club172770222\|.*\]";
        private readonly List<long> ChatList = new List<long>{2000000002};
        
    public Bot(string token)
        {
            api = new VkApi.VkApi(token);
            Console.WriteLine("Success login ВК");
        }

        public void Run()
        {
            while (true)
            {
                GoodMorning();
                GoodNight();
            }
        }

        private DateTime lastMorning = DateTime.MinValue;
        private void GoodMorning()
        {
            var now = DateTime.UtcNow.AddHours(5);
            if (!lastMorning.Date.Equals(now.Date) &&
                now.Hour == 10 && now.Minute < 10)
            {
                foreach (var chat in ChatList)
                    Send(chat, "Доброе утро, пушистики! :3");
                lastMorning = now;
            }
        }

        private DateTime lastNight = DateTime.MinValue;
        private void GoodNight()
        {
            var now = DateTime.UtcNow.AddHours(5);
            if (!lastNight.Date.Equals(now.Date) &&
                now.Hour == 2 && now.Minute < 10)
            {
                foreach (var chat in ChatList)
                    Send(chat, "Сладких всем снов! :3");
                lastNight = now;
            }
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
