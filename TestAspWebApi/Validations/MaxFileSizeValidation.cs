using System.ComponentModel.DataAnnotations;

namespace TestAspWebApi.Validations
{
    public class MaxFileSizeValidation : ValidationAttribute
    {
        private readonly int _maxSizeInMb;

        public MaxFileSizeValidation(int maxSizeInMb)
        {
            _maxSizeInMb = maxSizeInMb;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not IFormFile formFile)
            {
                return ValidationResult.Success;
            }

            if (formFile.Length > _maxSizeInMb * 1024 * 1024)
            {
                return new ValidationResult($"The max size of the file must be {_maxSizeInMb}");
            }

            return ValidationResult.Success;
        }
    }
}
