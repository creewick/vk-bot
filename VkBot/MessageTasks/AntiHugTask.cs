using System;
using System.Text.RegularExpressions;

namespace VkBot.MessageTasks
{
    public class AntiHugTask : IMessageTask
    {
        private static Random random = new Random();

        public bool Action(Bot bot, long peerId, string message)
        {
            if (!Regex.IsMatch(message, "^!hug "))
                return false;

            if (random.Next(3) == 0)
                bot.Send(peerId, "👉🏌‍♀️👀🚶👈 Обнимайтесь!");
            return true;
        }
    }
}
