using System.ComponentModel.DataAnnotations;
using TestAspWebApi.Validations;
using TestAspWebApi.Validations.Enums;

namespace TestAspWebApi.DTOs.Actors
{
    public class ActorCreateNewDTO
    {
        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        [MaxFileSizeValidation(maxSizeInMb: 4)]
        [FormatFileValidation(supportedFormats: FormatFileEnum.Image)]
        public IFormFile PhotoFile { get; set; }
    }
}
