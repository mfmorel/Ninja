using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Ninja.View;

namespace Ninja.Helper
{
    public static class Commands
    {
        public static readonly ICommand ExitCommand = new RelayCommand(() => System.Windows.Application.Current.Shutdown());

        public static readonly ICommand ManageArmourCommand = new RelayCommand(() => Router.ArmourListView.Show());

    }
}
