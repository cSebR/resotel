using Resotel.Entities;
using Resotel.ViewModels.VMEntretien;
using Resotel.ViewModels.VMReservation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour UCEntretien.xaml
    /// </summary>
    public partial class UCEntretien : UserControl
    {
        public UCEntretien()
        {
            InitializeComponent();
            this.DataContext = new UCEntretienViewModel();
        }
    }
}
