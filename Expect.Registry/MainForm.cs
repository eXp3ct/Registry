using Expect.Registry.Infrastructure.Commands.LoadRegestry;
using Expect.Registry.Infrastructure.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Expect.Registry
{
	public partial class MainForm : Form
	{
		private readonly IMediator _mediator;
		private readonly IConfiguration _configuration;

		public MainForm(IMediator mediator, IConfiguration configuration)
		{
			InitializeComponent();
			_mediator = mediator;
			_configuration = configuration;
		}

		private async Task SetRegestry(RegistryType type)
		{
			var query = new LoadRegistryQuery(type, _configuration);

			var docs = await _mediator.Send(query);

			bindingSource.DataSource = docs;
			dataGridView1.DataSource = bindingSource;
		}

		private async void LoadBasicRegistry(object sender, EventArgs e)
		{
			await SetRegestry(RegistryType.Basic);
		}

		private async void LoadIncomingRegistry(object sender, EventArgs e)
		{
			await SetRegestry(RegistryType.Incoming);
		}
	}
}