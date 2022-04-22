using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.Model
{
    public class MyStopwatchModel
    {
        public bool Running { get; set; }
        public DateTime? StartTime { get; private set; }
        public TimeSpan? LocalElapsedTime { get; private set; }
        public TimeSpan? TotalElapsedTime { get; set; }
        public TimeSpan? LapTime { get; private set; }
        public List<TimeSpan> LapTimes { get; private set; }

        public MyStopwatchModel()
        {
            LapTimes = new List<TimeSpan>();
        }

        public void Start()
        {
            Running = true;
            StartTime = DateTime.Now;
        }

        public void Stop()
        {
            Running = false;
        }

        public void Reset()
        {
            if(!Running)
            {
                StartTime = null;
                LocalElapsedTime = null;
                TotalElapsedTime = null;
                LapTime = null;
                LapTimes.Clear();
            }
        }

        public void SetLapTime()
        {
            if(Running)
            {
                if(LapTime==null)
                {
                    LapTime = TotalElapsedTime.Value;
                    LapTimes.Add(LapTime.Value);
                }
                else
                {
                    TimeSpan completedLapTimes;
                    foreach (var item in LapTimes)
                    {
                        completedLapTimes += item;
                    }
                    TimeSpan newLapTime = TotalElapsedTime.Value - completedLapTimes;
                    LapTime = newLapTime;
                    LapTimes.Add(LapTime.Value);
                }
            }
        }

        public TimeSpan CurrentStopwatchTime()
        {

            if(!LocalElapsedTime.HasValue) LocalElapsedTime = TimeSpan.Zero;
            if(!TotalElapsedTime.HasValue) TotalElapsedTime = TimeSpan.Zero;

            if(!Running)
            {
                LocalElapsedTime = TotalElapsedTime;
                return TotalElapsedTime.Value;
            }
            else
            {
                TotalElapsedTime = LocalElapsedTime + (DateTime.Now - StartTime);
                return TotalElapsedTime.Value;
            }
        }
    }
}
