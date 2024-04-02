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
    public partial class Page6 : Page
    {
        //ef
        private PrakticaEntities context = new PrakticaEntities();
        public Page6()
        {
            InitializeComponent();
            DeliveryDgr.ItemsSource = context.Delivery.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Delivery c = new Delivery();

            context.Delivery.Add(c);

            context.SaveChanges();
            DeliveryDgr.ItemsSource = context.Delivery.ToList();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (DeliveryDgr.SelectedItem != null)
            {
                var selected = DeliveryDgr.SelectedItem as Delivery;

                selected.deliveryAddress = NameTbx1.Text;
                context.SaveChanges();
                DeliveryDgr.ItemsSource = context.Delivery.ToList();
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            if (DeliveryDgr.SelectedItem != null)
            {
                context.Delivery.Remove(DeliveryDgr.SelectedItem as Delivery);
                context.SaveChanges();
                DeliveryDgr.ItemsSource = context.Delivery.ToList();
            }
        }

        private void DeliveryDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DeliveryDgr.SelectedItem != null)
            {
                var selected = DeliveryDgr.SelectedItem as Delivery;

                NameTbx1.Text = selected.deliveryAddress;
            }
        }
    }
}
