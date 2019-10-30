using System;
using System.Collections.Generic;
using Resotel.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.ViewModels.VMReservation
{
    public class UCAddInvoiceViewModel
    {
        public InvoiceViewModel InvoiceViewModel { get; set; }
        public ReservationsViewModel ReservationsViewModel { get; set; }

        public UCAddInvoiceViewModel()
        {
            InvoiceViewModel = new InvoiceViewModel(new Entities.Invoice());
            ReservationsViewModel = new ReservationsViewModel();
            //foreach (BedroomViewModel b in ReservationsViewModel.ReservationSelected.BedroomsViewModel.ListBedrooms)
            //{
            //    InvoiceViewModel.LineInvoicesViewModel.ListLineInvoices.Add(new LineInvoiceViewModel(new LineInvoice { Description = "test", Pttc = 8 }));
            //}
        }
    }
}
