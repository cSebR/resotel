using Resotel.Entities;
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
    /// Logique d'interaction pour UCAddPayment.xaml
    /// </summary>
    public partial class UCAddPayment : UserControl
    {
        PaymentViewModel pvm;
        public List<string> ListMode = new List<string>();

        public UCAddPayment()
        {
            InitializeComponent();
            ListMode.Add("Chèque bancaire");
            ListMode.Add("Carte bancaire");
            ListMode.Add("Virement bancaire");
            pvm = new PaymentViewModel(new Payment());
            comboBoxModePayment.ItemsSource = ListMode;
            comboBoxModePayment.SelectedItem = ListMode[0];
            this.DataContext = pvm;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pvm.Payment.Mode = comboBoxModePayment.SelectedItem.ToString();
        }
    }
}
