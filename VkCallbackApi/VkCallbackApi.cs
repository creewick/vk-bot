using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using VkCallbackApi.Models;

namespace VkCallbackApi
{
    public class VkCallbackApi
    {
        public string ConfirmationToken { get; set; }
        public string Secret { get; set; }

        public delegate void RequestHandler(CallbackRequest request);
        public event RequestHandler OnRequest;

        private readonly HttpListener httpListener = new HttpListener();

        public VkCallbackApi(string confirmToken)
        {
            ConfirmationToken = confirmToken;
            OnRequest += (x) => { };

            httpListener.Prefixes.Add("http://+:80/");
        }

        public async void Run()
        {
            httpListener.Start();
            try
            {
                while (true)
                {
                    Console.WriteLine("waiting for request");
                    var context = await httpListener.GetContextAsync();
                    Console.WriteLine("got request");
                    var request = context.Request;
                    string content;
                    using (var receiveStream = request.InputStream)
                        using (var readStream = new StreamReader(receiveStream))
                            content = readStream.ReadToEnd();
                    var answer = HandleResponse(JsonConvert.DeserializeObject<CallbackRequest>(content));

                    var response = context.Response;
                    var buffer = System.Text.Encoding.UTF8.GetBytes(answer);
                    var outputStream = response.OutputStream;

                    await outputStream.WriteAsync(buffer, 0, buffer.Length);
                    Console.WriteLine("response sent");
                    outputStream.Close();
                }
            }
            finally
            {
                httpListener.Close();
            }

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

        public string HandleResponse(string stringData)
        {
            var data = JsonConvert.DeserializeObject<CallbackRequest>(stringData);
            return HandleResponse(data);
        }
    }
}
