using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkApi
{
    public class VkApi
    {
        private readonly VkNet.VkApi api = new VkNet.VkApi();

        public void Login(string token)
        {
            api.Authorize(new ApiAuthParams { AccessToken = token });
        }

        public void Send(long? peerId, string message)
        {
            Thread.Sleep(1000 / 20);
            api.Messages.Send(new MessagesSendParams { Message = message, PeerId = peerId });
        }

        public void Mention()
        {
            Thread.Sleep(1000 / 20);
            var dialogs = api.Messages.GetConversations(new GetConversationsParams
            {
                Filter = GetConversationFilter.Unread
            }).Items.Select(d => d.Conversation.Peer.Id);

            var du = api.Messages.GetDialogs(new MessagesDialogsGetParams());

            Send(2000000001, "Force Send by peerID");

            foreach (var dialog in dialogs)
            {
                try
                {
                    Thread.Sleep(1000 / 20);
                    var history = api.Messages.GetHistory(new MessagesGetHistoryParams
                    {
                        PeerId = dialog
                    });

                    foreach (var message in history.Messages)
                        if (dialog == message.FromId ||
                            message.Text.StartsWith("[club172770222|@in_bot]"))
                        {
                            Send(message.PeerId, "Destroy the humanity!");
                            break;
                        }
                } catch { }
            }
        }
    }
}
