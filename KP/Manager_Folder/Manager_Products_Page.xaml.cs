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

namespace KP.Manager_Folder
{
    /// <summary>
    /// Логика взаимодействия для Manager_Products_Page.xaml
    /// </summary>
    public partial class Manager_Products_Page : Page
    {
        Manager_Add_Folder.Manager_Add_Product manager_Add_Product = new Manager_Add_Folder.Manager_Add_Product();

        public Manager_Products_Page()
        {
            InitializeComponent();
            DGrid_Clients.ItemsSource = KPEntities.GetContext().Product.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ProductRemoving = DGrid_Clients.SelectedItems.Cast<Product>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ProductRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    KPEntities.GetContext().Product.RemoveRange((IEnumerable<Product>)ProductRemoving);
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

        private void Button_edit_data(object sender, RoutedEventArgs e)
        {
            try
            {
                Manager_Add_Folder.Manager_Edit_Product manager_Edit_Product
                    = new Manager_Add_Folder.Manager_Edit_Product((sender as Button).DataContext as Product);
                manager_Edit_Product.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Add_Product(object sender, RoutedEventArgs e)
        {
            manager_Add_Product.Show();
        }
    }
}
