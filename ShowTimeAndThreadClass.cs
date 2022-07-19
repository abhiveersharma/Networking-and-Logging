namespace FileLogger
{
    /// <summary>
    /// Extensions class to use with our custom file logger. Helps attach the current time and thread to the logging information.
    /// </summary>
    public class ShowTimeAndThreadClass
    {
        /// <summary>
        /// Appends the current time and date and also the current thread to a string. To be used for append this info
        /// to logging entries.
        /// </summary>
        /// <param name="mssgToAppendTo"></param>
        /// <returns></returns>
        public static string ShowTimeAndThread(string mssgToAppendTo)
        {
            return DateTime.Now.ToString() + Thread.CurrentThread.ManagedThreadId + mssgToAppendTo;
        }
    }
}