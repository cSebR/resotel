using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resotel.ViewModels.VMRestauration;

namespace Resotel.Entities
{
    public class LinkMeal
    {
        internal ObservableCollection<RestaurationViewModel> listRestauration;

        public int Id { get; set; }
        public int Id_resa { get; set; }
        public DateTime Date { get; set; }

    }
}
