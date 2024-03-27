using PostApi.Services;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PostApi.ValidationAttributes
{
    //public class StringRangeAttribute<T> : ValidationAttribute
    //{
    //    public T[] AllowableValues { get; set; }
    //    string defaultMessage = "Select From Allowed Values: {0}";

    //    protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
    //    {
    //        var convertedValue = Helper.Convert<T>(value.ToString());

    //        if (AllowableValues is null)
    //        {
    //            return ValidationResult.Success;
    //        }

    //        if (convertedValue != null && AllowableValues.Contains(convertedValue))
    //        {
    //            return ValidationResult.Success;
    //        }

    //        var msg = ErrorMessage ?? String.Format(defaultMessage, string.Join(", ", AllowableValues));
    //        return new ValidationResult(msg);
    //    }
    //}

    public class StringRangeAttribute : ValidationAttribute
    {
        public string[] AllowableValues { get; set; }
        string defaultMessage = "Select From Allowed Values: {0}";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (AllowableValues is null)
            {
                return ValidationResult.Success;
            }

            if (AllowableValues.Contains(value))
            {
                return ValidationResult.Success;
            }

            var msg = ErrorMessage ?? string.Format(defaultMessage, string.Join(", ", AllowableValues));
            return new ValidationResult(msg);
        }
    }

    public static class Helper
    {
        public static T Convert<T>(this string input)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    // Cast ConvertFromString(string text) : object to (T)
                    return (T)converter.ConvertFromString(input);
                }
                return default;
            }
            catch (NotSupportedException)
            {
                return default;
            }
        }
    }
}