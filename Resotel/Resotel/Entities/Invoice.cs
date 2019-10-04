using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public float PriceHT { get; set; }
        public float PriceTTC { get; set; }
        public string BillingAddress { get; set; }
        public string State { get; set; }
        public string Date { get; set; }
        public Reservation Reservation { get; set; }
    }
}