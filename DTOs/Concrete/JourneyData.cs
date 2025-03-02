using System.Text.Json.Serialization;

namespace DTOs.Concrete
{
    public class JourneyData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("partner-id")]
        public int PartnerId { get; set; }

        [JsonPropertyName("partner-name")]
        public string PartnerName { get; set; }

        [JsonPropertyName("route-id")]
        public int RouteId { get; set; }

        [JsonPropertyName("bus-type")]
        public string BusType { get; set; }

        [JsonPropertyName("total-seats")]
        public int TotalSeats { get; set; }

        [JsonPropertyName("available-seats")]
        public int AvailableSeats { get; set; }

        [JsonPropertyName("journey")]
        public Journey Journey { get; set; }

        [JsonPropertyName("features")]
        public List<Feature> Features { get; set; }

        [JsonPropertyName("origin-location")]
        public string OriginLocation { get; set; }

        [JsonPropertyName("destination-location")]
        public string DestinationLocation { get; set; }

        [JsonPropertyName("is-active")]
        public bool IsActive { get; set; }

        [JsonPropertyName("origin-location-id")]
        public int OriginLocationId { get; set; }

        [JsonPropertyName("destination-location-id")]
        public int DestinationLocationId { get; set; }

        [JsonPropertyName("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonPropertyName("cancellation-offset")]
        public int CancellationOffset { get; set; }

        [JsonPropertyName("has-bus-shuttle")]
        public bool HasBusShuttle { get; set; }

        [JsonPropertyName("disable-sales-without-gov-id")]
        public bool DisableSalesWithoutGovId { get; set; }

        [JsonPropertyName("display-offset")]
        public TimeSpan DisplayOffset { get; set; }

        [JsonPropertyName("partner-rating")]
        public double PartnerRating { get; set; }
    }

    public class Journey
    {
        public string Kind { get; set; }
        public string Code { get; set; }
        public List<JourneyStop> Stops { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string Currency { get; set; }
        public TimeSpan Duration { get; set; }

        [JsonPropertyName("original-price")]
        public float OriginalPrice { get; set; }

        [JsonPropertyName("internet-price")]
        public float InternetPrice { get; set; }
        public string Booking { get; set; }
        public string BusName { get; set; }
        public Policy Policy { get; set; }
        public List<string> Features { get; set; }
        public string Description { get; set; }
        public bool? Available { get; set; }

    }

    public class Policy
    {
        [JsonPropertyName("max-seats")]
        public int? MaxSeats { get; set; }

        [JsonPropertyName("max-single")]
        public int? MaxSingle { get; set; }

        [JsonPropertyName("max-single-males")]
        public int? MaxSingleMales { get; set; }

        [JsonPropertyName("max-single-females")]
        public int? MaxSingleFemales { get; set; }

        [JsonPropertyName("mixed-genders")]
        public bool MixedGenders { get; set; }

        [JsonPropertyName("gov-id")]
        public bool GovId { get; set; }

        [JsonPropertyName("lht")]
        public bool Lht { get; set; }
    }

    public class JourneyStop
    {
        public string Name { get; set; }
        public string Station { get; set; }
        public DateTime? Time { get; set; }

        [JsonPropertyName("is-origin")]
        public bool IsOrigin { get; set; }

        [JsonPropertyName("is-destination")]
        public bool IsDestination { get; set; }
    }
    public class Feature
    {
        public int Id { get; set; }
        public int? Priority { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonPropertyName("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonPropertyName("back-color")]
        public string BackColor { get; set; }

        [JsonPropertyName("fore-color")]
        public string ForeColor { get; set; }
    }
}