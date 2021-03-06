﻿using CallbackApi.Models.Enums;
using CallbackApi.Models.Objects;
using Newtonsoft.Json;

namespace CallbackApi.Models
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
