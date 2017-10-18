using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private IEquipment _equpment;
        public ICommand SellSelectedArmourCommand { get; set; }
        public ICommand UseSelectedArmourCommand { get; set; }
        private INinja _ninja;

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
            _ninja = new NinjaRepository();

            _equpment = new EquipmentRepository();
            var equipments = _equpment.GetEquipment(SelectedNinja.SelectedNinja.Id).Select(s => new NinjaEquipmentViewModel(s));
            EqupmentList = new ObservableCollection<NinjaEquipmentViewModel>(equipments);

            SellSelectedArmourCommand = new RelayCommand(SellSelectedArmour);
            UseSelectedArmourCommand = new RelayCommand(UseSelectedArmour, CanUse);
        }

        private void SellSelectedArmour()
        {
            SelectedNinja.SelectedNinja.Gold += SelectedArmour.Price;
            _equpment.DeleteEquipment(SelectedArmour.ToModel().NinjaId, SelectedArmour.ToModel().ArmourId);
            EqupmentList.Remove(SelectedArmour);
            _ninja.UpdateNinja(SelectedNinja.SelectedNinja.ToModel());
        }

        private void UseSelectedArmour()
        {
            if(SelectedArmour.Category.Equals(Category.ECategory.Chest.ToString()))
                UpdateChest();
            else if (SelectedArmour.Category.Equals(Category.ECategory.Head.ToString()))
                UpdateHead();
            else if (SelectedArmour.Category.Equals(Category.ECategory.Shoulder.ToString()))
                UpdateShoulder();
            else if (SelectedArmour.Category.Equals(Category.ECategory.Legs.ToString()))
                UpdateLegs();
            else if (SelectedArmour.Category.Equals(Category.ECategory.Boots.ToString()))
                UpdateBoots();
            else if (SelectedArmour.Category.Equals(Category.ECategory.Belt.ToString()))
                UpdateBelt();
        }

        private void UpdateChest()
        {
            if (SelectedNinja.SelectedNinja.Head == null)
            {
                SelectedNinja.ChestImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
                SelectedNinja.SelectedNinja.Chest = SelectedArmour.ArmourId;
                UpdateNinja();
                AddToEquipedList();
            }
        }

        private void UpdateHead()
        {
            SelectedNinja.HeadImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            SelectedNinja.SelectedNinja.Head = SelectedArmour.ArmourId;
            UpdateNinja();
            AddToEquipedList();
        }

        private void UpdateShoulder()
        {
            SelectedNinja.ShoulderImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            SelectedNinja.SelectedNinja.Shoulder = SelectedArmour.ArmourId;
            UpdateNinja();
            AddToEquipedList();
        }

        private void UpdateLegs()
        {
            SelectedNinja.LegsImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            SelectedNinja.SelectedNinja.Legs = SelectedArmour.ArmourId;
            UpdateNinja();
            AddToEquipedList();
        }

        private void UpdateBoots()
        {
            SelectedNinja.BootsImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            SelectedNinja.SelectedNinja.Boots = SelectedArmour.ArmourId;
            UpdateNinja();
            AddToEquipedList();
        }

        private void UpdateBelt()
        {
            SelectedNinja.BeltImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            SelectedNinja.SelectedNinja.Belt = SelectedArmour.ArmourId;
            UpdateNinja();
            AddToEquipedList();
        }

        private void AddToEquipedList()
        {
            SelectedNinja.EquipedArmourList.Add(SelectedArmour);
            SelectedNinja.TotalStrength += SelectedArmour.Strength;
            SelectedNinja.TotalIntelligence += SelectedArmour.Intelligence;
            SelectedNinja.TotalAgility += SelectedArmour.Agility;
        }

        private void UpdateNinja()
        {
            _ninja.UpdateNinja(SelectedNinja.SelectedNinja.ToModel());
        }

        private bool CanUse()
        {
            return true;
        }
    }
}