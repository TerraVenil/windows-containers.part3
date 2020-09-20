using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace ImageYRotator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:5000")
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
