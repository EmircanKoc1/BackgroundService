
using BackgroundService.API.BackgroundServices;
using BackgroundService.API.Services.Implementations;
using BackgroundService.API.Services.Interfaces;

namespace BackgroundService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IConsoleLogService, ConsoleLogService>();

            builder.Services.AddHostedService<BGLogService>();
            builder.Services.AddHostedService<HLogService>();
            builder.Services.AddHostedService<BackgroundConsoleLogService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
