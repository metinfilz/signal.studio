using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Signal.Studio.Workspace.Utils {
    internal class StarLengthConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value is double @double ? new GridLength(@double, GridUnitType.Star) : (object)new GridLength(0, GridUnitType.Star);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return ((GridLength)value).Value;
        }
    }
    internal class PixelLengthConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value is double @double ? new GridLength(@double, GridUnitType.Pixel) : (object)new GridLength(0, GridUnitType.Pixel);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return ((GridLength)value).Value;
        }
    }
    internal class HorizontalMarginConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            var left = (bool)values[0] || (bool)values[1];
            var right = (bool)values[2] || (bool)values[3];
            if (left && right) {
                return new Thickness(-3, 0, -3, 0);
            }
            else if (!left && right) {
                return new Thickness(0, 0, -3, 0);
            }
            else if (left && !right) {
                return new Thickness(-3, 0, 0, 0);
            }
            else {
                return new Thickness(0, 0, 0, 0);
            }

        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    internal class VerticalMarginConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            var top = (bool)values[0] || (bool)values[1];
            var bottom = (bool)values[2] || (bool)values[3];
            if (top && bottom) {
                return new Thickness(0, -3, 0, -3);
            }
            else if (!top && bottom) {
                return new Thickness(0, 0, 0, -3);
            }
            else if (top && !bottom) {
                return new Thickness(0, -3, 0, 0);
            }
            else {
                return new Thickness(0, 0, 0, 0);
            }

        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

    }
    internal class MultiOrBooleanToVisibilityConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            var status = false;
            values.ToList().ForEach(i => {
                if (i is bool) status |= (bool)i;
            });


            return status ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    internal class MultiAndBooleanToVisibilityConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            var status = true;
            values.ToList().ForEach(i => {
                if (i is bool) status &= (bool)i;
                else if (i is int) {
                    if ((int)i == 0) status &= false;
                    else status &= true;
                }

            });
            return status ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
