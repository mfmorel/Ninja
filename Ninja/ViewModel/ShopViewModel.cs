using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Ninja.Enum;
using Ninja.Model;

namespace Ninja.ViewModel
{
    public class ShopViewModel : ViewModelBase
    {
        private ArmourListViewModel _armourListViewModel;

        public ArmourListViewModel ArmourListViewModel
        {
            get { return _armourListViewModel; }
            set
            {
                _armourListViewModel = value;
                RaisePropertyChanged();
            }
        }

        public ICommand ChangeCategoryToHeadCommand { get; set; }
        public ICommand ChangeCategoryToBeltCommand { get; set; }
        public ICommand ChangeCategoryToBootsCommand { get; set; }
        public ICommand ChangeCategoryToChestCommand { get; set; }
        public ICommand ChangeCategoryToLegsCommand { get; set; }
        public ICommand ChangeCategoryToShoulderCommand { get; set; }
        public ICommand BuyCommand { get; set; }


        public ShopViewModel(ArmourListViewModel armourListViewModel)
        {
            this.ArmourListViewModel = armourListViewModel;

            ChangeCategoryToHeadCommand = new RelayCommand(ChangeCategoryToHead);
            ChangeCategoryToBeltCommand = new RelayCommand(ChangeCategoryToBelt);
            ChangeCategoryToBootsCommand = new RelayCommand(ChangeCategoryToBoots);
            ChangeCategoryToChestCommand = new RelayCommand(ChangeCategoryToChest);
            ChangeCategoryToLegsCommand = new RelayCommand(ChangeCategoryToLegs);
            ChangeCategoryToShoulderCommand = new RelayCommand(ChangeCategoryToShoulder);
            BuyCommand = new RelayCommand(Buy);
        }

        private void ChangeCategory(Enum.Category.ECategory category)
        {
            Console.WriteLine("Changed category to: " + category.ToString());
            List<Domain.Armour> armours = ArmourRepository.GetArmourByCategory(category);
            ArmourListViewModel.ArmourList.Clear();
            foreach (Domain.Armour armour in armours)
                ArmourListViewModel.ArmourList.Add(new ArmourViewModel(armour));
            RaisePropertyChanged();
        }

        private void ChangeCategoryToHead()
        {
            ChangeCategory(Enum.Category.ECategory.Head);
        }

        private void ChangeCategoryToBelt()
        {
            ChangeCategory(Enum.Category.ECategory.Belt);
        }

        private void ChangeCategoryToBoots()
        {
            ChangeCategory(Enum.Category.ECategory.Boots);
        }

        private void ChangeCategoryToChest()
        {
            ChangeCategory(Enum.Category.ECategory.Chest);
        }

        private void ChangeCategoryToLegs()
        {
            ChangeCategory(Enum.Category.ECategory.Legs);
        }

        private void ChangeCategoryToShoulder()
        {
            ChangeCategory(Enum.Category.ECategory.Shoulder);
        }

        private void Buy()
        {
            if (ArmourListViewModel.SelectedArmour == null)
                return;


        }



    }
}
