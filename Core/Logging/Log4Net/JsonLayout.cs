using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core.Logging.Log4Net
{
    /// <summary>
    /// Represents a JSON layout.
    /// </summary>
    public class JsonLayout : LayoutSkeleton
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonLayout"/> class.
        /// </summary>
        public override void ActivateOptions()
        {

        }

        /// <summary>
        /// Formats the logging event.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="loggingEvent"></param>
        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent = new SerializableLogEvent(loggingEvent);
            var json = JsonConvert.SerializeObject(logEvent, Formatting.Indented);
            writer.WriteLine(json);
        }
    }
}
