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

        public int? Head
        {
            get { return _ninja.Head; }
            set { _ninja.Head = value; RaisePropertyChanged("Head"); }
        }

        public int? Shoulder
        {
            get { return _ninja.Shoulder; }
            set { _ninja.Shoulder = value; RaisePropertyChanged("Shoulder"); }
        }

        public int? Chest
        {
            get { return _ninja.Chest; }
            set { _ninja.Chest = value; RaisePropertyChanged("Chest"); }
        }

        public int? Belt
        {
            get { return _ninja.Belt; }
            set { _ninja.Belt = value; RaisePropertyChanged("Belt"); }
        }

        public int? Legs
        {
            get { return _ninja.Legs; }
            set { _ninja.Legs = value; RaisePropertyChanged("Legs"); }
        }

        public int? Boots
        {
            get { return _ninja.Boots; }
            set { _ninja.Boots = value; RaisePropertyChanged("Boots"); }
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
