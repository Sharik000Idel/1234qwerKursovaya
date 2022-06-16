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
using WpfApp1.Classes;
using WpfApp1.Models;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        
        public HomePage()
        {
            InitializeComponent();
            Buyer buyer = Manager.buyer;
            NameText.Text = "Имя: " + buyer.Name;
            EamiUserl.Text = "Email: " + buyer.Login;
            SurnameText.Text = "Фамилия: " + buyer.Surname;
            Lastname.Text = "Отчество: " + buyer.Lastname;
            DateBirthUser.Text = "Дата рождения: " + buyer.Birthday.ToString();
            Numbertext.Text = "Номер: " + buyer.phone_number;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignOnUser sign = new SignOnUser();
            Manager.MainWindow.Close();
            sign.ShowDialog();

        }
    }
}
