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
            List<Option> listOptions = ReservationService.Instance.ChargerAllOptions();

            ListOptions = new ObservableCollection<OptionViewModel>();
            foreach (Option o in listOptions)
            {
                addOptionsToList(o);
            }

            observer = CollectionViewSource.GetDefaultView(ListOptions);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("OptionSelected");
        }

        public void addOptionsToList(Option op)
        {
            OptionViewModel option = new OptionViewModel(op);
            ListOptions.Add(option);
        }
    }
}
