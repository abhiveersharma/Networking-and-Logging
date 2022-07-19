using Microsoft.Extensions.Logging;

namespace FileLogger
{
    /// <summary>
    /// File logger to use with our specific file naming and with our desired message structure.
    /// </summary>
    public class CustomFileLogger : ILogger
    {
        private string _fileName;

        private string _category_name;

        /// <summary>
        /// Property for _fileName member variable. 
        /// </summary>
        public string fileName
        {
            get { return this._fileName; }
            set { this._fileName = value; }
        }

        private FileStream _fileStream;

        public FileStream fileStream
        {
            get { return this._fileStream; }
            set { this._fileStream = value; }
        }

        /// <summary>
        /// Initialize file name for logging.
        /// </summary>
        /// <param name="category_name"></param>
        public CustomFileLogger(string category_name)
        {
            _category_name = category_name;
            _fileName = $"Log_CS3500_{category_name}_Assignment8";

            //_fileStream = File.Open(_fileName, FileMode.Append, FileAccess.Write);
        }

        /// <summary>
        /// Nesting scopes. Scopes can have information about where they came from. So put extra information into a log entry.
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="state"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method that appends the text onto the file for logging. Append properly opens and closes the file.
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="logLevel"></param>
        /// <param name="eventId"></param>
        /// <param name="state"></param>
        /// <param name="exception"></param>
        /// <param name="formatter"></param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            //ShowTimeAndThreadClass timeAndThread = new ShowTimeAndThreadClass();

            //Add current time and the logging level to the log string we add to logger file. Just appends to anything already logged there:
            string logInfo = $": {logLevel.ToString()} :" + formatter(state, exception) + Environment.NewLine; //May need current thread too
            logInfo = ShowTimeAndThreadClass.ShowTimeAndThread(logInfo); //Appends time and thread info onto loginfo
            File.AppendAllText(_fileName, logInfo);
        }
    }
}