using Expect.Registry.View.Pages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
	/// Логика взаимодействия для DocumentCreationPage.xaml
	/// </summary>
	public partial class DocumentCreationPage : Page, IBasedOnType
	{

		private Type _type;

		public Type Type
		{
			get { return _type; }
			set 
			{
				_type = value; 
				AddFields();
			}
		}


		public DocumentCreationPage()
		{
			InitializeComponent();
		}


		private void Button_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
        }

		private void AddFields()
		{
			foreach(var property in Type.GetProperties(BindingFlags.Public))
			{
				Panel.Children.Add(new TextBlock()
				{
					Text = property.Name,
					
				});
				Panel.Children.Add(new TextBox()
				{
					Name = property.Name,
				});
			}

			
		}
    }
}
