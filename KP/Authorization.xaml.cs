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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Seller SellerWindow = new Seller();
            Manager ManagerWindow = new Manager();
            Administrator AdministratorWindow = new Administrator();

            string login = Login.Text.ToLower();
            string password = Password.Password;

            if (login == "seller" && password == "1")
            {
                this.Close();
                SellerWindow.Show();
            }
            else if (login == "manager" && password == "2")
            {
                this.Close();
                ManagerWindow.Show();
            }
            else if (login == "admin" && password == "3")
            {
                this.Close();
                AdministratorWindow.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

    }
}
