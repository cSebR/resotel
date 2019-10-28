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

namespace Resotel.ViewModels.VMRestauration
{
    public class RestaurationsViewModel : ViewModelBase
    {

        public ObservableCollection<RestaurationViewModel> ListRestaurations { get; set; }
        private ICollectionView observer;
        private string date;

        public RestaurationsViewModel(string date)
        {
            this.date = date;
        }

        public RestaurationsViewModel()
        {
        }

        public RestaurationViewModel RestaurationSelected
        {
            get
            {
                return (RestaurationViewModel)observer.CurrentItem;
            }
        }

        public RestaurationsViewModel(string date)
        {
            addRestaurationToList(RestaurationService.Instance.ChargerRestaurationsByDate(date));
        }



        public RestaurationsViewModel(int id)
        {
        }

        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("RestaurationSelected");
        }


        public void addRestaurationToList(List<LinkMeal> listRestauration)
        {
            ListRestaurations = new ObservableCollection<RestaurationViewModel>();
            foreach (LinkMeal r in listRestauration)
            {

                RestaurationsViewModel mvm = new RestaurationsViewModel(r.Id);
                r.listRestauration = mvm.ListRestaurations;

                RestaurationViewModel reservation = new RestaurationViewModel(r);
                ListRestaurations.Add(reservation);
            }

            observer = CollectionViewSource.GetDefaultView(ListRestaurations);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }
    }
}
