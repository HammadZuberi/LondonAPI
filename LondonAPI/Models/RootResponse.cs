using Newtonsoft.Json;
using System.ComponentModel;

namespace LondonAPI.Models
{
    public class RootResponse
    {
        public const string GETMethod = "GET";


        public static RootResponse To(string routeName, object routeValues) => new RootResponse
        {
            Releations = null!,
            RouteName = routeName,
            RouteValues = routeValues,
            Methods = GETMethod

        };


        [JsonProperty(Order = -4)]

        public string Href { get; set; } = string.Empty;

        [JsonProperty(Order = -3, PropertyName = "rel", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Releations { get; set; } = default!;

        [JsonProperty(Order = -2, DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(GETMethod)]
        public string Methods { get; set; } = string.Empty;

        //stores route name and values  to rwritten by the link filter
        [JsonIgnore]
        public string RouteName { get; set; }= string.Empty;
        [JsonIgnore]
        public object RouteValues { get; set; } = default!;
    }
}
