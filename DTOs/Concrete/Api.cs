using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOs.Concrete
{
    public class ApiRequest
    {
        [JsonPropertyName("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }
    }

    public class ApiResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("user-message")]
        public string UserMessage { get; set; }

        [JsonPropertyName("api-request-id")]
        public string ApiRequestId { get; set; }

        [JsonPropertyName("controller")]
        public string Controller { get; set; }

        [JsonPropertyName("client-request-id")]
        public string ClientRequestId { get; set; }

        [JsonPropertyName("web-correlation-id")]
        public string WebCorrelationId { get; set; }

        [JsonPropertyName("parameters")]
        public string Parameters { get; set; }
    }
}
