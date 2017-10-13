using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using GalaSoft.MvvmLight;
namespace Ninja.ViewModel
{
    public class ArmourViewModel : ViewModelBase
    {
        private Armour _armour;

        public string Name
        {
            get { return _armour.Name; }
            set { _armour.Name = value; RaisePropertyChanged("Name"); }
        }

        public string Category
        {
            get { return _armour.Category; }
            set { _armour.Category = value; RaisePropertyChanged("Category"); }
        }

        public string Picture_location
        {
            get { return _armour.Picture_location; }
            set { _armour.Picture_location = value; RaisePropertyChanged("Picture_location"); }
        }

        public int Strength
        {
            get { return _armour.Strength; }
            set { _armour.Strength = value; RaisePropertyChanged("Strength"); }
        }

        public int Intelligence
        {
            get { return _armour.Intelligence; }
            set { _armour.Intelligence = value; RaisePropertyChanged("Intelligence"); }
        }

        public int Agility
        {
            get { return _armour.Agility; }
            set { _armour.Agility = value; RaisePropertyChanged("Agility"); }
        }

        public int Price
        {
            get { return _armour.Price; }
            set { _armour.Price = value; RaisePropertyChanged("Price"); }
        }

        public ArmourViewModel()
        {
            _armour = new Armour();
        }

        public ArmourViewModel(Armour armour)
        {
            _armour = armour;
        }

        internal Armour ToModel()
        {
            GenerateRandomProperties();
            Picture_location = "";
            return _armour;
        }

        private void GenerateRandomProperties()
        {
            Random rnd = new Random();
            int roll = 100;
            Agility = rnd.Next(roll);
            Intelligence = rnd.Next(roll);
            Strength = rnd.Next(roll);
        }
    }
}
