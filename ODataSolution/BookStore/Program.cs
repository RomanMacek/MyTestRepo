
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                             //  .ConfigureLogging(builder => builder.AddFile())
                             //.ConfigureLogging((context, builder) =>
                             //      {
                             //          builder.AddFile(opts =>
                             //          {
                             //              context.Configuration.GetSection("FileLoggingOptions").Bind(opts);

                             //          });
                             //      })
                             //.ConfigureLogging(builder => builder.AddFile(opts =>
                             //{
                //    opts.FileName = "app-logs-";
                //    opts.FileSizeLimit = 1024 * 1024;

                //}))
                .ConfigureLogging(builder => builder.AddFile(options => {
                    options.FileName = "diagnostics-"; // The log file prefixes
                    options.LogDirectory = "LogFiles"; // The directory to write the logs
                    options.FileSizeLimit = 20 * 1024 * 1024; // The maximum log file size (20MB here)
                }))
                .UseStartup<Startup>();
    }
}
