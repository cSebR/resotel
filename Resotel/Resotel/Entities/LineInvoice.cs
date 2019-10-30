using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.Entities
{
    public class LineInvoice
    {
        public string Description { get; set; }
        public float Pht { get; set; }
        public float Tva { get; set; }
        public float Pttc { get; set; }
    }
}
