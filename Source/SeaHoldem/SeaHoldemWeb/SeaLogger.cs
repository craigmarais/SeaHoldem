using NLog;

namespace SeaHoldemLogic
{
    internal class SeaLogger : ISeaLogger
    {
        readonly NLog.ILogger _logger;

        public SeaLogger()
        {
            _logger = LogManager.GetCurrentClassLogger();
            _logger.Debug("Logger initialized");
        }

        public void Trace(string message)
        {
            _logger.Trace(message);
        }
        public void Debug(string message)
        {
            _logger.Debug(message);
        }
        public void Info(string message)
        {
            _logger.Info(message);
        }
        public void Warn(string message)
        {
            _logger.Warn(message);
        }
        public void Error(string message)
        {
            _logger.Error(message);
        }
        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }
    }
}
