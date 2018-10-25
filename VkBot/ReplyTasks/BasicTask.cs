using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkBot.ReplyTasks
{
    public class BasicTask : IReplyTask
    {
        public bool Action(Bot bot, long peerId, string message)
        {
            var a = new Random().Next(5);
            bot.Send(peerId, a == 0 ? "Destroy the humanity" : "zzz");
            return true;
        }
    }
}
