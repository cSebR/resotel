using Resotel.Entities;
using Resotel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Resotel.ViewModels.VMReservation
{
    public class CustomersViewModel : ViewModelBase
    {
        public ObservableCollection<CustomerViewModel> ListCustomers { get; set; }
        private ICollectionView observer;

        public CustomerViewModel CustomerSelected
        {
            get
            {
                return (CustomerViewModel)observer.CurrentItem;
            }
            set
            {

            }
        }

        public CustomersViewModel()
        {
            addCustomersToList(ReservationService.Instance.ChargerAllCustomers());
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("CustomerSelected");
        }

        public void addCustomersToList(List<Customer> listCustomers)
        {
            ListCustomers = new ObservableCollection<CustomerViewModel>();
            foreach (Customer c in listCustomers)
            {
                addCustomerToList(c);
            }
            observer = CollectionViewSource.GetDefaultView(ListCustomers);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }

        private void deleteCustomer(object sender, EventArgs e)
        {
            this.ListCustomers.Remove(CustomerSelected);
            observer.MoveCurrentToFirst();
        }

        public void addCustomerToList(Customer c)
        {
            CustomerViewModel customer = new CustomerViewModel(c);
            customer.DelCustomer += deleteCustomer;
            ListCustomers.Add(customer);
        }

        private ICommand commandNewCustomer;
        public ICommand CommandNewCustomer
        {
            get
            {
                if (commandNewCustomer == null)
                {
                    commandNewCustomer = new RelayCommand((object sender) =>
                    {
                        addCustomerToList(new Customer());
                        OnPropertyChanged("ListCustomers");
                        observer.MoveCurrentToLast();
                    });
                }
                return commandNewCustomer;
            }
        }
    }
}
