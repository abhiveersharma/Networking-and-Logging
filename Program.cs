using FileLogger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatServer
{
    /// <summary>
    /// Run the GUI for the chat server and use its file logger.
    /// </summary>
    internal static class Program
    {
        private static void ConfigureServices(ServiceCollection services)
        {
            using (CustomFileLogProvider provider = new CustomFileLogProvider())
            {
                services.AddLogging(configure =>
                {
                    configure.AddConsole();
                    configure.AddDebug();   //We don't have a console in windows form so have logging happen through debug sync
                    configure.AddProvider(new CustomFileLogProvider()); //Added after the next line about min level. Actually log to file now instead of console/debug
                    configure.SetMinimumLevel(LogLevel.Information); //Min level is normally information, but we want debug!
                    configure.AddEventLog(); //Allow logging to Windows Event Viewer (make sure to refresh to see it appear!)

                });
            }

            services.AddScoped<ChatServerForm>();
        }


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using ServiceProvider serviceProvider = services.BuildServiceProvider(); //TODO: Correct??
            var gui = serviceProvider.GetRequiredService<ChatServerForm>();
            Application.Run(gui);

        }
    }
}