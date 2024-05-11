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
    /// Логика взаимодействия для Seller_Products_Page.xaml
    /// </summary>
    public partial class Seller_Products_Page : Page
    {
        public Seller_Products_Page()
        {
            InitializeComponent();
            DGrid_Clients.ItemsSource = KPEntities.GetContext().Product.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Недостаточно прав");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Недостаточно прав");
        }
    }
}
