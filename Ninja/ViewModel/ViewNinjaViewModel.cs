using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaSoft.MvvmLight;

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
        public ObservableCollection<NinjaEquipmentViewModel> EquipedArmourList { get; set; }

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

        public ViewNinjaViewModel(NinjaViewModel selectedNinja)
        {
            SelectedNinja = selectedNinja;
            EquipedArmourList = new ObservableCollection<NinjaEquipmentViewModel>();
        }
    }
}
