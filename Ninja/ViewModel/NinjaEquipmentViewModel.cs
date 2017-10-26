using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using GalaSoft.MvvmLight;
using Ninja.Model;
using Ninja.Model.Interfaces;

namespace Ninja.ViewModel
{
    public class NinjaEquipmentViewModel : ViewModelBase
    {
        private Ninja_equipment _ninjaEquipment;

        public int NinjaId
        {
            get { return _ninjaEquipment.NinjaId; }
            set { _ninjaEquipment.NinjaId = value; RaisePropertyChanged("NinjaId"); }
        }

        public int ArmourId
        {
            get { return _ninjaEquipment.ArmourId; }
            set { _ninjaEquipment.ArmourId = value; RaisePropertyChanged("ArmourId"); }
        }

        public int Strength
        {
            get { return _ninjaEquipment.Strength; }
            set { _ninjaEquipment.Strength = value; RaisePropertyChanged("Strength"); }
        }
        
        public int Intelligence
        {
            get { return _ninjaEquipment.Intelligence; }
            set { _ninjaEquipment.Intelligence = value; RaisePropertyChanged("Intelligence"); }
        }
        
        public int Agility
        {
            get { return _ninjaEquipment.Agility; }
            set { _ninjaEquipment.Agility = value; RaisePropertyChanged("Agility"); }
        }

        public string Name { get; }

        public string Category { get; }

        public string Picture_location { get; }
        public int Price { get; }

        public NinjaEquipmentViewModel()
        {
            _ninjaEquipment = new Ninja_equipment();
            GenerateRandomProperties();
        }

        public NinjaEquipmentViewModel(Ninja_equipment ninjaEquipment)
        {
            _ninjaEquipment = ninjaEquipment;
            IArmour armour = new ArmourRepository();
            ninjaEquipment.Armour = armour.GetArmour(ninjaEquipment.ArmourId);
            Name = ninjaEquipment.Armour.Name;
            Category = ninjaEquipment.Armour.Category;
            Picture_location = Directory.GetCurrentDirectory() + ninjaEquipment.Armour.Picture_location;
            Price = ninjaEquipment.Armour.Price;
            Agility = ninjaEquipment.Agility;
            Strength = ninjaEquipment.Strength;
            Intelligence = ninjaEquipment.Intelligence;
        }

        internal Ninja_equipment ToModel()
        {
            return _ninjaEquipment;
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
