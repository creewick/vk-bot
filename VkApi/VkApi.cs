using System.Collections.Generic;
using VkNet.Enums;
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

        public void Send(long peerId, string message)
        {
            api.Messages.Send(new MessagesSendParams { Message = message, PeerId = peerId });
        }
    }
}
