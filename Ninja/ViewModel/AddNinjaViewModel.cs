using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Ninja.View;

namespace Ninja.ViewModel
{
    public class AddNinjaViewModel : ViewModelBase
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
            using (var context = new NinjaEntities())
            {
                context.Ninjas.Add(Ninja.ToModel());
                context.SaveChanges();
            }

            _ninjaListViewModel.NinjaList.Add(Ninja);

            Router.HideAddNinjaView();
        }

        private bool CanAddNinja()
        {
            if (string.IsNullOrEmpty(Ninja.Name) || Ninja.Gold <= 0)
                return false;

            return true;
        }
    }
}
