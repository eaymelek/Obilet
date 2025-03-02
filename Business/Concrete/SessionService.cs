using Business.Abstract;
using Common.Constants;
using Core.Utilities.Results;
using DTOs.Concrete;
using Infrastructure.ExternalServices;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace Business.Concrete
{
    /// <summary>
    /// SessionService class is used to get session data from Obilet API
    /// </summary>
    public class SessionService : ISessionService
    {
        private readonly IObiletApiService _obiletApiService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        ///     
        /// </summary>
        /// <param name="obiletApiService"></param>
        /// <param name="httpContextAccessor"></param>
        public SessionService(IObiletApiService obiletApiService, IHttpContextAccessor httpContextAccessor)
        {
            _obiletApiService = obiletApiService;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// GetSession method is used to get session data from Obilet API
        /// </summary>
        /// <returns></returns>
        public IDataResult<SessionData> GetSession()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            var sessionId = session?.Id;

            if (session == null)
            {
                return new ErrorDataResult<SessionData>(Messages.SessionNotFound);
            }

            if (session.TryGetValue($"Session-{sessionId}", out var sessionBytes))
            {
                var sessionString = Encoding.UTF8.GetString(sessionBytes);
                var sessionData = JsonSerializer.Deserialize<SessionData>(sessionString);

                if (sessionData == null)
                {
                    return new ErrorDataResult<SessionData>(Messages.InvalidSessionData);
                }

                return new SuccessDataResult<SessionData>(sessionData);
            }
            else
            {
                var sessioninfo = _httpContextAccessor.HttpContext?.Items["Session"] as SessionInfo;

                if (sessioninfo == null)
                {
                    return new ErrorDataResult<SessionData>(Messages.SessionNotFound);
                }

                var sessionData = _obiletApiService.GetSessionAsync(sessioninfo).GetAwaiter().GetResult();
                if (sessionData != null)
                {
                    SetSession(sessionData);
                    return new SuccessDataResult<SessionData>(sessionData);
                }
                return new ErrorDataResult<SessionData>(Messages.SessionDataNotFound);
            }
        }

        /// <summary>
        /// SetSession method is used to set session data from Obilet API
        /// </summary>
        /// <param name="sessionData"></param>
        public void SetSession(SessionData sessionData)
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session != null)
            {
                var sessionId = _httpContextAccessor.HttpContext?.Session?.Id;
                var sessionKey = $"Session-{sessionId}"; // veya userId'yi kullanabilirsiniz

                var sessionString = JsonSerializer.Serialize(sessionData);
                var sessionBytes = Encoding.UTF8.GetBytes(sessionString);
                session.Set(sessionKey, sessionBytes);
            }
        }
    }
}
