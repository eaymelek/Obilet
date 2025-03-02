using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DTOs.Concrete
{
    public class SessionData : ApiResponse
    {
        [JsonPropertyName("data")]
        public DeviceSession Data { get; set; }
    }

    public class SessionInfo
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("connection")]
        public Connection Connection { get; set; }

        [JsonPropertyName("application")]
        public Application Application { get; set; }

        [JsonPropertyName("browser")]
        public Browser Browser { get; set; }
    }

    public class Connection
    {
        [JsonPropertyName("ip-address")]
        public string IpAddress { get; set; }

        [JsonPropertyName("port")]
        public int Port { get; set; }
    }
    public class Application
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("equipment-id")]
        public string EquipmentId { get; set; }
    }

    public class Browser
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }
    }
    public class DeviceSession
    {
        [JsonPropertyName("session-id")]
        public string SessionId { get; set; }

        [JsonPropertyName("device-id")]
        public string DeviceId { get; set; }

    }
}
