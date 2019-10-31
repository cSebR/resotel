using Resotel.ViewModels.VMEntretien;
using Resotel.ViewModels.VMReservation;
using Resotel.ViewModels.VMRestauration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Resotel.ViewModels
{
    class UCMenuDivideViewModel : ViewModelBase
    {
        public ICommand ShowReservationPlanning { get; set; }
        public ICommand ShowListReservation { get; set; }
        public ICommand ShowAddReservation { get; set; }
        public ICommand ShowEntretien { get; set; }
        public ICommand ShowListCustomer { get; set; }
        public ICommand ShowAddCustomer { get; set; }
        public ICommand ShowAddRestauration { get; set; }
        public ICommand ShowRestauration { get; set; }
        public ICommand ShowListInvoice { get; set; }

        private object selectedViewModel;

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }

        public UCMenuDivideViewModel()
        {
            ShowReservationPlanning = new RelayCommand(OpenUCReservation);
            ShowListReservation = new RelayCommand(OpenUCListReservation);
            ShowAddReservation = new RelayCommand(OpenUCAddReservation);
            ShowEntretien = new RelayCommand(OpenUCEntretien);
            ShowListCustomer = new RelayCommand(OpenUCListCustomer);
            ShowAddCustomer = new RelayCommand(OpenUCAddCustomer);
            ShowAddRestauration = new RelayCommand(OpenUCAddRestauration);
            ShowRestauration = new RelayCommand(OpenUCRestauration);
            ShowListInvoice = new RelayCommand(OpenUCListInvoice);
            SelectedViewModel = new UCReservationViewModel();
        }

        public void OpenUCReservation(object obj)
        {
            SelectedViewModel = new UCReservationViewModel();
        }

        private void OpenUCListReservation(object obj)
        {
            SelectedViewModel = new UCListReservationViewModel();
        }

        private void OpenUCAddReservation(object obj)
        {
            SelectedViewModel = new UCAddReservationViewModel();
        }

        private void OpenUCEntretien(object obj)
        {
            SelectedViewModel = new UCEntretienViewModel();
        }

        private void OpenUCListCustomer(object obj)
        {
            SelectedViewModel = new UCListCustomerViewModel();
        }

        private void OpenUCAddCustomer(object obj)
        {
            SelectedViewModel = new UCAddCustomerViewModel();
        }

        private void OpenUCAddRestauration(object obj)
        {
            SelectedViewModel = new UCAddRestaurationViewModel();
        }

        private void OpenUCRestauration(object obj)
        {
            SelectedViewModel = new UCRestaurationViewModel();
        }

        private void OpenUCListInvoice(object obj)
        {
            SelectedViewModel = new UCListInvoiceViewModel();
        }
    }
}
