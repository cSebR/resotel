using Resotel.ViewModels.VMReservation;
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
        public UCAddRestauration()
        {
            InitializeComponent();
            listBoxMeal.DataContext = new MealsViewModel();
            mealComboBox.DataContext = new MealsViewModel();
            reservComboBox.DataContext = new ReservationsViewModel();
        }

        private void AddMealToList(object sender, RoutedEventArgs e)
        {
            listBoxMeal.Items.Add(mealDatePicker.SelectedDate.Value.ToString("dd/MM/yyyy") + " - " + mealComboBox.SelectedValue.ToString());
        }
    
    }
}
