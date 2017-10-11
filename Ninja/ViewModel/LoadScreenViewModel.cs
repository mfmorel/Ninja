using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Threading;
using GalaSoft.MvvmLight;
using Timer = System.Timers.Timer;
using System.Media;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Ninja.View;
using System.Windows;

namespace Ninja.ViewModel
{
    public class LoadScreenViewModel : Router
    {
        public ICommand PlayCommand { get; set; }
        private readonly SoundPlayer _player;

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

        private Visibility _butVisibility;
        public Visibility ButVisibility
        {
            get { return _butVisibility; }
            set
            {
                _butVisibility = value;
                base.RaisePropertyChanged();
            }
        }

        private Visibility _progVisibility;
        public Visibility ProgVisibility
        {
            get { return _progVisibility; }
            set
            {
                _progVisibility = value;
                base.RaisePropertyChanged();
            }
        }

        private readonly Timer _timer;

        public LoadScreenViewModel()
        {
            ProgVisibility = Visibility.Visible;
            ButVisibility = Visibility.Hidden;

            PlayCommand = new RelayCommand(this.Play);

            Progress = 0;

            _timer = new System.Timers.Timer {Interval = 100};

            _timer.Elapsed += OnTimedEvent;

            _timer.Start();

            _player = new SoundPlayer
            {
                SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\theme_song.wav"
            };
            _player.Play();
        }

        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            if (Progress < 100)
            {
                Progress += 2;
                LoadBarText = RandomLoadText();
            }
            else
                Stop();
        }

        private void Stop()
        {
            _timer.Stop();

            ProgVisibility = Visibility.Hidden;
            ButVisibility = Visibility.Visible;
        }

        private void Play()
        {
            _player.Stop();
            _player.Dispose();

            var ninjas = this.GetNinjasListView;
            ninjas.Show();

            Application.Current.MainWindow.Close();
        }

        private string RandomLoadText()
        {
            var txt = "";

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
