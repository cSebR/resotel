using Resotel.ViewModels.VMReservation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public double PriceHT { get; set; }
        public double PriceTTC { get; set; }
        public string BillingAddress { get; set; }
        public string State { get; set; }
        public DateTime Date { get; set; }
        public Reservation Reservation { get; set; }
        public ObservableCollection<LineInvoiceViewModel> Lines { get; set; }
    }
}