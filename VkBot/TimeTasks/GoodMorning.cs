using System;

namespace VkBot.TimeTasks
{
    public class GoodMorning : ITimeTask
    {
        private static DateTime lastMorning = DateTime.MinValue;

        public void Task(Bot bot)
        {
            var now = DateTime.UtcNow.AddHours(5); ;
            if (!lastMorning.Date.Equals(now.Date) &&
                now.Hour == 10 && now.Minute < 10)
            {
                foreach (var chat in bot.Chats)
                    bot.Send(chat, "Доброе утро, пушистики! :3");
                lastMorning = now;
            }
        }
    }
}
