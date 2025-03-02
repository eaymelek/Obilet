using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logging.Log4Net
{
    /// <summary>
    /// Represents a file logger.
    /// </summary>
    public class FileLogger : LoggerServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        public FileLogger() : base("JsonFileLogger")
        {
        }
    }
}
