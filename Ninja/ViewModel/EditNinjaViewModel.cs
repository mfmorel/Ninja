using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Domain;
using GalaSoft.MvvmLight.CommandWpf;
using Ninja.View;

namespace Ninja.ViewModel
{
    public class EditNinjaViewModel : Router
    {
        public ICommand SaveNinjaCommand { get; set; }
        public NinjaViewModel Ninja { get; set; }

        public EditNinjaViewModel(NinjaViewModel selectedNinja)
        {
            this.Ninja = selectedNinja;
            SaveNinjaCommand = new RelayCommand<EditNinjaView>(Save);
        }

        private void Save(EditNinjaView window)
        {
            using (var context = new NinjaEntities())
            {
                var ninja = Ninja.ToModel();

                context.Entry(ninja).State = EntityState.Modified;
                context.SaveChanges();
            }

            window.Hide();
        }
    }
}
