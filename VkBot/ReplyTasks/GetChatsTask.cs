using System.Text;
using System.Text.RegularExpressions;

namespace VkBot.ReplyTasks
{
    public class GetChatsTask : IReplyTask
    {
        public bool Action(Bot bot, long peerId, string message)
        {
            if (!Regex.IsMatch(message, "debugGetChats"))
                return false;

            var reply = new StringBuilder("Список чатов:");
            foreach (var chat in bot.Chats)
                reply.Append($" {chat}");

            bot.Send(peerId, reply.ToString());
            return true;
        }
    }
}
