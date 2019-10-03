using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.Entities
{
    public class Bedroom
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string State { get; set; }
        public TypeBedroom TypeBedroom { get; set; }
    }
}
