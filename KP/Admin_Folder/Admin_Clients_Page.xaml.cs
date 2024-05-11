using KP.Admin_Folder.Add_Folder;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class Admin_Clients_Page : Page
    {
        Admin_Add_Client Admin_Add_Client = new Admin_Add_Client();

        public Admin_Clients_Page()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                KPEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid_Clients.ItemsSource = KPEntities.GetContext().Client.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin_Add_Client.Show();
        }

        private void Button_edit_data(object sender, RoutedEventArgs e)
        {
                try
                {
                    Edit_data_Folder.Admin_client_edit_data admin_Client_Edit_Data 
                        = new Edit_data_Folder.Admin_client_edit_data((sender as Button).DataContext as Client);
                    admin_Client_Edit_Data.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }


        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            var clientRemoving = DGrid_Clients.SelectedItems.Cast<Client>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {clientRemoving.Count()} элементов?", "Внимание", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    KPEntities.GetContext().Client.RemoveRange((IEnumerable<Client>)clientRemoving);
                    KPEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGrid_Clients.ItemsSource = KPEntities.GetContext().Client.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
