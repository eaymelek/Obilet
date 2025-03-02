using DTOs.Concrete;

namespace WebUI.Models
{
    public class BusLocationModel
    {
        public List<LocationData> LocationData { get; set; }
        public int? OriginId { get; set; } 
        public int? DestinationId { get; set; }
        public string AlertMessage { get; set; }
    }
}
