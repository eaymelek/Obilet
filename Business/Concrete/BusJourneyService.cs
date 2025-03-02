using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Common.Constants;
using Core.Aspects.Validation;
using DTOs.Concrete;
using Infrastructure.ExternalServices;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Logging;

namespace Business.Concrete
{
    /// <summary>
    /// BusJourneyService class is used to get bus journeys from Obilet API
    /// </summary>
    public class BusJourneyService : IBusJourneyService
    {
        private readonly ILogger<BusJourneyService> _logger;
        private readonly IObiletApiService _obiletApiService;

        /// <summary>
        /// Constructor method for BusJourneyService
        /// </summary>
        /// <param name="obiletApiService"></param>
        /// <param name="logger"></param>
        public BusJourneyService(IObiletApiService obiletApiService, ILogger<BusJourneyService> logger)
        {
            _obiletApiService = obiletApiService;
            _logger = logger;
        }

        /// <summary>
        /// GetBusJourneys method is used to get bus journeys from Obilet API
        /// </summary>
        /// <param name="busJourneyRequest"></param>
        /// <returns></returns>
        [ValidationAspect(typeof(BusJourneyValidator), Priority = 1)]
        public BusJourneyResponse GetBusJourneys(BusJourneyRequest busJourneyRequest)
        {
            try
            {
                return _obiletApiService.GetBusJourneysAsync(busJourneyRequest).GetAwaiter().GetResult();
                        }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "GetBusJourneys failed");
                return new BusJourneyResponse();
            }
        }
    }
}
