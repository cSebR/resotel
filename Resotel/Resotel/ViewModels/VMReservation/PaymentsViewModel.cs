using Resotel.Entities;
using Resotel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Resotel.ViewModels.VMReservation
{
    public class PaymentsViewModel :ViewModelBase
    {
        public ObservableCollection<PaymentViewModel> ListPayments { get; set; }
        private ICollectionView observer;

        public PaymentViewModel PaymentSelected
        {
            get
            {
                return (PaymentViewModel)observer.CurrentItem;
            }
            set
            {
            }
        }

        public PaymentsViewModel()
        {
            //addPaymentsToList(ReservationService.Instance.ChargerAllPayments());
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("PaymentSelected");
        }

        public void addPaymentsToList(List<Payment> listPayments)
        {
            ListPayments = new ObservableCollection<PaymentViewModel>();
            foreach (Payment p in listPayments)
            {
                addPaymentToList(p);
            }
            observer = CollectionViewSource.GetDefaultView(ListPayments);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }

        public void addPaymentToList(Payment p)
        {
            PaymentViewModel payment = new PaymentViewModel(p);
            ListPayments.Add(payment);
        }
    }
}
