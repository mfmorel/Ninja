using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Ninja.Domain;
using Ninja.View;

namespace Ninja.ViewModel
{
    public class AddNinjaViewModel : Router
    {
        private NinjaListViewModel _ninjaList;
        public NinjaViewModel Ninja { get; set; }
        public ICommand AddNinjaCommand { get; set; }
        public AddNinjaViewModel(NinjaListViewModel ninjaList)
        {
            this._ninjaList = ninjaList;
            this.Ninja = new NinjaViewModel();
            AddNinjaCommand = new RelayCommand(AddNinja);
        }

        private void AddNinja()
        {
            _ninjaList.Ninjas.Add(Ninja);
            using (var context = new NinjaEntities())
            {
                context.Ninjas.Add(Ninja.ToModel());
                context.SaveChanges();
            }
            GetAddNinjaView.Close();
        }
    }
}