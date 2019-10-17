using Resotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.ViewModels.VMReservation
{
    public class MealViewModel
    {
        public Meal Meal { get; }
        public MealViewModel(Meal meal)
        {
            Meal = meal;
        }

        public string NameDate
        {
            get
            {
                return Meal.Date.Day + "/" + Meal.Date.Month + "/" + Meal.Date.Year + " - " + Meal.Name + " (" + Meal.Price + " €)";
            }
        }

        public string Name
        {
            get
            {
                return Meal.Name + " (" + Meal.Price + " €)";
            }
        }
    }
}
