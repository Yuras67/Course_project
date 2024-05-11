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

namespace KP.Seller_Folder
{
    /// <summary>
    /// Логика взаимодействия для Seller_Clients_Page.xaml
    /// </summary>
    public partial class Seller_Clients_Page : Page
    {
        Seller_Add_Folder.Seller_Add_Client seller_Add_Client = new Seller_Add_Folder.Seller_Add_Client();

        public Seller_Clients_Page()
        {
            InitializeComponent();
            DGrid_Clients.ItemsSource = KPEntities.GetContext().Client.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Недостаточно прав");
        }

        private void Button_Add_Client(object sender, RoutedEventArgs e)
        {
            seller_Add_Client.Show();
        }
    }
}
