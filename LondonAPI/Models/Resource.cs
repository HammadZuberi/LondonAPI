using Newtonsoft.Json;

namespace LondonAPI.Models
{
    public abstract class Resource
    {
        //all api should self reference the data identifing which api is called.order to top
        [JsonProperty(Order = -2)]
        public string Href { get; set; } = "";
    }
}
