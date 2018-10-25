using System;

namespace VkBot.TimeTasks
{
    class GoodNight : ITimeTask
    {
        private static DateTime lastNight = DateTime.MinValue;

        public void Task(Bot bot)
        {
            var now = DateTime.UtcNow.AddHours(5);
            if (!lastNight.Date.Equals(now.Date) &&
                now.Hour == 0 && now.Minute < 10)
            {
                foreach (var chat in bot.Chats)
                    bot.Send(chat, "Сладких всем снов! :3");
                lastNight = now;
            }
        }
    }
}
