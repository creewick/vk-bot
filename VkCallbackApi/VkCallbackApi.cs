using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using VkCallbackApi.Models;

namespace VkCallbackApi
{
    public class VkCallbackApi
    {
        public string ConfirmationToken { get; set; }

        public delegate void RequestHandler(CallbackRequest request);
        public event RequestHandler OnRequest;

        private readonly Socket socket;
        
        public VkCallbackApi(string confirmToken)
        {
            ConfirmationToken = confirmToken;
            OnRequest += (x) => { };

            socket = new Socket(SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(new IPEndPoint(IPAddress.Any, 80));
            Receive();
        }

        private void Receive()
        {
            var e = new SocketAsyncEventArgs();
            e.SetBuffer(new byte[100], 0, 100);
            e.RemoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            e.UserToken = socket;
            e.Completed += Handler;
            socket.ReceiveFromAsync(e);
        }

        private void Send(string answer)
        {

        }

        private void Handler(object sender, SocketAsyncEventArgs e)
        {
            Console.WriteLine("receive");
            var data = Encoding.ASCII.GetString(e.Buffer, e.Offset, e.BytesTransferred);
            var answer = HandleResponse(data);
            Send(answer);
        }

        public string HandleResponse(CallbackRequest request)
        {
            try
            {
                if (request.Type == Models.Enums.EventType.Сonfirmation)
                {
                    return ConfirmationToken;
                }
                OnRequest(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "ok";
        }

        private string HandleResponse(string stringData)
        {
            var data = JsonConvert.DeserializeObject<CallbackRequest>(stringData);
            return HandleResponse(data);
        }
    }
}
