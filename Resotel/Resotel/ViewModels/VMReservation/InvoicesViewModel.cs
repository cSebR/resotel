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
    public class InvoicesViewModel : ViewModelBase
    {
        public ObservableCollection<InvoiceViewModel> ListInvoices { get; set; }
        private ICollectionView observer;

        public InvoiceViewModel InvoiceSelected
        {
            get
            {
                return (InvoiceViewModel)observer.CurrentItem;
            }
            set
            {
            }
        }

        public InvoicesViewModel()
        {
            addCustomersToList(ReservationService.Instance.ChargerAllInvoices());
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("CustomerSelected");
        }

        public void addCustomersToList(List<Invoice> listInvoices)
        {
            ListInvoices = new ObservableCollection<InvoiceViewModel>();
            foreach (Invoice i in listInvoices)
            {
                addCustomerToList(i);
            }
            observer = CollectionViewSource.GetDefaultView(ListInvoices);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }

        private void deleteInvoice(object sender, EventArgs e)
        {
            this.ListInvoices.Remove(InvoiceSelected);
            observer.MoveCurrentToFirst();
        }

        public void addCustomerToList(Invoice i)
        {
            InvoiceViewModel invoice = new InvoiceViewModel(i);
            invoice.DelInvoice += deleteInvoice;
            ListInvoices.Add(invoice);
        }
    }
}
