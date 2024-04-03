using System;
using System.Collections.Generic;
using System.Data;
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
using prak1.PrakticaaDataSetTableAdapters;

namespace prak1
{
    public partial class Page1 : Page
    {
        //датасет
        BakeryTableAdapter bakery = new BakeryTableAdapter();
        public Page1()
        {
            InitializeComponent();
            BakeryDataGrid.ItemsSource = bakery.GetData();
            bakeryCbx.ItemsSource = bakery.GetData();
            bakeryCbx.DisplayMemberPath = "bakeryAddress";

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BakeryDataGrid.ItemsSource = bakery.SearchByName(Searchtxt.Text);
        }

        private void bakeryCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bakeryCbx.SelectedItem != null)
            {
                var bakeryAddress = (string)(bakeryCbx.SelectedItem as DataRowView).Row["bakeryAddress"];
                BakeryDataGrid.ItemsSource = bakery.FilterByAddress(bakeryAddress);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BakeryDataGrid.ItemsSource = bakery.GetData();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            bakery.InsertQuery(NameTbx1.Text, NameTbx2.Text, decimal.Parse(NameTbx3.Text));
            BakeryDataGrid.ItemsSource = bakery.GetData();
            

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (BakeryDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = BakeryDataGrid.SelectedItem as DataRowView;
                object bakery_id = selectedRow.Row[0];
                bakery.UpdateQuery(NameTbx1.Text, NameTbx2.Text, decimal.Parse(NameTbx3.Text), Convert.ToInt32(bakery_id));
                BakeryDataGrid.ItemsSource = bakery.GetData();
            }

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            object bakery_id = (BakeryDataGrid.SelectedItem as DataRowView).Row[0];
            bakery.DeleteQuery(Convert.ToInt32(bakery_id));
        }

        private void BakeryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BakeryDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = BakeryDataGrid.SelectedItem as DataRowView;
                NameTbx1.Text = selectedRow.Row[1].ToString(); 
                NameTbx2.Text = selectedRow.Row[2].ToString(); 
                NameTbx3.Text = selectedRow.Row[3].ToString(); 
            }
        }
    }
    
}
