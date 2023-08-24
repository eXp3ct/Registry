using Expect.Registry.View.Pages.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;

namespace Expect.Registry.View.Factories.DocumentCreationFactory
{
	public static class DependencyInjection
	{
		public static void AddCreationFactory<TPage>(this IServiceCollection services) where TPage : Page, IBasedOnType
		{
			services.AddTransient<TPage>();
			services.AddSingleton<Func<TPage>>(x => () => x.GetRequiredService<TPage>());
			services.AddSingleton<IPageFactory<TPage>, CreationFactory<TPage>>();
		}
	}
}