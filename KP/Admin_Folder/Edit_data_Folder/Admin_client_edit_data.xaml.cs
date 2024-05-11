using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

namespace KP.Admin_Folder.Edit_data_Folder
{
    public partial class Admin_client_edit_data : Window
    {
        private Client _currentClient = new Client();
        public Admin_client_edit_data(Client selectedClient)
        { 
            InitializeComponent();
            DataContext = _currentClient;

            if (selectedClient != null)
                _currentClient = selectedClient;
            DataContext = _currentClient;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Данные изменены");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
