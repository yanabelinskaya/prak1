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
using prak1.PrakticaDataSetTableAdapters;

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
            bakeryCbx.DisplayMemberPath = "название_пекарни";

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

        private void BakeryCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bakeryCbx.SelectedItem != null)
            {
                var bakery_id = (int)(bakeryCbx.SelectedItem as DataRowView).Row["название_пекарни"];
                BakeryDataGrid.ItemsSource= bakery.FilterByProduct(bakery_id);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BakeryDataGrid.ItemsSource = bakery.GetData();
        }
    }
}
