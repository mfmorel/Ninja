using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using Ninja.Enum;
using Ninja.View;

namespace Ninja.ViewModel
{
    public class AddArmourViewModel : ViewModelBase
    {
        private ArmourListViewModel _armours;
        public ArmourViewModel Armour { get; set; }
        private ImageSource _imageSource;

        public ImageSource ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; RaisePropertyChanged(); }
        }

        private string _imgloc;
        public ICommand AddArmourCommand { get; set; }
        public ICommand AddImageCommand { get; set; }
        public ObservableCollection<string> Categories { get; set; }

        public AddArmourViewModel(ArmourListViewModel armours)
        {
            _armours = armours;
            Armour = new ArmourViewModel();
            Categories = new ObservableCollection<string>(Category.GetCategories());

            //commands
            AddImageCommand = new RelayCommand(AddImage);
            AddArmourCommand = new RelayCommand(AddArmour, CanAddArmour);
        }

        private void AddImage()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Selecteer een afbeelding.";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ImageSource = new BitmapImage(new Uri(op.FileName));
                _imgloc = op.FileName;
            }
        }

        private void SaveImage(string image, string name)
        {
            var bitmap = Bitmap.FromFile(image);
            var imgloc = Directory.GetCurrentDirectory() + "\\Resources\\Images\\" + name + ".png";
            bitmap.Save(imgloc, ImageFormat.Png);

            Armour.Picture_location = imgloc;
        }

        private void AddArmour()
        {
            SaveImage(_imgloc, Armour.Name);

            using (var context = new NinjaEntities())
            {
                context.Armours.Add(Armour.ToModel());
                context.SaveChanges();
            }

            _armours.ArmourList.Add(Armour);

            Router.HideArmourView();
        }

        private bool CanAddArmour()
        {
            return true;
        }
    }
}