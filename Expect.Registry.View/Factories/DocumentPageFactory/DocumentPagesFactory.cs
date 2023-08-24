using Expect.Registry.View.Factories.DocumentCreationFactory;
using Expect.Registry.View.Pages.Interfaces;
using System;
using System.Windows.Controls;

namespace Expect.Registry.View.Factories.DocumentPageFactory
{
	internal class DocumentPagesFactory<TPage> : IPageFactory<TPage> where TPage : Page, IBasedOnType
	{
		private readonly Func<TPage> _factory;

		public DocumentPagesFactory(Func<TPage> factory)
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