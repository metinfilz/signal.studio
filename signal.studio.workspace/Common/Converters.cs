using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Signal.Studio.Workspace.Common {
    public class MultiValueAndConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            var status = true;
            for (int i = 0; i < values.Length; i++) {
                if (values[i] is bool boolean) {
                    status &= boolean;
                }
            }
            return status;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }




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
