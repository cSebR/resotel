using Resotel.Entities;
using Resotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Resotel.ViewModels.VMReservation
{
    public class CustomerViewModel : ViewModelBase
    {
        public Customer Customer { get; }

        public CustomerViewModel (Customer customer)
        {
            Customer = customer;
        }

        public string LastName
        {
            get
            {
                return Customer.Lastname;
            }

            set
            {
                Customer.Lastname = value;
                OnPropertyChanged();
                OnPropertyChanged("Name");
            }
        }

        public string FirstName
        {
            get
            {
                return Customer.Firstname;
            }

            set
            {
                Customer.Firstname = value;
                OnPropertyChanged();
                OnPropertyChanged("Name");
            }
        }

        public string Name 
        {
            get
            {
                return Customer.Lastname + " " + Customer.Firstname;
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
                        ReservationService.Instance.SaveCustomer(Customer);
                        ClearFields();
                    },
                    (object sender) =>
                    {
                        if (string.IsNullOrWhiteSpace(Customer.Lastname) || string.IsNullOrWhiteSpace(Customer.Firstname))
                        {
                            return false;
                        }
                        return true;
                    });
                }

                return commandSave;
            }
        }

        public event EventHandler DelCustomer;
        private ICommand commandDel;
        public ICommand CommandDel
        {
            get
            {
                if (commandDel == null)
                {
                    commandDel = new RelayCommand((object sender) =>
                    {
                        if (Customer.Id > 0)
                            ReservationService.Instance.DelCustomer(Customer);
                        DelCustomer?.Invoke(this, EventArgs.Empty);
                    });
                }
                return commandDel;
            }
        }

        private void ClearFields()
        {
            Customer.Lastname = "";
            Customer.Firstname = "";
            Customer.Address = "";
            Customer.CityCode = "";
            Customer.City = "";
            Customer.Email = "";
            Customer.Phone = "";
        }
    }
}
