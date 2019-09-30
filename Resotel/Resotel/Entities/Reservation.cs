using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public Customer Customer { get; set; }
        public Invoice Invoice { get; set; }
    }
}
