using Core.Entities;
using System.Text.Json.Serialization;

namespace Entities.Concrete.Session
{
    public class DeviceSession :IEntity
    {
        [JsonPropertyName("session-id")]
        public string SessionId { get; set; }

        [JsonPropertyName("device-id")]
        public string DeviceId { get; set; }
    }
}