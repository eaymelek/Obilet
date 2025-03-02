using DTOs.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalServices
{
    /// <summary>
    /// Obitel Api Service
    /// </summary>
    public interface IObiletApiService
    {
        Task<SessionData> GetSessionAsync(SessionInfo session);
        Task<BusLocationResponse> GetBusLocationsAsync(BusLocationRequest busLocationRequest);
        Task<BusJourneyResponse> GetBusJourneysAsync(BusJourneyRequest busJourneyRequest);
    }
}
