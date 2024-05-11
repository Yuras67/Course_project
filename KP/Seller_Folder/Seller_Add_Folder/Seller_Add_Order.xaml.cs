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

namespace KP.Seller_Folder.Seller_Add_Folder
{
    /// <summary>
    /// Логика взаимодействия для Seller_Add_Order.xaml
    /// </summary>
    public partial class Seller_Add_Order : Window
    {
        private Order _currentOrder = new Order();

        public Seller_Add_Order()
        {
            InitializeComponent();
            DataContext = _currentOrder;

        }

        private void Button_Click(object sender, object e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentOrder.Order_number == 0)
                KPEntities.GetContext().Order.Add(_currentOrder);

            try
            {
                KPEntities.GetContext().SaveChanges();
                MessageBox.Show("Заказ оформлен");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
