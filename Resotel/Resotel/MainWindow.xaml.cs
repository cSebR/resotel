using Resotel.ViewModels.VMReservation;
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

namespace Resotel
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ReservationsViewModel(new DateTime());
        }

        private void ReservationCalendar_SelectedDatesChange(object sender, SelectionChangedEventArgs e)
        {
            if (reservationCalendar.SelectedDate.HasValue)
            {
                Console.WriteLine(reservationCalendar.SelectedDate.Value.ToString("dd/MM/yyyy"));
                DateTime date = reservationCalendar.SelectedDate.Value;
                //this.DataContext = new ReservationsViewModel(date);
            }
        }
    }
}
