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

namespace KP.Admin_Folder.Add_Folder
{
    /// <summary>
    /// Логика взаимодействия для Admin_Add_Orders.xaml
    /// </summary>
    public partial class Admin_Add_Orders : Window
    {
        private Order _currentOrder = new Order();

        public Admin_Add_Orders()
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