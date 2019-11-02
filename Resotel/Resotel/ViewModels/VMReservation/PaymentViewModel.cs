using Resotel.Entities;
using Resotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Resotel.ViewModels.VMReservation
{
    public class PaymentViewModel : ViewModelBase
    {
        public Payment Payment { get; set; }
        public InvoicesViewModel InvoicesViewModel { get; set; }

        public PaymentViewModel(Payment payment)
        {
            Payment = payment;
            InvoicesViewModel = new InvoicesViewModel();
        }

        private ICommand commandAddPayment;
        public ICommand CommandAddPayment
        {
            get
            {
                if (commandAddPayment == null)
                {
                    commandAddPayment = new RelayCommand((object sender) =>
                    {
                        Payment.Invoice = InvoicesViewModel.InvoiceSelected.Invoice;
                        ReservationService.Instance.AddPayment(Payment);
                        MessageBox.Show("Le paiement à bien été ajouté", "Message d'information", MessageBoxButton.OK, MessageBoxImage.Information);
                    },
                    (object sender) =>
                    {
                        //if (string.IsNullOrWhiteSpace(Customer.Lastname) || string.IsNullOrWhiteSpace(Customer.Firstname))
                        //{
                        //    return false;
                        //}
                        return true;
                    });
                }

                return commandAddPayment;
            }
        }
    }
}
