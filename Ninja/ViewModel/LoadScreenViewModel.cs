using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Threading;
using GalaSoft.MvvmLight;
using Timer = System.Timers.Timer;
using System.Media;

namespace Ninja.ViewModel
{
    public class LoadScreenViewModel : ViewModelBase
    {
        private SoundPlayer _player;
        private int _progress;
        public int Progress
        {
            get { return _progress; }
            private set {
                _progress = value;
                base.RaisePropertyChanged();
            }
        }

        private string _loadBarText;
        public string LoadBarText
        {
            get { return _loadBarText; }
            set
            {
                _loadBarText = value;
                base.RaisePropertyChanged();
            }
        }

        private Timer timer;

        public LoadScreenViewModel()
        {
            _player = new SoundPlayer();
            _player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\theme_song.wav";
            _player.Play();

            Progress = 0;
            
            timer = new System.Timers.Timer();
            timer.Interval = 100;

            timer.Elapsed += OnTimedEvent;

            timer.Start();

        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (Progress < 100)
            {
                Progress += 2;
                LoadBarText = RandomLoadText();
            }
            else
            {
                _player.Stop();
                _player.Dispose();
                timer.Stop();
            }
        }

        private string RandomLoadText()
        {
            string txt = "";

            if (Progress < 10)
                txt = "Loading textures...";
            else if (Progress > 10 && Progress <= 20)
            {
                txt = "Loading chestplates...";
            }
            else if (Progress > 20 && Progress <= 30)
            {
                txt = "Loading helmets...";
            }
            else if (Progress > 30 && Progress <= 40)
            {
                txt = "Loading shoulder armour...";
            }
            else if (Progress > 40 && Progress <= 50)
            {
                txt = "Loading boots...";
            }
            else if (Progress > 50 && Progress <= 60)
            {
                txt = "Loading pants...";
            }
            else if (Progress > 60 && Progress <= 70)
            {
                txt = "Loading belts...";
            }
            else if (Progress > 70 && Progress <= 80)
            {
                txt = "Loading shop...";
            }
            else if (Progress > 80 && Progress <= 90)
            {
                txt = "Loading ninjas...";
            }
            else if (Progress > 90 && Progress < 100)
            {
                txt = "Loading inventories...";
            }
            else
            {
                txt = "Loading textures...";
            }

            return txt;
        }

    }
}
