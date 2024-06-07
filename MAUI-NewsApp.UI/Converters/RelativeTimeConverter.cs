using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.UI.Converters
{
    internal class RelativeTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DateTime date)
            {
                TimeSpan difference = DateTime.Now - date;
                if(difference.TotalMinutes < 1)
                {
                    return "just now";
                }
                else if(difference.TotalMinutes < 60)
                {
                    return $"{difference.Minutes}m ago";
                }
                else if(difference.TotalHours < 24)
                {
                    return $"{difference.Hours}h ago";
                }
                else if(difference.TotalDays < 7)
                {
                    return $"{difference.Days}d ago";
                }
                else if(difference.TotalDays < 30)
                {
                    return $"{difference.Days / 7}w ago";
                }
                else if(difference.TotalDays < 365)
                {
                    return $"{difference.Days / 30}mo ago";
                }
                else
                {
                    return $"{difference.Days / 365}y ago";
                }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
