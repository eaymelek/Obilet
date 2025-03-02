using Core.Utilities.Results;
using DTOs.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Business.Abstract
{
    /// <summary>
    /// ISessionService interface is used to define session service
    /// </summary>
    public interface ISessionService
    {
        IDataResult<SessionData> GetSession();
        void SetSession(SessionData sessionData);

    }
}
