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
    public class BedroomsViewModel : ViewModelBase
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

        public BedroomsViewModel(string query)
        {
            if (query == "All")
                addBedroomToList(ReservationService.Instance.ChargerAllBedroom());
            else if (query == "Available")
                addBedroomToList(ReservationService.Instance.ChargerAllAvailableBedroom());
            else if (query == "ToClean")
                addBedroomToList(ReservationService.Instance.ChargerAllBedroomToClean());
        }

        public BedroomsViewModel(int id)
        {
            addBedroomToList(ReservationService.Instance.ChargerBedroomByReservation(id));
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("BedroomSelected");
        }

        public void addBedroomToList(List<Bedroom> listBedrooms)
        {
            ListBedrooms = new ObservableCollection<BedroomViewModel>();
            foreach (Bedroom b in listBedrooms)
            {
                BedroomViewModel bedroom = new BedroomViewModel(b);
                ListBedrooms.Add(bedroom);
            }

            observer = CollectionViewSource.GetDefaultView(ListBedrooms);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }
    }
}
