using NLog;

namespace Logger
{
    public class Logger : ILogger
    {
        private static NLog.ILogger logger;

        public Logger()
        {
            logger = LogManager.GetLogger("Logger");
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }
    }
}