using Expect.Registry.Domain.Interfaces;
using Expect.Registry.Domain.Models;
using Expect.Registry.Domain.ViewModels;
using Expect.Registry.Domain.ViewModels.Interfaces;
using Expect.Registry.Infrastructure.Commands.LoadRegestry;
using Expect.Registry.Infrastructure.Enums;
using Expect.Registry.View.Factories.DocumentCreationFactory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Expect.Registry.View.Pages
{
	/// <summary>
	/// Логика взаимодействия для DataPage.xaml
	/// </summary>
	public partial class DataPage : Page
	{
		private readonly IMediator _mediator;
		private readonly ICreationFactory<DocumentCreationPage> _creationFactory;
		private Type? _regisrtyType = null;
		public DataPage(IMediator mediator, ICreationFactory<DocumentCreationPage> creationFactory)
		{
			InitializeComponent();
			_mediator = mediator;
			_creationFactory = creationFactory;
		}
		private async Task SetRegistry<TViewModel>() 
			where TViewModel : IViewModel
		{
			_regisrtyType = typeof(TViewModel);
			var query = new LoadRegistryQuery<TViewModel>();

			var docs = await _mediator.Send(query);
			
			DataGrid.ItemsSource = docs;
		}

		private async void BasicDocumentButton_Click(object sender, RoutedEventArgs e)
		{
			await SetRegistry<BasicDocumentViewModel>();
		}

		private async void IncomingDocumentButton_Click(object sender, RoutedEventArgs e)
		{
			await SetRegistry<IncomingDocumentViewModel>();
		}

		private void CreateDocument_Click(object sender, RoutedEventArgs e)
		{
			if(_regisrtyType == null)
			{
				MessageBox.Show("Выберите тип реестра", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			NavigationService.Navigate(_creationFactory.Create(_regisrtyType));
		}
    }
}
