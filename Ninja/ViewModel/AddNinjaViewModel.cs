using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Domain;
using GalaSoft.MvvmLight.CommandWpf;

namespace Ninja.ViewModel
{
    public class AddNinjaViewModel
    {
        private NinjaListViewModel _ninjaListViewModel;

        public NinjaViewModel Ninja { get; set; }

        public ICommand AddNinjaCommand { get; set; }

        public AddNinjaViewModel(NinjaListViewModel nlvm)
        {
            _ninjaListViewModel = nlvm;
            Ninja = new NinjaViewModel();
            AddNinjaCommand = new RelayCommand(AddNinja, CanAddNinja);
        }

        private void AddNinja()
        {
            _ninjaListViewModel.NinjaList.Add(Ninja);
            using (var context = new NinjaEntities())
            {
                context.Ninjas.Add(Ninja.ToModel());
                context.SaveChanges();
            }
        }

        private bool CanAddNinja()
        {
            return true;
        }
    }
}
