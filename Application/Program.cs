using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

class Program
{
    static void Main(string[] args)
    {
        // Set up DI
        var serviceProvider = new ServiceCollection()
            .AddLogging(configure => configure.AddConsole())
            .AddSingleton<Logger>()
            .AddSingleton<App>() // Register your main application class
            .BuildServiceProvider();

        // Configure logging
        var logger = serviceProvider.GetService<ILogger<Program>>();
        logger.LogInformation("Starting application");

        // Run the application
        var app = serviceProvider.GetService<App>();
        app.Run();

        logger.LogInformation("Ending application");
    }
}