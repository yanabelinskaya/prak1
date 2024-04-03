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

            ProductDgr.Columns[1].Header = "Название продукта";
            ProductDgr.Columns[2].Header = "Описание продукта";
            ProductDgr.Columns[3].Header = "Цена";
            ProductDgr.Columns[5].Header = "Название пекарни";
            ProductDgr.Columns[6].Header = "Адрес пекарни";
            ProductDgr.Columns[7].Header = "Рейтинг пекарни";
            ProductDgr.Columns[9].Header = "Дата доставки";
            ProductDgr.Columns[10].Header = "Адрес доставки";
            ProductDgr.Columns[11].Header = "Количество";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
