using Resotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.ViewModels.VMReservation
{
    class OptionViewModel
    {
        public Option Option { get; }
        public OptionViewModel(Option option)
        {
            Option = option;
        }

        public string Name
        {
            get
            {
                return Option.Name + " (" + Option.Price + " €)";
            }
        }
    }
}
