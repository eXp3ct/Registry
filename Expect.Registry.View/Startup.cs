using Expect.Registry.Data;
using Expect.Registry.Infrastructure;
using Expect.Registry.View.Factories.DocumentCreationFactory;
using Expect.Registry.View.Pages;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect.Registry.View
{
	public static class Startup
	{
		public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddInfrastructure();
			services.AddPersistance(configuration);
			services.AddScoped<DataPage>();
			services.AddCreationFactory<DocumentCreationPage>();
		}
	}
}
