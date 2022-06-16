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
using WpfApp1.Classes;
using WpfApp1.Models;
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для SignOnUser.xaml
    /// </summary>
    public partial class SignOnUser : Window
    {
        public SignOnUser()
        {
            InitializeComponent();
        }

        private void SignOnButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                List<string> logandpas = Skyline_DBEntities.GetContext().Buyer.Select(p => p.Login.Trim() + ";" + p.Password.Trim()).ToList();

                if (logandpas.Contains(LoginBox.Text.Trim() + ";" + PasswordName.Text.Trim()))
                {
                    Manager.buyer = Skyline_DBEntities.GetContext().Buyer.Where(p => p.Login.Trim() + ";" + p.Password.Trim() == LoginBox.Text.Trim() + ";" + PasswordName.Text.Trim()).First();
                    MainWindow mainWindow = new MainWindow();
                    Manager.MainWindow = mainWindow;
                    this.Close();
                    mainWindow.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
