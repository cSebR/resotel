using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resotel.ViewModels.VMRestauration;

namespace Resotel.Entities
{
    public class Meal
    {
        internal ObservableCollection<RestaurationViewModel> listRestauration;

        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }
}
}
