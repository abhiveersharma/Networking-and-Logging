using Microsoft.Extensions.Logging;

namespace FileLogger
{
    /// <summary>
    /// Custom file logger provider that provides services with our custome file logger object.
    /// </summary>
    public class CustomFileLogProvider : ILoggerProvider
    {
        CustomFileLogger fileLogger = new CustomFileLogger("information");

        /// <summary>
        /// Create new file logger according to our implementation.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            return new CustomFileLogger(categoryName);
        }

        public void Dispose()
        {
        }
    }
}
