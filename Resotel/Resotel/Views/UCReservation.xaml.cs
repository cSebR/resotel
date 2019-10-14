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

namespace Resotel.Views
{
    /// <summary>
    /// Logique d'interaction pour UCReservation.xaml
    /// </summary>
    public partial class UCReservation : UserControl
    {
        public UCReservation()
        {
            InitializeComponent();
            ReservationsViewModel resaVM = new ReservationsViewModel();
            reservationCalendar.SelectionMode = CalendarSelectionMode.MultipleRange;
            foreach (ReservationViewModel rvm in resaVM.ListReservations)
            {
                reservationCalendar.SelectedDates.AddRange(rvm.Reservation.DateStart, rvm.Reservation.DateEnd);
            }
            //this.DataContext = resaVM;
        }

        private void ReservationCalendar_SelectedDatesChange(object sender, SelectionChangedEventArgs e)
        {
            if (reservationCalendar.SelectedDate.HasValue)
            {
                Console.WriteLine(reservationCalendar.SelectedDate.Value.ToString("dd/MM/yyyy"));
                string date = reservationCalendar.SelectedDate.Value.ToString("yyyy-MM-dd");
                this.DataContext = new ReservationsViewModel(date);
            }
        }
    }
}
