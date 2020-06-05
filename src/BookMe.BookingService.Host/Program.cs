using System;
using System.Reflection;
using BookMe.BookingService.Host.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace BookMe.BookingService.Host
{
    public class Program
    {
        public static void Main (string[] args)
        {
            try
            {
                LoggingExtensions.ConfigureLogging();

                CreateWebHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                Log.Fatal($"Failed to start {Assembly.GetExecutingAssembly().GetName().Name}", ex);
                throw;
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
		    .UseSerilog();
    }
}