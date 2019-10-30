using Resotel.Entities;
using Resotel.ViewModels.VMEntretien;
using Resotel.ViewModels.VMReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Resotel.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public ICommand ShowMenuDivide { get; set; }
        public ICommand ShowLogin { get; set; }

        public UCLoginViewModel UCLoginViewModel = new UCLoginViewModel();


        private object selectedViewModel;

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }

        public MainWindowViewModel()
        {
            ShowLogin = new RelayCommand(OpenUCLogin);
            ShowMenuDivide = new RelayCommand(OpenUCMenuDivide);
            SelectedViewModel = UCLoginViewModel;
        }

        private void OpenUCLogin(object obj)
        {
            SelectedViewModel = new UCLoginViewModel();
        }

        private void OpenUCMenuDivide(object obj)
        {
            SelectedViewModel = new UCMenuDivideViewModel();
        }

        private ICommand commandConnect;
        public ICommand CommandConnect
        {
            get
            {
                if (commandConnect == null)
                {
                    commandConnect = new RelayCommand((object sender) =>
                    {
                        PasswordBox passwordBox = (PasswordBox)sender;
                        UCLoginViewModel.Password = passwordBox.Password;
                        bool isValidated = UCLoginViewModel.Validate();
                        if (isValidated)
                        {
                            Application.Current.Properties["UserConnected"] = UCLoginViewModel.User;
                            SelectedViewModel = new UCMenuDivideViewModel();
                        }
                        else
                        {
                            MessageBox.Show("Identifiant ou mot de passe erroné !", "Message d'erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }, (object sender) =>
                    {
                        if (string.IsNullOrWhiteSpace(UCLoginViewModel.Login))
                        {
                            return false;
                        }
                        return true;
                    });
                }
                return commandConnect;
            }
        }

        private ICommand commandDisconnect;
        public ICommand CommandDisconnect
        {
            get
            {
                if (commandDisconnect == null)
                {
                    commandDisconnect = new RelayCommand((object sender) =>
                    {
                        UCLoginViewModel = new UCLoginViewModel();
                        SelectedViewModel = UCLoginViewModel;
                    });
                }

                return commandDisconnect;
            }
        }
    }
}
