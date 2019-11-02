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
        }

        public string Name
        {
            get
            {
                return Invoice.Id + " - " + Invoice.Date.Day + "/" + Invoice.Date.Month + "/" + Invoice.Date.Year + " - " + " - " + Invoice.Reservation.Number + " - " + Invoice.Reservation.Customer.Lastname + " " + Invoice.Reservation.Customer.Firstname;
            }
        }

        public string TotalHt
        {
            get
            {
                return Invoice.PriceHT.ToString("0.00") + " €";
            }
        }

        public string TotalTva
        {
            get
            {
                return (Invoice.PriceTTC - Invoice.PriceHT).ToString("0.00") + " €";
            }
        }

        public string TotalTtc
        {
            get
            {
                return Invoice.PriceTTC.ToString("0.00") + " €";
            }
        }

        //public event EventHandler DelInvoice;
        //private ICommand commandDel;
        //public ICommand CommandDel
        //{
        //    get
        //    {
        //        if (commandDel == null)
        //        {
        //            commandDel = new RelayCommand((object sender) =>
        //            {
        //                if (Customer.Id > 0)
        //                    ReservationService.Instance.DelCustomer(Customer);
        //                DelCustomer?.Invoke(this, EventArgs.Empty);
        //                MessageBox.Show("Le client à bien été supprimé", "Message d'informationr", MessageBoxButton.OK, MessageBoxImage.Information);
        //            });
        //        }
        //        return commandDel;
        //    }
        //}

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
