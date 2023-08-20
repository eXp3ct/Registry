using Expect.Registry.Domain.ViewModels.Interfaces;
using Expect.Registry.Infrastructure.Commands.FilterDocuments;
using Expect.Registry.Infrastructure.Commands.LoadRegestry;
using Expect.Registry.Infrastructure.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Expect.Registry
{
	public partial class MainForm : Form
	{
		private readonly IMediator _mediator;
		private readonly IConfiguration _configuration;

		private RegistryType CurrentRegistryType { get; set; }

		public MainForm(IMediator mediator, IConfiguration configuration)
		{
			InitializeComponent();
			_mediator = mediator;
			_configuration = configuration;
		}

		private async Task SetRegistry(RegistryType type)
		{
			CurrentRegistryType = type;
			var query = new LoadRegistryQuery(type, _configuration);

			await SetRegistry(query);
		}

		private async Task SetRegistry(IRequest<IEnumerable<IViewModel>> request)
		{
			var docs = await _mediator.Send(request);

			bindingSource.DataSource = docs;
			dataGridView1.DataSource = bindingSource;
		}

		private async void LoadBasicRegistry(object sender, EventArgs e)
		{
			await SetRegistry(RegistryType.Basic);
		}

		private async void LoadIncomingRegistry(object sender, EventArgs e)
		{
			await SetRegistry(RegistryType.Incoming);
		}

		private async void FilterDocumentsByName(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != '\r')
				return;

			var filterQuery = new FilterDocumentsByNameQuery(filterByNameTextBox.Text, bindingSource.DataSource as IEnumerable<IViewModel>);

			await SetRegistry(filterQuery);
		}

		private void StartCreatingDocument(object sender, EventArgs e)
		{

		}
	}
}