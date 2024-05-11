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
    /// Логика взаимодействия для Manager_Clients_Page.xaml
    /// </summary>
    public partial class Manager_Clients_Page : Page
    {
        public Manager_Clients_Page()
        {
            InitializeComponent();
            DGrid_Clients.ItemsSource = KPEntities.GetContext().Client.ToList();
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
