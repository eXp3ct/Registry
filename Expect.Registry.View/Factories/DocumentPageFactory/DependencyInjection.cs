using Expect.Registry.View.Factories.DocumentCreationFactory;
using Expect.Registry.View.Pages.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;

namespace Expect.Registry.View.Factories.DocumentPageFactory
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPageFactory<TPage>(this IServiceCollection services) where TPage : Page, IBasedOnType
		{
			services.AddTransient<TPage>();
			services.AddTransient<Func<TPage>>(x => () => x.GetRequiredService<TPage>());
			services.AddTransient<IPageFactory<TPage>, DocumentPagesFactory<TPage>>();

			return services;
		}
	}
}