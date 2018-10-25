namespace VkBot.MessageTasks
{
    interface IMessageTask
    {
        bool Action(Bot bot, long peerId, string message);
    }
}
