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
            bakeryCbx1.ItemsSource = context.Bakery.ToList();
            NameTbx4.ItemsSource = context.Bakery.ToList();
            NameTbx4.SelectedIndex = 0;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void DeliveryDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsDgr.SelectedItem != null)
            {
                var selected = ProductsDgr.SelectedItem as Product;

                NameTbx1.Text = selected.productName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductsDgr.ItemsSource = context.Product.ToList().Where(item => item.productName.Contains(Searchtxt.Text));

        }

        private void bakeryCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(bakeryCbx1.SelectedItem != null)
            {
                var selectedBakery = bakeryCbx1.SelectedItem as Bakery;
                var selectedBakeryId = selectedBakery.bakery_id;
                ProductsDgr.ItemsSource = context.Product.ToList().Where(item => item.bakery_id == selectedBakeryId);

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ProductsDgr.ItemsSource = context.Product.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var newProduct = new Product
            {
                productName = NameTbx1.Text,
                productDescription = NameTbx2.Text,
                price = decimal.Parse(NameTbx3.Text),
                bakery_id = (int)NameTbx4.SelectedValue,
            };
            context.Product.Add(newProduct);
            context.SaveChanges();
            ProductsDgr.ItemsSource = context.Product.ToList();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (ProductsDgr.SelectedItem != null)
            {
                var selectedProduct = ProductsDgr.SelectedItem as Product;
                selectedProduct.productName = NameTbx1.Text;
                selectedProduct.productDescription = NameTbx2.Text;
                selectedProduct.price = decimal.Parse(NameTbx3.Text);
                selectedProduct.bakery_id = (int)NameTbx4.SelectedValue;

                context.SaveChanges();
                ProductsDgr.Items.Refresh();

            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (ProductsDgr.SelectedItem != null)
            {
                var selectedProduct = ProductsDgr.SelectedItem as Product;
                context.Product.Remove(selectedProduct);
                context.SaveChanges();
                ProductsDgr.ItemsSource = context.Product.ToList();
            }
        }

        private void ProductsDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsDgr.SelectedItem != null)
            {
                var selectedProduct = ProductsDgr.SelectedItem as Product;
                NameTbx1.Text = selectedProduct.productName;
                NameTbx2.Text = selectedProduct.productDescription;
                NameTbx3.Text = selectedProduct.price.ToString();

                Bakery selectedBakery = context.Bakery.FirstOrDefault(c => c.bakery_id == selectedProduct.bakery_id);
                if (selectedBakery != null)
                {
                    NameTbx4.SelectedItem = selectedBakery;
                }
            }
        }
    }
}
