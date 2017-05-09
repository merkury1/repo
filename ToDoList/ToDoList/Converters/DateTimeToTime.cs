using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ToDoList.Converters
{
    class DateTimeToTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime DateNotConverted = new DateTime();
            DateTime.TryParse(value.ToString(), out DateNotConverted);
            string Time = DateNotConverted.ToString("HH:mm");
            return Time;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime MyDateTime= new DateTime();
            DateTime.TryParse((string)value, out MyDateTime);
            return MyDateTime;
        }
    }
}
