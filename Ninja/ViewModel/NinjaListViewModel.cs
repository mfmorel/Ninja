using System.Collections.Generic;
using System.Windows.Controls;
using Ninja.View;
using Ninja.View.UserControl;

namespace Ninja.ViewModel
{
    public class NinjaListViewModel : Router
    {
        private List<NinjaGrid> _ninjaGrids;

        public List<NinjaGrid> NinjaGrids
        {
            get
            {
                return _ninjaGrids;
            }

            set
            {
                _ninjaGrids = value;
                base.RaisePropertyChanged();
            }
        }

        public NinjaListViewModel()
        {
            NinjaGrids = new List<NinjaGrid>();
        }
    }
}