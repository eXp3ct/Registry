using Expect.Registry.Domain.Models;
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

namespace Expect.Registry.View.CustomControls.DocumentInforamtion
{
    /// <summary>
    /// Логика взаимодействия для DocumentInformation.xaml
    /// </summary>
    public partial class DocumentInformation : UserControl
    {


        public BasicDocument Document
        {
            get { return (BasicDocument)GetValue(DocumentProperty); }
            set { SetValue(DocumentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DocumentProperty =
            DependencyProperty.Register("Document", typeof(BasicDocument), typeof(DocumentInformation));



        public DocumentInformation()
        {
            InitializeComponent();
        }
    }
}
