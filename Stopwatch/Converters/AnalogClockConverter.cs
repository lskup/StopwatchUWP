using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Stopwatch.Converters
{
    public class AnalogClockConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            TimeSpan time;
            if(value is TimeSpan)
            {
                time = (TimeSpan)value;
            }
            if ((string)parameter == "seconds")
                return time.TotalSeconds * 6;
            else if ((string)parameter == "miliseconds")
                return time.TotalMilliseconds * 36.0 / 100.0;
            else
                return time.TotalSeconds / 60;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
