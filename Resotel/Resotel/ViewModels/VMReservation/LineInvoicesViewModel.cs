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
    public class LineInvoicesViewModel : ViewModelBase
    {
        public ObservableCollection<LineInvoiceViewModel> ListLineInvoices { get; set; }
        private ICollectionView observer;

        public LineInvoiceViewModel LineInvoiceSelected
        {
            get
            {
                return (LineInvoiceViewModel)observer.CurrentItem;
            }
            set
            {
            }
        }

        public LineInvoicesViewModel()
        { 
        }

        public LineInvoicesViewModel(int id)
        {
            addCustomersToList(ReservationService.Instance.ChargerLineInvoicesByInvoice(id));
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("CustomerSelected");
        }

        public void addCustomersToList(List<LineInvoice> listLineInvoices)
        {
            ListLineInvoices = new ObservableCollection<LineInvoiceViewModel>();
            foreach (LineInvoice li in listLineInvoices)
            {
                addCustomerToList(li);
            }
            observer = CollectionViewSource.GetDefaultView(ListLineInvoices);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }

        public void addCustomerToList(LineInvoice li)
        {
            LineInvoiceViewModel lineInvoice = new LineInvoiceViewModel(li);
            ListLineInvoices.Add(lineInvoice);
        }
    }
}
