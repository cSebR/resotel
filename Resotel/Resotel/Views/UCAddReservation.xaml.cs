using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Resotel.ViewModels.VMReservation;
using Resotel.Entities;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Resotel.Views
{
    /// <summary>
    /// Logique d'interaction pour UCAddReservation.xaml
    /// </summary>
    public partial class UCAddReservation : UserControl
    {
        private ReservationViewModel resa;
        public UCAddReservation()
        {
            InitializeComponent();
            mealDatePicker.SelectedDate = DateTime.Now;

            resa = new ReservationViewModel(new Reservation());
            resa.Reservation.DateStart = DateTime.Now;
            resa.Reservation.DateEnd = DateTime.Now;
            resa.Reservation.Date = DateTime.Now;
            resa.Reservation.ListMeal = new ObservableCollection<MealViewModel>();
            resa.Reservation.ListBedroom = new ObservableCollection<BedroomViewModel>();
            resa.Reservation.ListOptions = new ObservableCollection<OptionViewModel>();
            resa.Reservation.Customer = new Customer();
            resa.CustomersViewModel = new CustomersViewModel();
            resa.MealsViewModel = new MealsViewModel();
            resa.OptionsViewModel = new OptionsViewModel();
            resa.BedroomsViewModel = new BedroomsViewModel("Available");


            this.DataContext = resa;
        }

        private void AddMealToList(object sender, RoutedEventArgs e)
        {
            resa.Reservation.ListMeal.Add(resa.MealsViewModel.MealSelected);
            resa.Reservation.ListMeal.Last().Meal.Date = mealDatePicker.SelectedDate.Value;
        }

        private void AddBedroomToList(object sender, RoutedEventArgs e)
        {
            resa.Reservation.ListBedroom.Add(resa.BedroomsViewModel.BedroomSelected);
        }

        private void AddOptionToList(object sender, RoutedEventArgs e)
        {
            resa.Reservation.ListOptions.Add(resa.OptionsViewModel.OptionSelected);
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (var child in addReservationGrid.Children.OfType<StackPanel>())
            {
                foreach (var child2 in child.Children.OfType<TextBox>())
                {
                    child2.Text = "";
                }
            }
        }
    }
}
