using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Ninja.Domain.Model;

namespace Ninja.ViewModel
{
    public class NinjaViewModel : ViewModelBase
    {
        public int ID
        {
            get { return _ninja.ID; }
            set { _ninja.ID = value; RaisePropertyChanged("ID"); }
        }

        public string Name
        {
            get { return _ninja.Name; }
            set { _ninja.Name = value; RaisePropertyChanged("Name"); }
        }

        internal Domain.Ninja ToModel()
        {
            return _ninja;
        }

        private Domain.Ninja _ninja;
        public NinjaViewModel()
        {
            _ninja = new Domain.Ninja();
        }

        public NinjaViewModel(Domain.Ninja ninja)
        {
            _ninja = ninja;
        }
    }
}
