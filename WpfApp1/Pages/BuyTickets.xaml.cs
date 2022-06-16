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
using WpfApp1.Models;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для BuyTickets.xaml
    /// </summary>
    public partial class BuyTickets : Page
    {
        List<Flight> flights;
        public BuyTickets(Airport outAirport , Airport InAirport)
        {
            InitializeComponent();
            flights = Skyline_DBEntities.GetContext().Flight.ToList().Where(p => p.place_of_departure == outAirport.IDairport && p.landing_place == InAirport.IDairport).ToList();

            MessageBox.Show(flights.Count().ToString());

            foreach(Flight flight in flights)
            {
                double FlyTime = Math.Sqrt(Math.Pow(Double.Parse(InAirport.CoordinatesX.Replace('.', ',')) - Double.Parse(outAirport.CoordinatesX.Replace('.', ',')), 2) +
                                           Math.Pow(Double.Parse(InAirport.CoordinatesY.Replace('.', ',')) - Double.Parse(outAirport.CoordinatesY.Replace('.', ',')), 2));
                flight.boarding_time = flight.departure_time.AddHours(FlyTime); 
            }



            DateList.ItemsSource = flights;
        }

        private void DateList_Selected(object sender, SelectionChangedEventArgs e)
        {
            TicketNumber.Text += (Skyline_DBEntities.GetContext().Tickets.Count() + 1).ToString();
            FLightNumber.Text += ((Flight)DateList.SelectedItem).FlightNumber.ToString();
            OutAitportTB.Text += ((Flight)DateList.SelectedItem).Airport.FullAirportBin.ToString();
            InAitportTB.Text  += ((Flight)DateList.SelectedItem).Airport1.FullAirportBin.ToString();
            OutAitportTBDate.Text += ((Flight)DateList.SelectedItem).OutAirportDate.ToString();
            InAitportTBDate.Text += ((Flight)DateList.SelectedItem).InAirportDate.ToString();
            ChairNumberText.Text += (((Flight)DateList.SelectedItem).number_of_passengers + 1).ToString();

        }
    }
}
