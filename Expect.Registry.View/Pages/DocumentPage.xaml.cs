using Expect.Registry.View.Pages.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Expect.Registry.View.Pages
{
	/// <summary>
	/// Логика взаимодействия для DocumentPage.xaml
	/// </summary>
	public partial class DocumentPage : Page, IBasedOnType
	{
		public DocumentPage()
		{
			InitializeComponent();
		}

		public void AddFields(object document)
		{
			foreach (var property in document.GetType().GetProperties())
			{
				Panel.Children.Add(new TextBlock()
				{
					Text = $"{property.Name}: ",
					Height = 35f,
					VerticalAlignment = VerticalAlignment.Center,
				});
				Panel.Children.Add(new TextBlock()
				{
					Text = property?.GetValue(document)?.ToString(),
					Height = 35f,
					VerticalAlignment = VerticalAlignment.Center,
				});
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}
	}
}