namespace Common.DataAnnotations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UrlListAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;


            if (value is not List<string> urls)
                return new ValidationResult("Value is not a valid list of URLs.");

            foreach (var url in urls)
            {
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    return new ValidationResult($"Invalid URL: {url}");
                }
            }

            return ValidationResult.Success;
        }
    }

}