using System.Text.Json.Serialization;

namespace Entities.Concrete.BusJourney
{
    public class JourneyStop
    {
        public string Name { get; set; }
        public string Station { get; set; }
        public DateTime Time { get; set; }

        [JsonPropertyName("is-origin")]
        public bool IsOrigin { get; set; }

        [JsonPropertyName("is-destination")]
        public bool IsDestination { get; set; }
    }
}