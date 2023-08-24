using Expect.Registry.View.Pages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Expect.Registry.View.Factories.DocumentCreationFactory
{
	public interface ICreationFactory<TPage> where TPage : Page, IBasedOnType
	{
		public TPage Create(Type documentType);
	}
}
