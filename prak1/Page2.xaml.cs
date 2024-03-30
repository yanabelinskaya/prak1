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
using prak1.PrakticaDataSetTableAdapters;

namespace prak1
{
    public partial class Page2 : Page
    {
        //датасет
        /*ProductTableAdapter products = new ProductTableAdapter();
        public Page2()
        {
            InitializeComponent();
            ProductsDataGrid.ItemsSource = products.GetData();
        }*/

        //ef
        private PrakticaEntities context = new PrakticaEntities();
        public Page2()
        {
            InitializeComponent();
            ProductsDgr.ItemsSource = context.Product.ToList();
        }
    }
}
