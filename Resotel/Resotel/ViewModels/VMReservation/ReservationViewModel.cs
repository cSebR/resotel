using Resotel.Entities;
using Resotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Resotel.ViewModels.VMReservation
{
    public class ReservationViewModel
    {
        public Reservation Reservation { get; }
        public ReservationViewModel(Reservation reservation)
        {
            Reservation = reservation;
        }

        public string Name
        {
            get
            {
                return Reservation.Number + " - " + Reservation.Customer.Lastname + " " + Reservation.Customer.Firstname;
            }
        }

        private ICommand commandSavereservation;
        public ICommand CommandSaveReservation
        {
            get
            {
                if (commandSavereservation == null)
                {
                    commandSavereservation = new RelayCommand((object sender) =>
                    {
                        ReservationService.Instance.SaveReservation(Reservation);
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
                return commandSavereservation;
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
                    });
                }
                return commandDel;
            }
        }
    }
}
