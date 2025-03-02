using DTOs.Concrete;

namespace WebUI.Models
{
    public class BusJourneyModel
    {
        public List<JourneyData> JourneyData { get; set; }
        public string AlertMessage { get; set; }
    }
}
