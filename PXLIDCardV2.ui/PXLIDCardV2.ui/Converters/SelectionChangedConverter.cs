using PXLIDCardV2.ui.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PXLIDCardV2.ui.Converters
{
    public class SelectionChangedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is SelectionChangedEventArgs eventArgs)
            {
                Option option = (Option)eventArgs.CurrentSelection.FirstOrDefault();
                return option;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
