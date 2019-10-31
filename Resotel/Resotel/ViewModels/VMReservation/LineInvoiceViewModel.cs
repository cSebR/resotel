using Resotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.ViewModels.VMReservation
{
    public class LineInvoiceViewModel
    {
        public LineInvoice LineInvoice { get; }

        public LineInvoiceViewModel(LineInvoice lineInvoice)
        {
            LineInvoice = lineInvoice;
        }

        public string Pht
        {
            get
            {
                return LineInvoice.Pht.ToString("0.00") + " €";
            }
        }

        public string Tva
        {
            get
            {
                return LineInvoice.Tva.ToString("0.00") + " €";
            }
        }

        public string Pttc
        {
            get
            {
                return LineInvoice.Pttc.ToString("0.00") + " €";
            }
        }
    }
}
