using Resotel.Entities;
using Resotel.ViewModels.VMReservation;
using Resotel.ViewModels.VMRestauration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Resotel.Views
{
    /// <summary>
    /// Logique d'interaction pour UCAddRestauration.xaml
    /// </summary>
    public partial class UCAddRestauration : UserControl
    {
        public UCAddRestaurationViewModel ucarvm;
        public UCAddRestauration()
        {
            InitializeComponent();
            mealDatePicker.SelectedDate = DateTime.Now;
            ucarvm = new UCAddRestaurationViewModel();
            this.DataContext = ucarvm;
        }

        private void AddMealToList(object sender, RoutedEventArgs e)
        {
            ucarvm.ListMeals.Add(ucarvm.MealsViewModel.MealSelected);
            ucarvm.ListMeals.Last().Meal.Date = mealDatePicker.SelectedDate.Value;
        }

    }
}