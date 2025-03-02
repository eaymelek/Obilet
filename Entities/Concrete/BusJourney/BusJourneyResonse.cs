using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.BusJourney
{
    public class BusJourneyResonse: ApiResponse
    {
        public List<JourneyData> Data { get; set; }

    }
}