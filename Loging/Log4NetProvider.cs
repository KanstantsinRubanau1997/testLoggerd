using log4net;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Loging
{
    internal class Log4NetProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            var log4NetLogger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
            var log4NetLoggerAdapter = new Log4NetLoggerAdapter(log4NetLogger);

            return log4NetLoggerAdapter;
        }

        public void Dispose()
        {
        }
    }
}
