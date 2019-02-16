using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MailSender.UtilityClasses
{
    public class MultiConverter : IMultiValueConverter
    {
        public object Convert( object[] values, Type targetType, object parameter, CultureInfo culture )
        {
            var buf = values[ 0 ];
            values[ 1 ] = buf;
            return values[ 1 ];
        }
        public object[] ConvertBack( object value, Type[] targetTypes, object parameter, CultureInfo culture ) { throw new NotImplementedException(); }
    }
}
