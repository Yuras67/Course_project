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

namespace KP.Seller_Folder.Seller_Add_Folder
{
    /// <summary>
    /// Логика взаимодействия для Seller_Add_Client.xaml
    /// </summary>
    public partial class Seller_Add_Client : Window
    {

        private Client _currentClient = new Client();
        public Seller_Add_Client()
        {
            InitializeComponent();
            DataContext = _currentClient;
        }

        private void Button_Click(object sender, object e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentClient.First_Name))
                errors.AppendLine("Укажите имя клиента");
            if (string.IsNullOrWhiteSpace(_currentClient.Last_Name))
                errors.AppendLine("Укажите фамилию клиента");
            if (string.IsNullOrWhiteSpace(_currentClient.Patronomic))
                errors.AppendLine("Укажите отчество клиента");
            if (string.IsNullOrWhiteSpace(_currentClient.Email))
                errors.AppendLine("Укажите почту клиента");
            if (string.IsNullOrWhiteSpace(_currentClient.Phone))
                errors.AppendLine("Укажите номер телефона клиента");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentClient.Client_ID == 0)
                KPEntities.GetContext().Client.Add(_currentClient);

            try
            {
                KPEntities.GetContext().SaveChanges();
                MessageBox.Show("Клиент добавлен");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
