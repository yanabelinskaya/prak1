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
    public partial class Page8 : Page
    {
        private PrakticaEntities context = new PrakticaEntities();
        public Page8()
        {
            InitializeComponent();
            LoadData();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
        private void LoadData()
        {
            var query = from product in context.Product
                        join bakery in context.Bakery on product.bakery_id equals bakery.bakery_id
                        join delivery in context.Delivery on product.product_id equals delivery.product_id
                        select new
                        {
                            productName = product.productName,
                            productDescription = product.productDescription,
                            price = product.price,
                            Bakery = new
                            {
                                bakeryName = bakery.bakeryName,
                                bakeryAddress = bakery.bakeryAddress,
                                rating = bakery.rating
                            },
                            Delivery = new
                            {
                                deliveryDate = delivery.deliveryDate,
                                quantity = delivery.quantity,
                                deliveryAddress = delivery.deliveryAddress
                            }
                        };

            ProductDgr.ItemsSource = query.ToList();
        }
    }
}
