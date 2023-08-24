using Expect.Registry.View.Pages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Expect.Registry.View.Factories.DocumentCreationFactory
{
	public class CreationFactory<TPage> : ICreationFactory<TPage> where TPage : Page, IBasedOnType
	{
		private readonly Func<TPage> _factory;

		public CreationFactory(Func<TPage> factory)
		{
			_factory = factory;
		}

		public TPage Create(Type documentType)
		{
			var page = _factory();

			page.Type = documentType;

			return page;
		}
	}
}
