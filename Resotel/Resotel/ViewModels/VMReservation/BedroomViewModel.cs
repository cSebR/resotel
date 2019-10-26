using Resotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.ViewModels.VMReservation
{
    public class BedroomViewModel
    {
        public Bedroom Bedroom { get; }
        public BedroomViewModel(Bedroom bedroom)
        {
            Bedroom = bedroom;
        }

        public string Name
        {
            get
            {
                return Bedroom.Number + " - " + Bedroom.TypeBedroom.Name + " (" + Bedroom.TypeBedroom.Price + " €) - " + Bedroom.State;
            }
        }
        public string ListeForEntretien
        {
            get
            {
                return " " + Bedroom.Number + " ";
            }
        }
        public string NameForEntretien
        {
            get
            {
                return "                    " +
                    " " + Bedroom.Number + "                                         " +
                    " " + Bedroom.TypeBedroom.Name + " (" + Bedroom.TypeBedroom.Price + " €)                                  " +
                    " " + Bedroom.State;
            }
        }
       
    }
}
