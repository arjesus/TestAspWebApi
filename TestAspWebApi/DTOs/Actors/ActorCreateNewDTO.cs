using System.ComponentModel.DataAnnotations;

namespace TestAspWebApi.DTOs.Actors
{
    public class ActorCreateNewDTO
    {
        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public IFormFile PhotoFile { get; set; }
    }
}
