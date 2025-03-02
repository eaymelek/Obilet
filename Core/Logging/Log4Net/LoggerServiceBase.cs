using log4net;
using log4net.Repository;
using System.Reflection;
using System.Xml;

namespace Core.Logging.Log4Net
{
    /// <summary>
    /// Represents a logger service base.
    /// </summary>
    public class LoggerServiceBase
    {
        private ILog _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerServiceBase"/> class.
        /// </summary>
        /// <param name="name"></param>
        public LoggerServiceBase(string name)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(File.OpenRead("log4net.config"));

            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);

            _log = LogManager.GetLogger(loggerRepository.Name, name);
        }

        /// <summary>
        /// Checks if the given log level is enabled.
        /// </summary>
        public bool IsInfoEnabled => _log.IsInfoEnabled;

        /// <summary>
        /// Checks if the given log level is enabled.
        /// </summary>
        public bool IsDebugEnabled => _log.IsDebugEnabled;

        /// <summary>
        /// Checks if the given log level is enabled.
        /// </summary>
        public bool IsWarnEnabled => _log.IsWarnEnabled;

        /// <summary>
        /// Checks if the given log level is enabled.
        /// </summary>
        public bool IsFatalEnabled => _log.IsFatalEnabled;

        /// <summary>
        /// Checks if the given log level is enabled.
        /// </summary>
        public bool IsErrorEnabled => _log.IsErrorEnabled;

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <param name="logMessage"></param>
        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
                _log.Info(logMessage);
        }

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <param name="logMessage"></param>
        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
                _log.Debug(logMessage);
        }
        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <param name="logMessage"></param>
        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
                _log.Warn(logMessage);
        }
        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <param name="logMessage"></param>
        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
                _log.Fatal(logMessage);
        }

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <param name="logMessage"></param>
        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
                _log.Error(logMessage);
        }
    }
}
