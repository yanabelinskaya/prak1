using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using prak1.PrakticaaDataSetTableAdapters;

namespace prak1
{
    public partial class Page3 : Page
    {
        //датасет
        DeliveryTableAdapter delivery = new DeliveryTableAdapter();
        ProductTableAdapter product = new ProductTableAdapter();
        public Page3()
        {
            InitializeComponent();
            DeliveryDataGrid.ItemsSource = delivery.GetData();
            productCbx.ItemsSource = product.GetData();
            productCbx.DisplayMemberPath = "productName";
            NameTbx4.ItemsSource = product.GetData();
            NameTbx4.DisplayMemberPath = "productName";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DeliveryDataGrid.ItemsSource = delivery.SearchAddress(Searchtxt.Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DeliveryDataGrid.ItemsSource = delivery.GetData();
        }

        private void bakeryCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productCbx.SelectedItem != null)
            {
                var product_id = (int)(productCbx.SelectedItem as DataRowView).Row[0];
                DeliveryDataGrid.ItemsSource = delivery.FilterByProduct(product_id);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (NameTbx4.SelectedItem != null)
            {
                var product_id = (int)(NameTbx4.SelectedItem as DataRowView).Row[0];
                delivery.InsertQuery(NameTbx1.Text, int.Parse(NameTbx2.Text), NameTbx3.Text, product_id);
                DeliveryDataGrid.ItemsSource = delivery.GetData();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (DeliveryDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = DeliveryDataGrid.SelectedItem as DataRowView;
                object delivery_id = selectedRow.Row[0];
                int product_id = (int)(NameTbx4.SelectedItem as DataRowView).Row[0];
                delivery.UpdateQuery(NameTbx1.Text, int.Parse(NameTbx2.Text), NameTbx3.Text, product_id, Convert.ToInt32(delivery_id));
                DeliveryDataGrid.ItemsSource = delivery.GetData();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            object delivery_id = (DeliveryDataGrid.SelectedItem as DataRowView).Row[0];
            delivery.DeleteQuery(Convert.ToInt32(delivery_id));
            DeliveryDataGrid.ItemsSource = delivery.GetData();
        }

        private void DeliveryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DeliveryDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = DeliveryDataGrid.SelectedItem as DataRowView;
                NameTbx1.Text = selectedRow.Row[1].ToString();
                NameTbx2.Text = selectedRow.Row[2].ToString();
                NameTbx3.Text = selectedRow.Row[3].ToString();
            }
        }
    }
                    
}
