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
    /// Логика взаимодействия для SignOnPage.xaml
    /// </summary>
    public partial class SignOnPage : Page
    {
        public SignOnPage()
        {
            InitializeComponent();
        }

        private void SignOnButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            List<string> logandpas = Skyline_DBEntities.GetContext().Buyer.Select(p => p.Login.Trim() + ";"+ p.Password.Trim()).ToList();

            if (logandpas.Contains(LoginBox.Text.Trim() + ";" + PasswordName.Text.Trim()))
            {
                Manager.buyer = Skyline_DBEntities.GetContext().Buyer.Where(p => p.Login.Trim() + ";" + p.Password.Trim() == LoginBox.Text.Trim() + ";" + PasswordName.Text.Trim()).First();
                Manager.MainFrame.Navigate(new MainPage());

                
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
