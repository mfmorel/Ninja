using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Ninja.Enum;
using Ninja.Model;
using Ninja.Model.Interfaces;
using Ninja.View;

namespace Ninja.ViewModel
{
    public class EditArmourViewModel : ViewModelBase
    {
        public ICommand SaveArmourCommand { get; set; }
        public ArmourViewModel Armour { get; set; }
        private IArmour _armour;
        public ObservableCollection<string> Categories { get; set; }
        public EditArmourViewModel(ArmourViewModel selectedArmour)
        {
            Armour = selectedArmour;
            _armour = new ArmourRepository();
            Categories = new ObservableCollection<string>(Category.GetCategories());

            SaveArmourCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            _armour.UpdateArmour(Armour.ToModel());

            Router.HideEditArmourView();
        }
    }
}