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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Manager.MainFrame = MainPageFrame;
            Manager.MainFrame.Navigate(new HomePage()); 

            
                    
            

        }

        

        private void LeftMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            LeftMenu.Width = 200;
            //MainPageFrame.Margin = new Thickness(260,0,0,0);


        }

        private void LeftMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            LeftMenu.Width = 50;
            //MainPageFrame.Margin = new Thickness(60, 0, 0, 0);
        }


        private void LeftMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            switch (LeftMenu.SelectedIndex)
            {
                case 0:
                    Manager.MainFrame.Navigate(new HomePage());
                    break;
                case 1:
                    Manager.MainFrame.Navigate(new BuyerPage());
                    break;
                case 2:
                    Manager.MainFrame.Navigate(new PlanePage());
                    break;
                case 3:
                    Manager.MainFrame.Navigate(new PersonnelPage());
                    break;
            }


            TopMenu.SelectedIndex = -1;
        }

        private void TopMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (TopMenu.SelectedIndex)
            {

                case 2:
                    Manager.MainFrame.Navigate(new MapsPage());
                    break;
               
            }

            LeftMenu.SelectedIndex = -1;
        }

    }
}
