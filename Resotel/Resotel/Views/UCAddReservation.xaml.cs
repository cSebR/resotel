using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Resotel.ViewModels.VMReservation;
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
    /// Logique d'interaction pour UCAddReservation.xaml
    /// </summary>
    public partial class UCAddReservation : UserControl
    {
        public UCAddReservation()
        {
            InitializeComponent(); 
            BedroomComboBox.DataContext = new BedroomsViewModel();
            //this.DataContext = new OptionsViewModel();    
            OptionComboBox.DataContext = new OptionsViewModel();
        }
    }
}
