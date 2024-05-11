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
    /// Логика взаимодействия для Admin_Products_Page.xaml
    /// </summary>
    public partial class Admin_Products_Page : Page
    {
        Admin_Add_Product admin_Add_Product = new Admin_Add_Product();

        public Admin_Products_Page()
        {
            InitializeComponent();
            DGrid_Clients.ItemsSource = KPEntities.GetContext().Product.ToList();
        }

        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            var clientRemoving = DGrid_Clients.SelectedItems.Cast<Product>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {clientRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    KPEntities.GetContext().Product.RemoveRange((IEnumerable<Product>)clientRemoving);
                    KPEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGrid_Clients.ItemsSource = KPEntities.GetContext().Product.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Button_Add_Product(object sender, RoutedEventArgs e)
        {
            admin_Add_Product.Show();
        }

        private void Button_edit_data(object sender, RoutedEventArgs e)
        {
            try
            {
                Edit_data_Folder.Admin_product_edit_data admin_product_Edit_Data
                    = new Edit_data_Folder.Admin_product_edit_data((sender as Button).DataContext as Product);
                admin_product_Edit_Data.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
