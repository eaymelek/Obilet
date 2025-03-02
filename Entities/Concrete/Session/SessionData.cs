using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entities.Concrete.Session
{
    public class SessionData : ApiResponse
    {
        public DeviceSession Data { get; set; }
    }
    public class Session
    {
        public int Type { get; set; }
        public Connection Connection { get; set; }

        public Application Application { get; set; }
    }

    public class Connection
    {
        [JsonPropertyName("ip-address")]
        public string IpAddress { get; set; }
    }
    public class Application
    {
        public string Version { get; set; }

        [JsonPropertyName("equipment-id")]
        public string EquipmentId { get; set; }
    }
}
