using Entities.Concrete.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ApiRequest
    {
        public DeviceSession DeviceSession { get; set; }
        public string Date { get; set; }
        public string Language { get; set; }
    }
}
