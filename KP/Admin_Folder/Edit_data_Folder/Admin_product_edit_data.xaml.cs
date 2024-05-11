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

namespace KP.Admin_Folder.Edit_data_Folder
{
    /// <summary>
    /// Логика взаимодействия для Admin_product_edit_data.xaml
    /// </summary>
    public partial class Admin_product_edit_data : Window
    {
        private Product _currentProduct = new Product();

        public Admin_product_edit_data(Product selectedProduct)
        {
            InitializeComponent();
            DataContext = _currentProduct;
        }

        private void Edit_Product(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentProduct.Product_ID == 0)
                KPEntities.GetContext().Product.Add(_currentProduct);

            try
            {
                KPEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные изменены");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
