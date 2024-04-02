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
using prak1.PrakticaDataSetTableAdapters;

namespace prak1
{
    public partial class Page11 : Page
    {
        ProductTableAdapter product = new ProductTableAdapter();
        public Page11()
        {
            InitializeComponent();
            ProductDgr.ItemsSource = product.GetFullInfo();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProductDgr.Columns[0].Visibility = Visibility.Collapsed;
            ProductDgr.Columns[4].Visibility = Visibility.Collapsed;
            ProductDgr.Columns[8].Visibility = Visibility.Collapsed;
            ProductDgr.Columns[12].Visibility = Visibility.Collapsed;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
