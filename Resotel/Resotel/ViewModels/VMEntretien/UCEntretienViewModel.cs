using Resotel.Services;
using Resotel.ViewModels.VMReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Resotel.ViewModels.VMEntretien
{
    public class UCEntretienViewModel
    {
        public BedroomsViewModel BedroomsViewModelAll { get; set; }
        public BedroomsViewModel BedroomsViewModelToClean { get; set; }

        public UCEntretienViewModel()
        {
            BedroomsViewModelAll = new BedroomsViewModel("All");
            BedroomsViewModelToClean = new BedroomsViewModel("ToClean");
        }

        private ICommand commandChangeStatus;
        public ICommand CommandChangeStatus
        {
            get
            {
                if (commandChangeStatus == null)
                {
                    commandChangeStatus = new RelayCommand((object sender) =>
                    {
                        BedroomsViewModelToClean.BedroomSelected.Bedroom.State = "Nettoyé";
                        BedroomsViewModelToClean.BedroomSelected.Bedroom.DateLastClean = DateTime.Now;
                        ReservationService.Instance.ChangeBedroomStatus(BedroomsViewModelToClean.BedroomSelected.Bedroom);
                        MessageBox.Show("L'état de la chambre a bien été changé !", "Message d'information", MessageBoxButton.OK, MessageBoxImage.Information);

                    });
                }
                return commandChangeStatus;
            }
        }
    }
}
