using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Common.Web;

public class FutureDate : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime dateTime = Convert.ToDateTime(value);
        return dateTime > DateTime.Now ? ValidationResult.Success : new ValidationResult("A future date is required. " + dateTime.ToString("yyyy.MM.dd.hh:mm:ss"));
    }
}

public class PastDate : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime dateTime = Convert.ToDateTime(value);
        return dateTime < DateTime.Now ? ValidationResult.Success : new ValidationResult("A past date is required. " + dateTime.ToString("yyyy.MM.dd.hh:mm:ss"));
    }
}

public class ZeroValue : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        int num = (int)value;
        return num == 0 ? ValidationResult.Success : new ValidationResult("Zero value is required.");
    }
}

public class Password : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasLowerChar = new Regex(@"[a-z]+");
        var hasMinimumChars = new Regex(@".{6,}");

        var isValid = hasNumber.IsMatch(value.ToString()) && hasUpperChar.IsMatch(value.ToString()) && hasLowerChar.IsMatch(value.ToString()) && hasMinimumChars.IsMatch(value.ToString());
        return isValid ? ValidationResult.Success : new ValidationResult("Password must have a minimum length of 6 and contain both lower and upper case letters and numbers.");
    }
}
