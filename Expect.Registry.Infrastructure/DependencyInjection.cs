using Expect.Registry.Domain.Interfaces;
using Expect.Registry.Domain.Models;
using Expect.Registry.Domain.ViewModels;
using Expect.Registry.Domain.ViewModels.Interfaces;
using Expect.Registry.Infrastructure.Commands.LoadRegestry;
using MediatR;
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
			services.AddGenericHandlers<BasicDocument, BasicDocumentViewModel>();
			services.AddGenericHandlers<IncomingDocument, IncomingDocumentViewModel>();
			return services;
		}

		private static IServiceCollection AddGenericHandlers<TDocumentType, TViewModel>(this IServiceCollection services)
			where TDocumentType : IHaveId
			where TViewModel : IViewModel
		{
			services.AddTransient<
				IRequestHandler<LoadRegistryQuery<TViewModel>, IEnumerable<TViewModel>>,
				LoadRegistryQueryHandler<TDocumentType, TViewModel>
				>();

			return services;
		}
	}
}