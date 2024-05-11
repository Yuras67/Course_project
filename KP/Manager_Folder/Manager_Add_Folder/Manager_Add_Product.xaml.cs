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

namespace KP.Manager_Folder.Manager_Add_Folder
{
    /// <summary>
    /// Логика взаимодействия для Manager_Add_Product.xaml
    /// </summary>
    public partial class Manager_Add_Product : Window
    {
        public Manager_Add_Product()
        {
            InitializeComponent();
            DataContext = _currentProduct;
        }

        private Product _currentProduct = new Product();


        private void Add_Product(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Товар добавлен");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
