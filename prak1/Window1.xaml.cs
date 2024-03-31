using prak1.PrakticaDataSetTableAdapters;
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
using System.Windows.Shapes;
using System.Runtime.InteropServices;

namespace prak1
{
    public partial class Window1 : Window
    {
        BakeryTableAdapter bakery = new BakeryTableAdapter();
        public Window1()
        {
            InitializeComponent();
            BakeryDataGrid.ItemsSource = bakery.GetData();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            bakery.InsertQuery(NameTbx1.Text);
            BakeryDataGrid.ItemsSource = bakery.GetData();

        }
    }
}
