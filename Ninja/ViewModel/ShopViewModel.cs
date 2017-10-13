using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

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


        public ShopViewModel(ArmourListViewModel armourListViewModel)
        {
            this.ArmourListViewModel = armourListViewModel;
        }

    }
}
