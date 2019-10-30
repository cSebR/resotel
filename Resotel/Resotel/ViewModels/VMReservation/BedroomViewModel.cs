using Resotel.Entities;
using Resotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

        public string DateLastClean
        {
            get
            {
                return Bedroom.DateLastClean.Day + "/" + Bedroom.DateLastClean.Month + "/" + Bedroom.DateLastClean.Year;
            }
        }
        public string RowColor
        {
            get
            {
                if (Bedroom.State == "Non nettoyé")
                    return "#ffd6d1";
                else
                    return "White";
            }
        }
    }
}
