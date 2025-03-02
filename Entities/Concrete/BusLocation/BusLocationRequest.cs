using Core.Entities;
using Entities.Concrete.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.BusLocation
{
    public class BusLocationRequest : ApiRequest, IEntity
    {
        public object Data { get; set; }

    }
}