using BackgroundService.API.Services.Interfaces;

namespace BackgroundService.API.Services.Implementations
{
    public class ConsoleLogService : IConsoleLogService
    {
        public void Log(string message)
        {
            Console.WriteLine($"Log service executed : {message}");
        }
    }
}
