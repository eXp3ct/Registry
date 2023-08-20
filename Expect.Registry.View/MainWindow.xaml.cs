using Expect.Registry.Infrastructure.Commands.LoadRegestry;
using Expect.Registry.Infrastructure.Enums;
using MediatR;
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
		public MainWindow(IMediator mediator)
		{
			InitializeComponent();
			_mediator = mediator;
		}

		private async Task SetRegistry(RegistryType type)
		{
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
	}
}
