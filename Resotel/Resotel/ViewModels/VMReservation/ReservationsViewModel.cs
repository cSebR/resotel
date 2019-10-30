using Resotel.Services;
using Resotel.Entities;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace Resotel.ViewModels.VMReservation
{
    public class ReservationsViewModel : ViewModelBase 
    {
        public ObservableCollection<ReservationViewModel> ListReservations { get; set; }
        private ICollectionView observer;

        public ReservationViewModel ReservationSelected
        {
            get
            {
                return (ReservationViewModel)observer.CurrentItem;
            }
        }

        public ReservationsViewModel()
        {
            addReservationToList(ReservationService.Instance.ChargerReservations());
        }

        public ReservationsViewModel(string date)
        {
            addReservationToList(ReservationService.Instance.ChargerReservationsByDate(date));
        }
        public ReservationsViewModel(int id)
        {
            addReservationToList(ReservationService.Instance.ChargerReservationsByCustomer(id));
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("ReservationSelected");
        }

        private void deleteReservation(object sender, EventArgs e)
        {
            this.ListReservations.Remove(ReservationSelected);
            observer.MoveCurrentToFirst();
        }

        public void addReservationToList(List<Reservation> listReservations)
        {
            ListReservations = new ObservableCollection<ReservationViewModel>();
            foreach (Reservation r in listReservations)
            {
                BedroomsViewModel bvm = new BedroomsViewModel(r.Id);
                r.ListBedroom = bvm.ListBedrooms;

                OptionsViewModel ovm = new OptionsViewModel(r.Id);
                r.ListOptions = ovm.ListOptions;

                MealsViewModel mvm = new MealsViewModel(r.Id);
                r.ListMeal = mvm.ListMeals;

                ReservationViewModel reservation = new ReservationViewModel(r);
                reservation.DelReservation += deleteReservation;
                ListReservations.Add(reservation);
            }

            observer = CollectionViewSource.GetDefaultView(ListReservations);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }
    }
}
