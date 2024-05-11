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

namespace KP
{
    /// <summary>
    /// Логика взаимодействия для Seller.xaml
    /// </summary>
    public partial class Seller : Window
    {
        public Seller()
        {
            InitializeComponent();
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Seller_Folder.Seller_Clients_Page());
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Seller_Folder.Seller_Orders_Page());
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Seller_Folder.Seller_Products_Page());
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Seller_Folder.Seller_Reports_Page());

        }
    }
}
