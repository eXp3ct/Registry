using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Registry.View
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            var app = host.Services.GetRequiredService<App>();
            app?.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, configBuilder) =>
                {
					configBuilder
						.SetBasePath(context.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("config.json", true, true);
                })
                .ConfigureServices((context, services) =>
                {
					services.AddSingleton<App>();
					services.AddSingleton<MainWindow>();
					services.ConfigureServices(context.Configuration);
				});
    }
}
