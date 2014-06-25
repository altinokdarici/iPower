using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace iPower.Phone.Converter
{
    public class TimeSpanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Nullable<TimeSpan> ts = value as Nullable<TimeSpan>;
            if (ts != null)
                return string.Format("{0:mm\\:ss}", ts);
            else
                return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string TimeSpanString = value as string;
            return TimeSpan.ParseExact(TimeSpanString, "{0:mm\\:ss}", CultureInfo.InvariantCulture);

        }
    }
}
