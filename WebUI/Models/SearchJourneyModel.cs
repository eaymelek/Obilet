using DTOs.Concrete;

namespace WebUI.Models
{
    public class SearchJourneyModel
    {
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public DateTime Date { get; set; }
    }
}
