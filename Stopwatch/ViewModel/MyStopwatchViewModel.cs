using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Stopwatch.Model;
using System.ComponentModel;

namespace Stopwatch.ViewModel
{
    public class MyStopwatchViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<string> lapTimes { get; set; } = new ObservableCollection<string>();
        MyStopwatchModel myModel = new MyStopwatchModel();

        public TimeSpan time { get; set; }
        public DispatcherTimer timer { get; set; }
        public TimeSpan lapTime { get; set; }
        public bool Running { get { return myModel.Running; } }

        public string Display { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MyStopwatchViewModel()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
        }

        public void StartStop()
        {
            if(!Running)
            {
                myModel.Start();
                timer.Start();
            }
            else
            {
                myModel.Stop();
            }
        }

        private void Timer_Tick(object sender, object e)
        {
            time = myModel.CurrentStopwatchTime();
            Display = DisplayAsTime(time);
            OnPropertyChanged("time");
            OnPropertyChanged("Display");
        }

        private void GetLapTime()
        {
            myModel.SetLapTime();
            lapTimes.Add(DisplayAsTime(myModel.LapTime.Value));
        }

        public void ResetOrLapTime()
        {
            if (Running) GetLapTime();
            else
            {
                myModel.Reset();
                lapTimes.Clear();
            }
        }

        public string DisplayAsTime(TimeSpan time)
        {
            double totalTime = time.TotalSeconds;
            int hours = (int)totalTime / 3600;
            int minutes = (int)totalTime / 60;
            double seconds = Math.Round(totalTime % 60,3);

            return $"{hours:d2}:{minutes:d2}:{seconds}";
        }

    }
}
