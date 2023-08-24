using Expect.Registry.View.Pages.Interfaces;
using System;
using System.Windows.Controls;

namespace Expect.Registry.View.Factories.DocumentCreationFactory
{
	public class CreationFactory<TPage> : IPageFactory<TPage> where TPage : Page, IBasedOnType
	{
		private readonly Func<TPage> _factory;

		public CreationFactory(Func<TPage> factory)
		{
			_factory = factory;
		}

		public TPage Create(object document)
		{
			var page = _factory();

			page.AddFields(document);

			return page;
		}
	}
}