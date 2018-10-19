using Newtonsoft.Json;
using VKCallbackApi.Models.Enums;
using VKCallbackApi.Models.Objects;

namespace VKCallbackApi.Models
{
    public class CallbackRequest
    {
        [JsonProperty("type")]
        public EventType Type { get; set; }

        [JsonProperty("object")]
        public CallbackRequestObject Object { get; set; }

        [JsonProperty("group_id")]
        public long GroupId { get; set; }

    }
}
