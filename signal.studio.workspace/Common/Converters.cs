using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Signal.Studio.Workspace.Common {
    public class AndVisibleConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            var status = true;
            values.ToList().ForEach(i => { if (i is bool boolean) status = status && boolean; });
            return status ? Visibility.Visible : (object)Visibility.Collapsed;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotSupportedException("Cannot convert back");
        }
    }
    public class OrVisibleConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            var status = false;
            values.ToList().ForEach(i => { if (i is bool boolean) status = status || boolean; });
            return status ? Visibility.Visible : (object)Visibility.Collapsed;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotSupportedException("Cannot convert back");
        }
    }


}
