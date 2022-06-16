
using Microsoft.Maps.MapControl.WPF;
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
    /// Логика взаимодействия для MapsPage.xaml
    /// </summary>
    public partial class MapsPage : Page
    {
        
        public MapsPage()
        {
            InitializeComponent();
            airports = Skyline_DBEntities.GetContext().Airport.ToList();
        }
        
        private void ReplaceCity_Click(object sender, RoutedEventArgs e)
        {
            string city = OutCity.Text;
            OutCity.Text = InCity.Text;
            InCity.Text = city;
        }
        Airport airportOut;
        Airport airportIn;
        private void SearchReys_Click(object sender, RoutedEventArgs e)
        {
            airports = Skyline_DBEntities.GetContext().Airport.ToList();
            
            if (airports.Select(p => p.FullAirportBin).Contains(OutCity.Text) &&
                airports.Select(p => p.FullAirportBin).Contains(InCity.Text ))
            {
                airportOut = airports.Find(p => p.FullAirportBin == OutCity.Text);
                airportIn = airports.Find(p => p.FullAirportBin == InCity.Text);

                myMap.Children.Clear();
                MapPolyline maplINE = new MapPolyline();
                maplINE.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
                maplINE.StrokeThickness = 5;
                maplINE.Opacity = 0.5;

                Console.WriteLine(airportOut.CoordinatesX + " " + airportOut.CoordinatesY + " " + airportIn.CoordinatesX + " " + airportIn.CoordinatesY);
                MessageBox.Show(airportOut.CoordinatesX + " " + airportOut.CoordinatesY + " " + airportIn.CoordinatesX + " " + airportIn.CoordinatesY);

                maplINE.Locations = new LocationCollection() {
                new Location(Double.Parse(airportOut.CoordinatesX.Replace('.' , ',')), Double.Parse(airportOut.CoordinatesY.Replace('.' , ','))),
                new Location(Double.Parse(airportIn.CoordinatesX.Replace('.' , ',')), Double.Parse(airportIn.CoordinatesY.Replace('.' , ',')))};


                myMap.Children.Add(maplINE);


                Buytickets.Visibility = Visibility.Visible;
            }
            
        }

        List<Airport> airports;

        List <string> airportsFullName;
        private void OutCity_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
            if (OutCity.Text != "")
            {
                airports = Skyline_DBEntities.GetContext().Airport.ToList();
                airports = airports.Where(p => p.City.ToLower().StartsWith(OutCity.Text.ToLower())
                                        || p.Country.ToLower().StartsWith(OutCity.Text.ToLower())).Take(20).ToList();
                airportsFullName = airports.Select(p => p.FullAirportBin).ToList();
                OutCity.ItemsSource = airportsFullName;
                airportsFullName.Clear();
                airports.Clear();
            }
            
        }

        private void InCity_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
            if (InCity.Text != "")
            {

                airports = Skyline_DBEntities.GetContext().Flight.Select(p => p.Airport1).ToList();
                airports = airports.Where(p => p.City.ToLower().StartsWith(InCity.Text.ToLower())
                                        || p.Country.ToLower().StartsWith(InCity.Text.ToLower()) ).Take(20).ToList();

                airportsFullName = airports.Select(p => p.FullAirportBin).ToList();
                InCity.ItemsSource = airportsFullName;
                airportsFullName.Clear();
                airports.Clear();
            }
            
        }

        private void Buytickets_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new BuyTickets( airportOut ,  airportIn));
        }
    }
}
