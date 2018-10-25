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
        private static readonly VkBot.Bot Bot = 
            new Bot(ConfigurationManager.ConnectionStrings["token"].ConnectionString);

        public HttpResponseMessage Post([FromBody]CallbackRequest request)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            if (request.Type == EventType.Сonfirmation)
                response.Content = new StringContent(
                    ConfigurationManager.ConnectionStrings["confirm-code"].ConnectionString,
                    System.Text.Encoding.UTF8, "text/plain");

            if (request.Type == EventType.MessageNew)
            {
                var m = request.Object;
                Task.Run(() => Bot.NewMessage(m.PeerId, m.Text));

                response.Content = new StringContent(
                    "ok",
                    System.Text.Encoding.UTF8,
                    "text/plain");
            }

            return response;
        }
    }
}