using System;
using System.Globalization;
using System.Windows.Data;

namespace SignalStudio.Core.Utils.Converters {
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
}
