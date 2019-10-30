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
    }
}
