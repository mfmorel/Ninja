﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Ninja.Helper;
using Ninja.Model;
using Ninja.View;

namespace Ninja.ViewModel
{
    public class NinjaListViewModel : ViewModelBase
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
        public ICommand ShowNinjaCommand { get; set; }
        public ICommand ShowEditSelectedNinjaCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public NinjaListViewModel()
        {
            ninja = new NinjaRepository();
            var ninjas = ninja.GetNinjas().Select(s => new NinjaViewModel(s));
            NinjaList = new ObservableCollection<NinjaViewModel>(ninjas);

            // Commands
            ShowAddNinjaCommand = new RelayCommand(ShowAddNinja);
            DeleteSelectedNinjaCommand = new RelayCommand(DeleteSelectedNinja);
            ShowNinjaCommand = new RelayCommand(ShowNinja);
            ShowEditSelectedNinjaCommand = new RelayCommand(ShowEditSelectedNinja);
            ExitCommand = new RelayCommand(Exit);
        }

        public void ShowNinja()
        {
            Router.NinjaView.Show();
            ShowInventory();
            ShowShop();
            Router.HideNinjaListView();
        }

        public void ShowInventory()
        {
            Router.InventoryView.Show();
        }

        public void ShowShop()
        {
            Router.ShopView.Show();
        }

        public void ShowAddNinja()
        {
            Router.AddNinjaView.Show();
        }

        private void DeleteSelectedNinja()
        {
            ninja.DeleteNinja(SelectedNinja.ToModel().Id);
            NinjaList.Remove(SelectedNinja);
        }

        private void ShowEditSelectedNinja()
        {
            Router.EditNinjaView.Show();
        }

        private void Exit()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}