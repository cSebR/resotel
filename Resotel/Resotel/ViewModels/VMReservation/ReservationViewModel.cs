using Resotel.Entities;
using Resotel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Resotel.ViewModels.VMReservation
{
    public class ReservationViewModel : ViewModelBase
    {
        public Reservation Reservation { get; }
        public CustomersViewModel CustomersViewModel { get; set; }
        public MealsViewModel MealsViewModel { get; set; }
        public BedroomsViewModel BedroomsViewModel { get; set; }
        public OptionsViewModel OptionsViewModel { get; set; }
        public Users UserConnected {get; set;}

        public ReservationViewModel(Reservation reservation)
        {
            Reservation = reservation;
            UserConnected = (Users)Application.Current.Properties["UserConnected"];
        }

        public string Name
        {
            get
            {
                return Reservation.Number + " - " + Reservation.Customer.Lastname + " " + Reservation.Customer.Firstname;
            }
        }

        public string NameUCCustomer
        {
            get
            {
                return Reservation.Number + " - Du " + Reservation.DateStart.Day + "/" + Reservation.DateStart.Month + "/" + Reservation.DateStart.Year + " au " + Reservation.DateEnd.Day + "/" + Reservation.DateEnd.Month + "/" + Reservation.DateEnd.Year;
            }
        }

        private ICommand commandSave;
        public ICommand CommandSave
        {
            get
            {
                if (commandSave == null)
                {
                    commandSave = new RelayCommand((object sender) =>
                    {
                        Reservation.Customer = CustomersViewModel.CustomerSelected.Customer;
                        ReservationService.Instance.SaveReservation(Reservation, UserConnected);
                        ClearFields();
                        MessageBox.Show("La réservation a bien été ajouté !", "Message d'information", MessageBoxButton.OK, MessageBoxImage.Information);
                    },
                    (object sender) =>
                    {
                        if (string.IsNullOrWhiteSpace(Reservation.Number))
                        {
                            return false;
                        }
                        return true;
                    });
                }
                return commandSave;
            }
        }

        public event EventHandler DelReservation;
        private ICommand commandDel;
        public ICommand CommandDel
        {
            get
            {
                if (commandDel == null)
                {
                    commandDel = new RelayCommand((object sender) =>
                    {
                        if (Reservation.Id > 0)
                            ReservationService.Instance.DelReservation(Reservation);
                        DelReservation?.Invoke(this, EventArgs.Empty);
                        MessageBox.Show("La réservation a bien été supprimé !", "Message d'information", MessageBoxButton.OK, MessageBoxImage.Information);
                    });
                }
                return commandDel;
            }
        }

        private void ClearFields()
        {
            Reservation.Number = "";
            Reservation.ListBedroom.Clear();
            Reservation.ListMeal.Clear();
            Reservation.ListOptions.Clear();
            Reservation.Customer = null;
            Reservation.Date = DateTime.Now;
            Reservation.DateStart = DateTime.Now;
            Reservation.DateEnd = DateTime.Now;
        }
    }
}
