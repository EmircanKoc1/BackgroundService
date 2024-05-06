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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Func<Task> func = async () =>
            {
                await Task.Delay(delay: TimeSpan.FromSeconds(1));

                _consoleLogService.Log("Executed BackgroundLogService");
            };

            while (!stoppingToken.IsCancellationRequested)
                await func.Invoke();

        }


    }
}
