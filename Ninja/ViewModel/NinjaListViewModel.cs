using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Ninja.Model;
using Ninja.View;
using Ninja.View.UserControl;

namespace Ninja.ViewModel
{
    public class NinjaListViewModel : Router
    {
        private AddNinjaView _addNinjaView;
        private EditNinjaView _editNinjaView;
        public ObservableCollection<NinjaViewModel> NinjaList { get; set; }
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

        private readonly INinja ninja;

        public ICommand ShowAddNinjaCommand { get; set; }
        public ICommand DeleteSelectedNinjaCommand { get; set; }
        public ICommand EditSelectedNinjaCommand { get; set; }

        public NinjaListViewModel()
        {
            ninja = new NinjaRepository();
            var ninjas = ninja.GetNinjas().Select(s => new NinjaViewModel(s));
            NinjaList = new ObservableCollection<NinjaViewModel>(ninjas);

            // Commands
            ShowAddNinjaCommand = new RelayCommand(ShowAddNinja);
            DeleteSelectedNinjaCommand = new RelayCommand(DeleteSelectedNinja);
            EditSelectedNinjaCommand = new RelayCommand(EditSelectedNinja);
        }

        public void ShowAddNinja()
        {
            _addNinjaView = new AddNinjaView();
            _addNinjaView.Show();
        }

        public void HideAddNinja()
        {
            _addNinjaView.Close();
        }

        private void DeleteSelectedNinja()
        {
            ninja.DeleteNinja(SelectedNinja.Name);
            NinjaList.Remove(SelectedNinja);
        }

        private void EditSelectedNinja()
        {
            _editNinjaView = new EditNinjaView();
            _editNinjaView.Show();
        }
    }
}