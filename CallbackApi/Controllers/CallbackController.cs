using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CallbackApi.Models;
using CallbackApi.Models.Enums;
using VkBot;

namespace CallbackApi.Controllers
{
    [Route("api/vk")]
    public class CallbackController : ApiController
    {
        private readonly VkBot.Bot bot = new Bot(ConfigurationManager.ConnectionStrings["token"].ConnectionString);

        public HttpResponseMessage Post([FromBody]CallbackRequest request)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            if (request.Type == EventType.Сonfirmation)
                response.Content = new StringContent(
                    ConfigurationManager.ConnectionStrings["confirm-code"].ConnectionString,
                    System.Text.Encoding.UTF8, "text/plain");

            try
            {
                if (request.Type == EventType.MessageNew)
                {
                    var m = request.Object;
                    bot.NewMessage(m.PeerId, m.Text);
                }
            }
            catch (Exception e)
            {
                response.Content = new StringContent(e.Message + '\n' + e.StackTrace, System.Text.Encoding.UTF8, "text/plain");
            }

            response.Content = new StringContent(
                "ok", 
                System.Text.Encoding.UTF8, 
                "text/plain");
            return response;
        }
    }
}