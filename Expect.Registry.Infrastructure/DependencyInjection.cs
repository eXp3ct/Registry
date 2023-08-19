using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Expect.Registry.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			return services;
		}
	}
}