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
    /// Logique d'interaction pour UCRestauration.xaml
    /// </summary>
    public partial class UCRestauration : UserControl
    {
        public UCRestauration()
        {
            InitializeComponent();
            RestaurationsViewModel resaVM = new RestaurationsViewModel();
            restaurationCalendar.SelectedDate = DateTime.Now;
        }

        private void RestaurationCalendar_SelectedDatesChange(object sender, SelectionChangedEventArgs e)
        {
            if (restaurationCalendar.SelectedDate.HasValue)
            {
                string date = restaurationCalendar.SelectedDate.Value.ToString("yyyy-MM-dd");
                this.DataContext = new RestaurationsViewModel(date);
            }
        }
    }
}
