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

namespace Resotel.ViewModels.VMReservation
{
    class OptionsViewModel : ViewModelBase
    {
        public ObservableCollection<OptionViewModel> ListOptions { get; set; }
        private ICollectionView observer;

        public OptionViewModel OptionSelected
        {
            get
            {
                return (OptionViewModel)observer.CurrentItem;
            }
            set
            {

            }
        }

        public OptionsViewModel()
        {
            addOptionsToList(ReservationService.Instance.ChargerAllOptions());
        }

        public OptionsViewModel(int id)
        {
            addOptionsToList(ReservationService.Instance.ChargerOptionByReservation(id));
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("OptionSelected");
        }

        public void addOptionsToList(List<Option> listOptions)
        {
            ListOptions = new ObservableCollection<OptionViewModel>();
            foreach (Option o in listOptions)
            {
                OptionViewModel option = new OptionViewModel(o);
                ListOptions.Add(option);
            }

            observer = CollectionViewSource.GetDefaultView(ListOptions);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }
    }
}
