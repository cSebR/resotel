using Resotel.Entities;
using Resotel.ViewModels;
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
    /// Logique d'interaction pour UCAddCustomer.xaml
    /// </summary>
    public partial class UCAddCustomer : UserControl
    {
        public UCAddCustomer()
        {
            InitializeComponent();
            this.DataContext = new CustomerViewModel(new Customer());
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (var child in addCustomerGrid.Children.OfType<StackPanel>())
            {
                foreach (var child2 in child.Children.OfType<TextBox>())
                {
                    child2.Text = "";
                }
            }
        }
    }
}
