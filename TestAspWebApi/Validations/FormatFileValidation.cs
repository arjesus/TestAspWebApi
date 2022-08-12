using System.ComponentModel.DataAnnotations;
using TestAspWebApi.Validations.Constants;
using TestAspWebApi.Validations.Enums;

namespace TestAspWebApi.Validations
{
    public class FormatFileValidation : ValidationAttribute
    {
        private readonly string[] _supportedFormats;

        public FormatFileValidation(params string[] supportedFormats)
        {
            _supportedFormats = supportedFormats;
        }

        public FormatFileValidation(params FormatFileEnum[] supportedFormats)
        {
            _supportedFormats = new string[0];
            foreach (FormatFileEnum formatFile in supportedFormats)
            {
                switch (formatFile)
                {
                    case FormatFileEnum.Image:
                        _supportedFormats = _supportedFormats
                            .Union(new string[] { FormatFileConstants.JPG, FormatFileConstants.JPEG, FormatFileConstants.PNG, FormatFileConstants.GIF })
                            .ToArray();
                        break;
                    default:
                        throw new NotSupportedException($"File format {formatFile} is not supported");
                }
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not IFormFile formFile)
            {
                return ValidationResult.Success;
            }

            if (!_supportedFormats.Contains(formFile.ContentType))
            {
                return new ValidationResult($"The {formFile.ContentType} format is not supported. Supported types: {string.Join(", ", _supportedFormats)}");
            }

            return ValidationResult.Success;
        }
    }
}
