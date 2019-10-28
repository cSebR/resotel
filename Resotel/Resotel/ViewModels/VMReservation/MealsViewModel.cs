using Resotel.Entities;
using Resotel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Resotel.ViewModels.VMReservation
{
    public class MealsViewModel : ViewModelBase
    {
        public ObservableCollection<MealViewModel> ListMeals { get; set; }
        private ICollectionView observer;

        public MealViewModel MealSelected
        {
            get
            {
                return (MealViewModel)observer.CurrentItem;
            }
            set
            {

            }
        }

        public MealsViewModel()
        {
            addMealsToList(ReservationService.Instance.ChargerAllMeals());
        }

        public MealsViewModel(int id)
        {
            addMealsToList(ReservationService.Instance.ChargerMealByReservation(id));
        }

        public MealsViewModel(string date)
        {
            addMealsToList(RestaurationService.Instance.ChargerRestaurationsByDate(date));
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("OptionSelected");
        }

        public void addMealsToList(List<Meal> listMeals)
        {
            ListMeals = new ObservableCollection<MealViewModel>();
            foreach (Meal m in listMeals)
            {
                MealViewModel meal = new MealViewModel(m);
                ListMeals.Add(meal);
            }
            observer = CollectionViewSource.GetDefaultView(ListMeals);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }
    }
}
