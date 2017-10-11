using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja.View
{
    public class Router : ViewModelBase
    {
        public Router()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        }

        public InventoryView GetInventoryView
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<InventoryView>())
                    SimpleIoc.Default.Register<InventoryView>();

                return ServiceLocator.Current.GetInstance<InventoryView>();
            }
        }

        public ShopView GetShopView
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<ShopView>())
                    SimpleIoc.Default.Register<ShopView>();

                return ServiceLocator.Current.GetInstance<ShopView>();
            }
        }

        public NinjasListView GetNinjasListView
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<NinjasListView>())
                    SimpleIoc.Default.Register<NinjasListView>();

                return ServiceLocator.Current.GetInstance<NinjasListView>();
            }
        }

        public AddNinjaView GetAddNinjaView
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<AddNinjaView>())
                    SimpleIoc.Default.Register<AddNinjaView>();

                return ServiceLocator.Current.GetInstance<AddNinjaView>();
            }
        }
    }
}
