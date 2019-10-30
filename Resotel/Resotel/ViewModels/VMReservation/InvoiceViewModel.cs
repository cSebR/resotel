using Resotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Resotel.ViewModels.VMReservation
{
    public class InvoiceViewModel : ViewModelBase
    {
        public Invoice Invoice { get; }
        public LineInvoicesViewModel LineInvoicesViewModel { get; set; }

        public InvoiceViewModel(Invoice invoice)
        {
            Invoice = invoice;
            if (Invoice.Id == 0)
            {
                LineInvoicesViewModel = new LineInvoicesViewModel();
            }
            else
            {
                LineInvoicesViewModel = new LineInvoicesViewModel(Invoice.Id);
            }
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
                        //ReservationService.Instance.SaveCustomer(Customer);
                        //ClearFields();
                        //MessageBox.Show("Le client à bien été ajouté", "Message d'information", MessageBoxButton.OK, MessageBoxImage.Information);
                    },
                    (object sender) =>
                    {
                        //if (string.IsNullOrWhiteSpace(Customer.Lastname) || string.IsNullOrWhiteSpace(Customer.Firstname))
                        //{
                        //    return false;
                        //}
                        return true;
                    });
                }

                return commandSave;
            }
        }

        public event EventHandler DelInvoice;
        private ICommand commandDel;
        public ICommand CommandDel
        {
            get
            {
                if (commandDel == null)
                {
                    commandDel = new RelayCommand((object sender) =>
                    {
                        //if (Customer.Id > 0)
                        //    ReservationService.Instance.DelCustomer(Customer);
                        //DelCustomer?.Invoke(this, EventArgs.Empty);
                        //MessageBox.Show("Le client à bien été supprimé", "Message d'informationr", MessageBoxButton.OK, MessageBoxImage.Information);
                    });
                }
                return commandDel;
            }
        }

        //private void ClearFields()
        //{
        //    Customer.Lastname = "";
        //    Customer.Firstname = "";
        //    Customer.Address = "";
        //    Customer.CityCode = "";
        //    Customer.City = "";
        //    Customer.Email = "";
        //    Customer.Phone = "";
        //}
    }
}
