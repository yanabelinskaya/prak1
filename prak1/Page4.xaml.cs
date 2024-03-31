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

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Bakery c = new Bakery();
            c.bakeryName = NameTbx1.Text;
            c.bakeryAddress = NameTbx2.Text;

            context.Bakery.Add(c);

            context.SaveChanges();
            BakeryDgr.ItemsSource = context.Bakery.ToList();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (BakeryDgr.SelectedItem != null)
            {
                var selected = BakeryDgr.SelectedItem as Bakery;

                selected.bakeryName = NameTbx1.Text;
                selected.bakeryAddress = NameTbx2.Text;
       
                context.SaveChanges();
                BakeryDgr.ItemsSource = context.Bakery.ToList();
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            if (BakeryDgr.SelectedItem != null)
            {
                context.Bakery.Remove(BakeryDgr.SelectedItem as Bakery);

                context.SaveChanges();
                BakeryDgr.ItemsSource = context.Bakery.ToList();
            }
        }

        private void BakeryDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BakeryDgr.SelectedItem != null)
            {
                var selected = BakeryDgr.SelectedItem as Bakery;

                NameTbx1.Text = selected.bakeryName;
                NameTbx2.Text = selected.bakeryAddress;
            }
        }
    }
}
