using DTOs.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace Core.Middleware
{
    /// <summary>
    /// SessionMiddleware class is used to get session information
    /// </summary>
    public class SessionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionMiddleware"/> class.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="configuration"></param>
        public SessionMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        /// <summary>
        /// Invokes the session middleware.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            string clientIp = GetClientIpAddress();
            Browser browser = GetBrowserInfo(context);
            GetSessionInfo(context, clientIp, browser);

            await _next(context);
        }

        /// <summary>
        /// Gets the session information.   
        /// </summary>
        /// <param name="context"></param>
        /// <param name="clientIp"></param>
        /// <param name="browser"></param>
        private void GetSessionInfo(HttpContext context, string clientIp, Browser browser)
        {
            var session = new SessionInfo
            {
                Application = new Application()
                {
                    EquipmentId = _configuration["SessionSettings:EquipmentId"] ?? string.Empty,
                    Version = _configuration["SessionSettings:Version"] ?? string.Empty
                },
                Connection = new Connection()
                {
                    IpAddress = clientIp,
                    Port = Convert.ToInt32(_configuration["SessionSettings:Port"] ?? "0")
                },
                Type = Convert.ToInt32(_configuration["SessionSettings:Type"] ?? "0"),
                Browser = new Browser()
                {
                    Name = browser.Name,
                    Version = browser.Version,
                    Type = Convert.ToInt32(_configuration["SessionSettings:BrowserType"] ?? "0")
                }
            };

            context.Items["Session"] = session;
        }

        /// <summary>
        /// Gets the browser information.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static Browser GetBrowserInfo(HttpContext context)
        {
            var userAgent = context.Request.Headers["User-Agent"].ToString();
            var browserRegex = new Regex(@"(?<browser>[a-zA-Z]+)/(?<version>[\d\.]+)", RegexOptions.IgnoreCase);

            var matchCollection = browserRegex.Matches(userAgent);
            var browser = new Browser();
            if (matchCollection.Count > 0)
            {
                foreach (Match match in matchCollection)
                {
                    string name = match.Groups["browser"].Value;
                    string version = match.Groups["version"].Value;

                    if (name.Equals("Chrome", StringComparison.OrdinalIgnoreCase) ||
                        name.Equals("Firefox", StringComparison.OrdinalIgnoreCase) ||
                        name.Equals("Edge", StringComparison.OrdinalIgnoreCase) ||
                        name.Equals("Safari", StringComparison.OrdinalIgnoreCase) ||
                        name.Equals("Opera", StringComparison.OrdinalIgnoreCase))
                    {
                        browser.Name = name;
                        browser.Version = version;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(browser.Name) && matchCollection.Count > 0)
                {
                    browser.Name = matchCollection[0].Groups["browser"].Value;
                    browser.Version = matchCollection[0].Groups["version"].Value;
                }
            }

            return browser;
        }

        /// <summary>
        /// Gets the client IP address.
        /// </summary>
        /// <returns></returns>
        protected string GetClientIpAddress()
        {
            var context = _httpContextAccessor.HttpContext;
            string ipAddress = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }
    }
}
