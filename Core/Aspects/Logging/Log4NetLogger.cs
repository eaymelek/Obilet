using log4net;
using Microsoft.Extensions.Logging;

namespace Core.Aspects.Logging
{
    /// <summary>
    /// Represents a logger that uses Log4Net.
    /// </summary>
    public class Log4NetLogger : ILogger
    {
        private readonly ILog _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetLogger"/> class.
        /// </summary>
        /// <param name="categoryName"></param>
        public Log4NetLogger(string categoryName)
        {
            _log = LogManager.GetLogger("JsonFileLogger");
        }

        /// <summary>
        /// Begins a logical operation scope.
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="state"></param>
        /// <returns></returns>
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        /// <summary>
        /// Checks if the given log level is enabled.
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Trace => _log.IsDebugEnabled,
                LogLevel.Debug => _log.IsDebugEnabled,
                LogLevel.Information => _log.IsInfoEnabled,
                LogLevel.Warning => _log.IsWarnEnabled,
                LogLevel.Error => _log.IsErrorEnabled,
                LogLevel.Critical => _log.IsFatalEnabled,
                _ => false,
            };
        }

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="logLevel"></param>
        /// <param name="eventId"></param>
        /// <param name="state"></param>
        /// <param name="exception"></param>
        /// <param name="formatter"></param>

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                _log.Logger.Log(typeof(Log4NetLogger), MapLogLevel(logLevel), formatter(state, exception), exception);
            }
        }

        /// <summary>
        /// Maps the log level.
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>

        private log4net.Core.Level MapLogLevel(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Trace => log4net.Core.Level.Trace,
                LogLevel.Debug => log4net.Core.Level.Debug,
                LogLevel.Information => log4net.Core.Level.Info,
                LogLevel.Warning => log4net.Core.Level.Warn,
                LogLevel.Error => log4net.Core.Level.Error,
                LogLevel.Critical => log4net.Core.Level.Fatal,
                _ => log4net.Core.Level.Info,
            };
        }
    }

    /// <summary>
    /// Represents a logger provider that uses Log4Net.
    /// </summary>
    public class Log4NetLoggerProvider : ILoggerProvider
    {
        /// <summary>
        /// Creates a logger.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            return new Log4NetLogger(categoryName);
        }

        /// <summary>
        /// Disposes the logger provider.
        /// </summary>
        public void Dispose() { }
    }
}
