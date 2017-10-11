using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Ninja.View;
using Ninja.View.UserControl;

namespace Ninja.ViewModel
{
    public class NinjaListViewModel : Router
    {
        public ObservableCollection<NinjaViewModel> Ninjas { get; set; }

        public ICommand ShowAddNinjaCommand { get; set; }

        private List<NinjaGrid> _ninjaGrids;

        public List<NinjaGrid> NinjaGrids
        {
            get { return _ninjaGrids; }
            set
            {
                _ninjaGrids = value;
                base.RaisePropertyChanged();
            }
        }

        public NinjaListViewModel()
        {
            NinjaGrids = new List<NinjaGrid>();
            ShowAddNinjaCommand = new RelayCommand(ShowAddNinja);
        }

        public void ShowAddNinja()
        {
            GetAddNinjaView.Show();
        }
    }
}