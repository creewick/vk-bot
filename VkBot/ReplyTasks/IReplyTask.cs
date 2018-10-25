using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkBot.ReplyTasks
{
    interface IReplyTask
    {
        bool Action(Bot bot, long peerId, string message);
    }
}
