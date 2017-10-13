using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Ninja.Model;
using Ninja.Model.Interfaces;
using Ninja.View;

namespace Ninja.ViewModel
{
    public class ArmourListViewModel : ViewModelBase
    {
        public ObservableCollection<ArmourViewModel> ArmourList { get; set; }
        private ArmourViewModel _selectedArmour;

        public ArmourViewModel SelectedArmour
        {
            get { return _selectedArmour; }
            set
            {
                _selectedArmour = value;
                base.RaisePropertyChanged();
            }
        }

        private readonly IArmour _armour;

        public ICommand ShowAddArmourCommand { get; set; }
        public ICommand DeleteSelectedArmourCommand { get; set; }
        public ICommand ShowEditSelectedArmourCommand { get; set; }

        public ArmourListViewModel()
        {
            _armour = new ArmourRepository();
            var armours = _armour.GetArmours().Select(s => new ArmourViewModel(s));
            ArmourList = new ObservableCollection<ArmourViewModel>(armours);

            //commands
            ShowAddArmourCommand = new RelayCommand(ShowAddArmourView);
            DeleteSelectedArmourCommand = new RelayCommand(DeleteSelectedArmour);
            ShowEditSelectedArmourCommand = new RelayCommand(ShowEditView);
        }

        private void ShowAddArmourView()
        {
            Router.AddArmourView.Show();
        }

        private void DeleteSelectedArmour()
        {
            _armour.DeleteArmour(SelectedArmour.ToModel().Id);
            ArmourList.Remove(SelectedArmour);
        }

        private void ShowEditView()
        {
            Router.EditArmourView.Show();
        }
    }
}
