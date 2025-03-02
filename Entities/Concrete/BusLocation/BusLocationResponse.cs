using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete.BusLocation
{
    public class BusLocationResponse : ApiResponse
    {
        public List<LocationData> Data { get; set; }

    }
}
