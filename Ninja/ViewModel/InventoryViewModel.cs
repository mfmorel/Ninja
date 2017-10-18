using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Ninja.Enum;
using Ninja.Model;
using Ninja.Model.Interfaces;

namespace Ninja.ViewModel
{
    public class InventoryViewModel : ViewModelBase
    {
        private ViewNinjaViewModel _selectedNinja;
        private IEquipment _equipment;
        public ICommand SellSelectedArmourCommand { get; set; }
        public ICommand UseSelectedArmourCommand { get; set; }
        public ICommand SellInventoryCommand { get; set; }

        public ViewNinjaViewModel SelectedNinja
        {
            get { return _selectedNinja; }
            set
            {
                _selectedNinja = value;
                RaisePropertyChanged();
            }
        }

        private NinjaEquipmentViewModel _selectedArmour;

        public NinjaEquipmentViewModel SelectedArmour
        {
            get { return _selectedArmour; }
            set
            {
                _selectedArmour = value;
                base.RaisePropertyChanged();
            }
        }

        public ObservableCollection<NinjaEquipmentViewModel> EqupmentList { get; set; }

        public InventoryViewModel(ViewNinjaViewModel selectedNinja)
        {
            SelectedNinja = selectedNinja;

            _equipment = new EquipmentRepository();
            var equipments = _equipment.GetEquipment(SelectedNinja.SelectedNinja.Id).Select(s => new NinjaEquipmentViewModel(s));
            EqupmentList = new ObservableCollection<NinjaEquipmentViewModel>(equipments);

            SellSelectedArmourCommand = new RelayCommand(SellSelectedArmour);
            UseSelectedArmourCommand = new RelayCommand(UseSelectedArmour, CanUse);
            SellInventoryCommand = new RelayCommand(SellInventory);
        }

        private void SellSelectedArmour()
        {
            SelectedNinja.SelectedNinja.Gold += SelectedArmour.Price;

            _equipment.DeleteEquipment(SelectedArmour.ToModel().NinjaId, SelectedArmour.ToModel().ArmourId);
            EqupmentList.Remove(SelectedArmour);
        }

        private void SellArmour(int ninjaId, NinjaEquipmentViewModel equipment)
        {
            SelectedNinja.SelectedNinja.Gold += equipment.Price;
            _equipment.DeleteEquipment(ninjaId, equipment.ArmourId);
            EqupmentList.Remove(equipment);
        }

        private void UseSelectedArmour()
        {
            if(SelectedArmour.Category.Equals(Category.ECategory.Chest.ToString()))
                SelectedNinja.ChestImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            else if (SelectedArmour.Category.Equals(Category.ECategory.Head.ToString()))
                SelectedNinja.HeadImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            else if (SelectedArmour.Category.Equals(Category.ECategory.Shoulder.ToString()))
                SelectedNinja.ShoulderImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            else if (SelectedArmour.Category.Equals(Category.ECategory.Legs.ToString()))
                SelectedNinja.LegsImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            else if (SelectedArmour.Category.Equals(Category.ECategory.Boots.ToString()))
                SelectedNinja.BootsImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            else if (SelectedArmour.Category.Equals(Category.ECategory.Belt.ToString()))
                SelectedNinja.BeltImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
        }

        private void SellInventory()
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(
                "Weet je zeker dat je, je inventory wilt verkopen?", "Inventory verkopen", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                EqupmentList.ToList().ForEach(k => SellArmour(_selectedNinja.SelectedNinja.Id, k));
            }

        }

        private bool CanUse()
        {
            return true;
        }
    }
}