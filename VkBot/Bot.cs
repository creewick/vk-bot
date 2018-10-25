using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using VkBot.MessageTasks;
using VkBot.ReplyTasks;
using VkBot.TimeTasks;

namespace VkBot
{
    public class Bot
    {
        public readonly HashSet<long> Chats = new HashSet<long>();

        const string Calling = @"^\[club172770222\|.*\]";
        private readonly VkApi.VkApi api;

        private static readonly List<ITimeTask> TimeTasks = new List<ITimeTask>
        {
            new GoodMorning(),
            new GoodNight()
        };  

        private static readonly List<IReplyTask> ReplyTasks = new List<IReplyTask>
        {
            new RepeatTask(),
            new GetChatsTask(),
            new BasicTask()
        };

        private static readonly List<IMessageTask> MessageTasks = new List<IMessageTask>
        {
            new AntiHugTask()
        };
        
        public Bot(string token)
        {
            api = new VkApi.VkApi(token);
            Task.Run(() => Run());
        }

        public void Run()
        {
            while (true)
            {
                foreach (var timeTask in TimeTasks)
                    timeTask.Task(this);
                Thread.Sleep(1000 * 60);
            }
        }

        public void NewMessage(long peerId, string text)
        {
            AddChat(peerId);
            if (BotCalled(peerId, text))
            {
                foreach (var task in ReplyTasks)
                    if (task.Action(this, peerId, text))
                        break;
            }
            else
            {
                foreach (var task in MessageTasks)
                    if (task.Action(this, peerId, text))
                        break;
            }
        }

        private static bool BotCalled(long peerId, string text) =>
            Regex.IsMatch(text, Calling) || peerId < 2000000000;

        private void AddChat(long peerId)
        {
            if (peerId > 2000000000)
                Chats.Add(peerId);
        }

        public void Send(long peerId, string message) => api.Send(peerId, message);
    }
}
