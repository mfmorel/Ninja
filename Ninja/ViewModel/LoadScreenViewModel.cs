using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Threading;
using GalaSoft.MvvmLight;
using Timer = System.Timers.Timer;

namespace Ninja.ViewModel
{
    public class LoadScreenViewModel : ViewModelBase
    {
        private int _progress;
        public int Progress
        {
            get { return _progress; }
            private set {
                _progress = value;
                base.RaisePropertyChanged();
            }
        }

        private Timer timer;

        public LoadScreenViewModel()
        {
            Progress = 0;
            
            timer = new System.Timers.Timer();
            timer.Interval = 100;

            timer.Elapsed += OnTimedEvent;

            timer.Enabled = true;

        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (Progress < 100)
                Progress += 2;
            else
                timer.Enabled = false;
        }

    }
}
