using System;
using System.Globalization;
using Cirrious.CrossCore.Converters;
using Core.Models;

namespace Touch.Converters
{
   public class ContactFullNameConverter : IMvxValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
       {
           var contact = value as Contact;
           return contact == null ? null : contact.Firstname + " " + contact.Lastname;
       }

       public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
       {
           throw new NotImplementedException();
       }
    }
}
