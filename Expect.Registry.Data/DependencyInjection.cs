using Expect.Registry.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Expect.Registry.Data
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

			return services;
		}
	}
}