using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace PL.Controls
{
    public class VisibilityIfNumericConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((int)value > 0) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return false; // not needed
        }

        #endregion
    }

    public class HideIfNumericConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((int)value > 0) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return false; // not needed
        }

        #endregion
    }


     public class BoolToIcon : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if((bool)value)
            {
                  return MaterialDesignThemes.Wpf.PackIconKind.Check;
            }
             return MaterialDesignThemes.Wpf.PackIconKind.Clear;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return false; // not needed
        }

        #endregion
    }

     public class FalseTrueColored : IValueConverter
     {
         public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             SolidColorBrush brush = new SolidColorBrush(Colors.LimeGreen);
             if ((bool)value == false)
             {
                 brush = new SolidColorBrush(Colors.Red);
             }
             return brush;
         }
         public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             return false; // not needed
         }
     }


     
}
