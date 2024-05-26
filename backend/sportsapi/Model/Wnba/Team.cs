using System.Text.Json.Serialization;

namespace sportsapi.Model.Wnba
{
    public class team
    {
        public string id { get; set; }
        public string uid { get; set; }
        public string slug { get; set; }
        public string abbreviation { get; set; }
        [JsonPropertyName("displayName")]
        public string displayName { get; set; }

        [JsonPropertyName("shortDisplayName")]
        public string shortDisplayName { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string location { get; set; }
        public string color { get; set; }
        public string alternateColor { get; set; }
        public bool isActive { get; set; }
        public bool isAllStar { get; set; }
        public Logo[] Logos { get; set; }
    }

    public class Logo
    {
        public string href { get; set; }
    }
}
