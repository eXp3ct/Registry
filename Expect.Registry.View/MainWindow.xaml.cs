using Expect.Registry.Infrastructure.Commands.LoadRegestry;
using Expect.Registry.Infrastructure.Enums;
using Expect.Registry.View.Windows.CreateDocument;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Expect.Registry.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IMediator _mediator;
		private RegistryType RegistryType { get; set; }
		public MainWindow(IMediator mediator)
		{
			InitializeComponent();
			_mediator = mediator;
		}

		private async Task SetRegistry(RegistryType type)
		{
			RegistryType = type;
			var query = new LoadRegistryQuery(type);

			var docs = await _mediator.Send(query);

			DataGrid.ItemsSource = docs;
		}

		private async void BasicDocumentButton_Click(object sender, RoutedEventArgs e)
		{
			await SetRegistry(RegistryType.Basic);
		}

		private async void IncomingDocumentButton_Click(object sender, RoutedEventArgs e)
		{
			await SetRegistry(RegistryType.Incoming);
		}

		private void CreateDocument_Click(object sender, RoutedEventArgs e)
		{
			var creationWindow = new CreateDocumentWindow(RegistryType, _mediator)
			{
				Owner = this,
			};

			creationWindow.ShowDialog();
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
