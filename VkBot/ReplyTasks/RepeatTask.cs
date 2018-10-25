using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace VkBot.ReplyTasks
{
    class RepeatTask : IReplyTask
    {
        public bool Action(Bot bot, long peerId, string message)
        {
            if (!Regex.IsMatch(message, "повтори"))
                return false;

            bot.Send(peerId, message.Split(
                new[] {"повтори"},
                StringSplitOptions.None).LastOrDefault());
            return true;
        }
    }
}
