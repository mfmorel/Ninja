/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Ninja"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Ninja.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoadScreenViewModel>();
            SimpleIoc.Default.Register<NinjaListViewModel>();
            SimpleIoc.Default.Register<ArmourListViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public LoadScreenViewModel LoadScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoadScreenViewModel>();
            }
        }

        public NinjaListViewModel Ninjas
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NinjaListViewModel>();
            }
        }

        public AddNinjaViewModel AddNinja
        {
            get
            {
                return new AddNinjaViewModel(Ninjas);
            }
        }

        public EditNinjaViewModel EditNinja
        {
            get
            {
                return new EditNinjaViewModel(Ninjas.SelectedNinja);
            }
        }

        public ViewNinjaViewModel ViewNinja
        {
            get
            {
                return new ViewNinjaViewModel(Ninjas.SelectedNinja);
            }
        }

        public ArmourListViewModel Armours
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ArmourListViewModel>();
            }
        }

        public AddArmourViewModel AddArmour
        {
            get
            {
                return new AddArmourViewModel(Armours);
            }
        }

        public EditArmourViewModel EditArmour
        {
            get
            {
                return new EditArmourViewModel(Armours.SelectedArmour);
            }
        }

        public ShopViewModel Shop
        {
            get
            {
                return new ShopViewModel(Armours);
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}