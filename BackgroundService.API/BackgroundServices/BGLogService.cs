
using meh = Microsoft.Extensions.Hosting;

namespace BackgroundService.API.BackgroundServices
{
    public class BGLogService : meh.BackgroundService
    {
        private readonly ILogger<BGLogService> _loggerService;

        public BGLogService(ILogger<BGLogService> loggerService)
        {
            _loggerService = loggerService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _loggerService.LogError("started bglogservice");

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {

            _loggerService.LogError("stopped bglogservice");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                Log();
                await Task.Delay(1000);
            }

        }

        void Log() => _loggerService.LogError("executed bglogservice");
    }
}
