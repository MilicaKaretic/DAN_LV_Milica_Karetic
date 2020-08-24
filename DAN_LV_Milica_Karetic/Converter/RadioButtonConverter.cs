using System;
using System.Globalization;
using System.Windows.Data;

namespace DAN_LV_Milica_Karetic.Converter
{
    class RadioButtonConverter : IValueConverter
    {
        /// <summary>
        /// Converts the parameter value into a string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)parameter == (string)value);
        }

        /// <summary>
        /// Reverts it back
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? parameter : null;
        }
    }
}
