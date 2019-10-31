using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.Entities
{
    public class LineInvoice
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Pht { get; set; }
        public double Tva { get; set; }
        public double Pttc { get; set; }
    }
}
