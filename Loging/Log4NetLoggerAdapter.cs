using log4net;
using Microsoft.Extensions.Logging;

namespace Loging
{
    internal class Log4NetLoggerAdapter : ILogger
    {
        private readonly ILog _logger;

        public Log4NetLoggerAdapter(ILog logger)
        {
            _logger = logger;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            switch (logLevel)
            {
                case LogLevel.Information:
                    _logger.Info(state.ToString());
                    break;
                case LogLevel.Warning:
                    _logger.Warn(state.ToString());
                    break;
                case LogLevel.Debug:
                    _logger.Debug(state.ToString());
                    break;
                case LogLevel.Error:
                    _logger.Error(state.ToString());
                    break;
            }
        }
    }
}
