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
    /// Логика взаимодействия для Admin_order_edit_data.xaml
    /// </summary>
    public partial class Admin_order_edit_data : Window
    {
        private Order _currentOrder = new Order();

        public Admin_order_edit_data(Order selectedOrder)
        {
            InitializeComponent();
            DataContext = _currentOrder;

            if (selectedOrder!= null)
                _currentOrder = selectedOrder;
            DataContext = _currentOrder;
        }


        private void Order_edit(object sender, RoutedEventArgs e)
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
