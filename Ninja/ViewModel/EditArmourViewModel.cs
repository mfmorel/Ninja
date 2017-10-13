using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Ninja.Enum;
using Ninja.Helper;
using Ninja.Model;
using Ninja.Model.Interfaces;
using Ninja.View;

namespace Ninja.ViewModel
{
    public class EditArmourViewModel : ViewModelBase
    {
        public ICommand SaveArmourCommand { get; set; }
        public ICommand AddImageCommand { get; set; }
        public ArmourViewModel Armour { get; set; }
        private IArmour _armour;
        public ObservableCollection<string> Categories { get; set; }
        private string oldName;
        public EditArmourViewModel(ArmourViewModel selectedArmour)
        {
            Armour = selectedArmour;
            oldName = Armour.Name;
            _armour = new ArmourRepository();
            Categories = new ObservableCollection<string>(Category.GetCategories());

            SaveArmourCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            RenameImage();

            _armour.UpdateArmour(Armour.ToModel());

            Router.HideEditArmourView();
        }

        private void RenameImage()
        {
            var oldImgloc = Directory.GetCurrentDirectory() + "\\Resources\\Images\\" + oldName + ".png";
            var newImgloc = Directory.GetCurrentDirectory() + "\\Resources\\Images\\" + Armour.Name + ".png";

            if (System.IO.File.Exists(oldImgloc))
                if(!System.IO.File.Exists(newImgloc))
                    System.IO.File.Copy(oldImgloc, newImgloc);

            Armour.Picture_location = newImgloc;
        }
    }
}