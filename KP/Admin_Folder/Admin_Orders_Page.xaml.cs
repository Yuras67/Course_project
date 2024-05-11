using KP.Admin_Folder.Add_Folder;
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

namespace KP.Admin_Folder
{
    /// <summary>
    /// Логика взаимодействия для Admin_Orders_Page.xaml
    /// </summary>
    public partial class Admin_Orders_Page : Page
    {
        Admin_Add_Orders admin_Add_Orders = new Admin_Add_Orders();

        public Admin_Orders_Page()
        {
            InitializeComponent();
            DGrid_Clients.ItemsSource = KPEntities.GetContext().Order.ToList();
        }

        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            var clientRemoving = DGrid_Clients.SelectedItems.Cast<Order>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {clientRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    KPEntities.GetContext().Order.RemoveRange((IEnumerable<Order>)clientRemoving);
                    KPEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGrid_Clients.ItemsSource = KPEntities.GetContext().Order.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Button_Add_Orders(object sender, RoutedEventArgs e)
        {
            admin_Add_Orders.Show();
        }

        private void Button_edit_data(object sender, RoutedEventArgs e)
        {
            try
            {
                Edit_data_Folder.Admin_order_edit_data admin_order_Edit_Data
                    = new Edit_data_Folder.Admin_order_edit_data((sender as Button).DataContext as Order);
                admin_order_Edit_Data.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
