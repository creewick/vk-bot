﻿using System;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkApi
{
    public class VkApi
    {
        private readonly VkNet.VkApi api = new VkNet.VkApi();
        

        public VkApi(string token)
        {
            api.Authorize(new ApiAuthParams { AccessToken = token });
        }

        public void Send(long peerId, string message)
        {
            try
            {
                api.Messages.Send(new MessagesSendParams
                {
                    Message = message,
                    PeerId = peerId
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
