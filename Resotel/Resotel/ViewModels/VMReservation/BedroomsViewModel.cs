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
    class BedroomsViewModel : ViewModelBase
    {
        public ObservableCollection<BedroomViewModel> ListBedrooms { get; set; }
        private ICollectionView observer;

        public BedroomViewModel BedroomSelected
        {
            get
            {
                return (BedroomViewModel)observer.CurrentItem;
            }
            set
            {

            }
        }

        public BedroomsViewModel()
        {
            List<Bedroom> listBedrooms = ReservationService.Instance.ChargerAllBedroom();

            ListBedrooms = new ObservableCollection<BedroomViewModel>();
            foreach (Bedroom b in listBedrooms)
            {
                addBedroomToList(b);
            }

            observer = CollectionViewSource.GetDefaultView(ListBedrooms);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("BedroomSelected");
        }

        public void addBedroomToList(Bedroom bed)
        {
            BedroomViewModel bedroom = new BedroomViewModel(bed);
            ListBedrooms.Add(bedroom);
        }
    }
}
