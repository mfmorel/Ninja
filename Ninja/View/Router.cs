using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ninja.View
{
    public static class Router
    {
        private static AddNinjaView _addNinjaView;
        private static EditNinjaView _editNinjaView;
        private static InventoryView _inventoryView;
        private static LoadScreen _loadScreen;
        private static NinjasListView _ninjasListView;
        private static ShopView _shopView;
        private static NinjaView _ninjaView;
        private static ArmourListView _armourListView;
        private static AddArmourView _addArmourView;
        private static EditArmourView _editArmourView;

        public static AddNinjaView AddNinjaView
        {
            get
            {
                _addNinjaView = new AddNinjaView();
                return _addNinjaView;
            }
        }

        public static void HideAddNinjaView()
        {
            _addNinjaView?.Close();
        }

        public static EditNinjaView EditNinjaView
        {
            get
            {
                _editNinjaView = new EditNinjaView();
                return _editNinjaView;
            }
        }

        public static void HideEditNinjaView()
        {
            _editNinjaView?.Close();
        }

        public static InventoryView InventoryView
        {
            get
            {
                _inventoryView = new InventoryView();
                return _inventoryView;
            }
        }

        public static void HideInventoryView()
        {
            _inventoryView?.Close();
        }

        public static LoadScreen LoadScreen
        {
            get
            {
                _loadScreen = new LoadScreen();
                return _loadScreen;
            }
        }

        public static void HideLoadScreen()
        {
            _loadScreen?.Close();
        }

        public static NinjasListView NinjaListView
        {
            get
            {
                _ninjasListView = new NinjasListView();
                return _ninjasListView;
            }
        }

        public static void HideNinjaListView()
        {
            _ninjasListView?.Close();
        }

        public static ShopView ShopView
        {
            get
            {
                _shopView = new ShopView();
                return _shopView;
            }
        }

        public static void HideShopView()
        {
            _shopView?.Close();
        }

        public static NinjaView NinjaView
        {
            get
            {
                _ninjaView = new NinjaView();
                return _ninjaView;
            }
        }

        public static void HideNinjaView()
        {
            _ninjaView?.Close();
        }

        public static ArmourListView ArmourListView
        {
            get
            {
                _armourListView = new ArmourListView();
                return _armourListView;
            }
        }

        public static void HideItemListView()
        {
            _armourListView?.Close();
        }

        public static AddArmourView AddArmourView
        {
            get
            {
                _addArmourView = new AddArmourView();
                return _addArmourView;
            }
        }

        public static void HideArmourView()
        {
            _addArmourView?.Close();
        }

        public static EditArmourView EditArmourView
        {
            get
            {
                _editArmourView = new EditArmourView();
                return _editArmourView;
            }
        }

        public static void HideEditArmourView()
        {
            _editArmourView?.Close();
        }
    }
}