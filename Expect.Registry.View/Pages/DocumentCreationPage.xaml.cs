using Expect.Registry.Domain.ViewModels;
using Expect.Registry.Infrastructure.Commands.CreateDocument;
using Expect.Registry.View.Pages.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Expect.Registry.View.Pages
{
	/// <summary>
	/// Логика взаимодействия для DocumentCreationPage.xaml
	/// </summary>
	public partial class DocumentCreationPage : Page, IBasedOnType
	{
		private readonly Dictionary<PropertyInfo, TextBox> _documentValues = new();
		private readonly IMediator _mediator;

		private Type? _docType = null;

		public DocumentCreationPage(IMediator mediator)
		{
			InitializeComponent();
			_mediator = mediator;
		}

		private void GoBackButtonClick(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}

		public void AddFields(object document)
		{
			_docType = document.GetType();
			foreach (var property in document.GetType().GetProperties())
			{
				if (property.Name == "Id" || property.Name == "Discriminator" || property.Name == "DocumentKind" || property.Name == "CreatedDate")
					continue;

				Panel.Children.Add(new TextBlock()
				{
					Text = property.Name,
					Height = 35f,
					VerticalAlignment = VerticalAlignment.Center
				});
				var textBox = new TextBox()
				{
					Name = property.Name,
					Height = 35f,
				};
				Panel.Children.Add(textBox);

				_documentValues.Add(property, textBox);
			}
		}

		private async void CreateDocumentButtonClick(object sender, RoutedEventArgs e)
		{
			if (_docType == null)
				return;

			var document = Activator.CreateInstance(_docType);

			foreach (var (prop, value) in _documentValues)
			{
				document!.GetType()!.GetProperty(prop.Name)!.SetValue(document, value.Text, null);
			}

			var query = new CreateDocumentQuery((BasicDocumentViewModel)document);

			await _mediator.Send(query);

			MessageBox.Show("Документ успешно создан!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

			NavigationService.GoBack();
		}
	}
}