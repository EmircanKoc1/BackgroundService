
using meh = Microsoft.Extensions.Hosting;

namespace BackgroundService.API.BackgroundServices
{
    public class BGLogService : meh.BackgroundService
    {

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Started");

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {

            Console.WriteLine("Stopped");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                PrintConsole();
                await Task.Delay(1000);
            }

        }

        void PrintConsole() => Console.WriteLine("exetuing");

    }
}
