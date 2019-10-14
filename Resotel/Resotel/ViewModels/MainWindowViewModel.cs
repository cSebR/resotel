﻿using Resotel.ViewModels.VMEntretien;
using Resotel.ViewModels.VMReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Resotel.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public ICommand ShowReservationPlanning { get; set; }
        public ICommand ShowListReservation { get; set; }
        public ICommand ShowAddReservation { get; set; }
        public ICommand ShowEntretien { get; set; }

        private object selectedViewModel;

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }

        public MainWindowViewModel()
        {
            ShowReservationPlanning = new RelayCommand(OpenUCReservation);
            ShowListReservation = new RelayCommand(OpenUCListReservation);
            ShowAddReservation = new RelayCommand(OpenUCAddReservation);
            ShowEntretien = new RelayCommand(OpenUCEntretien);
        }

        private void OpenUCReservation(object obj)
        {
            SelectedViewModel = new UCReservationViewModel();
        }
        
        private void OpenUCListReservation(object obj)
        {
            SelectedViewModel = new UCListReservationViewModel();
        }

        private void OpenUCAddReservation(object obj)
        {
            SelectedViewModel = new UCAddReservationViewModel();
        }

        private void OpenUCEntretien(object obj)
        {
            SelectedViewModel = new UCEntretienViewModel();
        }
    }
}