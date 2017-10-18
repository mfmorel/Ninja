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
using static Ninja.Enum.Category;

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

        private Domain.Ninja _Ninja;

        public InventoryViewModel(ViewNinjaViewModel selectedNinja)
        {
            SelectedNinja = selectedNinja;
            _ninja = new NinjaRepository();

            _Ninja = _ninja.GetNinja(selectedNinja.SelectedNinja.Id);

            _equpment = new EquipmentRepository();
            var equipments = _equpment.GetEquipment(SelectedNinja.SelectedNinja.Id).Select(s => new NinjaEquipmentViewModel(s));
            EqupmentList = new ObservableCollection<NinjaEquipmentViewModel>(equipments);

            SellSelectedArmourCommand = new RelayCommand(SellSelectedArmour);
            UseSelectedArmourCommand = new RelayCommand(UseSelectedArmour, CanUse);
        }

        private void SellSelectedArmour()
        {
            SelectedNinja.SelectedNinja.Gold += SelectedArmour.Price;
            if (SelectedNinja.EquipedArmourList.ContainsKey(SelectedArmour.ArmourId))
            {
                if (SelectedArmour.Category.Equals(ECategory.Head.ToString()))
                    SelectedNinja.DeleteHead();
                else if (SelectedArmour.Category.Equals(ECategory.Chest.ToString()))
                    SelectedNinja.DeleteChest();
                else if (SelectedArmour.Category.Equals(ECategory.Shoulder.ToString()))
                    SelectedNinja.DeleteShoulder();
                else if (SelectedArmour.Category.Equals(ECategory.Belt.ToString()))
                    SelectedNinja.DeleteBelt();
                else if (SelectedArmour.Category.Equals(ECategory.Legs.ToString()))
                    SelectedNinja.DeleteLegs();
                else if (SelectedArmour.Category.Equals(ECategory.Boots.ToString()))
                    SelectedNinja.DeleteBoots();
            }
            _equpment.DeleteEquipment(SelectedArmour.ToModel().NinjaId, SelectedArmour.ToModel().ArmourId);
            EqupmentList.Remove(SelectedArmour);
            _ninja.UpdateNinja(SelectedNinja.SelectedNinja.ToModel());
        }

        private void UseSelectedArmour()
        {
            if(SelectedArmour.Category.Equals(ECategory.Chest.ToString()))
                UpdateChest();
            else if (SelectedArmour.Category.Equals(ECategory.Head.ToString()))
                UpdateHead();
            else if (SelectedArmour.Category.Equals(ECategory.Shoulder.ToString()))
                UpdateShoulder();
            else if (SelectedArmour.Category.Equals(ECategory.Legs.ToString()))
                UpdateLegs();
            else if (SelectedArmour.Category.Equals(ECategory.Boots.ToString()))
                UpdateBoots();
            else if (SelectedArmour.Category.Equals(ECategory.Belt.ToString()))
                UpdateBelt();
        }

        private void UpdateChest()
        {
            if (SelectedNinja.SelectedNinja.Chest != null) return;
            SelectedNinja.ChestImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            SelectedNinja.SelectedNinja.Chest = SelectedArmour.ArmourId;
            UpdateNinja();
            OnEquipedArmourChange(false);
        }

        private void UpdateHead()
        {
            if (SelectedNinja.SelectedNinja.Head != null) return;
            SelectedNinja.HeadImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            SelectedNinja.SelectedNinja.Head = SelectedArmour.ArmourId;
            UpdateNinja();
            OnEquipedArmourChange(false);
        }

        private void UpdateShoulder()
        {
            if (SelectedNinja.SelectedNinja.Shoulder != null) return;
            SelectedNinja.ShoulderImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            SelectedNinja.SelectedNinja.Shoulder = SelectedArmour.ArmourId;
            UpdateNinja();
            OnEquipedArmourChange(false);
        }

        private void UpdateLegs()
        {
            if (SelectedNinja.SelectedNinja.Legs != null) return;
            SelectedNinja.LegsImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            SelectedNinja.SelectedNinja.Legs = SelectedArmour.ArmourId;
            UpdateNinja();
            OnEquipedArmourChange(false);
        }

        private void UpdateBoots()
        {
            if (SelectedNinja.SelectedNinja.Boots != null) return;
            SelectedNinja.BootsImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            SelectedNinja.SelectedNinja.Boots = SelectedArmour.ArmourId;
            UpdateNinja();
            OnEquipedArmourChange(false);
        }

        private void UpdateBelt()
        {
            if (SelectedNinja.SelectedNinja.Belt != null) return;
            SelectedNinja.BeltImageSource = new BitmapImage(new Uri(SelectedArmour.Picture_location));
            SelectedNinja.SelectedNinja.Belt = SelectedArmour.ArmourId;
            UpdateNinja();
            OnEquipedArmourChange(false);
        }

        private void OnEquipedArmourChange(bool delete)
        {
            SelectedNinja.OnEquipedArmourChange(SelectedArmour, delete);
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