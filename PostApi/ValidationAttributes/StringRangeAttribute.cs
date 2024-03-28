using System.ComponentModel.DataAnnotations;

namespace PostApi.ValidationAttributes
{
    public class StringRangeAttribute : ValidationAttribute
    {
        public string[]? AllowableValues { get; set; }

        string defaultMessage = "Select From Allowed Values: {0}";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (AllowableValues is null)
            {
                return ValidationResult.Success;
            }

            if (AllowableValues.Contains(value))
            {
                return ValidationResult.Success;
            }

            var msg = ErrorMessage ??
                string.Format(defaultMessage, string.Join(", ", AllowableValues));

            return new ValidationResult(msg);
        }
    }
}