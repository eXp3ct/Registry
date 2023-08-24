using Expect.Registry.Domain.ViewModels;
using Expect.Registry.Domain.ViewModels.Interfaces;
using Expect.Registry.Infrastructure.Commands.LoadRegestry;
using Expect.Registry.View.Factories.DocumentCreationFactory;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Expect.Registry.View.Pages
{
	/// <summary>
	/// Логика взаимодействия для DataPage.xaml
	/// </summary>
	public partial class DataPage : Page
	{
		private readonly IMediator _mediator;
		private readonly IPageFactory<DocumentCreationPage> _creationFactory;
		private readonly IPageFactory<DocumentPage> _pageFactory;
		private Type? _regisrtyType = null;

		public DataPage(IMediator mediator, IPageFactory<DocumentCreationPage> creationFactory, IPageFactory<DocumentPage> pageFactory)
		{
			InitializeComponent();
			_mediator = mediator;
			_creationFactory = creationFactory;
			_pageFactory = pageFactory;
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
			if (_regisrtyType == null)
			{
				MessageBox.Show("Выберите тип реестра", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			NavigationService.Navigate(_creationFactory.Create(_regisrtyType));
		}

		private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var document = DataGrid.SelectedItem;

			NavigationService.Navigate(_pageFactory.Create(document));
		}
	}
}