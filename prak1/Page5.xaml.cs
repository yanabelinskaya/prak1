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
    public partial class Page5 : Page
    {
        //ef
        private PrakticaEntities context = new PrakticaEntities();
        public Page5()
        {
            InitializeComponent();
            ProductsDgr.ItemsSource = context.Product.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Product c = new Product();
            c.productName = NameTbx1.Text;

            context.Product.Add(c);

            context.SaveChanges();
            ProductsDgr.ItemsSource = context.Product.ToList();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (ProductsDgr.SelectedItem != null)
            {
                var selected = ProductsDgr.SelectedItem as Product;

                selected.productName = NameTbx1.Text;
                context.SaveChanges();
                ProductsDgr.ItemsSource = context.Product.ToList();
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            if (ProductsDgr.SelectedItem != null)
            {
                context.Product.Remove(ProductsDgr.SelectedItem as Product);
                context.SaveChanges();
                ProductsDgr.ItemsSource = context.Product.ToList();
            }
        }

        private void DeliveryDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsDgr.SelectedItem != null)
            {
                var selected = ProductsDgr.SelectedItem as Product;

                NameTbx1.Text = selected.productName;
            }
        }
    }
}
