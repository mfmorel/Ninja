using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ViewNinjaViewModel(NinjaViewModel selectedNinja)
        {
            SelectedNinja = selectedNinja;
        }
    }
}
