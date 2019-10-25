using Resotel.Entities;
using Resotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Resotel.ViewModels
{
    class UCLoginViewModel : ViewModelBase
    {
        public Users User { get; set; }

        private string login;
        private string password;

        public UCLoginViewModel()
        {
        }

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                if (login != value)
                {
                    login = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool Validate()
        {
            User = ReservationService.Instance.CheckConnect(login, password);
            if (User != null)
                return true;
            else
                return false;
        }
    }
}
