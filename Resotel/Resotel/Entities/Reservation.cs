using Resotel.ViewModels.VMReservation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Customer Customer { get; set; }
        public ObservableCollection<BedroomViewModel> ListBedroom { get; set; }
        public ObservableCollection<OptionViewModel> ListOptions { get; set; }
        public ObservableCollection<MealViewModel> ListMeal { get; set; }
    }
}
