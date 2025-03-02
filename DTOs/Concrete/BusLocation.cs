using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOs.Concrete
{
    public class BusLocationRequest : ApiRequest
    {
        [JsonPropertyName("data")]
        public object Data { get; set; }

    }
    public class BusLocationResponse : ApiResponse
    {
        [JsonPropertyName("data")]
        public List<LocationData> Data { get; set; }

    }
}