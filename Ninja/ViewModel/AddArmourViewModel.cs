using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Domain;
using GalaSoft.MvvmLight.CommandWpf;
using Ninja.Enum;
using Ninja.View;

namespace Ninja.ViewModel
{
    public class AddArmourViewModel
    {
        private ArmourListViewModel _armours;
        public ArmourViewModel Armour { get; set; }
        public ICommand AddArmourCommand { get; set; }
        public ObservableCollection<string> Categories { get; set; }

        public AddArmourViewModel(ArmourListViewModel armours)
        {
            _armours = armours;
            Armour = new ArmourViewModel();
            Categories = new ObservableCollection<string>(GetCategories());

            //commands
            AddArmourCommand = new RelayCommand(AddArmour, CanAddArmour);
        }

        private ObservableCollection<string> GetCategories()
        {
            var cats = new ObservableCollection<string>();
            foreach (var cat in typeof(ECategory).GetEnumValues())
            {
                cats.Add(cat.ToString());
            }
            return cats;
        }

        private void AddArmour()
        {
            using (var context = new NinjaEntities())
            {
                context.Armours.Add(Armour.ToModel());
                context.SaveChanges();
            }

            _armours.ArmourList.Add(Armour);

            Router.HideArmourView();
        }

        private bool CanAddArmour()
        {
            return true;
        }
    }
}