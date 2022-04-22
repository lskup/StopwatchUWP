using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Stopwatch.Converters
{
    public class DisplayDigitalClock:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            TimeSpan time;
            if(value is TimeSpan)
            {
                time = (TimeSpan)value;
            }

            double totalTime = time.TotalSeconds;
            int hours = (int)totalTime / 3600;
            int minutes = (int)totalTime / 60;
            double seconds = Math.Round(totalTime % 60, 2);

            if (time.TotalSeconds < 60)
                return $"{seconds}";
            if (time.TotalSeconds >= 60 && time.TotalSeconds < 3600)
                return $"{minutes:d2}:{seconds}";
            else
                return $"{hours:d2}:{minutes:d2}:{seconds}";


        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
