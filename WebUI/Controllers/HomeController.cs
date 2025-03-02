using Business.Abstract;
using Common.Constants;
using DTOs.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISessionService _sessionService;
    private readonly IBusJourneyService _busJourneyService;
    private readonly IBusLocationService _busLocationService;

    IValidator<BusJourneyRequest> _validator;
    public HomeController(ISessionService sessionService, IBusJourneyService busJourneyService, IBusLocationService busLocationService, IValidator<BusJourneyRequest> validator, ILogger<HomeController> logger)
    {
        _sessionService = sessionService;
        _busJourneyService = busJourneyService;
        _busLocationService = busLocationService;
        _logger = logger;
        _validator = validator;
    }
    private BusJourneyModel CreateBusJourneyModel(string alertMessage = null, IEnumerable<JourneyData> journeyData = null)
    {
        var model = new BusJourneyModel
        {
            AlertMessage = alertMessage,
            JourneyData = journeyData?.ToList() ?? new List<JourneyData>()
        };

        foreach (var key in ModelState.Keys)
        {
            var state = ModelState[key];
            foreach (var error in state.Errors)
            {
                model.AlertMessage += error.ErrorMessage;
            }
        }
        return model;
    }
    private BusJourneyRequest CreateBusJourneyRequest(SearchJourneyModel model, SessionData session)
    {
        return new BusJourneyRequest
        {
            Data = new BusSearchData
            {
                DepartureDate = model.Date.ToString("yyyy-MM-dd"),
                DestinationId = model.DestinationId,
                OriginId = model.OriginId
            },
            DeviceSession = session.Data,
            Date = DateTime.Now.ToString("yyyy-MM-dd"),
            Language = "tr-TR"
        };
    }

    public IActionResult Index()
    {

        var session = _sessionService.GetSession();
        if (session?.Data == null)
        {
            _logger.LogError(Messages.SessionNotFound);
            return View(new BusLocationModel { AlertMessage = Messages.SessionNotFound , LocationData =new List<LocationData>()});
        }

        var busLocationRequest = new BusLocationRequest()
        {
            Data = null,
            DeviceSession = session.Data.Data,
            Date = DateTime.Now.ToString("yyyy-MM-dd"),
            Language = "tr-TR"
        };

        var busJourneyList = _busLocationService.GetBusLocations(busLocationRequest);
        return View(new BusLocationModel { LocationData = busJourneyList.Data });
    }

    [HttpPost]
    public IActionResult JourneyIndex(SearchJourneyModel model)
    {

        var session = _sessionService.GetSession();
        if (session?.Data == null)
        {
            _logger.LogError(Messages.SessionNotFound);
            return View(CreateBusJourneyModel(Messages.SessionNotFound));
        }
        var busJourneyRequest = CreateBusJourneyRequest(model, session.Data);
        var validationResult = _validator.Validate(busJourneyRequest);

        if (!validationResult.IsValid)
        {
            foreach (var failure in validationResult.Errors)
            {
                _logger.LogError(failure.ErrorMessage);
                ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
            }
            return View(CreateBusJourneyModel());
        }

        var busJourneyList = _busJourneyService.GetBusJourneys(busJourneyRequest);
        if (busJourneyList.Data == null)
        {
            _logger.LogError(Messages.JourneyListError);
            return View(CreateBusJourneyModel(Messages.JourneyListError));
        }

        return View(CreateBusJourneyModel(journeyData: busJourneyList.Data));
    }

    public IActionResult Error(string message)
    {
        return View("Error", model: message);
    }
}
