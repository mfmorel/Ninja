﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Ninja.Model;
using Ninja.View;
using Ninja.View.UserControl;

namespace Ninja.ViewModel
{
    public class NinjaListViewModel : Router
    {
        public ObservableCollection<NinjaViewModel> NinjaList { get; set; }
        private NinjaViewModel _selectedNinja;

        public NinjaViewModel SelectedNinja
        {
            get { return _selectedNinja; }
            set
            {
                _selectedNinja = value;
                base.RaisePropertyChanged();
            }
        }

        private readonly INinja ninja;

        public ICommand ShowAddNinjaCommand { get; set; }
        public ICommand DeleteSelectedNinjaCommand { get; set; }

        public NinjaListViewModel()
        {
            ninja = new NinjaRepository();
            var ninjas = ninja.GetNinjas().Select(s => new NinjaViewModel(s));
            NinjaList = new ObservableCollection<NinjaViewModel>(ninjas);

            // Commands
            ShowAddNinjaCommand = new RelayCommand(ShowAddNinja);
            DeleteSelectedNinjaCommand = new RelayCommand(DeleteSelectedNinja);
        }

        public void ShowAddNinja()
        {
            GetAddNinjaView.Show();
        }

        private void DeleteSelectedNinja()
        {
            ninja.DeleteNinja(SelectedNinja.Name);
            NinjaList.Remove(SelectedNinja);
        }
    }
}