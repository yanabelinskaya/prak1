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
    public partial class Page4 : Page
    {
        //ef
        private PrakticaEntities context = new PrakticaEntities();
        public Page4()
        {
            InitializeComponent();
            BakeryDgr.ItemsSource = context.Bakery.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BakeryDgr.ItemsSource = context.Bakery.ToList().Where(item => item.bakeryName.Contains(Searchtxt.Text));
        }

        private void bakeryCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bakeryCbx.SelectedItem != null)
            {
                var selectedBakery = bakeryCbx.SelectedItem as Bakery;
                var selectedBakeryName = selectedBakery.bakeryName;
                BakeryDgr.ItemsSource = context.Bakery.ToList().Where(item => item.bakeryName == selectedBakeryName);

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BakeryDgr.ItemsSource = context.Bakery.ToList();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            var newBakery = new Bakery
            {
                bakeryName = NameTbx1.Text,
                bakeryAddress = NameTbx2.Text,
                rating = decimal.Parse(NameTbx3.Text),
            };
            context.Bakery.Add(newBakery);
            context.SaveChanges();
            BakeryDgr.ItemsSource = context.Bakery.ToList();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if(BakeryDgr.SelectedItem != null) 
            { 
                var selectedBakery = BakeryDgr.SelectedItem as Bakery;
                selectedBakery.bakeryName = NameTbx1.Text;
                selectedBakery.bakeryAddress = NameTbx2.Text;
                selectedBakery.rating = decimal.Parse(NameTbx3.Text);

                context.SaveChanges();
                BakeryDgr.Items.Refresh();

            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            if (BakeryDgr.SelectedItem != null)
            {
                var selectedBakery = BakeryDgr.SelectedItem as Bakery;
                context.Bakery.Remove(selectedBakery);
                context.SaveChanges();
                BakeryDgr.ItemsSource = context.Bakery.ToList();

            }
        }

        private void BakeryDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BakeryDgr.SelectedItem != null)
            {
                var selectedBakery = BakeryDgr.SelectedItem as Bakery;
                NameTbx1.Text = selectedBakery.bakeryName.ToString();
                NameTbx2.Text = selectedBakery.bakeryAddress.ToString();
                NameTbx3.Text = selectedBakery.rating.ToString();
            }
        }
    }
}
