using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using prak1.PrakticaaDataSetTableAdapters;

namespace prak1
{
    public partial class Page2 : Page
    {
        // Датасет
        ProductTableAdapter products = new ProductTableAdapter();
        BakeryTableAdapter bakery = new BakeryTableAdapter();

        public Page2()
        {
            InitializeComponent();
            ProductsDataGrid.ItemsSource = products.GetData();
            bakeryCbx1.ItemsSource = bakery.GetData();
            bakeryCbx1.DisplayMemberPath = "bakeryName";
            NameTbx4.ItemsSource = bakery.GetData();
            NameTbx4.DisplayMemberPath = "bakeryName";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ProductsDataGrid.ItemsSource = products.SearchProduct(Searchtxt.Text);
        }

        private void bakeryCbx1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bakeryCbx1.SelectedItem != null)
            {
                var product_id = (int)(bakeryCbx1.SelectedItem as DataRowView).Row[0];
                ProductsDataGrid.ItemsSource = products.FilterByBakery(product_id);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ProductsDataGrid.ItemsSource = products.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (NameTbx4.SelectedItem != null)
            {
                var bakery_id = (int)(NameTbx4.SelectedItem as DataRowView).Row[0];
                products.InsertQuery(NameTbx1.Text, NameTbx2.Text, decimal.Parse(NameTbx3.Text), bakery_id);
                ProductsDataGrid.ItemsSource = products.GetData();
            }
        }

        private void NameTbx4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NameTbx4.SelectedItem != null)
            {
                var bakery_id = (int)(NameTbx4.SelectedItem as DataRowView).Row[0];
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = ProductsDataGrid.SelectedItem as DataRowView;
                object product_id = selectedRow.Row[0];
                int bakery_id = (int)(NameTbx4.SelectedItem as DataRowView).Row[0];
                products.UpdateQuery(NameTbx1.Text, NameTbx2.Text, decimal.Parse(NameTbx3.Text), bakery_id, Convert.ToInt32(product_id));
                ProductsDataGrid.ItemsSource =products.GetData();
            }

        }

        private void ProductsDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = ProductsDataGrid.SelectedItem as DataRowView;
                NameTbx1.Text = selectedRow.Row[1].ToString();
                NameTbx2.Text = selectedRow.Row[2].ToString();
                NameTbx3.Text = selectedRow.Row[3].ToString();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            object product_id = (ProductsDataGrid.SelectedItem as DataRowView).Row[0];
            products.DeleteQuery(Convert.ToInt32(product_id));
            ProductsDataGrid.ItemsSource = products.GetData();
        }
    }
}