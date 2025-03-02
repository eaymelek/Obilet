using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Concrete
{
    public class LocationRequest
    {
        // İlgili isteğe göre alanlar ekle
        public string Departure { get; set; }
        public string Arrival { get; set; }
    }

    public class LocationResponse
    {
        public List<BusLocation> Locations { get; set; }
        // Diğer gerekli alanlar
    }

    public class BusLocation
    {
        public string Departure { get; set; }
        public string Arrival { get; set; }
        // Diğer gerekli alanlar
    }

}
