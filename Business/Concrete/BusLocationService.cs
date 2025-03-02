using Business.Abstract;
using DTOs.Concrete;
using Infrastructure.ExternalServices;
using Microsoft.Extensions.Logging;

namespace Business.Concrete
{
    /// <summary>
    /// BusLocationService class is used to get bus locations from Obilet API
    /// </summary>
    public class BusLocationService : IBusLocationService
    {
        private readonly ILogger<BusLocationService> _logger;
        private readonly IObiletApiService _obiletApiService;

        /// <summary>
        /// Constructor method for BusLocationService
        /// </summary>
        /// <param name="obiletApiService"></param>
        /// <param name="logger"></param>
        public BusLocationService(IObiletApiService obiletApiService, ILogger<BusLocationService> logger)
        {
            _obiletApiService = obiletApiService;
            _logger = logger;
        }

        /// <summary>
        /// GetBusLocations method is used to get bus locations from Obilet API
        /// </summary>
        /// <param name="busLocationRequest"></param>
        /// <returns></returns>
        public BusLocationResponse GetBusLocations(BusLocationRequest busLocationRequest)
        {
            try
            {
                return _obiletApiService.GetBusLocationsAsync(busLocationRequest).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "GetBusLocations failed");
                return new BusLocationResponse();
            }
        }
    }
}
