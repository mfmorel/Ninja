using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Ninja.Model;
using Ninja.Model.Interfaces;

namespace Ninja.ViewModel
{
    public class ViewNinjaViewModel : ViewModelBase
    {
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

        public ObservableCollection<NinjaEquipmentViewModel> EqupmentList { get; set; }
        //public ObservableCollection<NinjaEquipmentViewModel> EquipedArmourList { get; set; }
        public Dictionary<int, NinjaEquipmentViewModel> EquipedArmourList { get; set; }
        private ImageSource _chestImageSource;

        public ImageSource ChestImageSource
        {
            get { return _chestImageSource; }
            set { _chestImageSource = value; RaisePropertyChanged(); }
        }

        private ImageSource _headImageSource;

        public ImageSource HeadImageSource
        {
            get { return _headImageSource; }
            set { _headImageSource = value; RaisePropertyChanged(); }
        }

        private ImageSource _shoulderImageSource;

        public ImageSource ShoulderImageSource
        {
            get { return _shoulderImageSource; }
            set { _shoulderImageSource = value; RaisePropertyChanged(); }
        }

        private ImageSource _beltImageSource;

        public ImageSource BeltImageSource
        {
            get { return _beltImageSource; }
            set { _beltImageSource = value; RaisePropertyChanged(); }
        }

        private ImageSource _legsImageSource;

        public ImageSource LegsImageSource
        {
            get { return _legsImageSource; }
            set { _legsImageSource = value; RaisePropertyChanged(); }
        }

        private ImageSource _bootsImageSource;

        public ImageSource BootsImageSource
        {
            get { return _bootsImageSource; }
            set { _bootsImageSource = value; RaisePropertyChanged(); }
        }

        private int _totalStrength;
        private int _totalIntelligence;
        private int _totalAgility;

        public int TotalStrength
        {
            get { return _totalStrength; }
            set { _totalStrength = value; RaisePropertyChanged(); }
        }

        public int TotalIntelligence
        {
            get { return _totalIntelligence; }
            set { _totalIntelligence = value; RaisePropertyChanged(); }
        }

        public int TotalAgility
        {
            get { return _totalAgility; }
            set { _totalAgility = value; RaisePropertyChanged(); }
        }

        private IEquipment _equipment;
        private INinja _ninja;
        public ICommand UpdateHeadCommand { get; set; }
        public ICommand UpdateChestCommand { get; set; }
        public ICommand UpdateShoulderCommand { get; set; }
        public ICommand UpdateBeltCommand { get; set; }
        public ICommand UpdateLegsCommand { get; set; }
        public ICommand UpdateBootsCommand { get; set; }

        public ViewNinjaViewModel(NinjaViewModel selectedNinja)
        {
            _equipment = new EquipmentRepository();
            SelectedNinja = selectedNinja;
            EquipedArmourList = new Dictionary<int, NinjaEquipmentViewModel>();
            UpdateHeadCommand = new RelayCommand(DeleteHead);
            UpdateChestCommand = new RelayCommand(DeleteChest);
            UpdateShoulderCommand = new RelayCommand(DeleteShoulder);
            UpdateBeltCommand = new RelayCommand(DeleteBelt);
            UpdateLegsCommand = new RelayCommand(DeleteLegs);
            UpdateBootsCommand = new RelayCommand(DeleteBoots);
            _ninja = new NinjaRepository();

            NinjaEquipmentViewModel ninjaEq = null;

            if (SelectedNinja.Head != null)
            {
                ninjaEq = new NinjaEquipmentViewModel(_equipment.GetEquipment(SelectedNinja.Id, (int)SelectedNinja.Head));
                OnEquipedArmourChange(ninjaEq, false);
                HeadImageSource = ImageSource(ninjaEq.Picture_location);
            }
            if (SelectedNinja.Chest != null)
            {
                ninjaEq = new NinjaEquipmentViewModel(_equipment.GetEquipment(SelectedNinja.Id, (int) SelectedNinja.Chest));
                OnEquipedArmourChange(ninjaEq, false);
                ChestImageSource = ImageSource(ninjaEq.Picture_location);
            }
            if (SelectedNinja.Shoulder != null)
            {
                ninjaEq = new NinjaEquipmentViewModel(_equipment.GetEquipment(SelectedNinja.Id, (int)SelectedNinja.Shoulder));
                OnEquipedArmourChange(ninjaEq, false);
                ShoulderImageSource = ImageSource(ninjaEq.Picture_location);
            }
            if (SelectedNinja.Boots != null)
            {
                ninjaEq = new NinjaEquipmentViewModel(_equipment.GetEquipment(SelectedNinja.Id, (int)SelectedNinja.Boots));
                OnEquipedArmourChange(ninjaEq, false);
                BootsImageSource = ImageSource(ninjaEq.Picture_location);
            }
            if (SelectedNinja.Legs != null)
            {
                ninjaEq = new NinjaEquipmentViewModel(_equipment.GetEquipment(SelectedNinja.Id, (int)SelectedNinja.Legs));
                OnEquipedArmourChange(ninjaEq, false);
                LegsImageSource = ImageSource(ninjaEq.Picture_location);
            }
            if (SelectedNinja.Belt != null)
            {
                ninjaEq = new NinjaEquipmentViewModel(_equipment.GetEquipment(SelectedNinja.Id, (int)SelectedNinja.Belt));
                OnEquipedArmourChange(ninjaEq, false);
                BeltImageSource = ImageSource(ninjaEq.Picture_location);
            }
        }

        public void DeleteHead()
        {
            if (SelectedNinja.Head == null) return;
            var ninjaEq = new NinjaEquipmentViewModel(_equipment.GetEquipment(SelectedNinja.Id, (int)SelectedNinja.Head));
            OnEquipedArmourChange(ninjaEq, true);
            HeadImageSource = null;
            SelectedNinja.Head = null;
            UpdateNinja();
        }

        public void DeleteChest()
        {
            if (SelectedNinja.Chest == null) return;
            var ninjaEq = new NinjaEquipmentViewModel(_equipment.GetEquipment(SelectedNinja.Id, (int)SelectedNinja.Chest));
            OnEquipedArmourChange(ninjaEq, true);
            ChestImageSource = null;
            SelectedNinja.Chest = null;
            UpdateNinja();
        }

        public void DeleteShoulder()
        {
            if (SelectedNinja.Shoulder == null) return;
            var ninjaEq = new NinjaEquipmentViewModel(_equipment.GetEquipment(SelectedNinja.Id, (int)SelectedNinja.Shoulder));
            OnEquipedArmourChange(ninjaEq, true);
            ShoulderImageSource = null;
            SelectedNinja.Shoulder = null;
            UpdateNinja();
        }

        public void DeleteBelt()
        {
            if (SelectedNinja.Belt == null) return;
            var ninjaEq = new NinjaEquipmentViewModel(_equipment.GetEquipment(SelectedNinja.Id, (int)SelectedNinja.Belt));
            OnEquipedArmourChange(ninjaEq, true);
            BeltImageSource = null;
            SelectedNinja.Belt = null;
            UpdateNinja();
        }

        public void DeleteLegs()
        {
            if (SelectedNinja.Legs == null) return;
            var ninjaEq = new NinjaEquipmentViewModel(_equipment.GetEquipment(SelectedNinja.Id, (int)SelectedNinja.Legs));
            OnEquipedArmourChange(ninjaEq, true);
            LegsImageSource = null;
            SelectedNinja.Legs = null;
            UpdateNinja();
        }

        public void DeleteBoots()
        {
            if (SelectedNinja.Boots == null) return;
            var ninjaEq = new NinjaEquipmentViewModel(_equipment.GetEquipment(SelectedNinja.Id, (int)SelectedNinja.Boots));
            OnEquipedArmourChange(ninjaEq, true);
            BootsImageSource = null;
            SelectedNinja.Boots = null;
            UpdateNinja();
        }

        private void UpdateNinja()
        {
            _ninja.UpdateNinja(SelectedNinja.ToModel());
        }

        private BitmapImage ImageSource(string str)
        {
            return new BitmapImage(new Uri(str));
        }

        public void OnEquipedArmourChange(NinjaEquipmentViewModel eq, bool delete)
        {
            if (!delete)
            {
                EquipedArmourList.Add(eq.ArmourId, eq);

                TotalStrength += eq.Strength;
                TotalIntelligence += eq.Intelligence;
                TotalAgility += eq.Agility;
            }
            else
            {
                EquipedArmourList.Remove(eq.ArmourId);

                TotalStrength -= eq.Strength;
                TotalIntelligence -= eq.Intelligence;
                TotalAgility -= eq.Agility;
            }
        }
    }
}
