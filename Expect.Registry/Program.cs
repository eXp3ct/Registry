using Expect.Registry.Data;
using Expect.Registry.Infrastructure;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Expect.Registry
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			ApplicationConfiguration.Initialize();

			var services = new ServiceCollection();

			var configurationBuilder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("config.json", optional: true, reloadOnChange: true);

			var configuration = configurationBuilder.Build();

			ConfigureServices(services, configuration);

			var serviceProvider = services.BuildServiceProvider();

			var mediator = serviceProvider.GetRequiredService<IMediator>();
			using var form = new MainForm(mediator, configuration);

			Application.Run(form);
		}

		private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddPersistance(configuration);
			services.AddInfrastructure();
		}
	}
}