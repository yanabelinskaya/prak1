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
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            bakery.InsertQuery(NameTbx1.Text);
            BakeryDataGrid.ItemsSource = bakery.GetData();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            object bakery_id = (BakeryDataGrid.SelectedItem as DataRowView).Row[0];
            bakery.UpdateQuery(NameTbx1.Text, Convert.ToInt32(bakery_id));
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            object bakery_id = (BakeryDataGrid.SelectedItem as DataRowView).Row[0];
            bakery.DeleteQuery(Convert.ToInt32(bakery_id));
        }
    }
}
