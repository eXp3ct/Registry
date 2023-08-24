using Expect.Registry.View.Pages.Interfaces;
using System.Windows.Controls;

namespace Expect.Registry.View.Factories.DocumentCreationFactory
{
	public interface IPageFactory<TPage> where TPage : Page, IBasedOnType
	{
		public TPage Create(object document);
	}
}