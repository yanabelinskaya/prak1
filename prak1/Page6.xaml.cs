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
            NameTbx4.ItemsSource = context.Product.ToList();
            NameTbx4.SelectedIndex = 0;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DeliveryDgr.ItemsSource = context.Delivery.ToList().Where(item => item.deliveryAddress.Contains(Searchtxt.Text));

        }

        private void bakeryCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (deliveryCbx.SelectedItem != null)
            {
                var selectedDelivery = deliveryCbx.SelectedItem as Delivery;
                var selectedDeliveryAddress = selectedDelivery.deliveryAddress;
                DeliveryDgr.ItemsSource = context.Delivery.ToList().Where(item => item.deliveryAddress == selectedDeliveryAddress);

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DeliveryDgr.ItemsSource = context.Delivery.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DateTime deliveryDate;
            int quantity;

            // Преобразование даты
            if (DateTime.TryParse(NameTbx1.Text, out deliveryDate))
            {
                // Преобразование количества
                if (int.TryParse(NameTbx2.Text, out quantity))
                {
                    var newDelivery = new Delivery
                    {
                        deliveryDate = deliveryDate,
                        quantity = quantity,
                        deliveryAddress = NameTbx3.Text,
                        product_id = (int)NameTbx4.SelectedValue
                    };

                    context.Delivery.Add(newDelivery);
                    context.SaveChanges();
                    DeliveryDgr.ItemsSource = context.Product.ToList();
                }
                else
                {
                    // Сообщаем пользователю, что введено некорректное количество
                    MessageBox.Show("Введите корректное количество.");
                }
            }
            else
            {
                // Сообщаем пользователю, что введена некорректная дата
                MessageBox.Show("Введите корректную дату.");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DateTime deliveryDate;
            int quantity;

            // Преобразование даты
            if (DateTime.TryParse(NameTbx1.Text, out deliveryDate))
            {
                // Преобразование количества
                if (int.TryParse(NameTbx2.Text, out quantity))
                {
                    if (DeliveryDgr.SelectedItem != null)
                    {
                        var selectedDelivery = DeliveryDgr.SelectedItem as Delivery;
                        selectedDelivery.deliveryDate = deliveryDate;
                        selectedDelivery.quantity = quantity;
                        selectedDelivery.deliveryAddress = NameTbx3.Text;
                        selectedDelivery.product_id = (int)NameTbx4.SelectedValue;

                        context.SaveChanges();
                        DeliveryDgr.Items.Refresh();
                    }
                    else
                    {
                        // Сообщаем пользователю, что введено некорректное количество
                        MessageBox.Show("Введите корректное количество.");
                    }
                }
                else
                {
                    // Сообщаем пользователю, что введена некорректная дата
                    MessageBox.Show("Введите корректную дату.");
                }
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (DeliveryDgr.SelectedItem != null)
            {
                var selectedDelivery = DeliveryDgr.SelectedItem as Delivery;
                context.Delivery.Remove(selectedDelivery);
                context.SaveChanges();
                DeliveryDgr.ItemsSource = context.Delivery.ToList();
            }
        }

        private void DeliveryDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DeliveryDgr.SelectedItem != null)
            {
                var selectedDelivery = DeliveryDgr.SelectedItem as Delivery;
                NameTbx1.Text = selectedDelivery.deliveryDate.ToString();
                NameTbx2.Text = selectedDelivery.quantity.ToString();
                NameTbx3.Text = selectedDelivery.deliveryAddress;

                Product selectedProduct = context.Product.FirstOrDefault(c => c.product_id == selectedDelivery.product_id);
                if (selectedProduct != null)
                {
                    NameTbx4.SelectedItem = selectedProduct;
                }
            }
        }
    }
    
}
