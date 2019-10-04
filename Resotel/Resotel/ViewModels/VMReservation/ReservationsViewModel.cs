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
            List<Reservation> listReservation = ReservationService.Instance.ChargerReservations();

            ListReservations = new ObservableCollection<ReservationViewModel>();
            foreach (Reservation r in listReservation)
            {
                addReservationToList(r);
            }

            observer = CollectionViewSource.GetDefaultView(ListReservations);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }

        public ReservationsViewModel(string date)
        {
            List<Reservation> listReservation = ReservationService.Instance.ChargerReservationsByDate(date);

            ListReservations = new ObservableCollection<ReservationViewModel>();
            foreach (Reservation r in listReservation)
            {
                addReservationToList(r);
            }

            observer = CollectionViewSource.GetDefaultView(ListReservations);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
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

        public void addReservationToList(Reservation resa)
        {
            ReservationViewModel reservation = new ReservationViewModel(resa);
            reservation.DelReservation += deleteReservation;
            ListReservations.Add(reservation);
        }
    }
}
