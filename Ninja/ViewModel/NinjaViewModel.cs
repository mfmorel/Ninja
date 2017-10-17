using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using GalaSoft.MvvmLight;

namespace Ninja.ViewModel
{
    public class NinjaViewModel : ViewModelBase
    {
        private Domain.Ninja _ninja;

        public int Id => _ninja.Id;

        public string Name
        {
            get { return _ninja.Name; }
            set { _ninja.Name = value; RaisePropertyChanged("Name"); }
        }

        public int Gold
        {
            get { return _ninja.Gold; }
            set { _ninja.Gold = value; RaisePropertyChanged("Gold"); }
        }

        public NinjaViewModel()
        {
            _ninja = new Domain.Ninja();
        }

        public NinjaViewModel(Domain.Ninja ninja)
        {
            _ninja = ninja;
        }
        internal Domain.Ninja ToModel()
        {
            return _ninja;
        }
    }
}
