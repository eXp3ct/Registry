using Expect.Registry.Infrastructure.Enums;
using MediatR;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Expect.Registry.View.Windows.CreateDocument
{
	/// <summary>
	/// Логика взаимодействия для CreateDocumentWindow.xaml
	/// </summary>
	public partial class CreateDocumentWindow : Window
	{
		private readonly IMediator _mediator;

		public CreateDocumentWindow(RegistryType type, IMediator mediator)
		{
			InitializeComponent();

			if (type == RegistryType.Basic)
			{
				DocumentTemplateContainer.ContentTemplate = (DataTemplate)Resources["BasicDocumentTemplate"];
				Title = "Создание базового документа";
			}
			else if (type == RegistryType.Incoming)
			{
				DocumentTemplateContainer.ContentTemplate = (DataTemplate)Resources["IncomingDocumentTemplate"];
				Title = "Создание входящего документа";
			}

			_mediator = mediator;
		}

		private void CreateButton_Click(object sender, RoutedEventArgs e)
		{
			var nameTextBox = FindName("NameTextBox") as TextBox;
			var kindTextBox = FindName("KindTextBox") as TextBox;
			var subjectTextBox = FindName("SubjectTextBox") as TextBox;
			var documentTextBox = FindName("DocumentNumberTextBox") as TextBox;



			DialogResult= true;
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			e.Cancel = true;

			Hide();
		}
	}
}
