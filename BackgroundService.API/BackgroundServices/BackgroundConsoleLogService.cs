using BackgroundService.API.Services.Interfaces;
using meh = Microsoft.Extensions.Hosting;

namespace BackgroundService.API.BackgroundServices
{
    public class BackgroundConsoleLogService : meh.BackgroundService
    {
        private readonly IConsoleLogService _consoleLogService;

        public BackgroundConsoleLogService(IConsoleLogService consoleLogService)
        {
            _consoleLogService = consoleLogService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
                _consoleLogService.Log("Executed backgroundconsole log service");

            return Task.CompletedTask;
        }


    }
}
