
using Resotel.Entities;
using Resotel.Services;
using Resotel.ViewModels.VMReservation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Resotel.ViewModels.VMRestauration
{
    public class UCAddRestaurationViewModel : ViewModelBase
    {
        public ObservableCollection<MealViewModel> ListMeals { get; set; }
        public ReservationsViewModel ReservationsViewModel { get; set; }
        public MealsViewModel MealsViewModel { get; set; }

        public UCAddRestaurationViewModel()
        {
            ListMeals = new ObservableCollection<MealViewModel>();
            ReservationsViewModel = new ReservationsViewModel();
            MealsViewModel = new MealsViewModel();
        }

        private ICommand commandSave;
        public ICommand CommandSave
        {
            get
            {
                if (commandSave == null)
                {
                    commandSave = new RelayCommand((object sender) =>
                    {
                        RestaurationService.Instance.SaveRestauration(ListMeals, ReservationsViewModel.ReservationSelected.Reservation.Id);
                        ListMeals.Clear();
                        MessageBox.Show("Les repas ont bien été ajouté !", "Message d'information", MessageBoxButton.OK, MessageBoxImage.Information);
                    },
                    (object sender) =>
                    {
                        if (!ListMeals.Any())
                        {
                            return false;
                        }
                        return true;
                    });
                }
                return commandSave;
            }
        }
    }
}