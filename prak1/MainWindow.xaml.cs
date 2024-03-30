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

namespace prak1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BakeryClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page1();
        }
        private void ProductsClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page2();
        }
        private void DeliveryClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page3();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
