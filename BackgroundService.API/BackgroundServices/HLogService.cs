
using st = System.Threading;
namespace BackgroundService.API.BackgroundServices
{
    public class HLogService : IHostedService, IDisposable
    {
        private readonly ILogger<HLogService> _loggerService;
        private st.Timer? _timer;
        private int executionCount = 0;

        public HLogService(ILogger<HLogService> loggerService)
        {
            _loggerService = loggerService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {


            _loggerService.LogWarning("started hosted service");

            _timer = new Timer(
            callback: (state) =>
            {
                Interlocked.Increment(ref executionCount);

                _loggerService.LogWarning($"Executed count : {executionCount}");
            },
            state: "state",
            dueTime: TimeSpan.FromSeconds(0),
            period: TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _loggerService.LogWarning("stopped hosted service");

            _timer?.Change(
                dueTime: Timeout.Infinite,
                period: 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _timer = null;
        }
    }
}
