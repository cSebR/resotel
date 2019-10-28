using Resotel.Entities;
using Resotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Resotel.ViewModels.VMRestauration
{
    public class RestaurationViewModel
    {
        public LinkMeal Restauration { get; }

        public RestaurationViewModel(LinkMeal restauration)
        {
            Restauration = restauration;
        }

        private ICommand commandSaverestauration;
        public ICommand CommandSaveRestauration
        {
            get
            {
                if (commandSaverestauration == null)
                {
                    commandSaverestauration = new RelayCommand((object sender) =>
                    {
                        RestaurationService.Instance.SaveRestauration(Restauration);
                    });
                    /*(object sender) =>
                    {
                        if (string.IsNullOrWhiteSpace(Restauration.Id))
                        {
                            return false;
                        }
                        return true;
                    });*/
                }
                return commandSaverestauration;
            }
        }
    }
}