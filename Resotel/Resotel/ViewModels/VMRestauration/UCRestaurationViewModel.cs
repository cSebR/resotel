using Resotel.ViewModels.VMReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.ViewModels.VMRestauration
{
    public class UCRestaurationViewModel : ViewModelBase
    {
        public MealsViewModel MealsViewModel { get; set; }
        public int NbBreakfast { get; set; }
        public int NbLunch { get; set; }
        public int NbDinner { get; set; }
        public int NbTotalMeal { get; set; }

        public UCRestaurationViewModel()
        {

        }

        public UCRestaurationViewModel(string date)
        {
            MealsViewModel = new MealsViewModel(date);
            NbBreakfast = 0;
            NbLunch = 0;
            NbDinner = 0;
            NbTotalMeal = 0;
            foreach (MealViewModel mvm in MealsViewModel.ListMeals)
            {
                if (mvm.Meal.Id == 1)
                {
                    NbBreakfast++;
                }
                else if (mvm.Meal.Id == 2)
                {
                    NbLunch++;
                }
                else if (mvm.Meal.Id == 3)
                {
                    NbDinner++;
                }
            }
            NbTotalMeal = NbBreakfast + NbLunch + NbDinner;
        }

    }
}
