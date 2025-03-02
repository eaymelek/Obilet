using Core.Utilities.Results;
using DTOs.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    /// <summary>
    /// IBusJourneyService interface is used to define bus journey service
    /// </summary>
    public interface IBusJourneyService
    {
        BusJourneyResponse GetBusJourneys(BusJourneyRequest busJourneyRequest);
    }
}
