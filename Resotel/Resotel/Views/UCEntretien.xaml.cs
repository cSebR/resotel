using Resotel.Entities;
using Resotel.ViewModels.VMReservation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour UCEntretien.xaml
    /// </summary>
    public partial class UCEntretien : UserControl
    {
        private ReservationViewModel resa;
        public UCEntretien()
        {
            InitializeComponent();

            resa = new ReservationViewModel(new Reservation());
            resa.Reservation.DateStart = DateTime.Now;
            resa.Reservation.DateEnd = DateTime.Now;
            resa.Reservation.Date = DateTime.Now;
            resa.Reservation.ListBedroom = new ObservableCollection<BedroomViewModel>();
            resa.Reservation.ListOptions = new ObservableCollection<OptionViewModel>();
            resa.Reservation.Customer = new Customer();
            resa.CustomersViewModel = new CustomersViewModel();
            resa.MealsViewModel = new MealsViewModel();
            resa.OptionsViewModel = new OptionsViewModel();
            resa.BedroomsViewModel = new BedroomsViewModel("Available");


            this.DataContext = resa;
        }
        private void CleaningRoom(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Votre demande a bien été prise en compte");
        }
    }
}
