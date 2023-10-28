using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Loging
{
    public class HostedService : IHostedService
    {
        private readonly ILogger _logger;

        public HostedService(ILogger<HostedService> logger)
        {
            this._logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this._logger.LogError("ERRRRRRRRRRRRRRRR");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
