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
    /// Логика взаимодействия для Seller_Orders_Page.xaml
    /// </summary>
    public partial class Seller_Orders_Page : Page
    {
        Seller_Add_Folder.Seller_Add_Order seller_Add_Order = new Seller_Add_Folder.Seller_Add_Order();

        public Seller_Orders_Page()
        {
            InitializeComponent();
            DGrid_Clients.ItemsSource = KPEntities.GetContext().Order.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Недостаточно прав");
        }

        private void Button_Add_Order(object sender, RoutedEventArgs e)
        {
            seller_Add_Order.Show();
        }
    }
}
