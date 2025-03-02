using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logging.Log4Net
{
    /// <summary>
    /// Represents a serializable log event.
    /// </summary>
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableLogEvent"/> class.
        /// </summary>
        /// <param name="loggingEvent"></param>
        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        /// <summary>
        /// Gets the timestamp of the log event.
        /// </summary>
        public object Message => _loggingEvent.MessageObject;
    }
}
