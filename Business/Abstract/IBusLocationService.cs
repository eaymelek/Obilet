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
    /// IBusLocationService interface is used to define bus location service
    /// </summary>
    public interface IBusLocationService
    {
        BusLocationResponse GetBusLocations(BusLocationRequest busLocationRequest);
    }
}
