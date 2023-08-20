using Expect.Registry.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Expect.Registry.Data
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseNpgsql(connectionString);
			});
			services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

			return services;
		}
	}
}