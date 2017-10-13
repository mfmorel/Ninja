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
using Ninja.Model;
using Ninja.View;

namespace Ninja.ViewModel
{
    public class EditNinjaViewModel : ViewModelBase
    {
        public ICommand SaveNinjaCommand { get; set; }
        public NinjaViewModel Ninja { get; set; }
        private INinja ninja;

        public EditNinjaViewModel(NinjaViewModel selectedNinja)
        {
            this.Ninja = selectedNinja;
            ninja = new NinjaRepository();
            SaveNinjaCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            ninja.UpdateNinja(Ninja.ToModel());

            Router.HideEditNinjaView();
        }
    }
}
