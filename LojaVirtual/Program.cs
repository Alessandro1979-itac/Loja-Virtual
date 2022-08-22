using LojaVirtual.Libraries.Bug;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace LojaVirtual
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CurrentDirectoryHelpers.SetCurrentDirectory();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
